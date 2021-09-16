// Decompiled with JetBrains decompiler
// Type: HuntersLodgeInsideOutlet
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class HuntersLodgeInsideOutlet : ObjectActionController
{
  public Sprite cord;
  public Sprite cord2;
  public Sprite heater;
  public SpriteRenderer heaterLight;
  public float lightAlfa;
  public float lightAlfa2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "lodge_socket";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("heater_broken", GameStrings.getString(GameStrings.actions, "heater_broken"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("fan_broken", GameStrings.getString(GameStrings.actions, "fan_broken"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("heater", GameStrings.getString(GameStrings.actions, "plug_not_needed"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ac", GameStrings.getString(GameStrings.actions, "plug_not_needed"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("fan", GameStrings.getString(GameStrings.actions, "plug_not_needed"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ext_cord", string.Empty, anim: string.Empty));
    this.updateState();
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    if (this.usedItem == "ext_cord")
    {
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") != 1)
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "plug_not_needed"));
      }
      else
      {
        InventoryController.ic.removeItem("ext_cord");
        GameDataController.gd.setObjective("lodge_cord_plugged", true);
        this.updateAll();
      }
    }
    else if (GameDataController.gd.getObjective("lodge_cord_plugged"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "plug_dont_unplug"));
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "socket_empty"));
  }

  public override void updateState()
  {
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
    if (this.usedItem != "ext_cord")
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 30f;
    }
    else
    {
      this.range = 1f;
      this.characterAnimationName = "kneel_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
  }

  public override void whatOnClick()
  {
  }
}
