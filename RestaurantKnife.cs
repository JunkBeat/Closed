// Decompiled with JetBrains decompiler
// Type: RestaurantKnife
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RestaurantKnife : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_knife";
    this.range = 1f;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("restaurant_knife_taken") || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("knife")))
      return;
    GameDataController.gd.setObjective("restaurant_knife_taken", true);
    this.updateState();
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("restaurant_knife_taken") || !GameDataController.gd.getObjective("restaurant_cupboard3_open"))
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

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
