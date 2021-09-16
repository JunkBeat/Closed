// Decompiled with JetBrains decompiler
// Type: LocationSiderealF2CStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class LocationSiderealF2CStart : MonoBehaviour
{
  public SpriteRenderer overLight;
  public SpriteRenderer light1;
  public SpriteRenderer doorlight;
  public SpriteRenderer darkness;
  public NPCWalkController cody;

  private void Start()
  {
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.NORMAL, AudioReverbPreset.StoneCorridor);
    GameDataController.gd.setObjective("visited_sidereal_f2c", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_mystery);
    if (GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_A") == 50 && GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_B") == 10)
    {
      this.darkness.enabled = false;
      this.overLight.enabled = true;
      this.light1.enabled = true;
      this.doorlight.enabled = true;
      PlayerController.wc.shadow.fadeRateV = 1f / 1000f;
      PlayerController.wc.shadow.fadeRateH = 0.005f;
      PlayerController.wc.shadowOffsetY = 2;
      PlayerController.wc.shadow.skewFactor = 40f;
      PlayerController.wc.shadow.skewFactor2 = 0.0f;
      PlayerController.wc.shadow.startAlpha = 0.75f;
      PlayerController.wc.shadow.scaleFactor = 0.5f;
      PlayerController.wc.shadow.downwards = true;
      PlayerController.wc.shadow.source = 10f;
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.buzz, 0.5f);
    }
    else
    {
      this.darkness.enabled = true;
      this.light1.enabled = false;
      this.overLight.enabled = false;
      this.doorlight.enabled = false;
      PlayerController.wc.shadow.fadeRateV = 0.01f;
      PlayerController.wc.shadow.fadeRateH = 0.005f;
      PlayerController.wc.shadowOffsetY = 2;
      PlayerController.wc.shadow.skewFactor = 40f;
      PlayerController.wc.shadow.skewFactor2 = 0.0f;
      PlayerController.wc.shadow.startAlpha = 0.5f;
      PlayerController.wc.shadow.scaleFactor = 0.5f;
      PlayerController.wc.shadow.downwards = true;
      PlayerController.wc.shadow.source = 130f;
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.underground_1, 1f);
    }
    PlayerController.pc.copySettingsToNPCs();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive") && !GameDataController.gd.getObjective("place_sidereal_auto_cody"))
    {
      GameDataController.gd.setObjective("place_sidereal_auto_cody", true);
      GameDataController.gd.setObjective("place_sidereal_auto_barry", true);
      Vector3 color1 = GingerActionController.getColor();
      Vector3 color2 = Npc3Controller.getColor();
      PlayerController.pc.forceAnimation("stand_s");
      TextFieldController component = GameObject.Find("Npc3").GetComponent<TextFieldController>();
      DialogueController.dc.initDialogue(dialogueLines, "place_sidereal_auto_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), color1, component, color2);
      dialogueLines[4].action = new TimelineFunction(this.codyRun);
      dialogueLines[0].action = new TimelineFunction(this.turn_south);
      dialogueLines[0].actionWithText = true;
    }
    if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive") && !GameDataController.gd.getObjective("place_sidereal_auto_barry"))
    {
      GameDataController.gd.setObjective("place_sidereal_auto_barry", true);
      GameDataController.gd.setObjective("place_sidereal_auto_cody", true);
      Vector3 color3 = GingerActionController.getColor();
      Vector3 color4 = Npc2Controller.getColor();
      PlayerController.pc.forceAnimation("stand_s");
      TextFieldController component = GameObject.Find("Npc2").GetComponent<TextFieldController>();
      DialogueController.dc.initDialogue(dialogueLines, "place_sidereal_auto_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), color3, component, color4);
      dialogueLines[0].action = new TimelineFunction(this.turn_south);
      dialogueLines[0].actionWithText = true;
    }
    if (GameDataController.gd.getObjective("npc2_joined") && !GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjectiveDetail("npc2_alive") == 1 && GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive") && !GameDataController.gd.getObjective("place_sidereal_auto2_cody") && GameDataController.gd.getObjective("sidereal_base_located"))
    {
      GameDataController.gd.setObjective("place_sidereal_auto2_cody", true);
      GameDataController.gd.setObjective("place_sidereal_auto2_barry", true);
      Vector3 color5 = GingerActionController.getColor();
      Vector3 color6 = Npc3Controller.getColor();
      PlayerController.pc.forceAnimation("stand_se");
      TextFieldController component = GameObject.Find("Npc3").GetComponent<TextFieldController>();
      DialogueController.dc.initDialogue(dialogueLines, "place_sidereal_auto2_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), color5, component, color6);
      dialogueLines[0].action = new TimelineFunction(this.turn_south_east);
      dialogueLines[0].actionWithText = true;
    }
    if (GameDataController.gd.getObjective("npc3_joined") && !GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjectiveDetail("npc3_alive") == 1 && GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive") && !GameDataController.gd.getObjective("place_sidereal_auto2_barry") && GameDataController.gd.getObjective("sidereal_base_located"))
    {
      GameDataController.gd.setObjective("place_sidereal_auto2_barry", true);
      GameDataController.gd.setObjective("place_sidereal_auto2_cody", true);
      Vector3 color7 = GingerActionController.getColor();
      Vector3 color8 = Npc2Controller.getColor();
      TextFieldController component = GameObject.Find("Npc2").GetComponent<TextFieldController>();
      DialogueController.dc.initDialogue(dialogueLines, "place_sidereal_auto2_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), color7, component, color8);
      dialogueLines[0].action = new TimelineFunction(this.turn_south_east);
      dialogueLines[0].actionWithText = true;
    }
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    if (dialogueLines.Count != 0)
      return;
    PlayerController.pc.setBusy(false);
  }

  private void codyRun(string s = "")
  {
    this.cody = GameObject.Find("Npc3").GetComponent<NPCWalkController>();
    GameObject.Find("Npc3").GetComponent<NPCWalkController>().setSimpleTargetV3(GameObject.Find("CodyRunAway").transform.position);
    GameObject.Find("Npc3").GetComponent<NPCWalkController>().forceAnimation("cody_run", true);
    GameObject.Find("Npc3").GetComponent<NPCWalkController>().speed = GameObject.Find("Npc3").GetComponent<NPCWalkController>().MAX_SPEED * 1.5f;
  }

  private void Update()
  {
    if (!((Object) this.cody != (Object) null) || (double) Mathf.Abs(this.cody.currentXY.x - PlayerController.wc.currentXY.x) >= 12.0 || (double) this.cody.currentXY.y - (double) PlayerController.wc.currentXY.y <= 0.0)
      return;
    this.cody.forceAnimation("stand_se");
    this.cody = (NPCWalkController) null;
  }

  private void turn_south(string var = "") => PlayerController.pc.forceAnimation("stand_s");

  private void turn_south_east(string var = "") => PlayerController.pc.forceAnimation("stand_se");
}
