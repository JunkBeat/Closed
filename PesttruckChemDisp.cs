﻿// Decompiled with JetBrains decompiler
// Type: PesttruckChemDisp
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;

public class PesttruckChemDisp : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "action_n";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "pesttruck_chem_disp";
    this.updateState();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("chem_glass", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("chem_glass_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("chem_glass_2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("chem_glass_3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("chem_glass_12", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("chem_glass_13", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("chem_glass_23", string.Empty, anim: string.Empty));
  }

  public override void clickAction()
  {
    if (this.usedItem == "chem_glass_1" || this.usedItem == "chem_glass_2" || this.usedItem == "chem_glass_3" || this.usedItem == "chem_glass_12" || this.usedItem == "chem_glass_13" || this.usedItem == "chem_glass_23")
    {
      InventoryController.ic.removeItem(this.usedItem);
      InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("chem_glass"));
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "chem_glass_emptied"), true);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.liquid_pour_small);
    }
    else if (this.usedItem == "chem_glass")
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "chem_glass_empty"), true);
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "chem_disposal"), true);
  }

  public override void whatOnClick()
  {
    if (this.usedItem == "chem_glass_1" || this.usedItem == "chem_glass_2" || this.usedItem == "chem_glass_3" || this.usedItem == "chem_glass_12" || this.usedItem == "chem_glass_13" || this.usedItem == "chem_glass_23")
      this.characterAnimationName = "action_n";
    else
      this.characterAnimationName = "action_stnd_n";
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 1)
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.colliderManager.setCollider(-1);
    }
    else
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.colliderManager.setCollider(0);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
