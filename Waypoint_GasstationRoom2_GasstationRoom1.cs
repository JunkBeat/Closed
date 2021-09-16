// Decompiled with JetBrains decompiler
// Type: Waypoint_GasstationRoom2_GasstationRoom1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

public class Waypoint_GasstationRoom2_GasstationRoom1 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_room1_entry";
    this.doubleClickCondition = "visited_gasstationRoom1";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.W;
  }

  public override void clickAction()
  {
    GameDataController.gd.setObjectiveDetail("gasstation_spider_discovered", 2);
    PlayerController.pc.spawnName = "Waypoint_GasstationRoom1_GasstationRoom2";
    string animation = (string) null;
    bool flipX = false;
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited"))
    {
      animation = "action_stnd_se";
      flipX = true;
    }
    CurtainController.cc.fadeOut("LocationGasstationRoom1", WalkController.Direction.W, animation, flipX: flipX);
  }

  public override void updateState() => this.colliderManager.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
