// Decompiled with JetBrains decompiler
// Type: BaseFuelBasket
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class BaseFuelBasket : ObjectActionController
{
  public ParticleGenerator smoke;
  public Sprite wood1;
  public Sprite wood2;
  public Sprite wood3;
  public Sprite wood4;
  public Sprite wood0;
  public SpriteRenderer wood;
  public SpriteRenderer charcoal;
  public SpriteRenderer charcoal_bag;
  public SpriteRenderer cash;
  public SpriteRenderer note;
  public SpriteRenderer papers;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_in_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "base_chimney_basket_empty";
    this.range = 1f;
    this.teleport = false;
    this.updateState();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("charcoal", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("charcoal_empty", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("planks1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("planks2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("planks3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("planks4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("planks5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("gas_note", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("pest_note", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("spider_note", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("invoices", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("wad_of_cash", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("bandage", GameStrings.getString(GameStrings.actions, "bandage_chimney"), anim: string.Empty));
  }

  private void Update()
  {
  }

  public void standSay()
  {
    this.range = 20f;
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
  }

  public void kneel()
  {
    this.range = 1f;
    this.characterAnimationName = "kneel_in_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
  }

  public void talk(string say)
  {
    Timeline.t.addAction(new TimelineAction()
    {
      blockG = true,
      textfield = PlayerController.pc.textField,
      text = say
    });
    if (!(this.characterAnimationName == "kneel_in_n"))
      return;
    Timeline.t.doNotUnlock = true;
  }

  public override void whatOnClick0()
  {
    if (this.usedItem == string.Empty)
    {
      this.standSay();
    }
    else
    {
      bool flag1 = false;
      bool flag2 = false;
      if (GameDataController.gd.getObjective("chimney_note") || GameDataController.gd.getObjective("chimney_cash") || GameDataController.gd.getObjective("chimney_bag") || GameDataController.gd.getObjective("chimney_papers"))
        flag1 = true;
      if (GameDataController.gd.getObjective("chimney_charcoal") || GameDataController.gd.getObjectiveDetail("chimney_wood") > 0)
        flag2 = true;
      if (!flag1 && (this.usedItem == "charcoal_empty" || this.usedItem == "spider_note" || this.usedItem == "pest_note" || this.usedItem == "gas_note" || this.usedItem == "wad_of_cash" || this.usedItem == "invoices"))
        this.standSay();
      else if (!flag2)
        this.standSay();
      else
        this.kneel();
    }
  }

  public void getup(string param = "") => PlayerController.wc.forceAnimation("kneel_out_n");

  public void talkAndGetUp(string say)
  {
    Timeline.t.addAction(new TimelineAction()
    {
      blockG = true,
      textfield = PlayerController.pc.textField,
      actionWithText = false,
      function = new TimelineFunction(this.getup),
      text = say
    });
    Timeline.t.doNotUnlock = true;
  }

  public override void clickAction()
  {
    bool flag1 = false;
    bool flag2 = false;
    if (GameDataController.gd.getObjective("basket_note") || GameDataController.gd.getObjective("basket_cash") || GameDataController.gd.getObjective("basket_bag") || GameDataController.gd.getObjective("basket_papers"))
      flag1 = true;
    if (GameDataController.gd.getObjective("basket_charcoal") || GameDataController.gd.getObjectiveDetail("basket_wood") > 0)
      flag2 = true;
    if (this.usedItem == string.Empty)
    {
      if (flag1 | flag2)
        this.talk(GameStrings.getString(GameStrings.actions, "chimney_basket_full"));
      else
        this.talk(GameStrings.getString(GameStrings.actions, "chimney_basket_empty"));
      if (GameDataController.gd.getObjective("basket_bag"))
        this.talk(GameStrings.getPrefixedShort(GameStrings.items, "charcoal_empty", true) + "...");
      if (GameDataController.gd.getObjective("basket_note"))
        this.talk(GameStrings.getPrefixedShort(GameStrings.items, "generic_note", true) + "...");
      if (GameDataController.gd.getObjective("basket_cash"))
        this.talk(GameStrings.getPrefixedShort(GameStrings.items, "wad_of_cash", true) + "...");
      if (GameDataController.gd.getObjective("basket_papers"))
        this.talk(GameStrings.getPrefixedShort(GameStrings.items, "invoices", true) + "...");
      if (GameDataController.gd.getObjective("basket_charcoal"))
        this.talk(GameStrings.getPrefixedShort(GameStrings.items, "charcoal", true));
      if (GameDataController.gd.getObjectiveDetail("basket_wood") == 1)
        this.talk(GameStrings.getString(GameStrings.actions, "base_chimney_basket_plank") + "...");
      if (GameDataController.gd.getObjectiveDetail("basket_wood") <= 1)
        return;
      this.talk(GameDataController.gd.getObjectiveDetail("basket_wood").ToString() + " " + GameStrings.getString(GameStrings.actions, "base_chimney_basket_planks") + "...");
    }
    else if (GameDataController.gd.getCurrentDay() == 1)
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "chimney_basket_d1"));
    }
    else
    {
      if ((this.usedItem == "pest_note" || this.usedItem == "gas_note" || this.usedItem == "spider_note") && !GameDataController.gd.getObjective("day1_complete"))
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "this_note_might_be_usefull"));
      else if (this.usedItem == "charcoal_empty" || this.usedItem == "pest_note" || this.usedItem == "gas_note" || this.usedItem == "spider_note" || this.usedItem == "wad_of_cash" || this.usedItem == "invoices")
      {
        if (GameDataController.gd.getObjective("chimney_note") || GameDataController.gd.getObjective("chimney_cash") || GameDataController.gd.getObjective("chimney_bag") || GameDataController.gd.getObjective("chimney_papers"))
        {
          if (this.usedItem == "charcoal_empty")
            GameDataController.gd.setObjective("basket_bag", true);
          if (this.usedItem == "pest_note" || this.usedItem == "gas_note" || this.usedItem == "spider_note")
            GameDataController.gd.setObjective("basket_note", true);
          if (this.usedItem == "wad_of_cash")
            GameDataController.gd.setObjective("basket_cash", true);
          if (this.usedItem == "invoices")
            GameDataController.gd.setObjective("basket_papers", true);
          InventoryController.ic.removeItem(this.usedItem);
          this.updateAll();
          this.talkAndGetUp(GameStrings.getString(GameStrings.actions, "basket_kindling1") + " " + GameStrings.getString(GameStrings.items, this.usedItem + "_short_accusative") + " " + GameStrings.getString(GameStrings.actions, "basket_kindling2"));
        }
        else
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "chimney_basket_kindling"));
      }
      if (!(this.usedItem == "planks1") && !(this.usedItem == "planks2") && !(this.usedItem == "planks3") && !(this.usedItem == "planks4") && !(this.usedItem == "planks5") && !(this.usedItem == "charcoal"))
        return;
      if (GameDataController.gd.getObjectiveDetail("chimney_wood") > 0 || GameDataController.gd.getObjective("chimney_charcoal"))
      {
        if (this.usedItem == "planks1" || this.usedItem == "planks2" || this.usedItem == "planks3" || this.usedItem == "planks4" || this.usedItem == "planks5")
          GameDataController.gd.setObjectiveDetail("basket_wood", GameDataController.gd.getObjectiveDetail("basket_wood") + 1);
        if (this.usedItem == "charcoal")
          GameDataController.gd.setObjective("basket_charcoal", true);
        InventoryController.ic.removeItem(this.usedItem);
        if (this.usedItem == "charcoal")
        {
          this.talkAndGetUp(GameStrings.getString(GameStrings.actions, "put_charcoal") + " " + GameStrings.getString(GameStrings.actions, "basket_kindling2"));
          InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("charcoal_empty"));
        }
        else
          this.talkAndGetUp(GameStrings.getString(GameStrings.actions, "basket_kindling1") + " " + GameStrings.getString(GameStrings.items, this.usedItem + "_short_accusative") + " " + GameStrings.getString(GameStrings.actions, "basket_kindling2"));
        this.updateAll();
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "chimney_basket_fuel"));
    }
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    this.objectName = "base_chimney_basket_empty";
    if (GameDataController.gd.getObjective("basket_note"))
    {
      this.note.enabled = true;
      this.objectName = "base_chimney_basket_filled";
    }
    else
      this.note.enabled = false;
    if (GameDataController.gd.getObjective("basket_cash"))
    {
      this.cash.enabled = true;
      this.objectName = "base_chimney_basket_filled";
    }
    else
      this.cash.enabled = false;
    if (GameDataController.gd.getObjective("basket_papers"))
    {
      this.papers.enabled = true;
      this.objectName = "base_chimney_basket_filled";
    }
    else
      this.papers.enabled = false;
    if (GameDataController.gd.getObjective("basket_bag"))
    {
      this.objectName = "base_chimney_basket_filled";
      this.charcoal_bag.enabled = true;
    }
    else
      this.charcoal_bag.enabled = false;
    if (GameDataController.gd.getObjective("basket_charcoal"))
    {
      this.objectName = "base_chimney_basket_filled";
      this.charcoal.enabled = true;
    }
    else
      this.charcoal.enabled = false;
    if (GameDataController.gd.getObjectiveDetail("basket_wood") == 0)
    {
      this.wood.enabled = false;
    }
    else
    {
      this.objectName = "base_chimney_basket_filled";
      this.wood.enabled = true;
    }
    if (GameDataController.gd.getObjectiveDetail("basket_wood") == 1)
      this.wood.sprite = this.wood1;
    else if (GameDataController.gd.getObjectiveDetail("basket_wood") == 2)
      this.wood.sprite = this.wood2;
    else if (GameDataController.gd.getObjectiveDetail("basket_wood") == 3)
      this.wood.sprite = this.wood3;
    else
      this.wood.sprite = this.wood4;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
