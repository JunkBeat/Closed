// Decompiled with JetBrains decompiler
// Type: Gasstation2SpyWaypoint
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class Gasstation2SpyWaypoint : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_window_away";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.S;
    this.range = 200f;
    this.teleport = true;
  }

  public override void clickAction()
  {
    GameDataController.gd.setObjective("gasstation_spy_mode", false);
    PlayerController.pc.spawnName = "Waypoint_GasstationRoom2_Spy";
    CurtainController.cc.fadeOut("LocationGasstationRoom2", WalkController.Direction.E);
  }

  public void goThere(string s = "")
  {
  }

  public override void updateState()
  {
    this.setCollider(-1);
    if (!GameDataController.gd.getObjective("gasstation_spy_mode"))
      return;
    this.setCollider(0);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
