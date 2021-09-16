﻿// Decompiled with JetBrains decompiler
// Type: Waypoint_RV_Crashsite
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class Waypoint_RV_Crashsite : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "base_exit";
    this.doubleClickCondition = "visited_rv";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.S;
    this.range = 10f;
  }

  public override void clickAction()
  {
    PlayerController.pc.setBusy(true);
    GameDataController.gd.setObjectiveDetail("map_rv_revealed", TravelAgency.LOCATION_STATUS_REACHABLE);
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("LocationMap", WalkController.Direction.E);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("car_location") == 6)
      this.setCollider(1);
    else
      this.setCollider(0);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
