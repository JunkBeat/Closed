// Decompiled with JetBrains decompiler
// Type: CS3Ammo
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class CS3Ammo : ObjectActionController
{
  public Sprite ammobox1;
  public Sprite ammobox2;
  private CursorController cursorController;
  public SpriteRenderer box1;
  public SpriteRenderer box2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_in_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_ammobox";
    this.range = 1f;
    this.updateState();
    this.cursorController = GameObject.Find("cursor").GetComponent<CursorController>();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("oil", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("water1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("water2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("water3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("water4", string.Empty, anim: string.Empty));
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() == 4)
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "ammo_day4"));
    }
    else
    {
      if (this.usedItem == "oil")
      {
        GameDataController.gd.setObjective("cs_ammo_oiled", true);
        PlayerController.pc.forceAnimation("kneel_out_n");
        InventoryController.ic.removeItem(this.usedItem);
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.liquid_pour_small, 0.5f);
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_ammobox_oil"));
      }
      else if (this.usedItem.IndexOf("water") != -1)
      {
        GameDataController.gd.setObjective("cs_ammo_watered", true);
        PlayerController.pc.forceAnimation("kneel_out_n");
        InventoryController.ic.removeItem(this.usedItem);
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.liquid_pour_small, 0.5f);
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_ammobox_water"));
      }
      else if (!GameDataController.gd.getObjective("cs_ammo_oiled") && !GameDataController.gd.getObjective("cs_ammo_watered"))
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.trunk_open);
        ExamineSprite.es.textField.shift.x = -80f;
        ExamineSprite.es.textField.shift.y = -20f;
        ExamineSprite.es.readyText(new List<string>()
        {
          GameStrings.getString(GameStrings.world_labels, "cs_ammobox")
        }, 200, 0.9490196f, 0.7882353f, 0.0f, 1f, 1f, 0.8f, 0.0f);
        ExamineSprite.es.cycleSprites = true;
        ExamineSprite.es.closingAnimation = "kneel_out_n";
        ExamineSprite.es.show(this.ammobox2, this.ammobox2, this.ammobox2, act: new ExamineSprite.Delegate(this.aaa), actionOnOpen: false);
      }
      else
      {
        if (!GameDataController.gd.getObjective("cs_ammo_oiled") && !GameDataController.gd.getObjective("cs_ammo_watered"))
          PlayerController.pc.forceAnimation("kneel_out_n");
        this.aaa();
      }
      this.updateState();
    }
  }

  public void aaa()
  {
    if (GameDataController.gd.getObjective("cs_ammo_oiled"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_ammobox_oil"));
    else if (GameDataController.gd.getObjective("cs_ammo_watered"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_ammobox_water"));
    }
    else
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.trunk_close);
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_ammobox_2"));
    }
  }

  public override void updateState()
  {
    this.box1.enabled = true;
    this.box2.enabled = true;
    this.setCollider(0);
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
    {
      this.box1.enabled = false;
      this.box2.enabled = false;
      this.setCollider(-1);
    }
    else if (!GameDataController.gd.getObjective("cs_ammo_oiled") && !GameDataController.gd.getObjective("cs_ammo_watered"))
    {
      this.characterAnimationName = "kneel_in_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
    if (!(this.usedItem != string.Empty))
      return;
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_ammobox_1"));
  }

  public override void whatOnClick0()
  {
    if (!(this.usedItem != string.Empty))
      return;
    this.characterAnimationName = "kneel_in_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
  }

  public override void whatOnClick()
  {
  }
}
