// Decompiled with JetBrains decompiler
// Type: HouseBBlanket
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class HouseBBlanket : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "house_b_blanket";
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("house_b_blanket_taken") || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("blanketb")))
      return;
    GameDataController.gd.setObjective("house_b_blanket_taken", true);
    this.updateState();
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (!GameDataController.gd.getObjective("house_b_blanket_taken"))
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
