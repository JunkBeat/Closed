// Decompiled with JetBrains decompiler
// Type: HuntersLodgeSolar
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class HuntersLodgeSolar : ObjectActionController
{
  public SpriteRenderer leaves;
  public SpriteRenderer blik;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "lodge_solar1";
    this.range = 20f;
    this.actionType = ObjectActionController.Type.NormalAction;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("broom", string.Empty, anim: string.Empty));
    this.updateState();
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("lodge_roof_cleaned"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "lodge_roof_clean"));
    else if (this.usedItem == string.Empty)
    {
      TextFieldController component1 = GameObject.Find("Ginger").GetComponent<TextFieldController>();
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "lodge_roof", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, GingerActionController.getColor());
      if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
      {
        Vector3 color = Npc3Controller.getColor();
        TextFieldController component2 = GameObject.Find("Npc3").GetComponent<TextFieldController>();
        DialogueController.dc.initDialogue(dialogueLines, "lodge_roof_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color, component2, color);
      }
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
    }
    else
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "lodge_swipe_roof"), yesClick: new Button.Delegate(this.swiper), time: 70, timeSaver: 10);
  }

  private void swiper()
  {
    GameDataController.gd.setObjective("lodge_roof_cleaned", true);
    CurtainController.cc.fadeOut();
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") != 1)
    {
      this.colliderManager.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.blik.enabled = false;
      this.leaves.enabled = false;
    }
    else
    {
      this.colliderManager.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.blik.enabled = true;
      if (GameDataController.gd.getObjective("lodge_roof_cleaned"))
      {
        this.leaves.enabled = false;
        this.objectName = "lodge_solar2";
      }
      else
      {
        this.objectName = "lodge_solar1";
        this.leaves.enabled = true;
      }
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
