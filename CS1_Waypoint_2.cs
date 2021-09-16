// Decompiled with JetBrains decompiler
// Type: CS1_Waypoint_2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class CS1_Waypoint_2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "machine_park";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.range = 20f;
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("cs_park_nogo") && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getCurrentDay() == 3)
    {
      DialogueLine dl1 = new DialogueLine(PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameStrings.getString(GameStrings.dialogues, "cs_park_start"), (TimelineFunction) null);
      Timeline.t.addDialogue(dl1);
      GameDataController.gd.setObjective("cs_park_nogo", true);
      if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive") || GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive"))
      {
        DialogueLine dl2 = new DialogueLine(PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameStrings.getString(GameStrings.dialogues, "cs_park_multi"), (TimelineFunction) null);
        Timeline.t.addDialogue(dl2);
      }
      else
      {
        DialogueLine dl3 = new DialogueLine(PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameStrings.getString(GameStrings.dialogues, "cs_park_single"), (TimelineFunction) null);
        Timeline.t.addDialogue(dl3);
      }
      Vector3 color1 = GingerActionController.getColor();
      TextFieldController component1 = GameObject.Find("Ginger").GetComponent<TextFieldController>();
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "cs_park_nogo", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1);
      if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive"))
      {
        Vector3 color2 = GingerActionController.getColor();
        Vector3 color3 = Npc2Controller.getColor();
        TextFieldController component2 = GameObject.Find("Ginger").GetComponent<TextFieldController>();
        TextFieldController component3 = GameObject.Find("Npc2").GetComponent<TextFieldController>();
        DialogueController.dc.initDialogue(dialogueLines, "cs_park_nogo_plus_barry", component3, color3, component2, color2);
      }
      if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
      {
        Vector3 color4 = Npc3Controller.getColor();
        TextFieldController component4 = GameObject.Find("Npc3").GetComponent<TextFieldController>();
        DialogueController.dc.initDialogue(dialogueLines, "cs_park_nogo_plus_cody", component4, color4, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
      }
      for (int index = 0; index < dialogueLines.Count - 1; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
      dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.goThere);
      Timeline.t.addDialogue(dialogueLines[dialogueLines.Count - 1]);
    }
    else
      this.goThere(string.Empty);
  }

  public void goThere(string s = "")
  {
    GameDataController.gd.setObjective("cs_arrive_from_inside", false);
    if (!GameDataController.gd.getObjective("cs_safe"))
      GameDataController.gd.setObjective("cs_crow_away", false);
    else
      GameDataController.gd.setObjective("cs_crow_away", true);
    PlayerController.pc.spawnName = "CS2_Waypoint_1";
    CurtainController.cc.fadeOut("CS2", WalkController.Direction.E);
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("cs_park_nogo") && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getCurrentDay() == 3)
      this.doubleClickCondition = "impossible";
    else
      this.doubleClickCondition = "visited_cs_2";
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
