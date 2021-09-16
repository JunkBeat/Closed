// Decompiled with JetBrains decompiler
// Type: HuntersLodgeOutsideTrap
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class HuntersLodgeOutsideTrap : ObjectActionController
{
  public SpriteRenderer corpse;
  public ParticleGenerator pg;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.characterAnimationName = "kneel_n";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_papers";
    this.range = 2f;
    this.updateState();
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("hunters_lodge_trap_cleared"))
    {
      Vector3 color = GingerActionController.getColor();
      TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "lodge_back_corpse", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
      for (int index = 0; index < dialogueLines.Count - 1; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
      if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive"))
      {
        DialogueLine dl = new DialogueLine(GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor(), GameStrings.getString(GameStrings.dialogues, "lodge_back_corpse_barry_1_C"), (TimelineFunction) null);
        Timeline.t.addDialogue(dl);
      }
      if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
      {
        DialogueLine dl = new DialogueLine(GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor(), GameStrings.getString(GameStrings.dialogues, "lodge_back_corpse_cody_1_C"), (TimelineFunction) null);
        Timeline.t.addDialogue(dl);
      }
      MonoBehaviour.print((object) (dialogueLines.ToString() + " " + (object) dialogueLines.Count));
      dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.clearIt);
      Timeline.t.addDialogue(dialogueLines[dialogueLines.Count - 1]);
    }
    else
      this.pickItUp(string.Empty);
  }

  private void clearIt(string param) => QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "lodge_back_corpse_clear"), yesClick: new Button.Delegate(this.yesClearIt), time: 30, timeSaver: 5, noClick: new Button.Delegate(this.noCliear));

  private void yesClearIt()
  {
    PlayerController.pc.setBusy(true);
    GameDataController.gd.setObjective("hunters_lodge_trap_cleared", true);
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.N, animation: "stop", flipX: true, actionAfterFade: new CurtainController.Delegate(this.doneClearing));
  }

  private void noCliear() => this.standup(string.Empty);

  private void doneClearing()
  {
    Timeline.t.addDialogue(new DialogueLine(PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameStrings.getString(GameStrings.actions, "lodge_back_corspe_cleared"), new TimelineFunction(this.standup))
    {
      actionWithText = false
    });
    Timeline.t.doNotUnlock = true;
  }

  private void standup(string param = "")
  {
    PlayerController.pc.setBusy(true);
    PlayerController.wc.forceAnimation("kneel_out_n");
  }

  private void pickItUp(string param)
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("bear_trap_3")))
      return;
    GameDataController.gd.setObjective("hunters_lodge_trap_picked", true);
    this.updateAll();
  }

  public override void whatOnClick()
  {
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") != 0)
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.corpse.enabled = false;
      this.colliderManager.setCollider(-1);
      this.characterAnimationName = "kneel_n";
      this.pg.started = false;
    }
    else if (!GameDataController.gd.getObjective("hunters_lodge_trap_cleared"))
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.corpse.enabled = true;
      this.colliderManager.setCollider(1);
      this.characterAnimationName = "kneel_in_n";
      this.objectName = "lodge_back_corpse";
      this.pg.started = true;
    }
    else if (!GameDataController.gd.getObjective("hunters_lodge_trap_picked"))
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.corpse.enabled = false;
      this.colliderManager.setCollider(0);
      this.characterAnimationName = "kneel_n";
      this.objectName = "lodge_back_trap";
      this.pg.started = false;
    }
    else
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.corpse.enabled = false;
      this.colliderManager.setCollider(-1);
      this.characterAnimationName = "kneel_n";
      this.pg.started = false;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
