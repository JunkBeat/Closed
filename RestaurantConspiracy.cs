// Decompiled with JetBrains decompiler
// Type: RestaurantConspiracy
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class RestaurantConspiracy : ObjectActionController
{
  public Sprite painting;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_e_in";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_conspiracy";
    this.range = 1f;
  }

  public override void clickAction()
  {
    ExamineSprite.es.textField.shift.x = -3f;
    ExamineSprite.es.textField.shift.y = 50f;
    ExamineSprite.es.readyText(new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "conspiracy1_1"),
      GameStrings.getString(GameStrings.world_labels, "conspiracy1_2"),
      GameStrings.getString(GameStrings.world_labels, "conspiracy1_3"),
      GameStrings.getString(GameStrings.world_labels, "conspiracy1_4"),
      GameStrings.getString(GameStrings.world_labels, "conspiracy1_5"),
      GameStrings.getString(GameStrings.world_labels, "conspiracy1_6"),
      GameStrings.getString(GameStrings.world_labels, "conspiracy1_7"),
      GameStrings.getString(GameStrings.world_labels, "conspiracy1_8"),
      GameStrings.getString(GameStrings.world_labels, "conspiracy1_9"),
      GameStrings.getString(GameStrings.world_labels, "conspiracy1_10")
    }, 120, 0.2f, 0.2f, 0.2f, 1f, 1f, 1f, 1f);
    ExamineSprite.es.closingAnimation = "kneel_e_out";
    ExamineSprite.es.closingAnimationFlip = true;
    ExamineSprite.es.ac = SoundsManagerController.sm.page_turn_03;
    ExamineSprite.es.show(this.painting, actionOnOpen: false);
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("restaurant_chem_walked"))
    {
      this.setCollider(-1);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    else
    {
      this.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
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
  }

  public override void whatOnClick()
  {
  }
}
