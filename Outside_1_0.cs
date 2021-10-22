// Decompiled with JetBrains decompiler
// Type: Outside_1_0
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class Outside_1_0 : ObjectActionController
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
    this.doubleClickCondition = "visited_baseOutside0";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "Waypoint_0_1";
    CurtainController.cc.fadeOut("LocationBaseOutside0", WalkController.Direction.NE);
  }

  public override void updateState() => this.colliderManager.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
