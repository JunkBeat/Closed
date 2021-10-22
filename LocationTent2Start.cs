// Decompiled with JetBrains decompiler
// Type: LocationTent2Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationTent2Start : MonoBehaviour
{
  public int skipit;
  public float timer;

  private void music1()
  {
    this.skipit = 1;
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_success, false, 0.0f, 0.0f);
  }

  private void music2()
  {
    this.skipit = 1;
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_sorrow, false, 0.0f, 0.0f);
  }

  private void music3() => JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_main, false, 0.0f, 0.0f);

  private void Start()
  {
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
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 1f);
    PlayerController.wc.speed = 0.0f;
    PlayerController.wc.dir = WalkController.Direction.SE;
    PlayerController.wc.currentXY = new Vector2(-51f, -28f);
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(-999f, -999f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    InventoryButtonController.ibc.gameObject.transform.position = worldPoint;
    PlayerController.wc.busy = true;
    this.Invoke("exitTent", 5f);
    this.Invoke("exitTent2", 7f);
    GameObject.Find("ContinueBtn").GetComponent<Button>().buttonEnabled = false;
  }

  private void mainMenu()
  {
    PlayerController.wc.fullStop();
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("MainMenu", WalkController.Direction.S, "action_stnd_s", tSpeed: CurtainController.MENU_CURTAIN_SPEED);
  }

  public void showButton()
  {
    Button component = GameObject.Find("ContinueBtn").GetComponent<Button>();
    component.initButton("[" + GameStrings.getString(GameStrings.gui, "skip") + "]");
    component.workIfBusy = true;
    component.buttonText.OPTIONAL_MARGIN = 6;
    component.onClick = new Button.Delegate(this.mainMenu);
    component.enabled = true;
    component.buttonEnabled = true;
  }

  private void exitTent()
  {
    PlayerController.wc.currentXY = new Vector2(51f, 28f);
    PlayerController.wc.forceAnimation("exit_tent");
  }

  private void exitTent3(string v = "")
  {
    Timeline.t.doNotUnlock = true;
    this.Invoke("exitTent4", 1f);
  }

  private void exitTent4()
  {
    string str = "david_ending_bad";
    if (GameDataController.gd.getObjective("moon_disc1_used") || GameDataController.gd.getObjective("moon_disc2_used"))
      str = "david_ending_med";
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.dialogues, str + "_1_a"),
      blockG = true
    });
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.dialogues, str + "_2_a"),
      blockG = true
    });
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.dialogues, str + "_3_a"),
      blockG = true
    });
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.dialogues, str + "_4_a"),
      blockG = true
    });
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.dialogues, str + "_5_a"),
      blockG = true,
      function = new TimelineFunction(this.showNapisy),
      actionWithText = false
    });
  }

  private void exitTent2()
  {
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.actions, "story_intro_day_1_1"),
      blockG = true
    });
    TimelineAction action = new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.actions, "story_intro_day_1_2"),
      blockG = true
    };
    action.blockG = true;
    action.function = new TimelineFunction(this.exitTent3);
    action.actionWithText = false;
    Timeline.t.doNotUnlock = true;
    Timeline.t.addAction(action);
    PlayerController.wc.forceAnimation("stand_se", makeBusy: false);
  }

  private void showNapisy(string s = "")
  {
    if (GameDataController.KART)
    {
      GameDataController.persistentData.kong_game = true;
      GameDataController.gd.PersistentSave();
    }
    GameDataController.Achievement("ENDING_1");
    if (!GameDataController.gd.getObjective("car_driven"))
      GameDataController.Achievement("S_WALKING");
    if (!GameDataController.gd.getObjective("npc1_alive") && !GameDataController.gd.getObjective("npc2_alive") && !GameDataController.gd.getObjective("npc3_alive"))
      GameDataController.Achievement("S_WOLF");
    if (GameDataController.gd.getObjective("npc1_alive") && GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjective("npc3_alive"))
      GameDataController.Achievement("S_FAMILY");
    if (GameDataController.gd.getObjective("moon_disc1_used") || GameDataController.gd.getObjective("moon_disc2_used"))
    {
      GameDataController.Achievement("ENDING_2");
      this.Invoke("music1", 3f);
      this.Invoke("music3", 49f);
    }
    else
    {
      this.Invoke("music2", 1f);
      this.Invoke("music3", 46f);
    }
    this.gameObject.GetComponent<Napisy>().showNapisyS(string.Empty);
  }

  private void Update()
  {
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
        component.buttonEnabled = false;
      }
    }
    if (!Input.GetMouseButtonDown(0) && !Input.GetKeyDown(KeyCode.Escape) || this.skipit != 1)
      return;
    this.skipit = 2;
    this.showButton();
  }
}
