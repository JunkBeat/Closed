// Decompiled with JetBrains decompiler
// Type: LocationMoonShipTest
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class LocationMoonShipTest : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "airplane_pilot";
    this.range = 1f;
  }

  public override void clickAction()
  {
    GameDataController.gd.setObjective("moon_shocked1", true);
    GameDataController.gd.setObjective("moon_shocked2", true);
    GameDataController.gd.setObjective("moon_shocked3", true);
    PlayerController.pc.spawnName = "WakeUp";
    CurtainController.cc.fadeOut("MoonShip", WalkController.Direction.E, "wake_up");
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

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}
