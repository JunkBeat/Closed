// Decompiled with JetBrains decompiler
// Type: GreenhouseSprayer
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class GreenhouseSprayer : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "greenhouse_sprayer";
    this.range = 5f;
  }

  public override void clickAction()
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("watersprayer")))
      return;
    GameDataController.gd.setObjective("greenhouse_sprayer_taken", true);
    this.updateAll();
  }

  public override void whatOnClick()
  {
    if ((double) PlayerController.wc.currentXY.y < 69.0)
      this.characterAnimationName = "action_n";
    else
      this.characterAnimationName = "action_s";
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("greenhouse_sprayer_taken"))
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
}
