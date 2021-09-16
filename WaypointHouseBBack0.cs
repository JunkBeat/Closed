// Decompiled with JetBrains decompiler
// Type: WaypointHouseBBack0
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

public class WaypointHouseBBack0 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "house_b_back_waypoint0";
    this.actionType = ObjectActionController.Type.Transition;
    this.doubleClickCondition = "visited_house_b";
    this.trans_dir = WalkController.Direction.E;
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "WaypointHouseB1";
    CurtainController.cc.fadeOut("LocationHouseB", WalkController.Direction.W);
  }

  public override void updateState() => this.colliderManager.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
