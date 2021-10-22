// Decompiled with JetBrains decompiler
// Type: LocationOutpost1_Silo1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationOutpost1_Silo1 : ObjectActionController
{
  public SpriteRenderer ground;
  public SpriteRenderer plane;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_silo_far";
    this.range = 100f;
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("visited_outpost4"))
    {
      Vector3 color1 = GingerActionController.getColor();
      TextFieldController component1 = GameObject.Find("Ginger").GetComponent<TextFieldController>();
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "outpost_silo_far1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1);
      if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
      {
        Vector3 color2 = Npc3Controller.getColor();
        TextFieldController component2 = GameObject.Find("Npc3").GetComponent<TextFieldController>();
        dialogueLines.Add(new DialogueLine(component2, color2, GameStrings.getString(GameStrings.dialogues, "outpost_silo_far1_cody"), (TimelineFunction) null));
      }
      if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive"))
      {
        Vector3 color3 = Npc2Controller.getColor();
        TextFieldController component3 = GameObject.Find("Npc2").GetComponent<TextFieldController>();
        dialogueLines.Add(new DialogueLine(component3, color3, GameStrings.getString(GameStrings.dialogues, "outpost_silo_far1_barry"), (TimelineFunction) null));
      }
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
    }
    else
    {
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "outpost_silo_far3", PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
    }
  }

  public override void updateState()
  {
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
