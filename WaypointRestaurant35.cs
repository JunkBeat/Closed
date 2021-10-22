// Decompiled with JetBrains decompiler
// Type: WaypointRestaurant35
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class WaypointRestaurant35 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_waypoint35";
    this.actionType = ObjectActionController.Type.Transition;
    this.doubleClickCondition = "visited_restaurant_wc";
    this.range = 20f;
    this.trans_dir = WalkController.Direction.W;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() == 2 && !GameDataController.gd.getObjective("restaurant_door_opened2"))
      return;
    if (GameDataController.gd.getObjective("restaurant_door_opened"))
      GameDataController.gd.setObjective("restaurant_door_opened_teamed", true);
    PlayerController.pc.spawnName = "WaypointRestaurant5_3";
    CurtainController.cc.fadeOut("LocationRestaurant5", WalkController.Direction.S);
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getCurrentDay() == 2 && !GameDataController.gd.getObjective("restaurant_door_opened2"))
    {
      this.range = 10f;
      this.characterAnimationName = "action_stnd_";
    }
    else
    {
      this.range = 20f;
      this.characterAnimationName = "stop";
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
