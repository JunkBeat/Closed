// Decompiled with JetBrains decompiler
// Type: CS3Food
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class CS3Food : ObjectActionController
{
  public Sprite ammobox1;
  public Sprite ammobox2;
  private CursorController cursorController;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_food";
    this.range = 1f;
    this.updateState();
    this.cursorController = GameObject.Find("cursor").GetComponent<CursorController>();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("poison", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("whiskey", string.Empty, anim: string.Empty));
  }

  private void Update()
  {
  }

  private void poisionit()
  {
    GameDataController.gd.setObjective("cs_food_poisioned", true);
    InventoryController.ic.removeItem("poison");
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.liquid_pour_small, 0.5f);
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_food_poisioned"));
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() == 4)
    {
      if (GameDataController.gd.getObjective("cs_food_poisioned"))
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_food_poisioned2"));
      else if (this.usedItem == string.Empty && !GameDataController.gd.getObjective("cs_food_taken"))
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_food_taken"));
        InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("food_bag"));
        GameDataController.gd.setObjective("cs_food_taken", true);
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "food_day4"));
    }
    else
    {
      if (this.usedItem == "poison")
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "poision_food"), yesClick: new Button.Delegate(this.poisionit));
      else if (this.usedItem == "whiskey")
      {
        InventoryController.ic.dropItem(ItemsManager.im.getItem("whiskey"), true);
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_food_whiskey"));
      }
      else if (GameDataController.gd.getObjective("cs_food_poisioned"))
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_food_poisioned2"));
      else if (GameDataController.gd.getObjective("cs_food_taken"))
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_food_taken2"));
      }
      else
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_food_taken"));
        InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("food_bag"));
        GameDataController.gd.setObjective("cs_food_taken", true);
      }
      this.updateState();
    }
  }

  public override void updateState()
  {
    this.setCollider(0);
    this.GetComponent<SpriteRenderer>().enabled = true;
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
    {
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
    }
    else if (!GameDataController.gd.getObjective("cs_food_poisioned"))
      this.objectName = "cs_food";
    else
      this.objectName = "cs_food_poisioned";
    this.interactions = new List<ItemInteraction>();
    if (GameDataController.gd.getCurrentDay() != 3)
      return;
    this.interactions.Add(new ItemInteraction("poison", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("whiskey", string.Empty, anim: string.Empty));
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    if (this.usedItem == string.Empty && !GameDataController.gd.getObjective("cs_food_taken"))
    {
      this.characterAnimationName = "action1_e";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    if (!(this.usedItem == "whiskey"))
      return;
    this.characterAnimationName = "kneel_s";
    this.animationFlip = false;
    this.useCurrentDirection = false;
  }

  public override void whatOnClick()
  {
  }
}
