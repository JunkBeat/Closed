// Decompiled with JetBrains decompiler
// Type: HouseBSheet
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class HouseBSheet : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "house_b_inside_sheet";
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("house_b_sheet_taken") || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("sheet")))
      return;
    GameDataController.gd.setObjective("house_b_sheet_taken", true);
    this.updateState();
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (!GameDataController.gd.getObjective("house_b_sheet_taken"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    else
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(-1);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
