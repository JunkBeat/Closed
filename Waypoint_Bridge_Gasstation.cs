// Decompiled with JetBrains decompiler
// Type: Waypoint_Bridge_Gasstation
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class Waypoint_Bridge_Gasstation : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "road_west";
    this.doubleClickCondition = "visited_gasstation";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.W;
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("bridge_westside") && !GameDataController.gd.getObjective("bridge_planks_used_1"))
    {
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "ravine_wrong_side"), true);
    }
    else
    {
      GameDataController.gd.setObjective("bridge_westside", true);
      GameDataController.gd.setObjectiveDetail("map_gasstation_revealed", 1);
      PlayerController.pc.setBusy(true);
      PlayerController.pc.spawnName = "InfoExit";
      CurtainController.cc.fadeOut("LocationMap", WalkController.Direction.E);
    }
  }

  public override void whatOnClick()
  {
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (!GameDataController.gd.getObjective("bridge_westside") && !GameDataController.gd.getObjective("bridge_planks_used_1"))
    {
      this.doubleClickCondition = string.Empty;
      this.range = 2000f;
    }
    else
    {
      this.doubleClickCondition = "visited_gasstation";
      this.range = 4f;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
