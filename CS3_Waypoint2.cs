// Decompiled with JetBrains decompiler
// Type: CS3_Waypoint2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class CS3_Waypoint2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_in_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_waypoint_2_3";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.W;
    this.doubleClickCondition = "visited_cs_2";
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && !GameDataController.gd.getObjective("cs_rain_enter_left") && !GameDataController.gd.getObjective("cs_pack_lifted"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cant_reach"));
    }
    else
    {
      GameDataController.gd.setObjective("cs_arrive_from_inside", true);
      if (!GameDataController.gd.getObjective("cs_safe"))
        GameDataController.gd.setObjective("cs_crow_away", false);
      else
        GameDataController.gd.setObjective("cs_crow_away", true);
      PlayerController.pc.spawnName = "CS2_Waypoint_3";
      CurtainController.cc.fadeOut("CS2", WalkController.Direction.S);
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && !GameDataController.gd.getObjective("cs_rain_enter_left") && !GameDataController.gd.getObjective("cs_pack_lifted"))
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 200f;
      this.doubleClickCondition = string.Empty;
    }
    else
    {
      this.characterAnimationName = "kneel_in_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.range = 1f;
      this.doubleClickCondition = "visited_cs_2";
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
