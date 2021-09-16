// Decompiled with JetBrains decompiler
// Type: Waypoint_Crashsite2_Pesttruck
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class Waypoint_Crashsite2_Pesttruck : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "pest_truck_locked";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("paperclip", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("pipe", GameStrings.getString(GameStrings.actions, "pest_truck_locked_pipe"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("crowbar", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("key2", GameStrings.getString(GameStrings.actions, "key_pesttruck"), anim: string.Empty));
    this.trans_dir = WalkController.Direction.E;
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
    {
      if (GameDataController.gd.getObjective("pesttruck_unlocked"))
        this.objectName = "pest_truck";
      else
        this.objectName = "pest_truck_locked";
    }
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
    {
      if (GameDataController.gd.getObjective("pesttruck_unlocked"))
        this.objectName = "gas_truck";
      else
        this.objectName = "gas_truck_locked";
    }
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 2)
      return;
    if (GameDataController.gd.getObjective("pesttruck_unlocked"))
      this.objectName = "pest_truck";
    else
      this.objectName = "pest_truck_locked";
  }

  public override void clickAction()
  {
    PlayerController.wc.forceDirection(WalkController.Direction.E);
    if (GameDataController.gd.getObjective("pesttruck_unlocked"))
    {
      PlayerController.pc.spawnName = "Waypoint_Pesttruck_Crashsite2";
      CurtainController.cc.fadeOut("LocationPesttruck", WalkController.Direction.E);
    }
    else if (this.usedItem == "crowbar")
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.crowbar_pry_open);
    else if (this.usedItem == "paperclip")
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "pesttruck_locker"), yesClick: new Button.Delegate(this.yesClicked), time: 15);
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "pest_truck_locked"), true);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("pesttruck_unlocked"))
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.actionType = ObjectActionController.Type.Transition;
    }
    else
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker2").gameObject;
      this.actionType = ObjectActionController.Type.NormalAction;
    }
    if (GameDataController.gd.getObjective("pesttruck_unlocked"))
    {
      this.interactions = new List<ItemInteraction>();
      this.gameObject.GetComponent<Animator>().Play("crashsitetruckdoor_opened", 0);
      this.colliderManager.setCollider(0);
    }
    else
    {
      this.interactions = new List<ItemInteraction>();
      this.interactions.Add(new ItemInteraction("paperclip", string.Empty, anim: string.Empty));
      this.interactions.Add(new ItemInteraction("pipe", GameStrings.getString(GameStrings.actions, "pest_truck_locked_pipe"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("crowbar", string.Empty, anim: string.Empty));
      this.interactions.Add(new ItemInteraction("key2", GameStrings.getString(GameStrings.actions, "key_pesttruck"), anim: string.Empty));
      this.gameObject.GetComponent<Animator>().Play("crashsitetruckdoor_closed", 0);
      this.colliderManager.setCollider(0);
    }
  }

  public override void clickAction2()
  {
    if (GameDataController.gd.getObjective("pesttruck_unlocked"))
    {
      if (!(this.usedItem == string.Empty))
        return;
      PlayerController.pc.spawnName = "Waypoint_Pesttruck_Crashsite2";
      CurtainController.cc.fadeOut("LocationPesttruck", WalkController.Direction.E);
    }
    else if (this.usedItem == "crowbar")
    {
      GameDataController.gd.setObjective("pesttruck_unlocked", true);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<Animator>().Play("crashsitetruckdoor_open", 0);
    }
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "pest_truck_locked"), true);
  }

  public override void whatOnClick()
  {
    if (!GameDataController.gd.getObjective("pesttruck_unlocked"))
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker2").gameObject;
      this.doubleClickCondition = string.Empty;
    }
    else
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.doubleClickCondition = "visited_pestTruck";
    }
    if (this.usedItem == "crowbar")
    {
      if (!GameDataController.gd.getObjective("pesttruck_unlocked"))
      {
        this.characterAnimationName = "crowbar_e";
        this.useCurrentDirection = false;
      }
      else
      {
        this.characterAnimationName = "action_stnd_";
        this.useCurrentDirection = true;
      }
    }
    else if (this.usedItem == "paperclip")
    {
      this.characterAnimationName = "stop";
      this.useCurrentDirection = true;
    }
    else if (!GameDataController.gd.getObjective("pesttruck_unlocked"))
    {
      this.characterAnimationName = "action_stnd_e";
      this.useCurrentDirection = false;
    }
    else
    {
      this.characterAnimationName = string.Empty;
      this.useCurrentDirection = false;
    }
  }

  private void yesClicked()
  {
    GameDataController.gd.setObjective("pesttruck_unlocked", true);
    PlayerController.wc.forceDirection(WalkController.Direction.E);
    CurtainController.cc.fadeOut();
  }

  public override void clickAction0()
  {
  }
}
