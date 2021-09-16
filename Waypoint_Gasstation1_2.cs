// Decompiled with JetBrains decompiler
// Type: Waypoint_Gasstation1_2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Waypoint_Gasstation1_2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_back";
    this.doubleClickCondition = "visited_gasstation2";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && !GameDataController.gd.getObjective("thugs_gasstation_talk") && GameDataController.gd.getObjective("sidereal_base_located"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "gasstation_thugs_are_there"));
    else if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && !GameDataController.gd.getObjective("gasstation_sarge_intro") && !GameDataController.gd.getObjective("gasstation_sarge_shot") && GameDataController.gd.getObjective("sidereal_base_located"))
    {
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      Vector3 color = GingerActionController.getColor();
      TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
      DialogueController.dc.initDialogue(dialogueLines, "gasstation_meet_thug", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
      if (GameDataController.gd.getObjective("npc2_alive") || GameDataController.gd.getObjective("npc3_alive"))
        dialogueLines[0].text = GameStrings.getString(GameStrings.dialogues, "gasstation_meet_thug2_1_a");
      dialogueLines[2].action = new TimelineFunction(this.goThere);
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
    }
    else
    {
      GameDataController.gd.setObjective("gasstation_thugs_safe", true);
      GameDataController.gd.setObjective("gasstation_spy_mode", false);
      PlayerController.pc.spawnName = "Waypoint_Gasstation2_1";
      CurtainController.cc.fadeOut("LocationGasstation2", WalkController.Direction.E);
    }
  }

  public override void whatOnClick0()
  {
    this.doubleClickCondition = "visited_gasstation2";
    if (GameDataController.gd.getCurrentDay() != 3 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 0 || GameDataController.gd.getObjective("gasstation_sarge_intro") || GameDataController.gd.getObjective("gasstation_sarge_shot"))
      return;
    this.doubleClickCondition = string.Empty;
  }

  public void goThere(string a = "")
  {
    GameDataController.gd.setObjective("gasstation_thugs_safe", false);
    GameDataController.gd.setObjective("gasstation_spy_mode", false);
    PlayerController.pc.spawnName = "Waypoint_Gasstation2_1";
    CurtainController.cc.fadeOut("LocationGasstation2", WalkController.Direction.E, "walk_e");
  }

  public override void updateState()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjective("gasstation_spider_baited") && !GameDataController.gd.getObjective("gasstation_spider_shot") && ItemsManager.im.getItem("rifle_6").dataRef.droppedLocation.ToLower().IndexOf("inventory") != -1)
      this.colliderManager.setCollider(-1);
    else
      this.colliderManager.setCollider(0);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
