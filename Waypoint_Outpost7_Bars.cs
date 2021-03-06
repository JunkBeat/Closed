// Decompiled with JetBrains decompiler
// Type: Waypoint_Outpost7_Bars
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class Waypoint_Outpost7_Bars : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_computer_bars1";
    this.actionType = ObjectActionController.Type.NormalAction;
    this.trans_dir = WalkController.Direction.N;
    this.range = 2f;
    this.doubleClickCondition = string.Empty;
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "OutpostBarsExit";
    CurtainController.cc.fadeOut("LocationBarsPuzzle", WalkController.Direction.S);
  }

  public void rideDown()
  {
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 1)
      this.objectName = "outpost_computer_bars1";
    else
      this.objectName = "outpost_computer_bars2";
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
