﻿// Decompiled with JetBrains decompiler
// Type: SiderealOutside2_Waypoint_3
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class SiderealOutside2_Waypoint_3 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_outside_back2";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.E;
    this.doubleClickCondition = "visited_sidereal_outside_3";
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "SiderealOutside3_Waypoint_2";
    CurtainController.cc.fadeOut("SiderealOutside3", WalkController.Direction.E);
  }

  public override void updateState()
  {
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
