// Decompiled with JetBrains decompiler
// Type: Npc2Controller
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Npc2Controller : NPCActionController
{
  private bool struggled;
  private static Vector3 color = new Vector3(0.285f, 0.525f, 0.66f);

  public static Vector3 getColor() => Npc2Controller.color;

  public override void continueStart()
  {
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("locket", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("water1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("water2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("water3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("water4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("food_bag", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("deadbird", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("whiskey", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("lighter", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rope", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ropehook", string.Empty, anim: string.Empty));
    if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
    {
      this.interactions.Add(new ItemInteraction("revolver_6", string.Empty, anim: string.Empty));
      this.interactions.Add(new ItemInteraction("revolver_5", string.Empty, anim: string.Empty));
      this.interactions.Add(new ItemInteraction("revolver_4", string.Empty, anim: string.Empty));
      this.interactions.Add(new ItemInteraction("revolver_3", string.Empty, anim: string.Empty));
      this.interactions.Add(new ItemInteraction("revolver_2", string.Empty, anim: string.Empty));
      this.interactions.Add(new ItemInteraction("revolver_1", string.Empty, anim: string.Empty));
      this.interactions.Add(new ItemInteraction("revolver_0", GameStrings.getString(GameStrings.actions, "revolver_npc_ammo"), anim: string.Empty));
    }
    else if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
    {
      this.interactions.Add(new ItemInteraction("revolver_6", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("revolver_5", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("revolver_4", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("revolver_3", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("revolver_2", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("revolver_1", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("revolver_0", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
    }
    this.interactions.Add(new ItemInteraction("pills", string.Empty, anim: string.Empty));
    if (!GameDataController.gd.getObjective("npc2_joined"))
    {
      this.interactions.Add(new ItemInteraction("rifle_0", GameStrings.getString(GameStrings.actions, "barry_threaten"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_1", GameStrings.getString(GameStrings.actions, "barry_threaten"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_2", GameStrings.getString(GameStrings.actions, "barry_threaten"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_3", GameStrings.getString(GameStrings.actions, "barry_threaten"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_4", GameStrings.getString(GameStrings.actions, "barry_threaten"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_5", GameStrings.getString(GameStrings.actions, "barry_threaten"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_6", GameStrings.getString(GameStrings.actions, "barry_threaten"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("wrench", GameStrings.getString(GameStrings.actions, "barry_threaten"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("crowbar", GameStrings.getString(GameStrings.actions, "barry_threaten"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("hammer", GameStrings.getString(GameStrings.actions, "barry_threaten"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("pipe", GameStrings.getString(GameStrings.actions, "barry_threaten"), anim: string.Empty));
    }
    else if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
    {
      this.interactions.Add(new ItemInteraction("rifle_0", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_1", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_2", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_3", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_4", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_5", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_6", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_0", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_1", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_2", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_3", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_4", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_5", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_6", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_0", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_1", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_2", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_3", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_4", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_5", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_6", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_0", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_1", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_2", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_3", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_4", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_5", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_6", GameStrings.getString(GameStrings.actions, "barry_give_rifle"), anim: string.Empty));
    }
    else if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
    {
      this.interactions.Add(new ItemInteraction("rifle_0", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_1", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_2", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_3", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_4", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_5", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_6", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_0", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_1", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_2", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_3", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_4", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_5", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_6", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_0", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_1", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_2", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_3", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_4", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_5", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_6", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_0", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_1", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_2", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_3", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_4", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_5", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_6", GameStrings.getString(GameStrings.actions, "gun_barry_storm"), anim: string.Empty));
    }
    this.actionType = ObjectActionController.Type.Talk;
  }

  public override void whatOnClick()
  {
  }

  public override void whatOnClick0()
  {
    if (GameDataController.gd.getObjective("constructionsite_from_above"))
    {
      this.range = 250f;
      this.rotateToSpeaker = true;
    }
    else if (GameDataController.gd.getObjective("sidereal_roof_wait_for_rescue"))
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker_pull").gameObject;
      this.range = 1f;
      this.rotateToSpeaker = false;
    }
    else if (GameDataController.gd.getObjective("sidereal_roof_npc_shocked"))
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker_sit").gameObject;
      this.range = 0.0f;
      this.rotateToSpeaker = false;
    }
    else if (GameDataController.gd.getObjective("moon_shocked2"))
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker_sit").gameObject;
      this.range = 0.0f;
      this.rotateToSpeaker = false;
    }
    else if (GameDataController.gd.getObjective("dialogue_ginger_barry_distracted"))
    {
      this.actionMarker = GameObject.Find("Action_Marker");
      this.range = 100f;
      this.rotateToSpeaker = false;
    }
    else if (GameDataController.gd.getObjective("npc2_joined"))
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.range = 25f;
      this.rotateToSpeaker = true;
    }
    else
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.range = 1f;
      this.rotateToSpeaker = false;
    }
  }

  private void giveNote(string val = "")
  {
    if (GameDataController.gd.getObjective("dialogue_ginger_barry_distracted"))
    {
      GameObject.Find("Ginger").GetComponent<TextFieldController>().dissmiss();
      GameObject.Find("Npc2").GetComponent<TextFieldController>().dissmiss();
      GameObject.Find("Ginger").GetComponent<GingerActionController>().setDistractFalse(string.Empty);
    }
    GameObject.Find("Ginger").GetComponent<NPCWalkController>().setTargetV3(GameObject.Find("BarryShootPoint").transform.position);
    PlayerController.wc.setSimpleTargetV3(GameObject.Find("BarryLocketPoint").gameObject.transform.position);
    PlayerController.wc.autoAction = new WalkController.Delegate(this.giveLocket);
    PlayerController.wc.forceAnimation("walk_e");
  }

  public void siderealFall()
  {
    GameObject.Find("Npc2").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.dialogues, "fall_aah"), mwidth: 100, r: Npc2Controller.getColor().x, g: Npc2Controller.getColor().y, b: Npc2Controller.getColor().z, mute: true);
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("barry_fall");
    this.gameObject.GetComponent<NPCWalkController>().speed = 5f;
    this.gameObject.GetComponent<NPCWalkController>().setSimpleTarget(new Vector2(this.gameObject.GetComponent<NPCWalkController>().currentXY.x, -100f));
    JukeboxMusic.jb.changeMusic((AudioClip) null, minTime: 0.0f, maxTime: 0.0f, newStep: 0.01f);
  }

  public void fallAccelerate()
  {
    if ((double) this.gameObject.GetComponent<NPCWalkController>().speed < 10.0)
      this.gameObject.GetComponent<NPCWalkController>().speed += 0.5f;
    if ((double) this.gameObject.GetComponent<NPCWalkController>().currentXY.y > -90.0)
      return;
    this.gameObject.GetComponent<NPCWalkController>().speed = 0.0f;
    this.gameObject.GetComponent<NPCWalkController>().spawned = false;
    this.gameObject.GetComponent<NPCWalkController>().currentXY.x = 0.0f;
    this.gameObject.GetComponent<NPCWalkController>().currentXY.y = 0.0f;
    this.gameObject.GetComponent<NPCWalkController>().clearTarget();
    this.gameObject.GetComponent<NPCWalkController>().fullStop();
    this.gameObject.GetComponent<TextFieldController>().dissmiss();
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("stand_n");
    this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
  }

  public void giveLocket() => PlayerController.wc.forceAnimation("action1_e_animation");

  private void standUp(string val = "")
  {
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("get_up", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_action_loop, minTime: 0.0f, maxTime: 0.0f);
  }

  private void fall(string val = "")
  {
    this.gameObject.GetComponent<NPCWalkController>().setBusy(false);
    this.gameObject.GetComponent<NPCWalkController>().setTargetV3(GameObject.Find("BarryAttackPoint").transform.position);
    GameObject.Find("Ginger").GetComponent<NPCWalkController>().setTargetV3(GameObject.Find("BarryShootPoint2").transform.position);
    PlayerController.wc.forceAnimation("sit_fall");
    this.struggled = false;
    this.Invoke("sit_strugle1", 1f);
  }

  private void sit_strugle1() => this.sit_strugle(string.Empty);

  private void sit_strugle(string val = "")
  {
    if (this.struggled)
      return;
    this.struggled = true;
    this.gameObject.GetComponent<NPCWalkController>().setBusy(true);
    PlayerController.wc.forceAnimation(nameof (sit_strugle));
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("stand_e", true);
    GameObject.Find("Ginger").GetComponent<GingerActionController>().drawGun(string.Empty);
  }

  private void drawGun(string val = "")
  {
  }

  private void aimGun(string val = "") => GameObject.Find("Ginger").GetComponent<GingerActionController>().aimDown("right");

  private void read(string val = "")
  {
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_emotional, false, newStep: 0.01f);
    this.gameObject.GetComponent<NPCWalkController>().setBusy(false);
    this.gameObject.GetComponent<NPCWalkController>().setSimpleTargetV3(GameObject.Find("WaypointHouseBDistract").transform.Find("BarrySpawner").transform.position);
  }

  private void read2(string val = "")
  {
    GameObject.Find("Ginger").GetComponent<GingerActionController>().holdGunUp("right");
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("npc2_read");
  }

  private void read3(string val = "") => PlayerController.wc.forceAnimation("stand_up");

  private void returnToSpawn(string val = "") => GameObject.Find("Ginger").GetComponent<GingerActionController>().holster("right");

  private void sitDown(string val = "") => this.gameObject.GetComponent<NPCWalkController>().forceAnimation("sit_down", true);

  public void goToSleep1(string a = "") => this.gameObject.GetComponent<NPCWalkController>().setSimpleTargetV3(GameObject.Find("BarryWalkHere").transform.position);

  public void goToSleep2(string a = "")
  {
    PlayerController.pc.setBusy(true);
    PlayerController.pc.spawnName = "barry_pod";
    DialogueController.dc.talking = false;
    Timeline.t.doNotUnlock = true;
    CurtainController.cc.fadeOut("LocationMoonbase3", WalkController.Direction.NW, "stand_ne", actionAfterFade: new CurtainController.Delegate(this.goToSleep3));
  }

  public void goToSleep3()
  {
    TextFieldController component = GameObject.Find("Moonbase3Pad4").transform.Find("TextField").GetComponent<TextFieldController>();
    if (GameDataController.gd.getObjective("npc1_alive") && !GameDataController.gd.getObjective("moon_cate_sleeps"))
    {
      component.transform.position = ScreenControler.roundToNearestFullPixel3(component.transform.position);
      this.instantLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(this.instantLines, "barry_sleep_cate", component, Npc2Controller.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
      for (int index = 0; index < this.instantLines.Count; ++index)
        Timeline.t.addDialogue(this.instantLines[index]);
    }
    if (GameDataController.gd.getObjective("npc3_alive") && !GameDataController.gd.getObjective("moon_cody_sleeps"))
    {
      this.instantLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(this.instantLines, "barry_sleep_cody", component, Npc2Controller.color, GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor());
      for (int index = 0; index < this.instantLines.Count; ++index)
        Timeline.t.addDialogue(this.instantLines[index]);
    }
    this.instantLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.instantLines, "barry_sleep_2david", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, Npc2Controller.color);
    this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(this.closePod);
    for (int index = 0; index < this.instantLines.Count; ++index)
      Timeline.t.addDialogue(this.instantLines[index]);
  }

  public void closePod(string s = "")
  {
    GameObject.Find("Moonbase3Pad4").GetComponent<Animator>().Play("moon_pod4_close");
    GameDataController.gd.setObjectiveDetail("moon_barry_sleeps", 1);
    if (GameDataController.gd.getObjective("npc1_alive") && !GameDataController.gd.getObjective("moon_cate_sleeps"))
      GameObject.Find("Ginger").GetComponent<GingerActionController>().pod_rotate();
    if (!GameDataController.gd.getObjective("npc3_alive") || GameDataController.gd.getObjective("moon_cody_sleeps"))
      return;
    GameObject.Find("Npc3").GetComponent<Npc3Controller>().pod_rotate();
  }

  public void pod_rotate() => this.Invoke("pod_rotate2", Random.Range(0.5f, 2f));

  public void pod_rotate2()
  {
    this.GetComponent<NPCWalkController>().playIdleAnimation("stand_se");
    this.GetComponent<NPCWalkController>().setBusy(false);
  }

  public void playerStandUp(string v = "")
  {
    Timeline.t.doNotUnlock = true;
    PlayerController.pc.forceAnimation("kneel_out_n");
  }

  public override void npcClickAction(string item = "")
  {
    Vector3 color1 = GingerActionController.getColor();
    TextFieldController component1 = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    Vector3 color2 = Npc3Controller.getColor();
    TextFieldController component2 = GameObject.Find("Npc3").GetComponent<TextFieldController>();
    this.instantLines = new List<DialogueLine>();
    if (GameDataController.gd.getObjective("sidereal_roof_wait_for_rescue"))
    {
      if (GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjectiveDetail("npc3_alive") != 1 && !GameDataController.gd.getObjective("cody_warned"))
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "save_barry"), yesClick: new Button.Delegate(this.uratuj));
      else
        this.uratuj();
    }
    else
    {
      if (GameDataController.gd.getObjective("sidereal_roof_npc_shocked"))
      {
        PlayerController.pc.forceAnimation("kneel_in_n");
        if (!GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjectiveDetail("npc3_alive") == 1)
        {
          DialogueController.dc.initDialogue(this.instantLines, "sidereal_afterfall_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component1, color1);
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(this.playerStandUp);
        }
        else
        {
          DialogueController.dc.initDialogue(this.instantLines, "sidereal_nofall_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component1, color1);
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(this.endTalkRoof);
          GameDataController.gd.setObjective("sidereal_roof_npc_shocked", false);
          this.instantLines[this.instantLines.Count - 2].action = new TimelineFunction(this.playerStandUp);
          for (int index = 0; index < this.instantLines.Count; ++index)
            Timeline.t.addDialogue(this.instantLines[index]);
          return;
        }
      }
      else
      {
        if (GameDataController.gd.getObjective("moon_shocked2"))
        {
          PlayerController.pc.forceAnimation("kneel_in_n");
          DialogueController.dc.initDialogue(this.instantLines, "moon_shocked_barry1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component1, color1);
          GameDataController.gd.setObjective("moon_shocked2", false);
          if (GameDataController.gd.getObjective("npc1_alive") && !GameDataController.gd.getObjective("moon_shocked1") && (!GameDataController.gd.getObjective("npc2_alive") || !GameDataController.gd.getObjective("moon_shocked2")) && (!GameDataController.gd.getObjective("npc3_alive") || !GameDataController.gd.getObjective("moon_shocked3")) && GameDataController.gd.getObjective("npc1_alive"))
            this.instantLines.Add(new DialogueLine(component1, color1, GameStrings.getString(GameStrings.dialogues, "moon_shocked_cate_ending"), (TimelineFunction) null));
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(this.endTalkShip);
          this.instantLines[this.instantLines.Count - 2].action = new TimelineFunction(this.playerStandUp);
          for (int index = 0; index < this.instantLines.Count; ++index)
            Timeline.t.addDialogue(this.instantLines[index]);
          if (GameDataController.gd.getObjective("npc1_alive") || GameDataController.gd.getObjective("moon_shocked1"))
            return;
          this.instantLines = new List<DialogueLine>();
          DialogueController.dc.initDialogue(this.instantLines, "moon_shocked_barry2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component1, color1);
          for (int index = 0; index < this.instantLines.Count; ++index)
            Timeline.t.addDialogue(this.instantLines[index]);
          return;
        }
        if (item == "locket")
        {
          if (!GameDataController.gd.getObjective("house_b_wife_note_read"))
          {
            PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "house_b_locket_unread"), true, mwidth: 180);
            return;
          }
          DialogueController.dc.initDialogue(this.instantLines, "npc2_locket", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component1, color1);
          GameDataController.gd.setObjective("npc2_wife_note_given", true);
          InventoryController.ic.removeItem("locket");
          this.instantLines[0].action = new TimelineFunction(this.giveNote);
          this.instantLines[0].actionWithText = true;
          this.instantLines[3].action = new TimelineFunction(this.standUp);
          this.instantLines[3].actionWithText = true;
          this.instantLines[4].action = new TimelineFunction(this.fall);
          this.instantLines[4].actionWithText = true;
          this.instantLines[5].action = new TimelineFunction(this.sit_strugle);
          this.instantLines[5].actionWithText = true;
          this.instantLines[8].action = new TimelineFunction(this.drawGun);
          this.instantLines[8].actionWithText = true;
          this.instantLines[10].action = new TimelineFunction(this.aimGun);
          this.instantLines[10].actionWithText = true;
          this.instantLines[16].action = new TimelineFunction(this.read);
          this.instantLines[16].actionWithText = true;
          this.instantLines[17].action = new TimelineFunction(this.read2);
          this.instantLines[17].actionWithText = true;
          this.instantLines[18].action = new TimelineFunction(this.read3);
          this.instantLines[18].actionWithText = true;
          this.instantLines[20].action = new TimelineFunction(this.returnToSpawn);
          this.instantLines[20].actionWithText = true;
          this.instantLines[22].action = new TimelineFunction(this.sitDown);
          this.instantLines[22].actionWithText = true;
          if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
          {
            this.instantLines.Insert(13, new DialogueLine(component2, color2, GameStrings.getString(GameStrings.dialogues, "npc2_locket_CODY_c"), (TimelineFunction) null));
            component2.gameObject.GetComponent<NPCWalkController>().forceDirection(NPCWalkController.Direction.SE);
          }
        }
        else
        {
          if (!GameDataController.gd.getObjective("dialogue_npc2_intro"))
          {
            DialogueController.dc.initDialogue(this.instantLines, "npc2_intro1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component1, color1);
            this.instantLines[0].actionWithText = true;
            GameDataController.gd.setObjective("dialogue_npc2_intro", true);
            if (GameDataController.gd.getObjective("npc3_joined"))
              this.instantLines.Insert(6, new DialogueLine(PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameStrings.getString(GameStrings.dialogues, "npc2_intro1_6_extra_a"), (TimelineFunction) null));
            if (GameDataController.gd.getObjective("previous_disc_barry") || GameDataController.gd.getObjective("previous_disc_cody"))
              DialogueController.dc.initDialogue(this.instantLines, "npc2_intro3", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component1, color1);
          }
          else
          {
            if (GameDataController.gd.getObjective("dialogue_ginger_barry_distracted"))
            {
              PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "ginger_barry_distracted"), true, mwidth: 150);
              return;
            }
            if (GameDataController.gd.getObjective("npc2_joined"))
            {
              if (item == "coat1" || item == "coat2" || item == "coat3" || item == "coat4")
              {
                if (GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
                {
                  DialogueController.dc.initDialogue(this.instantLines, "npc2_bad_coat", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component1, color1);
                  this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
                }
                else if (GameDataController.gd.getCurrentDay() != 2)
                {
                  DialogueController.dc.initDialogue(this.instantLines, "npc2_bad2_coat", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component1, color1);
                  this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
                }
                else if (ItemsManager.im.getItem("coat1").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("coat2").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("coat3").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("coat4").dataRef.droppedLocation == "npc2")
                {
                  DialogueController.dc.initDialogue(this.instantLines, "npc2_already_coat", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component1, color1);
                  this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
                }
                else if (GameDataController.gd.getObjective("npc3_joined") && ItemsManager.im.getItem("coat1").dataRef.droppedLocation != "npc3" && ItemsManager.im.getItem("coat2").dataRef.droppedLocation != "npc3" && ItemsManager.im.getItem("coat3").dataRef.droppedLocation != "npc3" && ItemsManager.im.getItem("coat4").dataRef.droppedLocation != "npc3")
                {
                  DialogueController.dc.initDialogue(this.instantLines, "npc2_cody_coat", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component2, color2);
                  this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
                }
                else if (GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
                {
                  DialogueController.dc.initDialogue(this.instantLines, "npc2_give_coat", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component1, color1);
                  this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
                  InventoryController.ic.removeItem(item);
                  ItemsManager.im.getItem(item).dataRef.droppedLocation = "npc2";
                  JournalTexts.pickTexts(GameDataController.gd.getCurrentDay());
                }
              }
              else if (item == "water1" || item == "water2" || item == "water3" || item == "water4")
              {
                if (GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
                {
                  DialogueController.dc.initDialogue(this.instantLines, "npc2_bad_water", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component1, color1);
                  this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
                }
                else if (GameDataController.gd.getCurrentDay() != 2)
                {
                  DialogueController.dc.initDialogue(this.instantLines, "npc2_bad2_water", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component1, color1);
                  this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
                }
                else if (ItemsManager.im.getItem("water1").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("water2").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("water3").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("water4").dataRef.droppedLocation == "npc2")
                {
                  DialogueController.dc.initDialogue(this.instantLines, "npc2_already_water", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component1, color1);
                  this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
                }
                else if (GameDataController.gd.getObjective("npc3_joined") && ItemsManager.im.getItem("water1").dataRef.droppedLocation != "npc3" && ItemsManager.im.getItem("water2").dataRef.droppedLocation != "npc3" && ItemsManager.im.getItem("water3").dataRef.droppedLocation != "npc3" && ItemsManager.im.getItem("water4").dataRef.droppedLocation != "npc3")
                {
                  DialogueController.dc.initDialogue(this.instantLines, "npc2_cody_water", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component2, color2);
                  this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
                }
                else if (GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
                {
                  DialogueController.dc.initDialogue(this.instantLines, "npc2_give_water", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component1, color1);
                  this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
                  InventoryController.ic.removeItem(item);
                  ItemsManager.im.getItem(item).dataRef.droppedLocation = "npc2";
                  JournalTexts.pickTexts(GameDataController.gd.getCurrentDay());
                }
              }
              else if (this.usedItem == "pills")
              {
                string prefix = "barry_give_pills";
                if (GameDataController.gd.getObjective("barry_pills_taken"))
                  prefix = "barry_gave_pills";
                GameDataController.gd.setObjective("barry_pills_taken", true);
                DialogueController.dc.initDialogue(this.instantLines, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color);
                this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
              }
              else if (this.usedItem.IndexOf("revolver") != -1)
              {
                if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
                {
                  DialogueController.dc.initDialogue(this.instantLines, "npc2_give_gun", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component1, color1);
                  this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
                  InventoryController.ic.removeItem(item);
                  ItemsManager.im.getItem(item).dataRef.droppedLocation = "npc2";
                }
              }
              else if (item == "food_bag")
              {
                if (GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjective("npc3_joined"))
                  DialogueController.dc.initDialogue(this.instantLines, "barry_bag_of_food1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor(), this.textField, Npc2Controller.color);
                else
                  DialogueController.dc.initDialogue(this.instantLines, "barry_bag_of_food2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor(), this.textField, Npc2Controller.color);
                this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
              }
              else if (item == "deadbird")
              {
                DialogueController.dc.initDialogue(this.instantLines, "dead_bird_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1, this.textField, Npc2Controller.color);
                this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
              }
              else if (item == "whiskey")
              {
                DialogueController.dc.initDialogue(this.instantLines, "whiskey_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1, this.textField, Npc2Controller.color);
                this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
              }
              else if (item == "lighter")
              {
                DialogueController.dc.initDialogue(this.instantLines, "lighter_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1, this.textField, Npc2Controller.color);
                this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
              }
              else if (item == "rope" || item == "ropehook")
              {
                DialogueController.dc.initDialogue(this.instantLines, "rope_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1, this.textField, Npc2Controller.color);
                this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
              }
              else
                DialogueController.dc.initDialogue(this.instantLines, "npc2_intro2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component1, color1);
            }
            else
              DialogueController.dc.initDialogue(this.instantLines, "npc2_intro2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component1, color1);
          }
          if (!GameDataController.gd.getObjective("npc2_joined"))
            this.instantLines[0].action = new TimelineFunction(this.lookUp);
        }
      }
      for (int index = 0; index < this.instantLines.Count; ++index)
        Timeline.t.addDialogue(this.instantLines[index]);
      DialogueController.dc.callback = new DialogueController.Callback(this.dialogues);
      this.dialogues();
    }
  }

  public void dialogues()
  {
    DialogueController.dc.reset();
    Vector3 color = GingerActionController.getColor();
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    int i1 = 0;
    if (!GameDataController.gd.getObjective("npc2_joined"))
    {
      this.takeDoc(i1);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "npc2_come_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/barry");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dialogue_npc2_come");
      DialogueController.dc.initDialogue(this.doc.lines, "npc2_come", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component, color);
      ++i1;
    }
    int num1;
    if (GameDataController.gd.getObjective("sidereal_roof_npc_shocked") && !GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjectiveDetail("npc3_alive") == 1)
    {
      this.takeDoc(i1);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sidereal_afterfall_barry_ans1_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/cody");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective(string.Empty);
      DialogueController.dc.initDialogue(this.doc.lines, "sidereal_afterfall_barry_ans1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component, color);
      this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalkRoof);
      int i2 = i1 + 1;
      this.takeDoc(i2);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sidereal_afterfall_barry_ans2_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/cody");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective(string.Empty);
      DialogueController.dc.initDialogue(this.doc.lines, "sidereal_afterfall_barry_ans2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component, color);
      this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalkRoof);
      int i3 = i2 + 1;
      this.takeDoc(i3);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sidereal_afterfall_barry_ans3_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/cody");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective(string.Empty);
      DialogueController.dc.initDialogue(this.doc.lines, "sidereal_afterfall_barry_ans3", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component, color);
      this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalkRoof);
      num1 = i3 + 1;
      this.takeDoc(0);
      if (this.doc.caption != string.Empty)
        DialogueController.dc.talking = true;
      this.updateState();
    }
    else
    {
      this.takeDoc(i1);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "npc2_wife_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/dead_wife");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dialogue_npc2_wife");
      DialogueController.dc.initDialogue(this.doc.lines, "npc2_wife", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component, color);
      int i4 = i1 + 1;
      if (!GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("dialogue_npc2_come") && GameDataController.gd.getObjective("dialogue_npc2_wife"))
      {
        this.takeDoc(i4);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "npc2_come2_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/barry_wife");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_npc2_come2");
        DialogueController.dc.initDialogue(this.doc.lines, "npc2_come2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component, color);
        ++i4;
      }
      if (GameDataController.gd.getObjective("npc2_joined"))
      {
        i4 = this.dayDialogue(this.locationDialogue(i4, Npc2Controller.color, "barry"), Npc2Controller.color, "barry");
        if ((SceneManager.GetActiveScene().name == "Location1" || SceneManager.GetActiveScene().name == "Location2" || SceneManager.GetActiveScene().name == "LocationBaseBathroom" || SceneManager.GetActiveScene().name == "LocationBaseUpstairs" || SceneManager.GetActiveScene().name == "LocationBaseOutside0" || SceneManager.GetActiveScene().name == "LocationBaseOutside1" || SceneManager.GetActiveScene().name == "LocationBaseOutside2" || SceneManager.GetActiveScene().name == "LocationBaseOutside3" || SceneManager.GetActiveScene().name == "LocationAttic2" || SceneManager.GetActiveScene().name == "LocationAttic1") && GameDataController.gd.getObjective("barry_base_welcome"))
        {
          this.takeDoc(i4);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "barry_base_family_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/house");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("barry_base_family");
          DialogueController.dc.initDialogue(this.doc.lines, "barry_base_family", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component, color);
          ++i4;
        }
        if (GameDataController.gd.getCurrentDay() < 4)
        {
          this.takeDoc(i4);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "npc2_moon_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/moon");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_npc2_moon");
          DialogueController.dc.initDialogue(this.doc.lines, "npc2_moon", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component, color);
          int i5 = i4 + 1;
          this.takeDoc(i5);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "npc2_ship_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/ship");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_npc2_ship");
          DialogueController.dc.initDialogue(this.doc.lines, "npc2_ship", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component, color);
          i4 = i5 + 1;
        }
        string empty = string.Empty;
        if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getCurrentDay() < 5)
        {
          this.takeDoc(i4);
          string str = "npc2_cody";
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, str + "_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/cody");
          this.doc.lines = new List<DialogueLine>();
          int num2 = 1;
          if (GameDataController.gd.getCurrentDay() == 2)
            num2 = 1;
          if (GameDataController.gd.getCurrentDay() == 3)
            num2 = 2;
          if (GameDataController.gd.getCurrentDay() == 4)
            num2 = 3;
          this.doc.setObjective("dialogue_" + str + num2.ToString());
          DialogueController.dc.initDialogue(this.doc.lines, str + num2.ToString(), PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor());
          ++i4;
        }
        else if (GameDataController.gd.getObjective("npc3_joined") && !GameDataController.gd.getObjective("npc3_alive") && (GameDataController.gd.getObjective("sidereal_npc_found") || GameDataController.gd.getObjectiveDetail("npc3_alive") != 1))
        {
          this.takeDoc(i4);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "barry_cody_dead_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/cody");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_npc2_cody_dead");
          DialogueController.dc.initDialogue(this.doc.lines, "barry_cody_dead", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component, color);
          if (GameDataController.gd.getObjectiveDetail("npc3_alive") == 0)
            this.doc.lines[3].text = GameStrings.getString(GameStrings.dialogues, "barry_cody_dead_day2");
          if (GameDataController.gd.getObjectiveDetail("npc3_alive") == 1)
            this.doc.lines[3].text = GameStrings.getString(GameStrings.dialogues, "barry_cody_dead_sidereal");
          ++i4;
        }
        if (GameDataController.gd.getObjective("npc1_alive"))
        {
          if (GameDataController.gd.getCurrentDay() < 5)
          {
            this.takeDoc(i4);
            string str = "npc2_ginger";
            this.doc.caption = GameStrings.getString(GameStrings.dialogues, str + "_caption");
            this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/ginger");
            this.doc.lines = new List<DialogueLine>();
            int num3 = 1;
            if (GameDataController.gd.getCurrentDay() == 2)
              num3 = 1;
            if (GameDataController.gd.getCurrentDay() == 3)
              num3 = 2;
            if (GameDataController.gd.getCurrentDay() == 4)
              num3 = 3;
            this.doc.setObjective("dialogue_" + str + num3.ToString());
            DialogueController.dc.initDialogue(this.doc.lines, str + num3.ToString(), PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color, this.textField, Npc2Controller.color);
            ++i4;
          }
        }
        else
        {
          this.takeDoc(i4);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "npc2_ginger_dead_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/ginger");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_npc2_ginger_dead");
          DialogueController.dc.initDialogue(this.doc.lines, "npc2_ginger_dead", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color, this.textField, Npc2Controller.color);
          ++i4;
        }
        if (GameDataController.gd.getObjective("gasstation_sarge_intro") && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getCurrentDay() == 3)
        {
          this.takeDoc(i4);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dialogue_sarge_thugs_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/sarge");
          this.doc.lines = new List<DialogueLine>();
          if (GameDataController.gd.getObjective("gasstation_sarge_shot"))
          {
            this.doc.setObjective("dialogue_sarge_thugs4_barry");
            DialogueController.dc.initDialogue(this.doc.lines, "dialogue_sarge_thugs4_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc2Controller.color);
          }
          else if (GameDataController.gd.getObjective("gasstation_sarge_convinced"))
          {
            if (GameDataController.gd.getObjective("previous_disc_barry"))
            {
              this.doc.setObjective("dialogue_sarge_thugs3_barry");
              DialogueController.dc.initDialogue(this.doc.lines, "dialogue_sarge_thugs3_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc2Controller.color);
            }
            else
            {
              this.doc.setObjective("dialogue_sarge_thugs2_barry");
              DialogueController.dc.initDialogue(this.doc.lines, "dialogue_sarge_thugs2_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc2Controller.color);
            }
          }
          else
          {
            this.doc.setObjective("dialogue_sarge_thugs1_barry");
            DialogueController.dc.initDialogue(this.doc.lines, "dialogue_sarge_thugs1_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc2Controller.color);
          }
          ++i4;
        }
        if (GameDataController.gd.getObjective("restaurant_sarge_encountered") && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && GameDataController.gd.getCurrentDay() == 3)
        {
          this.takeDoc(i4);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dialogue_sarge_storm_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/sarge");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_sarge_storm1_barry");
          DialogueController.dc.initDialogue(this.doc.lines, "dialogue_sarge_storm1_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc2Controller.color);
          ++i4;
        }
        if (!GameDataController.gd.getObjective("thug_to_kill_bathroom") && GameDataController.gd.getObjective("thug_killed_bathroom") && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getCurrentDay() == 4)
        {
          this.takeDoc(i4);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dialogue_razor_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/razor");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("d4_kill_razor_barry");
          DialogueController.dc.initDialogue(this.doc.lines, "d4_kill_razor0_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc2Controller.color);
          if (GameDataController.gd.getObjective("gasstation_sarge_shot") && GameDataController.gd.getObjective("cs_thug_shot"))
            DialogueController.dc.initDialogue(this.doc.lines, "d4_kill_razor3_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc2Controller.color);
          else if (GameDataController.gd.getObjective("gasstation_sarge_shot"))
            DialogueController.dc.initDialogue(this.doc.lines, "d4_kill_razor2_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc2Controller.color);
          else if (GameDataController.gd.getObjective("cs_thug_shot"))
            DialogueController.dc.initDialogue(this.doc.lines, "d4_kill_razor1_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc2Controller.color);
          if (GameDataController.gd.getObjective("gasstation_sarge_shot") || GameDataController.gd.getObjective("cs_thug_shot"))
            DialogueController.dc.initDialogue(this.doc.lines, "d4_kill_razor4_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc2Controller.color);
          else
            DialogueController.dc.initDialogue(this.doc.lines, "d4_kill_razor5_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc2Controller.color);
          ++i4;
        }
        if (!GameDataController.gd.getObjective("thug_to_kill_bathroom") && !GameDataController.gd.getObjective("thug_killed_bathroom") && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getCurrentDay() == 4)
        {
          this.takeDoc(i4);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dialogue_razor_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/razor");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("d4_spare_razor_barry");
          DialogueController.dc.initDialogue(this.doc.lines, "d4_spare_razor0_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc2Controller.color);
          ++i4;
        }
      }
      if (GameDataController.gd.getObjective("npc2_wife_note_given") && !GameDataController.gd.getObjective("house_b_garage_open"))
      {
        this.takeDoc(i4);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "npc2_burial_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/burial");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_npc2_burial");
        DialogueController.dc.initDialogue(this.doc.lines, "npc2_burial", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component, color);
        ++i4;
        this.doc.lines[4].action = new TimelineFunction(this.gingerFacepalm);
        this.doc.lines[4].actionWithText = true;
        this.doc.lines[10].action = new TimelineFunction(this.openGarage);
        this.doc.lines[10].actionWithText = true;
      }
      if (GameDataController.gd.getObjective("house_b_grave_dug") && GameDataController.gd.getObjective("house_b_wife_moved") && !GameDataController.gd.getObjective("house_b_grave_filled"))
      {
        this.takeDoc(i4);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "npc2_burial2_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/burial");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_npc2_burial2");
        DialogueController.dc.initDialogue(this.doc.lines, "npc2_burial2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component, color);
        ++i4;
        this.doc.lines[2].action = new TimelineFunction(this.goToGrave);
      }
      if (SceneManager.GetActiveScene().name == "LocationRestaurant2" && !GameDataController.gd.getObjective("restaurant_trash_moved") && GameDataController.gd.getObjective("restaurant_trash_tried") && (!GameDataController.gd.getObjective("npc3_alive") || GameDataController.gd.getObjective("dialogue_cody_intro")))
      {
        this.takeDoc(i4);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "npc2_push_trash_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/push_trash");
        this.doc.lines = new List<DialogueLine>();
        DialogueController.dc.initDialogue(this.doc.lines, "npc2_push_trash", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color);
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.pushTrashCart);
        ++i4;
      }
      if (SceneManager.GetActiveScene().name == "SiderealF1C" && !GameDataController.gd.getObjective("sidereal_barry_pipe_moved") && GameDataController.gd.getObjective("sidereal_pipe_tried"))
      {
        this.takeDoc(i4);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "npc2_push_pipe_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/pipe");
        this.doc.lines = new List<DialogueLine>();
        DialogueController.dc.initDialogue(this.doc.lines, "npc2_push_pipe", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color);
        this.doc.lines[this.doc.lines.Count - 3].action = new TimelineFunction(this.pushPipe);
        ++i4;
      }
      if (GameDataController.gd.getObjective("moon_pods_unlocked") && SceneManager.GetActiveScene().name == "LocationMoonbase3")
      {
        this.takeDoc(i4);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "barry_sleep_david_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/pod_barry");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("moon_barry_sleeps");
        DialogueController.dc.initDialogue(this.doc.lines, "barry_sleep_david", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color);
        this.doc.lines[this.doc.lines.Count - 3].action = new TimelineFunction(this.goToSleep1);
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.goToSleep2);
        ++i4;
      }
      if (!GameDataController.gd.getObjective("cody_warned") && GameDataController.gd.getObjective("dream_maggie_future") && GameDataController.gd.getCurrentDay() == 3 && !GameDataController.gd.getObjective("sidereal_roof_collapsed"))
      {
        this.takeDoc(i4);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "barry_warn_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/where_go");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("barry_warned");
        DialogueController.dc.initDialogue(this.doc.lines, "barry_warn", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color);
        if (GameDataController.gd.getObjective("visited_sidereal_outside_1") && GameDataController.gd.getObjectiveDetail("car_location") == 8)
        {
          this.doc.lines[2].text = GameStrings.getString(GameStrings.dialogues, "barry_warn_variant1b");
          this.doc.lines[10].text = GameStrings.getString(GameStrings.dialogues, "barry_warn_variant2b");
        }
        if (GameDataController.gd.getObjective("visited_sidereal_outside_1") && GameDataController.gd.getObjectiveDetail("car_location") != 8)
        {
          this.doc.lines[2].text = GameStrings.getString(GameStrings.dialogues, "barry_warn_variant1a");
          this.doc.lines[10].text = GameStrings.getString(GameStrings.dialogues, "barry_warn_variant2a");
        }
        if (SceneManager.GetActiveScene().name.ToLower().IndexOf("sidereal") != -1)
          this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.goAndWait);
        ++i4;
      }
      if (GameDataController.gd.getCurrentDay() <= 4 && !GameDataController.gd.getObjective("barry_improved_car") && GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("car_driven"))
      {
        if (!GameDataController.gd.getObjective("barn_car_wheel_repaired") || !GameDataController.gd.getObjective("barn_car_coil_repaired"))
        {
          this.takeDoc(i4);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "barry_car0_1_a");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/car");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_barry_car0");
          DialogueController.dc.initDialogue(this.doc.lines, "barry_car0", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc2Controller.color);
          ++i4;
        }
        else if ((SceneManager.GetActiveScene().name == "LocationHouseB" || SceneManager.GetActiveScene().name == "LocationHouseBBack" || SceneManager.GetActiveScene().name == "LocationHouseBInside") && GameDataController.gd.getObjectiveDetail("car_location") == 3)
        {
          this.takeDoc(i4);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "barry_car2_1_a");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/car");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_barry_car2");
          DialogueController.dc.initDialogue(this.doc.lines, "barry_car2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc2Controller.color);
          this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.upgradeCarQuestion);
          this.doc.lines[this.doc.lines.Count - 1].actionWithText = false;
          ++i4;
        }
        else
        {
          this.takeDoc(i4);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "barry_car1_1_a");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/car");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_barry_car1");
          DialogueController.dc.initDialogue(this.doc.lines, "barry_car1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc2Controller.color);
          ++i4;
        }
      }
      if (GameDataController.gd.getObjective("dream_maggie_future"))
      {
        this.takeDoc(i4);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "barry_wife_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/barry_wife");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_barry_wife");
        DialogueController.dc.initDialogue(this.doc.lines, "barry_wife", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color);
        ++i4;
      }
      this.takeDoc(i4);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "exit_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective(string.Empty);
      DialogueController.dc.initDialogue(this.doc.lines, "npc2_exit", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color, component, color);
      this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
      num1 = i4 + 1;
      this.takeDoc(0);
      if (this.doc.caption != string.Empty)
        DialogueController.dc.talking = true;
      this.updateState();
    }
  }

  public void goAndWait(string param = "")
  {
    if (SceneManager.GetActiveScene().name == "LocationSiderealRoof")
    {
      GameObject.Find("Npc2").GetComponent<NPCWalkController>().speed = GameObject.Find("Npc2").GetComponent<NPCWalkController>().MAX_SPEED * 2f;
      GameDataController.gd.setObjective("npc2_joined", false);
      this.gameObject.GetComponent<NPCWalkController>().forceAnimation("walk_e", true);
      this.Invoke("stopWalking", 3f);
    }
    GameObject.Find("Npc2").GetComponent<NPCWalkController>().setSimpleTargetV3(GameObject.Find("BarryGoAway").transform.position);
    this.endTalk(string.Empty);
  }

  public void stopWalking() => this.gameObject.GetComponent<NPCWalkController>().forceAnimation("stand_se", true);

  public override void clickAction2()
  {
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("npc2_joined"))
    {
      if (SceneManager.GetActiveScene().name == "LocationSiderealRoof" && GameDataController.gd.getObjective("npc2_alive"))
        return;
      this.gameObject.GetComponent<NPCWalkController>().forceAnimation("npc2_mourn", true);
      this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.1161384f, 0.172491f);
      this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-0.01313657f, -0.11f);
    }
    else
    {
      this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.1161384f, 0.3449821f);
      this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-0.01313657f, -0.04973114f);
    }
    if (!GameDataController.gd.getObjective("dialogue_npc2_intro"))
      this.objectName = "npc_mourning";
    else
      this.objectName = "npc_barry";
    if (GameDataController.gd.getObjective("sidereal_roof_wait_for_rescue"))
      this.actionType = ObjectActionController.Type.NormalAction;
    else
      this.actionType = ObjectActionController.Type.Talk;
    if (GameDataController.gd.getObjective("dialogue_ginger_barry_distracted"))
    {
      this.range = 100f;
      this.rotateToSpeaker = false;
    }
    else if (GameDataController.gd.getObjective("npc2_joined"))
    {
      this.range = 25f;
      this.rotateToSpeaker = true;
    }
    else
    {
      this.range = 1f;
      this.rotateToSpeaker = false;
    }
  }

  public override void clickAction0()
  {
  }

  public void upgradeCarQuestion(string val = "")
  {
    DialogueController.dc.talking = false;
    QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "barry_upgrade_car"), yesClick: new Button.Delegate(this.upgradeCar), time: 80);
  }

  public void upgradeCar()
  {
    GameDataController.gd.setObjective("barry_improved_car", true);
    PlayerController.pc.setBusy(true);
    PlayerController.wc.forceAnimation("stop");
    PlayerController.pc.spawnName = "WaypointHouseB0";
    CurtainController.cc.fadeOut("LocationHouseB", actionAfterFade: new CurtainController.Delegate(this.sayUpgraded));
  }

  public void sayUpgraded()
  {
    this.instantLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.instantLines, "barry_car_upgraded", GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.color);
    for (int index = 0; index < this.instantLines.Count; ++index)
      Timeline.t.addDialogue(this.instantLines[index]);
  }

  public void pushPipe(string val = "")
  {
    DialogueController.dc.talking = false;
    Timeline.t.doNotUnlock = true;
    this.gameObject.GetComponent<NPCWalkController>().setBusy(false);
    PlayerController.pc.setBusy(true);
    Object.FindObjectOfType<LocationSiderealF1C_Waypoint_S>().pushLittleCart();
    this.Invoke("pushTrashCartSound", 0.2f);
  }

  public void pushTrashCart(string val = "")
  {
    DialogueController.dc.talking = false;
    Timeline.t.doNotUnlock = true;
    this.gameObject.GetComponent<NPCWalkController>().setBusy(false);
    PlayerController.pc.setBusy(true);
    Object.FindObjectOfType<Restaurant2Trash>().pushLittleCart_Barry();
    this.Invoke("pushTrashCart2", 0.75f);
    this.Invoke("pushTrashCartSound", 0.5f);
    this.Invoke("pushTrashCartSound", 0.75f);
    this.Invoke("pushTrashCartSound", 1.25f);
  }

  public void pushTrashCart2()
  {
    this.gameObject.GetComponent<NPCWalkController>().currentXY = new Vector2(55f, 60f);
    this.gameObject.GetComponent<NPCWalkController>().setSimpleTarget(this.gameObject.GetComponent<NPCWalkController>().currentXY);
    GameObject.Find("Player").GetComponent<WalkController>().currentXY = new Vector2(105f, 50f);
    GameObject.Find("Player").GetComponent<WalkController>().setSimpleTarget(GameObject.Find("Player").GetComponent<WalkController>().currentXY);
  }

  public void pushTrashCartSound() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_creak1);

  public void goToGrave(string val = "")
  {
    GameDataController.gd.setObjective("house_b_grave_filled", true);
    PlayerController.pc.spawnName = "WaypointHouseBBackBody2";
    CurtainController.cc.fadeOut("LocationHouseBBack", WalkController.Direction.N, "stand_s");
    this.endTalk(string.Empty);
    Timeline.t.doNotUnlock = true;
  }

  public void endTalkRoof(string val = "")
  {
    GameDataController.gd.setObjective("sidereal_roof_npc_shocked", false);
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("barry_get_up");
    this.endTalk(string.Empty);
    GameObject.Find("Ginger").GetComponent<GingerActionController>().roofAfterFall();
  }

  public void endTalkShip(string val = "")
  {
    GameDataController.gd.setObjective("moon_shocked2", false);
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("barry_get_up");
    this.endTalk(string.Empty);
  }

  public void gingerFacepalm(string val = "") => GameObject.Find("Ginger").GetComponent<NPCWalkController>().forceAnimation("ginger_facepalm");

  public void lookUp(string val = "") => this.gameObject.GetComponent<NPCWalkController>().forceAnimation("npc2_mourn_look", true);

  public void openGarage(string val = "")
  {
    DialogueController.dc.talking = false;
    Timeline.t.doNotUnlock = true;
    PlayerController.pc.setBusy(true);
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("npc2_open_garage", true);
    this.Invoke("openGarage2", 3f);
  }

  public void openGarage2()
  {
    GameObject.Find("Gate").GetComponent<Animator>().Play("gate_1", 0);
    GameDataController.gd.setObjective("house_b_garage_open", true);
    this.Invoke("closeGarage", 3f);
  }

  public void closeGarage()
  {
    this.endTalk(string.Empty);
    PlayerController.pc.setBusy(false);
    this.instantLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.instantLines, "npc2_burialz", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc2Controller.color);
    Timeline.t.addDialogueLines(this.instantLines);
  }

  public void uratuj()
  {
    PlayerController.pc.setBusy(true);
    PlayerController.wc.forceAnimation("save_cody", true);
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("barry_climb");
    this.Invoke("naChama", 0.1f);
  }

  private void naChama() => PlayerController.wc.forceAnimation("save_cody", true);

  public void barrySaved()
  {
    this.gameObject.GetComponent<NPCWalkController>().currentXY = ScreenControler.screenToGame((Vector2) Camera.main.WorldToScreenPoint(GameObject.Find("BarrySitHere").transform.position));
    this.gameObject.GetComponent<NPCWalkController>().clearTarget();
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("barry_sit");
    Timeline.t.stopChitChat();
    JukeboxMusic.jb.changeMusic((AudioClip) null, minTime: 0.0f, maxTime: 0.0f, newStep: 0.01f);
    if (GameDataController.gd.getObjective("npc3_alive") && !GameDataController.gd.getObjective("cody_warned"))
    {
      GameObject.Find("Npc3").GetComponent<Npc3Controller>().siderealFall();
      GameDataController.gd.setObjective("npc3_alive", false);
      GameDataController.gd.setObjectiveDetail("npc3_alive", 1);
      this.Invoke("barrySaved2", 0.5f);
    }
    else
      PlayerController.pc.setBusy(false);
    GameDataController.gd.setObjective("sidereal_roof_wait_for_rescue", false);
    GameDataController.gd.setObjective("sidereal_roof_npc_shocked", true);
  }

  public void barrySaved2() => GameObject.Find("fall_plane").GetComponent<LetterFall>().startTalkAfterfall();
}
