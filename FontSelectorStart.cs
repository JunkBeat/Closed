// Decompiled with JetBrains decompiler
// Type: FontSelectorStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FontSelectorStart : MonoBehaviour
{
  protected DialogueOptionController doc;
  private TextFieldController caption;
  private TextFieldController caption2;
  private TextFieldController bottom;
  private TextFieldController languageCaption;
  private LanguageSelectorCaption languageIcon;

  private void Start()
  {
    PlayerPrefs.SetString("lang", GameStrings.Language.PL.ToString());
    PlayerPrefs.Save();
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = -5f;
    PlayerController.wc.shadow.startAlpha = 0.0f;
    PlayerController.wc.shadow.source = 10f;
    PlayerController.ssg.setStepType("none");
    PlayerController.pc.copySettingsToNPCs();
    MonoBehaviour.print((object) "............................. LOCATION INFO  ..................................");
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(-999f, -999f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    InventoryButtonController.ibc.gameObject.transform.position = worldPoint;
    this.caption = GameObject.Find("Caption").GetComponent<TextFieldController>();
    this.caption.force_pixel_font = true;
    this.caption.viewText(GameStrings.getString(GameStrings.gui, "font_pick0"), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    this.caption.keepAlive = true;
    this.caption.transform.position = ScreenControler.roundToNearestFullPixel2(this.caption.transform.position);
    this.caption2 = GameObject.Find("Caption2").GetComponent<TextFieldController>();
    this.caption2.force_pixel_font = true;
    this.caption2.viewText(GameStrings.getString(GameStrings.gui, "font_pick3"), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    this.caption2.keepAlive = true;
    this.caption2.transform.position = ScreenControler.roundToNearestFullPixel2(this.caption.transform.position);
    this.bottom = GameObject.Find("BottomText").GetComponent<TextFieldController>();
    this.bottom.force_pixel_font = true;
    this.languageCaption = GameObject.Find("LanguageIcon").GetComponent<TextFieldController>();
    this.languageCaption.force_pixel_font = true;
    this.languageIcon = GameObject.Find("LanguageIcon").GetComponent<LanguageSelectorCaption>();
    Button component1 = GameObject.Find("PixelBtn").GetComponent<Button>();
    component1.initButton("[" + GameStrings.getString(GameStrings.gui, "font_pick1") + "]");
    component1.buttonText.force_pixel_font = true;
    component1.buttonText.force_smooth_font = false;
    component1.buttonText.updateFont();
    component1.initButton("[" + GameStrings.getString(GameStrings.gui, "font_pick1") + "]");
    component1.workIfBusy = false;
    component1.onClick = new Button.Delegate(this.selectPixel);
    component1.onHover = new Button.Delegate(this.previewPixel);
    Button component2 = GameObject.Find("SmoothBtn").GetComponent<Button>();
    component2.initButton("[" + GameStrings.getString(GameStrings.gui, "font_pick2") + "]");
    component2.buttonText.force_smooth_font = true;
    component2.buttonText.force_pixel_font = false;
    component2.buttonText.updateFont();
    component2.initButton("[" + GameStrings.getString(GameStrings.gui, "font_pick2") + "]");
    component2.workIfBusy = false;
    component2.onClick = new Button.Delegate(this.selectSmooth);
    component2.onHover = new Button.Delegate(this.previewSmooth);
    if (!(bool) (Object) PlayerController.wc)
      return;
    PlayerController.wc.currentXY.x = 1000f;
    PlayerController.wc.currentXY.y = 1000f;
    PlayerController.wc.clearTarget();
  }

  public void selectPixel()
  {
    PlayerPrefs.SetString("font", "pixel");
    PlayerPrefs.Save();
    this.pickFont();
  }

  public void previewPixel()
  {
    MonoBehaviour.print((object) "PREVIEW PIXEL FONT");
    this.caption.force_smooth_font = false;
    this.caption.force_pixel_font = true;
    this.caption.updateFont();
    this.caption.viewText(GameStrings.getString(GameStrings.gui, "font_pick0"), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    this.caption2.force_smooth_font = false;
    this.caption2.force_pixel_font = true;
    this.caption2.updateFont();
    this.caption2.viewText(GameStrings.getString(GameStrings.gui, "font_pick3"), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    this.languageCaption = GameObject.Find("LanguageIcon").GetComponent<TextFieldController>();
    this.languageCaption.force_smooth_font = false;
    this.languageCaption.force_pixel_font = true;
    this.languageCaption.updateFont();
    this.languageIcon.updateText();
    this.bottom.force_smooth_font = false;
    this.bottom.force_pixel_font = true;
    this.bottom.updateFont();
  }

  public void selectSmooth()
  {
    PlayerPrefs.SetString("font", "smooth");
    PlayerPrefs.Save();
    this.pickFont();
  }

  public void previewSmooth()
  {
    MonoBehaviour.print((object) "PREVIEW SMOOTH FONT");
    this.caption.force_smooth_font = true;
    this.caption.force_pixel_font = false;
    this.caption.updateFont();
    this.caption.viewText(GameStrings.getString(GameStrings.gui, "font_pick0"), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    this.caption2.force_smooth_font = true;
    this.caption2.force_pixel_font = false;
    this.caption2.updateFont();
    this.caption2.viewText(GameStrings.getString(GameStrings.gui, "font_pick3"), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    this.languageCaption = GameObject.Find("LanguageIcon").GetComponent<TextFieldController>();
    this.languageCaption.force_smooth_font = true;
    this.languageCaption.force_pixel_font = false;
    this.languageCaption.updateFont();
    this.languageIcon.updateText();
    this.bottom.force_smooth_font = true;
    this.bottom.force_pixel_font = false;
    this.bottom.updateFont();
  }

  public void pickFont()
  {
    PlayerPrefs.Save();
    foreach (TextFieldController textFieldController in Resources.FindObjectsOfTypeAll(typeof (TextFieldController)))
      textFieldController.updateFont();
    PlayerController.wc.fullStop();
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("MainMenu", WalkController.Direction.S, "action_stnd_s", tSpeed: CurtainController.MENU_CURTAIN_SPEED);
  }

  private void Update()
  {
  }
}
