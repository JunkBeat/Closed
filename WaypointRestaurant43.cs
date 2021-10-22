// Decompiled with JetBrains decompiler
// Type: WaypointRestaurant43
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class WaypointRestaurant43 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_waypoint43l";
    this.actionType = ObjectActionController.Type.Transition;
    this.doubleClickCondition = "restaurant_door_opened";
    this.range = 2f;
    this.trans_dir = WalkController.Direction.E;
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("dialogue_cody_door_opened") && ItemsManager.im.getItem("foodcan").dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1 && ItemsManager.im.getItem("foodcanopen").dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1 && GameDataController.gd.getCurrentDay() == 2)
    {
      PlayerController.pc.setBusy(false);
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "take_foodcan_plz"), true);
      PlayerController.wc.dir = WalkController.Direction.W;
      CursorController.cc.showCursor(CursorController.PixelCursor.NORMAL);
    }
    else
    {
      if (!GameDataController.gd.getObjective("restaurant_door_opened"))
      {
        GameDataController.gd.setObjective("restaurant_door_opened", true);
        this.updateState();
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_creak1);
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.crowbar_pry_open);
      }
      PlayerController.pc.spawnName = "WaypointRestaurant3_4";
      CurtainController.cc.fadeOut("LocationRestaurant3", WalkController.Direction.S);
    }
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("restaurant_door_opened"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.objectName = "restaurant_waypoint43l";
      this.actionType = ObjectActionController.Type.NormalAction;
    }
    else
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.objectName = "restaurant_waypoint43o";
      this.actionType = ObjectActionController.Type.Transition;
    }
    this.colliderManager.setCollider(0);
  }

  public override void whatOnClick()
  {
    if (!GameDataController.gd.getObjective("dialogue_cody_door_opened") && ItemsManager.im.getItem("foodcan").dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1 && ItemsManager.im.getItem("foodcanopen").dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1)
    {
      this.characterAnimationName = "action_stnd_";
      this.range = 200f;
      PlayerController.wc.range = (int) this.range;
    }
    else
    {
      this.characterAnimationName = "stop";
      this.range = 2f;
      PlayerController.wc.range = (int) this.range;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
