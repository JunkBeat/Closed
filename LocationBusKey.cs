// Decompiled with JetBrains decompiler
// Type: LocationBusKey
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class LocationBusKey : ObjectActionController
{
  public Sprite zoom;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action1_e";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "bus_key";
    this.range = 1f;
    this.teleport = false;
    this.updateState();
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("key3")))
      return;
    GameDataController.gd.setObjective("bus_key_taken", true);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("bus_key_taken"))
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.setCollider(-1);
    }
    else
    {
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.setCollider(0);
    }
  }

  public override void clickAction2()
  {
    if (GameDataController.gd.getObjective("bus_key_taken"))
    {
      PlayerController.wc.forceAnimation("stand_se", true);
      ExamineSprite.es.textField.shift.x = -110f;
      ExamineSprite.es.textField.shift.y = 20f;
      ExamineSprite.es.readyText(new List<string>()
      {
        GameStrings.getString(GameStrings.world_labels, "key3_inspect")
      }, 100, 1f, 1f, 1f, 0.0f, 0.0f, 0.0f, 0.75f);
      ExamineSprite.es.show(this.zoom);
    }
    this.updateAll();
  }

  public override void clickAction0()
  {
  }
}
