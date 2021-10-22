// Decompiled with JetBrains decompiler
// Type: Waypoint_Crossroad_Base
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class Waypoint_Crossroad_Base : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "up_hill";
    this.doubleClickCondition = "visited_baseOutside1";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "Waypoint_Outside_Crossroad";
    CurtainController.cc.fadeOut("LocationBaseOutside1", WalkController.Direction.N);
  }

  public override void updateState() => this.colliderManager.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
