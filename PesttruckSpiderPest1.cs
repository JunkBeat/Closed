// Decompiled with JetBrains decompiler
// Type: PesttruckSpiderPest1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class PesttruckSpiderPest1 : ObjectActionController
{
  public Sprite sprite1;
  public Sprite sprite2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "kneel_n";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "pest_truck_spider_pest1";
    this.updateState();
  }

  public override void clickAction()
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("spiderpest1")))
      return;
    GameDataController.gd.setObjective("pesttruck_spiderpest1_taken", true);
    this.updateState();
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 2)
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(-1);
    }
    else if (!GameDataController.gd.getObjective("pesttruck_spiderpest1_taken") && GameDataController.gd.getObjective("pesttruck_locker1_open"))
    {
      this.characterAnimationName = "kneel_n";
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.sprite1;
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.colliderManager.setCollider(0);
    }
    else if (GameDataController.gd.getObjective("pesttruck_spiderpest1_taken") && GameDataController.gd.getObjective("pesttruck_locker1_open"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.sprite2;
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.colliderManager.setCollider(-1);
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
