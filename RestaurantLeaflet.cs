// Decompiled with JetBrains decompiler
// Type: RestaurantLeaflet
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class RestaurantLeaflet : ObjectActionController
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
    this.objectName = "restaurant_leaflet";
    this.range = 1f;
  }

  public override void clickAction()
  {
    ExamineSprite.es.textField.shift.x = -3f;
    ExamineSprite.es.textField.shift.y = 50f;
    ExamineSprite.es.readyText(new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "leaflet_1"),
      GameStrings.getString(GameStrings.world_labels, "leaflet_2"),
      GameStrings.getString(GameStrings.world_labels, "leaflet_3"),
      GameStrings.getString(GameStrings.world_labels, "leaflet_4"),
      GameStrings.getString(GameStrings.world_labels, "leaflet_5"),
      GameStrings.getString(GameStrings.world_labels, "leaflet_6"),
      GameStrings.getString(GameStrings.world_labels, "leaflet_7"),
      GameStrings.getString(GameStrings.world_labels, "leaflet_8"),
      GameStrings.getString(GameStrings.world_labels, "leaflet_9"),
      GameStrings.getString(GameStrings.world_labels, "leaflet_10")
    }, 120, 0.2f, 0.2f, 0.2f, 0.8235294f, 0.8784314f, 0.9803922f, 1f);
    ExamineSprite.es.closingAnimation = GameDataController.gd.getCurrentDay() == 2 ? "kneel_e_wait" : "kneel_e_out";
    ExamineSprite.es.closingAnimationFlip = true;
    ExamineSprite.es.ac = SoundsManagerController.sm.page_turn_02;
    ExamineSprite.es.show(this.painting, act: new ExamineSprite.Delegate(this.talkWithCate), actionOnOpen: false);
  }

  private void talkWithCate()
  {
    if (GameDataController.gd.getCurrentDay() != 2)
      return;
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "cate_restaurant_leaflet", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.getup);
    dialogueLines[dialogueLines.Count - 1].actionWithText = false;
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    Timeline.t.doNotUnlock = true;
  }

  private void getup(string p = "")
  {
    Timeline.t.doNotUnlock = true;
    PlayerController.wc.forceAnimation("kneel_e_out", true);
  }

  public override void updateState() => this.colliderManager.setCollider(0);

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
