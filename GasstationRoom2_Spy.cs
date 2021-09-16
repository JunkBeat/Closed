// Decompiled with JetBrains decompiler
// Type: GasstationRoom2_Spy
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class GasstationRoom2_Spy : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_window";
    this.actionType = ObjectActionController.Type.NormalAction;
    this.trans_dir = WalkController.Direction.N;
    this.range = 2f;
    this.teleport = false;
  }

  public override void clickAction()
  {
    GameDataController.gd.setObjective("gasstation_spy_mode", true);
    PlayerController.pc.spawnName = "Gasstation2SpyWaypoint";
    CurtainController.cc.fadeOut("LocationGasstation2", WalkController.Direction.E);
  }

  public void goThere(string s = "")
  {
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
