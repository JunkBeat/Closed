// Decompiled with JetBrains decompiler
// Type: Outpost8Socket
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Outpost8Socket : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_ship_socket";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("fan", GameStrings.getString(GameStrings.actions, "ship_socket_power"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("heater", GameStrings.getString(GameStrings.actions, "ship_socket_power"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ac", GameStrings.getString(GameStrings.actions, "ship_socket_power"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("stormcatcher1", GameStrings.getString(GameStrings.actions, "ship_socket_power"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("stormcatcher2", GameStrings.getString(GameStrings.actions, "ship_socket_power"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("stormcatcher3", GameStrings.getString(GameStrings.actions, "ship_socket_power"), anim: string.Empty));
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getItemData("welder").droppedLocation == "socket_ship_outside")
    {
      InventoryController.ic.pickUpItem(ItemsManager.im.getItem("welder"));
      this.updateAll();
    }
    else if (this.usedItem != string.Empty)
    {
      InventoryController.ic.removeItem("welder");
      GameDataController.gd.getItemData("welder").droppedLocation = "socket_ship_outside";
      this.updateAll();
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "welder_plugged"));
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "welder_plug_empty"));
  }

  public override void updateState()
  {
    if (GameDataController.gd.getItemData("welder").droppedLocation == "socket_ship_outside")
    {
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.colliderManager.setCollider(1);
      this.objectName = "outpost_ship_welder";
      this.interactions = new List<ItemInteraction>();
      this.interactions.Add(new ItemInteraction("metal_slab", GameStrings.getString(GameStrings.actions, "welder_metal"), anim: string.Empty));
    }
    else
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(0);
      this.objectName = "outpost_ship_socket";
      this.interactions = new List<ItemInteraction>();
      this.interactions.Add(new ItemInteraction("welder", string.Empty, anim: string.Empty));
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
    if (GameDataController.gd.getItemData("welder").droppedLocation == "socket_ship_outside")
    {
      this.characterAnimationName = "kneel_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else if (this.usedItem != string.Empty)
    {
      this.characterAnimationName = "kneel_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
  }

  public override void whatOnClick()
  {
  }
}
