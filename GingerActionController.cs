// Decompiled with JetBrains decompiler
// Type: GingerActionController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GingerActionController : NPCActionController
{
  private static Vector3 color = new Vector3(0.8431373f, 0.227451f, 0.1803922f);
  private TextFieldController distractBarryTextfield;

  public static Vector3 getColor() => GingerActionController.color;

  public static bool isGingerHere() => !GameDataController.gd.getObjective("dialogue_ginger_barry_distracted") && (!GameDataController.gd.getObjective("sidereal_roof_collapsed") || GameDataController.gd.getObjective("dialogue_ginger_reunited")) && GameDataController.gd.getObjective("npc1_alive") && !GameDataController.gd.getObjective("moon_cate_sleeps");

  public override void continueStart()
  {
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("coat1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("water1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("water2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("water3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("water4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_6", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_0", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("pills", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("deadbird", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("whiskey", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("oil", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("fan", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("fan_broken", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rope", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ropehook", string.Empty, anim: string.Empty));
    this.busyTalkingRandomly = false;
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
    else if (GameDataController.gd.getObjective("sidereal_roof_collapsed") && SceneManager.GetActiveScene().name == "LocationSiderealRoof")
    {
      this.range = 200f;
      this.rotateToSpeaker = false;
    }
    else if (GameDataController.gd.getObjective("moon_shocked1"))
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker_sit").gameObject;
      this.range = 0.0f;
      this.rotateToSpeaker = false;
    }
    else if (SceneManager.GetActiveScene().name == "LocationShip1")
    {
      this.range = 25f;
      this.rotateToSpeaker = false;
    }
    else if (GameDataController.gd.getObjective("dialogue_ginger_barry_distracted"))
    {
      this.range = 100f;
      this.rotateToSpeaker = false;
    }
    else
    {
      this.range = 25f;
      this.rotateToSpeaker = true;
    }
  }

  public void playerStandUp(string v = "")
  {
    Timeline.t.doNotUnlock = true;
    PlayerController.pc.forceAnimation("kneel_out_n");
  }

  public void endTalkShip(string val = "")
  {
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("ruda_get_up");
    this.endTalk(string.Empty);
  }

  public void roofAfterFall()
  {
    this.instantLines = new List<DialogueLine>();
    if (!GameDataController.gd.getObjective("npc3_alive") && !GameDataController.gd.getObjective("npc2_alive"))
      DialogueController.dc.initDialogue(this.instantLines, "sidereal_nofall2_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
    else if (!GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjectiveDetail("npc3_alive") == 1 || !GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjectiveDetail("npc2_alive") == 1)
      DialogueController.dc.initDialogue(this.instantLines, "sidereal_afterfall_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
    else
      DialogueController.dc.initDialogue(this.instantLines, "sidereal_nofall_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
    this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(this.roofWalkAway);
    for (int index = 0; index < this.instantLines.Count; ++index)
      Timeline.t.addDialogue(this.instantLines[index]);
  }

  public void goToSleep1(string a = "") => this.gameObject.GetComponent<NPCWalkController>().setSimpleTargetV3(GameObject.Find("CateWalkHere").transform.position);

  public void goToSleep2(string a = "")
  {
    PlayerController.pc.setBusy(true);
    PlayerController.pc.spawnName = "cate_pod";
    DialogueController.dc.talking = false;
    Timeline.t.doNotUnlock = true;
    CurtainController.cc.fadeOut("LocationMoonbase3", WalkController.Direction.NW, "stand_ne", flipX: true, actionAfterFade: new CurtainController.Delegate(this.goToSleep3));
  }

  public void goToSleep3()
  {
    TextFieldController component = GameObject.Find("Moonbase3Pad2").transform.Find("TextField").GetComponent<TextFieldController>();
    if (GameDataController.gd.getObjective("npc2_alive") && !GameDataController.gd.getObjective("moon_barry_sleeps"))
    {
      component.transform.position = ScreenControler.roundToNearestFullPixel3(component.transform.position);
      this.instantLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(this.instantLines, "cate_sleep_barry", component, GingerActionController.color, GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor());
      for (int index = 0; index < this.instantLines.Count; ++index)
        Timeline.t.addDialogue(this.instantLines[index]);
    }
    if (GameDataController.gd.getObjective("npc3_alive") && !GameDataController.gd.getObjective("moon_cody_sleeps"))
    {
      this.instantLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(this.instantLines, "cate_sleep_cody", component, GingerActionController.color, GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor());
      for (int index = 0; index < this.instantLines.Count; ++index)
        Timeline.t.addDialogue(this.instantLines[index]);
    }
    this.instantLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.instantLines, "cate_sleep_2david", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, GingerActionController.color);
    this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(this.closePod);
    for (int index = 0; index < this.instantLines.Count; ++index)
      Timeline.t.addDialogue(this.instantLines[index]);
  }

  public void closePod(string s = "")
  {
    GameObject.Find("Moonbase3Pad2").GetComponent<Animator>().Play("moon_pod2_close");
    GameDataController.gd.setObjectiveDetail("moon_cate_sleeps", 1);
    if (GameDataController.gd.getObjective("npc2_alive") && !GameDataController.gd.getObjective("moon_barry_sleeps"))
      GameObject.Find("Npc2").GetComponent<Npc2Controller>().pod_rotate();
    if (!GameDataController.gd.getObjective("npc3_alive") || GameDataController.gd.getObjective("moon_cody_sleeps"))
      return;
    GameObject.Find("Npc3").GetComponent<Npc3Controller>().pod_rotate();
  }

  public void pod_rotate() => this.Invoke("pod_rotate2", Random.Range(0.5f, 2f));

  public void pod_rotate2()
  {
    this.GetComponent<NPCWalkController>().fullStop(true);
    this.GetComponent<NPCWalkController>().forceAnimation("stand_se");
    this.GetComponent<NPCWalkController>().setBusy(false);
  }

  public void roofWalkAway(string a = "")
  {
    this.gameObject.GetComponent<NPCWalkController>().speed = this.gameObject.GetComponent<NPCWalkController>().MAX_SPEED;
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("walk_e", true);
    this.gameObject.GetComponent<NPCWalkController>().setSimpleTargetV3(GameObject.Find("GingerWalkAway").transform.position);
    if (!GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjectiveDetail("npc3_alive") == 1 || GameDataController.gd.getObjective("npc2_alive") || GameDataController.gd.getObjectiveDetail("npc2_alive") != 1)
      ;
    this.Invoke("roofWalkAway2", 5f);
  }

  public void roofWalkAway2()
  {
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("stand_n", true);
    this.gameObject.GetComponent<NPCWalkController>().fullStop();
  }

  public override void npcClickAction(string item = "")
  {
    this.instantLines = new List<DialogueLine>();
    if (GameDataController.gd.getObjective("sidereal_roof_collapsed") && SceneManager.GetActiveScene().name == "LocationSiderealRoof" && !GameDataController.gd.getObjective("dialogue_ginger_reunited"))
    {
      bool flag1 = true;
      if (!GameDataController.gd.getObjective("npc3_joined") || !GameDataController.gd.getObjective("npc3_alive"))
        flag1 = false;
      bool flag2 = true;
      if (!GameDataController.gd.getObjective("npc2_joined") || !GameDataController.gd.getObjective("npc2_alive"))
        flag2 = false;
      if (!GameDataController.gd.getObjective("sidereal_roof_wait_for_rescue"))
      {
        flag2 = false;
        flag1 = false;
      }
      if (flag2 && flag1)
        DialogueController.dc.initDialogue(this.instantLines, "ginger_roof_save_them", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      else if (flag2)
        DialogueController.dc.initDialogue(this.instantLines, "ginger_roof_save_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      else if (flag1)
        DialogueController.dc.initDialogue(this.instantLines, "ginger_roof_save_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      else
        DialogueController.dc.initDialogue(this.instantLines, "sidereal_savedfalltalk_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      for (int index = 0; index < this.instantLines.Count; ++index)
        Timeline.t.addDialogue(this.instantLines[index]);
    }
    else if (GameDataController.gd.getObjective("moon_shocked1"))
    {
      PlayerController.pc.forceAnimation("kneel_in_n");
      DialogueController.dc.initDialogue(this.instantLines, "moon_shocked_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      GameDataController.gd.setObjective("moon_shocked1", false);
      if (GameDataController.gd.getObjective("npc1_alive") && !GameDataController.gd.getObjective("moon_shocked1") && (!GameDataController.gd.getObjective("npc2_alive") || !GameDataController.gd.getObjective("moon_shocked2")) && (!GameDataController.gd.getObjective("npc3_alive") || !GameDataController.gd.getObjective("moon_shocked3")))
      {
        if (GameDataController.gd.getObjective("npc1_alive"))
          this.instantLines.Add(new DialogueLine(this.textField, GingerActionController.color, GameStrings.getString(GameStrings.dialogues, "moon_shocked_cate_ending"), (TimelineFunction) null));
        else
          this.instantLines.Add(new DialogueLine(PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameStrings.getString(GameStrings.dialogues, "moon_shocked_nocate_ending"), (TimelineFunction) null));
      }
      this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(this.endTalkShip);
      this.instantLines[this.instantLines.Count - 2].action = new TimelineFunction(this.playerStandUp);
      for (int index = 0; index < this.instantLines.Count; ++index)
        Timeline.t.addDialogue(this.instantLines[index]);
    }
    else
    {
      if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjective("thug_to_kill_bathroom"))
      {
        GameObject.Find("Ginger").GetComponent<NPCWalkController>().setFlipped(true);
        this.textField = this.gameObject.GetComponent<TextFieldController>();
        DialogueController.dc.initDialogue(this.instantLines, "thug_kill_or_not", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color, GameObject.Find("thug").GetComponent<TextFieldController>(), new Vector3(0.588f, 0.15f, 0.43f));
        if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive"))
        {
          GingerActionController.getColor();
          Vector3 color = Npc2Controller.getColor();
          TextFieldController component = GameObject.Find("Npc2").GetComponent<TextFieldController>();
          DialogueController.dc.initDialogue(this.instantLines, "thug_kill_or_not_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color, component, color);
        }
        if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
        {
          Vector3 color = Npc3Controller.getColor();
          TextFieldController component = GameObject.Find("Npc3").GetComponent<TextFieldController>();
          DialogueController.dc.initDialogue(this.instantLines, "thug_kill_or_not_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color, component, color);
        }
      }
      else if (!GameDataController.gd.getObjective("dialogue_ginger_intro"))
      {
        if (!GameDataController.gd.getObjective("ginger_from_attic"))
          DialogueController.dc.initDialogue(this.instantLines, "ginger_intro0b", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        else
          DialogueController.dc.initDialogue(this.instantLines, "ginger_intro0a", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        DialogueController.dc.initDialogue(this.instantLines, "ginger_intro1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        if (GameDataController.gd.getObjective("previous_disc_barry") || GameDataController.gd.getObjective("previous_disc_cody"))
          DialogueController.dc.initDialogue(this.instantLines, "ginger_intro_dejavu", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        DialogueController.dc.initDialogue(this.instantLines, "ginger_intro", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        if (GameDataController.gd.getObjective("ginger_from_attic"))
        {
          this.instantLines[1].action = new TimelineFunction(this.aimGun);
          this.instantLines[1].actionParam = "left";
          this.instantLines[1].actionWithText = true;
        }
        else
        {
          this.instantLines[0].action = new TimelineFunction(this.aimGun);
          this.instantLines[0].actionParam = "right";
          this.instantLines[0].actionWithText = true;
        }
        this.instantLines[9].action = new TimelineFunction(this.holdGunUp);
        this.instantLines[9].actionWithText = true;
        this.instantLines[9].actionParam = "right";
        if (GameDataController.gd.getObjective("ginger_from_attic"))
          this.instantLines[9].actionParam = "left";
        this.instantLines[14].action = new TimelineFunction(this.holster);
        this.instantLines[14].actionParam = "right";
        if (GameDataController.gd.getObjective("ginger_from_attic"))
          this.instantLines[14].actionParam = "left";
      }
      else
      {
        if (GameDataController.gd.getObjective("dialogue_ginger_barry_distracted"))
        {
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "ginger_barry_distracted"), true, mwidth: 150);
          return;
        }
        if (item == "coat1" || item == "coat2" || item == "coat3" || item == "coat4")
        {
          if (ItemsManager.im.getItem("coat1").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("coat2").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("coat3").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("coat4").dataRef.droppedLocation == "ginger")
          {
            DialogueController.dc.initDialogue(this.instantLines, "ginger_already_coat", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
            this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
          }
          else if (GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
          {
            DialogueController.dc.initDialogue(this.instantLines, "ginger_give_coat", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
            this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
            InventoryController.ic.removeItem(item);
            ItemsManager.im.getItem(item).dataRef.droppedLocation = "ginger";
            JournalTexts.pickTexts(GameDataController.gd.getCurrentDay());
          }
          else if (GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
          {
            DialogueController.dc.initDialogue(this.instantLines, "ginger_bad_coat", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
            this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
          }
          else
          {
            DialogueController.dc.initDialogue(this.instantLines, "ginger_bad2_coat", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
            this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
          }
        }
        else if (item == "water1" || item == "water2" || item == "water3" || item == "water4")
        {
          if (ItemsManager.im.getItem("water1").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("water2").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("water3").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("water4").dataRef.droppedLocation == "ginger")
          {
            DialogueController.dc.initDialogue(this.instantLines, "ginger_already_water", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
            this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
          }
          else if (GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
          {
            DialogueController.dc.initDialogue(this.instantLines, "ginger_give_water", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
            this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
            InventoryController.ic.removeItem(item);
            ItemsManager.im.getItem(item).dataRef.droppedLocation = "ginger";
            JournalTexts.pickTexts(GameDataController.gd.getCurrentDay());
          }
          else if (GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
          {
            DialogueController.dc.initDialogue(this.instantLines, "ginger_bad_water", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
            this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
          }
          else if (ItemsManager.im.getItem("water1").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("water2").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("water3").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("water4").dataRef.droppedLocation == "ginger")
          {
            DialogueController.dc.initDialogue(this.instantLines, "ginger_already_water", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
            this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
          }
          else
          {
            DialogueController.dc.initDialogue(this.instantLines, "ginger_bad2_water", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
            this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
          }
        }
        else if (this.usedItem == "pills")
        {
          string prefix = "ginger_give_pills";
          if (GameDataController.gd.getObjective("cate_pills_taken"))
            prefix = "ginger_gave_pills";
          GameDataController.gd.setObjective("cate_pills_taken", true);
          DialogueController.dc.initDialogue(this.instantLines, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
        }
        else if (this.usedItem.IndexOf("revolver") != -1)
        {
          DialogueController.dc.initDialogue(this.instantLines, "ginger_give_gun", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
        }
        else if (item == "deadbird")
        {
          DialogueController.dc.initDialogue(this.instantLines, "dead_bird_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
        }
        else if (item == "whiskey")
        {
          DialogueController.dc.initDialogue(this.instantLines, "whiskey_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
        }
        else if (item == "oil")
        {
          DialogueController.dc.initDialogue(this.instantLines, "oil_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
        }
        else if (item == "fan" || item == "fan_broken")
        {
          DialogueController.dc.initDialogue(this.instantLines, "fan_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
        }
        else if (item == "rope" || item == "ropehook")
        {
          DialogueController.dc.initDialogue(this.instantLines, "rope_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
          this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
        }
        else if (GameDataController.gd.getCurrentDay() == 3 && SceneManager.GetActiveScene().name.IndexOf("Sidereal") != -1 && !GameDataController.gd.getObjective("sidereal_base_located"))
          DialogueController.dc.initDialogue(this.instantLines, "ginger_intro_sidereal", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        else if (SceneManager.GetActiveScene().name.IndexOf("Moonbase") != -1 && !GameDataController.gd.getObjective("dialogue_moonbase2_intro"))
          DialogueController.dc.initDialogue(this.instantLines, "moonbase2_postintro", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        else
          DialogueController.dc.initDialogue(this.instantLines, "ginger_intro2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
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
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjective("thug_to_kill_bathroom") && !GameDataController.gd.getObjective("dialogue_ginger_thug_kill_no"))
    {
      int i = 0;
      this.takeDoc(i);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "thug_kill_yes_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/kill_razor");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dialogue_ginger_thug_kill_yes");
      DialogueController.dc.initDialogue(this.doc.lines, "thug_kill_yes", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color, GameObject.Find("thug").GetComponent<TextFieldController>(), new Vector3(0.588f, 0.15f, 0.43f));
      if (GameDataController.gd.getObjective("npc2_joined") && !GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjectiveDetail("npc2_alive") == 2)
        this.doc.lines.Insert(7, new DialogueLine(PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameStrings.getString(GameStrings.dialogues, "thug_kill_yes_barry"), (TimelineFunction) null));
      if (GameDataController.gd.getObjective("npc3_joined") && !GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjectiveDetail("npc3_alive") == 2)
        this.doc.lines.Insert(7, new DialogueLine(PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameStrings.getString(GameStrings.dialogues, "thug_kill_yes_cody"), (TimelineFunction) null));
      if (GameDataController.gd.getObjective("npc3_alive"))
        this.doc.lines[this.doc.lines.Count - 1].text = GameStrings.getString(GameStrings.dialogues, "thug_kill_yes_11_b_cody");
      this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.killRazor);
      this.takeDoc(i + 1);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "thug_kill_no_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/razor");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dialogue_ginger_thug_kill_no");
      DialogueController.dc.initDialogue(this.doc.lines, "thug_kill_no", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color, GameObject.Find("thug").GetComponent<TextFieldController>(), new Vector3(0.588f, 0.15f, 0.43f));
      this.takeDoc(0);
      if (!(this.doc.caption != string.Empty))
        return;
      DialogueController.dc.talking = true;
    }
    else if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjective("thug_to_kill_bathroom"))
    {
      int i1 = 0;
      this.takeDoc(i1);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "thug_kill_yes_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/kill_razor");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dialogue_ginger_thug_kill_yes");
      DialogueController.dc.initDialogue(this.doc.lines, "thug_kill_yes", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color, GameObject.Find("thug").GetComponent<TextFieldController>(), new Vector3(0.588f, 0.15f, 0.43f));
      if (GameDataController.gd.getObjective("npc2_joined") && !GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjectiveDetail("npc2_alive") == 2)
        this.doc.lines.Insert(7, new DialogueLine(PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameStrings.getString(GameStrings.dialogues, "thug_kill_yes_barry"), (TimelineFunction) null));
      if (GameDataController.gd.getObjective("npc3_joined") && !GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjectiveDetail("npc3_alive") == 2)
        this.doc.lines.Insert(7, new DialogueLine(PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameStrings.getString(GameStrings.dialogues, "thug_kill_yes_cody"), (TimelineFunction) null));
      if (GameDataController.gd.getObjective("npc3_alive"))
        this.doc.lines[this.doc.lines.Count - 1].text = GameStrings.getString(GameStrings.dialogues, "thug_kill_yes_11_b_cody");
      this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.killRazor);
      int i2 = i1 + 1;
      this.takeDoc(i2);
      if (!GameDataController.gd.getObjective("dialogue_ginger_thug_kill_waste"))
      {
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "thug_kill_waste_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bullet");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_ginger_thug_kill_waste");
        DialogueController.dc.initDialogue(this.doc.lines, "thug_kill_waste", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color, GameObject.Find("thug").GetComponent<TextFieldController>(), new Vector3(0.588f, 0.15f, 0.43f));
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.evaluateRazor);
        ++i2;
        this.takeDoc(i2);
      }
      if (!GameDataController.gd.getObjective("dialogue_ginger_thug_kill_lesson"))
      {
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "thug_kill_lesson_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/razor");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_ginger_thug_kill_lesson");
        DialogueController.dc.initDialogue(this.doc.lines, "thug_kill_lesson", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color, GameObject.Find("thug").GetComponent<TextFieldController>(), new Vector3(0.588f, 0.15f, 0.43f));
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.evaluateRazor);
        ++i2;
        this.takeDoc(i2);
      }
      if (!GameDataController.gd.getObjective("dialogue_ginger_thug_kill_better"))
      {
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "thug_kill_better_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/ginger_saint");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_ginger_thug_kill_better");
        DialogueController.dc.initDialogue(this.doc.lines, "thug_kill_better", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color, GameObject.Find("thug").GetComponent<TextFieldController>(), new Vector3(0.588f, 0.15f, 0.43f));
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.evaluateRazor);
        this.takeDoc(i2 + 1);
      }
      if (!GameDataController.gd.getObjective("dialogue_ginger_thug_kill_end_anyway"))
      {
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "thug_kill_end_anyway_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/end_of_world");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_ginger_thug_kill_end_anyway");
        DialogueController.dc.initDialogue(this.doc.lines, "thug_kill_end_anyway", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color, GameObject.Find("thug").GetComponent<TextFieldController>(), new Vector3(0.588f, 0.15f, 0.43f));
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.evaluateRazor);
      }
      this.takeDoc(0);
      if (!(this.doc.caption != string.Empty))
        return;
      DialogueController.dc.talking = true;
    }
    else if (SceneManager.GetActiveScene().name.IndexOf("Moonbase") != -1 && GameDataController.gd.getObjective("visited_moonbase3"))
    {
      int i3 = this.locationDialogue(0, GingerActionController.color, "cate");
      this.takeDoc(i3);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "moonbase2_sleeper_pods_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/pods");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dialogue_moonbase2_sleeper_pods");
      DialogueController.dc.initDialogue(this.doc.lines, "moonbase2_sleeper_pods", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      int i4 = i3 + 1;
      this.takeDoc(i4);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "moonbase2_body_dies_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/pod_dead");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dialogue_moonbase2_body_dies");
      DialogueController.dc.initDialogue(this.doc.lines, "moonbase2_body_dies", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      int i5 = i4 + 1;
      this.takeDoc(i5);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "moonbase2_realm_of_dreams_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/dreams");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dialogue_moonbase2_realm_of_dreams");
      DialogueController.dc.initDialogue(this.doc.lines, "moonbase2_realm_of_dreams", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      int i6 = i5 + 1;
      this.takeDoc(i6);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_moon_radio1_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/earth_or_moon");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dialogue_ginger_moon_radio1");
      DialogueController.dc.initDialogue(this.doc.lines, "ginger_moon_radio1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      if (GameDataController.gd.getObjective("dialogue_ginger_moon_radio1"))
      {
        ++i6;
        this.takeDoc(i6);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_moon_radio2_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/earth_or_moon2");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_ginger_moon_radio2");
        DialogueController.dc.initDialogue(this.doc.lines, "ginger_moon_radio2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      }
      if (GameDataController.gd.getObjective("pods_cosnole_inspected") && !GameDataController.gd.getObjective("moon_console_unlocked"))
      {
        ++i6;
        this.takeDoc(i6);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_moon_pods_lockdown_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/console_locked");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_pods_lockdown");
        DialogueController.dc.initDialogue(this.doc.lines, "ginger_moon_pods_lockdown", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      }
      if (GameDataController.gd.getObjective("dialogue_pods_intro"))
      {
        int i7 = i6 + 1;
        this.takeDoc(i7);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_moon_pods_phase_controller_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/phase");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_pods_phase_controller");
        DialogueController.dc.initDialogue(this.doc.lines, "ginger_moon_pods_phase_controller", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        int i8 = i7 + 1;
        this.takeDoc(i8);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_moon_pods_emergency_merge_mode_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/merge");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_pods_emergency_mode");
        DialogueController.dc.initDialogue(this.doc.lines, "ginger_moon_pods_emergency_merge_mode", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        int i9 = i8 + 1;
        this.takeDoc(i9);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_moon_pods_where_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/where_go");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_pods_where");
        DialogueController.dc.initDialogue(this.doc.lines, "ginger_moon_pods_where", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        i6 = i9 + 1;
        this.takeDoc(i6);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_moon_pods_loop1_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/already");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_pods_loop1");
        DialogueController.dc.initDialogue(this.doc.lines, "ginger_moon_pods_loop1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        if (GameDataController.gd.getObjective("dialogue_pods_emergency_mode"))
        {
          ++i6;
          this.takeDoc(i6);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_moon_pods_loop2_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/brain");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_pods_loop2");
          DialogueController.dc.initDialogue(this.doc.lines, "ginger_moon_pods_loop2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        }
        if (GameDataController.gd.getObjective("dialogue_pods_emergency_mode"))
        {
          ++i6;
          this.takeDoc(i6);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_moon_pods_paradox_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/paradox");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_pods_paradox");
          DialogueController.dc.initDialogue(this.doc.lines, "ginger_moon_pods_paradox", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        }
        if (GameDataController.gd.getObjective("moon_disc1_used") && GameDataController.gd.getObjective("moon_disc2_used"))
        {
          ++i6;
          this.takeDoc(i6);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_moon_disks_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/discs");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("ginger_moon_disks");
          DialogueController.dc.initDialogue(this.doc.lines, "ginger_moon_disks", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        }
        else if (GameDataController.gd.getObjective("moon_disc1_used"))
        {
          ++i6;
          this.takeDoc(i6);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_moon_disk1_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/disc1");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("ginger_moon_disk");
          DialogueController.dc.initDialogue(this.doc.lines, "ginger_moon_disk", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        }
        else if (GameDataController.gd.getObjective("moon_disc2_used"))
        {
          ++i6;
          this.takeDoc(i6);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_moon_disk2_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/disc2");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("ginger_moon_disk");
          DialogueController.dc.initDialogue(this.doc.lines, "ginger_moon_disk", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        }
        if (GameDataController.gd.getObjective("moon_pods_unlocked") && SceneManager.GetActiveScene().name == "LocationMoonbase3")
        {
          ++i6;
          this.takeDoc(i6);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "cate_sleep_david_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/pod_cate");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("moon_cate_sleeps");
          DialogueController.dc.initDialogue(this.doc.lines, "cate_sleep_david", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
          this.doc.lines[this.doc.lines.Count - 3].action = new TimelineFunction(this.goToSleep1);
          this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.goToSleep2);
        }
      }
      string prefix = "moonbase2_intro_end";
      if (GameDataController.gd.getObjective("dialogue_moonbase2_intro"))
        prefix = "ginger_exit";
      this.takeDoc(i6 + 1);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "exit_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dialogue_moonbase2_intro");
      if (GameDataController.gd.getObjective("moon_console_unlocked") && !GameDataController.gd.getObjective("moon_pods_unlocked") && GameDataController.gd.getObjective("dialogue_pods_intro"))
      {
        this.doc.setObjective("moon_pods_unlocked");
        prefix = "moonbase2_pods_open_end";
      }
      DialogueController.dc.initDialogue(this.doc.lines, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
      if (GameDataController.gd.getObjective("moon_console_unlocked") && !GameDataController.gd.getObjective("moon_pods_unlocked") && GameDataController.gd.getObjective("dialogue_pods_intro"))
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.openThePodBayDoors);
      this.takeDoc(0);
      if (!(this.doc.caption != string.Empty))
        return;
      DialogueController.dc.talking = true;
    }
    else if (GameDataController.gd.getCurrentDay() == 3 && SceneManager.GetActiveScene().name.IndexOf("Sidereal") != -1 && !GameDataController.gd.getObjective("sidereal_base_located"))
    {
      int i10 = 0;
      this.takeDoc(i10);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_sidereal_arrival_outpost_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/outpost");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dialogue_ginger_sidereal_arrival_outpost");
      DialogueController.dc.initDialogue(this.doc.lines, "ginger_sidereal_arrival_outpost", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      int i11 = i10 + 1;
      this.takeDoc(i11);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_sidereal_arrival_docs_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/docs");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dialogue_ginger_sidereal_arrival_docs");
      DialogueController.dc.initDialogue(this.doc.lines, "ginger_sidereal_arrival_docs", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      int i12 = i11 + 1;
      this.takeDoc(i12);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_sidereal_connections1_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/sidereal");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dialogue_ginger_sidereal_arrival_connections1");
      DialogueController.dc.initDialogue(this.doc.lines, "ginger_sidereal_connections1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      this.takeDoc(i12 + 1);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "exit_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective(string.Empty);
      DialogueController.dc.initDialogue(this.doc.lines, "ginger_sidereal_exit", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
      this.takeDoc(0);
      if (!(this.doc.caption != string.Empty))
        return;
      DialogueController.dc.talking = true;
    }
    else
    {
      int i13 = 0;
      if (GameDataController.gd.getObjective("dialogue_ginger_first_exit"))
        i13 = this.dayDialogue(this.locationDialogue(i13, GingerActionController.color, "cate"), GingerActionController.color, "cate");
      this.takeDoc(i13);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_about_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/ginger");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dialogue_ginger_about");
      DialogueController.dc.initDialogue(this.doc.lines, "ginger_about", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      if (GameDataController.gd.getCurrentDay() <= 2)
      {
        ++i13;
        this.takeDoc(i13);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_car_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/car");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_ginger_car");
        DialogueController.dc.initDialogue(this.doc.lines, "ginger_car1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        if (!GameDataController.gd.getObjective("barn_car_wheel_repaired") || !GameDataController.gd.getObjective("barn_car_coil_repaired") || !GameDataController.gd.getObjective("barn_car_battery_repaired"))
          DialogueController.dc.initDialogue(this.doc.lines, "ginger_car2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      }
      if (GameDataController.gd.getCurrentDay() <= 3)
      {
        int i14 = i13 + 1;
        this.takeDoc(i14);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_moon_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/moon");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_ginger_moon");
        DialogueController.dc.initDialogue(this.doc.lines, "ginger_moon", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        int i15 = i14 + 1;
        this.takeDoc(i15);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_spaceship_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/ship");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_ginger_ship");
        DialogueController.dc.initDialogue(this.doc.lines, "ginger_spaceship", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        i13 = i15 + 1;
        this.takeDoc(i13);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_outpost_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/outpost");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_ginger_outpost");
        DialogueController.dc.initDialogue(this.doc.lines, "ginger_outpost", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        if (GameDataController.gd.getObjective("dialogue_ginger_outpost"))
        {
          ++i13;
          this.takeDoc(i13);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_map_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/map");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_ginger_map");
          DialogueController.dc.initDialogue(this.doc.lines, "ginger_map", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
          this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.showMap);
        }
      }
      if (GameDataController.gd.getCurrentDay() <= 2)
      {
        ++i13;
        this.takeDoc(i13);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_dreams_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/dream");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_ginger_dreams");
        DialogueController.dc.initDialogue(this.doc.lines, "ginger_dreams", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
          this.doc.lines[1].text = GameStrings.getString(GameStrings.dialogues, "ginger_dreams_SWARM_2_a");
        if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
          this.doc.lines[1].text = GameStrings.getString(GameStrings.dialogues, "ginger_dreams_GAS_2_a");
        if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
          this.doc.lines[1].text = GameStrings.getString(GameStrings.dialogues, "ginger_dreams_SPIDERS_2_a");
        if (GameDataController.gd.getObjective("dialogue_ginger_dreams"))
        {
          ++i13;
          this.takeDoc(i13);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_dreams2_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/dream2");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("dialogue_ginger_dreams2");
          DialogueController.dc.initDialogue(this.doc.lines, "ginger_dreams2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
          if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
            this.doc.lines[1].text = GameStrings.getString(GameStrings.dialogues, "ginger_dreams2_2_COLD");
          if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
            this.doc.lines[1].text = GameStrings.getString(GameStrings.dialogues, "ginger_dreams2_2_HEAT");
        }
      }
      string empty = string.Empty;
      if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getCurrentDay() < 5)
      {
        ++i13;
        this.takeDoc(i13);
        string str = "ginger_barry";
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, str + "_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/barry");
        this.doc.lines = new List<DialogueLine>();
        int num = 1;
        if (GameDataController.gd.getCurrentDay() == 2)
          num = 1;
        if (GameDataController.gd.getCurrentDay() == 3)
          num = 2;
        if (GameDataController.gd.getCurrentDay() == 4)
          num = 3;
        this.doc.setObjective("dialogue_" + str + num.ToString());
        DialogueController.dc.initDialogue(this.doc.lines, str + num.ToString(), PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      }
      else if (GameDataController.gd.getObjective("npc2_joined") && !GameDataController.gd.getObjective("npc2_alive") && (GameDataController.gd.getObjective("sidereal_npc_found") || GameDataController.gd.getObjectiveDetail("npc2_alive") != 1))
      {
        ++i13;
        this.takeDoc(i13);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_barry_dead_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/barry");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_ginger_barry_dead");
        DialogueController.dc.initDialogue(this.doc.lines, "ginger_barry_dead", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      }
      if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getCurrentDay() < 5)
      {
        ++i13;
        this.takeDoc(i13);
        string str = "ginger_cody";
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, str + "_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/cody");
        this.doc.lines = new List<DialogueLine>();
        int num = 1;
        if (GameDataController.gd.getCurrentDay() == 2)
          num = 1;
        if (GameDataController.gd.getCurrentDay() == 3)
          num = 2;
        if (GameDataController.gd.getCurrentDay() == 4)
          num = 3;
        this.doc.setObjective("dialogue_" + str + num.ToString());
        DialogueController.dc.initDialogue(this.doc.lines, str + num.ToString(), PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      }
      else if (GameDataController.gd.getObjective("npc3_joined") && !GameDataController.gd.getObjective("npc3_alive") && (GameDataController.gd.getObjective("sidereal_npc_found") || GameDataController.gd.getObjectiveDetail("npc3_alive") != 1))
      {
        ++i13;
        this.takeDoc(i13);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_cody_dead_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/cody");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_ginger_cody_dead");
        DialogueController.dc.initDialogue(this.doc.lines, "ginger_cody_dead", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      }
      if (GameDataController.gd.getCurrentDay() >= 3 && GameDataController.gd.getObjective("sidereal_base_located") && GameDataController.gd.getObjective("sidereal_read_cate_mail"))
      {
        ++i13;
        this.takeDoc(i13);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_sidereal_reveal_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/ginger");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("ginger_sidereal_reveal");
        DialogueController.dc.initDialogue(this.doc.lines, "ginger_sidereal_reveal", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        if (GameDataController.gd.getObjective("ginger_sidereal_reveal"))
        {
          int i16 = i13 + 1;
          this.takeDoc(i16);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_sidereal_why_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/cate_hide");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("ginger_sidereal_why");
          DialogueController.dc.initDialogue(this.doc.lines, "ginger_sidereal_why", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
          int i17 = i16 + 1;
          this.takeDoc(i17);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_sidereal_else_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/sidereal");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("ginger_sidereal_else");
          DialogueController.dc.initDialogue(this.doc.lines, "ginger_sidereal_else", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
          if (!GameDataController.gd.getObjective("outpost_spaceship_discovered"))
          {
            ++i17;
            this.takeDoc(i17);
            this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_sidereal_ship_caption");
            this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/ship");
            this.doc.lines = new List<DialogueLine>();
            this.doc.setObjective("ginger_sidereal_ship");
            DialogueController.dc.initDialogue(this.doc.lines, "ginger_sidereal_ship", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
          }
          i13 = i17 + 1;
          this.takeDoc(i13);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_sidereal_dreams_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/dreams");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("ginger_sidereal_dreams");
          DialogueController.dc.initDialogue(this.doc.lines, "ginger_sidereal_dreams", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        }
      }
      if (GameDataController.gd.getCurrentDay() == 2 && SceneManager.GetActiveScene().name == "LocationHouseB" && GameDataController.gd.getObjectiveDetail("dialogue_npc2_house_blocked") > 0 && !GameDataController.gd.getObjective("npc2_wife_note_given") && GameDataController.gd.getObjective("dialogue_npc2_intro"))
      {
        ++i13;
        this.takeDoc(i13);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_barry_busy_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/barry");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_ginger_barry_distracted");
        DialogueController.dc.initDialogue(this.doc.lines, "ginger_barry_busy", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        this.doc.lines[1].action = new TimelineFunction(this.drawGun);
        this.doc.lines[1].actionWithText = true;
        this.doc.lines[3].action = new TimelineFunction(this.holster);
        this.doc.lines[3].actionWithText = true;
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.goDistractBarry);
      }
      if (SceneManager.GetActiveScene().name == "LocationRestaurant2" && !GameDataController.gd.getObjective("restaurant_trash_moved") && GameDataController.gd.getObjective("restaurant_trash_tried") && (!GameDataController.gd.getObjective("npc3_alive") || GameDataController.gd.getObjective("dialogue_cody_intro")))
      {
        ++i13;
        this.takeDoc(i13);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_push_trash_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/push_trash");
        this.doc.lines = new List<DialogueLine>();
        DialogueController.dc.initDialogue(this.doc.lines, "ginger_push_trash", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.pushTrashCart);
      }
      if (!GameDataController.gd.getObjective("outpost_fingerprint_unlocked") && GameDataController.gd.getObjectiveDetail("outpost_underground_light") > 1 && SceneManager.GetActiveScene().name == "LocationOutpost4")
      {
        ++i13;
        this.takeDoc(i13);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "ginger_fingerprint_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/fingerprint");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective(string.Empty);
        this.doc.setObjective("dialogue_ginger_fingerprint");
        DialogueController.dc.initDialogue(this.doc.lines, "ginger_fingerprint", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.fingerPress);
      }
      if (GameDataController.gd.getObjective("gasstation_sarge_intro") && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getCurrentDay() == 3)
      {
        ++i13;
        this.takeDoc(i13);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dialogue_sarge_thugs_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/sarge");
        this.doc.lines = new List<DialogueLine>();
        if (GameDataController.gd.getObjective("gasstation_sarge_shot"))
        {
          this.doc.setObjective("dialogue_sarge_thugs4_cate");
          DialogueController.dc.initDialogue(this.doc.lines, "dialogue_sarge_thugs4_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        }
        else if (GameDataController.gd.getObjective("gasstation_sarge_convinced"))
        {
          if (GameDataController.gd.getObjective("previous_disc_barry") || GameDataController.gd.getObjective("previous_disc_cody"))
          {
            this.doc.setObjective("dialogue_sarge_thugs3_cate");
            DialogueController.dc.initDialogue(this.doc.lines, "dialogue_sarge_thugs3_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
          }
          else
          {
            this.doc.setObjective("dialogue_sarge_thugs2_cate");
            DialogueController.dc.initDialogue(this.doc.lines, "dialogue_sarge_thugs2_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
          }
        }
        else
        {
          this.doc.setObjective("dialogue_sarge_thugs1_cate");
          DialogueController.dc.initDialogue(this.doc.lines, "dialogue_sarge_thugs1_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
        }
      }
      if (GameDataController.gd.getObjective("restaurant_sarge_encountered") && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && GameDataController.gd.getCurrentDay() == 3)
      {
        ++i13;
        this.takeDoc(i13);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dialogue_sarge_storm_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/sarge");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dialogue_sarge_storm1_cate");
        DialogueController.dc.initDialogue(this.doc.lines, "dialogue_sarge_storm1_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
      }
      if (!GameDataController.gd.getObjective("thug_to_kill_bathroom") && GameDataController.gd.getObjective("thug_killed_bathroom") && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getCurrentDay() < 5)
      {
        ++i13;
        this.takeDoc(i13);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dialogue_razor_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/razor");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("d4_kill_razor_cate");
        DialogueController.dc.initDialogue(this.doc.lines, "d4_kill_razor0_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, GingerActionController.color);
        if (GameDataController.gd.getObjective("gasstation_sarge_shot") && GameDataController.gd.getObjective("cs_thug_shot"))
          DialogueController.dc.initDialogue(this.doc.lines, "d4_kill_razor3_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, GingerActionController.color);
        else if (GameDataController.gd.getObjective("gasstation_sarge_shot"))
          DialogueController.dc.initDialogue(this.doc.lines, "d4_kill_razor2_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, GingerActionController.color);
        else if (GameDataController.gd.getObjective("cs_thug_shot"))
          DialogueController.dc.initDialogue(this.doc.lines, "d4_kill_razor1_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, GingerActionController.color);
        if (GameDataController.gd.getObjective("gasstation_sarge_shot") || GameDataController.gd.getObjective("cs_thug_shot"))
          DialogueController.dc.initDialogue(this.doc.lines, "d4_kill_razor4_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, GingerActionController.color);
        else
          DialogueController.dc.initDialogue(this.doc.lines, "d4_kill_razor5_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, GingerActionController.color);
      }
      if (!GameDataController.gd.getObjective("thug_to_kill_bathroom") && !GameDataController.gd.getObjective("thug_killed_bathroom") && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getCurrentDay() == 4)
      {
        ++i13;
        this.takeDoc(i13);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dialogue_razor_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/razor");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("d4_spare_razor_cate");
        DialogueController.dc.initDialogue(this.doc.lines, "d4_spare_razor0_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, GingerActionController.color);
      }
      if (GameDataController.gd.getObjective("dialogue_ginger_dreams2") && GameDataController.gd.getObjective("dialogue_ginger_outpost"))
      {
        this.takeDoc(i13 + 1);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "exit_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective(string.Empty);
        if (GameDataController.gd.getObjective("dialogue_ginger_first_exit"))
        {
          DialogueController.dc.initDialogue(this.doc.lines, "ginger_exit", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
          this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(((NPCActionController) this).endTalk);
        }
        else
        {
          DialogueController.dc.initDialogue(this.doc.lines, "ginger_first_exit", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color);
          this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.firstEndTalk);
        }
      }
      this.takeDoc(0);
      if (!(this.doc.caption != string.Empty))
        return;
      DialogueController.dc.talking = true;
    }
  }

  public void fingerPress(string val = "")
  {
    this.gameObject.GetComponent<NPCWalkController>().setSimpleTargetV3(GameObject.Find("diode").transform.Find("Action_Marker").transform.position);
    DialogueController.dc.talking = false;
    DialogueController.dc.hide();
    PlayerController.pc.setBusy(true);
    Timeline.t.doNotUnlock = true;
    GameObject.Find("LocationManager").GetComponent<LocationOutpost4Start>().gingerShowFinger = true;
  }

  private void firstEndTalk(string val = "")
  {
    GameDataController.gd.setObjective("dialogue_ginger_first_exit", true);
    this.endTalk(string.Empty);
  }

  public override void clickAction2()
  {
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("dialogue_ginger_intro"))
      this.objectName = "npc_ginger";
    else
      this.objectName = "npc_cathy";
  }

  public override void clickAction0()
  {
  }

  public void goDistractBarry(string val = "")
  {
    if ((Object) this.currentLocationManager == (Object) null)
      this.currentLocationManager = GameObject.Find("Location").GetComponent<LocationManager>();
    DialogueController.dc.talking = false;
    Timeline.t.doNotUnlock = true;
    this.gameObject.GetComponent<NPCWalkController>().setBusy(false);
    PlayerController.pc.setBusy(true);
    List<Vector2> newTarget = this.currentLocationManager.Search2(this.currentLocationManager.findNearestClearNode(this.currentLocationManager.getNodeLocation(this.gameObject.GetComponent<NPCWalkController>().currentXY)), this.currentLocationManager.findNearestClearNode(this.currentLocationManager.getNodeLocation((Vector2) ScreenControler.roundToNearestFullPixel(GameObject.Find("BarryDistractPoint").transform.position))));
    newTarget.Insert(0, this.gameObject.GetComponent<NPCWalkController>().currentXY);
    this.gameObject.GetComponent<NPCWalkController>().setTarget(newTarget);
    GameDataController.gd.setObjectiveDetail("dialogue_ginger_barry_distracted", 0);
    GameDataController.gd.setObjective("dialogue_ginger_barry_distracted", true);
    this.Invoke("distractBarry1", 3f);
  }

  public void showMap(string val = "")
  {
    this.endTalk(string.Empty);
    ExamineSprite.es.textField.shift.x = -80f;
    ExamineSprite.es.textField.shift.y = -40f;
    ExamineSprite.es.readyText(new List<string>()
    {
      GameStrings.getString(GameStrings.dialogues, "ginger_map_view_1"),
      GameStrings.getString(GameStrings.dialogues, "ginger_map_view_2"),
      GameStrings.getString(GameStrings.dialogues, "ginger_map_view_3"),
      GameStrings.getString(GameStrings.dialogues, "ginger_map_view_4")
    }, 200, GingerActionController.color.x, GingerActionController.color.y, GingerActionController.color.z, 0.0f, 0.0f, 0.0f, 0.75f);
    ExamineSprite.es.cycleSprites = true;
    ExamineSprite.es.show(Resources.Load<Sprite>("Bitmaps/Locations/base/LocationAttic2/map1"), Resources.Load<Sprite>("Bitmaps/Locations/base/LocationAttic2/map1"), Resources.Load<Sprite>("Bitmaps/Locations/base/LocationAttic2/map2"), Resources.Load<Sprite>("Bitmaps/Locations/base/LocationAttic2/map3"), act: new ExamineSprite.Delegate(this.resumeAfterMap), actionOnOpen: false);
    if (GameDataController.gd.getObjectiveDetail("map_houseb_revealed") == TravelAgency.LOCATION_STATUS_UNDISCOVERED)
      GameDataController.gd.setObjectiveDetail("map_houseb_revealed", TravelAgency.LOCATION_STATUS_UNREACHABLE);
    if (GameDataController.gd.getObjectiveDetail("map_restaurant_revealed") != TravelAgency.LOCATION_STATUS_UNDISCOVERED)
      return;
    GameDataController.gd.setObjectiveDetail("map_restaurant_revealed", TravelAgency.LOCATION_STATUS_UNREACHABLE);
  }

  public void resumeAfterMap()
  {
    DialogueController.dc.talking = true;
    DialogueController.dc.show();
  }

  public void drawGun(string val = "") => this.gameObject.GetComponent<NPCWalkController>().forceAnimation("gun_draw", this.gameObject.GetComponent<NPCWalkController>().flipped());

  public void aimGun(string val = "")
  {
    bool flip = true;
    if (val == "right")
      flip = false;
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("gun_take_aim", flip);
  }

  public void holdGunUp(string val = "")
  {
    bool flip = true;
    if (val == "right")
      flip = false;
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("gun_aim_up", flip);
  }

  public void aimDown(string val = "")
  {
    bool flip = true;
    if (val == "right")
      flip = false;
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("gun_aim_down", flip);
  }

  public void holster(string val = "")
  {
    bool flip = this.gameObject.GetComponent<NPCWalkController>().flipped();
    if (val == "right")
      flip = false;
    if (val == "left")
      flip = true;
    this.gameObject.GetComponent<NPCWalkController>().forceAnimation("gun_holster", flip);
    GameDataController.gd.setObjective("dialogue_ginger_intro", true);
  }

  public void openThePodBayDoors(string a = "")
  {
    DialogueController.dc.talking = false;
    DialogueController.dc.hide();
    PlayerController.pc.setBusy(false);
    GameDataController.gd.setObjective("moon_pods_unlocked", true);
    GameObject.Find("Moonbase3Pad1").GetComponent<Moonbase3Pod>().openIfNeeded();
    GameObject.Find("Moonbase3Pad2").GetComponent<Moonbase3Pod>().openIfNeeded();
    GameObject.Find("Moonbase3Pad3").GetComponent<Moonbase3Pod>().openIfNeeded();
    GameObject.Find("Moonbase3Pad4").GetComponent<Moonbase3Pod>().openIfNeeded();
  }

  public void killRazor(string a = "")
  {
    GameDataController.gd.setObjective("location01_door2_locked", false);
    GameDataController.gd.setObjective("location01_door2_open", true);
    if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 1)
    {
      GameDataController.gd.setObjectiveDetail("towel_1_at_door", 0);
      Item obj = ItemsManager.im.getItem("towel_1");
      obj.dataRef.locX = 35;
      obj.dataRef.locY = 35;
      obj.dataRef.droppedLocation = "Location1";
    }
    if (GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 1)
    {
      GameDataController.gd.setObjectiveDetail("towel_2_at_door", 0);
      Item obj = ItemsManager.im.getItem("towel_2");
      obj.dataRef.locX = 35;
      obj.dataRef.locY = 35;
      obj.dataRef.droppedLocation = "Location1";
    }
    DialogueController.dc.talking = false;
    Timeline.t.doNotUnlock = true;
    PlayerController.pc.setBusy(true);
    GameDataController.gd.setObjective("thug_to_kill_bathroom", false);
    GameDataController.gd.setObjective("thug_killed_bathroom", true);
    PlayerController.pc.spawnName = "Day4_morning";
    CurtainController.cc.fadeOut("LocationBaseOutside1", WalkController.Direction.N, "stand_n", SoundsManagerController.sm.rifle_shoot);
  }

  public void spareRazor(string a = "")
  {
    GameDataController.gd.setObjective("location01_door2_locked", false);
    GameDataController.gd.setObjective("location01_door2_open", true);
    if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 1)
    {
      GameDataController.gd.setObjectiveDetail("towel_1_at_door", 0);
      Item obj = ItemsManager.im.getItem("towel_1");
      obj.dataRef.locX = 35;
      obj.dataRef.locY = 35;
      obj.dataRef.droppedLocation = "Location1";
    }
    if (GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 1)
    {
      GameDataController.gd.setObjectiveDetail("towel_2_at_door", 0);
      Item obj = ItemsManager.im.getItem("towel_2");
      obj.dataRef.locX = 35;
      obj.dataRef.locY = 35;
      obj.dataRef.droppedLocation = "Location1";
    }
    DialogueController.dc.talking = false;
    Timeline.t.doNotUnlock = true;
    PlayerController.pc.setBusy(true);
    GameDataController.gd.setObjective("thug_killed_bathroom", false);
    GameDataController.gd.setObjective("thug_to_kill_bathroom", false);
    PlayerController.pc.spawnName = "Day4_morning";
    CurtainController.cc.fadeOut("LocationBaseOutside1", WalkController.Direction.N, "stand_n");
  }

  public void evaluateRazor(string a = "")
  {
    int num = 0;
    if (GameDataController.gd.getObjective("dialogue_ginger_thug_kill_waste"))
      ++num;
    if (GameDataController.gd.getObjective("dialogue_ginger_thug_kill_lesson"))
      ++num;
    if (GameDataController.gd.getObjective("dialogue_ginger_thug_kill_better"))
      ++num;
    if (GameDataController.gd.getObjective("dialogue_ginger_thug_kill_end_anyway"))
      ++num;
    if (num < 2)
      return;
    this.instantLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.instantLines, "thug_kill_not", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GingerActionController.color, GameObject.Find("thug").GetComponent<TextFieldController>(), new Vector3(0.588f, 0.15f, 0.43f));
    this.instantLines[this.instantLines.Count - 1].action = new TimelineFunction(this.spareRazor);
    for (int index = 0; index < this.instantLines.Count; ++index)
      Timeline.t.addDialogue(this.instantLines[index]);
  }

  public void mourn()
  {
    if (!GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjectiveDetail("npc2_alive") == 1)
    {
      DialogueController.dc.quickDialogue(GingerActionController.color, (NPCActionController) this, "ginger_sidereal_barry_mourn");
      Timeline.t.actions[Timeline.t.actions.Count - 1].function = new TimelineFunction(this.mourned);
    }
    else
    {
      if (GameDataController.gd.getObjective("npc3_alive") || GameDataController.gd.getObjectiveDetail("npc3_alive") != 1)
        return;
      DialogueController.dc.quickDialogue(GingerActionController.color, (NPCActionController) this, "ginger_sidereal_cody_mourn");
      Timeline.t.actions[Timeline.t.actions.Count - 1].function = new TimelineFunction(this.mourned);
    }
  }

  public void mourned(string t = "") => GameDataController.gd.setObjective("dialogue_ginger_dead_mourned", true);

  public void pushTrashCart(string val = "")
  {
    DialogueController.dc.talking = false;
    Timeline.t.doNotUnlock = true;
    this.gameObject.GetComponent<NPCWalkController>().setBusy(false);
    PlayerController.pc.setBusy(true);
    Object.FindObjectOfType<Restaurant2Trash>().pushLittleCart_Cate();
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

  public void distractBarry1()
  {
    this.endTalk(string.Empty);
    this.distractBarry();
    PlayerController.pc.setBusy(false);
  }

  public void distractBarry()
  {
    if (!GameDataController.gd.getObjective("dialogue_ginger_barry_distracted"))
      return;
    if ((Object) this.distractBarryTextfield != (Object) null)
      this.distractBarryTextfield.dissmiss();
    GameObject.Find("Npc2").GetComponent<NPCWalkController>().forceAnimation("npc2_mourn_look", true);
    int detail = GameDataController.gd.getObjectiveDetail("dialogue_ginger_barry_distracted") + 1;
    if (detail > 14)
      detail = 1;
    GameDataController.gd.setObjectiveDetail("dialogue_ginger_barry_distracted", detail);
    MonoBehaviour.print((object) ("GINGER DISTRACTION AT " + (object) GameDataController.gd.getObjectiveDetail("dialogue_ginger_barry_distracted")));
    Vector3 vector3 = new Vector3();
    string str1 = GameStrings.getString(GameStrings.dialogues, "ginger_barry_talk_" + (object) detail + "_a");
    string str2 = GameStrings.getString(GameStrings.dialogues, "ginger_barry_talk_" + (object) detail + "_b");
    string empty = string.Empty;
    string text;
    Vector3 color;
    if (str1.IndexOf("_STRING_MISSING") == -1)
    {
      text = str1;
      color = GingerActionController.getColor();
      this.distractBarryTextfield = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    }
    else
    {
      text = str2;
      color = Npc2Controller.getColor();
      this.distractBarryTextfield = GameObject.Find("Npc2").GetComponent<TextFieldController>();
    }
    this.distractBarryTextfield.viewText(text, mwidth: 100, r: color.x, g: color.y, b: color.z);
    this.Invoke(nameof (distractBarry), 5f);
  }

  public void unlockDistraction(string val = "") => this.gameObject.GetComponent<NPCWalkController>().setTargetV3(GameObject.Find("WaypointHouseB2").transform.Find("GingerSpawner").transform.Find("NPCTarget").transform.position);

  public void setDistractFalse(string val = "") => GameDataController.gd.setObjective("dialogue_ginger_barry_distracted", false);

  public void distractBarryEnd()
  {
    GameObject.Find("Npc2").GetComponent<NPCWalkController>().forceAnimation("npc2_mourn_look", true);
    GameDataController.gd.setObjectiveDetail("dialogue_ginger_barry_distracted", 0);
    DialogueController.dc.reset();
    List<DialogueLine> dialogueLineList = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLineList, "ginger_barry_talk_end", GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor());
    dialogueLineList[0].action = new TimelineFunction(this.setDistractFalse);
    dialogueLineList[0].actionWithText = true;
    dialogueLineList[1].action = new TimelineFunction(this.unlockDistraction);
    dialogueLineList[1].actionWithText = false;
    Timeline.t.addDialogueLines(dialogueLineList);
  }

  public void initFindShipDialogue()
  {
    List<DialogueLine> dialogueLineList = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLineList, "ginger_barry_talk_end", GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor());
    Timeline.t.addDialogueLines(dialogueLineList);
  }
}
