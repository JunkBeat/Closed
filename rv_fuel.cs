// Decompiled with JetBrains decompiler
// Type: rv_fuel
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;

public class rv_fuel : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "rv_fuel_inlet";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("canister_full", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister_empty", GameStrings.getString(GameStrings.actions, "canister_is_empty"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister2_full", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister2_empty", GameStrings.getString(GameStrings.actions, "canister_is_empty"), anim: string.Empty));
  }

  public override void clickAction()
  {
    if (this.usedItem != string.Empty)
    {
      if (this.usedItem == "canister_full")
      {
        if (!GameDataController.gd.getObjective("rv_fueled"))
        {
          GameDataController.gd.setObjective("rv_fueled", true);
          InventoryController.ic.removeItem("canister_full");
          ItemsManager.im.updateItem("canister_full", "nowhere", 0, 0);
          InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("canister_empty"));
        }
        else
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "rv_already_fueled"));
      }
      else
      {
        if (!(this.usedItem == "canister2_full"))
          return;
        if (!GameDataController.gd.getObjective("rv_fueled"))
        {
          GameDataController.gd.setObjective("rv_fueled", true);
          InventoryController.ic.removeItem("canister2_full");
          ItemsManager.im.updateItem("canister2_full", "nowhere", 0, 0);
          InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("canister2_empty"));
        }
        else
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "rv_already_fueled"));
      }
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "rv_fuel_inlet"));
  }

  public override void updateState()
  {
  }

  public override void whatOnClick0()
  {
    if (this.usedItem != string.Empty && !GameDataController.gd.getObjective("rv_fueled"))
    {
      this.characterAnimationName = "action_n_long";
      this.useCurrentDirection = false;
      this.range = 1f;
    }
    else
    {
      this.range = 100f;
      this.characterAnimationName = "action_stnd_";
      this.useCurrentDirection = true;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
