// Decompiled with JetBrains decompiler
// Type: LocationKitchenKey
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationKitchenKey : ObjectActionController
{
  public bool shined;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "house_key";
    this.shined = false;
  }

  public override void clickAction()
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("key2")))
      return;
    GameDataController.gd.setObjective("house_key_taken", true);
    this.updateAll();
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("house_key_taken"))
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

  public void shine()
  {
    if (!this.shined)
    {
      this.shined = true;
    }
    else
    {
      if ((double) Random.value <= 0.25)
        return;
      this.gameObject.GetComponent<Animator>().Play("Location2KeyShine", 0, 0.0f);
    }
  }
}
