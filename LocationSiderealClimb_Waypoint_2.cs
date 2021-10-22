// Decompiled with JetBrains decompiler
// Type: LocationSiderealClimb_Waypoint_2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class LocationSiderealClimb_Waypoint_2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_climb2";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.W;
    this.range = 2f;
  }

  public override void clickAction() => QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "sidereal_climbing_down"), yesClick: new Button.Delegate(this.climb), time: 5);

  private void climb()
  {
    PlayerController.pc.spawnName = "SiderealOutside2_Waypoint_Climb";
    CurtainController.cc.fadeOut("SiderealOutside2", WalkController.Direction.S);
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
