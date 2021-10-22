// Decompiled with JetBrains decompiler
// Type: DreamWindow
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class DreamWindow : ObjectActionController
{
  public Sprite window;
  public GameObject[] pajaki;
  public lightingblast light;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "bug_death";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "dream_window";
    this.range = 5f;
    this.teleport = false;
  }

  public override void whatOnClick()
  {
    if (GameDataController.gd.getCurrentDay() == 1)
    {
      this.characterAnimationName = "bug_death";
      this.animationFlip = true;
    }
    else if (GameDataController.gd.getCurrentDay() == 2)
    {
      this.animationFlip = true;
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
        this.characterAnimationName = "heat_death";
      else
        this.characterAnimationName = "ice_death";
    }
    else if (GameDataController.gd.getCurrentDay() == 3)
    {
      this.animationFlip = true;
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
        this.characterAnimationName = "action_stnd_ne_busy";
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") != 1)
        return;
      this.characterAnimationName = "action_stnd_ne_busy";
    }
    else
    {
      if (GameDataController.gd.getCurrentDay() != 4)
        return;
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
      PlayerController.wc.GetComponent<Animator>().speed = 1.75f;
    else if (GameDataController.gd.getCurrentDay() < 4)
      PlayerController.wc.GetComponent<Animator>().speed = 1f;
    if (GameDataController.gd.getCurrentDay() == 1)
    {
      if (!GameDataController.gd.getObjective("dream_day_1_window_broken"))
        GameDataController.gd.setObjective("dream_day_1_window_broken", true);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.break_window);
      PlayerController.pc.GetComponent<SpriteRenderer>().flipX = false;
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.flies);
        this.Invoke("showBugs", 1.4f);
        GameObject[] gameObjectsWithTag = GameObject.FindGameObjectsWithTag("insect");
        for (int i = 0; i < gameObjectsWithTag.Length; ++i)
          gameObjectsWithTag[i].GetComponent<BugFly>().startFly(i);
      }
      else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.gas);
        GameObject.Find("Gas").GetComponent<ParticleGenerator>().started = true;
        this.Invoke("gasAfterWhile", 0.75f);
      }
      else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
      {
        for (int index = 0; index < this.pajaki.Length; ++index)
          this.pajaki[index].GetComponent<SpiderFall>().startFall();
      }
      this.updateAll();
    }
    else if (GameDataController.gd.getCurrentDay() == 2)
    {
      if (!GameDataController.gd.getObjective("dream_day_2_window_broken"))
        GameDataController.gd.setObjective("dream_day_2_window_broken", true);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.break_window);
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.blizzard);
        Vector2 newTarget = new Vector2(96f, 25f);
        PlayerController.wc.setSimpleTarget(newTarget);
        GameObject.Find("Location").transform.Find("cold").GetComponent<SpriteRenderer>().enabled = true;
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("snow"))
          gameObject.GetComponent<ParticleGenerator>().started = true;
        this.Invoke("nextScene2", 8f);
      }
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
      {
        Vector2 newTarget = new Vector2(76f, 25f);
        PlayerController.wc.setSimpleTarget(newTarget);
        GameObject.Find("Heat1").GetComponent<ParticleGenerator>().started = true;
        GameObject.Find("Heat2").GetComponent<ParticleGenerator>().started = true;
        GameObject.Find("Heat3").GetComponent<ParticleGenerator>().started = true;
        GameObject.Find("Location").transform.Find("hot").GetComponent<SpriteRenderer>().enabled = true;
        this.Invoke("makeSmoke", 3f);
        this.Invoke("makeSmoke2", 5f);
        this.Invoke("makeSmoke3", 6f);
        this.Invoke("makeSmoke4", 7f);
        this.Invoke("nextScene2", 10f);
      }
      this.updateAll();
    }
    else if (GameDataController.gd.getCurrentDay() == 3)
    {
      if (!GameDataController.gd.getObjective("dream_day_3_window_broken"))
        GameDataController.gd.setObjective("dream_day_3_window_broken", true);
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
      {
        this.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.motor_incoming);
        this.Invoke("bangbangyouredead", 2f);
      }
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") != 1)
        return;
      this.Invoke("thunderstorm", 1f);
    }
    else
    {
      if (GameDataController.gd.getCurrentDay() != 4)
        return;
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "dream4_window"));
    }
  }

  private void thunderstorm()
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.break_window);
    GameObject.Find("RainEmmiter0").GetComponent<ParticleGenerator>().started = true;
    GameObject.Find("RainEmmiter1").GetComponent<ParticleGenerator>().started = true;
    GameObject.Find("RainEmmiter2").GetComponent<ParticleGenerator>().started = true;
    GameObject.Find("RainEmmiter3").GetComponent<ParticleGenerator>().started = true;
    this.gameObject.GetComponent<Animator>().enabled = true;
    this.gameObject.GetComponent<Animator>().Play("window_flood");
    PlayerController.wc.forceAnimation("bug_death", true);
    this.Invoke("rainSmoke1", 1.5f);
    this.Invoke("rainSmoke2", 2.5f);
    this.Invoke("prestrike", 3f);
    this.Invoke("strike", 3.5f);
    this.Invoke("strikeEnd", 5f);
    this.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.rain_short);
  }

  private void rainSmoke1()
  {
    PlayerController.wc.setSimpleTargetV3(GameObject.Find("FirstEncounter").transform.position);
    PlayerController.wc.forceAnimation("run_e");
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED * 0.9f;
    GameObject.Find("RainSmokeEmmiter0").GetComponent<ParticleGenerator>().started = true;
  }

  private void rainSmoke2() => GameObject.Find("RainSmokeEmmiter1").GetComponent<ParticleGenerator>().started = true;

  private void prestrike() => this.light.strike(SoundsManagerController.sm.thunder5, 0.5f, true);

  private void strike()
  {
    GameObject.Find("lighting01").GetComponent<SpriteRenderer>().enabled = true;
    PlayerController.wc.forceAnimation("electrocute");
    GameObject gameObject = GameObject.Find("PlayerElectro");
    gameObject.transform.position = PlayerController.pc.gameObject.transform.position;
    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -3f);
    gameObject.GetComponent<SpriteRenderer>().flipX = PlayerController.wc.sr.flipX;
    gameObject.GetComponent<Animator>().Play("electrocute");
  }

  private void strikeEnd()
  {
    GameObject.Find("lighting01").GetComponent<SpriteRenderer>().enabled = false;
    PlayerController.pc.aS.Stop();
    this.Invoke("nextScene3", 4f);
  }

  private void bangbangyouredead()
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.break_window);
    this.gameObject.GetComponent<Animator>().enabled = true;
    this.gameObject.GetComponent<Animator>().Play("thugs_attack");
    this.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.rifle_shoot);
    PlayerController.wc.forceAnimation("shot_n", true);
    this.Invoke("nextScene3", 4f);
  }

  private void gasAfterWhile()
  {
    GameObject.Find("Gas (1)").GetComponent<ParticleGenerator>().started = true;
    GameObject.Find("Gas (2)").GetComponent<ParticleGenerator>().started = true;
  }

  private void makeSmoke()
  {
    GameObject.Find("Smoke1").GetComponent<ParticleGenerator>().started = true;
    GameObject.Find("Smoke1").GetComponent<ParticleGenerator>().maxParticles = 50;
    GameObject.Find("Smoke1").GetComponent<ParticleGenerator>().minAlpha = 0.1f;
    GameObject.Find("Smoke1").GetComponent<ParticleGenerator>().maxAlpha = 0.25f;
  }

  private void makeSmoke2()
  {
    GameObject.Find("Smoke1").GetComponent<ParticleGenerator>().maxParticles = 100;
    GameObject.Find("Smoke1").GetComponent<ParticleGenerator>().minAlpha = 0.25f;
    GameObject.Find("Smoke1").GetComponent<ParticleGenerator>().maxAlpha = 0.75f;
  }

  private void makeSmoke3()
  {
    GameObject.Find("Smoke1").GetComponent<ParticleGenerator>().maxParticles = 150;
    GameObject.Find("Smoke1").GetComponent<ParticleGenerator>().minAlpha = 0.5f;
    GameObject.Find("Smoke1").GetComponent<ParticleGenerator>().maxAlpha = 1f;
  }

  private void makeSmoke4()
  {
    GameObject.Find("Smoke1").GetComponent<ParticleGenerator>().maxParticles = 200;
    GameObject.Find("Smoke1").GetComponent<ParticleGenerator>().minAlpha = 1f;
    GameObject.Find("Smoke1").GetComponent<ParticleGenerator>().maxAlpha = 1f;
  }

  public override void updateState()
  {
    if ((bool) (Object) this.gameObject.GetComponent<Animator>())
      this.gameObject.GetComponent<Animator>().enabled = false;
    if (GameDataController.gd.getCurrentDay() == 1 && !GameDataController.gd.getObjective("dream_day_1_started") || GameDataController.gd.getCurrentDay() == 2 && !GameDataController.gd.getObjective("dream_day_2_started") || GameDataController.gd.getCurrentDay() == 3 && !GameDataController.gd.getObjective("dream_day_3_started") || GameDataController.gd.getCurrentDay() == 4 && !GameDataController.gd.getObjective("dream_day_4_started"))
      this.colliderManager.setCollider(-1);
    else if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjective("dream_day_1_window_broken") || GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjective("dream_day_2_window_broken"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(-1);
    }
    else if (GameDataController.gd.getCurrentDay() == 3)
    {
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.window;
      if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjective("dream_day_3_window_broken"))
      {
        this.gameObject.GetComponent<Animator>().enabled = true;
        this.gameObject.GetComponent<Animator>().Play("thugs_stare");
      }
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.colliderManager.setCollider(0);
    }
    else
      this.colliderManager.setCollider(0);
  }

  public void showBugs() => GameObject.Find("bugs_feast_1").GetComponent<SpriteRenderer>().enabled = true;

  public override void clickAction2()
  {
    if (GameDataController.gd.getCurrentDay() != 1)
      return;
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      GameObject.Find("bugs_feast_1").transform.position = ScreenControler.roundToNearestFullPixel2(GameObject.Find("bugs_feast_1").transform.position);
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
    {
      GameObject.Find("Gas (3)").GetComponent<ParticleGenerator>().started = true;
      GameObject.Find("Gas (4)").GetComponent<ParticleGenerator>().started = true;
      GameObject.Find("Gas (5)").GetComponent<ParticleGenerator>().started = true;
    }
    PlayerController.wc.forceAnimation("bug_death_2");
    this.Invoke("nextScene", 4f);
  }

  public void nextScene()
  {
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("LocationTent", WalkController.Direction.S, tSpeed: 0.5f);
  }

  public void nextScene2()
  {
    PlayerController.pc.aS.Stop();
    PlayerController.pc.spawnName = "WakeUp";
    if (GameDataController.gd.getObjectiveDetail("day1_complete") >= 0)
      CurtainController.cc.fadeOut("LocationBaseUpstairs", WalkController.Direction.S, "stand_up", flipX: true, tSpeed: 0.1f);
    else
      CurtainController.cc.fadeOut("LocationBaseUpstairs", WalkController.Direction.S, "sleep", flipX: true, tSpeed: 0.02f);
  }

  public void nextScene3()
  {
    if (!GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjectiveDetail("npc2_alive") == 0 || !GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjectiveDetail("npc3_alive") == 0)
    {
      GameDataController.gd.setObjective("location02_door_locked", false);
      GameDataController.gd.setObjective("location02_door_open", true);
      if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 2)
      {
        GameDataController.gd.setObjectiveDetail("towel_1_at_door", 0);
        Item obj = ItemsManager.im.getItem("towel_1");
        obj.dataRef.locX = 175;
        obj.dataRef.locY = 30;
        obj.dataRef.droppedLocation = "Location2";
      }
      if (GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 2)
      {
        GameDataController.gd.setObjectiveDetail("towel_2_at_door", 0);
        Item obj = ItemsManager.im.getItem("towel_2");
        obj.dataRef.locX = 175;
        obj.dataRef.locY = 30;
        obj.dataRef.droppedLocation = "Location2";
      }
      GameDataController.gd.setObjectiveDetail("car_location", 0);
      PlayerController.pc.spawnName = "Funeral";
      CurtainController.cc.fadeOut("LocationBaseOutside2", WalkController.Direction.NW, "stand_ne", flipX: true, actionAfterFade: new CurtainController.Delegate(this.startFuneral), tSpeed: 0.1f);
    }
    else
    {
      PlayerController.pc.spawnName = "Day3";
      if (GameDataController.gd.finishingLocation == "LocationCave")
        CurtainController.cc.fadeOut("LocationRV", WalkController.Direction.SW, "stand_se", flipX: true, actionAfterFade: new CurtainController.Delegate(this.startDreamTalk), tSpeed: 0.1f);
      else
        CurtainController.cc.fadeOut("Location1", WalkController.Direction.SW, "stand_se", flipX: true, actionAfterFade: new CurtainController.Delegate(this.startDreamTalk), tSpeed: 0.1f);
    }
  }

  private void startFuneral()
  {
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    string prefix = GameDataController.gd.getObjective("npc2_alive") || !GameDataController.gd.getObjective("npc2_joined") || GameDataController.gd.getObjectiveDetail("npc2_alive") != 0 ? "day3_funeral_cody" : "day3_funeral_barry";
    DialogueController.dc.initDialogue(dialogueLines, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    if (GameDataController.gd.getObjective("npc3_alive"))
      dialogueLines.Add(new DialogueLine(GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor(), GameStrings.getString(GameStrings.dialogues, "day3_funeral_barry_cody"), (TimelineFunction) null));
    if (GameDataController.gd.getObjective("npc2_alive"))
      dialogueLines.Add(new DialogueLine(GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc3Controller.getColor(), GameStrings.getString(GameStrings.dialogues, "day3_funeral_cody_barry"), (TimelineFunction) null));
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    this.startDreamTalk();
  }

  private void startDreamTalk()
  {
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    string prefix = GameDataController.gd.getObjectiveDetail("day_3_threat") != 0 ? "day3_intro1" : "day3_intro0";
    DialogueController.dc.initDialogue(dialogueLines, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive") && (!GameDataController.gd.getObjective("npc2_joined") || GameDataController.gd.getObjective("npc2_alive")))
      DialogueController.dc.initDialogue(dialogueLines, "d2_dream_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor());
    DialogueController.dc.initDialogue(dialogueLines, "day3_intro", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    Timeline.t.actions[Timeline.t.actions.Count - 1].function = new TimelineFunction(this.transportToSidereal);
  }

  private void transportToSidereal(string s = "")
  {
    PlayerController.pc.setBusy(false);
    GameDataController.gd.setObjectiveDetail("map_sidereal_revealed", TravelAgency.LOCATION_STATUS_REACHABLE);
  }

  public override void clickAction0()
  {
  }
}
