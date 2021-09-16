// Decompiled with JetBrains decompiler
// Type: Waypoint_CS3_Crane
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

public class Waypoint_CS3_Crane : ObjectActionController
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
    this.trans_dir = WalkController.Direction.N;
    this.doubleClickCondition = string.Empty;
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("cs_rain_enter_left") && !GameDataController.gd.getObjective("cs_pack_lifted"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cant_reach"));
    else
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "climb_up_crane"), yesClick: new Button.Delegate(this.climbCrane), time: 5);
  }

  private void climbCrane()
  {
    PlayerController.pc.spawnName = "Waypoint_Crane_CS3";
    CurtainController.cc.fadeOut("CS_Crane", WalkController.Direction.E);
  }

  public override void updateState()
  {
    this.setCollider(0);
    if (!GameDataController.gd.getObjective("cs_rain_enter_left") && !GameDataController.gd.getObjective("cs_pack_lifted"))
    {
      this.range = 200f;
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
    else
    {
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 1f;
    }
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
      return;
    this.setCollider(-1);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
