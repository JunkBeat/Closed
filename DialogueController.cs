// Decompiled with JetBrains decompiler
// Type: DialogueController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
  public static DialogueController dc;
  public DialogueController.Callback callback;
  public bool talking;
  public bool hidden = true;
  public GameObject[] dialogueOptions;
  public GameObject frame;
  public Sprite frameNew;
  public Sprite frameOld;
  public TextFieldController bottomTextfield;
  public GameObject upperTextGameObject;
  public TextFieldController upperTextfield;
  public float cooldown;
  public float maxCooldown = 30f;
  private SpriteRenderer darkness;
  private float darknessAlpha;
  private float lastDarknessAlpha;
  private float targetAlpha = 0.5f;
  private float targetColor = 1f;

  private void Awake()
  {
    if ((Object) DialogueController.dc == (Object) null)
    {
      Object.DontDestroyOnLoad((Object) this.gameObject);
      DialogueController.dc = this;
    }
    else
    {
      if (!((Object) DialogueController.dc != (Object) this))
        return;
      Object.Destroy((Object) this.gameObject);
    }
  }

  public void ShowText(string text)
  {
    this.upperTextfield.center = true;
    this.upperTextfield.shift = new Vector2(0.0f, 0.0f);
    this.upperTextfield.viewText(text, quick: true, instant: true, mwidth: 230);
    this.upperTextfield.keepAlive = true;
  }

  public void HideText() => this.upperTextfield.dissmiss();

  private void Start()
  {
    this.talking = false;
    this.hidden = true;
    this.frame.GetComponent<SpriteRenderer>().enabled = false;
    this.cooldown = this.maxCooldown;
    this.bottomTextfield = GameObject.Find("BottomText").GetComponent<TextFieldController>();
    this.darkness = this.gameObject.transform.Find("darkness").GetComponent<SpriteRenderer>();
    this.darkness.color = new Color(0.0f, 0.0f, 0.0f, this.darknessAlpha);
    this.transform.position = new Vector3(0.0f, 0.0f, -4.5f);
    this.darkness.transform.position = new Vector3(0.0f, 0.0f, -4.2f);
    if (!((Object) this.upperTextfield == (Object) null))
      return;
    this.upperTextGameObject = new GameObject();
    this.upperTextfield = this.upperTextGameObject.AddComponent<TextFieldController>();
    this.upperTextGameObject.transform.parent = this.gameObject.transform;
    this.upperTextfield.container.transform.parent = this.upperTextGameObject.transform;
    this.upperTextGameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.upperTextGameObject.transform.position);
  }

  public void quickDialogue(Vector3 color, NPCActionController who, string what)
  {
    Vector3 color_b = color;
    TextFieldController component = who.gameObject.GetComponent<TextFieldController>();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, what, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color_b);
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  private void Update()
  {
    if ((Object) this.bottomTextfield == (Object) null)
      this.bottomTextfield = GameObject.Find("BottomText").GetComponent<TextFieldController>();
    if (!this.hidden && (PlayerController.pc.dialogue != PlayerController.DialogueState.NONE || Timeline.t.actions != null && Timeline.t.actions.Count > 0))
      this.hide();
    else if (!this.hidden && !this.talking)
      this.hide();
    else if (this.hidden && this.talking && PlayerController.pc.dialogue == PlayerController.DialogueState.NONE && (Timeline.t.actions == null || Timeline.t.actions.Count == 0))
      this.show();
    if (!this.hidden)
    {
      if ((double) this.darknessAlpha < (double) this.targetAlpha)
        this.darknessAlpha += (float) (0.75 * (double) Time.deltaTime * 1.5);
      if ((double) this.darknessAlpha > (double) this.targetAlpha)
        this.darknessAlpha = this.targetAlpha;
      PlayerController.pc.setBusy(true);
      if ((double) this.cooldown > 0.0)
      {
        this.cooldown -= (float) (1.0 * (double) Time.deltaTime * 60.0);
        if ((double) this.cooldown < 0.0)
          this.cooldown = 0.0f;
      }
    }
    else
    {
      if ((double) this.darknessAlpha > 0.0)
        this.darknessAlpha -= (float) (1.5 * (double) Time.deltaTime * 1.5);
      if ((double) this.darknessAlpha < 0.0)
        this.darknessAlpha = 0.0f;
    }
    if ((double) this.lastDarknessAlpha == (double) this.darknessAlpha)
      return;
    this.darkness.color = new Color(this.targetColor, this.targetColor, this.targetColor, this.darknessAlpha);
    this.lastDarknessAlpha = this.darknessAlpha;
  }

  public void show()
  {
    if ((Object) this.bottomTextfield == (Object) null)
      this.bottomTextfield = GameObject.Find("BottomText").GetComponent<TextFieldController>();
    if (this.callback != null)
      this.callback();
    this.hidden = false;
    for (int index = 0; index < this.dialogueOptions.Length; ++index)
    {
      if (this.dialogueOptions[index].GetComponent<DialogueOptionController>().caption != string.Empty)
        this.dialogueOptions[index].GetComponent<DialogueOptionController>().show();
    }
    this.cooldown = this.maxCooldown;
    if (GameObject.Find("Location").GetComponent<LocationManager>().showInventory)
      InventoryButtonController.ibc.hide();
    if (!((Object) GameObject.Find("journal") != (Object) null))
      return;
    GameObject.Find("journal").GetComponent<JournalButtonController>().hide();
  }

  public void hide()
  {
    this.hidden = true;
    this.HideText();
    for (int index = 0; index < this.dialogueOptions.Length; ++index)
      this.dialogueOptions[index].GetComponent<DialogueOptionController>().hide();
    if (this.talking)
      return;
    if (GameObject.Find("Location").GetComponent<LocationManager>().showInventory)
      InventoryButtonController.ibc.showFinal();
    if (!((Object) GameObject.Find("journal") != (Object) null))
      return;
    GameObject.Find("journal").GetComponent<JournalButtonController>().showFinal();
  }

  public void reset()
  {
    MonoBehaviour.print((object) ("RESETTING DIALOGUE OPTIONS... All " + (object) this.dialogueOptions.Length + " of them."));
    for (int index = 0; index < this.dialogueOptions.Length; ++index)
      this.dialogueOptions[index].GetComponent<DialogueOptionController>().caption = string.Empty;
  }

  public void initDialogue(
    List<DialogueLine> dialogueLines,
    string prefix,
    TextFieldController tf_a,
    Vector3 color_a,
    TextFieldController tf_b = null,
    Vector3 color_b = default (Vector3),
    TextFieldController tf_c = null,
    Vector3 color_c = default (Vector3),
    Sprite background = null)
  {
    if ((Object) background != (Object) null)
    {
      this.darkness.color = new Color(1f, 1f, 1f, this.darknessAlpha);
      this.transform.position = new Vector3(0.0f, 0.0f, -4.5f);
      this.darkness.transform.position = new Vector3(0.0f, 0.0f, -4.2f);
      this.darkness.GetComponent<SpriteRenderer>().sprite = background;
      this.darkness.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
      this.targetAlpha = 1f;
      this.targetColor = 1f;
    }
    else
    {
      this.targetColor = 0.0f;
      this.targetAlpha = 0.5f;
      this.darkness.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Misc/black");
      this.darkness.gameObject.transform.localScale = new Vector3(10f, 10f, 1f);
      this.darkness.color = new Color(0.0f, 0.0f, 0.0f, this.darknessAlpha);
    }
    bool flag = false;
    int num = 1;
    if (prefix == string.Empty)
    {
      dialogueLines.Add(new DialogueLine(tf_a, color_a, string.Empty, (TimelineFunction) null));
      dialogueLines[dialogueLines.Count - 1].displayText = false;
    }
    else
    {
      do
      {
        string str1 = GameStrings.getString(GameStrings.dialogues, prefix + "_" + (object) num + "_a");
        string str2 = GameStrings.getString(GameStrings.dialogues, prefix + "_" + (object) num + "_b");
        string str3 = GameStrings.getString(GameStrings.dialogues, prefix + "_" + (object) num + "_c");
        string empty = string.Empty;
        Vector3 tC = new Vector3(1f, 1f, 1f);
        if (str1.IndexOf("_STRING_MISSING") == -1)
        {
          string t = str1;
          TextFieldController src = tf_a;
          tC = color_a;
          dialogueLines.Add(new DialogueLine(src, tC, t, (TimelineFunction) null));
        }
        else if (str2.IndexOf("_STRING_MISSING") == -1)
        {
          string t = str2;
          TextFieldController src = tf_b;
          tC = color_b;
          dialogueLines.Add(new DialogueLine(src, tC, t, (TimelineFunction) null));
        }
        else if (str3.IndexOf("_STRING_MISSING") == -1)
        {
          string t = str3;
          TextFieldController src = tf_c;
          tC = color_c;
          dialogueLines.Add(new DialogueLine(src, tC, t, (TimelineFunction) null));
        }
        else
          flag = true;
        ++num;
      }
      while (!flag);
    }
  }

  public delegate void Callback();
}
