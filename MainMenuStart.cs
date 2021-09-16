// Decompiled with JetBrains decompiler
// Type: MainMenuStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuStart : MonoBehaviour
{
  public string custom_disc;
  public string custom_d1;
  public string custom_d2;
  public string custom_d3;
  public string custom_d4;
  public Sprite background1_a;
  public Sprite background1_b;
  public Sprite background2_a;
  public Sprite background2_b;
  public Sprite background3_a;
  public Sprite background3_b;
  private TextFieldController counter1;
  private TextFieldController counter2;
  private TextFieldController counter3;
  public SpriteRenderer background_2_1;
  public SpriteRenderer background_2_2;
  public SpriteRenderer background_2_3;
  public SpriteRenderer background_1_3;
  public ParticleGenerator clouds;
  protected DialogueOptionController doc;
  public SpriteRenderer back1;
  public SpriteRenderer back2;
  public SpriteRenderer fore1;
  public SpriteRenderer fore2;
  public float xpos;
  public float alpha;
  public float previousAlpha = 999f;
  public Button continueBtn;
  public Button newGameBtn;
  public Button loadGameBtn;
  public Button OptionsBtn;
  public Button CreditsBtn;
  public Button QuitBtn;
  public Button fakeContinue1;
  public Button fakeContinue2;
  public Button fakeContinue3;
  public Button fakeNewGame1;
  public Button fakeNewGame2;
  public Button fakeNewGame3;
  public Button fakeLoadGame1;
  public Button fakeLoadGame2;
  public Button fakeLoadGame3;
  public Button fakeOptions1;
  public Button fakeOptions2;
  public Button fakeOptions3;
  public Button fakeCredits1;
  public Button fakeCredits2;
  public Button fakeCredits3;
  public Button fakeQuit1;
  public Button fakeQuit2;
  public Button fakeQuit3;
  public ParticleGenerator d_a_1;
  public ParticleGenerator d_a_2;
  public ParticleGenerator d_a_3;
  public ParticleGenerator d_a_4;
  public ParticleGenerator d_a_5;
  public ParticleGenerator d_b_1;
  public ParticleGenerator d_b_2;
  public ParticleGenerator d_b_3;
  public ParticleGenerator d_b_4;
  public ParticleGenerator d_b_5;
  private float blinkDelay;
  private float blinkChance = 1f;
  private bool old;

  private void makeCloudsNormal()
  {
    this.clouds.xSpread = 75;
    this.clouds.maxDelayBetweeenParticles = 800;
    this.clouds.minDelayBetweeenParticles = 6;
  }

  public void setupButton(
    Button button,
    Button fake1,
    Button fake2,
    Button fake3,
    string label,
    Button.Delegate action)
  {
    button.initButton(string.Empty + GameStrings.getString(GameStrings.gui, label) + string.Empty);
    button.workIfBusy = false;
    button.onClick = action;
    fake1.initButton(string.Empty + GameStrings.getString(GameStrings.gui, label) + string.Empty);
    fake2.initButton(string.Empty + GameStrings.getString(GameStrings.gui, label) + string.Empty);
    fake1.buttonEnabled = false;
    fake2.buttonEnabled = false;
    fake3.initButton(string.Empty + GameStrings.getString(GameStrings.gui, label) + string.Empty);
    fake3.buttonEnabled = false;
  }

  private void Start()
  {
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
    Vector2 screen1 = ScreenControler.gameToScreen(new Vector2(-999f, -999f));
    Vector3 worldPoint1 = Camera.main.ScreenToWorldPoint(new Vector3(screen1.x, screen1.y, 0.0f));
    worldPoint1.z = -3f;
    InventoryButtonController.ibc.gameObject.transform.position = worldPoint1;
    this.clouds.xSpread = 750;
    this.clouds.maxDelayBetweeenParticles = 0;
    this.clouds.minDelayBetweeenParticles = 0;
    this.Invoke("makeCloudsNormal", 0.5f);
    this.setupButton(this.continueBtn, this.fakeContinue1, this.fakeContinue2, this.fakeContinue3, "continueGame", new Button.Delegate(this.continueGame));
    if (!GameDataController.gd.checkSave(GameDataController.CONTINUE))
    {
      this.continueBtn.initButton(" ");
      this.continueBtn.onClick = (Button.Delegate) null;
      this.continueBtn.buttonEnabled = false;
      this.fakeContinue1.initButton(" ");
      this.fakeContinue2.initButton(" ");
      this.fakeContinue3.initButton(" ");
      this.fakeContinue1.enabled = false;
      this.fakeContinue2.enabled = false;
      this.fakeContinue3.enabled = false;
      this.fakeContinue1.gameObject.GetComponent<BoxCollider2D>().enabled = false;
      this.fakeContinue2.gameObject.GetComponent<BoxCollider2D>().enabled = false;
      this.fakeContinue3.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    if (GameDataController.persistentData.disc_barry && GameDataController.persistentData.disc_cody)
    {
      GameDataController.persistentData.custom_unlocked = true;
      GameDataController.gd.PersistentSave();
    }
    if (GameDataController.persistentData.custom_unlocked)
      this.setupButton(this.newGameBtn, this.fakeNewGame1, this.fakeNewGame2, this.fakeNewGame3, "custom_game_label", new Button.Delegate(this.newGameCustom));
    else
      this.setupButton(this.newGameBtn, this.fakeNewGame1, this.fakeNewGame2, this.fakeNewGame3, "newGame", new Button.Delegate(this.newGame));
    this.setupButton(this.loadGameBtn, this.fakeLoadGame1, this.fakeLoadGame2, this.fakeLoadGame3, "loadGame", new Button.Delegate(this.loadGame));
    this.setupButton(this.OptionsBtn, this.fakeOptions1, this.fakeOptions2, this.fakeOptions3, "options", new Button.Delegate(this.optionsClick));
    this.setupButton(this.CreditsBtn, this.fakeCredits1, this.fakeCredits2, this.fakeCredits3, "credits", new Button.Delegate(this.creditsClick));
    this.setupButton(this.QuitBtn, this.fakeQuit1, this.fakeQuit2, this.fakeQuit3, "quit", new Button.Delegate(this.quit));
    if ((bool) (Object) PlayerController.wc)
    {
      PlayerController.wc.currentXY.x = 1000f;
      PlayerController.wc.currentXY.y = 1000f;
      PlayerController.wc.clearTarget();
    }
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_main, minTime: 0.0f, maxTime: 1f);
    JukeboxAmbient.jb.changeAmbient((AudioClip) null, 0.0f);
    Vector2 screen2 = ScreenControler.gameToScreen(new Vector2(120f, 67f));
    Vector3 worldPoint2 = Camera.main.ScreenToWorldPoint(new Vector3(screen2.x, screen2.y, 0.0f));
    worldPoint1.z = -3f;
    GameObject.Find("Caption_Version").GetComponent<TextFieldController>().viewText(GameDataController.VERSION, quick: true, instant: true, mwidth: 200, r: 0.6078432f, g: 0.6078432f, b: 0.6078432f, ba: 0.0f);
    GameObject.Find("Caption_Version").GetComponent<TextFieldController>().keepAlive = true;
    GameObject.Find("Caption_Version").transform.position = worldPoint2;
    GameObject.Find("Location").GetComponent<LocationManager>().escButton = this.QuitBtn;
    this.back1.enabled = true;
    this.back2.enabled = true;
    this.background_1_3.enabled = true;
    this.background_2_1.enabled = false;
    this.background_2_2.enabled = false;
    this.background_2_3.enabled = false;
    this.d_a_1.started = true;
    this.d_a_2.started = true;
    this.d_a_3.started = true;
    this.d_a_4.started = true;
    this.d_a_5.started = true;
    this.d_b_1.started = false;
    this.d_b_2.started = false;
    this.d_b_3.started = false;
    this.d_b_4.started = false;
    this.d_b_5.started = false;
    if (GameDataController.persistentData.disc_barry || GameDataController.persistentData.disc_cody)
    {
      this.back1.enabled = false;
      this.back2.enabled = false;
      this.background_1_3.enabled = false;
      this.background_2_1.enabled = true;
      this.background_2_2.enabled = true;
      this.background_2_3.enabled = true;
      this.d_a_1.started = false;
      this.d_a_2.started = false;
      this.d_a_3.started = false;
      this.d_a_4.started = false;
      this.d_a_5.started = false;
      this.d_b_1.started = true;
      this.d_b_2.started = true;
      this.d_b_3.started = true;
      this.d_b_4.started = true;
      this.d_b_5.started = true;
    }
    Timeline.t.doNotUnlock = false;
  }

  private void creditsClick()
  {
    PlayerController.wc.fullStop(true);
    CurtainController.cc.fadeOut("Credits", tSpeed: CurtainController.MENU_CURTAIN_SPEED);
    AudioListener.pause = true;
  }

  private void optionsClick()
  {
    PlayerController.wc.fullStop(true);
    if ((double) PlayerController.wc.speed != 0.0)
      PlayerController.wc.forceAnimation("stand_", useCurrentDir: true);
    PlayerController.pc.spawnName = "InfoExit";
    GameDataController.gd.previousLocation = SceneManager.GetActiveScene().name;
    GameDataController.gd.previousX = (int) PlayerController.wc.currentXY.x;
    GameDataController.gd.previousY = (int) PlayerController.wc.currentXY.y;
    CurtainController.cc.fadeOut("PauseMenu", tSpeed: CurtainController.MENU_CURTAIN_SPEED);
    AudioListener.pause = true;
  }

  private void loadGame()
  {
    GameDataController.wantSave = false;
    PlayerController.wc.fullStop();
    GameDataController.gd.previousLocation = SceneManager.GetActiveScene().name;
    CurtainController.cc.fadeOut("SaveMenu", WalkController.Direction.S, "action_stnd_s", tSpeed: CurtainController.MENU_CURTAIN_SPEED);
  }

  private void continueGame() => GameDataController.gd.politeLoad(GameDataController.CONTINUE);

  private void quit() => QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "quit_game"), yesClick: new Button.Delegate(this.quit2), noClick: new Button.Delegate(this.noQuit));

  private void noQuit() => GameObject.Find("Location").GetComponent<LocationManager>().escButton = GameObject.Find("QuitBtn").GetComponent<Button>();

  private void quit2() => Application.Quit();

  private void newGame()
  {
    if (GameDataController.gd.checkSave(GameDataController.CONTINUE))
    {
      string key = "new_game_warning";
      if (GameDataController.persistentData.disc_barry || GameDataController.persistentData.disc_cody)
        key = "new_game_warning2";
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.gui, key), yesClick: new Button.Delegate(this.newGame2));
    }
    else
      this.newGame2();
  }

  private void newGameCustom() => this.newGameCustom1(string.Empty);

  private void newGameCustom1(string param = "")
  {
    if (param != string.Empty)
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click1);
    else
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.comp_beeps2);
    DialogueController.dc.hide();
    GameObject.Find("BottomText").GetComponent<TextFieldController>().dissmiss();
    DialogueController.dc.callback = (DialogueController.Callback) null;
    this.takeDoc(0);
    DialogueController.dc.reset();
    int i1 = 0;
    GameObject.Find("Caption_Static").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "custom_game_params") + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_disc_desc") + " < ^" + GameStrings.getString(GameStrings.gui, "custom_game_d1") + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d2") + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d3") + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d4"), quick: true, instant: true, mwidth: 230, r: 0.015f, g: 0.464f, b: 0.79f, br: 0.07f, bg: 0.14f, bb: 0.23f, constantRefresh: true, mute: true);
    GameObject.Find("Caption_Static").GetComponent<TextFieldController>().keepAlive = true;
    this.takeDoc(i1);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_disc_barry");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/custom/disc1");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.newGameCustom2);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = "barry";
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int i2 = i1 + 1;
    this.takeDoc(i2);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_disc_cody");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/custom/disc2");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.newGameCustom2);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = "cody";
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int i3 = i2 + 1;
    this.takeDoc(i3);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_disc_both");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/custom/both");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.newGameCustom2);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = "both";
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int i4 = i3 + 1;
    this.takeDoc(i4);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_disc_none");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/custom/nodisc");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.newGameCustom2);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = "none";
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int i5 = i4 + 1;
    this.takeDoc(i5);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_back");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective(string.Empty);
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalk);
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int num = i5 + 1;
    this.takeDoc(0);
    if (!(this.doc.caption != string.Empty))
      return;
    DialogueController.dc.talking = true;
  }

  private void newGameCustom2(string param = "")
  {
    if (param != string.Empty)
    {
      this.custom_disc = param;
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click1);
    }
    else
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.comp_beeps2);
    DialogueController.dc.hide();
    GameObject.Find("BottomText").GetComponent<TextFieldController>().dissmiss();
    DialogueController.dc.callback = (DialogueController.Callback) null;
    this.takeDoc(0);
    DialogueController.dc.reset();
    int i1 = 0;
    GameObject.Find("Caption_Static").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "custom_game_params") + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_disc_desc") + " " + GameStrings.getString(GameStrings.gui, "custom_game_disc_" + this.custom_disc) + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d1") + " < ^" + GameStrings.getString(GameStrings.gui, "custom_game_d2") + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d3") + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d4"), quick: true, instant: true, mwidth: 230, r: 0.015f, g: 0.464f, b: 0.79f, br: 0.07f, bg: 0.14f, bb: 0.23f, constantRefresh: true, mute: true);
    GameObject.Find("Caption_Static").GetComponent<TextFieldController>().keepAlive = true;
    this.takeDoc(i1);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_d1") + " " + GameStrings.getString(GameStrings.gui, "custom_game_locust");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/custom/locust");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.newGameCustom3);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = "locust";
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int i2 = i1 + 1;
    this.takeDoc(i2);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_d1") + " " + GameStrings.getString(GameStrings.gui, "custom_game_gas");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/custom/gas");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.newGameCustom3);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = "gas";
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int i3 = i2 + 1;
    this.takeDoc(i3);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_d1") + " " + GameStrings.getString(GameStrings.gui, "custom_game_spiders");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/custom/spiders");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.newGameCustom3);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = "spiders";
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int i4 = i3 + 1;
    this.takeDoc(i4);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_back");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective(string.Empty);
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.newGameCustom1);
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int num = i4 + 1;
    this.takeDoc(0);
    if (!(this.doc.caption != string.Empty))
      return;
    DialogueController.dc.talking = true;
  }

  private void newGameCustom3(string param = "")
  {
    if (param != string.Empty)
    {
      this.custom_d1 = param;
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click1);
    }
    else
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.comp_beeps2);
    DialogueController.dc.hide();
    GameObject.Find("BottomText").GetComponent<TextFieldController>().dissmiss();
    DialogueController.dc.callback = (DialogueController.Callback) null;
    this.takeDoc(0);
    DialogueController.dc.reset();
    int i1 = 0;
    string str = "1";
    if (param != "none")
      str = "2";
    GameObject.Find("Caption_Static").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "custom_game_params") + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_disc_desc") + " " + GameStrings.getString(GameStrings.gui, "custom_game_disc_" + this.custom_disc) + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d1") + " " + GameStrings.getString(GameStrings.gui, "custom_game_" + this.custom_d1) + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d2") + " < ^" + GameStrings.getString(GameStrings.gui, "custom_game_d3") + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d4"), quick: true, instant: true, mwidth: 230, r: 0.015f, g: 0.464f, b: 0.79f, br: 0.07f, bg: 0.14f, bb: 0.23f, constantRefresh: true, mute: true);
    GameObject.Find("Caption_Static").GetComponent<TextFieldController>().keepAlive = true;
    this.takeDoc(i1);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_d2") + " " + GameStrings.getString(GameStrings.gui, "custom_game_hot");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/custom/heat");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.newGameCustom4);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = "hot";
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int i2 = i1 + 1;
    this.takeDoc(i2);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_d2") + " " + GameStrings.getString(GameStrings.gui, "custom_game_cold");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/custom/cold");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.newGameCustom4);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = "cold";
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int i3 = i2 + 1;
    this.takeDoc(i3);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_back");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective(string.Empty);
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.newGameCustom2);
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int num = i3 + 1;
    this.takeDoc(0);
    if (!(this.doc.caption != string.Empty))
      return;
    DialogueController.dc.talking = true;
  }

  private void newGameCustom4(string param = "")
  {
    if (param != string.Empty)
    {
      this.custom_d2 = param;
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click1);
    }
    else
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.comp_beeps2);
    DialogueController.dc.hide();
    GameObject.Find("BottomText").GetComponent<TextFieldController>().dissmiss();
    DialogueController.dc.callback = (DialogueController.Callback) null;
    this.takeDoc(0);
    DialogueController.dc.reset();
    int i1 = 0;
    GameObject.Find("Caption_Static").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "custom_game_params") + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_disc_desc") + " " + GameStrings.getString(GameStrings.gui, "custom_game_disc_" + this.custom_disc) + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d1") + " " + GameStrings.getString(GameStrings.gui, "custom_game_" + this.custom_d1) + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d2") + " " + GameStrings.getString(GameStrings.gui, "custom_game_" + this.custom_d2) + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d3") + " < ^" + GameStrings.getString(GameStrings.gui, "custom_game_d4"), quick: true, instant: true, mwidth: 230, r: 0.015f, g: 0.464f, b: 0.79f, br: 0.07f, bg: 0.14f, bb: 0.23f, constantRefresh: true, mute: true);
    GameObject.Find("Caption_Static").GetComponent<TextFieldController>().keepAlive = true;
    this.takeDoc(i1);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_d3") + " " + GameStrings.getString(GameStrings.gui, "custom_game_bandits");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/custom/razor");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.newGameCustom5);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = "bandits";
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int i2 = i1 + 1;
    this.takeDoc(i2);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_d3") + " " + GameStrings.getString(GameStrings.gui, "custom_game_storm");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/custom/storm");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.newGameCustom5);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = "storm";
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int i3 = i2 + 1;
    this.takeDoc(i3);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_back");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective(string.Empty);
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.newGameCustom3);
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int num = i3 + 1;
    this.takeDoc(0);
    if (!(this.doc.caption != string.Empty))
      return;
    DialogueController.dc.talking = true;
  }

  private void newGameCustom5(string param = "")
  {
    if (param != string.Empty)
    {
      this.custom_d3 = param;
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click1);
    }
    else
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.comp_beeps2);
    DialogueController.dc.hide();
    GameObject.Find("BottomText").GetComponent<TextFieldController>().dissmiss();
    DialogueController.dc.callback = (DialogueController.Callback) null;
    this.takeDoc(0);
    DialogueController.dc.reset();
    int i1 = 0;
    GameObject.Find("Caption_Static").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "custom_game_params") + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_disc_desc") + " " + GameStrings.getString(GameStrings.gui, "custom_game_disc_" + this.custom_disc) + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d1") + " " + GameStrings.getString(GameStrings.gui, "custom_game_" + this.custom_d1) + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d2") + " " + GameStrings.getString(GameStrings.gui, "custom_game_" + this.custom_d2) + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d3") + " " + GameStrings.getString(GameStrings.gui, "custom_game_" + this.custom_d3) + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d4") + " <", quick: true, instant: true, mwidth: 230, r: 0.015f, g: 0.464f, b: 0.79f, br: 0.07f, bg: 0.14f, bb: 0.23f, constantRefresh: true, mute: true);
    GameObject.Find("Caption_Static").GetComponent<TextFieldController>().keepAlive = true;
    this.takeDoc(i1);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_d4") + " " + GameStrings.getString(GameStrings.gui, "custom_game_air");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/custom/air");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.newGameCustom6);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = "air";
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int i2 = i1 + 1;
    this.takeDoc(i2);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_d4") + " " + GameStrings.getString(GameStrings.gui, "custom_game_fuel");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/custom/fuel");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.newGameCustom6);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = "fuel";
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int i3 = i2 + 1;
    this.takeDoc(i3);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_back");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective(string.Empty);
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.newGameCustom4);
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int num = i3 + 1;
    this.takeDoc(0);
    if (!(this.doc.caption != string.Empty))
      return;
    DialogueController.dc.talking = true;
  }

  private void newGameCustom6(string param = "")
  {
    if (param != string.Empty)
    {
      this.custom_d4 = param;
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click1);
    }
    else
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.comp_beeps2);
    DialogueController.dc.hide();
    GameObject.Find("BottomText").GetComponent<TextFieldController>().dissmiss();
    DialogueController.dc.callback = (DialogueController.Callback) null;
    this.takeDoc(0);
    DialogueController.dc.reset();
    int i1 = 0;
    GameObject.Find("Caption_Static").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "custom_game_params") + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_disc_desc") + " " + GameStrings.getString(GameStrings.gui, "custom_game_disc_" + this.custom_disc) + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d1") + " " + GameStrings.getString(GameStrings.gui, "custom_game_" + this.custom_d1) + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d2") + " " + GameStrings.getString(GameStrings.gui, "custom_game_" + this.custom_d2) + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d3") + " " + GameStrings.getString(GameStrings.gui, "custom_game_" + this.custom_d3) + " ^" + GameStrings.getString(GameStrings.gui, "custom_game_d4") + " " + GameStrings.getString(GameStrings.gui, "custom_game_" + this.custom_d4), quick: true, instant: true, mwidth: 230, r: 0.015f, g: 0.464f, b: 0.79f, br: 0.07f, bg: 0.14f, bb: 0.23f, constantRefresh: true, mute: true);
    GameObject.Find("Caption_Static").GetComponent<TextFieldController>().keepAlive = true;
    this.takeDoc(i1);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_start");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/yes");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.pickDays);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = string.Empty;
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int i2 = i1 + 1;
    this.takeDoc(i2);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "custom_game_back");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective(string.Empty);
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.newGameCustom5);
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int num = i2 + 1;
    this.takeDoc(0);
    if (!(this.doc.caption != string.Empty))
      return;
    DialogueController.dc.talking = true;
  }

  public void takeDoc(int i) => this.doc = DialogueController.dc.dialogueOptions[i].GetComponent<DialogueOptionController>();

  public void pickDays(string lang)
  {
    this.endTalk(string.Empty);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.power_up_big);
    GameDataController.gd.newGame();
    if (this.custom_d1 == "locust")
      GameDataController.gd.setObjectiveDetail("day_1_threat", 0);
    if (this.custom_d1 == "gas")
      GameDataController.gd.setObjectiveDetail("day_1_threat", 1);
    if (this.custom_d1 == "spiders")
      GameDataController.gd.setObjectiveDetail("day_1_threat", 2);
    if (this.custom_d2 == "hot")
      GameDataController.gd.setObjectiveDetail("day_2_threat", 0);
    if (this.custom_d2 == "cold")
      GameDataController.gd.setObjectiveDetail("day_2_threat", 1);
    if (this.custom_d3 == "bandits")
      GameDataController.gd.setObjectiveDetail("day_3_threat", 0);
    if (this.custom_d3 == "storm")
      GameDataController.gd.setObjectiveDetail("day_3_threat", 1);
    if (this.custom_d4 == "air")
      GameDataController.gd.setObjectiveDetail("day_4_threat", 0);
    if (this.custom_d4 == "fuel")
      GameDataController.gd.setObjectiveDetail("day_4_threat", 1);
    GameDataController.gd.setObjective("previous_disc_barry", false);
    GameDataController.gd.setObjective("previous_disc_cody", false);
    if (this.custom_disc == "both")
    {
      GameDataController.gd.setObjective("previous_disc_barry", true);
      GameDataController.gd.setObjective("previous_disc_cody", true);
    }
    if (this.custom_disc == "cody")
      GameDataController.gd.setObjective("previous_disc_cody", true);
    if (this.custom_disc == "barry")
      GameDataController.gd.setObjective("previous_disc_barry", true);
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("LocationDreamBugs", WalkController.Direction.N);
  }

  public void endTalk(string val = "")
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2);
    DialogueController.dc.talking = false;
    DialogueController.dc.hide();
    GameObject.Find("Caption_Static").GetComponent<TextFieldController>().viewText(" ", quick: true, instant: true, mwidth: 230, r: 0.015f, g: 0.464f, b: 0.79f, br: 0.07f, bg: 0.14f, bb: 0.23f, constantRefresh: true, mute: true);
    GameObject.Find("Caption_Static").GetComponent<TextFieldController>().keepAlive = false;
    GameObject.Find("Caption_Static").GetComponent<TextFieldController>().dissmiss(true);
  }

  private void newGame2()
  {
    GameDataController.gd.newGame();
    List<int> intList1 = new List<int>();
    List<int> intList2 = new List<int>();
    List<int> intList3 = new List<int>();
    List<int> intList4 = new List<int>();
    List<int> intList5 = new List<int>();
    List<int> intList6 = new List<int>();
    List<int> intList7 = new List<int>();
    List<int> intList8 = new List<int>();
    if (GameDataController.persistentData.chapter1_locust)
      intList2.Add(0);
    else
      intList1.Add(0);
    if (GameDataController.persistentData.chapter1_gas)
      intList2.Add(1);
    else
      intList1.Add(1);
    if (GameDataController.persistentData.chapter1_spiders)
      intList2.Add(2);
    else
      intList1.Add(2);
    if (GameDataController.persistentData.chapter2_hot)
      intList4.Add(0);
    else
      intList3.Add(0);
    if (GameDataController.persistentData.chapter2_cold)
      intList4.Add(1);
    else
      intList3.Add(1);
    if (GameDataController.persistentData.chapter3_bandits)
      intList6.Add(0);
    else
      intList5.Add(0);
    if (GameDataController.persistentData.chapter3_thunderstorm)
      intList6.Add(1);
    else
      intList5.Add(1);
    if (GameDataController.persistentData.chapter4_air)
      intList8.Add(0);
    else
      intList7.Add(0);
    if (GameDataController.persistentData.chapter4_fuel)
      intList8.Add(1);
    else
      intList7.Add(1);
    int detail1 = intList1.Count <= 0 ? intList2[Random.Range(0, intList2.Count)] : intList1[Random.Range(0, intList1.Count)];
    int detail2 = intList3.Count <= 0 ? intList4[Random.Range(0, intList4.Count)] : intList3[Random.Range(0, intList3.Count)];
    int detail3 = intList5.Count <= 0 ? intList6[Random.Range(0, intList6.Count)] : intList5[Random.Range(0, intList5.Count)];
    int detail4 = intList7.Count <= 0 ? intList8[Random.Range(0, intList8.Count)] : intList7[Random.Range(0, intList7.Count)];
    Debug.LogWarning((object) "===== PERSISTENT ===================");
    Debug.LogWarning((object) ("CH1_0: " + (object) GameDataController.persistentData.chapter1_locust));
    Debug.LogWarning((object) ("CH1_1: " + (object) GameDataController.persistentData.chapter1_gas));
    Debug.LogWarning((object) ("CH1_2: " + (object) GameDataController.persistentData.chapter1_spiders));
    Debug.LogWarning((object) ("CH2_0: " + (object) GameDataController.persistentData.chapter2_hot));
    Debug.LogWarning((object) ("CH2_1: " + (object) GameDataController.persistentData.chapter2_cold));
    Debug.LogWarning((object) ("CH3_0: " + (object) GameDataController.persistentData.chapter3_bandits));
    Debug.LogWarning((object) ("CH3_1: " + (object) GameDataController.persistentData.chapter3_thunderstorm));
    Debug.LogWarning((object) ("CH4_0: " + (object) GameDataController.persistentData.chapter4_air));
    Debug.LogWarning((object) ("CH4_1: " + (object) GameDataController.persistentData.chapter4_fuel));
    GameDataController.gd.setObjectiveDetail("day_1_threat", detail1);
    GameDataController.gd.setObjectiveDetail("day_2_threat", detail2);
    GameDataController.gd.setObjectiveDetail("day_3_threat", detail3);
    GameDataController.gd.setObjectiveDetail("day_4_threat", detail4);
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("LocationDreamBugs", WalkController.Direction.N);
  }

  private void Update()
  {
    if (!GameDataController.persistentData.custom_unlocked && (GameDataController.persistentData.disc_barry || GameDataController.persistentData.disc_cody))
    {
      this.blinkDelay += Time.deltaTime;
      if ((double) this.blinkDelay > 0.100000001490116)
      {
        this.blinkDelay = 0.0f;
        if ((double) Random.Range(0.0f, 1f) < (double) this.blinkChance && (double) this.blinkChance < 0.600000023841858)
        {
          this.blinkChance -= 0.01f;
          if ((double) this.blinkChance < 0.300000011920929)
            this.blinkChance = 0.3f;
          if (!this.old)
          {
            this.old = true;
            this.setupButton(this.newGameBtn, this.fakeNewGame1, this.fakeNewGame2, this.fakeNewGame3, "newGamePlus", new Button.Delegate(this.newGame));
            if ((double) this.blinkChance == 0.300000011920929)
              this.blinkChance = -100f;
          }
          else if (this.old)
          {
            this.old = false;
            this.setupButton(this.newGameBtn, this.fakeNewGame1, this.fakeNewGame2, this.fakeNewGame3, "newGame", new Button.Delegate(this.newGame));
          }
        }
        else if ((double) this.blinkChance >= 0.600000023841858)
          this.blinkChance -= 0.03f;
      }
    }
    if ((bool) (Object) PlayerController.wc)
    {
      PlayerController.wc.currentXY.x = 1000f;
      PlayerController.wc.currentXY.y = 1000f;
      PlayerController.wc.clearTarget();
    }
    this.xpos = Input.mousePosition.x / (float) Screen.width;
    this.xpos *= 5f;
    this.xpos -= 2f;
    if ((double) this.xpos > 1.0)
      this.xpos = 1f;
    if ((double) this.xpos < 0.0)
      this.xpos = 0.0f;
    this.alpha -= (float) (((double) this.alpha - (double) this.xpos) / 1.0 * (double) Time.deltaTime * 3.0);
    if ((double) Mathf.Abs(this.alpha - this.xpos) < 1.0 / 1000.0)
      this.alpha = this.xpos;
    this.background_2_2.color = new Color(1f, 1f, 1f, this.alpha);
    this.back2.color = new Color(1f, 1f, 1f, this.alpha);
    this.fore1.color = new Color(1f, 1f, 1f, this.alpha);
    this.fore2.color = new Color(1f, 1f, 1f, 1f - this.alpha);
    if (!(bool) (Object) this.newGameBtn)
      return;
    this.previousAlpha = this.alpha;
    this.continueBtn.buttonText.setAlpha(this.alpha);
    this.newGameBtn.buttonText.setAlpha(this.alpha);
    this.loadGameBtn.buttonText.setAlpha(this.alpha);
    this.OptionsBtn.buttonText.setAlpha(this.alpha);
    this.CreditsBtn.buttonText.setAlpha(this.alpha);
    this.QuitBtn.buttonText.setAlpha(this.alpha);
    float a = (float) (0.200000002980232 - (double) this.alpha / 4.0);
    if ((double) a < 0.0)
      a = 0.0f;
    if ((double) a > 1.0)
      a = 1f;
    this.fakeContinue1.buttonText.setAlpha(a);
    this.fakeContinue2.buttonText.setAlpha(a);
    this.fakeContinue3.buttonText.setAlpha(a);
    this.fakeCredits1.buttonText.setAlpha(a);
    this.fakeCredits2.buttonText.setAlpha(a);
    this.fakeCredits3.buttonText.setAlpha(a);
    this.fakeLoadGame1.buttonText.setAlpha(a);
    this.fakeLoadGame2.buttonText.setAlpha(a);
    this.fakeLoadGame3.buttonText.setAlpha(a);
    this.fakeNewGame1.buttonText.setAlpha(a);
    this.fakeNewGame2.buttonText.setAlpha(a);
    this.fakeNewGame3.buttonText.setAlpha(a);
    this.fakeOptions1.buttonText.setAlpha(a);
    this.fakeOptions2.buttonText.setAlpha(a);
    this.fakeOptions3.buttonText.setAlpha(a);
    this.fakeQuit1.buttonText.setAlpha(a);
    this.fakeQuit2.buttonText.setAlpha(a);
    this.fakeQuit3.buttonText.setAlpha(a);
  }
}
