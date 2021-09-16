// Decompiled with JetBrains decompiler
// Type: RV_Socket
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class RV_Socket : ObjectActionController
{
  public Sprite cord;
  public Sprite cord2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "rv_socket";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("heater_broken", GameStrings.getString(GameStrings.actions, "heater_broken"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("fan_broken", GameStrings.getString(GameStrings.actions, "fan_broken"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("heater", GameStrings.getString(GameStrings.actions, "socket_wrong"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ac", GameStrings.getString(GameStrings.actions, "socket_wrong"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("fan", GameStrings.getString(GameStrings.actions, "socket_wrong"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ext_cord", string.Empty, anim: string.Empty));
    this.updateState();
  }

  public override void clickAction()
  {
    if (this.usedItem == "ext_cord")
    {
      InventoryController.ic.removeItem("ext_cord");
      GameDataController.gd.setObjective("rv_cord_plugged", true);
      this.updateAll();
    }
    else if (GameDataController.gd.getObjective("rv_cord_plugged") && GameDataController.gd.getObjective("rv_cord_caved"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cord_dragged"));
    else if (GameDataController.gd.getObjective("rv_cord_plugged"))
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("ext_cord")))
        return;
      GameDataController.gd.setObjective("rv_cord_plugged", false);
      this.updateAll();
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "socket_empty"));
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjective("rv_cord_plugged"))
    {
      this.GetComponent<SpriteRenderer>().enabled = true;
      if (!GameDataController.gd.getObjective("rv_cord_caved"))
        this.GetComponent<SpriteRenderer>().sprite = this.cord;
      else
        this.GetComponent<SpriteRenderer>().sprite = this.cord2;
      this.setCollider(1);
      this.objectName = "plugged_cord";
    }
    else
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.setCollider(0);
      this.objectName = "rv_socket";
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
    if (this.usedItem != string.Empty && GameDataController.gd.getObjective("rv_cord_plugged"))
    {
      this.range = 100f;
      this.characterAnimationName = "action_stnd_";
      this.useCurrentDirection = true;
    }
    else if (this.usedItem == string.Empty && GameDataController.gd.getObjective("rv_cord_plugged") && !GameDataController.gd.getObjective("rv_cord_caved"))
    {
      this.range = 1f;
      this.characterAnimationName = "action_n";
      this.useCurrentDirection = false;
    }
    else if (this.usedItem == string.Empty || GameDataController.gd.getObjective("rv_cord_caved"))
    {
      this.range = 100f;
      this.characterAnimationName = "action_stnd_";
      this.useCurrentDirection = true;
    }
    else
    {
      this.range = 1f;
      this.characterAnimationName = "action_n";
      this.useCurrentDirection = false;
    }
  }

  public override void whatOnClick()
  {
  }
}
