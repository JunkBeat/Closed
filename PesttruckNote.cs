// Decompiled with JetBrains decompiler
// Type: PesttruckNote
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class PesttruckNote : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "action_n";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "pest_note";
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0 && InventoryController.ic.pickUpItem(ItemsManager.im.getItem("pest_note")))
    {
      GameDataController.gd.setObjective("pesttruck_note_taken", !GameDataController.gd.getObjective("pesttruck_note_taken"));
      ExamineSprite.es.show(ItemsManager.im.getItem("pest_note").examineSprite);
      this.updateState();
    }
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1 && InventoryController.ic.pickUpItem(ItemsManager.im.getItem("gas_note")))
    {
      ExamineSprite.es.textField.shift.x = (float) ItemsManager.im.getItem("gas_note").textShiftX;
      ExamineSprite.es.textField.shift.y = (float) ItemsManager.im.getItem("gas_note").textShiftY;
      List<string> _pages = new List<string>();
      if (ItemsManager.im.getItem("gas_note").examineTexts != null)
      {
        for (int index = 0; index < ItemsManager.im.getItem("gas_note").examineTexts.Count; ++index)
          _pages.Add(ItemsManager.im.getItem("gas_note").examineTexts[index]);
      }
      ExamineSprite.es.readyText(_pages, ItemsManager.im.getItem("gas_note").textWidth, ItemsManager.im.getItem("gas_note").textColor1.r, ItemsManager.im.getItem("gas_note").textColor1.g, ItemsManager.im.getItem("gas_note").textColor1.b, ItemsManager.im.getItem("gas_note").textColor2.r, ItemsManager.im.getItem("gas_note").textColor2.g, ItemsManager.im.getItem("gas_note").textColor2.b, ItemsManager.im.getItem("gas_note").textColor2.a);
      GameDataController.gd.setObjective("pesttruck_note_taken", !GameDataController.gd.getObjective("pesttruck_note_taken"));
      ExamineSprite.es.show(ItemsManager.im.getItem("gas_note").examineSprite);
      this.updateState();
    }
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 2 || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("spider_note")))
      return;
    ExamineSprite.es.textField.shift.x = (float) ItemsManager.im.getItem("spider_note").textShiftX;
    ExamineSprite.es.textField.shift.y = (float) ItemsManager.im.getItem("spider_note").textShiftY;
    List<string> _pages1 = new List<string>();
    if (ItemsManager.im.getItem("spider_note").examineTexts != null)
    {
      for (int index = 0; index < ItemsManager.im.getItem("spider_note").examineTexts.Count; ++index)
        _pages1.Add(ItemsManager.im.getItem("spider_note").examineTexts[index]);
    }
    ExamineSprite.es.readyText(_pages1, ItemsManager.im.getItem("spider_note").textWidth, ItemsManager.im.getItem("spider_note").textColor1.r, ItemsManager.im.getItem("spider_note").textColor1.g, ItemsManager.im.getItem("spider_note").textColor1.b, ItemsManager.im.getItem("spider_note").textColor2.r, ItemsManager.im.getItem("spider_note").textColor2.g, ItemsManager.im.getItem("spider_note").textColor2.b, ItemsManager.im.getItem("spider_note").textColor2.a);
    GameDataController.gd.setObjective("pesttruck_note_taken", !GameDataController.gd.getObjective("pesttruck_note_taken"));
    ExamineSprite.es.show(ItemsManager.im.getItem("spider_note").examineSprite);
    this.updateState();
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      this.objectName = "pest_note";
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
      this.objectName = "gas_note";
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
      this.objectName = "spider_note";
    if (!GameDataController.gd.getObjective("pesttruck_note_taken") && GameDataController.gd.getObjective("pesttruck_locker4_open"))
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

  public override void clickAction2() => PlayerController.wc.forceAnimation("action_stnd_n");

  public override void clickAction0()
  {
  }
}
