// Decompiled with JetBrains decompiler
// Type: LocationBusWaypointMap
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class LocationBusWaypointMap : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "exit_wasteland";
    this.doubleClickCondition = "visited_bus1";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.S;
    this.range = 10f;
  }

  public override void clickAction()
  {
    PlayerController.pc.setBusy(true);
    GameDataController.gd.setObjectiveDetail("map_bus_revealed", TravelAgency.LOCATION_STATUS_REACHABLE);
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("LocationMap", WalkController.Direction.E);
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjectiveDetail("car_location") == 11)
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
