// Decompiled with JetBrains decompiler
// Type: Waypoint_Outpost4_5
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class Waypoint_Outpost4_5 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_corridor2";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.W;
    this.range = 2f;
    this.doubleClickCondition = "visited_outpost5";
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "Waypoint_Outpost5_4";
    if (GameDataController.gd.getObjective("visited_outpost5"))
      CurtainController.cc.fadeOut("LocationOutpost5", WalkController.Direction.W);
    else
      CurtainController.cc.fadeOut("LocationOutpost5", WalkController.Direction.W, "walk_e", flipX: true);
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
