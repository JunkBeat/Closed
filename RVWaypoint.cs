// Decompiled with JetBrains decompiler
// Type: RVWaypoint
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class RVWaypoint : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "crashsite_tracks";
    this.doubleClickCondition = "visited_rv";
    this.actionType = ObjectActionController.Type.NormalAction;
    this.trans_dir = WalkController.Direction.N;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjectiveDetail("map_rv_revealed") == TravelAgency.LOCATION_STATUS_UNDISCOVERED)
    {
      Vector3 color = GingerActionController.getColor();
      TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "crashsite_tracks", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
      GameDataController.gd.setObjectiveDetail("map_rv_revealed", TravelAgency.LOCATION_STATUS_REACHABLE);
      this.updateState();
    }
    else
    {
      PlayerController.pc.setBusy(true);
      PlayerController.pc.spawnName = "InfoExit";
      CurtainController.cc.fadeOut("LocationMap", WalkController.Direction.E);
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("map_rv_revealed") == TravelAgency.LOCATION_STATUS_UNDISCOVERED)
    {
      this.range = 40f;
      this.characterAnimationName = "action_stnd_";
      this.actionType = ObjectActionController.Type.NormalAction;
    }
    else
    {
      this.range = 10f;
      this.characterAnimationName = "stop";
      this.actionType = ObjectActionController.Type.Transition;
    }
    if (GameDataController.gd.getCurrentDay() > 1)
      this.setCollider(0);
    else
      this.setCollider(-1);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
