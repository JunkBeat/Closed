// Decompiled with JetBrains decompiler
// Type: HouseBGate
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class HouseBGate : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_e";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "house_b_garage";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("key1", GameStrings.getString(GameStrings.actions, "generic_key"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("key2", GameStrings.getString(GameStrings.actions, "generic_key"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("key3", GameStrings.getString(GameStrings.actions, "generic_key"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("key4", string.Empty, anim: string.Empty));
  }

  public override void clickAction()
  {
    if (this.usedItem == string.Empty)
    {
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "house_b_garage"), true, mwidth: 150);
    }
    else
    {
      GameDataController.gd.setObjective("house_b_garage_open", true);
      InventoryController.ic.removeItem("key4");
      this.updateAll();
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_slide);
    }
  }

  public void gateIsOpen()
  {
    this.updateState();
    GameObject.Find("Shovel").GetComponent<HouseBShovel>().updateState();
  }

  public void gateIsOpening()
  {
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("house_b_garage_open"))
    {
      this.gameObject.GetComponent<Animator>().Play("gate_2", 0);
      this.setCollider(-1);
    }
    else
    {
      this.setCollider(0);
      this.gameObject.GetComponent<Animator>().Play("gate_0", 0);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
