// Decompiled with JetBrains decompiler
// Type: OptionsMenuStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuStart : MonoBehaviour
{
  private TextFieldController counter1;
  private TextFieldController counter2;
  private TextFieldController counter3;
  private TextFieldController counter4;
  private List<AudioClip> exampleSound;
  private AudioClip exampleMusic;
  public AudioSource aS;
  protected DialogueOptionController doc;

  private void Start()
  {
    Timeline.t.doNotUnlock = false;
    this.exampleSound = new List<AudioClip>();
    this.exampleSound.Add(ItemsManager.im.getItem("key1").sound);
    this.exampleSound.Add(ItemsManager.im.getItem("pipe").sound);
    this.exampleSound.Add(ItemsManager.im.getItem("sonic").sound);
    this.exampleSound.Add(ItemsManager.im.getItem("bug").sound);
    this.exampleSound.Add(ItemsManager.im.getItem("pest_note").sound);
    this.exampleSound.Add(ItemsManager.im.getItem("pest1").sound);
    this.exampleSound.Add(ItemsManager.im.getItem("crowbar").sound);
    this.exampleSound.Add(ItemsManager.im.getItem("hammer").sound);
    this.exampleSound.Add(ItemsManager.im.getItem("window_net1").sound);
    this.exampleSound.Add(ItemsManager.im.getItem("canister_empty").sound);
    this.exampleSound.Add(ItemsManager.im.getItem("board1").sound);
    this.exampleSound.Add(ItemsManager.im.getItem("chem_glass").sound);
    this.exampleSound.Add(ItemsManager.im.getItem("rifle_1").sound);
    this.exampleSound.Add(ItemsManager.im.getItem("bear_trap_1").sound);
    this.exampleSound.Add(ItemsManager.im.getItem("revolver_0").sound);
    this.exampleMusic = SoundsManagerController.sm.chorus1;
    PlayerPrefs.Save();
    this.aS.ignoreListenerPause = true;
    this.aS.ignoreListenerVolume = true;
    this.aS.volume = (float) PlayerPrefs.GetInt("sound") / 100f;
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
    Button component1 = GameObject.Find("ContinueBtn").GetComponent<Button>();
    component1.initButton("[" + GameStrings.getString(GameStrings.gui, "back") + "]");
    component1.buttonText.OPTIONAL_MARGIN = 6;
    component1.workIfBusy = false;
    component1.onClick = new Button.Delegate(this.continueGame);
    if (GameDataController.gd.previousLocation != "MainMenu")
    {
      Button component2 = GameObject.Find("QuitBtn").GetComponent<Button>();
      component2.workIfBusy = false;
      component2.initButton("[" + GameStrings.getString(GameStrings.gui, "quit") + "]");
      component2.onClick = new Button.Delegate(this.quit);
      Button component3 = GameObject.Find("SaveBtn").GetComponent<Button>();
      component3.initButton("[" + GameStrings.getString(GameStrings.gui, "save") + "]");
      component3.workIfBusy = false;
      component3.onClick = new Button.Delegate(this.saveGame);
      Button component4 = GameObject.Find("LoadBtn").GetComponent<Button>();
      component4.initButton("[" + GameStrings.getString(GameStrings.gui, "loadGame") + "]");
      component4.workIfBusy = false;
      component4.onClick = new Button.Delegate(this.loadGame);
      Button component5 = GameObject.Find("MainBtn").GetComponent<Button>();
      component5.initButton("[" + GameStrings.getString(GameStrings.gui, "quitToMain") + "]");
      component5.workIfBusy = false;
      component5.onClick = new Button.Delegate(this.mainMenu);
    }
    else
    {
      Button component6 = GameObject.Find("QuitBtn").GetComponent<Button>();
      component6.workIfBusy = false;
      component6.initButton(" ");
      component6.buttonEnabled = false;
      Button component7 = GameObject.Find("SaveBtn").GetComponent<Button>();
      component7.initButton(" ");
      component7.workIfBusy = false;
      component7.buttonEnabled = false;
      Button component8 = GameObject.Find("LoadBtn").GetComponent<Button>();
      component8.initButton(" ");
      component8.workIfBusy = false;
      component8.buttonEnabled = false;
    }
    Button component9 = GameObject.Find("LanguageBtn").GetComponent<Button>();
    component9.initButton("[" + GameStrings.getString(GameStrings.gui, "language") + ": " + GameStrings.getString(GameStrings.languages, PlayerPrefs.GetString("lang")) + "]");
    component9.workIfBusy = false;
    component9.onClick = new Button.Delegate(this.pickLanguage);
    TextFieldController component10 = GameObject.Find("Caption_Speed").GetComponent<TextFieldController>();
    component10.viewText(GameStrings.getString(GameStrings.gui, "text_speed") + ":", quick: true, instant: true, mwidth: 100, ba: 0.0f);
    component10.keepAlive = true;
    component10.transform.position = ScreenControler.roundToNearestFullPixel2(component10.transform.position);
    TextFieldController component11 = GameObject.Find("Caption_Static").GetComponent<TextFieldController>();
    component11.viewText(GameStrings.getString(GameStrings.gui, "static") + ":", quick: true, instant: true, mwidth: 100, ba: 0.0f);
    component11.keepAlive = true;
    component11.transform.position = ScreenControler.roundToNearestFullPixel2(component11.transform.position);
    TextFieldController component12 = GameObject.Find("Caption_Music").GetComponent<TextFieldController>();
    component12.viewText(GameStrings.getString(GameStrings.gui, "music") + ":", quick: true, instant: true, mwidth: 100, ba: 0.0f);
    component12.keepAlive = true;
    component12.transform.position = ScreenControler.roundToNearestFullPixel2(component11.transform.position);
    TextFieldController component13 = GameObject.Find("Caption_Sound").GetComponent<TextFieldController>();
    component13.viewText(GameStrings.getString(GameStrings.gui, "sound") + ":", quick: true, instant: true, mwidth: 100, ba: 0.0f);
    component13.keepAlive = true;
    component13.transform.position = ScreenControler.roundToNearestFullPixel2(component11.transform.position);
    this.counter1 = GameObject.Find("Counter1").GetComponent<TextFieldController>();
    this.counter2 = GameObject.Find("Counter2").GetComponent<TextFieldController>();
    this.counter3 = GameObject.Find("Counter3").GetComponent<TextFieldController>();
    this.counter4 = GameObject.Find("Counter4").GetComponent<TextFieldController>();
    Button component14 = GameObject.Find("SpeedBtnDown").GetComponent<Button>();
    component14.initButton("[" + GameStrings.getString(GameStrings.gui, "down") + "]");
    component14.onClick = new Button.Delegate(this.speedDown);
    component14.workIfBusy = false;
    Button component15 = GameObject.Find("SpeedBtnUp").GetComponent<Button>();
    component15.initButton("[" + GameStrings.getString(GameStrings.gui, "up") + "]");
    component15.onClick = new Button.Delegate(this.speedUp);
    component15.workIfBusy = false;
    Button component16 = GameObject.Find("StaticBtnDown").GetComponent<Button>();
    component16.initButton("[" + GameStrings.getString(GameStrings.gui, "down") + "]");
    component16.onClick = new Button.Delegate(this.staticDown);
    component16.workIfBusy = false;
    Button component17 = GameObject.Find("StaticBtnUp").GetComponent<Button>();
    component17.initButton("[" + GameStrings.getString(GameStrings.gui, "up") + "]");
    component17.onClick = new Button.Delegate(this.staticUp);
    component17.workIfBusy = false;
    Button component18 = GameObject.Find("MusicBtnDown").GetComponent<Button>();
    component18.initButton("[" + GameStrings.getString(GameStrings.gui, "down") + "]");
    component18.onClick = new Button.Delegate(this.musicDown);
    component18.workIfBusy = false;
    Button component19 = GameObject.Find("SoundBtnUp").GetComponent<Button>();
    component19.initButton("[" + GameStrings.getString(GameStrings.gui, "up") + "]");
    component19.onClick = new Button.Delegate(this.soundsUp);
    component19.workIfBusy = false;
    Button component20 = GameObject.Find("SoundBtnDown").GetComponent<Button>();
    component20.initButton("[" + GameStrings.getString(GameStrings.gui, "down") + "]");
    component20.onClick = new Button.Delegate(this.soundsDown);
    component20.workIfBusy = false;
    Button component21 = GameObject.Find("MusicBtnUp").GetComponent<Button>();
    component21.initButton("[" + GameStrings.getString(GameStrings.gui, "up") + "]");
    component21.onClick = new Button.Delegate(this.musicUp);
    component21.workIfBusy = false;
    this.counter1.viewText(this.meter(PlayerPrefs.GetInt("sound")), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    this.counter1.keepAlive = true;
    this.counter2.viewText(this.meter(PlayerPrefs.GetInt("music")), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    this.counter2.keepAlive = true;
    this.counter3.viewText(this.meter(PlayerPrefs.GetInt("stati")), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    this.counter3.keepAlive = true;
    this.counter4.viewText(this.meter(100 - (int) ((double) ((PlayerPrefs.GetFloat("textSpeed", 0.05f) - 0.0125f) / 0.075f) * 100.0)), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    this.counter4.keepAlive = true;
    int num1 = 0;
    Button component22 = GameObject.Find("ResolutionBtn").GetComponent<Button>();
    if (PlayerPrefs.GetInt("fullscreen") == 1)
    {
      component22.initButton("[" + GameStrings.getString(GameStrings.gui, "resolution") + ": " + GameStrings.getString(GameStrings.gui, "fullscreen") + "]");
    }
    else
    {
      int num2 = PlayerPrefs.GetInt("resolution");
      for (int index = 0; index < ScreenControler.allowedResolutions.Length; ++index)
      {
        if ((double) ScreenControler.allowedResolutions[index].x == (double) num2)
          num1 = (int) ScreenControler.allowedResolutions[index].y;
      }
      component22.initButton("[" + GameStrings.getString(GameStrings.gui, "resolution") + ": " + (object) num2 + "x" + (object) num1 + "]");
    }
    component22.workIfBusy = false;
    component22.onClick = new Button.Delegate(this.pickResolution);
    if (GameDataController.persistentData.chapter1_gas || GameDataController.persistentData.chapter1_locust || GameDataController.persistentData.chapter1_spiders)
    {
      Button component23 = GameObject.Find("ResetBtn").GetComponent<Button>();
      component23.initButton("[" + GameStrings.getString(GameStrings.gui, "clear_data") + "]");
      component23.workIfBusy = false;
      component23.onClick = new Button.Delegate(this.clearData);
      component23.buttonText.OPTIONAL_MARGIN = 6;
    }
    else
    {
      Button component24 = GameObject.Find("ResetBtn").GetComponent<Button>();
      component24.initButton(" ");
      component24.workIfBusy = false;
      component24.buttonEnabled = false;
    }
    GameObject.Find("Location").GetComponent<LocationManager>().escButton = component1;
  }

  private void clearData()
  {
    string label = GameStrings.getString(GameStrings.warnings, "clear_data1");
    if (GameDataController.persistentData.disc_barry || GameDataController.persistentData.disc_cody)
      label += GameStrings.getString(GameStrings.warnings, "clear_data2");
    QuestionController.qc.showQuestion(label, yesClick: new Button.Delegate(this.yesClearData), customYesLabel: GameStrings.getString(GameStrings.gui, "clear_data_yes"), customNoLabel: GameStrings.getString(GameStrings.gui, "clear_data_no"));
  }

  private void yesClearData()
  {
    GameDataController.persistentData = new PersistentData();
    GameDataController.gd.initPersistantAchieves();
    GameDataController.gd.PersistentSave();
    Button component = GameObject.Find("ResetBtn").GetComponent<Button>();
    component.initButton(" ");
    component.workIfBusy = false;
    component.buttonEnabled = false;
  }

  private void changeResolution(string res)
  {
    if (res == "fullscreen")
      ScreenControler.setFullScreenResolution();
    else
      ScreenControler.setWindowedResolution(int.Parse(res));
    PlayerPrefs.Save();
    this.endTalk(string.Empty);
    CurtainController.cc.fadeOut(tSpeed: 1f);
    this.Start();
  }

  private void pickResolution()
  {
    DialogueController.dc.callback = (DialogueController.Callback) null;
    this.takeDoc(0);
    MonoBehaviour.print((object) "PICKING RESOLUTION");
    DialogueController.dc.reset();
    int i1 = 0;
    if (PlayerPrefs.GetInt("resolution_max") == -1)
    {
      int x1 = (int) ScreenControler.getHighestWindowResolution().x;
    }
    int x2 = (int) ScreenControler.getHighestWindowResolution().x;
    this.takeDoc(i1);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "fullscreen");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/resolutions/full");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.changeResolution);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = "fullscreen";
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int i2 = i1 + 1;
    for (int index = 0; index < ScreenControler.allowedResolutions.Length; ++index)
    {
      if ((double) ScreenControler.allowedResolutions[index].x != (double) PlayerPrefs.GetInt("resolution_max") && (double) ScreenControler.allowedResolutions[index].x <= (double) x2)
      {
        this.takeDoc(i2);
        this.doc.caption = ScreenControler.allowedResolutions[index].x.ToString() + "x" + (object) ScreenControler.allowedResolutions[index].y;
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/resolutions/" + (object) ScreenControler.allowedResolutions[index].x);
        this.doc.lines = new List<DialogueLine>();
        DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
        this.doc.setObjective(string.Empty);
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.changeResolution);
        this.doc.lines[this.doc.lines.Count - 1].actionParam = ScreenControler.allowedResolutions[index].x.ToString() + string.Empty;
        this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
        ++i2;
      }
    }
    this.takeDoc(i2);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "cancel");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective(string.Empty);
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalk);
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int num = i2 + 1;
    this.takeDoc(0);
    if (!(this.doc.caption != string.Empty))
      return;
    DialogueController.dc.talking = true;
  }

  private void quit() => QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "quit_game"), yesClick: new Button.Delegate(this.quit2));

  private void quit2() => Application.Quit();

  public void takeDoc(int i) => this.doc = DialogueController.dc.dialogueOptions[i].GetComponent<DialogueOptionController>();

  public void changeLanguage(string lang)
  {
    PlayerPrefs.SetString(nameof (lang), lang);
    PlayerPrefs.Save();
    GameStrings.readStrings(lang);
    ItemsManager.im.reloadAfterLanguageChange();
    this.endTalk(string.Empty);
    this.Start();
  }

  public void pickFont()
  {
    if (PlayerPrefs.GetString("font") == "pixel")
      PlayerPrefs.SetString("font", "smooth");
    else
      PlayerPrefs.SetString("font", "pixel");
    PlayerPrefs.Save();
    foreach (TextFieldController textFieldController in Resources.FindObjectsOfTypeAll(typeof (TextFieldController)))
      textFieldController.updateFont();
    this.Start();
  }

  private void pickLanguage()
  {
    DialogueController.dc.callback = (DialogueController.Callback) null;
    this.takeDoc(0);
    MonoBehaviour.print((object) "PICKING LANGUAGE");
    DialogueController.dc.reset();
    int num1 = 0;
    this.takeDoc(0);
    this.doc.caption = GameStrings.getString(GameStrings.languages, GameStrings.Language.EN.ToString());
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/l_eng");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalk);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = GameStrings.Language.EN.ToString();
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int i = num1 + 1;
    this.doc.caption = GameStrings.getString(GameStrings.languages, GameStrings.Language.PL.ToString());
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/l_pl");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective(string.Empty);
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.changeLanguage);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = GameStrings.Language.PL.ToString();
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    this.takeDoc(i);
    this.doc.caption = GameStrings.getString(GameStrings.languages, GameStrings.Language.DE.ToString());
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/l_de");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective(string.Empty);
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalk);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = GameStrings.Language.DE.ToString();
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    this.doc.caption = GameStrings.getString(GameStrings.gui, "cancel");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective(string.Empty);
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalk);
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int num2 = i + 1;
    this.takeDoc(0);
    if (!(this.doc.caption != string.Empty))
      return;
    DialogueController.dc.talking = true;
  }

  public void endTalk(string val = "")
  {
    DialogueController.dc.talking = false;
    DialogueController.dc.hide();
  }

  private void resetGame2()
  {
    GameDataController.gd.newGame();
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("LocationDreamBugs", WalkController.Direction.N);
  }

  private void resetGame() => QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "reset_game"), yesClick: new Button.Delegate(this.resetGame2));

  private void continueGame()
  {
    PlayerController.pc.spawnName = "previous";
    PlayerController.wc.fullStop();
    CurtainController.cc.fadeOut(GameDataController.gd.previousLocation, WalkController.Direction.S, "action_stnd_s", tSpeed: CurtainController.MENU_CURTAIN_SPEED);
  }

  private void saveGame()
  {
    GameDataController.wantSave = true;
    PlayerController.wc.fullStop();
    CurtainController.cc.fadeOut("SaveMenu", WalkController.Direction.S, "action_stnd_s", tSpeed: CurtainController.MENU_CURTAIN_SPEED);
  }

  private void loadGame()
  {
    GameDataController.wantSave = false;
    PlayerController.wc.fullStop();
    CurtainController.cc.fadeOut("SaveMenu", WalkController.Direction.S, "action_stnd_s", tSpeed: CurtainController.MENU_CURTAIN_SPEED);
  }

  private void mainMenu()
  {
    PlayerController.wc.fullStop();
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("MainMenu", WalkController.Direction.S, "action_stnd_s", tSpeed: CurtainController.MENU_CURTAIN_SPEED);
  }

  private void staticUp()
  {
    PlayerPrefs.SetInt("stati", PlayerPrefs.GetInt("stati") + 10);
    if (PlayerPrefs.GetInt("stati") > 100)
      PlayerPrefs.SetInt("stati", 100);
    PlayerPrefs.Save();
    this.counter3.viewText(this.meter(PlayerPrefs.GetInt("stati")), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    this.counter3.keepAlive = true;
    StaticControler.static_power = PlayerPrefs.GetInt("stati");
  }

  private void staticDown()
  {
    PlayerPrefs.SetInt("stati", PlayerPrefs.GetInt("stati") - 10);
    if (PlayerPrefs.GetInt("stati") < 0)
      PlayerPrefs.SetInt("stati", 0);
    PlayerPrefs.Save();
    this.counter3.viewText(this.meter(PlayerPrefs.GetInt("stati")), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    this.counter3.keepAlive = true;
    StaticControler.static_power = PlayerPrefs.GetInt("stati");
  }

  private void speedUp()
  {
    PlayerPrefs.SetFloat("textSpeed", PlayerPrefs.GetFloat("textSpeed") - 0.0075f);
    if ((double) PlayerPrefs.GetFloat("textSpeed") < 0.0125000001862645)
      PlayerPrefs.SetFloat("textSpeed", 0.0125f);
    PlayerPrefs.Save();
    int stat = 100 - (int) ((double) ((PlayerPrefs.GetFloat("textSpeed") - 0.0125f) / 0.075f) * 100.0);
    MonoBehaviour.print((object) (stat.ToString() + " " + (object) PlayerPrefs.GetFloat("textSpeed")));
    this.counter4.viewText(this.meter(stat), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    this.counter4.keepAlive = true;
  }

  private void speedDown()
  {
    PlayerPrefs.SetFloat("textSpeed", PlayerPrefs.GetFloat("textSpeed") + 0.0075f);
    if ((double) PlayerPrefs.GetFloat("textSpeed") > 0.0874999985098839)
      PlayerPrefs.SetFloat("textSpeed", 0.0875f);
    PlayerPrefs.Save();
    int stat = 100 - (int) ((double) ((PlayerPrefs.GetFloat("textSpeed") - 0.0125f) / 0.075f) * 100.0);
    MonoBehaviour.print((object) (stat.ToString() + " " + (object) PlayerPrefs.GetFloat("textSpeed")));
    this.counter4.viewText(this.meter(stat), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    this.counter4.keepAlive = true;
  }

  private void musicUp()
  {
    PlayerPrefs.SetInt("music", PlayerPrefs.GetInt("music") + 10);
    if (PlayerPrefs.GetInt("music") > 100)
      PlayerPrefs.SetInt("music", 100);
    PlayerPrefs.Save();
    this.counter2.viewText(this.meter(PlayerPrefs.GetInt("music")), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    this.counter2.keepAlive = true;
  }

  private void musicDown()
  {
    PlayerPrefs.SetInt("music", PlayerPrefs.GetInt("music") - 10);
    if (PlayerPrefs.GetInt("music") < 0)
      PlayerPrefs.SetInt("music", 0);
    PlayerPrefs.Save();
    this.counter2.viewText(this.meter(PlayerPrefs.GetInt("music")), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    this.counter2.keepAlive = true;
  }

  private void soundsUp()
  {
    PlayerPrefs.SetInt("sound", PlayerPrefs.GetInt("sound") + 10);
    if (PlayerPrefs.GetInt("sound") > 100)
      PlayerPrefs.SetInt("sound", 100);
    PlayerPrefs.Save();
    this.counter1.viewText(this.meter(PlayerPrefs.GetInt("sound")), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    this.counter1.keepAlive = true;
  }

  private void soundsDown()
  {
    PlayerPrefs.SetInt("sound", PlayerPrefs.GetInt("sound") - 10);
    if (PlayerPrefs.GetInt("sound") < 0)
      PlayerPrefs.SetInt("sound", 0);
    PlayerPrefs.Save();
    AudioListener.volume = (float) PlayerPrefs.GetInt("sound") / 100f;
    this.counter1.viewText(this.meter(PlayerPrefs.GetInt("sound")), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    this.counter1.keepAlive = true;
  }

  private void Update()
  {
  }

  private string meter(int stat)
  {
    string str = "··········";
    if (stat >= 100)
      str = "||||||||||";
    else if (stat >= 90)
      str = "|||||||||·";
    else if (stat >= 80)
      str = "||||||||··";
    else if (stat >= 70)
      str = "|||||||···";
    else if (stat >= 60)
      str = "||||||····";
    else if (stat >= 50)
      str = "|||||·····";
    else if (stat >= 40)
      str = "||||······";
    else if (stat >= 30)
      str = "|||·······";
    else if (stat >= 20)
      str = "||········";
    else if (stat >= 10)
      str = "|·········";
    else if (stat >= 0)
      str = "··········";
    return str;
  }
}
