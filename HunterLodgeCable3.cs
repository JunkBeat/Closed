// Decompiled with JetBrains decompiler
// Type: HunterLodgeCable3
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class HunterLodgeCable3 : ObjectActionController
{
  public Sprite cord;
  public Sprite stormcatcher_on;
  public Sprite stormcatcher_off;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "lodge_cord";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("heater_broken", GameStrings.getString(GameStrings.actions, "heater_broken"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("fan_broken", GameStrings.getString(GameStrings.actions, "fan_broken"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("heater", GameStrings.getString(GameStrings.actions, "plug_not_needed"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ac", GameStrings.getString(GameStrings.actions, "plug_not_needed"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("fan", GameStrings.getString(GameStrings.actions, "plug_not_needed"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("stormcatcher1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("stormcatcher2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("stormcatcher3", string.Empty, anim: string.Empty));
    this.updateState();
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    if (this.usedItem == string.Empty)
    {
      if (GameDataController.gd.getObjective("lodge_tree_stormcatcher"))
      {
        if (GameDataController.gd.getObjective("lodge_roof_cleaned"))
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "lodge_tree_stormcatcher_placed"));
        else
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "lodge_tree_stormcatcher_no_power"));
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "socket_empty"));
    }
    else if (GameDataController.gd.getObjective("lodge_tree_stormcatcher"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "stormcatcher_already"));
    }
    else
    {
      InventoryController.ic.removeItem(this.usedItem);
      GameDataController.gd.setObjective("lodge_tree_stormcatcher", true);
      this.updateState();
      if (GameDataController.gd.getObjective("lodge_roof_cleaned"))
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "lodge_tree_stormcatcher_placed"));
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "lodge_tree_stormcatcher_no_power"));
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("lodge_tree_stormcatcher"))
    {
      this.colliderManager.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
      if (GameDataController.gd.getObjective("lodge_roof_cleaned"))
        this.GetComponent<SpriteRenderer>().sprite = this.stormcatcher_on;
      else
        this.GetComponent<SpriteRenderer>().sprite = this.stormcatcher_off;
    }
    else if (GameDataController.gd.getObjective("lodge_cord_climbed"))
    {
      this.colliderManager.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.GetComponent<SpriteRenderer>().sprite = this.cord;
    }
    else
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.setCollider(-1);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
    if (this.usedItem == string.Empty)
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 20f;
    }
    else
    {
      this.characterAnimationName = "kneel_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 1f;
    }
  }

  public override void whatOnClick()
  {
  }
}
