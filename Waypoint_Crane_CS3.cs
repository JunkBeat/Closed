// Decompiled with JetBrains decompiler
// Type: Waypoint_Crane_CS3
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class Waypoint_Crane_CS3 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_crane";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.S;
    this.doubleClickCondition = string.Empty;
  }

  public override void clickAction() => QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "climb_down_crane"), yesClick: new Button.Delegate(this.climbCrane));

  public void climbCrane()
  {
    GameDataController.gd.setObjective("cs_rain_enter_left", true);
    PlayerController.pc.spawnName = "Waypoint_CS3_Crane";
    CurtainController.cc.fadeOut("CS3", WalkController.Direction.S);
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
