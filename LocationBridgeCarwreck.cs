// Decompiled with JetBrains decompiler
// Type: LocationBridgeCarwreck
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationBridgeCarwreck : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("wrench", string.Empty, anim: string.Empty));
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.range = 100f;
    this.dkvs = GameStrings.objects;
    this.objectName = "bridge_carwreck_wheel";
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("bridge_wheel_taken"))
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "bridge_carwreck"), true, mwidth: 150);
    else if (this.usedItem == string.Empty)
    {
      TimelineAction action = new TimelineAction(PlayerController.pc.textField);
      action.text = GameStrings.getString(GameStrings.actions, "bridge_carwreck_wheel");
      action.blockG = true;
      if (InventoryController.ic.isItemInInventory("wrench"))
      {
        Timeline.t.addAction(action);
        Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
        {
          text = GameStrings.getString(GameStrings.actions, "bridge_carwreck_wheel2"),
          blockG = true
        });
      }
      else
        Timeline.t.addAction(action);
    }
    else
      this.askQuestion();
  }

  public void askQuestion() => QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "bridge_wheel"), yesClick: new Button.Delegate(this.removeWheel), time: 15, timeSaver: 2);

  public void removeWheel() => CurtainController.cc.fadeOut(targetDir: WalkController.Direction.N, animation: "action_stnd_ne", flipX: true, actionAfterFade: new CurtainController.Delegate(this.sayAboutCarHarvest));

  public void sayAboutCarHarvest()
  {
    InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("wheel"));
    GameDataController.gd.setObjective("bridge_wheel_taken", true);
    this.updateAll();
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "got_wheel"));
  }

  public override void whatOnClick0()
  {
    if (this.usedItem == "wrench")
      this.range = 2f;
    else
      this.range = 100f;
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjective("bridge_wheel_taken"))
    {
      this.objectName = "bridge_carwreck";
      this.colliderManager.setCollider(0);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      this.objectName = "bridge_carwreck_wheel";
      this.colliderManager.setCollider(1);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
