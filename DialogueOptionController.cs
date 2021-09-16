// Decompiled with JetBrains decompiler
// Type: DialogueOptionController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class DialogueOptionController : MonoBehaviour
{
  public string caption;
  public bool active;
  public bool alphaSet;
  public string objective;
  public GameObject background;
  public List<DialogueLine> lines;
  private SpriteRenderer rend;
  private SpriteRenderer backgroundRend;
  public CursorController cc;
  public int number;
  public float localCooldown;
  private int maxCooldown = 30;
  public AudioSource audioSource;

  private void Start()
  {
    this.lines = new List<DialogueLine>();
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    this.alphaSet = false;
    this.cc = GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>();
    this.hide();
    this.background.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.background.transform.position.z);
    this.number *= 10;
    if (!((Object) this.audioSource == (Object) null))
      return;
    if ((Object) GameObject.Find("static_dust").GetComponent<AudioSource>() == (Object) null)
    {
      this.audioSource = GameObject.Find("static_dust").AddComponent<AudioSource>();
      this.audioSource.ignoreListenerPause = true;
      this.audioSource.ignoreListenerVolume = true;
    }
    else
      this.audioSource = GameObject.Find("static_dust").GetComponent<AudioSource>();
  }

  private void Update()
  {
    if ((Object) this.rend == (Object) null)
      this.rend = this.gameObject.GetComponent<SpriteRenderer>();
    if ((Object) this.backgroundRend == (Object) null)
      this.backgroundRend = this.background.GetComponent<SpriteRenderer>();
    if ((double) this.localCooldown > 0.0)
      this.localCooldown -= (float) (1.0 * (double) Time.deltaTime * 60.0);
    float num1 = ((float) this.maxCooldown - this.localCooldown + (float) this.number) / ((float) this.maxCooldown + (float) this.number);
    float num2 = num1 * num1;
    this.rend.color = new Color(num2, num2, num2, num2);
    this.backgroundRend.color = new Color(num2, num2, num2, num2);
  }

  private void OnMouseEnter()
  {
    Vector3 vector3 = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, DialogueController.dc.frame.transform.position.z);
    DialogueController.dc.frame.transform.position = vector3;
    if (PlayerController.pc.dialogue != PlayerController.DialogueState.NONE || (double) DialogueController.dc.cooldown != 0.0)
      return;
    if ((Object) this.cc == (Object) null)
      this.cc = GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>();
    this.cc.showCursor(CursorController.PixelCursor.ACTIVE);
    DialogueController.dc.frame.GetComponent<SpriteRenderer>().enabled = true;
    if ((Object) this.audioSource == (Object) null)
    {
      if ((Object) GameObject.Find("static_dust").GetComponent<AudioSource>() == (Object) null)
      {
        this.audioSource = GameObject.Find("static_dust").AddComponent<AudioSource>();
        this.audioSource.ignoreListenerPause = true;
        this.audioSource.ignoreListenerVolume = true;
      }
      else
        this.audioSource = GameObject.Find("static_dust").GetComponent<AudioSource>();
    }
    this.audioSource.volume = (float) PlayerPrefs.GetInt("sound") / 100f;
    this.audioSource.PlayOneShot(SoundsManagerController.sm.ui_hover);
    DialogueController.dc.bottomTextfield.viewText(this.caption, quick: true, mwidth: ObjectActionController.BOTTOM_TEXT_WIDTH);
  }

  private void OnMouseDown()
  {
    PlayerController.pc.clickedSomething = true;
    if (PlayerController.pc.dialogue != PlayerController.DialogueState.NONE || (double) DialogueController.dc.cooldown != 0.0)
      return;
    for (int index = 0; index < this.lines.Count; ++index)
    {
      if (this.lines[index].text.Length > 0)
      {
        PlayerController.pc.setBusy(true);
        PlayerController.pc.dialogue = PlayerController.DialogueState.WAIT_TO_SPEED;
      }
      Timeline.t.addDialogue(this.lines[index]);
    }
    if ((Object) this.audioSource == (Object) null)
    {
      if ((Object) GameObject.Find("static_dust").GetComponent<AudioSource>() == (Object) null)
      {
        this.audioSource = GameObject.Find("static_dust").AddComponent<AudioSource>();
        this.audioSource.ignoreListenerPause = true;
        this.audioSource.ignoreListenerVolume = true;
      }
      else
        this.audioSource = GameObject.Find("static_dust").GetComponent<AudioSource>();
    }
    this.audioSource.volume = (float) PlayerPrefs.GetInt("sound") / 100f;
    this.audioSource.PlayOneShot(SoundsManagerController.sm.ui_click, 0.5f);
    DialogueController.dc.cooldown = DialogueController.dc.maxCooldown;
    if (this.objective.Length > 0)
      GameDataController.gd.setObjective(this.objective, true);
    this.objective = string.Empty;
    DialogueController.dc.frame.GetComponent<SpriteRenderer>().enabled = false;
  }

  private void OnMouseOver()
  {
    if (PlayerController.pc.dialogue != PlayerController.DialogueState.NONE || (double) DialogueController.dc.cooldown != 0.0)
      return;
    if ((Object) this.cc == (Object) null)
      this.cc = GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>();
    this.cc.showCursor(CursorController.PixelCursor.ACTIVE);
    DialogueController.dc.frame.GetComponent<SpriteRenderer>().enabled = true;
    if (DialogueController.dc.bottomTextfield.TypedText.Length != 0)
      return;
    DialogueController.dc.bottomTextfield.viewText(this.caption, quick: true, mwidth: ObjectActionController.BOTTOM_TEXT_WIDTH);
  }

  private void OnMouseExit()
  {
    DialogueController.dc.frame.GetComponent<SpriteRenderer>().enabled = false;
    GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>().showCursor(CursorController.PixelCursor.NORMAL);
    GameObject.Find("BottomText").GetComponent<TextFieldController>().keepAlive = false;
    DialogueController.dc.bottomTextfield.dissmiss(true);
  }

  public void setObjective(string ob)
  {
    this.objective = ob;
    if (this.objective != string.Empty && GameDataController.gd.getObjective(this.objective))
      this.background.GetComponent<SpriteRenderer>().sprite = DialogueController.dc.frameOld;
    else
      this.background.GetComponent<SpriteRenderer>().sprite = DialogueController.dc.frameNew;
  }

  public void show()
  {
    this.rend.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    this.backgroundRend.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    this.localCooldown = (float) (this.maxCooldown + this.number);
    this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    this.background.GetComponent<SpriteRenderer>().enabled = true;
    this.active = true;
  }

  public void hide()
  {
    this.localCooldown = (float) (this.maxCooldown + this.number);
    this.active = false;
    this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    this.background.GetComponent<SpriteRenderer>().enabled = false;
    this.background.GetComponent<SpriteRenderer>().sprite = DialogueController.dc.frameNew;
  }

  public void initDialogue(
    List<DialogueLine> dialogueLines,
    string prefix,
    TextFieldController tf_a,
    Vector3 color_a,
    TextFieldController tf_b,
    Vector3 color_b,
    TextFieldController tf_c = null,
    Vector3 color_c = default (Vector3))
  {
    int num = 0;
    string str1 = GameStrings.getString(GameStrings.dialogues, prefix + (object) num + "_a");
    string str2 = GameStrings.getString(GameStrings.dialogues, prefix + (object) num + "_b");
    string t = string.Empty;
    TextFieldController src = (TextFieldController) null;
    Vector3 tC = new Vector3(1f, 1f, 1f);
    if (str1.IndexOf("_STRING_MISSING") == -1)
    {
      t = str1;
      src = tf_a;
      tC = color_a;
    }
    if (str2.IndexOf("_STRING_MISSING") == -1)
    {
      t = str2;
      src = tf_b;
      tC = color_b;
    }
    dialogueLines.Add(new DialogueLine(src, tC, t, (TimelineFunction) null));
  }
}
