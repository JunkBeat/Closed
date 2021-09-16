// Decompiled with JetBrains decompiler
// Type: SiderealOutside2_Waypoint_Climb
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class SiderealOutside2_Waypoint_Climb : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_climb";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.range = 2f;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("sidereal_roof_collapsed"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_climb_collapsed"));
    else
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "sidereal_climbing_up"), yesClick: new Button.Delegate(this.climb), time: 5);
  }

  private void climb()
  {
    PlayerController.pc.spawnName = "LocationSiderealClimb_Waypoint_2";
    CurtainController.cc.fadeOut("SiderealClimb", WalkController.Direction.E);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("sidereal_roof_collapsed"))
    {
      this.range = 100f;
      this.characterAnimationName = "action_stnd_";
    }
    else
    {
      this.range = 2f;
      this.characterAnimationName = "action_stnd_";
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
