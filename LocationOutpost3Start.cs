// Decompiled with JetBrains decompiler
// Type: LocationOutpost3Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class LocationOutpost3Start : MonoBehaviour
{
  public void setEntered(string s = "") => GameDataController.gd.setObjective("outpost_doormat_they_enter", true);

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 3f / 1000f;
    PlayerController.wc.shadowOffsetY = -2;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = -20f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.source = 10f;
    PlayerController.ssg.setStepType(StepSoundGenerator.ROAD);
    PlayerController.wc.shadow.scaleFactor = 0.25f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    if (PlayerController.pc.spawnName != "Waypoint_Outpost3_4" && PlayerController.pc.spawnName != "previous")
      GameObject.Find("Waypoint_Outpost3_4").GetComponent<Waypoint_Outpost3_4>().closeDoorQuickAndFast();
    if (GameDataController.gd.getObjective("outpost_elevator_open"))
      GameObject.Find("Waypoint_Outpost3_4").GetComponent<Waypoint_Outpost3_4>().closeDoorInFive();
    if (!GameDataController.gd.getObjective("outpost_doormat_just_disabled") && !GameDataController.gd.getObjective("outpost_door_powered"))
    {
      GameDataController.gd.setObjective("outpost_doormat_just_disabled", true);
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "outpost_elevator_fuse_done_first", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
      dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.setEntered);
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
      if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
      {
        DialogueLine dl = new DialogueLine(GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor(), GameStrings.getString(GameStrings.dialogues, "outpost_elevator_fuse_done_first_2_Cody"), (TimelineFunction) null);
        Timeline.t.addDialogue(dl);
      }
      if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive"))
      {
        DialogueLine dl = new DialogueLine(GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor(), GameStrings.getString(GameStrings.dialogues, "outpost_elevator_fuse_done_first_3_Barry"), (TimelineFunction) null);
        Timeline.t.addDialogue(dl);
      }
    }
    GameDataController.gd.setObjective("visited_outpost3", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_6a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_metal_inside, 0.6f);
    if (GameDataController.gd.getObjective("outpost_elevator_open"))
    {
      GameObject.Find("Location").GetComponent<PolygonCollider2D>().enabled = true;
      GameObject.Find("ClosedElevator").GetComponent<PolygonCollider2D>().enabled = false;
      GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
    }
    else
    {
      GameObject.Find("Location").GetComponent<PolygonCollider2D>().enabled = false;
      GameObject.Find("ClosedElevator").GetComponent<PolygonCollider2D>().enabled = true;
      GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
    }
  }

  private void Update()
  {
    if ((double) PlayerController.wc.currentXY.x > 165.0 && (double) PlayerController.wc.currentXY.y > 50.0)
      PlayerController.pc.allowDrop = false;
    else
      PlayerController.pc.allowDrop = true;
  }
}
