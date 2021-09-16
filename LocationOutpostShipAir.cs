// Decompiled with JetBrains decompiler
// Type: LocationOutpostShipAir
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationOutpostShipAir : ObjectActionController
{
  public Sprite examine1;
  public Sprite examine2;
  private Sprite examine;
  private string say;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_e_in";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_ship_air0";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("air_tanks", string.Empty, anim: string.Empty));
  }

  public override void clickAction()
  {
    if (this.usedItem != string.Empty)
    {
      if (GameDataController.gd.getObjective("outpost_air_tanks_inserted") || GameDataController.gd.getObjectiveDetail("day_4_threat") != 0)
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "air_already_in"));
      }
      else
      {
        InventoryController.ic.removeItem("air_tanks");
        GameDataController.gd.setObjective("outpost_air_tanks_inserted", true);
        this.updateState();
      }
    }
    else
    {
      ExamineSprite.es.textField.shift.x = 20f;
      ExamineSprite.es.textField.shift.y = 10f;
      ExamineSprite.es.readyText(new List<string>()
      {
        this.say
      }, 90, 1f, 1f, 1f, 0.0f, 0.0f, 0.0f, 0.75f);
      ExamineSprite.es.closingAnimation = "kneel_e_out";
      ExamineSprite.es.show(this.examine);
    }
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjective("outpost_air_tanks_inserted") || GameDataController.gd.getObjectiveDetail("day_4_threat") != 0)
    {
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.say = GameStrings.getString(GameStrings.actions, "ship_examine_air_1");
      this.examine = this.examine2;
      this.objectName = "outpost_ship_air1";
    }
    else
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.say = GameStrings.getString(GameStrings.actions, "ship_examine_air_0");
      this.examine = this.examine1;
      this.objectName = "outpost_ship_air0";
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
      this.characterAnimationName = "kneel_e";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else
    {
      this.characterAnimationName = "kneel_e_in";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
  }

  public override void whatOnClick()
  {
  }
}
