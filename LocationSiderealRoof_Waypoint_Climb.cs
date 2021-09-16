// Decompiled with JetBrains decompiler
// Type: LocationSiderealRoof_Waypoint_Climb
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class LocationSiderealRoof_Waypoint_Climb : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_climb";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.W;
    this.range = 2f;
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "LocationSiderealClimb_Waypoint_Roof";
    CurtainController.cc.fadeOut("SiderealClimb", WalkController.Direction.W);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("sidereal_roof_collapsed"))
      this.colliderManager.setCollider(-1);
    else
      this.colliderManager.setCollider(0);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
