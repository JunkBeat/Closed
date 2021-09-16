// Decompiled with JetBrains decompiler
// Type: SiderealF2SPC2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class SiderealF2SPC2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_pc_off";
    this.actionType = ObjectActionController.Type.NormalAction;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("disc1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("disc2", string.Empty, anim: string.Empty));
  }

  private void takeBack(string a = "") => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.pyk);

  public override void clickAction()
  {
    if (GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_A") == 50 && GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_B") == 10)
    {
      if (this.usedItem == "disc1" || this.usedItem == "disc2")
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.disk);
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.hdd2);
        List<DialogueLine> dialogueLines = new List<DialogueLine>();
        DialogueController.dc.initDialogue(dialogueLines, "sidereal_disk_comp", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.GetComponent<TextFieldController>(), new Vector3(1f, 0.0f, 0.0f));
        this.GetComponent<TextFieldController>().setBGColor(0.5f, 0.0f, 0.0f, 0.5f);
        dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.takeBack);
        for (int index = 0; index < dialogueLines.Count; ++index)
          Timeline.t.addDialogue(dialogueLines[index]);
      }
      else
      {
        PlayerController.pc.spawnName = "SiderealPCExit";
        CurtainController.cc.fadeOut("SiderealPC1", WalkController.Direction.S);
      }
    }
    else
    {
      Timeline.t.addAction(new TimelineAction()
      {
        textfield = PlayerController.pc.textField,
        text = GameStrings.getString(GameStrings.actions, "sidereal_pc_off1"),
        actionWithText = false
      });
      Timeline.t.addAction(new TimelineAction()
      {
        textfield = PlayerController.pc.textField,
        text = GameStrings.getString(GameStrings.actions, "sidereal_pc_off2"),
        actionWithText = false
      });
      Timeline.t.addAction(new TimelineAction()
      {
        textfield = PlayerController.pc.textField,
        text = GameStrings.getString(GameStrings.actions, "sidereal_pc_off3"),
        actionWithText = false
      });
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_A") == 50 && GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_B") == 10)
    {
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 2f;
      this.objectName = "sidereal_pc_on";
    }
    else
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 50f;
      this.objectName = "sidereal_pc_off";
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
