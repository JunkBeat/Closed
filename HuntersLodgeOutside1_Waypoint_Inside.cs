// Decompiled with JetBrains decompiler
// Type: HuntersLodgeOutside1_Waypoint_Inside
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class HuntersLodgeOutside1_Waypoint_Inside : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "lodge_to_inside";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.doubleClickCondition = "visited_hunters_lodge_inside_1";
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "HuntersLodgeInside1_Waypoint_Outside";
    CurtainController.cc.fadeOut("HuntersLodgeInside1", WalkController.Direction.E);
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
