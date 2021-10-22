// Decompiled with JetBrains decompiler
// Type: LocationSiderealF0SStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationSiderealF0SStart : MonoBehaviour
{
  public ParticleGenerator pg;
  public AudioSource audio;
  public NPCWalkController ginger;
  public NPCWalkController cody;
  public NPCWalkController barry;
  public GameObject npc;
  public GameObject npcTarget;
  public TextFieldController npcTextField;
  private float txtAlpha = 1f;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 2;
    PlayerController.wc.shadow.skewFactor = 60f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.scaleFactor = 0.5f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 120f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.NORMAL, AudioReverbPreset.Cave);
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.underground_1, 1f);
    this.Invoke("sypnij", 1f);
    GameDataController.gd.setObjective("visited_sidereal_f0s", true);
    this.npcTextField.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.npcTextField.gameObject.transform.position);
    if ((GameDataController.gd.getObjective("npc3_alive") || GameDataController.gd.getObjectiveDetail("npc3_alive") != 1) && (GameDataController.gd.getObjective("npc2_alive") || GameDataController.gd.getObjectiveDetail("npc2_alive") != 1))
      GameDataController.gd.setObjective("sidereal_npc_found", true);
    if (!GameDataController.gd.getObjective("dialogue_ginger_reunited") || GameDataController.gd.getObjective("dialogue_ginger_dead_mourned"))
      return;
    GameObject.Find("Ginger").GetComponent<GingerActionController>().mourn();
  }

  private void sypnij()
  {
    this.pg.started = true;
    float time = Random.Range(0.2f, 3f);
    this.Invoke("dosc", time);
    if ((double) time < 0.75)
      this.audio.PlayOneShot(SoundsManagerController.sm.sand_pour1);
    else if ((double) time < 1.5)
      this.audio.PlayOneShot(SoundsManagerController.sm.sand_pour3);
    else if ((double) time < 2.25)
      this.audio.PlayOneShot(SoundsManagerController.sm.sand_pour4);
    else
      this.audio.PlayOneShot(SoundsManagerController.sm.sand_pour2);
  }

  private void dosc()
  {
    this.pg.started = false;
    this.Invoke("sypnij", Random.Range(1.1f, 15.75f));
  }

  private void Update()
  {
    PlayerController.wc.shadow.downwards = (double) PlayerController.wc.currentXY.y <= 40.0;
    float f = (float) (((double) PlayerController.wc.currentXY.y - 40.0) / 20.0);
    if ((double) f > 1.0)
      f = 1f;
    if ((double) f < -1.0)
      f = -1f;
    float num1 = 1f - Mathf.Abs(f);
    PlayerController.wc.shadow.fadeRateV = 0.075f * num1;
    float num2 = Mathf.Sqrt(Mathf.Pow(120f - PlayerController.wc.currentXY.x, 2f) + Mathf.Pow((float) (67.0 - (double) PlayerController.wc.currentXY.y - 20.0), 2f)) / 120f;
    PlayerController.wc.shadow.scaleFactor = 0.65f * num2;
    PlayerController.wc.shadowOffsetY = (int) (2.0 - (double) PlayerController.wc.shadow.scaleFactor);
    if (GameDataController.gd.getObjective("npc2_alive"))
      this.shadowNPC(this.barry);
    if (GameDataController.gd.getObjective("npc3_alive"))
      this.shadowNPC(this.cody);
    if (GameDataController.gd.getObjective("dialogue_ginger_reunited"))
      this.shadowNPC(this.ginger);
    this.npcTextField.setAlpha(this.txtAlpha);
    if (GameDataController.gd.getObjective("sidereal_npc_found"))
      return;
    if (GameDataController.gd.getObjectiveDetail("sidereal_npc_found") == 0)
    {
      if ((double) PlayerController.wc.currentXY.x >= 145.0)
        return;
      PlayerController.wc.fullStop(true);
      PlayerController.wc.forceAnimation("stand_s");
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      PlayerController.pc.textField.shift.y = 18f;
      if (!GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjectiveDetail("npc3_alive") == 1)
        DialogueController.dc.initDialogue(dialogueLines, "sidereal_cody_death1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.npcTextField, Npc3Controller.getColor());
      else
        DialogueController.dc.initDialogue(dialogueLines, "sidereal_barry_death1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.npcTextField, Npc2Controller.getColor(), GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor());
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
      if (!GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjectiveDetail("npc2_alive") == 1)
        Timeline.t.actions[1].function = new TimelineFunction(this.walkNPC);
      Timeline.t.actions[dialogueLines.Count - 1].function = new TimelineFunction(this.walkDown);
      this.npcTextField.setAlpha(1f);
      this.txtAlpha = 1f;
      GameDataController.gd.setObjectiveDetail("sidereal_npc_found", 1);
    }
    else if (GameDataController.gd.getObjectiveDetail("sidereal_npc_found") == 2)
    {
      PlayerController.pc.setBusy(true);
      PlayerController.wc.forceAnimation("walk_se", true);
      PlayerController.wc.setSimpleTargetV3(this.npc.transform.position);
      GameDataController.gd.setObjectiveDetail("sidereal_npc_found", 3);
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("sidereal_npc_found") != 3 || (double) PlayerController.wc.targetXY.y != (double) PlayerController.wc.currentXY.y)
        return;
      PlayerController.wc.speed = PlayerController.wc.MAX_SPEED * 1f;
      GameDataController.gd.setObjectiveDetail("sidereal_npc_found", 4);
      GameDataController.gd.setObjective("sidereal_npc_found", true);
      PlayerController.wc.forceAnimation("kneel_se_in");
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      PlayerController.pc.textField.shift.y = 4f;
      if (!GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjectiveDetail("npc3_alive") == 1)
      {
        DialogueController.dc.initDialogue(dialogueLines, "sidereal_cody_death2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.npcTextField, Npc3Controller.getColor(), GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor());
        for (int index = 0; index < dialogueLines.Count; ++index)
        {
          dialogueLines[index].action = new TimelineFunction(this.txtColor);
          dialogueLines[index].actionParam = string.Empty + (object) (float) ((double) (dialogueLines.Count - index) / (double) dialogueLines.Count);
          Timeline.t.addDialogue(dialogueLines[index]);
        }
        Timeline.t.actions[4].function = new TimelineFunction(this.walkNPC);
        Timeline.t.actions[6].function = new TimelineFunction(this.mourn);
        Timeline.t.actions[11].function = new TimelineFunction(this.music);
        Timeline.t.actions[dialogueLines.Count - 1].function = new TimelineFunction(this.die);
      }
      else
      {
        DialogueController.dc.initDialogue(dialogueLines, "sidereal_barry_death2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.npcTextField, Npc2Controller.getColor(), GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor());
        for (int index = 0; index < dialogueLines.Count; ++index)
        {
          dialogueLines[index].action = new TimelineFunction(this.txtColor);
          dialogueLines[index].actionParam = string.Empty + (object) (float) ((double) (dialogueLines.Count - index) / (double) dialogueLines.Count);
          Timeline.t.addDialogue(dialogueLines[index]);
        }
        Timeline.t.actions[3].function = new TimelineFunction(this.mourn);
        Timeline.t.actions[21].function = new TimelineFunction(this.music);
        Timeline.t.actions[dialogueLines.Count - 1].function = new TimelineFunction(this.die);
      }
    }
  }

  private void mourn(string s = "")
  {
    MonoBehaviour.print((object) "MOURN");
    if (!GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjectiveDetail("npc3_alive") == 1)
      GameObject.Find("Npc2").GetComponent<NPCWalkController>().forceAnimation("barry_mourn_cody");
    else
      GameObject.Find("Npc3").GetComponent<NPCWalkController>().forceAnimation("cody_mourn_barry");
  }

  private void music(string s = "") => JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_sorrow, false);

  private void txtColor(string s = "")
  {
    this.txtAlpha = float.Parse(s);
    if (GameDataController.gd.getObjective("npc2_alive") || GameDataController.gd.getObjectiveDetail("npc2_alive") != 1)
      return;
    this.txtAlpha *= 5f;
  }

  private void walkDown(string s = "")
  {
    GameDataController.gd.setObjectiveDetail("sidereal_npc_found", 2);
    Timeline.t.doNotUnlock = true;
  }

  private void die(string s = "")
  {
    this.Invoke("die2", 4f);
    Timeline.t.doNotUnlock = true;
  }

  private void die2()
  {
    PlayerController.pc.textField.shift.y = 18f;
    PlayerController.wc.forceDirection(WalkController.Direction.SW);
    PlayerController.wc.forceAnimation("kneel_se_out");
  }

  private void walkNPC(string s = "")
  {
    if (!GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjectiveDetail("npc3_alive") == 1)
      GameObject.Find("Npc2").GetComponent<NPCWalkController>().setSimpleTargetV3(this.npcTarget.transform.position);
    else
      GameObject.Find("Npc3").GetComponent<NPCWalkController>().setSimpleTargetV3(this.npcTarget.transform.position);
    Timeline.t.doNotUnlock = true;
  }

  private void shadowNPC(NPCWalkController npcWC)
  {
    npcWC.shadow.downwards = (double) npcWC.currentXY.y <= 40.0;
    float f = (float) (((double) npcWC.currentXY.y - 40.0) / 20.0);
    if ((double) f > 1.0)
      f = 1f;
    if ((double) f < -1.0)
      f = -1f;
    float num1 = 1f - Mathf.Abs(f);
    npcWC.shadow.fadeRateV = 0.075f * num1;
    float num2 = Mathf.Sqrt(Mathf.Pow(120f - npcWC.currentXY.x, 2f) + Mathf.Pow((float) (67.0 - (double) npcWC.currentXY.y - 20.0), 2f)) / 120f;
    npcWC.shadow.scaleFactor = 0.65f * num2;
    npcWC.shadowOffsetY = (int) (2.0 - (double) npcWC.shadow.scaleFactor);
  }
}
