// Decompiled with JetBrains decompiler
// Type: GasstationCrowbar
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class GasstationCrowbar : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_crowbar";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("hammer", string.Empty, anim: string.Empty));
    this.range = 1f;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited"))
      return;
    if (this.usedItem == "hammer")
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "gasstation_hammer_crowbar"), yesClick: new Button.Delegate(this.giveCrowbar), time: 1);
    else
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "gasstation_force_crowbar"), yesClick: new Button.Delegate(this.giveCrowbar), time: 5);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("gasstation_crowbar_free"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(-1);
    }
    else
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.colliderManager.setCollider(0);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public void giveCrowbar()
  {
    this.drop();
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.E);
  }

  public void drop()
  {
    GameDataController.gd.setObjective("gasstation_crowbar_free", true);
    Item itemRef = ItemsManager.im.getItem("crowbar");
    this.updateState();
    InventoryController.ic.pickOrDropItem(itemRef);
  }

  public override void whatOnClick0()
  {
    if (GameDataController.gd.getCurrentDay() != 1 || GameDataController.gd.getObjectiveDetail("day_1_threat") != 2 || GameDataController.gd.getObjective("gasstation_spider_baited"))
      return;
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "nasty_spider_blocking"), true);
  }

  public override void whatOnClick()
  {
    if (GameDataController.gd.getCurrentDay() != 1 || GameDataController.gd.getObjectiveDetail("day_1_threat") != 2 || GameDataController.gd.getObjective("gasstation_spider_baited"))
      return;
    PlayerController.wc.fullStop(true);
  }
}
