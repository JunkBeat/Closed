﻿// Decompiled with JetBrains decompiler
// Type: CS1_Waypoint_Map
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class CS1_Waypoint_Map : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "back_to_road";
    this.doubleClickCondition = "visited_cs_1";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.E;
  }

  public override void clickAction()
  {
    PlayerController.pc.setBusy(true);
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("LocationMap", WalkController.Direction.S);
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjectiveDetail("car_location") != 9)
      return;
    this.colliderManager.setCollider(1);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
