// Decompiled with JetBrains decompiler
// Type: HouseBInsideBook
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class HouseBInsideBook : ObjectActionController
{
  public Sprite painting;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "house_lucid_book";
    this.range = 1f;
  }

  public override void clickAction()
  {
    ExamineSprite.es.textField.shift.x = -3f;
    ExamineSprite.es.textField.shift.y = 50f;
    ExamineSprite.es.readyText(new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "book_lucid_1"),
      GameStrings.getString(GameStrings.world_labels, "book_lucid_2"),
      GameStrings.getString(GameStrings.world_labels, "book_lucid_3"),
      GameStrings.getString(GameStrings.world_labels, "book_lucid_4"),
      GameStrings.getString(GameStrings.world_labels, "book_lucid_5"),
      GameStrings.getString(GameStrings.world_labels, "book_lucid_6"),
      GameStrings.getString(GameStrings.world_labels, "book_lucid_7"),
      GameStrings.getString(GameStrings.world_labels, "book_lucid_8")
    }, 120, 0.2f, 0.2f, 0.2f, 1f, 1f, 1f, 1f);
    ExamineSprite.es.ac = SoundsManagerController.sm.page_turn_02;
    ExamineSprite.es.show(this.painting);
  }

  public override void updateState() => this.colliderManager.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0() => PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "house_lucid_book"));

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}
