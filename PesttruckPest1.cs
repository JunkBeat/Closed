// Decompiled with JetBrains decompiler
// Type: PesttruckPest1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class PesttruckPest1 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "kneel_n";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "pest_can";
    this.updateState();
  }

  public override void clickAction()
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("pest1")))
      return;
    GameDataController.gd.setObjective("pesttruck_pest1_taken", !GameDataController.gd.getObjective("pesttruck_pest1_taken"));
    this.updateState();
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 0)
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(-1);
    }
    else if (!GameDataController.gd.getObjective("pesttruck_pest1_taken") && GameDataController.gd.getObjective("pesttruck_locker1_open"))
    {
      this.characterAnimationName = "kneel_n";
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
