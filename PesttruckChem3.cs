// Decompiled with JetBrains decompiler
// Type: PesttruckChem3
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;

public class PesttruckChem3 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "action_n";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "pesttruck_chem_3";
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
    if (this.usedItem == "chem_glass" || this.usedItem == "chem_glass_2" || this.usedItem == "chem_glass_1")
    {
      InventoryController.ic.removeItem(this.usedItem);
      if (this.usedItem == "chem_glass")
        InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("chem_glass_3"));
      else if (this.usedItem == "chem_glass_2")
        InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("chem_glass_23"));
      else if (this.usedItem == "chem_glass_1")
        InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("chem_glass_13"));
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.liquid_pour_small);
    }
    else if (this.usedItem == "chem_glass_3")
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "chem_glass_already"), true);
    else if (this.usedItem.IndexOf("chem_glass_") != -1)
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "chem_glass_full"), true);
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "chem_no_glass"), true);
  }

  public override void whatOnClick()
  {
    if (this.usedItem == "chem_glass" || this.usedItem == "chem_glass_2" || this.usedItem == "chem_glass_1")
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
