// Decompiled with JetBrains decompiler
// Type: LocationBridgePlanks
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationBridgePlanks : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "bridge_planks";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("hammer", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("nails1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("nails2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("nails3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("nails4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("nails5", string.Empty, anim: string.Empty));
  }

  public override void clickAction()
  {
    if (this.usedItem == "hammer" || this.usedItem == "nails1" || this.usedItem == "nails2" || this.usedItem == "nails3" || this.usedItem == "nails4" || this.usedItem == "nails5")
    {
      if (ItemsManager.im.getItem("nails1").dataRef.droppedLocation != "inventory" && ItemsManager.im.getItem("nails2").dataRef.droppedLocation != "inventory" && ItemsManager.im.getItem("nails3").dataRef.droppedLocation != "inventory" && ItemsManager.im.getItem("nails4").dataRef.droppedLocation != "inventory" && ItemsManager.im.getItem("nails5").dataRef.droppedLocation != "inventory")
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "no_nails"), true);
      else if (ItemsManager.im.getItem("hammer").dataRef.droppedLocation != "inventory")
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "nails_fail"), true);
      else if (!GameDataController.gd.getObjective("bridge_planks_used_1"))
      {
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "bridge_planks1"), yesClick: new Button.Delegate(this.yesClicked), time: 90, timeSaver: 20);
      }
      else
      {
        if (GameDataController.gd.getObjective("bridge_planks_used_2"))
          return;
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "bridge_planks2"), yesClick: new Button.Delegate(this.yesClicked), time: 120, timeSaver: 20);
      }
    }
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "bridge_planks"), true, mwidth: 150);
  }

  public void yesClicked()
  {
    Item[] objArray = new Item[5]
    {
      ItemsManager.im.getItem("nails1"),
      ItemsManager.im.getItem("nails2"),
      ItemsManager.im.getItem("nails3"),
      ItemsManager.im.getItem("nails4"),
      ItemsManager.im.getItem("nails5")
    };
    Item obj = (Item) null;
    for (int index = 0; index < objArray.Length; ++index)
    {
      if (objArray[index].dataRef.droppedLocation == "inventory")
      {
        obj = objArray[index];
        break;
      }
    }
    ItemsManager.im.updateItem(obj.id, "window1", 0, 0);
    InventoryController.ic.removeItem(obj.id);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.nailed);
    if (!GameDataController.gd.getObjective("bridge_planks_used_1"))
      GameDataController.gd.setObjective("bridge_planks_used_1", true);
    else if (!GameDataController.gd.getObjective("bridge_planks_used_2"))
      GameDataController.gd.setObjective("bridge_planks_used_2", true);
    PlayerController.wc.forceAnimation("kneel_n");
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.N, animation: "kneel_n");
  }

  public override void whatOnClick0()
  {
    MonoBehaviour.print((object) ("IM WHAT ON CLICK " + this.usedItem));
    if (this.usedItem == "hammer")
    {
      this.range = 1f;
      MonoBehaviour.print((object) "THE RANGE IS SET TO 1");
    }
    else
      this.range = 100f;
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("bridge_planks_used_1"))
    {
      this.colliderManager.setCollider(0);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationBridge/bridge_planks");
    }
    else if (!GameDataController.gd.getObjective("bridge_planks_used_2"))
    {
      this.colliderManager.setCollider(0);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationBridge/bridge_planks2");
    }
    else
    {
      this.colliderManager.setCollider(-1);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
