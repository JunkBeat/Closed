// Decompiled with JetBrains decompiler
// Type: HouseBBackHose
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class HouseBBackHose : ObjectActionController
{
  public Sprite sprite1;
  public Sprite sprite2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "house_b_back_hose_1";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("wrench", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("screwdriver", GameStrings.getString(GameStrings.actions, "hose_screwdriver"), anim: string.Empty));
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("house_b_hose_disconnected") && this.usedItem == "wrench")
    {
      GameDataController.gd.setObjective("house_b_hose_disconnected", true);
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "house_b_hose_disconnected"), true);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.screw);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.hose);
      this.updateState();
    }
    else if (GameDataController.gd.getObjective("house_b_hose_disconnected") && !GameDataController.gd.getObjective("house_b_hose_taken"))
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("hose")))
        return;
      GameDataController.gd.setObjective("house_b_hose_taken", true);
      this.updateState();
    }
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "house_b_hose_connected"), true);
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("house_b_hose_disconnected"))
    {
      this.colliderManager.setCollider(0);
      this.characterAnimationName = "kneel_n";
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.sprite1;
      this.objectName = "house_b_back_hose_1";
      this.interactions = new List<ItemInteraction>();
      this.interactions.Add(new ItemInteraction("wrench", string.Empty, anim: string.Empty));
    }
    else if (!GameDataController.gd.getObjective("house_b_hose_taken"))
    {
      this.colliderManager.setCollider(1);
      this.characterAnimationName = "kneel_n";
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.sprite2;
      this.objectName = "house_b_back_hose_2";
      this.interactions = new List<ItemInteraction>();
      this.interactions.Add(new ItemInteraction("wrench", GameStrings.getString(GameStrings.actions, "house_b_hose_already_disconnected"), anim: string.Empty));
    }
    else
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(-1);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
