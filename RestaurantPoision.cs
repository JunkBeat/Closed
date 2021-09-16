// Decompiled with JetBrains decompiler
// Type: RestaurantPoision
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class RestaurantPoision : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.characterAnimationName = "action1_e";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_poision";
    this.range = 2f;
    this.updateState();
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("restaurant_poision_taken"))
      return;
    this.pickItUp((string) null);
  }

  private void pickItUp(string param)
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("poison")))
      return;
    GameDataController.gd.setObjective("restaurant_poision_taken", true);
    this.updateAll();
  }

  public override void whatOnClick()
  {
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("restaurant_chem_door_open"))
    {
      this.setCollider(-1);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    else if (GameDataController.gd.getObjective("restaurant_poision_taken"))
    {
      this.setCollider(-1);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      this.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
