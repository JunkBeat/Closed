// Decompiled with JetBrains decompiler
// Type: LocationOutpost5Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationOutpost5Start : MonoBehaviour
{
  public SpriteRenderer light1;
  public SpriteRenderer light2;
  public SpriteRenderer light3;
  public GameObject playerTarget;
  public GameObject npc1_target;
  public GameObject npc2_target;
  public GameObject npc3_target;
  private NPCWalkController codyWalker;
  public bool codyRun;
  private bool firstTime;
  private int lights;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 3f / 500f;
    PlayerController.wc.shadowOffsetY = -2;
    PlayerController.wc.shadow.skewFactor = 70f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.source = 200f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.NORMAL, AudioReverbPreset.Hallway);
    PlayerController.wc.shadow.scaleFactor = 0.25f;
    PlayerController.wc.shadow.downwards = true;
    this.codyRun = false;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    this.firstTime = false;
    this.lights = GameDataController.gd.getObjectiveDetail("outpost_underground_light");
    this.light1.enabled = false;
    this.light2.enabled = false;
    this.light3.enabled = false;
    if (!GameDataController.gd.getObjective("visited_outpost5"))
    {
      this.firstTime = true;
      PlayerController.pc.setBusy(true);
      this.Invoke("walkthere", 0.01f);
      PlayerController.wc.speed = PlayerController.wc.MAX_SPEED * 0.8f;
      this.light1.enabled = true;
      this.light2.enabled = false;
      this.light3.enabled = false;
      if (GameDataController.gd.getObjective("npc3_alive"))
        GameObject.Find("Npc3").GetComponent<NPCWalkController>().speed = 2f;
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.neon_on);
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_main, false);
    }
    else
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_6a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.buzz, 0.3f);
  }

  private void forceTalk1()
  {
    Vector3 color1 = GingerActionController.getColor();
    TextFieldController component1 = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    Vector3 color2 = Npc2Controller.getColor();
    Vector3 color3 = Npc3Controller.getColor();
    TextFieldController component2 = GameObject.Find("Npc2").GetComponent<TextFieldController>();
    TextFieldController component3 = GameObject.Find("Npc3").GetComponent<TextFieldController>();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    if (GameDataController.gd.getObjective("npc3_alive"))
      dialogueLines.Add(new DialogueLine(component3, color3, GameStrings.getString(GameStrings.dialogues, "outpost_spaceship_discovered_Cody_1"), (TimelineFunction) null));
    DialogueController.dc.initDialogue(dialogueLines, "outpost_spaceship_discovered_A", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1);
    if (GameDataController.gd.getObjective("npc3_alive"))
      dialogueLines.Add(new DialogueLine(component3, color3, GameStrings.getString(GameStrings.dialogues, "outpost_spaceship_discovered_Cody_2"), (TimelineFunction) null));
    if (GameDataController.gd.getObjective("npc2_alive"))
      dialogueLines.Add(new DialogueLine(component2, color2, GameStrings.getString(GameStrings.dialogues, "outpost_spaceship_discovered_Barry_1"), (TimelineFunction) null));
    DialogueController.dc.initDialogue(dialogueLines, "outpost_spaceship_discovered_B", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1);
    if (GameDataController.gd.getObjective("npc3_alive"))
      dialogueLines.Add(new DialogueLine(component3, color3, GameStrings.getString(GameStrings.dialogues, "outpost_spaceship_discovered_Cody_3"), (TimelineFunction) null));
    DialogueController.dc.initDialogue(dialogueLines, "outpost_spaceship_discovered_C", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1);
    if (GameDataController.gd.getObjective("npc2_alive"))
    {
      dialogueLines.Add(new DialogueLine(component2, color2, GameStrings.getString(GameStrings.dialogues, "outpost_spaceship_discovered_Barry_2"), (TimelineFunction) null));
      dialogueLines.Add(new DialogueLine(component2, color2, GameStrings.getString(GameStrings.dialogues, "outpost_spaceship_discovered_Barry_3"), (TimelineFunction) null));
    }
    DialogueController.dc.initDialogue(dialogueLines, "outpost_spaceship_discovered_D", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1);
    if (GameDataController.gd.getObjective("npc3_alive"))
      dialogueLines.Add(new DialogueLine(component3, color3, GameStrings.getString(GameStrings.dialogues, "outpost_spaceship_discovered_Cody_4"), (TimelineFunction) null));
    DialogueController.dc.initDialogue(dialogueLines, "outpost_spaceship_discovered_E", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1);
    if (GameDataController.gd.getObjective("npc2_alive"))
      dialogueLines.Add(new DialogueLine(component2, color2, GameStrings.getString(GameStrings.dialogues, "outpost_spaceship_discovered_Barry_4"), (TimelineFunction) null));
    else
      DialogueController.dc.initDialogue(dialogueLines, "outpost_spaceship_discovered_F", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1);
    DialogueController.dc.initDialogue(dialogueLines, "outpost_spaceship_discovered_G", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1);
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  private void walkthere()
  {
    PlayerController.wc.setSimpleTargetV3(this.playerTarget.transform.position);
    PlayerController.pc.setBusy(true);
  }

  private void Update()
  {
    if (!this.firstTime)
      return;
    if (this.lights == 2 && (double) PlayerController.wc.currentXY.x < 160.0)
    {
      GameDataController.gd.setObjectiveDetail("outpost_underground_light", 3);
      this.lights = 3;
      this.light1.enabled = false;
      this.light2.enabled = true;
      this.light3.enabled = false;
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.spotlight);
    }
    if (this.lights == 3 && (double) PlayerController.wc.currentXY.x < 140.0)
    {
      GameDataController.gd.setObjectiveDetail("outpost_underground_light", 4);
      this.lights = 4;
      if (GameDataController.gd.getObjective("npc3_alive"))
      {
        GameObject.Find("Npc3").GetComponent<NPCWalkController>().setSimpleTargetV3(GameObject.Find("CodyTarget").transform.position);
        GameObject.Find("Npc3").GetComponent<NPCWalkController>().speed = 5f;
        GameObject.Find("Npc3").GetComponent<NPCWalkController>().forceAnimation("cody_run", true);
        this.codyRun = true;
        this.codyWalker = GameObject.Find("Npc3").GetComponent<NPCWalkController>();
      }
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.spotlight);
      this.light1.enabled = false;
      this.light2.enabled = false;
      this.light3.enabled = true;
      this.forceTalk1();
    }
    if (this.codyRun && (double) this.codyWalker.currentXY.x < 115.0)
    {
      this.codyRun = false;
      GameObject.Find("Npc3").GetComponent<NPCWalkController>().forceAnimation("cody_run_glass", true);
    }
    if (this.lights == 4 && (double) PlayerController.wc.currentXY.x < 120.0)
    {
      GameDataController.gd.setObjectiveDetail("outpost_underground_light", 5);
      this.lights = 5;
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.spotlight);
      this.light1.enabled = false;
      this.light2.enabled = false;
      this.light3.enabled = false;
    }
    if ((double) PlayerController.wc.currentXY.x >= 60.0)
      return;
    GameDataController.gd.setObjective("visited_outpost5", true);
    GameDataController.gd.setObjective("outpost_spaceship_discovered", false);
    this.firstTime = false;
    PlayerController.pc.setBusy(false);
    PlayerController.wc.fullStop();
    PlayerController.wc.forceAnimation("stand_ne", true);
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
  }
}
