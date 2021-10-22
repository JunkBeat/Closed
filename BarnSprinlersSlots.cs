// Decompiled with JetBrains decompiler
// Type: BarnSprinlersSlots
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class BarnSprinlersSlots : ObjectActionController
{
  private AudioClip soundOpen;
  private AudioClip soundClose;
  private PolygonCollider2D poly1;
  private PolygonCollider2D poly2;
  public Sprite barn_sprinkles_empty;
  public Sprite barn_sprinkles_1;
  public Sprite barn_sprinkles_2;
  public Sprite barn_sprinkles_single_filled;
  public Sprite barn_sprinkles_single_empty;
  public Sprite barn_sprinkles_single_12;
  public Sprite barn_sprinkles_single_23;
  public Sprite barn_sprinkles_single_13;
  public Sprite barn_sprinkles_single_mix_used;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "kick_ne";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sprinklers_slots_empty";
    this.setCollider(0);
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("pest1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("pest2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("chem_glass_12", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("chem_glass_13", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("chem_glass_23", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("spiderpest1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("spiderpest2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("spiderpest3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("spiderpest4", string.Empty, anim: string.Empty));
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
    {
      if (!GameDataController.gd.getObjective("barn_sprinklers_fed1"))
      {
        this.setCollider(0);
        this.objectName = "sprinklers_slots_empty";
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.barn_sprinkles_empty;
      }
      else if (!GameDataController.gd.getObjective("barn_sprinklers_fed2"))
      {
        this.setCollider(0);
        this.objectName = "sprinklers_slots_filled1";
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.barn_sprinkles_1;
      }
      else
      {
        this.setCollider(0);
        this.objectName = "sprinklers_slots_filled2";
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.barn_sprinkles_2;
      }
    }
    else if (GameDataController.gd.getObjective("barn_sprinklers_fed1"))
    {
      this.objectName = "sprinklers_slots_filled3";
      this.setCollider(1);
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.barn_sprinkles_single_filled;
    }
    else if (GameDataController.gd.getCurrentDay() > 1 && (ItemsManager.im.getItem("chem_glass_12").dataRef.droppedLocation == "sprinklers" || ItemsManager.im.getItem("chem_glass_13").dataRef.droppedLocation == "sprinklers" || ItemsManager.im.getItem("chem_glass_23").dataRef.droppedLocation == "sprinklers"))
    {
      this.objectName = "sprinklers_slots_empty";
      this.setCollider(1);
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.barn_sprinkles_single_mix_used;
    }
    else if (ItemsManager.im.getItem("chem_glass_12").dataRef.droppedLocation == "sprinklers")
    {
      this.objectName = "sprinklers_slots_chem";
      this.setCollider(1);
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.barn_sprinkles_single_12;
    }
    else if (ItemsManager.im.getItem("chem_glass_23").dataRef.droppedLocation == "sprinklers")
    {
      this.objectName = "sprinklers_slots_chem";
      this.setCollider(1);
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.barn_sprinkles_single_23;
    }
    else if (ItemsManager.im.getItem("chem_glass_13").dataRef.droppedLocation == "sprinklers")
    {
      this.objectName = "sprinklers_slots_chem";
      this.setCollider(1);
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.barn_sprinkles_single_13;
    }
    else
    {
      this.objectName = "sprinklers_slots_empty";
      this.setCollider(1);
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.barn_sprinkles_single_empty;
    }
  }

  public override void whatOnClick()
  {
    if (!GameDataController.gd.getObjective("base_discovered"))
      this.characterAnimationName = "action_stnd_n";
    else if (this.usedItem != string.Empty || GameDataController.gd.getObjective("barn_sprinklers_fed1"))
      this.characterAnimationName = "action_n";
    else
      this.characterAnimationName = "action_stnd_n";
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("base_discovered"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_pipe_first"));
    else if (GameDataController.gd.getCurrentDay() > 1)
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sprinklers_dont_want"));
    }
    else
    {
      if (this.usedItem == "chem_glass_12" || this.usedItem == "chem_glass_13" || this.usedItem == "chem_glass_23")
      {
        InventoryController.ic.removeItem(this.usedItem);
        ItemsManager.im.updateItem(this.usedItem, "sprinklers", 0, 0);
      }
      else if (this.usedItem == "pest1")
      {
        InventoryController.ic.removeItem("pest1");
        ItemsManager.im.updateItem("pest1", "sprinklers", 0, 0);
        if (!GameDataController.gd.getObjective("barn_sprinklers_fed1"))
          GameDataController.gd.setObjective("barn_sprinklers_fed1", true);
        else
          GameDataController.gd.setObjective("barn_sprinklers_fed2", true);
      }
      else if (this.usedItem == "pest2")
      {
        InventoryController.ic.removeItem("pest2");
        ItemsManager.im.updateItem("pest2", "sprinklers", 0, 0);
        if (!GameDataController.gd.getObjective("barn_sprinklers_fed1"))
          GameDataController.gd.setObjective("barn_sprinklers_fed1", true);
        else
          GameDataController.gd.setObjective("barn_sprinklers_fed2", true);
      }
      else if (this.usedItem == "spiderpest1" || this.usedItem == "spiderpest2" || this.usedItem == "spiderpest3" || this.usedItem == "spiderpest4")
      {
        if (ItemsManager.im.getItem("spiderpest1").dataRef.droppedLocation == "sprinklers" || ItemsManager.im.getItem("spiderpest2").dataRef.droppedLocation == "sprinklers" || ItemsManager.im.getItem("spiderpest3").dataRef.droppedLocation == "sprinklers" || ItemsManager.im.getItem("spiderpest4").dataRef.droppedLocation == "sprinklers")
        {
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_sprinklers_full"));
          return;
        }
        GameDataController.gd.setObjective("barn_sprinklers_fed1", true);
        InventoryController.ic.removeItem(this.usedItem);
        ItemsManager.im.updateItem(this.usedItem, "sprinklers", 0, 0);
      }
      else if (ItemsManager.im.getItem("chem_glass_12").dataRef.droppedLocation == "sprinklers")
      {
        if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("chem_glass_12")))
          ;
      }
      else if (ItemsManager.im.getItem("chem_glass_23").dataRef.droppedLocation == "sprinklers")
      {
        if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("chem_glass_23")))
          ;
      }
      else if (ItemsManager.im.getItem("chem_glass_13").dataRef.droppedLocation == "sprinklers")
      {
        if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("chem_glass_13")))
          ;
      }
      else if (ItemsManager.im.getItem("pest1").dataRef.droppedLocation == "sprinklers")
      {
        if (InventoryController.ic.pickUpItem(ItemsManager.im.getItem("pest1")))
        {
          if (GameDataController.gd.getObjective("barn_sprinklers_fed2"))
            GameDataController.gd.setObjective("barn_sprinklers_fed2", false);
          else if (GameDataController.gd.getObjective("barn_sprinklers_fed1"))
            GameDataController.gd.setObjective("barn_sprinklers_fed1", false);
        }
      }
      else if (ItemsManager.im.getItem("pest2").dataRef.droppedLocation == "sprinklers")
      {
        if (InventoryController.ic.pickUpItem(ItemsManager.im.getItem("pest2")))
        {
          if (GameDataController.gd.getObjective("barn_sprinklers_fed2"))
            GameDataController.gd.setObjective("barn_sprinklers_fed2", false);
          else if (GameDataController.gd.getObjective("barn_sprinklers_fed1"))
            GameDataController.gd.setObjective("barn_sprinklers_fed1", false);
        }
      }
      else if (ItemsManager.im.getItem("spiderpest1").dataRef.droppedLocation == "sprinklers")
      {
        if (InventoryController.ic.pickUpItem(ItemsManager.im.getItem("spiderpest1")))
          GameDataController.gd.setObjective("barn_sprinklers_fed1", false);
      }
      else if (ItemsManager.im.getItem("spiderpest2").dataRef.droppedLocation == "sprinklers")
      {
        if (InventoryController.ic.pickUpItem(ItemsManager.im.getItem("spiderpest2")))
          GameDataController.gd.setObjective("barn_sprinklers_fed1", false);
      }
      else if (ItemsManager.im.getItem("spiderpest3").dataRef.droppedLocation == "sprinklers")
      {
        if (InventoryController.ic.pickUpItem(ItemsManager.im.getItem("spiderpest3")))
          GameDataController.gd.setObjective("barn_sprinklers_fed1", false);
      }
      else if (ItemsManager.im.getItem("spiderpest4").dataRef.droppedLocation == "sprinklers")
      {
        if (InventoryController.ic.pickUpItem(ItemsManager.im.getItem("spiderpest4")))
          GameDataController.gd.setObjective("barn_sprinklers_fed1", false);
      }
      else
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "barn_sprinklers_inlet"), true);
      this.updateAll();
      PlayerController.wc.forceDirection(WalkController.Direction.NE);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
