// Decompiled with JetBrains decompiler
// Type: RestaurantOil
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class RestaurantOil : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.characterAnimationName = "kneel_n";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_oil";
    this.range = 2f;
    this.updateState();
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("restaurant_oil_taken"))
      return;
    this.pickItUp((string) null);
  }

  private void pickItUp(string param)
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("oil")))
      return;
    GameDataController.gd.setObjective("restaurant_oil_taken", true);
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
    else if (GameDataController.gd.getObjective("restaurant_oil_taken"))
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
