// Decompiled with JetBrains decompiler
// Type: GasstationFuelTank
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class GasstationFuelTank : ObjectActionController
{
  public Sprite s1;
  public Sprite s2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_tank";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("wrench", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister_empty", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister2_empty", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister_full", GameStrings.getString(GameStrings.actions, "tank_canister_full"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister2_full", GameStrings.getString(GameStrings.actions, "tank_canister_full"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("watersprayer", GameStrings.getString(GameStrings.actions, "tank_sprayer"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("flamethrower_empty", GameStrings.getString(GameStrings.actions, "tank_sprayer"), anim: string.Empty));
  }

  public override void whatOnClick()
  {
    if (this.usedItem == "wrench" && !GameDataController.gd.getObjective("gasstation_canister_placed_under_tank") && !GameDataController.gd.getObjective("gasstation_canister2_placed_under_tank"))
    {
      this.characterAnimationName = "fuel_spill";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else if (this.usedItem == "wrench" && (GameDataController.gd.getObjective("gasstation_canister_placed_under_tank") && !GameDataController.gd.getObjective("gasstation_canister_filled") || GameDataController.gd.getObjective("gasstation_canister2_placed_under_tank") && !GameDataController.gd.getObjective("gasstation_canister2_filled")))
    {
      this.characterAnimationName = "fuel_canster";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else if (this.usedItem == "canister_empty")
    {
      this.characterAnimationName = "kneel_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else if (this.usedItem == "canister2_empty")
    {
      this.characterAnimationName = "kneel_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else if (GameDataController.gd.getObjective("gasstation_canister_placed_under_tank") && this.usedItem == string.Empty)
    {
      if (GameDataController.gd.getObjective("gasstation_canister_filled"))
      {
        this.characterAnimationName = "kneel_n";
        this.animationFlip = false;
        this.useCurrentDirection = false;
      }
      else
      {
        this.characterAnimationName = "action_n";
        this.animationFlip = false;
        this.useCurrentDirection = false;
      }
    }
    else if (GameDataController.gd.getObjective("gasstation_canister2_placed_under_tank") && this.usedItem == string.Empty)
    {
      if (GameDataController.gd.getObjective("gasstation_canister2_filled"))
      {
        this.characterAnimationName = "kneel_n";
        this.animationFlip = false;
        this.useCurrentDirection = false;
      }
      else
      {
        this.characterAnimationName = "action_n";
        this.animationFlip = false;
        this.useCurrentDirection = false;
      }
    }
    else
    {
      this.characterAnimationName = "action_stnd_se";
      this.animationFlip = true;
      this.useCurrentDirection = false;
    }
  }

  public override void clickAction()
  {
    if (this.usedItem == "wrench")
    {
      if (GameDataController.gd.getObjective("gasstation_canister_placed_under_tank") && GameDataController.gd.getObjective("gasstation_canister_filled"))
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "tank_canister_full"), true);
      else if (GameDataController.gd.getObjective("gasstation_canister2_placed_under_tank") && GameDataController.gd.getObjective("gasstation_canister2_filled"))
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "tank_canister_full"), true);
      else if (GameDataController.gd.getObjective("gasstation_canister_placed_under_tank") && !GameDataController.gd.getObjective("gasstation_canister_filled"))
        GameDataController.gd.setObjective("gasstation_canister_filled", true);
      else if (GameDataController.gd.getObjective("gasstation_canister2_placed_under_tank") && !GameDataController.gd.getObjective("gasstation_canister2_filled"))
        GameDataController.gd.setObjective("gasstation_canister2_filled", true);
    }
    else if (this.usedItem == "canister_empty")
    {
      if (!GameDataController.gd.getObjective("gasstation_canister2_placed_under_tank"))
      {
        InventoryController.ic.removeItem(this.usedItem);
        GameDataController.gd.setObjective("gasstation_canister_placed_under_tank", true);
        GameDataController.gd.setObjective("gasstation_canister_filled", false);
      }
      else
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "tank_canister_already"), true);
    }
    else if (this.usedItem == "canister2_empty")
    {
      if (!GameDataController.gd.getObjective("gasstation_canister_placed_under_tank"))
      {
        InventoryController.ic.removeItem(this.usedItem);
        GameDataController.gd.setObjective("gasstation_canister2_placed_under_tank", true);
        GameDataController.gd.setObjective("gasstation_canister2_filled", false);
      }
      else
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "tank_canister_already"), true);
    }
    else if (this.usedItem == "canister_full")
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "tank_canister_full"), true);
    else if (this.usedItem == "canister2_full")
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "tank_canister_full"), true);
    else if (GameDataController.gd.getObjective("gasstation_canister_placed_under_tank"))
    {
      if (GameDataController.gd.getObjective("gasstation_canister_filled"))
      {
        if (InventoryController.ic.pickUpItem(ItemsManager.im.getItem("canister_full")))
        {
          GameDataController.gd.setObjective("gasstation_canister_placed_under_tank", false);
          GameDataController.gd.setObjective("gasstation_canister_filled", false);
        }
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "fuel_valves_closed"));
    }
    else if (GameDataController.gd.getObjective("gasstation_canister2_placed_under_tank"))
    {
      if (GameDataController.gd.getObjective("gasstation_canister2_filled"))
      {
        if (InventoryController.ic.pickUpItem(ItemsManager.im.getItem("canister2_full")))
        {
          GameDataController.gd.setObjective("gasstation_canister2_placed_under_tank", false);
          GameDataController.gd.setObjective("gasstation_canister2_filled", false);
        }
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "fuel_valves_closed"));
    }
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "gasstation_tank_wrench"), true);
    this.updateState();
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("gasstation_canister_placed_under_tank") && !GameDataController.gd.getObjective("gasstation_canister2_placed_under_tank"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(0);
      this.objectName = "gasstation_tank";
    }
    else if (!GameDataController.gd.getObjective("gasstation_canister2_placed_under_tank"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.s1;
      this.colliderManager.setCollider(1);
      if (GameDataController.gd.getObjective("gasstation_canister_filled"))
        this.objectName = "gasstation_tank_canister_full";
      else
        this.objectName = "gasstation_tank_canister";
    }
    else if (!GameDataController.gd.getObjective("gasstation_canister_placed_under_tank"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.s2;
      this.colliderManager.setCollider(2);
      if (GameDataController.gd.getObjective("gasstation_canister2_filled"))
        this.objectName = "gasstation_tank_canister_full";
      else
        this.objectName = "gasstation_tank_canister";
    }
    if (!GameDataController.gd.getObjective("gasstation_spy_mode"))
      return;
    this.setCollider(-1);
  }

  public override void clickAction2()
  {
    if (!(this.usedItem == "wrench"))
      return;
    this.valvePlay();
    this.Invoke("openTap", 0.2f);
  }

  public void openTap()
  {
    if (!GameDataController.gd.getObjective("gasstation_canister2_placed_under_tank") && !GameDataController.gd.getObjective("gasstation_canister_placed_under_tank"))
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.liquid_spill);
      this.Invoke("valvePlay", 2f);
    }
    else
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.liquid_pour);
      this.Invoke("valvePlay", 4.5f);
    }
  }

  public void valvePlay() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.valve);

  public override void clickAction0()
  {
  }
}
