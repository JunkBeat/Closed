// Decompiled with JetBrains decompiler
// Type: LocationOutpostShipCalibrator
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationOutpostShipCalibrator : ObjectActionController
{
  public Sprite missing;
  public Sprite present;
  public Sprite examine1;
  public Sprite examine2;
  private Sprite examine;
  private string say;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_in_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_ship_calib0";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("engine_calibrator", string.Empty, anim: string.Empty));
  }

  public override void clickAction()
  {
    if (this.usedItem != string.Empty)
    {
      if (GameDataController.gd.getObjective("outpost_calibrator_inserted") || GameDataController.gd.getObjectiveDetail("day_4_threat") != 1)
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "calibrator_already_in"));
      }
      else
      {
        InventoryController.ic.removeItem("engine_calibrator");
        GameDataController.gd.setObjective("outpost_calibrator_inserted", true);
        this.updateState();
      }
    }
    else
    {
      ExamineSprite.es.textField.shift.x = -80f;
      ExamineSprite.es.textField.shift.y = 10f;
      ExamineSprite.es.readyText(new List<string>()
      {
        this.say
      }, 90, 1f, 1f, 1f, 0.0f, 0.0f, 0.0f, 0.75f);
      ExamineSprite.es.closingAnimation = "kneel_out_n";
      ExamineSprite.es.show(this.examine);
    }
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjective("outpost_calibrator_inserted") || GameDataController.gd.getObjectiveDetail("day_4_threat") != 1)
    {
      this.GetComponent<SpriteRenderer>().sprite = this.present;
      this.say = GameStrings.getString(GameStrings.actions, "ship_examine_calib_1");
      this.examine = this.examine2;
      this.objectName = "outpost_ship_calib1";
    }
    else
    {
      this.GetComponent<SpriteRenderer>().sprite = this.missing;
      this.say = GameStrings.getString(GameStrings.actions, "ship_examine_calib_0");
      this.examine = this.examine1;
      this.objectName = "outpost_ship_calib0";
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
    if (this.usedItem != string.Empty)
    {
      this.characterAnimationName = "kneel_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else
    {
      this.characterAnimationName = "kneel_in_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
  }

  public override void whatOnClick()
  {
  }
}
