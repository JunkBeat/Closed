// Decompiled with JetBrains decompiler
// Type: Restaurant2Window
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class Restaurant2Window : ObjectActionController
{
  public Sprite open;
  public Sprite closed;
  public GameObject trashCollider;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_window";
    this.range = 10f;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("visited_restaurant_kitchen"))
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "rather_door"), true);
    else if (!GameDataController.gd.getObjective("restaurant_trash_moved"))
    {
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "restaurant_window"), true);
    }
    else
    {
      PlayerController.pc.spawnName = "WaypointRestaurant4_2";
      CurtainController.cc.fadeOut("LocationRestaurant4", WalkController.Direction.S, "window_jump");
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("visited_restaurant_kitchen"))
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 100f;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.open;
    }
    else
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 10f;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.closed;
    }
    if (!GameDataController.gd.getObjective("visited_restaurant_kitchen") && GameDataController.gd.getObjective("restaurant_trash_moved"))
    {
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.range = 10f;
      this.actionType = ObjectActionController.Type.Transition;
      this.trans_dir = WalkController.Direction.E;
    }
    else
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 10f;
      this.actionType = ObjectActionController.Type.NormalAction;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
