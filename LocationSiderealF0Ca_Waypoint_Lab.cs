// Decompiled with JetBrains decompiler
// Type: LocationSiderealF0Ca_Waypoint_Lab
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationSiderealF0Ca_Waypoint_Lab : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_doorway";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.doubleClickCondition = "visited_sidereal_lab";
  }

  public override void clickAction()
  {
    if (this.usedItem == "key3")
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_lock_unlock);
      GameDataController.gd.setObjective("sidereal_lab_locked", false);
      InventoryController.ic.removeItem("key3");
    }
    else if (GameDataController.gd.getObjective("sidereal_lab_open"))
    {
      PlayerController.pc.spawnName = "LocationSiderealLab_Waypoint_C";
      CurtainController.cc.fadeOut("SiderealLab13", WalkController.Direction.N);
    }
    else if (GameDataController.gd.getObjective("sidereal_lab_locked"))
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_locked);
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_lab_locked"));
    }
    else
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_moan2);
      GameDataController.gd.setObjective("sidereal_lab_open", true);
      this.updateAll();
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("sidereal_lab_open"))
    {
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.actionType = ObjectActionController.Type.Transition;
      this.objectName = "sidereal_doorway_lab";
    }
    else
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.characterAnimationName = "action_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.actionType = ObjectActionController.Type.NormalAction;
      this.objectName = "sidereal_doorway";
    }
    if (GameDataController.gd.getObjective("sidereal_lab_locked"))
    {
      this.interactions = new List<ItemInteraction>();
      this.interactions.Add(new ItemInteraction("crowbar", GameStrings.getString(GameStrings.actions, "sidereal_no_crowbar"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("paperclip", GameStrings.getString(GameStrings.actions, "sidereal_door_clip"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("sidereal_id", GameStrings.getString(GameStrings.actions, "sidereal_no_id_card"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("key3", string.Empty, anim: string.Empty));
    }
    else
      this.interactions = new List<ItemInteraction>();
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
