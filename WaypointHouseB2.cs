// Decompiled with JetBrains decompiler
// Type: WaypointHouseB2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class WaypointHouseB2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "house_b_waypoint2";
    this.actionType = ObjectActionController.Type.Transition;
    this.doubleClickCondition = "visited_house_b_inside";
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("day2_complete") && !GameDataController.gd.getObjective("npc2_wife_note_given") && !GameDataController.gd.getObjective("dialogue_ginger_barry_distracted"))
    {
      int objectiveDetail = GameDataController.gd.getObjectiveDetail("dialogue_npc2_house_blocked");
      if (objectiveDetail < 4)
        ++objectiveDetail;
      Vector3 color1 = Npc2Controller.getColor();
      TextFieldController component1 = GameObject.Find("Npc2").GetComponent<TextFieldController>();
      Vector3 color2 = GingerActionController.getColor();
      TextFieldController component2 = GameObject.Find("Ginger").GetComponent<TextFieldController>();
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "npc2_block_house" + (object) objectiveDetail, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1, component2, color2);
      GameDataController.gd.setObjectiveDetail("dialogue_npc2_house_blocked", objectiveDetail);
      dialogueLines[0].action = new TimelineFunction(this.turnAround);
      dialogueLines[0].actionWithText = false;
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
    }
    else
    {
      PlayerController.pc.spawnName = "WaypointHouseBInside0";
      CurtainController.cc.fadeOut("LocationHouseBInside", WalkController.Direction.N);
    }
  }

  public void turnAround(string var = "") => PlayerController.wc.forceAnimation("action_stnd_se");

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (!GameDataController.gd.getObjective("day2_complete") && !GameDataController.gd.getObjective("npc2_wife_note_given") && !GameDataController.gd.getObjective("dialogue_ginger_barry_distracted"))
    {
      this.range = 20f;
      this.doubleClickCondition = string.Empty;
    }
    else
    {
      this.range = 1f;
      this.doubleClickCondition = "visited_house_b_inside";
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
