// Decompiled with JetBrains decompiler
// Type: LocationSiderealF0C_Waypoint_F1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

public class LocationSiderealF0C_Waypoint_F1 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_elevator_1";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.doubleClickCondition = string.Empty;
  }

  public override void clickAction() => QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "sidereal_elevator_up"), yesClick: new Button.Delegate(this.climb), time: 5);

  private void climb()
  {
    PlayerController.pc.spawnName = "elevator_door";
    CurtainController.cc.fadeOut("SiderealF1C", WalkController.Direction.W);
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
