// Decompiled with JetBrains decompiler
// Type: LocationSiderealF2C_Waypoint_B
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class LocationSiderealF2C_Waypoint_B : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_exit4";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("sidereal_f2c_b_unlocked"))
    {
      this.doubleClickCondition = string.Empty;
      if (this.usedItem != string.Empty)
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "generic_unlocked"));
        GameDataController.gd.setObjective("sidereal_f2c_b_unlocked", true);
        this.updateAll();
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_lock_unlock);
        InventoryController.ic.removeItem(this.usedItem);
      }
      else
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_locked_3);
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "generic_locked"));
      }
    }
    else if (GameDataController.gd.getObjective("sidereal_f2c_b_open"))
    {
      PlayerController.pc.spawnName = "LocationSiderealF2B_Waypoint_C";
      CurtainController.cc.fadeOut("SiderealF2B", WalkController.Direction.N);
    }
    else
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_door_open);
      GameDataController.gd.setObjective("sidereal_f2c_b_open", true);
      this.updateAll();
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("sidereal_f2c_b_open"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.objectName = "sidereal_exit4";
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.actionType = ObjectActionController.Type.Transition;
      this.trans_dir = WalkController.Direction.N;
      this.doubleClickCondition = "visited_sidereal_f2b";
      this.interactions = new List<ItemInteraction>();
    }
    else
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.objectName = "sidereal_f2c_door";
      this.characterAnimationName = "locked_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.actionType = ObjectActionController.Type.NormalAction;
      this.trans_dir = WalkController.Direction.N;
      this.doubleClickCondition = string.Empty;
      this.interactions = new List<ItemInteraction>();
      this.interactions.Add(new ItemInteraction("key1", string.Empty, anim: string.Empty));
      this.interactions.Add(new ItemInteraction("crowbar", GameStrings.getString(GameStrings.actions, "sidereal_door_crowbar"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("paperclip", GameStrings.getString(GameStrings.actions, "sidereal_door_clip"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("screwdriver", GameStrings.getString(GameStrings.actions, "sidereal_door_screwdriver"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("sidereal_id_key", GameStrings.getString(GameStrings.actions, "sidereal_door_id"), anim: string.Empty));
    }
  }

  public override void whatOnClick0()
  {
    if (!GameDataController.gd.getObjective("sidereal_f2c_b_unlocked"))
    {
      if (!(this.usedItem != string.Empty))
        return;
      this.characterAnimationName = "action_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else
    {
      if (GameDataController.gd.getObjective("sidereal_f2c_b_open"))
        return;
      this.characterAnimationName = "open_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
