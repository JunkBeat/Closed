// Decompiled with JetBrains decompiler
// Type: RifleGasstation
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RifleGasstation : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_rifle";
    this.updateState();
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited") || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("rifle_6")))
      return;
    GameDataController.gd.setObjective("gasstation_rifle_taken", true);
    ItemsManager.im.getItem("rifle_6");
    this.updateState();
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("gasstation_rifle_taken"))
    {
      this.setCollider(0);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    else
    {
      this.setCollider(-1);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
  }

  public override void clickAction2()
  {
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
