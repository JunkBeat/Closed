// Decompiled with JetBrains decompiler
// Type: RestaurantFridge
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class RestaurantFridge : ObjectActionController
{
  public Sprite closed;
  public Sprite open_2;
  public Sprite open_1;
  public Sprite open_0;
  public Sprite open_2b;
  public Sprite open_1b;
  public Sprite open_0b;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_fridge";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("pipe", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("crowbar", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("hammer", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("wrench", string.Empty, anim: string.Empty));
  }

  public void opensond() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.fridge);

  public void break_glass() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.break_window);

  public void otherOpen()
  {
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.N, animation: "action_stnd_ne", flipX: true);
    this.Invoke("break_glass", 0.5f);
    GameDataController.gd.setObjective("restaurant_fridge_broken", true);
  }

  public void crowbarOpen()
  {
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.N, animation: "action_stnd_ne", flipX: true);
    this.Invoke("opensond", 0.5f);
    GameDataController.gd.setObjective("restaurant_fridge_open", true);
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("restaurant_fridge_open") && !GameDataController.gd.getObjective("restaurant_fridge_broken"))
    {
      if (this.usedItem == string.Empty)
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "restaurant_fridge_locked"));
      else if (this.usedItem == "crowbar")
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "restaurant_fridge_open"), yesClick: new Button.Delegate(this.crowbarOpen), time: 5);
      else
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "restaurant_fridge_break"), yesClick: new Button.Delegate(this.otherOpen), time: 10);
    }
    else if (!GameDataController.gd.getObjective("restaurant_water_taken1"))
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("water1")))
        return;
      GameDataController.gd.setObjective("restaurant_water_taken1", true);
      this.updateAll();
    }
    else
    {
      if (GameDataController.gd.getObjective("restaurant_water_taken2") || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("water2")))
        return;
      GameDataController.gd.setObjective("restaurant_water_taken2", true);
      this.updateAll();
    }
  }

  public override void whatOnClick0()
  {
    if (!GameDataController.gd.getObjective("restaurant_fridge_open") && !GameDataController.gd.getObjective("restaurant_fridge_broken"))
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
    else
    {
      this.characterAnimationName = "action_n";
      this.animationFlip = true;
      this.useCurrentDirection = false;
    }
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("restaurant_fridge_open") && !GameDataController.gd.getObjective("restaurant_fridge_broken"))
    {
      this.setCollider(0);
      this.characterAnimationName = "open_n";
      this.GetComponent<SpriteRenderer>().sprite = this.closed;
      this.objectName = "restaurant_fridge";
    }
    else if (!GameDataController.gd.getObjective("restaurant_water_taken1") && !GameDataController.gd.getObjective("restaurant_fridge_broken"))
    {
      this.setCollider(1);
      this.GetComponent<SpriteRenderer>().sprite = this.open_2;
      this.characterAnimationName = "action_n";
      this.objectName = "restaurant_fridge_water2";
    }
    else if (!GameDataController.gd.getObjective("restaurant_water_taken2") && !GameDataController.gd.getObjective("restaurant_fridge_broken"))
    {
      this.setCollider(2);
      this.GetComponent<SpriteRenderer>().sprite = this.open_1;
      this.characterAnimationName = "action_n";
      this.objectName = "restaurant_fridge_water1";
    }
    else if (!GameDataController.gd.getObjective("restaurant_fridge_broken"))
    {
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().sprite = this.open_0;
    }
    else if (!GameDataController.gd.getObjective("restaurant_water_taken1"))
    {
      this.setCollider(1);
      this.GetComponent<SpriteRenderer>().sprite = this.open_2b;
      this.characterAnimationName = "action_n";
      this.objectName = "restaurant_fridge_water2";
    }
    else if (!GameDataController.gd.getObjective("restaurant_water_taken2"))
    {
      this.setCollider(2);
      this.GetComponent<SpriteRenderer>().sprite = this.open_1b;
      this.characterAnimationName = "action_n";
      this.objectName = "restaurant_fridge_water1";
    }
    else
    {
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().sprite = this.open_0b;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
