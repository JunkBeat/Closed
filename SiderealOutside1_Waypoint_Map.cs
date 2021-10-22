// Decompiled with JetBrains decompiler
// Type: SiderealOutside1_Waypoint_Map
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class SiderealOutside1_Waypoint_Map : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "back_to_road";
    this.doubleClickCondition = "visited_sidereal_outside_1";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.S;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("sidereal_base_located"))
    {
      PlayerController.pc.setBusy(true);
      PlayerController.pc.spawnName = "InfoExit";
      CurtainController.cc.fadeOut("LocationMap", WalkController.Direction.S);
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_cant_leave"));
  }

  public override void whatOnClick0()
  {
    if (!GameDataController.gd.getObjective("sidereal_base_located"))
      this.range = 100f;
    else
      this.range = 2f;
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjectiveDetail("car_location") == 8)
      return;
    this.colliderManager.setCollider(1);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
