﻿// Decompiled with JetBrains decompiler
// Type: Waypoint_Outside_Crossroad
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class Waypoint_Outside_Crossroad : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "down_hill";
    this.doubleClickCondition = "visited_crossroad";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.S;
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "Waypoint_Crossroad_Base";
    CurtainController.cc.fadeOut("LocationCrossroad", WalkController.Direction.S);
  }

  public override void updateState() => this.colliderManager.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
