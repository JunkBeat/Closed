// Decompiled with JetBrains decompiler
// Type: Waypoint_Gasstation1_GasstationRoom1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class Waypoint_Gasstation1_GasstationRoom1 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_entry1";
    this.doubleClickCondition = "visited_gasstationRoom1";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.range = 1f;
  }

  public override void clickAction()
  {
    GameDataController.gd.setObjectiveDetail("gasstation_spider_discovered", 1);
    PlayerController.pc.spawnName = "Waypoint_GasstationRoom1_Gasstation1";
    string animation = (string) null;
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited"))
      animation = "action_stnd_s";
    CurtainController.cc.fadeOut("LocationGasstationRoom1", WalkController.Direction.S, animation);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjective("gasstation_spider_baited") && !GameDataController.gd.getObjective("gasstation_spider_shot") && ItemsManager.im.getItem("rifle_6").dataRef.droppedLocation.ToLower().IndexOf("inventory") != -1)
      this.colliderManager.setCollider(-1);
    else
      this.colliderManager.setCollider(0);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
