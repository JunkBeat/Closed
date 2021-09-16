// Decompiled with JetBrains decompiler
// Type: TextFieldController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TextFieldController : MonoBehaviour
{
  private Sprite[] sprites;
  private List<string> spritesNames;
  private List<GameObject> chars;
  public bool center;
  public int maxWidth;
  public float directionY = -1f;
  private float smod = 0.08f;
  private int pmod;
  private int pmod2;
  private bool isSmooth;
  public Vector2 shift = new Vector2(0.0f, 18f);
  [SerializeField]
  private float waitTillDelete;
  [SerializeField]
  private float currentWait;
  public bool keepAlive;
  private int lineHeight = 8;
  private List<int> linesBegins;
  private List<int> linesLengths;
  public GameObject black;
  private int longestLine;
  private string typed;
  public string queued;
  private bool positionEverytime;
  public bool blockTop = true;
  public int OPTIONAL_MARGIN;
  private float delay;
  private float currentDelay;
  private int perUpdate;
  private float red = 1f;
  private float green = 1f;
  private float blue = 1f;
  private float alpha = 1f;
  private float bgred;
  private float bggreen;
  private float bgblue;
  private float bgalpha;
  public byte[] bytes;
  private Vector2 norm1;
  private Vector3 norm2;
  public GameObject container;
  private bool blockGame;
  private float currentHeight;
  public float zzz = -6f;
  public int maxLines = -1;
  public MonoBehaviour test;
  public string remains;
  private AudioClip pyk;
  public GameObject MainCamera;
  public static float cameraShiftY;
  public static float BASE_DELAY;
  public bool force_pixel_font;
  public bool force_smooth_font;
  public bool useSeparateCamera = true;

  public List<GameObject> getChars() => this.chars;

  private void createBlack()
  {
    this.black = new GameObject("black");
    this.black.layer = LayerMask.NameToLayer("text");
    this.black.AddComponent<SpriteRenderer>();
    this.black.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Misc/black");
    this.black.transform.parent = this.container.transform;
    this.black.SetActive(false);
  }

  public void setTime(float t)
  {
    this.waitTillDelete = t;
    this.keepAlive = false;
  }

  private void Awake()
  {
    TextFieldController.BASE_DELAY = PlayerPrefs.GetFloat("textSpeed", 0.05f);
    this.queued = string.Empty;
    this.container = new GameObject("container");
    this.container.layer = LayerMask.NameToLayer("text");
    this.force_pixel_font = false;
    this.force_smooth_font = false;
    this.createBlack();
    this.isSmooth = false;
    this.updateFont();
    this.initThings();
  }

  public void initThings()
  {
    this.spritesNames = new List<string>();
    this.chars = new List<GameObject>();
    this.remains = string.Empty;
    for (int index = 0; index < this.sprites.Length; ++index)
      this.spritesNames.Add(this.sprites[index].name);
  }

  public void updateFont()
  {
    this.sprites = Resources.LoadAll<Sprite>("Bitmaps/Misc/smoothFont");
    this.smod = 0.03f;
    this.pmod = 3;
    this.pmod2 = 2;
  }

  public void positionTextfield(int x, int y)
  {
    Vector2 screen = ScreenControler.gameToScreen(new Vector2((float) x, (float) y));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    this.gameObject.transform.position = worldPoint;
  }

  public void setAlpha(float a)
  {
    for (int index = 0; index < this.chars.Count; ++index)
      this.chars[index].GetComponent<SpriteRenderer>().color = new Color(this.red, this.green, this.blue, a);
  }

  public void setTextColor(float r, float g, float b)
  {
    for (int index = 0; index < this.chars.Count; ++index)
      this.chars[index].GetComponent<SpriteRenderer>().color = new Color(r, g, b, 1f);
    this.red = r;
    this.green = g;
    this.blue = b;
  }

  public void setBGColor(float r, float g, float b, float a)
  {
    this.bgred = r;
    this.bggreen = g;
    this.bgblue = b;
    this.bgalpha = a;
  }

  public void viewText(
    string text,
    bool blockG = false,
    bool quick = false,
    bool instant = false,
    int mwidth = -1,
    float r = 1f,
    float g = 1f,
    float b = 1f,
    float br = 0.0f,
    float bg = 0.0f,
    float bb = 0.0f,
    float ba = 0.75f,
    bool constantRefresh = false,
    bool mute = false)
  {
    TextFieldController.BASE_DELAY = PlayerPrefs.GetFloat("textSpeed", 0.05f);
    if (mwidth == -1)
      mwidth = !(PlayerPrefs.GetString("lang") == GameStrings.Language.DE.ToString()) ? 100 : 130;
    this.maxWidth = mwidth;
    this.queued = string.Empty;
    this.remains = string.Empty;
    this.dissmiss();
    this.positionEverytime = constantRefresh;
    this.setBGColor(br, bg, bb, ba);
    this.setTextColor(r, g, b);
    this.keepAlive = false;
    if (blockG)
    {
      this.blockGame = true;
      GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>().showCursor(CursorController.PixelCursor.OK);
      PlayerController.pc.setDialogue(this.gameObject);
      this.delay = TextFieldController.BASE_DELAY;
      this.currentDelay = 0.0f;
      this.perUpdate = 1;
      this.waitTillDelete = -1f;
      this.pyk = SoundsManagerController.sm.pyk;
    }
    else
    {
      this.blockGame = false;
      this.delay = 0.0f;
      if (!quick)
        this.delay = TextFieldController.BASE_DELAY;
      this.currentDelay = 0.0f;
      this.perUpdate = 1;
      this.pyk = (AudioClip) null;
    }
    if (mute)
      this.pyk = (AudioClip) null;
    this.waitTillDelete = (float) (0.5 + (double) text.Length / 10.0);
    if (quick)
    {
      this.waitTillDelete = 0.0f;
      this.keepAlive = true;
      this.currentDelay = 1000f;
      this.perUpdate = 2;
      if (instant)
      {
        this.delay = 0.0f;
        this.currentDelay = 100f;
        this.perUpdate = 10000;
      }
    }
    this.currentWait = 0.0f;
    if ((Object) this.black == (Object) null)
      this.createBlack();
    this.black.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    this.black.SetActive(true);
    this.black.GetComponent<SpriteRenderer>().color = new Color(this.bgred, this.bggreen, this.bgblue, this.bgalpha);
    this.queued = text;
    this.Update();
  }

  private Vector3 coords(Vector2 source)
  {
    Vector2 screen1 = ScreenControler.gameToScreen(new Vector2(source.x, source.y));
    Vector3 worldPoint1 = Camera.main.ScreenToWorldPoint(new Vector3(screen1.x, screen1.y, 0.0f));
    Vector2 screen2 = ScreenControler.gameToScreen(new Vector2(0.0f, 0.0f));
    Vector3 worldPoint2 = Camera.main.ScreenToWorldPoint(new Vector3(screen2.x, screen2.y, 0.0f));
    worldPoint1.x -= worldPoint2.x;
    worldPoint1.y -= worldPoint2.y;
    return worldPoint1;
  }

  private void Update()
  {
    this.currentDelay += Time.deltaTime;
    bool flag = false;
    if (this.queued.Length < this.perUpdate)
      this.perUpdate = this.queued.Length;
    if (this.perUpdate == 0)
      this.perUpdate = 1;
    if (this.queued.Length > 0)
    {
      if ((double) this.currentDelay >= (double) this.delay)
      {
        this.currentDelay = 0.0f;
        if (((Object) CurtainController.cc == (Object) null || !CurtainController.cc.okToGo()) && (double) this.delay > 0.0 && this.blockGame)
          return;
        for (int index = 0; index < this.perUpdate; ++index)
        {
          if (this.queued.Length > 0)
          {
            flag = true;
            this.typed += this.queued[0].ToString();
            this.container.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            this.addText(this.queued[0].ToString());
            if (this.queued.Length > 0)
              this.queued = this.queued.Substring(1);
          }
        }
        if (this.queued.Length == 0 && this.blockGame && PlayerController.pc.dialogue == PlayerController.DialogueState.WAIT_TO_SPEED)
        {
          PlayerController.pc.dialogue = PlayerController.DialogueState.WAIT_TO_DISMISS;
          if ((bool) (Object) this.pyk)
            PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.pyk2, 0.75f);
        }
        if (flag && !this.positionEverytime)
          this.arrange();
      }
    }
    else if (this.blockGame && PlayerController.pc.dialogue == PlayerController.DialogueState.WAIT_TO_SPEED)
    {
      if (this.keepAlive)
        PlayerController.pc.dialogue = PlayerController.DialogueState.WAIT_TO_DISMISS;
    }
    else if (!this.blockGame && (double) this.waitTillDelete >= 0.0)
    {
      if (!this.keepAlive)
      {
        this.currentWait += Time.deltaTime;
        if ((double) this.currentWait >= (double) this.waitTillDelete)
        {
          this.waitTillDelete = -1f;
          this.dissmiss();
        }
      }
    }
    else if (PlayerController.pc.dialogue.Equals((object) PlayerController.DialogueState.NONE))
      this.dissmiss();
    Vector3 vector3 = this.coords(new Vector2(this.shift.x, this.shift.y));
    this.container.transform.position = new Vector3(this.gameObject.transform.position.x + vector3.x, this.gameObject.transform.position.y + vector3.y, this.zzz);
    float num1 = (float) (this.longestLine / 2);
    if (this.center)
      num1 = 0.0f;
    int num2 = 5;
    Vector2 screen1 = ScreenControler.gameToScreen(new Vector2((float) ScreenControler.sourceWidth - Mathf.Floor((float) (this.longestLine / 2)) - num1 - (float) num2 - (float) this.OPTIONAL_MARGIN, this.currentHeight));
    Vector3 worldPoint1 = Camera.main.ScreenToWorldPoint(new Vector3(screen1.x, screen1.y, 0.0f));
    if ((double) this.container.transform.position.x >= (double) worldPoint1.x)
      this.container.transform.position = new Vector3(worldPoint1.x, this.container.transform.position.y, this.container.transform.position.z);
    if ((double) this.container.transform.position.y >= -(double) worldPoint1.y && this.blockTop && (double) this.directionY == -1.0)
      this.container.transform.position = new Vector3(this.container.transform.position.x, -worldPoint1.y, this.container.transform.position.z);
    Vector2 screen2 = ScreenControler.gameToScreen(new Vector2(Mathf.Floor((float) (this.longestLine / 2)) - num1 + (float) num2 + (float) this.OPTIONAL_MARGIN, this.shift.y));
    Vector3 worldPoint2 = Camera.main.ScreenToWorldPoint(new Vector3(screen2.x, screen2.y, 0.0f));
    if ((double) this.container.transform.position.x > (double) worldPoint2.x)
      return;
    this.container.transform.position = new Vector3(worldPoint2.x, this.container.transform.position.y, this.container.transform.position.z);
  }

  public void speedUp()
  {
    if (this.queued.Length == 0)
      return;
    this.delay = 0.0f;
    this.perUpdate = 20;
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.pyk2, 0.75f);
    this.pyk = (AudioClip) null;
  }

  public void terminate()
  {
    this.delay = 0.0f;
    this.perUpdate = 10000;
    this.queued = string.Empty;
    this.keepAlive = false;
  }

  public bool dissmiss(bool hard = false)
  {
    if (hard)
      this.queued = string.Empty;
    this.bgalpha = 0.75f;
    this.bgred = this.bggreen = this.bgblue = 0.0f;
    this.blockGame = false;
    if (this.queued.Length != 0 || this.chars == null)
      return false;
    while (this.chars.Count > 0)
    {
      Object.Destroy((Object) this.chars[0]);
      this.chars.RemoveAt(0);
    }
    this.typed = string.Empty;
    this.queued = string.Empty;
    this.longestLine = 0;
    if ((Object) this.black != (Object) null)
      this.black.SetActive(false);
    return true;
  }

  private void addText(string text)
  {
    for (int index1 = 0; index1 < text.Length; ++index1)
    {
      GameObject gameObject = new GameObject("Tf_" + this.gameObject.name + "_t_" + (object) index1);
      gameObject.transform.parent = this.container.transform;
      char ch = text[index1];
      if (ch.ToString().Equals("^"))
      {
        this.bytes = Encoding.UTF8.GetBytes(" ");
      }
      else
      {
        ch = text[index1];
        if (ch.ToString().Equals("₴"))
        {
          this.bytes = Encoding.UTF8.GetBytes("@");
        }
        else
        {
          Encoding utF8 = Encoding.UTF8;
          ch = text[index1];
          string s = ch.ToString();
          this.bytes = utF8.GetBytes(s);
        }
      }
      int index2 = this.spritesNames.IndexOf((this.ToHex(this.bytes).ToString().Length != 2 ? (this.ToHex(this.bytes).ToString().Length != 3 ? "U+" + this.ToHex(this.bytes) : "U+0" + this.ToHex(this.bytes)) : "U+00" + this.ToHex(this.bytes)).ToUpper());
      if (index2 > -1)
      {
        gameObject.AddComponent<SpriteRenderer>();
        gameObject.GetComponent<SpriteRenderer>().sprite = this.sprites[index2];
        gameObject.GetComponent<SpriteRenderer>().color = new Color(this.red, this.green, this.blue);
        this.chars.Add(gameObject);
        if (this.useSeparateCamera)
          gameObject.layer = LayerMask.NameToLayer(nameof (text));
        if ((bool) (Object) this.pyk)
          PlayerController.pc.aS.PlayOneShot(this.pyk, 0.5f);
      }
    }
    if (!this.positionEverytime)
      return;
    this.arrange();
  }

  private string ToHex(byte[] bytes)
  {
    char[] chArray = new char[bytes.Length * 2];
    int index1 = 0;
    int index2 = 0;
    while (index1 < bytes.Length)
    {
      byte num1 = (byte) ((uint) bytes[index1] >> 4);
      chArray[index2] = num1 <= (byte) 9 ? (char) ((int) num1 + 48) : (char) ((int) num1 + 55 + 32);
      byte num2 = (byte) ((uint) bytes[index1] & 15U);
      int num3;
      chArray[num3 = index2 + 1] = num2 <= (byte) 9 ? (char) ((int) num2 + 48) : (char) ((int) num2 + 55 + 32);
      ++index1;
      index2 = num3 + 1;
    }
    return new string(chArray);
  }

  private void arrange()
  {
    this.linesBegins = new List<int>();
    this.linesBegins.Add(0);
    this.linesLengths = new List<int>();
    this.linesLengths.Add(0);
    for (int index1 = 0; index1 < this.chars.Count; ++index1)
    {
      int num1 = this.pmod;
      if ((double) this.chars[index1].GetComponent<SpriteRenderer>().sprite.rect.width < 30.0 && this.pmod > 1)
        num1 = this.pmod2;
      int num2 = this.linesLengths[this.linesLengths.Count - 1] + (int) ((double) this.chars[index1].GetComponent<SpriteRenderer>().sprite.rect.width * (double) this.smod) + num1;
      int num3 = 0;
      for (int index2 = index1; index2 < this.typed.Length; ++index2)
      {
        if (this.typed[index2].Equals(' ') || index2 == this.typed.Length - 1)
        {
          num2 -= (int) ((double) this.chars[index1].GetComponent<SpriteRenderer>().sprite.rect.width * (double) this.smod) + num1;
          int length = this.typed.Length;
          break;
        }
        num2 += (int) ((double) this.chars[index2].GetComponent<SpriteRenderer>().sprite.rect.width * (double) this.smod) + num1;
        ++num3;
      }
      bool flag = true;
      if (num2 > this.maxWidth)
        flag = this.newLine(index1);
      if (flag)
      {
        this.positionCharacter(this.chars[index1], this.linesLengths[this.linesLengths.Count - 1]);
        List<int> linesLengths;
        int index3;
        int num4 = (linesLengths = this.linesLengths)[index3 = this.linesLengths.Count - 1] + ((int) ((double) this.chars[index1].GetComponent<SpriteRenderer>().sprite.rect.width * (double) this.smod) + num1);
        linesLengths[index3] = num4;
        if (this.linesLengths[this.linesLengths.Count - 1] > this.longestLine)
          this.longestLine = this.linesLengths[this.linesLengths.Count - 1];
      }
      if (this.typed.Length > index1 && this.typed[index1].Equals('^'))
        this.newLine(index1);
    }
    for (int index = 0; index < this.linesBegins.Count; ++index)
    {
      int end = this.chars.Count;
      if (index + 1 < this.linesBegins.Count)
        end = this.linesBegins[index + 1];
      int line = this.linesLengths.Count - index - 1;
      if ((double) this.directionY == 1.0)
        line = index;
      this.placeAndCenterLine(this.linesBegins[index], end, this.linesLengths[index], line);
    }
    if ((Object) this.black == (Object) null)
      this.createBlack();
    float num5 = Mathf.Floor(this.black.GetComponent<SpriteRenderer>().sprite.rect.width);
    float num6 = Mathf.Floor(this.black.GetComponent<SpriteRenderer>().sprite.rect.height);
    float longestLine = (float) this.longestLine;
    float num7 = (float) (this.linesLengths.Count * this.lineHeight);
    if ((double) longestLine / 2.0 == (double) Mathf.Floor(longestLine / 2f))
      ++longestLine;
    float num8 = longestLine + 3f;
    float num9 = num7 + 2f;
    this.currentHeight = num9;
    this.black.transform.localScale = new Vector3(num8 / num5, num9 / num6, 1f);
    float num10 = 1f;
    if (this.center)
      num10 = 0.0f;
    float num11 = 1f;
    if ((double) this.directionY == 1.0)
      num11 = -1f;
    float num12 = 0.0f;
    if ((double) this.directionY == 1.0)
      num12 = 10f;
    Vector3 vector3 = this.coords(new Vector2(num10 * (float) ((double) num8 / 2.0 - 2.0), (float) ((double) num11 * (double) num9 / 2.0 - 3.0) + num12));
    this.black.transform.position = new Vector3(vector3.x, vector3.y, this.black.transform.position.z);
    this.black.GetComponent<SpriteRenderer>().color = new Color(this.bgred, this.bggreen, this.bgblue, this.bgalpha);
  }

  private bool newLine(int num, int extraChars = 0)
  {
    this.linesBegins.Add(num);
    this.linesLengths.Add(0);
    if (this.maxLines <= 0 || this.linesBegins.Count <= this.maxLines)
      return true;
    int num1 = 0;
    if (this.typed.Substring(num, 1).Equals("^"))
      num1 = 1;
    this.remains = this.typed.Substring(num + num1);
    if (this.queued.Length > 1)
      this.remains += this.queued.Substring(1);
    while (this.chars.Count > num)
    {
      Object.Destroy((Object) this.chars[this.chars.Count - 1]);
      this.typed = this.typed.Remove(this.chars.Count - 1, 1);
      this.chars.RemoveAt(this.chars.Count - 1);
    }
    this.queued = string.Empty;
    return false;
  }

  private void positionCharacter(GameObject ch, int lx)
  {
    Vector2 screen = ScreenControler.gameToScreen(new Vector2((float) lx * 1f, 0.0f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, -1f));
    worldPoint.z = -2f;
    ch.transform.position = worldPoint;
  }

  private void placeAndCenterLine(int start, int end, int lineLength, int line)
  {
    float num = 0.0f;
    if (this.center)
      num = 1f;
    Vector2 screen = ScreenControler.gameToScreen(new Vector2((float) lineLength * 0.5f * num, (float) (-this.lineHeight * line)));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    for (int index = start; index < end; ++index)
      this.chars[index].transform.position = new Vector3(this.chars[index].transform.position.x - worldPoint.x, (float) (-1.0 * (double) this.directionY * ((double) this.chars[index].transform.position.y - (double) worldPoint.y)), -0.1f);
  }

  public string TypedText => this.typed;
}
