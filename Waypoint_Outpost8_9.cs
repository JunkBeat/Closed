// Decompiled with JetBrains decompiler
// Type: Waypoint_Outpost8_9
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class Waypoint_Outpost8_9 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_elev_up";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.range = 2f;
    this.doubleClickCondition = string.Empty;
  }

  public override void clickAction()
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.button_click);
    if (GameDataController.gd.getObjective("outpost_belt_elevator"))
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.elevator_away);
      PlayerController.pc.spawnName = "Waypoint_Outpost9_8";
      CurtainController.cc.fadeOut("LocationOutpost9", WalkController.Direction.S, tSpeed: 0.015f);
    }
    else
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.engine_wrong);
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "elevator_not_working"));
    }
  }

  public void rideDown()
  {
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("outpost_belt_elevator"))
      this.actionType = ObjectActionController.Type.Transition;
    else
      this.actionType = ObjectActionController.Type.NormalAction;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
