// Decompiled with JetBrains decompiler
// Type: WaypointRestaurant12
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class WaypointRestaurant12 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_waypoint12";
    this.actionType = ObjectActionController.Type.Transition;
    this.doubleClickCondition = "visited_restaurant_back";
    this.trans_dir = WalkController.Direction.W;
    this.range = 10f;
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("dialogue_cody_intro") && GameDataController.gd.getCurrentDay() == 2)
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "restaurant_first_check_front"));
    }
    else
    {
      PlayerController.pc.spawnName = "WaypointRestaurant2_1";
      CurtainController.cc.fadeOut("LocationRestaurant2", WalkController.Direction.N);
    }
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getCurrentDay() == 2 && !GameDataController.gd.getObjective("dialogue_cody_intro"))
    {
      this.range = 1f;
      this.characterAnimationName = "action_stnd_";
    }
    else
    {
      this.range = 10f;
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
