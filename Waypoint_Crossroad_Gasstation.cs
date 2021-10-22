// Decompiled with JetBrains decompiler
// Type: Waypoint_Crossroad_Gasstation
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class Waypoint_Crossroad_Gasstation : ObjectActionController
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
    this.doubleClickCondition = "visited_bridge";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.W;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("base_discovered"))
    {
      if (GameDataController.gd.getCurrentDay() != 3 || GameDataController.gd.getObjective("sidereal_base_located"))
        GameDataController.gd.setObjectiveDetail("map_bridge_revealed", 1);
      GameDataController.gd.setObjective("crossroads_left", true);
      PlayerController.pc.setBusy(true);
      PlayerController.pc.spawnName = "InfoExit";
      CurtainController.cc.fadeOut("LocationMap", WalkController.Direction.E);
    }
    else
    {
      PlayerController.pc.setBusy(false);
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "story_no_go"), true);
    }
  }

  public override void updateState() => this.colliderManager.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
