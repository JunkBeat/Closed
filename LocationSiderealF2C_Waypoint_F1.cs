// Decompiled with JetBrains decompiler
// Type: LocationSiderealF2C_Waypoint_F1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

public class LocationSiderealF2C_Waypoint_F1 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_stairs_down";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.S;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjectiveDetail("map_outpost_revealed") == TravelAgency.LOCATION_STATUS_UNDISCOVERED)
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_cant_go_yet"));
    }
    else
    {
      PlayerController.pc.spawnName = "LocationSiderealF1C_Waypoint_F2";
      CurtainController.cc.fadeOut("SiderealF1C", WalkController.Direction.S);
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("map_outpost_revealed") == TravelAgency.LOCATION_STATUS_UNDISCOVERED)
      this.doubleClickCondition = string.Empty;
    else
      this.doubleClickCondition = "visited_sidereal_f1c";
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
