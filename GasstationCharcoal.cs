// Decompiled with JetBrains decompiler
// Type: GasstationCharcoal
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class GasstationCharcoal : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_charcoal";
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited") || GameDataController.gd.getObjective("gasstation_charcoal_taken") || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("charcoal")))
      return;
    GameDataController.gd.setObjective("gasstation_charcoal_taken", true);
    this.updateState();
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (!GameDataController.gd.getObjective("gasstation_charcoal_taken"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.characterAnimationName = "kneel_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(-1);
    }
  }

  public override void clickAction2()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited") || GameDataController.gd.getCurrentDay() != 1)
      return;
    Timeline.t.addAction(new TimelineAction(GameObject.Find("BottomText").GetComponent<TextFieldController>())
    {
      text = "[" + GameStrings.getString(GameStrings.gui, "items_hint") + "]",
      actionWithText = true,
      textWidth = 170,
      blockG = true
    });
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick()
  {
    if (GameDataController.gd.getCurrentDay() != 1 || GameDataController.gd.getObjectiveDetail("day_1_threat") != 2 || GameDataController.gd.getObjective("gasstation_spider_baited"))
      return;
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "nasty_spider_blocking"), true);
    PlayerController.wc.fullStop(true);
  }
}
