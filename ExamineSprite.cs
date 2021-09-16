// Decompiled with JetBrains decompiler
// Type: ExamineSprite
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class ExamineSprite : MonoBehaviour
{
  public static ExamineSprite es;
  public SpriteRenderer spriteRenderer;
  public SpriteRenderer spriteRenderer1;
  public SpriteRenderer spriteRenderer2;
  public SpriteRenderer spriteRenderer3;
  public SpriteRenderer spriteRenderer4;
  public ExamineSprite.Delegate lookAction;
  public bool actionOnShow;
  private float alpha;
  private float targetAlpha;
  private bool active;
  public TextFieldController textField;
  private List<string> pages;
  private int twidth;
  private float talpha;
  private Vector3 colors1;
  private Vector3 colors2;
  public string closingAnimation;
  public bool closingAnimationFlip;
  public bool cycleSprites;
  public bool quick = true;
  public AudioClip ac;
  public float audioVolume = 1f;

  public bool Active => this.active;

  private void Awake()
  {
    if ((Object) ExamineSprite.es == (Object) null)
    {
      Object.DontDestroyOnLoad((Object) this.gameObject);
      ExamineSprite.es = this;
      MonoBehaviour.print((object) "Inventory controler initialized");
    }
    else
    {
      if (!((Object) ExamineSprite.es != (Object) this))
        return;
      Object.Destroy((Object) this.gameObject);
    }
  }

  private void Start()
  {
    this.closingAnimation = (string) null;
    this.spriteRenderer = this.gameObject.transform.Find("sprite0").GetComponent<SpriteRenderer>();
    this.spriteRenderer1 = this.gameObject.transform.Find("sprite1").GetComponent<SpriteRenderer>();
    this.spriteRenderer2 = this.gameObject.transform.Find("sprite2").GetComponent<SpriteRenderer>();
    this.spriteRenderer3 = this.gameObject.transform.Find("sprite3").GetComponent<SpriteRenderer>();
    this.spriteRenderer4 = this.gameObject.transform.Find("sprite4").GetComponent<SpriteRenderer>();
    this.initTextfield();
  }

  private void initTextfield()
  {
    if (!((Object) this.textField == (Object) null))
      return;
    this.textField = this.gameObject.AddComponent<TextFieldController>();
    this.textField = this.gameObject.GetComponent<TextFieldController>();
    this.textField.transform.parent = this.gameObject.transform;
    this.textField.container.transform.parent = this.gameObject.transform;
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(120f, 67f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    this.gameObject.transform.position = worldPoint;
    worldPoint.y = 2f * worldPoint.y;
    this.spriteRenderer.gameObject.transform.position = worldPoint;
    worldPoint.z -= 0.1f;
    this.spriteRenderer1.gameObject.transform.position = worldPoint;
    worldPoint.z -= 0.1f;
    this.spriteRenderer2.gameObject.transform.position = worldPoint;
    worldPoint.z -= 0.1f;
    this.spriteRenderer3.gameObject.transform.position = worldPoint;
    worldPoint.z -= 0.1f;
    this.spriteRenderer4.gameObject.transform.position = worldPoint;
  }

  private void Update()
  {
    if ((double) this.targetAlpha < (double) this.alpha)
      this.alpha -= 0.1f;
    else if ((double) this.targetAlpha > (double) this.alpha)
      this.alpha += 0.1f;
    if ((double) Mathf.Abs(this.targetAlpha - this.alpha) < 0.100000001490116)
      this.alpha = this.targetAlpha;
    this.spriteRenderer.color = new Color(1f, 1f, 1f, this.alpha);
    float a = this.cycleSprites ? 0.0f : this.alpha;
    this.spriteRenderer1.color = new Color(1f, 1f, 1f, a);
    this.spriteRenderer2.color = new Color(1f, 1f, 1f, a);
    this.spriteRenderer3.color = new Color(1f, 1f, 1f, a);
    this.spriteRenderer4.color = new Color(1f, 1f, 1f, a);
  }

  public void show(
    Sprite sprite,
    Sprite sprite1 = null,
    Sprite sprite2 = null,
    Sprite sprite3 = null,
    Sprite sprite4 = null,
    ExamineSprite.Delegate act = null,
    bool actionOnOpen = true)
  {
    this.textField.center = false;
    this.gameObject.transform.position = new Vector3(0.0f, 0.0f, -5f);
    this.targetAlpha = 1f;
    this.alpha = 0.0f;
    this.active = true;
    GameObject.Find("BottomText").GetComponent<TextFieldController>().queued = string.Empty;
    GameObject.Find("BottomText").GetComponent<TextFieldController>().dissmiss();
    this.lookAction = act;
    this.actionOnShow = actionOnOpen;
    PlayerController.wc.fullStop(true);
    PlayerController.pc.setBusy(true);
    CursorController.cc.showCursor(CursorController.PixelCursor.OK);
    this.spriteRenderer.sprite = sprite;
    this.spriteRenderer1.sprite = sprite1;
    this.spriteRenderer2.sprite = sprite2;
    this.spriteRenderer3.sprite = sprite3;
    this.spriteRenderer4.sprite = sprite4;
    if (this.lookAction != null && this.actionOnShow)
    {
      this.lookAction();
      this.lookAction = (ExamineSprite.Delegate) null;
    }
    this.showPage();
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
  }

  private bool showPage()
  {
    if ((Object) this.ac != (Object) null)
      PlayerController.pc.aS.PlayOneShot(this.ac, this.audioVolume);
    GameObject.Find("BottomText").GetComponent<TextFieldController>().dissmiss(true);
    if (this.pages == null || this.pages.Count <= 0)
      return false;
    if (this.cycleSprites)
    {
      if ((Object) this.spriteRenderer1.sprite != (Object) null)
      {
        this.spriteRenderer.sprite = this.spriteRenderer1.sprite;
        this.spriteRenderer1.sprite = (Sprite) null;
      }
      else if ((Object) this.spriteRenderer2.sprite != (Object) null)
      {
        this.spriteRenderer.sprite = this.spriteRenderer2.sprite;
        this.spriteRenderer2.sprite = (Sprite) null;
      }
      else if ((Object) this.spriteRenderer3.sprite != (Object) null)
      {
        this.spriteRenderer.sprite = this.spriteRenderer3.sprite;
        this.spriteRenderer3.sprite = (Sprite) null;
      }
      else if ((Object) this.spriteRenderer4.sprite != (Object) null)
      {
        this.spriteRenderer.sprite = this.spriteRenderer4.sprite;
        this.spriteRenderer4.sprite = (Sprite) null;
      }
    }
    this.initTextfield();
    this.textField.keepAlive = true;
    this.textField.directionY = 1f;
    this.textField.viewText(this.pages[0], quick: this.quick, instant: this.quick, mwidth: this.twidth, r: this.colors1.x, g: this.colors1.y, b: this.colors1.z, br: this.colors2.x, bg: this.colors2.y, bb: this.colors2.z, ba: this.talpha);
    this.pages.RemoveAt(0);
    return true;
  }

  public void readyText(
    List<string> _pages,
    int w,
    float r1,
    float g1,
    float b1,
    float r2,
    float g2,
    float b2,
    float _talpha)
  {
    this.quick = true;
    MonoBehaviour.print((object) "READU TEXT");
    for (int index = 0; index < _pages.Count; ++index)
    {
      if (_pages[index].Equals(string.Empty) || _pages[index].Equals(" "))
      {
        _pages.RemoveAt(index);
        --index;
      }
    }
    if (_pages.Count > 0)
      MonoBehaviour.print((object) _pages[0]);
    this.pages = _pages;
    this.cycleSprites = false;
    this.twidth = w;
    this.colors1 = new Vector3(r1, g1, b1);
    this.colors2 = new Vector3(r2, g2, b2);
    this.talpha = _talpha;
  }

  public void hide()
  {
    if (this.showPage())
      return;
    this.ac = (AudioClip) null;
    this.audioVolume = 1f;
    this.active = false;
    this.pages = (List<string>) null;
    this.targetAlpha = 0.0f;
    MonoBehaviour.print((object) ("HIDE EXAMINE SPRITE " + (object) (this.closingAnimation == null)));
    MonoBehaviour.print((object) ("IS THERE AN ACTION TO DO? " + (object) this.lookAction));
    CursorController.cc.showCursor(CursorController.PixelCursor.NORMAL);
    CursorController.cc.clearOverride();
    this.initTextfield();
    if (!this.quick)
      this.textField.dissmiss();
    this.textField.keepAlive = false;
    if (this.closingAnimation != null)
    {
      PlayerController.wc.forceAnimation(this.closingAnimation, this.closingAnimationFlip);
      this.closingAnimationFlip = false;
      this.closingAnimation = (string) null;
    }
    else
      PlayerController.pc.setBusy(false);
    if (this.lookAction == null || this.actionOnShow)
      return;
    this.lookAction();
    this.lookAction = (ExamineSprite.Delegate) null;
  }

  public delegate void Delegate();
}
