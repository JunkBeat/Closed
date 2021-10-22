// Decompiled with JetBrains decompiler
// Type: LocationAirplane3Pilot
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationAirplane3Pilot : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n_busy2";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "airplane_pilot";
    this.range = 1f;
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("plane_pilot_searched"))
    {
      if (GameDataController.gd.getObjective("npc3_alive"))
      {
        Vector3 color1 = GingerActionController.getColor();
        TextFieldController component1 = GameObject.Find("Ginger").GetComponent<TextFieldController>();
        Vector3 color2 = Npc3Controller.getColor();
        TextFieldController component2 = GameObject.Find("Npc3").GetComponent<TextFieldController>();
        List<DialogueLine> dialogueLines = new List<DialogueLine>();
        if (GameDataController.gd.getObjectiveDetail("plane_pilot_searched") == 0)
        {
          DialogueController.dc.initDialogue(dialogueLines, "airplane_cody_a", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1, component2, color2);
          for (int index = 0; index < dialogueLines.Count - 1; ++index)
            Timeline.t.addDialogue(dialogueLines[index]);
          Timeline.t.addDialogue(dialogueLines[dialogueLines.Count - 1]);
          GameDataController.gd.setObjectiveDetail("plane_pilot_searched", 1);
        }
        else if (GameDataController.gd.getObjectiveDetail("plane_pilot_searched") == 1)
        {
          DialogueController.dc.initDialogue(dialogueLines, "airplane_cody_b", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1, component2, color2);
          for (int index = 0; index < dialogueLines.Count - 1; ++index)
            Timeline.t.addDialogue(dialogueLines[index]);
          Timeline.t.addDialogue(dialogueLines[dialogueLines.Count - 1]);
          GameDataController.gd.setObjectiveDetail("plane_pilot_searched", 2);
        }
        else if (GameDataController.gd.getObjectiveDetail("plane_pilot_searched") == 2)
        {
          DialogueController.dc.initDialogue(dialogueLines, "airplane_cody_c", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1, component2, color2);
          dialogueLines[1].action = new TimelineFunction(this.rotate);
          dialogueLines[1].actionWithText = true;
          for (int index = 0; index < dialogueLines.Count - 1; ++index)
            Timeline.t.addDialogue(dialogueLines[index]);
          Timeline.t.addDialogue(dialogueLines[dialogueLines.Count - 1]);
          GameDataController.gd.setObjectiveDetail("plane_pilot_searched", 3);
        }
        else
          QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "search_body_plane"), yesClick: new Button.Delegate(this.pickItUp1), customNoLabel: GameStrings.getString(GameStrings.warnings, "search_body_plane_no"));
      }
      else
        this.pickItUp();
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "airplane_pilot_dead"));
    this.updateState();
  }

  public void rotate(string a = "") => PlayerController.wc.forceAnimation("stand_se", true);

  public void pickItUp()
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("manifest")))
      return;
    GameDataController.gd.setObjective("plane_pilot_searched", true);
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "airplane_manifest_picked"));
  }

  public void pickItUp1()
  {
    PlayerController.wc.forceAnimation("action_n");
    this.pickItUp();
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("plane_pilot_searched"))
    {
      this.characterAnimationName = "action_n_busy2";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.range = 1f;
    }
    if (!GameDataController.gd.getObjective("plane_pilot_searched"))
    {
      if (GameDataController.gd.getObjective("npc3_alive"))
      {
        if (GameDataController.gd.getObjectiveDetail("plane_pilot_searched") == 0)
        {
          this.characterAnimationName = "action_stnd_";
          this.animationFlip = false;
          this.useCurrentDirection = true;
          this.range = 15f;
        }
        else if (GameDataController.gd.getObjectiveDetail("plane_pilot_searched") == 1)
        {
          this.characterAnimationName = "action_stnd_";
          this.animationFlip = false;
          this.useCurrentDirection = true;
          this.range = 5f;
        }
        else if (GameDataController.gd.getObjectiveDetail("plane_pilot_searched") == 2)
        {
          this.characterAnimationName = "action_n_busy2";
          this.animationFlip = false;
          this.useCurrentDirection = false;
          this.range = 1f;
        }
        else
        {
          this.characterAnimationName = "action_stnd_n";
          this.animationFlip = false;
          this.useCurrentDirection = false;
          this.range = 1f;
        }
      }
      else
      {
        this.characterAnimationName = "action_n";
        this.animationFlip = false;
        this.useCurrentDirection = false;
        this.range = 1f;
      }
    }
    else
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 100f;
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
