// Decompiled with JetBrains decompiler
// Type: BaseChest
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class BaseChest : ObjectActionController
{
  public Sprite sign;
  public Sprite chestexamine;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "base_chest";
    this.range = 2f;
    this.allowAllItems = true;
  }

  public override void clickAction()
  {
    if (this.usedItem == "ext_cord_place")
      PlayerController.pc.say(GameStrings.getWrongInteractionText());
    else if (this.usedItem == "ac_cord")
    {
      PlayerController.pc.say(GameStrings.getWrongInteractionText());
    }
    else
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.trunk_open);
      if (this.usedItem == string.Empty)
      {
        if (!GameDataController.gd.getObjective("chest_tutorial"))
          this.chestTutorial();
        else
          InventoryButtonController.ibc.openChest();
      }
      else if (!GameDataController.gd.getObjective("chest_tutorial"))
      {
        this.chestTutorial();
      }
      else
      {
        if ((double) ItemsManager.im.getItem(this.usedItem).weight < 0.0)
          return;
        InventoryController.ic.putItemInChest(this.usedItem);
      }
    }
  }

  public void openTheChest() => InventoryButtonController.ibc.openChest();

  public void chestTutorial()
  {
    if (GameDataController.gd.getObjective("chest_tutorial"))
      return;
    ExamineSprite.es.textField.shift.x = -110f;
    ExamineSprite.es.textField.shift.y = 30f;
    ExamineSprite.es.readyText(new List<string>()
    {
      GameStrings.getString(GameStrings.gui, "chest_tutorial1"),
      GameStrings.getString(GameStrings.gui, "chest_tutorial2")
    }, 90, 1f, 1f, 1f, 0.0f, 0.0f, 0.0f, 0.75f);
    ExamineSprite.es.show(this.chestexamine, act: new ExamineSprite.Delegate(this.openTheChest), actionOnOpen: false);
    GameDataController.gd.setObjective("chest_tutorial", true);
  }

  public override void updateState() => this.colliderManager.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
    if (this.usedItem == "ext_cord_place" || this.usedItem == "ac_cord")
    {
      this.range = 300f;
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
    else
    {
      this.characterAnimationName = "action_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.range = 2f;
    }
  }

  public override void whatOnClick()
  {
  }
}
