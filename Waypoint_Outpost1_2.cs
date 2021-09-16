// Decompiled with JetBrains decompiler
// Type: Waypoint_Outpost1_2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class Waypoint_Outpost1_2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_approach";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.doubleClickCondition = "visited_outpost2";
  }

  public override void clickAction() => this.gothere(string.Empty);

  public void gothere(string aaa = "")
  {
    PlayerController.pc.spawnName = "Waypoint_Outpost2_1";
    CurtainController.cc.fadeOut("LocationOutpostOutside2", WalkController.Direction.NE);
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
