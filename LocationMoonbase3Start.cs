// Decompiled with JetBrains decompiler
// Type: LocationMoonbase3Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class LocationMoonbase3Start : MonoBehaviour
{
  public float time;
  public AudioSource audioSouruce;
  public AudioSource audioSouruce2;
  public AudioSource rumbler;
  public MoonbaseLightFlicker mlf;
  public bool walkingHere;

  private void Start()
  {
    this.walkingHere = false;
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = -2;
    PlayerController.wc.shadow.skewFactor = 20f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.0f;
    PlayerController.wc.shadow.source = 120f;
    PlayerController.wc.shadow.scaleFactor = 0.7f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    this.audioSouruce.loop = true;
    this.audioSouruce.clip = SoundsManagerController.sm.moon;
    this.audioSouruce.volume = 1f;
    this.audioSouruce.Play();
    if (!GameDataController.gd.getObjective("moon_david_sleeps") && !GameDataController.gd.getObjective("moon_light_restored") && !GameDataController.gd.getObjective("moon_light_failed") && (GameDataController.gd.getObjective("moon_cate_sleeps") || GameDataController.gd.getObjective("moon_cody_sleeps") || GameDataController.gd.getObjective("moon_barry_sleeps")))
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_emotional);
    else if (!GameDataController.gd.getObjective("moon_david_sleeps") && GameDataController.gd.getObjective("moon_light_restored"))
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_attack2, minTime: 0.0f, maxTime: 1f);
    else
      JukeboxMusic.jb.changeMusic((AudioClip) null);
    if (GameDataController.gd.getObjective("moon_light_failed"))
    {
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.moon, 0.75f, AudioReverbPreset.Bathroom);
      this.audioSouruce2.clip = SoundsManagerController.sm.ambient_ship_crashed;
      this.audioSouruce2.gameObject.GetComponent<AudioReverbFilter>().reverbPreset = AudioReverbPreset.PaddedCell;
      this.audioSouruce2.volume = 0.75f;
      this.audioSouruce2.loop = true;
      this.audioSouruce2.pitch = 0.25f;
      this.audioSouruce2.time = this.audioSouruce2.clip.length * Random.Range(0.0f, 0.9f);
      this.audioSouruce2.Play();
    }
    else
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.pc_noise, 0.75f, AudioReverbPreset.Bathroom);
    PlayerController.ssg.setStepType2(StepSoundGenerator.NORMAL, AudioReverbPreset.Bathroom);
    GameDataController.gd.setObjective("visited_moonbase3", true);
    this.time = Random.Range(3f, 8f);
    if (!GameDataController.gd.getObjective("moon_talk_pods"))
    {
      TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
      string prefix = "moonbase2_intro_cate";
      if (!GameDataController.gd.getObjective("npc1_alive"))
        prefix = "moonbase2_intro_no_cate";
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, GingerActionController.getColor());
      if (GameDataController.gd.getObjective("npc1_alive"))
        dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.startDialogue);
      dialogueLines[0].action = new TimelineFunction(this.walkToMiddle);
      dialogueLines[0].actionWithText = true;
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
      GameDataController.gd.setObjective("moon_talk_pods", true);
    }
    if (GameDataController.gd.getObjective("moon_david_sleeps"))
    {
      this.Invoke("close_david_pod", 3f);
      GameObject.Find("Location").GetComponent<LocationManager>().needShake = 5f;
    }
    GameObject.Find("Location").GetComponent<LocationManager>().needShake = 115f;
  }

  private void walkToMiddle(string s = "")
  {
    PlayerController.wc.setSimpleTargetV3(GameObject.Find("DavidWalkHere").transform.position);
    PlayerController.pc.setBusy(true);
    PlayerController.wc.forceAnimation("walk_e", true);
    this.walkingHere = true;
  }

  private void close_david_pod()
  {
    GameObject.Find("Moonbase3Pad1").GetComponent<Moonbase3Pod>().openIfNeeded(true);
    this.Invoke("go_to_sleep", 5f);
  }

  private void go_to_sleep()
  {
    PlayerController.pc.spawnName = "InfoExit";
    if (GameDataController.gd.getObjective("moon_disc1_used") && GameDataController.gd.getObjective("moon_disc2_used"))
      CurtainController.cc.fadeOut("LocationEndingGood", WalkController.Direction.S, tSpeed: 1f);
    else
      CurtainController.cc.fadeOut("Ending4", WalkController.Direction.S, tSpeed: 1f);
  }

  public void updateMLF()
  {
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.moon, 0.75f, AudioReverbPreset.Bathroom);
    this.mlf.lightsFailed = true;
  }

  public void startDialogue(string str = "") => GameObject.Find("Ginger").GetComponent<GingerActionController>().npcClickAction(string.Empty);

  private void Update()
  {
    if (this.walkingHere && (double) PlayerController.wc.currentXY.x < 120.0)
    {
      this.walkingHere = false;
      PlayerController.wc.forceAnimation("stand_ne", true, makeBusy: false);
      PlayerController.wc.fullStop(true);
    }
    this.time -= Time.deltaTime;
    if ((double) this.time > 0.0)
      return;
    this.time = Random.Range(1f, 10f);
    float num = Random.Range(0.2f, 3f);
    if ((double) num < 1.0)
      this.rumbler.PlayOneShot(SoundsManagerController.sm.rumble_2s);
    else
      this.rumbler.PlayOneShot(SoundsManagerController.sm.rumble_4s);
    this.rumbler.pitch = Random.Range(0.9f, 1.1f);
    GameObject.Find("Location").GetComponent<LocationManager>().needShake = num;
  }
}
