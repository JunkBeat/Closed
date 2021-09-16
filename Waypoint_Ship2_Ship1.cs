// Decompiled with JetBrains decompiler
// Type: Waypoint_Ship2_Ship1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class Waypoint_Ship2_Ship1 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "climb_ladder_up";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "ship_ladder_up";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.range = 0.0f;
    this.doubleClickCondition = "visited_outpost_ship1";
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "Waypoint_Ship1_Ship2";
    CurtainController.cc.fadeOut("LocationShip1", WalkController.Direction.E);
  }

  public void rideDown()
  {
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
