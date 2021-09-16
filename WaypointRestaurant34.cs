// Decompiled with JetBrains decompiler
// Type: WaypointRestaurant34
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class WaypointRestaurant34 : ObjectActionController
{
  public Sprite locked;
  public Sprite open;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_waypoint34";
    this.actionType = ObjectActionController.Type.Transition;
    this.doubleClickCondition = "visited_restaurant_kitchen";
    this.range = 2f;
    this.trans_dir = WalkController.Direction.N;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("restaurant_door_opened"))
    {
      GameDataController.gd.setObjective("restaurant_door_opened_teamed", true);
      PlayerController.pc.spawnName = "WaypointRestaurant4_3";
      CurtainController.cc.fadeOut("LocationRestaurant4", WalkController.Direction.W);
    }
    else if (GameDataController.gd.getCurrentDay() == 2)
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "restaurant_door_locked"));
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "restaurant_door_locked2"));
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("restaurant_door_opened"))
    {
      this.colliderManager.setCollider(0);
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.locked;
      this.range = 2000f;
      this.actionType = ObjectActionController.Type.NormalAction;
    }
    else
    {
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.open;
      this.colliderManager.setCollider(1);
      this.range = 2f;
      this.actionType = ObjectActionController.Type.Transition;
    }
    if (GameDataController.gd.getCurrentDay() <= 2)
      return;
    this.colliderManager.setCollider(1);
    this.range = 2f;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
