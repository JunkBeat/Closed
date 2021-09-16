﻿// Decompiled with JetBrains decompiler
// Type: LocationMoonbase1_3
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class LocationMoonbase1_3 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "moonbase_passage";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.W;
    this.doubleClickCondition = "moon_allow_fast_travel_now";
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "LocationMoonbase3_1";
    if (!GameDataController.gd.getObjective("visited_moonbase3"))
      CurtainController.cc.fadeOut("LocationMoonbase3", WalkController.Direction.W, "walk_e");
    else
      CurtainController.cc.fadeOut("LocationMoonbase3", WalkController.Direction.W);
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
