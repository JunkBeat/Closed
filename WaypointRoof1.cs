// Decompiled with JetBrains decompiler
// Type: WaypointRoof1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class WaypointRoof1 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "roof_other_part";
    this.actionType = ObjectActionController.Type.Transition;
    this.doubleClickCondition = "visited_roof2";
    this.range = 10f;
    this.trans_dir = WalkController.Direction.W;
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "WaypointRoof2";
    CurtainController.cc.fadeOut("LocationRoof2", WalkController.Direction.W);
  }

  public override void updateState() => this.colliderManager.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
