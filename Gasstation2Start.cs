// Decompiled with JetBrains decompiler
// Type: Gasstation2Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Gasstation2Start : MonoBehaviour
{
  public GasstationThug2Controller thug2Controller;
  public GasstationThug2Controller thug3Controller;
  public GasstationSarge sargeController;
  public TextFieldController sarge;
  public TextFieldController thug;
  public Vector3 sargeColor;
  public Vector3 thugColor;
  public SpriteRenderer snowr;
  public PolygonCollider2D bikeBlock;
  public PolygonCollider2D sargeBlock;
  public SpriteRenderer bike;
  public bool updateDontKillCPUplz;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.12f;
    PlayerController.wc.shadow.fadeRateH = 1f / 1000f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 5f;
    PlayerController.wc.shadow.startAlpha = 0.75f;
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 160f;
    PlayerController.ssg.setStepType("road");
    GameDataController.gd.setObjective("visited_gasstation2", true);
    PlayerController.pc.copySettingsToNPCs();
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 1f);
    if (GameDataController.gd.getCurrentDay() == 1 && !GameDataController.gd.getObjective("gasstation_spider_shot") && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_6a, minTime: 1f, maxTime: 3f);
    else if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getObjective("sidereal_base_located") && !GameDataController.gd.getObjective("gasstation_sarge_reason"))
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_6a);
    else if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getObjective("sidereal_base_located") && GameDataController.gd.getObjective("gasstation_spy_mode"))
      JukeboxMusic.jb.changeMusic((AudioClip) null);
    else if (GameDataController.gd.getObjective("gasstation_sarge_shot"))
      JukeboxMusic.jb.changeMusic((AudioClip) null);
    else
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_3a);
    this.starter();
    this.updateDontKillCPUplz = false;
    if (GameDataController.gd.getCurrentDay() != 3 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 0 || !GameDataController.gd.getObjective("sidereal_base_located") || GameDataController.gd.getObjective("gasstation_spy_mode") || GameDataController.gd.getObjective("gasstation_sarge_intro") || GameDataController.gd.getObjective("gasstation_sarge_shot"))
      return;
    this.updateDontKillCPUplz = true;
  }

  public void starter()
  {
    if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && !GameDataController.gd.getObjective("thugs_gasstation_talk") && GameDataController.gd.getObjective("sidereal_base_located"))
    {
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "gasstation_thugs", this.sarge, this.sargeColor, this.thug, this.thugColor, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
      if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc3_joined"))
        dialogueLines[5].text = GameStrings.getString(GameStrings.dialogues, "gasstation_thugs_6_b_cody_barry");
      else if (GameDataController.gd.getObjective("npc2_joined"))
        dialogueLines[5].text = GameStrings.getString(GameStrings.dialogues, "gasstation_thugs_6_b_barry");
      else if (GameDataController.gd.getObjective("npc3_joined"))
        dialogueLines[5].text = GameStrings.getString(GameStrings.dialogues, "gasstation_thugs_6_b_cody");
      dialogueLines[18].action = new TimelineFunction(this.thug2Go);
      dialogueLines[18].actionWithText = true;
      dialogueLines[19].action = new TimelineFunction(this.sargeKneel);
      dialogueLines[19].actionWithText = false;
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
      GameDataController.gd.setObjective("thugs_gasstation_talk", true);
      GameDataController.gd.setObjectiveDetail("map_construction_revealed", TravelAgency.LOCATION_STATUS_REACHABLE);
      ItemsManager.im.fixGroundItems(new Vector2(175f, 35f), new Vector2(5f, 2f));
      GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
      ItemsManager.im.initGroundAndInv();
      this.bike.enabled = true;
      this.bikeBlock.enabled = true;
      this.sargeBlock.enabled = true;
      this.thug2Controller.GetComponent<SpriteRenderer>().enabled = true;
      this.thug3Controller.GetComponent<SpriteRenderer>().enabled = true;
    }
    else if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getObjective("sidereal_base_located"))
    {
      ItemsManager.im.fixGroundItems(new Vector2(175f, 35f), new Vector2(5f, 2f));
      GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
      ItemsManager.im.initGroundAndInv();
      this.bike.enabled = true;
      this.bikeBlock.enabled = true;
      if (!GameDataController.gd.getObjective("gasstation_sarge_shot") && !GameDataController.gd.getObjective("gasstation_sarge_convinced"))
        this.sargeBlock.enabled = true;
      else
        this.sargeBlock.enabled = false;
      if (GameDataController.gd.getObjective("gasstation_sarge_convinced"))
      {
        this.bike.enabled = false;
        this.bikeBlock.enabled = false;
        this.sargeBlock.enabled = false;
      }
      this.thug2Controller.GetComponent<SpriteRenderer>().enabled = false;
      this.thug3Controller.GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      this.bike.enabled = false;
      this.bikeBlock.enabled = false;
      this.sargeBlock.enabled = false;
      this.thug2Controller.GetComponent<SpriteRenderer>().enabled = false;
      this.thug3Controller.GetComponent<SpriteRenderer>().enabled = false;
    }
    if (GameDataController.gd.getObjective("gasstation_spy_mode"))
    {
      GameObject.Find("Location").GetComponent<PolygonCollider2D>().enabled = false;
      GameObject.Find("SpyWalkArea").GetComponent<PolygonCollider2D>().enabled = true;
      PlayerController.pc.allowDrop = false;
    }
    else
    {
      PlayerController.pc.allowDrop = true;
      GameObject.Find("Location").GetComponent<PolygonCollider2D>().enabled = true;
      GameObject.Find("SpyWalkArea").GetComponent<PolygonCollider2D>().enabled = false;
      if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getObjective("sidereal_base_located") && !GameDataController.gd.getObjective("gasstation_spy_mode") && !GameDataController.gd.getObjective("gasstation_sarge_intro") && !GameDataController.gd.getObjective("gasstation_sarge_shot"))
      {
        PlayerController.pc.setBusy(true);
        PlayerController.pc.forceAnimation("walk_e");
        this.Invoke("forceTalk0", 0.01f);
        this.forceTalk1();
      }
    }
    GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
    if (GameDataController.gd.getCurrentDay() == 3)
    {
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
        this.snowr.enabled = true;
      else
        this.snowr.enabled = false;
    }
    else
      this.snowr.enabled = false;
  }

  private void thug2Go(string param = "")
  {
    this.thug2Controller.ride();
    this.thug3Controller.ride();
  }

  private void forceTalk0()
  {
    PlayerController.pc.setBusy(true);
    PlayerController.wc.setSimpleTarget((Vector2) ScreenControler.roundToNearestFullPixel(GameObject.Find("WalkToGun").transform.position));
  }

  private void forceTalk1() => GameObject.Find("sargeObject").GetComponent<GasstationSargeObject>().initIntroDialogue();

  private void sargeKneel(string param = "") => this.sargeController.kneel();

  private void Update()
  {
    if (!this.updateDontKillCPUplz || (double) PlayerController.wc.currentXY.x < (double) ScreenControler.roundToNearestFullPixel(GameObject.Find("WalkToGun").transform.position).x)
      return;
    this.updateDontKillCPUplz = false;
    PlayerController.wc.forceAnimation("stand_se");
  }
}
