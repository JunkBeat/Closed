// Decompiled with JetBrains decompiler
// Type: Outpost7_RadarScreen
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Outpost7_RadarScreen : ObjectActionController
{
  public SpriteRenderer radar_background;
  public SpriteRenderer radar_dot;
  public SpriteRenderer radar_swipe1;
  public SpriteRenderer radar_swipe2;
  public AudioSource aS;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_radar_screen";
    this.actionType = ObjectActionController.Type.NormalAction;
    this.trans_dir = WalkController.Direction.N;
    this.range = 1f;
    this.endView(string.Empty);
  }

  public void turn(string s = "") => GameObject.Find("Ginger").GetComponent<NPCWalkController>().forceDirection(NPCWalkController.Direction.E);

  public void talkAboutRadarOnPlaneOn()
  {
    string prefix = "radar_repaired2";
    if (GameDataController.gd.getObjectiveDetail("map_airplane_revealed") == TravelAgency.LOCATION_STATUS_UNDISCOVERED)
    {
      prefix = "radar_repaired";
      GameDataController.gd.setObjectiveDetail("map_airplane_revealed", TravelAgency.LOCATION_STATUS_REACHABLE);
      GameObject.Find("Ginger").GetComponent<NPCWalkController>().forceDirection(NPCWalkController.Direction.E);
    }
    Vector3 color = GingerActionController.getColor();
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
    dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.endView);
    for (int index = 0; index < dialogueLines.Count; ++index)
    {
      if (index < dialogueLines.Count - 1)
        dialogueLines[index].action = new TimelineFunction(this.turn);
      Timeline.t.addDialogue(dialogueLines[index]);
    }
  }

  public void talkAboutRadarOnPlaneOff()
  {
    Vector3 color = GingerActionController.getColor();
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "radar_disabled", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
    dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.endView);
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  public void talkAboutRadarOff()
  {
    Vector3 color = GingerActionController.getColor();
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    GameObject.Find("Ginger").GetComponent<NPCWalkController>().forceDirection(NPCWalkController.Direction.E);
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "radar_broken", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color, PlayerController.pc.textField, new Vector3(1f, 0.5f, 0.5f));
    dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.endView);
    for (int index = 0; index < dialogueLines.Count; ++index)
    {
      if (index < dialogueLines.Count - 1)
        dialogueLines[index].action = new TimelineFunction(this.turn);
      Timeline.t.addDialogue(dialogueLines[index]);
    }
  }

  public override void clickAction()
  {
    this.radar_background.enabled = true;
    this.radar_dot.enabled = false;
    this.radar_swipe1.enabled = false;
    this.radar_swipe2.enabled = false;
    GameObject.Find("BottomText").GetComponent<TextFieldController>().dissmiss(true);
    if (!GameDataController.gd.getObjective("plane_transponder_disabled") && GameDataController.gd.getObjective("outpost_radar_repaired"))
    {
      this.radar_swipe1.enabled = true;
      this.radar_swipe2.enabled = true;
      this.radar_dot.enabled = true;
      this.aS.volume = 1f;
      this.talkAboutRadarOnPlaneOn();
    }
    else if (GameDataController.gd.getObjective("plane_transponder_disabled") && GameDataController.gd.getObjective("outpost_radar_repaired"))
    {
      this.radar_swipe1.enabled = true;
      this.radar_swipe2.enabled = true;
      this.radar_dot.enabled = false;
      this.talkAboutRadarOnPlaneOff();
    }
    else
      this.talkAboutRadarOff();
  }

  public void endView(string var = "")
  {
    this.radar_background.enabled = false;
    this.radar_dot.enabled = false;
    this.radar_swipe1.enabled = false;
    this.radar_swipe2.enabled = false;
    this.updateState();
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("plane_transponder_disabled") && GameDataController.gd.getObjective("outpost_radar_repaired"))
    {
      this.GetComponent<Animator>().Play("small_radar");
      this.aS.volume = 0.75f;
    }
    else if (GameDataController.gd.getObjective("plane_transponder_disabled") && GameDataController.gd.getObjective("outpost_radar_repaired"))
    {
      this.GetComponent<Animator>().Play("small_radar");
      this.aS.volume = 0.0f;
    }
    else
    {
      this.GetComponent<Animator>().Play("small_radar_broken");
      this.aS.volume = 0.0f;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
