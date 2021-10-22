// Decompiled with JetBrains decompiler
// Type: Waypoint_Outpost9_Ship1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class Waypoint_Outpost9_Ship1 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_ship_inside";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.W;
    this.range = 2f;
    this.doubleClickCondition = "visited_ship1";
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "Waypoint_Ship1_Outpost9";
    CurtainController.cc.fadeOut("LocationShip1", WalkController.Direction.S);
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
