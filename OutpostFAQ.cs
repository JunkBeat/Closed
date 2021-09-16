// Decompiled with JetBrains decompiler
// Type: OutpostFAQ
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class OutpostFAQ : ObjectActionController
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
    this.objectName = "outpost_faq";
    this.range = 1f;
  }

  public override void clickAction()
  {
    ExamineSprite.es.textField.shift.x = -110f;
    ExamineSprite.es.textField.shift.y = 55f;
    ExamineSprite.es.readyText(new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "outpost_faq_1"),
      GameStrings.getString(GameStrings.world_labels, "outpost_faq_2"),
      GameStrings.getString(GameStrings.world_labels, "outpost_faq_3"),
      GameStrings.getString(GameStrings.world_labels, "outpost_faq_4"),
      GameStrings.getString(GameStrings.world_labels, "outpost_faq_5"),
      GameStrings.getString(GameStrings.world_labels, "outpost_faq_6"),
      GameStrings.getString(GameStrings.world_labels, "outpost_faq_7"),
      GameStrings.getString(GameStrings.world_labels, "outpost_faq_8"),
      GameStrings.getString(GameStrings.world_labels, "outpost_faq_9"),
      GameStrings.getString(GameStrings.world_labels, "outpost_faq_10")
    }, 190, 0.2f, 0.2f, 0.2f, 1f, 1f, 1f, 1f);
    ExamineSprite.es.ac = SoundsManagerController.sm.page_turn_01;
    ExamineSprite.es.show((Sprite) null, actionOnOpen: false);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("outpost_switch_pressed"))
      this.setCollider(0);
    else
      this.setCollider(-1);
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
