// Decompiled with JetBrains decompiler
// Type: LocationSiderealF0S_Waypoint_C
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class LocationSiderealF0S_Waypoint_C : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_exit3";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.E;
    this.doubleClickCondition = "visited_sidereal_f0c";
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "LocationSiderealF0C_Waypoint_S";
    CurtainController.cc.fadeOut("SiderealF0C0a", WalkController.Direction.E);
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
