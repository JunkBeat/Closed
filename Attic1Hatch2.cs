// Decompiled with JetBrains decompiler
// Type: Attic1Hatch2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class Attic1Hatch2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_up_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "attic_hatch2";
    this.range = 5f;
    this.doubleClickCondition = "visited_roof";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("blanket", GameStrings.getString(GameStrings.actions, "roof_hatch_no_need"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanketb", GameStrings.getString(GameStrings.actions, "roof_hatch_no_need"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("thermalb", GameStrings.getString(GameStrings.actions, "roof_hatch_no_need"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("flag", GameStrings.getString(GameStrings.actions, "roof_hatch_no_need"), anim: string.Empty));
    this.trans_dir = WalkController.Direction.N;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && (!GameDataController.gd.getObjective("lighting_rod_installed") || GameDataController.gd.getObjectiveDetail("day3_complete") < 1))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "no_roof"));
    else if (!GameDataController.gd.getObjective("attic_hatch_open"))
    {
      GameDataController.gd.setObjective("attic_hatch_open", true);
      this.updateAll();
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_creak1);
      GameObject.Find("LocationManager").GetComponent<LoctionAttic1Start>().backgroundCheck();
    }
    else
    {
      PlayerController.pc.spawnName = "WaypointRoof1Hatch";
      CurtainController.cc.fadeOut("LocationRoof1", WalkController.Direction.W, "kneel_out_se", flipX: true);
    }
  }

  public override void updateState()
  {
    this.range = 5f;
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && (!GameDataController.gd.getObjective("lighting_rod_installed") || GameDataController.gd.getObjectiveDetail("day3_complete") < 1))
    {
      this.actionType = ObjectActionController.Type.NormalAction;
      this.characterAnimationName = "action_stnd_";
      this.useCurrentDirection = true;
      this.doubleClickCondition = "none";
      this.objectName = "attic_roof_destroyed";
      this.setCollider(0);
      this.range = 100f;
      this.interactions = new List<ItemInteraction>();
    }
    else if (!GameDataController.gd.getObjective("attic_hatch_open"))
    {
      this.actionType = ObjectActionController.Type.NormalAction;
      this.characterAnimationName = "action_up_n";
      this.useCurrentDirection = false;
      this.doubleClickCondition = "none";
      this.objectName = "attic_hatch2";
      this.setCollider(0);
    }
    else
    {
      this.actionType = ObjectActionController.Type.Transition;
      this.characterAnimationName = "stop";
      this.useCurrentDirection = true;
      this.setCollider(1);
      this.doubleClickCondition = "visited_roof";
      this.objectName = "attic_hatch2";
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
