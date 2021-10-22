// Decompiled with JetBrains decompiler
// Type: QuestionController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class QuestionController : MonoBehaviour
{
  private TextFieldController questionText;
  public Button yes;
  public Button no;
  public float antiDoubleClick;
  private int timeAdded;
  public Button.Delegate onYesClick;
  public Button.Delegate onNoClick;
  private SpriteRenderer darkness;
  public static QuestionController qc;
  private CursorController cursorCont;
  public static bool questionAsked;

  private void Awake()
  {
    if ((Object) QuestionController.qc == (Object) null)
    {
      Object.DontDestroyOnLoad((Object) this.gameObject);
      QuestionController.qc = this;
    }
    else
    {
      if (!((Object) QuestionController.qc != (Object) this))
        return;
      Object.Destroy((Object) this.gameObject);
    }
  }

  private void Start()
  {
    this.darkness = this.gameObject.transform.Find("darkness").GetComponent<SpriteRenderer>();
    this.questionText = this.gameObject.GetComponent<TextFieldController>();
    this.yes = this.gameObject.transform.Find("yes").GetComponent<Button>();
    this.no = this.gameObject.transform.Find("no").GetComponent<Button>();
    this.questionText.transform.parent = this.gameObject.transform;
    this.questionText.container.transform.parent = this.gameObject.transform;
    this.questionText.transform.position = ScreenControler.roundToNearestFullPixel2(this.questionText.transform.position);
    this.gameObject.SetActive(false);
    this.darkness.transform.localScale = new Vector3(10f, 10f, 1f);
    this.yes.initButton(" ");
    this.no.initButton(" ");
    this.yes.transform.parent = this.gameObject.transform;
    this.yes.gameObject.transform.parent = this.gameObject.transform;
    this.yes.buttonText.transform.parent = this.gameObject.transform;
    this.yes.buttonText.container.transform.parent = this.gameObject.transform;
    this.no.transform.parent = this.gameObject.transform;
    this.no.gameObject.transform.parent = this.gameObject.transform;
    this.no.buttonText.transform.parent = this.gameObject.transform;
    this.no.buttonText.container.transform.parent = this.gameObject.transform;
    this.no.onClick = new Button.Delegate(this.hideQuestion);
    QuestionController.questionAsked = false;
  }

  public void showQuestion(
    string label,
    QuestionController.PopupType type = QuestionController.PopupType.QUESTION,
    Button.Delegate yesClick = null,
    int time = 0,
    int timeSaver = 0,
    Button.Delegate noClick = null,
    string customYesLabel = null,
    string customNoLabel = null,
    Sprite image = null)
  {
    QuestionController.questionAsked = true;
    if ((Object) this.cursorCont == (Object) null)
      this.initCursor();
    this.cursorCont.showCursor(CursorController.PixelCursor.NORMAL);
    GameObject.Find("BottomText").GetComponent<TextFieldController>().keepAlive = false;
    this.antiDoubleClick = 0.6f;
    this.timeAdded = 0;
    float num1 = 0.0f;
    if (time != 0)
    {
      this.timeAdded = time;
      label += " ^^";
      if (timeSaver > 0 && GameDataController.gd.getObjective("dialogue_ginger_intro"))
      {
        label += GameStrings.getString(GameStrings.warnings, "time_action_would_take");
        label = label + " " + (object) time + " " + GameStrings.getString(GameStrings.warnings, "time_minutes") + ".";
        if (GameDataController.gd.getObjective("dialogue_ginger_intro"))
        {
          int num2 = timeSaver;
          this.timeAdded -= num2;
          label = label + " ^" + GameStrings.getString(GameStrings.warnings, "time_help1") + string.Empty + (object) num2 + " " + GameStrings.getString(GameStrings.warnings, "time_minutes") + string.Empty;
          num1 += 0.1f;
        }
        if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive"))
        {
          int num3 = (int) ((double) timeSaver * 1.5);
          this.timeAdded -= num3;
          label = label + " ^" + GameStrings.getString(GameStrings.warnings, "time_help2") + string.Empty + (object) num3 + " " + GameStrings.getString(GameStrings.warnings, "time_minutes") + string.Empty;
          num1 += 0.1f;
        }
        if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
        {
          int num4 = (int) ((double) timeSaver * 0.5);
          this.timeAdded -= num4;
          label = label + " ^" + GameStrings.getString(GameStrings.warnings, "time_help3") + string.Empty + (object) num4 + " " + GameStrings.getString(GameStrings.warnings, "time_minutes") + string.Empty;
          num1 += 0.1f;
        }
        label = label + " ^" + GameStrings.getString(GameStrings.warnings, "time_summary") + " " + (object) this.timeAdded + " " + GameStrings.getString(GameStrings.warnings, "time_minutes") + ".";
        float num5 = num1 + 0.1f;
      }
      else
      {
        label += GameStrings.getString(GameStrings.warnings, "time_action_will_take");
        label = label + " " + (object) time + " " + GameStrings.getString(GameStrings.warnings, "time_minutes") + ".";
      }
      string str1 = GameStrings.getString(GameStrings.gui, "left_prefix");
      if (str1.Length > 0)
        str1 += " ";
      string str2 = GameStrings.getString(GameStrings.gui, "left");
      if (str2.Length > 0)
        str2 = " " + str2;
      label = label + " ^" + GameStrings.getString(GameStrings.gui, "time_now") + " " + ClockController.getClockTime() + " (" + str1 + ClockController.getTimeLeft() + str2 + ")";
      label = label + " ^" + GameStrings.getString(GameStrings.warnings, "time_proceed");
    }
    this.questionText.viewText(label, quick: true, instant: true, mwidth: 230);
    this.questionText.keepAlive = true;
    float y = this.questionText.getChars()[this.questionText.getChars().Count - 1].transform.position.y;
    switch (type)
    {
      case QuestionController.PopupType.QUESTION:
        if (customYesLabel != null)
          this.yes.initButton(customYesLabel);
        else
          this.yes.initButton(GameStrings.getString(GameStrings.gui, "yes").ToUpper());
        if (customNoLabel != null)
          this.no.initButton(customNoLabel);
        else
          this.no.initButton(GameStrings.getString(GameStrings.gui, "no").ToUpper());
        this.yes.transform.position = ScreenControler.roundToNearestFullPixel2(new Vector3(-0.55f, y - 0.1f, this.yes.transform.position.z));
        this.no.transform.position = ScreenControler.roundToNearestFullPixel2(new Vector3(0.55f, y - 0.1f, this.yes.transform.position.z));
        break;
      case QuestionController.PopupType.STATEMENT:
        if (customYesLabel != null)
          this.yes.initButton(customYesLabel);
        else
          this.yes.initButton(GameStrings.getString(GameStrings.gui, "ok").ToUpper());
        this.yes.transform.position = ScreenControler.roundToNearestFullPixel2(new Vector3(0.0f, y - 0.1f, this.yes.transform.position.z));
        this.no.transform.position = ScreenControler.roundToNearestFullPixel2(new Vector3(9999f, 9999f, this.yes.transform.position.z));
        break;
    }
    this.yes.transform.parent = this.gameObject.transform;
    this.yes.gameObject.transform.parent = this.gameObject.transform;
    this.yes.buttonText.transform.parent = this.gameObject.transform;
    this.yes.buttonText.container.transform.parent = this.gameObject.transform;
    this.no.transform.parent = this.gameObject.transform;
    this.no.gameObject.transform.parent = this.gameObject.transform;
    this.no.buttonText.transform.parent = this.gameObject.transform;
    this.yes.buttonText.container.transform.parent = this.gameObject.transform;
    QuestionController.qc.gameObject.SetActive(true);
    PlayerController.pc.setBusy(true);
    this.yes.onClick = new Button.Delegate(this.timeAndHide);
    this.onYesClick = yesClick;
    if (noClick != null)
    {
      this.no.onClick = new Button.Delegate(this.customNo);
      this.onNoClick = noClick;
    }
    else
      this.no.onClick = new Button.Delegate(this.hideQuestion);
    this.yes.workIfBusy = false;
    this.no.workIfBusy = false;
    if ((Object) image != (Object) null)
    {
      this.gameObject.GetComponent<SpriteRenderer>().sprite = image;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    else
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
  }

  public void timeAndHide()
  {
    QuestionController.qc.hideQuestion();
    GameDataController.gd.autoSave();
    if (!ClockController.advanceTime(this.timeAdded))
    {
      this.yes.onClick = (Button.Delegate) null;
      this.onYesClick = (Button.Delegate) null;
    }
    else
    {
      if (this.onYesClick == null)
        return;
      this.onYesClick();
    }
  }

  public void customNo()
  {
    QuestionController.qc.hideQuestion();
    this.onNoClick();
  }

  private void initCursor() => this.cursorCont = GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>();

  public void hideQuestion()
  {
    QuestionController.questionAsked = false;
    QuestionController.qc.questionText.dissmiss();
    QuestionController.qc.no.buttonText.dissmiss();
    QuestionController.qc.yes.buttonText.dissmiss();
    QuestionController.qc.gameObject.SetActive(false);
    PlayerController.pc.clickedSomething = true;
    PlayerController.pc.setBusy(false);
    this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    if ((Object) this.cursorCont == (Object) null)
      this.initCursor();
    this.cursorCont.showCursor(CursorController.PixelCursor.NORMAL);
    MonoBehaviour.print((object) "QUESTION HIDDEN");
  }

  private void Update()
  {
    if (!QuestionController.questionAsked)
      return;
    if ((double) this.antiDoubleClick > 0.0)
    {
      this.antiDoubleClick -= Time.deltaTime;
    }
    else
    {
      this.yes.workIfBusy = true;
      this.no.workIfBusy = true;
    }
    if (!Input.GetKeyDown(KeyCode.Escape))
      return;
    this.no.onClick();
  }

  public enum PopupType
  {
    QUESTION,
    STATEMENT,
  }
}
