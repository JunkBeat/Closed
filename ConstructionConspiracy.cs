// Decompiled with JetBrains decompiler
// Type: ConstructionConspiracy
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class ConstructionConspiracy : ObjectActionController
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
    this.objectName = "construction_conspiracy";
    this.range = 1f;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("constructionsite_from_above"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cant_reach"));
    }
    else
    {
      ExamineSprite.es.textField.shift.x = -3f;
      ExamineSprite.es.textField.shift.y = 55f;
      ExamineSprite.es.readyText(new List<string>()
      {
        GameStrings.getString(GameStrings.world_labels, "conspiracy2_1"),
        GameStrings.getString(GameStrings.world_labels, "conspiracy2_2"),
        GameStrings.getString(GameStrings.world_labels, "conspiracy2_3"),
        GameStrings.getString(GameStrings.world_labels, "conspiracy2_4"),
        GameStrings.getString(GameStrings.world_labels, "conspiracy2_5"),
        GameStrings.getString(GameStrings.world_labels, "conspiracy2_6"),
        GameStrings.getString(GameStrings.world_labels, "conspiracy2_7"),
        GameStrings.getString(GameStrings.world_labels, "conspiracy2_8"),
        GameStrings.getString(GameStrings.world_labels, "conspiracy2_9"),
        GameStrings.getString(GameStrings.world_labels, "conspiracy2_10")
      }, 120, 0.2f, 0.2f, 0.2f, 1f, 1f, 1f, 1f);
      ExamineSprite.es.ac = SoundsManagerController.sm.page_turn_04;
      ExamineSprite.es.show(this.painting, act: new ExamineSprite.Delegate(this.talkWithCate), actionOnOpen: false);
    }
  }

  private void talkWithCate()
  {
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "cate_construction_conspiracy", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    Timeline.t.doNotUnlock = true;
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("constructionsite_from_above"))
    {
      this.range = 1f;
      this.characterAnimationName = "action_stnd_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else
    {
      this.range = 100f;
      this.characterAnimationName = "action_stnd_se";
      this.animationFlip = true;
      this.useCurrentDirection = false;
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
