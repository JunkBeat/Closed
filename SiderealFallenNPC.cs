// Decompiled with JetBrains decompiler
// Type: SiderealFallenNPC
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class SiderealFallenNPC : ObjectActionController
{
  public Sprite barry;
  public Sprite cody;
  public Sprite grave;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.characterAnimationName = "action_stnd_";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "npc_cody";
    this.range = 2f;
    this.updateState();
  }

  public void bury()
  {
    GameDataController.Achievement("S_GRAVE");
    GameDataController.gd.setObjective("sidereal_npc_buried", true);
    CurtainController.cc.fadeOut(actionAfterFade: new CurtainController.Delegate(this.cateTalk));
  }

  public void cateTalk()
  {
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    Vector3 color1 = GingerActionController.getColor();
    DialogueController.dc.initDialogue(dialogueLines, "cate_after_sidereal_burial1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), color1);
    if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive"))
    {
      Vector3 color2 = Npc2Controller.getColor();
      TextFieldController component = GameObject.Find("Npc2").GetComponent<TextFieldController>();
      DialogueController.dc.initDialogue(dialogueLines, "cate_after_sidereal_burial2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), color1, component, color2);
    }
    if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
    {
      Vector3 color3 = Npc3Controller.getColor();
      TextFieldController component = GameObject.Find("Npc3").GetComponent<TextFieldController>();
      DialogueController.dc.initDialogue(dialogueLines, "cate_after_sidereal_burial3", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), color1, component, color3);
    }
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("sidereal_npc_buried"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "npc_grave"));
    else if (GameDataController.gd.getObjective("dialogue_ginger_reunited"))
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "sidereal_burial"), yesClick: new Button.Delegate(this.bury), time: 30, timeSaver: 6);
    else if (!GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjectiveDetail("npc2_alive") == 1)
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "poor_barry"));
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "poor_cody"));
  }

  public override void whatOnClick()
  {
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("sidereal_npc_buried"))
    {
      this.setCollider(0);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.grave;
      this.objectName = "npc_grave";
    }
    else if (!GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjectiveDetail("npc2_alive") == 1)
    {
      this.setCollider(0);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.barry;
      this.objectName = "npc_barry";
    }
    else if (!GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjectiveDetail("npc3_alive") == 1)
    {
      this.setCollider(0);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.cody;
      this.objectName = "npc_cody";
    }
    else
    {
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
