// Decompiled with JetBrains decompiler
// Type: LocationBusSmudge
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationBusSmudge : ObjectActionController
{
  public Sprite zoom;
  public Sprite zoom2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "bus_fingerprint";
    this.range = 2f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("gluegun", GameStrings.getString(GameStrings.actions, "gluegun_no_power"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("gluegun_powered", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("screwdriver", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("knife", string.Empty, anim: string.Empty));
  }

  public override void clickAction()
  {
    if (this.usedItem == string.Empty)
    {
      if (GameDataController.gd.getObjectiveDetail("bus_fingerprint_molded") == 1)
      {
        ExamineSprite.es.textField.shift.x = -110f;
        ExamineSprite.es.textField.shift.y = 20f;
        ExamineSprite.es.readyText(new List<string>()
        {
          GameStrings.getString(GameStrings.actions, "bus_fingerprint2")
        }, 100, 1f, 1f, 1f, 0.0f, 0.0f, 0.0f, 0.75f);
        ExamineSprite.es.show(this.zoom2);
      }
      else
      {
        ExamineSprite.es.textField.shift.x = -110f;
        ExamineSprite.es.textField.shift.y = 20f;
        ExamineSprite.es.readyText(new List<string>()
        {
          GameStrings.getString(GameStrings.actions, "bus_fingerprint")
        }, 100, 1f, 1f, 1f, 0.0f, 0.0f, 0.0f, 0.75f);
        ExamineSprite.es.show(this.zoom);
      }
    }
    else if (this.usedItem == "screwdriver" || this.usedItem == "knife")
    {
      if (GameDataController.gd.getObjectiveDetail("bus_fingerprint_molded") == 1)
      {
        if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("fingerprint")))
          return;
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "fingerprint_mold_taken"));
        GameDataController.gd.setObjectiveDetail("bus_fingerprint_molded", 2);
        this.updateAll();
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "fingerprint_no_mold"));
    }
    else
    {
      Timeline.t.addAction(new TimelineAction()
      {
        textfield = PlayerController.pc.textField,
        text = GameStrings.getString(GameStrings.actions, "gluegun_take_impression_1"),
        actionWithText = false
      });
      Timeline.t.addAction(new TimelineAction()
      {
        textfield = PlayerController.pc.textField,
        text = GameStrings.getString(GameStrings.actions, "gluegun_take_impression_2"),
        actionWithText = false
      });
      InventoryController.ic.removeItem("gluegun_powered");
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.small_powerup);
      GameDataController.gd.setObjectiveDetail("bus_fingerprint_molded", 1);
      this.updateAll();
    }
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjectiveDetail("bus_fingerprint_molded") == 1)
    {
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.objectName = "bus_fingerprint";
    }
    else if (GameDataController.gd.getObjectiveDetail("bus_fingerprint_molded") == 2)
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(-1);
    }
    else
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.objectName = "bus_fingerprint";
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
    if (this.usedItem == "gluegun_powered")
      return;
    this.characterAnimationName = "action_stnd_n";
  }

  public override void whatOnClick()
  {
  }
}
