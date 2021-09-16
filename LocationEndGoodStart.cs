// Decompiled with JetBrains decompiler
// Type: LocationEndGoodStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationEndGoodStart : MonoBehaviour
{
  public SpriteRenderer cody00;
  public SpriteRenderer cody01;
  public SpriteRenderer cody02;
  public SpriteRenderer cody03;
  public SpriteRenderer cody04;
  public SpriteRenderer cody05;
  public SpriteRenderer barry00;
  public SpriteRenderer barry01;
  public SpriteRenderer barry02;
  public SpriteRenderer barry03;
  public SpriteRenderer cate00;
  public SpriteRenderer cate01;
  public SpriteRenderer cate02;
  public SpriteRenderer cate03;
  public SpriteRenderer cate04;
  public SpriteRenderer cate05;
  public SpriteRenderer david00;
  public SpriteRenderer david01;
  public SpriteRenderer david02;
  public SpriteRenderer david03;
  public SpriteRenderer david04;
  public SpriteRenderer end;
  public TextFieldController napis1;
  public TextFieldController napis2;
  private SpriteRenderer fadeIn;
  private SpriteRenderer fadeIn2;
  private SpriteRenderer fadeOut;
  private SpriteRenderer fadeOut2;
  public float adoptionX = -0.156f;
  private float waiting;
  public int skipit;
  public float timer;
  private float totalTime;

  private void Start()
  {
    this.adoptionX = -0.156f;
    GameObject.Find("journal").GetComponent<JournalButtonController>().hide();
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0015f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 8f;
    PlayerController.wc.shadow.startAlpha = 0.25f;
    PlayerController.wc.shadow.source = 200f;
    PlayerController.ssg.setStepType("dirt");
    PlayerController.wc.shadow.scaleFactor = 0.3f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient((AudioClip) null, 1f);
    PlayerController.wc.speed = 0.0f;
    PlayerController.wc.dir = WalkController.Direction.SE;
    PlayerController.wc.currentXY = new Vector2(-51f, -28f);
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(-999f, -999f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    InventoryButtonController.ibc.gameObject.transform.position = worldPoint;
    PlayerController.wc.busy = true;
    GameDataController.Achievement("ENDING_1");
    if (GameDataController.KART)
    {
      GameDataController.persistentData.kong_game = true;
      GameDataController.gd.PersistentSave();
    }
    if (!GameDataController.gd.getObjective("car_driven"))
      GameDataController.Achievement("S_WALKING");
    if (!GameDataController.gd.getObjective("npc1_alive") && !GameDataController.gd.getObjective("npc2_alive") && !GameDataController.gd.getObjective("npc3_alive"))
      GameDataController.Achievement("S_WOLF");
    if (GameDataController.gd.getObjective("npc1_alive") && GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjective("npc3_alive"))
      GameDataController.Achievement("S_FAMILY");
    GameDataController.Achievement("ENDING_3");
    this.cumulInvoke("music", 1f);
    this.cumulInvoke("slice_david00", 2f);
    if (GameDataController.gd.getObjective("npc1_alive"))
      this.cumulInvoke("slice_cate00", 8f);
    if (GameDataController.gd.getObjective("npc2_alive"))
      this.cumulInvoke("slice_barry00", 7f);
    if (GameDataController.gd.getObjective("npc3_alive"))
      this.cumulInvoke("slice_cody00", 9f);
    if (GameDataController.gd.getObjective("npc1_alive"))
      this.cumulInvoke("slice_cate01", 4f);
    if (GameDataController.gd.getObjective("npc1_alive"))
      this.cumulInvoke("slice_cate03", 5f);
    this.cumulInvoke("slice_david01", 3f);
    if (GameDataController.gd.getObjective("npc2_alive"))
      this.cumulInvoke("slice_barry01", 2f);
    if (GameDataController.gd.getObjective("npc3_alive"))
      this.cumulInvoke("slice_cody01", 4f);
    if (GameDataController.gd.getObjective("npc3_alive"))
      this.cumulInvoke("slice_cody02", 0.5f);
    if (GameDataController.gd.getObjective("npc3_alive"))
      this.cumulInvoke("slice_cody03", 0.5f);
    if (GameDataController.gd.getObjective("npc1_alive"))
      this.cumulInvoke("slice_cate02", 3f);
    this.cumulInvoke("slice_david02", 3f);
    this.cumulInvoke("slice_david03", 0.5f);
    this.cumulInvoke("slice_david04", 0.5f);
    if (GameDataController.gd.getObjective("npc1_alive"))
      this.cumulInvoke("slice_cate04", 0.5f);
    if (GameDataController.gd.getObjective("npc1_alive"))
      this.cumulInvoke("slice_cate05", 0.5f);
    if (GameDataController.gd.getObjective("npc3_alive"))
      this.cumulInvoke("slice_cody04", 0.5f);
    if (GameDataController.gd.getObjective("npc3_alive"))
      this.cumulInvoke("slice_cody05", 0.5f);
    if (GameDataController.gd.getObjective("npc2_alive"))
      this.cumulInvoke("slice_barry02", 0.5f);
    if (GameDataController.gd.getObjective("npc2_alive"))
      this.cumulInvoke("slice_barry03", 0.5f);
    this.cumulInvoke("slice_end", 3f);
    this.cumulInvoke("napisy", 4f);
    this.Invoke("music2", 93f);
    this.napis1.viewText(GameStrings.getString(GameStrings.world_labels, "ending_1"), quick: true, instant: true, mwidth: 100, r: 0.0f, g: 0.0f, b: 0.0f, ba: 0.0f, mute: true);
    this.napis1.setTime(100f);
    this.napis1.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.napis1.gameObject.transform.position);
    this.napis1.setAlpha(0.6f);
    this.napis2.viewText(GameStrings.getString(GameStrings.world_labels, "ending_2"), quick: true, instant: true, mwidth: 100, r: 0.0f, g: 0.0f, b: 0.0f, ba: 0.0f, mute: true);
    this.napis2.setTime(100f);
    this.napis2.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.napis1.gameObject.transform.position);
    this.napis2.setAlpha(0.6f);
    GameObject.Find("ContinueBtn").GetComponent<Button>().buttonEnabled = false;
    if (GameDataController.persistentData == null)
    {
      GameDataController.persistentData = new PersistentData();
      GameDataController.gd.initPersistantAchieves();
    }
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      GameDataController.persistentData.chapter1_locust = true;
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
      GameDataController.persistentData.chapter1_gas = true;
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
      GameDataController.persistentData.chapter1_spiders = true;
    if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
      GameDataController.persistentData.chapter2_hot = true;
    if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
      GameDataController.persistentData.chapter2_cold = true;
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
      GameDataController.persistentData.chapter3_bandits = true;
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
      GameDataController.persistentData.chapter3_thunderstorm = true;
    if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 0)
      GameDataController.persistentData.chapter4_air = true;
    if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 1)
      GameDataController.persistentData.chapter4_fuel = true;
    GameDataController.persistentData.disc_barry = GameDataController.gd.getObjective("moon_disc1_used");
    GameDataController.persistentData.disc_cody = GameDataController.gd.getObjective("moon_disc2_used");
    GameDataController.gd.PersistentSave();
  }

  private void mainMenu()
  {
    PlayerController.wc.fullStop();
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("MainMenu", WalkController.Direction.S, "action_stnd_s", tSpeed: CurtainController.MENU_CURTAIN_SPEED);
  }

  private void napisy() => this.gameObject.GetComponent<Napisy>().showNapisyS(string.Empty);

  private void cumulInvoke(string methodName, float time)
  {
    this.totalTime += time;
    this.Invoke(methodName, this.totalTime);
  }

  private void fader(SpriteRenderer sr)
  {
    this.fadeOut2 = this.fadeOut;
    this.fadeIn2 = this.fadeIn;
    sr.enabled = true;
    sr.color = new Color(1f, 1f, 1f, 0.0f);
    this.fadeIn = sr;
    this.fadeOut = sr;
    this.waiting = 8f;
  }

  private void music() => JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_2a);

  private void music2() => JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_main);

  private void slice_david00()
  {
    this.fader(this.david00);
    if (this.skipit == 0)
      this.skipit = 1;
    PlayerController.wc.busy = false;
  }

  private void slice_david01() => this.fader(this.david01);

  private void slice_david02() => this.fader(this.david02);

  private void slice_david03() => this.fader(this.david03);

  private void slice_david04() => this.fader(this.david04);

  private void slice_cate00() => this.fader(this.cate00);

  private void slice_cate01() => this.fader(this.cate01);

  private void slice_cate02() => this.fader(this.cate02);

  private void slice_cate03() => this.fader(this.cate03);

  private void slice_cate04() => this.fader(this.cate04);

  private void slice_cate05() => this.fader(this.cate05);

  private void slice_barry00() => this.fader(this.barry00);

  private void slice_barry01() => this.fader(this.barry01);

  private void slice_barry02() => this.fader(this.barry02);

  private void slice_barry03() => this.fader(this.barry03);

  private void slice_cody00() => this.fader(this.cody00);

  private void slice_cody01() => this.fader(this.cody01);

  private void slice_cody02() => this.fader(this.cody02);

  private void slice_cody03() => this.fader(this.cody03);

  private void slice_cody04() => this.fader(this.cody04);

  private void slice_cody05() => this.fader(this.cody05);

  private void slice_end() => this.fader(this.end);

  private void Update()
  {
    if (this.barry00.enabled && (double) this.adoptionX < 0.0)
    {
      this.adoptionX += 0.02f * Time.deltaTime;
      this.barry00.transform.position = new Vector3(this.adoptionX, this.barry00.transform.position.y, this.barry00.transform.position.z);
      this.barry00.transform.position = ScreenControler.roundToNearestFullPixel2(this.barry00.transform.position);
      this.napis2.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(new Vector3(this.adoptionX, this.napis1.gameObject.transform.position.y, this.napis1.gameObject.transform.position.z));
    }
    if ((Object) this.fadeIn != (Object) null)
    {
      this.fadeIn.color = new Color(1f, 1f, 1f, this.fadeIn.color.a + 2f * Time.deltaTime);
      if ((double) this.fadeIn.color.a >= 1.0)
        this.fadeIn = (SpriteRenderer) null;
    }
    if ((Object) this.fadeIn2 != (Object) null)
    {
      this.fadeIn2.color = new Color(1f, 1f, 1f, this.fadeIn2.color.a + 2f * Time.deltaTime);
      if ((double) this.fadeIn2.color.a >= 1.0)
        this.fadeIn2 = (SpriteRenderer) null;
    }
    if (this.skipit == 2)
    {
      this.timer += Time.deltaTime;
      if ((double) this.timer > 3.0)
      {
        this.timer = 0.0f;
        this.skipit = 1;
        Button component = GameObject.Find("ContinueBtn").GetComponent<Button>();
        component.initButton(" ");
        component.workIfBusy = false;
        component.onClick = (Button.Delegate) null;
        component.enabled = false;
        component.buttonEnabled = false;
      }
    }
    if (!Input.GetMouseButtonDown(0) && !Input.GetKeyDown(KeyCode.Escape) || this.skipit != 1)
      return;
    this.skipit = 2;
    this.showButton();
  }

  public void showButton()
  {
    Button component = GameObject.Find("ContinueBtn").GetComponent<Button>();
    component.initButton("[" + GameStrings.getString(GameStrings.gui, "skip") + "]");
    component.workIfBusy = true;
    component.onClick = new Button.Delegate(this.mainMenu);
    component.buttonText.OPTIONAL_MARGIN = 6;
    component.enabled = true;
    component.buttonEnabled = true;
  }
}
