// Decompiled with JetBrains decompiler
// Type: LocationSiderealOutside3Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class LocationSiderealOutside3Start : MonoBehaviour
{
  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.01f;
    PlayerController.wc.shadow.fadeRateH = 1f / 1000f;
    PlayerController.wc.shadowOffsetY = 2;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 20f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.scaleFactor = 0.4f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 240f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.DIRT, AudioReverbPreset.Off);
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 1f);
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && !GameDataController.gd.getObjective("restaurant_sarge_encountered") && GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjective("sidereal_base_located"))
      GameDataController.gd.setObjective("restaurant_sarge_awaits", true);
    GameDataController.gd.setObjective("visited_sidereal_outside_3", true);
    if (!GameDataController.gd.getObjective("sidereal_roof_collapsed") || GameDataController.gd.getObjective("dialogue_ginger_reunited"))
      return;
    List<DialogueLine> dialogueLines1 = new List<DialogueLine>();
    List<DialogueLine> dialogueLines2 = new List<DialogueLine>();
    List<DialogueLine> dialogueLines3 = new List<DialogueLine>();
    if (GameDataController.gd.getObjective("cody_warned"))
    {
      DialogueController.dc.initDialogue(dialogueLines2, "cody_sidereal_reunion", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor());
      if (GameDataController.gd.getObjective("barry_warned"))
        dialogueLines2[1].text = GameStrings.getString(GameStrings.dialogues, "cody_sidereal_reunion_alt");
    }
    if (GameDataController.gd.getObjective("barry_warned"))
    {
      DialogueController.dc.initDialogue(dialogueLines3, "barry_sidereal_reunion", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor());
      if (GameDataController.gd.getObjective("cody_warned"))
        dialogueLines3[0].text = GameStrings.getString(GameStrings.dialogues, "barry_sidereal_reunion_alt");
    }
    string prefix = GameDataController.gd.getObjectiveDetail("npc2_alive") != 1 ? (GameDataController.gd.getObjectiveDetail("npc3_alive") != 1 ? "ginger_sidereal_reunion" : "ginger_sidereal_reunion_cody") : "ginger_sidereal_reunion_barry";
    DialogueController.dc.initDialogue(dialogueLines1, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    DialogueController.dc.initDialogue(dialogueLines1, "ginger_sidereal_reunion_map", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
      DialogueController.dc.initDialogue(dialogueLines1, "ginger_sidereal_reunion_bandits", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    else
      DialogueController.dc.initDialogue(dialogueLines1, "ginger_sidereal_reunion_storm", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    dialogueLines1[2].action = new TimelineFunction(this.uuuu);
    for (int index = 0; index < dialogueLines2.Count; ++index)
      Timeline.t.addDialogue(dialogueLines2[index]);
    for (int index = 0; index < dialogueLines3.Count; ++index)
      Timeline.t.addDialogue(dialogueLines3[index]);
    for (int index = 0; index < dialogueLines1.Count; ++index)
      Timeline.t.addDialogue(dialogueLines1[index]);
  }

  private void uuuu(string a = "")
  {
    GameDataController.gd.setObjective("dialogue_ginger_reunited", true);
    GameDataController.gd.setObjective("cody_warned", false);
    GameDataController.gd.setObjective("barry_warned", false);
  }

  private void Update()
  {
  }
}
