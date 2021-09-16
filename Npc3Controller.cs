// Decompiled with JetBrains decompiler
// Type: Npc3Controller
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Npc3Controller : NPCActionController
{
  private static Vector3 color = new Vector3(195f / 512f, 291f / 512f, 165f / 512f);

  public static Vector3 getColor() => Npc3Controller.color;

  public override void continueStart()
  {
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("foodcan", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("foodcanopen", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("water1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("water2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("water3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("water4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("food_bag", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("whiskey", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("deadbird", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ropehook", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rope", string.Empty, anim: string.Empty));
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
      this.interactions.Add(new ItemInteraction("revolver_6", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("revolver_5", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("revolver_4", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("revolver_3", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("revolver_2", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("revolver_1", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("revolver_0", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
    }
    this.interactions.Add(new ItemInteraction("pills", string.Empty, anim: string.Empty));
    if (!GameDataController.gd.getObjective("restaurant_door_opened"))
    {
      this.interactions.Add(new ItemInteraction("wrench", GameStrings.getString(GameStrings.actions, "cody_intro_threat"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("crowbar", GameStrings.getString(GameStrings.actions, "cody_intro_threat"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("pipe", GameStrings.getString(GameStrings.actions, "cody_intro_threat"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_6", GameStrings.getString(GameStrings.actions, "cody_intro_threat"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_5", GameStrings.getString(GameStrings.actions, "cody_intro_threat"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_4", GameStrings.getString(GameStrings.actions, "cody_intro_threat"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_3", GameStrings.getString(GameStrings.actions, "cody_intro_threat"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_2", GameStrings.getString(GameStrings.actions, "cody_intro_threat"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_1", GameStrings.getString(GameStrings.actions, "cody_intro_threat"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_0", GameStrings.getString(GameStrings.actions, "cody_intro_threat"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("hammer", GameStrings.getString(GameStrings.actions, "cody_intro_threat"), anim: string.Empty));
    }
    else if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
    {
      this.interactions.Add(new ItemInteraction("rifle_0", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_1", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_2", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_3", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_4", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_5", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_6", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_0", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_1", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_2", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_3", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_4", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_5", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_6", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_0", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_1", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_2", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_3", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_4", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_5", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_6", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_0", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_1", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_2", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_3", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_4", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_5", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_6", GameStrings.getString(GameStrings.actions, "cody_give_rifle"), anim: string.Empty));
    }
    else if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
    {
      this.interactions.Add(new ItemInteraction("rifle_0", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_1", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_2", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_3", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_4", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_5", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_6", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_0", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_1", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_2", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_3", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_4", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_5", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_6", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_0", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_1", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_2", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_3", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_4", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_5", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_6", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_0", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_1", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_2", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_3", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_4", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_5", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s0_6", GameStrings.getString(GameStrings.actions, "gun_cody_storm"), anim: string.Empty));
    }
    this.actionType = ObjectActionController.Type.Talk;
  }

  public void giveFoodCan(string val = "")
  {
    GameDataController.gd.setObjective("dialogue_cody_food_closed_given", true);
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("can_shake", true);
  }

  public void giveBackFoodCan(string val = "") => GameDataController.gd.setObjective("dialogue_cody_food_closed_given", false);

  public void giveFoodCanOpen(string val = "") => this.gameObject.GetComponent<NPCWalkController>().forceAnimation("can_opened", true);

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
    else if (GameDataController.gd.getObjective("moon_shocked3"))
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker_sit").gameObject;
      this.range = 0.0f;
      this.rotateToSpeaker = false;
    }
    else if (GameDataController.gd.getObjective("sidereal_roof_npc_shocked"))
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker_sit").gameObject;
      this.range = 0.0f;
      this.rotateToSpeaker = false;
    }
    else if (GameDataController.gd.getObjective("restaurant_door_opened2"))
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.range = 25f;
      this.rotateToSpeaker = true;
    }
    else
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.range = 1000f;
      this.rotateToSpeaker = false;
    }
  }

  public override void whatOnClick()
  {
  }

  public void uratuj()
  {
    PlayerController.pc.setBusy(true);
    PlayerController.wc.forceAnimation("save_cody", true);
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("cody_climb");
    this.Invoke("naChama", 0.1f);
  }

  private void naChama() => PlayerController.wc.forceAnimation("save_cody", true);

  public void codySaved()
  {
    if (!GameDataController.gd.getObjective("sidereal_roof_wait_for_rescue"))
      return;
    Timeline.t.stopChitChat();
    this.gameObject.GetComponent<NPCWalkController>().currentXY = ScreenControler.screenToGame((Vector2) Camera.main.WorldToScreenPoint(GameObject.Find("CodySitHere").transform.position));
    this.gameObject.GetComponent<NPCWalkController>().clearTarget();
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("cody_sit");
    JukeboxMusic.jb.changeMusic((AudioClip) null, minTime: 0.0f, maxTime: 0.0f, newStep: 0.01f);
    if (GameDataController.gd.getObjective("npc2_alive") && !GameDataController.gd.getObjective("barry_warned"))
    {
      GameObject.Find("Npc2").GetComponent<Npc2Controller>().siderealFall();
      GameDataController.gd.setObjective("npc2_alive", false);
      GameDataController.gd.setObjectiveDetail("npc2_alive", 1);
      this.Invoke("codySaved2", 0.5f);
    }
    else
      PlayerController.pc.setBusy(false);
    GameDataController.gd.setObjective("sidereal_roof_wait_for_rescue", false);
    GameDataController.gd.setObjective("sidereal_roof_npc_shocked", true);
  }

  public void codySaved2() => GameObject.Find("fall_plane").GetComponent<LetterFall>().startTalkAfterfall();

  public void siderealFall()
  {
    GameObject.Find("Npc3").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.dialogues, "fall_aah"), mwidth: 100, r: Npc3Controller.getColor().x, g: Npc3Controller.getColor().y, b: Npc3Controller.getColor().z, mute: true);
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("cody_fall");
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

  public void endTalkRoof(string val = "")
  {
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("cody_get_up");
    this.endTalk(string.Empty);
    GameDataController.gd.setObjective("sidereal_roof_npc_shocked", false);
    GameObject.Find("Ginger").GetComponent<GingerActionController>().roofAfterFall();
  }

  public void endTalkShip(string val = "")
  {
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("cody_get_up");
    this.endTalk(string.Empty);
    GameDataController.gd.setObjective("moon_shocked3", false);
  }

  public void playerStandUp(string v = "")
  {
    Timeline.t.doNotUnlock = true;
    PlayerController.pc.forceAnimation("kneel_out_n");
  }

  public override void npcClickAction(string item = "")
  {
    Vector3 color = GingerActionController.getColor();
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    Npc2Controller.getColor();
    GameObject.Find("Npc2").GetComponent<TextFieldController>();
    this.instantLines = new List<DialogueLine>();
    if (GameDataController.gd.getObjective("sidereal_roof_wait_for_rescue"))
    {
      if (GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjectiveDetail("npc2_alive") != 1 && !GameDataController.gd.getObjective("barry_warned"))
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "save_cody"), yesClick: new Button.Delegate(this.uratuj));
      else
        this.uratuj();
    }
    else
    {
      if (GameDataController.gd.getObjective("sidereal_roof_npc_shocked"))
      {
        PlayerController.pc.forceAnimation("kneel_in_n");
        if (!GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjectiveDetail("npc2_alive") == 1 && !GameDataController.gd.getObjective("barry_warned"))
        {
          DialogueController.dc.initDialogue(this.instantLines, "sidereal_afterfall_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(this.playerStandUp);
        }
        else
        {
          DialogueController.dc.initDialogue(this.instantLines, "sidereal_nofall_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(this.endTalkRoof);
          this.instantLines[this.instantLines.Count - 2].action = new TimelineFunction(this.playerStandUp);
          for (int index = 0; index < this.instantLines.Count; ++index)
            Timeline.t.addDialogue(this.instantLines[index]);
          return;
        }
      }
      else
      {
        if (GameDataController.gd.getObjective("moon_shocked3"))
        {
          PlayerController.pc.forceAnimation("kneel_in_n");
          DialogueController.dc.initDialogue(this.instantLines, "moon_shocked_cody1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
          GameDataController.gd.setObjective("moon_shocked3", false);
          if (GameDataController.gd.getObjective("npc1_alive") && !GameDataController.gd.getObjective("moon_shocked1") && (!GameDataController.gd.getObjective("npc2_alive") || !GameDataController.gd.getObjective("moon_shocked2")) && (!GameDataController.gd.getObjective("npc3_alive") || !GameDataController.gd.getObjective("moon_shocked3")) && GameDataController.gd.getObjective("npc1_alive"))
            this.instantLines.Add(new DialogueLine(component, color, GameStrings.getString(GameStrings.dialogues, "moon_shocked_cate_ending"), (TimelineFunction) null));
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(this.endTalkShip);
          this.instantLines[this.instantLines.Count - 2].action = new TimelineFunction(this.playerStandUp);
          for (int index = 0; index < this.instantLines.Count; ++index)
            Timeline.t.addDialogue(this.instantLines[index]);
          if (GameDataController.gd.getObjective("npc1_alive") || GameDataController.gd.getObjective("moon_shocked1"))
            return;
          this.instantLines = new List<DialogueLine>();
          DialogueController.dc.initDialogue(this.instantLines, "moon_shocked_cody2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
          for (int index = 0; index < this.instantLines.Count; ++index)
            Timeline.t.addDialogue(this.instantLines[index]);
          return;
        }
        if (item == "foodcan")
        {
          DialogueController.dc.initDialogue(this.instantLines, "cody_food_locked", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
          this.instantLines[2].action = new TimelineFunction(this.giveFoodCan);
          this.instantLines[2].actionWithText = true;
          this.instantLines[this.instantLines.Count - 2].action = new TimelineFunction(this.giveBackFoodCan);
          this.instantLines[this.instantLines.Count - 2].actionWithText = true;
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
          this.instantLines[this.instantLines.Count - 1].actionWithText = true;
        }
        else if (item == "foodcanopen")
        {
          DialogueController.dc.initDialogue(this.instantLines, "cody_food", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
          GameDataController.gd.setObjective("npc3_joined", true);
          InventoryController.ic.removeItem("foodcanopen");
          GameDataController.gd.setObjectiveDetail("chitchat", -50);
          this.instantLines[1].action = new TimelineFunction(this.startTalkRestaurant);
          this.instantLines[2].action = new TimelineFunction(this.giveFoodCanOpen);
          this.instantLines[2].actionWithText = true;
          if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive"))
          {
            DialogueController.dc.initDialogue(this.instantLines, "barry_cody_first_meet", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor(), this.textField, Npc3Controller.color);
            this.instantLines[this.instantLines.Count - 2].action = new TimelineFunction(this.endTalkRestaurant2);
          }
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
          this.instantLines[this.instantLines.Count - 1].actionWithText = true;
        }
        else if (!GameDataController.gd.getObjective("dialogue_cody_intro"))
        {
          DialogueController.dc.initDialogue(this.instantLines, "cody_intro1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
          this.instantLines[0].actionWithText = true;
          GameDataController.gd.setObjective("dialogue_cody_intro", true);
          if (GameDataController.gd.getObjective("npc2_joined"))
            this.instantLines.Add(new DialogueLine(PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameStrings.getString(GameStrings.dialogues, "cody_intro1_6_extra_a"), (TimelineFunction) null));
          if (GameDataController.gd.getObjective("previous_disc_barry") || GameDataController.gd.getObjective("previous_disc_cody"))
            DialogueController.dc.initDialogue(this.instantLines, "cody_intro2b", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
          else
            DialogueController.dc.initDialogue(this.instantLines, "cody_intro2a", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
        }
        else if (!GameDataController.gd.getObjective("npc3_joined"))
        {
          if (!GameDataController.gd.getObjective("dialogue_cody_door_opened") && GameDataController.gd.getObjective("restaurant_door_opened2"))
          {
            DialogueController.dc.initDialogue(this.instantLines, "cody_door_opened_intro", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
            this.instantLines[0].actionWithText = true;
          }
          else if (GameDataController.gd.getObjective("dialogue_cody_door_opened") && GameDataController.gd.getObjective("restaurant_door_opened2"))
          {
            if (item == "water1" || item == "water2" || item == "water3" || item == "water4")
            {
              string key = "cody_water_not_joined";
              PlayerController.pc.say(GameStrings.getString(GameStrings.actions, key));
              return;
            }
            if (item == "coat1" || item == "coat2" || item == "coat3" || item == "coat4")
            {
              string key = "cody_coat_not_joined";
              PlayerController.pc.say(GameStrings.getString(GameStrings.actions, key));
              return;
            }
            DialogueController.dc.initDialogue(this.instantLines, "cody_intro2c", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
            this.instantLines[0].actionWithText = true;
          }
          else
          {
            if (item == "water1" || item == "water2" || item == "water3" || item == "water4")
            {
              string key = "cody_water_coat_unknown";
              if (GameDataController.gd.getObjective("dialogue_cody_door_closed") || GameDataController.gd.getObjective("dialogue_cody_come"))
                key = "cody_water_not_joined";
              PlayerController.pc.say(GameStrings.getString(GameStrings.actions, key));
              return;
            }
            if (item == "coat1" || item == "coat2" || item == "coat3" || item == "coat4")
            {
              string key = "cody_water_coat_unknown";
              if (GameDataController.gd.getObjective("dialogue_cody_door_closed") || GameDataController.gd.getObjective("dialogue_cody_come"))
                key = "cody_coat_not_joined";
              PlayerController.pc.say(GameStrings.getString(GameStrings.actions, key));
              return;
            }
            DialogueController.dc.initDialogue(this.instantLines, "cody_intro2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
            this.instantLines[0].actionWithText = true;
          }
        }
        else if (item == "coat1" || item == "coat2" || item == "coat3" || item == "coat4")
        {
          if (ItemsManager.im.getItem("coat1").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("coat2").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("coat3").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("coat4").dataRef.droppedLocation == "npc3")
          {
            DialogueController.dc.initDialogue(this.instantLines, "cody_already_coat", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
            this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
          }
          else if (GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
          {
            DialogueController.dc.initDialogue(this.instantLines, "cody_give_coat", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
            if (!GingerActionController.isGingerHere())
            {
              this.instantLines.RemoveAt(6);
              this.instantLines.RemoveAt(5);
              this.instantLines.RemoveAt(4);
            }
            this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
            InventoryController.ic.removeItem(item);
            ItemsManager.im.getItem(item).dataRef.droppedLocation = "npc3";
            JournalTexts.pickTexts(GameDataController.gd.getCurrentDay());
          }
          else if (GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
          {
            DialogueController.dc.initDialogue(this.instantLines, "cody_bad_coat", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
            this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
          }
          else
          {
            DialogueController.dc.initDialogue(this.instantLines, "cody_bad2_coat", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
            this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
          }
        }
        else if (item == "water1" || item == "water2" || item == "water3" || item == "water4")
        {
          if (ItemsManager.im.getItem("water1").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("water2").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("water3").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("water4").dataRef.droppedLocation == "npc3")
          {
            DialogueController.dc.initDialogue(this.instantLines, "cody_already_water", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
            this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
          }
          else if (GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
          {
            DialogueController.dc.initDialogue(this.instantLines, "cody_give_water", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
            if (!GingerActionController.isGingerHere())
            {
              this.instantLines.RemoveAt(6);
              this.instantLines.RemoveAt(5);
              this.instantLines.RemoveAt(4);
            }
            this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
            InventoryController.ic.removeItem(item);
            ItemsManager.im.getItem(item).dataRef.droppedLocation = "npc3";
            JournalTexts.pickTexts(GameDataController.gd.getCurrentDay());
          }
          else if (GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
          {
            DialogueController.dc.initDialogue(this.instantLines, "cody_bad_water", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
            this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
          }
          else
          {
            DialogueController.dc.initDialogue(this.instantLines, "cody_bad2_water", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
            this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
          }
        }
        else if (this.usedItem == "pills")
        {
          string prefix = "cody_give_pills";
          if (GameDataController.gd.getObjective("cody_pills_taken"))
            prefix = "cody_gave_pills";
          GameDataController.gd.setObjective("cody_pills_taken", true);
          DialogueController.dc.initDialogue(this.instantLines, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color);
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
        }
        else if (item.IndexOf("revolver") != -1)
        {
          if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
          {
            DialogueController.dc.initDialogue(this.instantLines, "npc3_give_gun", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
            this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(this.revolverQuestion);
          }
        }
        else if (item == "food_bag")
        {
          DialogueController.dc.initDialogue(this.instantLines, "cody_bag_of_food", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor(), this.textField, Npc3Controller.color);
          InventoryController.ic.removeItem(item);
          ItemsManager.im.getItem(item).dataRef.droppedLocation = "npc3";
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
        }
        else if (item == "deadbird")
        {
          DialogueController.dc.initDialogue(this.instantLines, "dead_bird_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color, this.textField, Npc3Controller.color);
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
        }
        else if (item == "whiskey")
        {
          DialogueController.dc.initDialogue(this.instantLines, "whiskey_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color, this.textField, Npc3Controller.color);
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
        }
        else if (item == "rope" || item == "ropehook")
        {
          DialogueController.dc.initDialogue(this.instantLines, "rope_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color, this.textField, Npc3Controller.color);
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
        }
        else
          DialogueController.dc.initDialogue(this.instantLines, "cody_intro3", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
      }
      if (!GameDataController.gd.getObjective("npc3_joined") && !GameDataController.gd.getObjective("restaurant_door_opened2"))
        this.instantLines[0].action = new TimelineFunction(this.fightStance);
      for (int index = 0; index < this.instantLines.Count; ++index)
        Timeline.t.addDialogue(this.instantLines[index]);
      DialogueController.dc.callback = new DialogueController.Callback(this.dialogues);
      this.dialogues();
    }
  }

  public void revolverQuestion(string s = "")
  {
    this.endTalk(string.Empty);
    QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "cody_gun"), yesClick: new Button.Delegate(this.revolverTeach), time: 60);
  }

  public void revolverTeach()
  {
    string name = string.Empty;
    if (InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("revolver_6"))
      name = "revolver_6";
    if (InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("revolver_5"))
      name = "revolver_5";
    if (InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("revolver_4"))
      name = "revolver_4";
    if (InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("revolver_3"))
      name = "revolver_3";
    if (InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("revolver_2"))
      name = "revolver_2";
    if (InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("revolver_1"))
      name = "revolver_1";
    InventoryController.ic.removeItem(name);
    ItemsManager.im.getItem(name).dataRef.droppedLocation = "npc3";
    PlayerController.pc.setBusy(true);
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.S, actionAfterFade: new CurtainController.Delegate(this.revolverDone));
  }

  public void revolverDone()
  {
    Vector3 color = GingerActionController.getColor();
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    this.instantLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.instantLines, "npc3_gave_gun", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
    for (int index = 0; index < this.instantLines.Count; ++index)
      Timeline.t.addDialogue(this.instantLines[index]);
  }

  public void goToSleep1(string a = "") => this.gameObject.GetComponent<NPCWalkController>().setSimpleTargetV3(GameObject.Find("CodyWalkHere").transform.position);

  public void goToSleep2(string a = "")
  {
    PlayerController.pc.setBusy(true);
    PlayerController.pc.spawnName = "cody_pod";
    DialogueController.dc.talking = false;
    Timeline.t.doNotUnlock = true;
    CurtainController.cc.fadeOut("LocationMoonbase3", WalkController.Direction.NW, "stand_ne", flipX: true, actionAfterFade: new CurtainController.Delegate(this.goToSleep3));
  }

  public void goToSleep3()
  {
    TextFieldController component = GameObject.Find("Moonbase3Pad3").transform.Find("TextField").GetComponent<TextFieldController>();
    if (GameDataController.gd.getObjective("npc1_alive") && !GameDataController.gd.getObjective("moon_cate_sleeps"))
    {
      component.transform.position = ScreenControler.roundToNearestFullPixel3(component.transform.position);
      this.instantLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(this.instantLines, "cody_sleep_cate", component, Npc3Controller.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
      for (int index = 0; index < this.instantLines.Count; ++index)
        Timeline.t.addDialogue(this.instantLines[index]);
    }
    if (GameDataController.gd.getObjective("npc2_alive") && !GameDataController.gd.getObjective("moon_barry_sleeps"))
    {
      this.instantLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(this.instantLines, "cody_sleep_barry", component, Npc3Controller.color, GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor());
      for (int index = 0; index < this.instantLines.Count; ++index)
        Timeline.t.addDialogue(this.instantLines[index]);
    }
    this.instantLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.instantLines, "cody_sleep_2david", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, Npc3Controller.color);
    this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(this.closePod);
    for (int index = 0; index < this.instantLines.Count; ++index)
      Timeline.t.addDialogue(this.instantLines[index]);
  }

  public void closePod(string s = "")
  {
    GameObject.Find("Moonbase3Pad3").GetComponent<Animator>().Play("moon_pod3_close");
    GameDataController.gd.setObjectiveDetail("moon_cody_sleeps", 1);
    if (GameDataController.gd.getObjective("npc2_alive") && !GameDataController.gd.getObjective("moon_barry_sleeps"))
      GameObject.Find("Npc2").GetComponent<Npc2Controller>().pod_rotate();
    if (!GameDataController.gd.getObjective("npc1_alive") || GameDataController.gd.getObjective("moon_cate_sleeps"))
      return;
    GameObject.Find("Ginger").GetComponent<GingerActionController>().pod_rotate();
  }

  public void pod_rotate() => this.Invoke("pod_rotate2", Random.Range(0.5f, 2f));

  public void pod_rotate2()
  {
    this.GetComponent<NPCWalkController>().playIdleAnimation("cody_stand_se");
    this.GetComponent<NPCWalkController>().setBusy(false);
  }

  public void dialogues()
  {
    string empty = string.Empty;
    DialogueController.dc.reset();
    Vector3 color = GingerActionController.getColor();
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    int i1 = 0;
    if (!GameDataController.gd.getObjective("npc3_joined") && !GameDataController.gd.getObjective("restaurant_door_opened2"))
    {
      this.takeDoc(i1);
      string prefix = "cody_orwhat";
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, prefix + "_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/orwhat");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dialogue_" + prefix);
      DialogueController.dc.initDialogue(this.doc.lines, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
      ++i1;
    }
    int num1;
    if (GameDataController.gd.getObjective("sidereal_roof_npc_shocked") && !GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjectiveDetail("npc2_alive") == 1)
    {
      this.takeDoc(i1);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sidereal_afterfall_cody_ans1_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/barry");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective(string.Empty);
      DialogueController.dc.initDialogue(this.doc.lines, "sidereal_afterfall_cody_ans1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
      this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalkRoof);
      int i2 = i1 + 1;
      this.takeDoc(i2);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sidereal_afterfall_cody_ans2_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/barry");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective(string.Empty);
      DialogueController.dc.initDialogue(this.doc.lines, "sidereal_afterfall_cody_ans2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
      this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalkRoof);
      int i3 = i2 + 1;
      this.takeDoc(i3);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sidereal_afterfall_cody_ans3_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/barry");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective(string.Empty);
      DialogueController.dc.initDialogue(this.doc.lines, "sidereal_afterfall_cody_ans3", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
      this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalkRoof);
      num1 = i3 + 1;
      this.takeDoc(0);
      if (this.doc.caption != string.Empty)
        DialogueController.dc.talking = true;
      this.updateState();
    }
    else
    {
      if ((GameDataController.gd.getObjective("npc3_joined") || !GameDataController.gd.getObjective("restaurant_door_opened2") || GameDataController.gd.getObjective("dialogue_cody_door_opened")) && GingerActionController.isGingerHere())
      {
        this.takeDoc(i1);
        string prefix = "cody_parents";
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, prefix + "_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/parents2");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_" + prefix);
        DialogueController.dc.initDialogue(this.doc.lines, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
        ++i1;
      }
      if (!GameDataController.gd.getObjective("npc3_joined") && (!GameDataController.gd.getObjective("restaurant_door_opened2") || GameDataController.gd.getObjective("dialogue_cody_door_opened")))
      {
        if (!GameDataController.gd.getObjective("restaurant_door_opened2"))
        {
          this.takeDoc(i1);
          string prefix = "cody_door_closed";
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, prefix + "_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/door1");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_" + prefix);
          DialogueController.dc.initDialogue(this.doc.lines, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
          ++i1;
        }
        if (!GameDataController.gd.getObjective("restaurant_door_opened2") || GameDataController.gd.getObjective("dialogue_cody_door_opened"))
        {
          this.takeDoc(i1);
          string prefix = "cody_come";
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, prefix + "_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/cody");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_" + prefix);
          DialogueController.dc.initDialogue(this.doc.lines, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
          ++i1;
        }
      }
      if (GameDataController.gd.getObjective("npc3_joined"))
      {
        i1 = this.dayDialogue(this.locationDialogue(i1, Npc3Controller.color, "cody"), Npc3Controller.color, "cody");
        if (GingerActionController.isGingerHere())
        {
          this.takeDoc(i1);
          string prefix1 = "cody_age";
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, prefix1 + "_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/age");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_" + prefix1);
          DialogueController.dc.initDialogue(this.doc.lines, prefix1, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
          ++i1;
          if (GameDataController.gd.getCurrentDay() < 5)
          {
            this.takeDoc(i1);
            string prefix2 = "cody_moon";
            this.doc.caption = GameStrings.getString(GameStrings.dialogues, prefix2 + "_caption");
            this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/moon");
            this.doc.lines = new List<DialogueLine>();
            this.doc.setObjective("dialogue_" + prefix2);
            DialogueController.dc.initDialogue(this.doc.lines, prefix2, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
            ++i1;
          }
        }
        if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getCurrentDay() < 5)
        {
          this.takeDoc(i1);
          string str = "cody_barry";
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, str + "_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/barry");
          this.doc.lines = new List<DialogueLine>();
          int num2 = 1;
          if (GameDataController.gd.getCurrentDay() == 2)
            num2 = 1;
          if (GameDataController.gd.getCurrentDay() == 3)
            num2 = 2;
          if (GameDataController.gd.getCurrentDay() == 4)
            num2 = 3;
          this.doc.setObjective("dialogue_" + str + num2.ToString());
          DialogueController.dc.initDialogue(this.doc.lines, str + num2.ToString(), PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color, this.textField, Npc3Controller.color);
          ++i1;
        }
        else if (GameDataController.gd.getObjective("npc2_joined") && !GameDataController.gd.getObjective("npc2_alive") && (GameDataController.gd.getObjective("sidereal_npc_found") || GameDataController.gd.getObjectiveDetail("npc2_alive") != 1))
        {
          this.takeDoc(i1);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "cody_barry_dead_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/barry");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_cody_barry_dead");
          DialogueController.dc.initDialogue(this.doc.lines, "cody_barry_dead", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
          if (GameDataController.gd.getObjectiveDetail("npc2_alive") == 0)
            this.doc.lines[3].text = GameStrings.getString(GameStrings.dialogues, "cody_barry_dead_day2");
          if (GameDataController.gd.getObjectiveDetail("npc2_alive") == 1)
            this.doc.lines[3].text = GameStrings.getString(GameStrings.dialogues, "cody_barry_dead_sidereal");
          ++i1;
        }
        if (GameDataController.gd.getObjective("npc1_alive") && GameDataController.gd.getCurrentDay() < 5)
        {
          this.takeDoc(i1);
          string str = "npc3_ginger";
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
          DialogueController.dc.initDialogue(this.doc.lines, str + num3.ToString(), PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color, this.textField, Npc3Controller.color);
          ++i1;
        }
        else if (!GameDataController.gd.getObjective("npc1_alive"))
        {
          this.takeDoc(i1);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "npc3_ginger_dead_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/ginger");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_npc3_ginger_dead");
          DialogueController.dc.initDialogue(this.doc.lines, "npc3_ginger_dead", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color, this.textField, Npc3Controller.color);
          ++i1;
        }
        if (GameDataController.gd.getObjective("gasstation_sarge_intro") && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getCurrentDay() == 3)
        {
          this.takeDoc(i1);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dialogue_sarge_thugs_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/sarge");
          this.doc.lines = new List<DialogueLine>();
          if (GameDataController.gd.getObjective("gasstation_sarge_shot"))
          {
            this.doc.setObjective("dialogue_sarge_thugs4_cody");
            DialogueController.dc.initDialogue(this.doc.lines, "dialogue_sarge_thugs4_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc3Controller.color);
          }
          else if (GameDataController.gd.getObjective("gasstation_sarge_convinced"))
          {
            if (GameDataController.gd.getObjective("previous_disc_cody"))
            {
              this.doc.setObjective("dialogue_sarge_thugs3_cody");
              DialogueController.dc.initDialogue(this.doc.lines, "dialogue_sarge_thugs3_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc3Controller.color);
            }
            else
            {
              this.doc.setObjective("dialogue_sarge_thugs2_cody");
              DialogueController.dc.initDialogue(this.doc.lines, "dialogue_sarge_thugs2_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc3Controller.color);
            }
          }
          else
          {
            this.doc.setObjective("dialogue_sarge_thugs1_cody");
            DialogueController.dc.initDialogue(this.doc.lines, "dialogue_sarge_thugs1_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc3Controller.color);
          }
          ++i1;
        }
        if (GameDataController.gd.getObjective("restaurant_sarge_encountered") && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && GameDataController.gd.getCurrentDay() == 3)
        {
          this.takeDoc(i1);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dialogue_sarge_storm_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/sarge");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_sarge_storm1_cody");
          DialogueController.dc.initDialogue(this.doc.lines, "dialogue_sarge_storm1_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc3Controller.color);
          ++i1;
        }
        if (!GameDataController.gd.getObjective("thug_to_kill_bathroom") && GameDataController.gd.getObjective("thug_killed_bathroom") && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getCurrentDay() == 4)
        {
          this.takeDoc(i1);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dialogue_razor_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/razor");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("d4_kill_razor_cody");
          DialogueController.dc.initDialogue(this.doc.lines, "d4_kill_razor0_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc3Controller.color);
          if (GameDataController.gd.getObjective("gasstation_sarge_shot") && GameDataController.gd.getObjective("cs_thug_shot"))
            DialogueController.dc.initDialogue(this.doc.lines, "d4_kill_razor3_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc3Controller.color);
          else if (GameDataController.gd.getObjective("gasstation_sarge_shot"))
            DialogueController.dc.initDialogue(this.doc.lines, "d4_kill_razor2_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc3Controller.color);
          else if (GameDataController.gd.getObjective("cs_thug_shot"))
            DialogueController.dc.initDialogue(this.doc.lines, "d4_kill_razor1_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc3Controller.color);
          if (GameDataController.gd.getObjective("gasstation_sarge_shot") || GameDataController.gd.getObjective("cs_thug_shot"))
            DialogueController.dc.initDialogue(this.doc.lines, "d4_kill_razor4_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc3Controller.color);
          else
            DialogueController.dc.initDialogue(this.doc.lines, "d4_kill_razor5_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc3Controller.color);
          ++i1;
        }
        if (!GameDataController.gd.getObjective("thug_to_kill_bathroom") && !GameDataController.gd.getObjective("thug_killed_bathroom") && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getCurrentDay() == 4)
        {
          this.takeDoc(i1);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dialogue_razor_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/razor");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("d4_spare_razor_cody");
          DialogueController.dc.initDialogue(this.doc.lines, "d4_spare_razor0_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc3Controller.color);
          ++i1;
        }
        if (GameDataController.gd.getObjective("cody_killed_someone") && GameDataController.gd.getCurrentDay() == 4)
        {
          this.takeDoc(i1);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dialogue_cody_killed_bandit_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bloodbath");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_cody_killed_bandit");
          DialogueController.dc.initDialogue(this.doc.lines, "dialogue_cody_killed_bandit", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, Npc3Controller.color);
          ++i1;
        }
      }
      if (GameDataController.gd.getObjective("restaurant_door_opened2") && !GameDataController.gd.getObjective("dialogue_cody_door_opened"))
      {
        this.takeDoc(i1);
        string prefix3 = "cody_door_opened_owner";
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, prefix3 + "_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/restaurant_chief");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_cody_door_opened");
        DialogueController.dc.initDialogue(this.doc.lines, prefix3, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
        this.doc.lines.Add(new DialogueLine(this.textField, Npc3Controller.color, GameStrings.getString(GameStrings.dialogues, "cody_intro2c_1_b"), (TimelineFunction) null));
        this.doc.lines[this.doc.lines.Count - 2].action = new TimelineFunction(this.endTalkRestaurant);
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
        int i4 = i1 + 1;
        this.takeDoc(i4);
        string prefix4 = "cody_door_opened_magic";
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, prefix4 + "_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/restaurant_wizard");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_cody_door_opened");
        DialogueController.dc.initDialogue(this.doc.lines, prefix4, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
        this.doc.lines.Add(new DialogueLine(this.textField, Npc3Controller.color, GameStrings.getString(GameStrings.dialogues, "cody_intro2c_1_b"), (TimelineFunction) null));
        this.doc.lines[this.doc.lines.Count - 2].action = new TimelineFunction(this.endTalkRestaurant);
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
        int i5 = i4 + 1;
        this.takeDoc(i5);
        string prefix5 = "cody_door_opened_backdoor";
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, prefix5 + "_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/restaurant_thief");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_cody_door_opened");
        DialogueController.dc.initDialogue(this.doc.lines, prefix5, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
        this.doc.lines.Add(new DialogueLine(this.textField, Npc3Controller.color, GameStrings.getString(GameStrings.dialogues, "cody_intro2c_1_b"), (TimelineFunction) null));
        this.doc.lines[this.doc.lines.Count - 2].action = new TimelineFunction(this.endTalkRestaurant);
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
        int i6 = i5 + 1;
        this.takeDoc(i6);
        string prefix6 = "cody_door_opened_twin";
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, prefix6 + "_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/restaurant_twin");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_cody_door_opened");
        DialogueController.dc.initDialogue(this.doc.lines, prefix6, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
        this.doc.lines.Add(new DialogueLine(this.textField, Npc3Controller.color, GameStrings.getString(GameStrings.dialogues, "cody_intro2c_1_b"), (TimelineFunction) null));
        this.doc.lines[this.doc.lines.Count - 2].action = new TimelineFunction(this.endTalkRestaurant);
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
        i1 = i6 + 1;
      }
      if (SceneManager.GetActiveScene().name == "SiderealF1C" && !GameDataController.gd.getObjective("sidereal_f1c_b_open") && GameDataController.gd.getObjective("sidereal_vent_open"))
      {
        this.takeDoc(i1);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "npc3_go_vent_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/vents");
        this.doc.lines = new List<DialogueLine>();
        DialogueController.dc.initDialogue(this.doc.lines, "npc3_go_vent", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color);
        this.doc.lines[this.doc.lines.Count - 2].action = new TimelineFunction(this.goVent1);
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.goVent);
        ++i1;
      }
      if (GameDataController.gd.getObjective("moon_pods_unlocked") && SceneManager.GetActiveScene().name == "LocationMoonbase3")
      {
        this.takeDoc(i1);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "cody_sleep_david_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/pod_cody");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("moon_cody_sleeps");
        DialogueController.dc.initDialogue(this.doc.lines, "cody_sleep_david", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color);
        this.doc.lines[this.doc.lines.Count - 3].action = new TimelineFunction(this.goToSleep1);
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.goToSleep2);
        ++i1;
      }
      if (!GameDataController.gd.getObjective("barry_warned") && GameDataController.gd.getObjective("dream_tiger_future") && GameDataController.gd.getCurrentDay() == 3 && !GameDataController.gd.getObjective("sidereal_roof_collapsed"))
      {
        this.takeDoc(i1);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "cody_warn_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/where_go");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("cody_warned");
        DialogueController.dc.initDialogue(this.doc.lines, "cody_warn", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color);
        if (GameDataController.gd.getObjective("visited_sidereal_outside_1") && GameDataController.gd.getObjectiveDetail("car_location") == 8)
        {
          this.doc.lines[2].text = GameStrings.getString(GameStrings.dialogues, "cody_warn_variant1b");
          this.doc.lines[10].text = GameStrings.getString(GameStrings.dialogues, "cody_warn_variant2b");
        }
        if (GameDataController.gd.getObjective("visited_sidereal_outside_1") && GameDataController.gd.getObjectiveDetail("car_location") != 8)
        {
          this.doc.lines[2].text = GameStrings.getString(GameStrings.dialogues, "cody_warn_variant1a");
          this.doc.lines[10].text = GameStrings.getString(GameStrings.dialogues, "cody_warn_variant2a");
        }
        if (SceneManager.GetActiveScene().name.ToLower().IndexOf("sidereal") != -1)
          this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.goAndWait);
        ++i1;
      }
      if (GameDataController.gd.getObjective("dream_tiger_future"))
      {
        this.takeDoc(i1);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "cody_tiger_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/tiger");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_cody_tiger");
        DialogueController.dc.initDialogue(this.doc.lines, "cody_tiger", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color);
        ++i1;
      }
      if (!GameDataController.gd.getObjective("restaurant_door_opened2") || GameDataController.gd.getObjective("dialogue_cody_door_opened"))
      {
        this.takeDoc(i1);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "exit_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
        this.doc.lines = new List<DialogueLine>();
        DialogueController.dc.initDialogue(this.doc.lines, "cody_exit", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, Npc3Controller.color, component, color);
        this.doc.setObjective(string.Empty);
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
        num1 = i1 + 1;
      }
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
      GameObject.Find("Npc3").GetComponent<NPCWalkController>().speed = GameObject.Find("Npc3").GetComponent<NPCWalkController>().MAX_SPEED * 2f;
      GameDataController.gd.setObjective("npc3_joined", false);
      this.gameObject.GetComponent<NPCWalkController>().forceAnimation("walk_e", true);
      this.Invoke("stopWalking", 3f);
    }
    GameObject.Find("Npc3").GetComponent<NPCWalkController>().setSimpleTargetV3(GameObject.Find("CodyGoAway").transform.position);
    this.endTalk(string.Empty);
  }

  public void stopWalking() => this.gameObject.GetComponent<NPCWalkController>().forceAnimation("stand_se", true);

  public void startTalkRestaurant(string val = "")
  {
    GameObject.Find("Ginger").GetComponent<NPCWalkController>().forceAnimation("stand_ne");
    if (!GameDataController.gd.getObjective("npc2_joined"))
      return;
    GameObject.Find("Npc2").GetComponent<NPCWalkController>().forceAnimation("stand_n");
  }

  public void endTalkRestaurant(string val = "") => this.gameObject.GetComponent<NPCWalkController>().forceAnimation("surprised_end", true);

  public void endTalkRestaurant2(string val = "")
  {
    GameObject.Find("Ginger").GetComponent<NPCWalkController>().forceAnimation("stand_se");
    if (!GameDataController.gd.getObjective("npc2_joined"))
      return;
    GameObject.Find("Npc2").GetComponent<NPCWalkController>().forceAnimation("stand_se");
  }

  public void flip() => this.gameObject.GetComponent<SpriteRenderer>().flipX = true;

  public override void clickAction2()
  {
  }

  public override void updateState()
  {
    this.setCollider(0);
    this.GetComponent<SpriteRenderer>().enabled = true;
    if (!GameDataController.gd.getObjective("npc3_alive"))
    {
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      if (!GameDataController.gd.getObjective("dialogue_cody_intro"))
        this.objectName = "npc_boy";
      else
        this.objectName = "npc_cody";
      if (GameDataController.gd.getObjective("sidereal_roof_wait_for_rescue"))
        this.actionType = ObjectActionController.Type.NormalAction;
      else
        this.actionType = ObjectActionController.Type.Talk;
      this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-0.01313657f, -0.04973114f);
      this.range = 25f;
      this.rotateToSpeaker = true;
      if (GameDataController.gd.getObjective("restaurant_door_opened2") && SceneManager.GetActiveScene().name == "LocationRestaurant3")
      {
        if (GameDataController.gd.getObjective("dialogue_cody_food_closed_given"))
          this.gameObject.GetComponent<NPCWalkController>().forceAnimation("can_shake", true);
        else if (GameDataController.gd.getObjective("dialogue_cody_door_opened"))
        {
          this.rotateToSpeaker = true;
          this.gameObject.GetComponent<NPCWalkController>().playIdleAnimation("cody_stand_se");
        }
        else
          this.rotateToSpeaker = false;
      }
      else
      {
        if (!(SceneManager.GetActiveScene().name == "LocationRestaurant3"))
          return;
        this.range = 1000f;
        this.rotateToSpeaker = false;
        if (DialogueController.dc.talking)
          return;
        this.gameObject.GetComponent<NPCWalkController>().forceAnimation("pull_door", true);
      }
    }
  }

  public override void clickAction0()
  {
  }

  public void goVent1(string val = "") => GameObject.Find("Npc3").GetComponent<NPCWalkController>().setSimpleTarget(new Vector2(55f, 50f));

  public void goVent(string val = "")
  {
    DialogueController.dc.talking = false;
    DialogueController.dc.hide();
    Timeline.t.doNotUnlock = true;
    this.gameObject.GetComponent<NPCWalkController>().setBusy(false);
    PlayerController.pc.setBusy(true);
    Object.FindObjectOfType<LocationSiderealF1C_Waypoint_B>().pushLittleCart();
    this.Invoke("openDoorSound", 0.2f);
  }

  public void fightStance(string val = "") => this.gameObject.GetComponent<NPCWalkController>().forceAnimation("fight_stance", true);

  public void openDoorSound() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_door_open);
}
