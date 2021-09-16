// Decompiled with JetBrains decompiler
// Type: LocationMoonbase1Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationMoonbase1Start : MonoBehaviour
{
  public float time;
  public float destructionProgress0;
  public float destructionProgress1;
  public float destructionProgress2;
  public float cloudProgress1;
  public float cloudProgress2;
  public AudioSource audioSouruce;
  public AudioSource rumbler;
  public float secToSave;
  public List<GameObject> kawalkiKsiezyca;
  public GameObject chmura1;
  public GameObject chmura2;
  public GameObject earth;
  public GameObject moon_shadow;
  public List<float> kawalkiFinish;
  public ParticleGenerator pg1;
  public ParticleGenerator pg2;
  public ParticleGenerator pg3;
  public ParticleGenerator pg4;
  public List<ParticleGenerator> sparkles;
  public List<float> times;
  private bool sparkstime;
  public int destIndex0;
  public int destIndex1;
  public int destIndex2;
  public SpriteRenderer suit_david;
  public SpriteRenderer suit_cate;
  public SpriteRenderer suit_barry;
  public SpriteRenderer suit_cody;
  private LocationManager lm;
  private bool startdestruction1;
  private bool startdestruction2;
  public AudioSource audioSource2;
  public AudioSource audioSource3;

  private void Start()
  {
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
    this.suit_cate.enabled = false;
    this.suit_barry.enabled = false;
    this.suit_cody.enabled = false;
    this.suit_david.enabled = false;
    this.lm = GameObject.Find("Location").GetComponent<LocationManager>();
    this.startdestruction2 = GameDataController.gd.getObjective("moon_light_failed") || GameDataController.gd.getObjective("moon_light_restored");
    this.startdestruction1 = GameDataController.gd.getObjective("moon_card_taken");
    this.startdestruction2 = this.startdestruction1;
    if (GameDataController.gd.getObjective("moon_light_failed"))
    {
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_attack2, minTime: 0.0f, maxTime: 1f);
      this.audioSource2.clip = SoundsManagerController.sm.ambient_ship_crashed;
      this.audioSource2.gameObject.GetComponent<AudioReverbFilter>().reverbPreset = AudioReverbPreset.PaddedCell;
      this.audioSource2.volume = 0.75f;
      this.audioSource2.loop = true;
      this.audioSource2.time = this.audioSource2.gameObject.GetComponent<AudioSource>().clip.length * Random.Range(0.0f, 0.9f);
      this.audioSource2.Play();
    }
    else
      JukeboxMusic.jb.changeMusic((AudioClip) null);
    if (GameDataController.gd.getObjective("moon_suited_up"))
    {
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.suit_breathing, 0.75f, AudioReverbPreset.Underwater);
      PlayerController.ssg.setStepType2(StepSoundGenerator.NORMAL, AudioReverbPreset.Underwater);
    }
    else
    {
      if (GameDataController.gd.getObjective("npc1_alive"))
        this.suit_cate.enabled = true;
      if (GameDataController.gd.getObjective("npc2_alive"))
        this.suit_barry.enabled = true;
      this.suit_david.enabled = true;
      if (GameDataController.gd.getObjective("npc3_alive"))
        this.suit_cody.enabled = true;
      if (GameDataController.gd.getObjective("moon_light_failed") && !GameDataController.gd.getObjective("moon_light_restored"))
        JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.moon, 1f, AudioReverbPreset.Bathroom);
      else
        JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.pc_noise, 0.75f, AudioReverbPreset.Bathroom);
      PlayerController.ssg.setStepType2(StepSoundGenerator.NORMAL, AudioReverbPreset.Bathroom);
    }
    if (!GameDataController.gd.getObjective("visited_moonbase1"))
    {
      TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
      this.suit_cody.enabled = false;
      this.suit_barry.enabled = false;
      this.suit_cate.enabled = false;
      this.suit_david.enabled = false;
      string prefix = "moonbase1_intro_cate_p1";
      if (!GameDataController.gd.getObjective("npc1_alive"))
        prefix = "moonbase1_intro_no_cate_p1";
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, GingerActionController.getColor());
      int index1 = 1;
      if (!GameDataController.gd.getObjective("npc1_alive"))
        index1 = 0;
      dialogueLines[index1].action = new TimelineFunction(this.removeSuits);
      dialogueLines[index1].actionWithText = false;
      for (int index2 = 0; index2 < dialogueLines.Count; ++index2)
        Timeline.t.addDialogue(dialogueLines[index2]);
      Timeline.t.doNotUnlock = true;
      GameDataController.gd.setObjective("visited_moonbase1", true);
    }
    else if (!GameDataController.gd.getObjective("moon_talk_base_enter"))
    {
      TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
      string prefix = "moonbase1_intro_cate_p2";
      if (!GameDataController.gd.getObjective("npc1_alive"))
        prefix = "moonbase1_intro_no_cate_p2";
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, GingerActionController.getColor());
      if (!GameDataController.gd.getObjective("npc1_alive"))
        dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.getnote);
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
      GameDataController.gd.setObjective("moon_talk_base_enter", true);
      if (InventoryController.ic.isItemInInventory("deadbird"))
        GameDataController.Achievement("S_BIRD");
    }
    GameDataController.gd.setObjective("visited_moonbase1", true);
    this.time = Random.Range(3f, 8f);
    for (int index = 0; index < this.kawalkiKsiezyca.Count; ++index)
    {
      this.kawalkiFinish[index] = this.kawalkiKsiezyca[index].transform.position.y;
      this.kawalkiKsiezyca[index].transform.position = new Vector3(0.0f, 0.0f, this.kawalkiKsiezyca[index].transform.position.z);
    }
    this.destIndex0 = GameDataController.gd.getObjectiveIndex("moonfall_progress_1");
    this.destIndex1 = GameDataController.gd.getObjectiveIndex("moonfall_progress_2");
    this.destIndex2 = GameDataController.gd.getObjectiveIndex("moonfall_progress_4");
    this.destructionProgress0 = (float) GameDataController.gd.objectives[this.destIndex0].detail;
    this.destructionProgress1 = (float) GameDataController.gd.objectives[this.destIndex1].detail;
    this.destructionProgress2 = (float) GameDataController.gd.objectives[this.destIndex2].detail;
    this.destructionProgress0 /= 1000f;
    this.destructionProgress1 /= 1000f;
    this.destructionProgress2 /= 1000f;
    this.cloudProgress1 = Random.Range(0.0f, 1f);
    this.cloudProgress2 = Random.Range(0.0f, 1f);
    if (GameDataController.gd.getObjective("moon_window_cracked") && !GameDataController.gd.getObjective("moon_door_closed"))
    {
      PlayerController.wc.setSimpleTargetV3(GameObject.Find("jump_here").transform.position);
      GameObject.Find("LocationMoonbase1_2").GetComponent<Animator>().Play("moon_door_close");
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.wind1);
      this.Invoke("sparkles1", 3.2f);
      this.Invoke("sparkles2", 4.8f);
      this.Invoke("sparkles3", 5.1f);
      this.Invoke("sparkles4", 5.7f);
      this.Invoke("sparkles5", 6f);
      this.Invoke("unlock", 5f);
      this.audioSource2.volume = 1f;
    }
    else
    {
      if (!GameDataController.gd.getObjective("moon_window_cracked") || !GameDataController.gd.getObjective("moon_door_closed"))
        return;
      this.audioSource3.clip = SoundsManagerController.sm.ambient_sparks;
      this.audioSource3.gameObject.GetComponent<AudioReverbFilter>().reverbPreset = AudioReverbPreset.PaddedCell;
      this.audioSource3.volume = 0.3f;
      this.audioSource3.loop = true;
      this.audioSource3.Play();
      this.sparkstime = true;
      this.audioSource2.volume = 1f;
    }
  }

  private void getnote(string s = "")
  {
    InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("cate_note"));
    ItemsManager.exmineItem(ItemsManager.im.getItem("cate_note"));
  }

  private void unlock()
  {
    this.sparkstime = true;
    GameDataController.gd.setObjective("moon_door_closed", true);
    this.sparkles6();
    PlayerController.wc.forceAnimation("stand_se", true, makeBusy: false);
    PlayerController.pc.setBusy(false);
    GameObject.Find("LocationMoonbase1_2").GetComponent<LocationMoonbase1_2>().updateAll();
  }

  private void sparkles1()
  {
    this.sparkles[0].started = true;
    this.audioSource3.clip = SoundsManagerController.sm.ambient_sparks;
    this.audioSource3.gameObject.GetComponent<AudioReverbFilter>().reverbPreset = AudioReverbPreset.PaddedCell;
    this.audioSource3.volume = 0.3f;
    this.audioSource3.loop = true;
    this.audioSource3.Play();
  }

  private void sparkles2() => this.sparkles[1].started = true;

  private void sparkles3() => this.sparkles[2].started = true;

  private void sparkles4() => this.sparkles[3].started = true;

  private void sparkles5() => this.sparkles[4].started = true;

  private void sparkles6() => this.sparkles[5].started = true;

  private void removeSuits(string val = "")
  {
    GameDataController.gd.setObjective("moon_suited_up", false);
    PlayerController.pc.spawnName = "LocationMoon3_Moonbase1";
    PlayerController.wc.suit = false;
    CurtainController.cc.fadeOut("LocationMoonbase1", WalkController.Direction.S, "stand_s");
  }

  private void Update()
  {
    this.secToSave += Time.deltaTime;
    if ((double) this.secToSave > 1.0)
    {
      int num1 = (int) ((double) this.destructionProgress0 * 1000.0);
      int num2 = (int) ((double) this.destructionProgress1 * 1000.0);
      int num3 = (int) ((double) this.destructionProgress2 * 1000.0);
      this.secToSave = 0.0f;
      GameDataController.gd.objectives[this.destIndex0].detail = num1;
      GameDataController.gd.objectives[this.destIndex1].detail = num2;
      GameDataController.gd.objectives[this.destIndex2].detail = num3;
    }
    this.time -= Time.deltaTime;
    if ((double) this.time <= 0.0)
    {
      this.time = Random.Range(1f, 10f);
      float num = Random.Range(0.2f, 3f);
      if ((double) num < 1.0)
        this.rumbler.PlayOneShot(SoundsManagerController.sm.rumble_2s);
      else
        this.rumbler.PlayOneShot(SoundsManagerController.sm.rumble_4s);
      this.rumbler.pitch = Random.Range(0.9f, 1.1f);
      GameObject.Find("Location").GetComponent<LocationManager>().needShake = num;
    }
    if (this.sparkstime)
    {
      for (int index1 = 0; index1 < this.times.Count; ++index1)
      {
        List<float> times;
        int index2;
        (times = this.times)[index2 = index1] = times[index2] + Time.deltaTime;
        if ((double) this.times[index1] >= 1.0)
        {
          this.times[index1] = Random.Range(0.0f, 0.75f);
          if ((double) Random.Range(0.0f, 1f) > 0.5)
          {
            if (!this.sparkles[index1].started)
            {
              this.sparkles[index1].started = true;
            }
            else
            {
              this.sparkles[index1].started = false;
              for (int index3 = 0; index3 < this.sparkles[index1].particles.Count; index3 = index3 - 1 + 1)
              {
                GameObject gameObject = this.sparkles[index1].particles[index3].gameObject;
                this.sparkles[index1].particles.RemoveAt(index3);
                Object.Destroy((Object) gameObject);
              }
            }
          }
        }
      }
    }
    this.pg1.maxParticles = (int) ((double) this.destructionProgress2 * 100.0) * 2;
    this.pg2.maxParticles = (int) ((double) this.destructionProgress2 * 100.0) * 2;
    this.pg1.speedYMax = (int) ((double) this.destructionProgress2 * 10.0) + 1;
    this.pg2.speedYMax = (int) ((double) this.destructionProgress2 * 10.0) + 1;
    this.pg3.maxParticles = (int) ((double) this.destructionProgress2 * 40.0) - 20;
    if (this.pg3.maxParticles < 0)
      this.pg3.maxParticles = 0;
    this.pg4.maxParticles = (int) ((double) this.destructionProgress2 * 40.0) - 20;
    if (this.pg4.maxParticles < 0)
      this.pg4.maxParticles = 0;
    this.cloudProgress1 += Time.deltaTime * (float) (0.230000004172325 * (double) this.destructionProgress2 * 0.5);
    this.cloudProgress2 += Time.deltaTime * (float) (0.189999997615814 * (double) this.destructionProgress2 * 0.5);
    if ((double) this.cloudProgress1 >= 1.0)
      --this.cloudProgress1;
    if ((double) this.cloudProgress2 >= 1.0)
      --this.cloudProgress2;
    if (this.startdestruction2)
    {
      if ((double) this.destructionProgress2 < 0.25)
        this.destructionProgress2 += Time.deltaTime * 0.02f;
      else if ((double) this.destructionProgress2 < 0.5)
        this.destructionProgress2 += Time.deltaTime * 0.015f;
      else if ((double) this.destructionProgress2 < 0.75)
        this.destructionProgress2 += Time.deltaTime * 0.01f;
      else if ((double) this.destructionProgress2 < 0.800000011920929)
        this.destructionProgress2 += Time.deltaTime * 0.005f;
      else
        this.destructionProgress2 += Time.deltaTime * (1f / 500f);
      if ((double) this.destructionProgress2 > 0.75)
        this.destructionProgress1 += Time.deltaTime * 0.05f;
    }
    if (this.startdestruction1)
      this.destructionProgress0 += Time.deltaTime * 0.06f;
    if ((double) this.destructionProgress0 > 1.0)
      this.destructionProgress0 = 1f;
    if ((double) this.destructionProgress1 > 1.0)
      this.destructionProgress1 = 1f;
    if ((double) this.destructionProgress2 > 1.0)
      this.destructionProgress2 = 1f;
    for (int index = 0; index < 3; ++index)
    {
      float num = (float) ((double) this.destructionProgress0 * 1.04999995231628 - 0.0500000007450581);
      if ((double) num < 0.0)
        num = 0.0f;
      if ((double) num > 0.0 && (double) num < 0.25)
        this.lm.needShake = 4f;
      this.kawalkiKsiezyca[index].transform.position = new Vector3(0.0f, this.kawalkiFinish[index] * num, this.kawalkiKsiezyca[index].transform.position.z);
      this.kawalkiKsiezyca[index].transform.position = ScreenControler.roundToNearestFullPixel2(new Vector3(this.kawalkiKsiezyca[index].transform.position.x, this.kawalkiKsiezyca[index].transform.position.y, this.kawalkiKsiezyca[index].transform.position.z));
    }
    for (int index = 3; index < this.kawalkiKsiezyca.Count; ++index)
    {
      this.kawalkiKsiezyca[index].transform.position = new Vector3(0.0f, this.kawalkiFinish[index] * this.destructionProgress1, this.kawalkiKsiezyca[index].transform.position.z);
      this.kawalkiKsiezyca[index].transform.position = ScreenControler.roundToNearestFullPixel2(new Vector3(this.kawalkiKsiezyca[index].transform.position.x, this.kawalkiKsiezyca[index].transform.position.y, this.kawalkiKsiezyca[index].transform.position.z));
    }
    this.earth.transform.position = new Vector3(0.0f, 1f * this.destructionProgress2, this.earth.transform.position.z);
    this.earth.transform.position = ScreenControler.roundToNearestFullPixel2(new Vector3(this.earth.transform.position.x, this.earth.transform.position.y, this.earth.transform.position.z));
    this.moon_shadow.transform.position = new Vector3(0.0f, 1.025f * this.destructionProgress2, this.moon_shadow.transform.position.z);
    this.moon_shadow.transform.position = ScreenControler.roundToNearestFullPixel2(new Vector3(this.moon_shadow.transform.position.x, this.moon_shadow.transform.position.y, this.moon_shadow.transform.position.z));
    this.chmura1.transform.position = new Vector3((float) ((double) this.cloudProgress1 * 4.40000009536743 - 2.20000004768372), this.chmura1.transform.position.y, this.chmura1.transform.position.z);
    this.chmura1.transform.position = ScreenControler.roundToNearestFullPixel2(new Vector3(this.chmura1.transform.position.x, this.earth.transform.position.y - 0.45f, 0.3f));
    this.chmura2.transform.position = new Vector3((float) (2.20000004768372 - (double) this.cloudProgress2 * 4.40000009536743), this.earth.transform.position.y, this.chmura2.transform.position.z);
    this.chmura2.transform.position = ScreenControler.roundToNearestFullPixel2(new Vector3(this.chmura2.transform.position.x, this.chmura2.transform.position.y - 0.45f, 0.4f));
  }
}
