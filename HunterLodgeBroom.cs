// Decompiled with JetBrains decompiler
// Type: HunterLodgeBroom
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class HunterLodgeBroom : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = true;
    this.characterAnimationName = "action1_e";
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "broom";
  }

  public override void clickAction()
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("broom")))
      return;
    GameDataController.gd.setObjective("lodge_broom_taken", true);
    this.updateAll();
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("lodge_broom_taken") && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.colliderManager.setCollider(0);
    }
    else
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
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
