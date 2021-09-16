// Decompiled with JetBrains decompiler
// Type: HouseBShovel
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class HouseBShovel : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "house_b_shovel";
    this.range = 1f;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("house_b_shovel_taken") || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("shovel")))
      return;
    GameDataController.gd.setObjective("house_b_shovel_taken", true);
    this.updateState();
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("house_b_garage_open"))
    {
      if (GameDataController.gd.getObjective("house_b_shovel_taken"))
      {
        this.setCollider(-1);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      }
      else
      {
        this.setCollider(0);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      }
    }
    else
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.setCollider(-1);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
