// Decompiled with JetBrains decompiler
// Type: BridgeDrone
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class BridgeDrone : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.characterAnimationName = "kneel_";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "bridge_drone";
    this.range = 6f;
    this.updateState();
  }

  public override void clickAction() => this.pickItUp((string) null);

  private void pickItUp(string param)
  {
    this.updateState();
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("drone")))
      return;
    GameDataController.gd.setObjective("drone_taken", true);
    Item obj = ItemsManager.im.getItem("drone");
    List<string> _pages = new List<string>();
    if (obj.examineTexts != null)
    {
      for (int index = 0; index < obj.examineTexts.Count; ++index)
        _pages.Add(obj.examineTexts[index]);
    }
    ExamineSprite.es.textField.shift.x = (float) obj.textShiftX;
    ExamineSprite.es.textField.shift.y = (float) obj.textShiftY;
    ExamineSprite.es.readyText(_pages, obj.textWidth, obj.textColor1.r, obj.textColor1.g, obj.textColor1.b, obj.textColor2.r, obj.textColor2.g, obj.textColor2.b, obj.textColor2.a);
    ExamineSprite.es.show(obj.examineSprite, obj.examineSprite_1, obj.examineSprite_2, obj.examineSprite_3, obj.examineSprite_4);
    this.updateState();
  }

  public override void whatOnClick()
  {
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 1 || GameDataController.gd.getObjective("drone_taken"))
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(-1);
    }
    else
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.colliderManager.setCollider(0);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.actions, "bridge_drone_1")
    });
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.actions, "bridge_drone_2")
    });
  }
}
