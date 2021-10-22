// Decompiled with JetBrains decompiler
// Type: PesttruckChemsuit1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class PesttruckChemsuit1 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "action_n";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "chemsuit_dmg";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("mask_filter", GameStrings.getString(GameStrings.actions, "pest_chemsuit_repair"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ducttape", GameStrings.getString(GameStrings.actions, "pest_chemsuit_repair"), anim: string.Empty));
    this.updateState();
  }

  public override void clickAction()
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("chemsuit_dmg_dmg")))
      return;
    GameDataController.gd.setObjective("pesttruck_chemsuit_dmg_taken", !GameDataController.gd.getObjective("pesttruck_chemsuit_dmg_taken"));
    this.updateState();
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 1)
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(-1);
    }
    else if (!GameDataController.gd.getObjective("pesttruck_chemsuit_dmg_taken") && GameDataController.gd.getObjective("pesttruck_locker1_open"))
    {
      this.characterAnimationName = "action_n";
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
