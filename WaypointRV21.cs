// Decompiled with JetBrains decompiler
// Type: WaypointRV21
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class WaypointRV21 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "rv_exit";
    this.actionType = ObjectActionController.Type.Transition;
    this.doubleClickCondition = "visited_rv_inside";
    this.trans_dir = WalkController.Direction.S;
    this.range = 2f;
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "WaypointRV12";
    CurtainController.cc.fadeOut("LocationRV", WalkController.Direction.S);
  }

  public override void updateState() => this.colliderManager.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
