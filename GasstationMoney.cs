// Decompiled with JetBrains decompiler
// Type: GasstationMoney
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class GasstationMoney : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_cash";
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited") || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("wad_of_cash")))
      return;
    GameDataController.gd.setObjective("gasstation_cash_taken", true);
    this.updateAll();
  }

  public override void updateState()
  {
    this.characterAnimationName = "kneel_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited"))
    {
      this.characterAnimationName = "stand_";
      this.animationFlip = true;
    }
    if (GameDataController.gd.getObjective("gasstation_cash_taken"))
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
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited"))
      return;
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "gasstation_cash"), true);
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
