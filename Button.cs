// Decompiled with JetBrains decompiler
// Type: Button
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class Button : MonoBehaviour
{
  protected BoxCollider2D bcol;
  private CursorController cursorCont;
  public TextFieldController buttonText;
  public AudioSource audioSource;
  public bool workIfBusy = true;
  public Vector3 color1;
  public Vector3 color2;
  public Vector3 background1;
  public Vector3 background2;
  public float alpha2;
  public float alpha1;
  public bool buttonEnabled = true;
  public Button.Delegate onClick;
  public Button.Delegate onHover;

  private void Start()
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

  private void Update()
  {
    if (this.buttonEnabled)
    {
      if ((Object) this.bcol == (Object) null)
        this.bcol = this.gameObject.GetComponent<BoxCollider2D>();
      this.bcol.enabled = true;
      if ((Object) this.buttonText == (Object) null)
        this.buttonText = this.gameObject.GetComponent<TextFieldController>();
      this.bcol.size = (Vector2) this.buttonText.black.GetComponent<SpriteRenderer>().bounds.size;
      this.bcol.offset = new Vector2(this.buttonText.black.GetComponent<SpriteRenderer>().bounds.center.x - this.gameObject.transform.position.x, this.buttonText.black.GetComponent<SpriteRenderer>().bounds.center.y - this.gameObject.transform.position.y);
    }
    else
    {
      if ((Object) this.bcol == (Object) null)
        this.bcol = this.gameObject.GetComponent<BoxCollider2D>();
      this.bcol.enabled = false;
    }
  }

  private void OnMouseDown()
  {
    if (this.onClick == null || !this.workIfBusy && PlayerController.wc.busy)
      return;
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
    this.onClick();
  }

  public void initButton(string label)
  {
    this.initCursor();
    this.buttonText = this.gameObject.GetComponent<TextFieldController>();
    this.bcol = this.gameObject.GetComponent<BoxCollider2D>();
    this.buttonText.viewText(label, quick: true, instant: true, mwidth: 200);
    this.buttonText.keepAlive = true;
    this.onHover = (Button.Delegate) null;
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    if ((Object) this.buttonText == (Object) null)
      this.buttonText = this.gameObject.GetComponent<TextFieldController>();
    this.buttonText.setTextColor(this.color1.x, this.color1.y, this.color1.z);
    this.buttonText.black.GetComponent<SpriteRenderer>().color = new Color(this.background1.x, this.background1.y, this.background1.z, this.alpha1);
  }

  private void initCursor() => this.cursorCont = GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>();

  private void OnMouseOver()
  {
    if (!this.workIfBusy && PlayerController.wc.busy)
      return;
    if ((Object) this.cursorCont == (Object) null)
      this.initCursor();
    this.cursorCont.showCursor(CursorController.PixelCursor.ACTIVE);
    if (this.onHover != null)
      this.onHover();
    if ((Object) this.buttonText == (Object) null)
      this.buttonText = this.gameObject.GetComponent<TextFieldController>();
    this.buttonText.setTextColor(this.color2.x, this.color2.y, this.color2.z);
    this.buttonText.black.GetComponent<SpriteRenderer>().color = new Color(this.background2.x, this.background2.y, this.background2.z, this.alpha2);
  }

  private void OnMouseEnter()
  {
    if ((Object) this.cursorCont == (Object) null)
      this.initCursor();
    if (!this.workIfBusy && PlayerController.wc.busy)
      return;
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
  }

  private void OnMouseExit()
  {
    if ((Object) this.cursorCont == (Object) null)
      this.initCursor();
    this.cursorCont.showCursor(CursorController.PixelCursor.NORMAL);
    if ((Object) this.buttonText == (Object) null)
      this.buttonText = this.gameObject.GetComponent<TextFieldController>();
    this.buttonText.setTextColor(this.color1.x, this.color1.y, this.color1.z);
    this.buttonText.black.GetComponent<SpriteRenderer>().color = new Color(this.background1.x, this.background1.y, this.background1.z, this.alpha1);
  }

  public delegate void Delegate();
}
