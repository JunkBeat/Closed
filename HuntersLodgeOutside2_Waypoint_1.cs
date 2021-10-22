// Decompiled with JetBrains decompiler
// Type: HuntersLodgeOutside2_Waypoint_1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class HuntersLodgeOutside2_Waypoint_1 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "lodge_to_front";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.W;
    this.doubleClickCondition = "visited_hunters_lodge_outside_1";
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "HuntersLodgeOutside1_Waypoint_2";
    CurtainController.cc.fadeOut("HuntersLodgeOutside1", WalkController.Direction.W);
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
