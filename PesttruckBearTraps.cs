// Decompiled with JetBrains decompiler
// Type: PesttruckBearTraps
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PesttruckBearTraps : ObjectActionController
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
    this.objectName = "pesttruck_bear_traps";
    this.updateState();
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjectiveDetail("pesttruck_bear_traps_taken") == 0)
    {
      if (InventoryController.ic.pickUpItem(ItemsManager.im.getItem("bear_trap_1")))
        GameDataController.gd.setObjectiveDetail("pesttruck_bear_traps_taken", 1);
    }
    else if (GameDataController.gd.getObjectiveDetail("pesttruck_bear_traps_taken") == 1 && InventoryController.ic.pickUpItem(ItemsManager.im.getItem("bear_trap_2")))
      GameDataController.gd.setObjectiveDetail("pesttruck_bear_traps_taken", 2);
    this.updateAll();
  }

  public override void whatOnClick()
  {
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 2)
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(-1);
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("pesttruck_bear_traps_taken") == 0)
      {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.sprite1;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        this.colliderManager.setCollider(0);
        this.objectName = "pesttruck_bear_traps";
      }
      else if (GameDataController.gd.getObjectiveDetail("pesttruck_bear_traps_taken") == 1)
      {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.sprite2;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        this.colliderManager.setCollider(0);
        this.objectName = "pesttruck_bear_trap";
      }
      else
      {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.colliderManager.setCollider(-1);
      }
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
