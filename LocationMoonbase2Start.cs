// Decompiled with JetBrains decompiler
// Type: LocationMoonbase2Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationMoonbase2Start : MonoBehaviour
{
  public float time;
  public float destructionProgress;
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
  public int destIndex1;
  public int destIndex2;
  private bool startdestruction1;
  private bool startdestruction2;
  public bool windowMayCrack;

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
    if (GameDataController.gd.getObjective("moon_light_failed"))
    {
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_attack2, minTime: 0.0f, maxTime: 1f);
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.moon, 1f, AudioReverbPreset.Bathroom);
    }
    else
    {
      JukeboxMusic.jb.changeMusic((AudioClip) null);
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.pc_noise, 0.75f, AudioReverbPreset.Bathroom);
    }
    PlayerController.ssg.setStepType2(StepSoundGenerator.NORMAL, AudioReverbPreset.Bathroom);
    GameDataController.gd.setObjective("visited_moonbase2", true);
    this.time = Random.Range(3f, 8f);
    for (int index = 0; index < this.kawalkiKsiezyca.Count; ++index)
    {
      this.kawalkiFinish[index] = this.kawalkiKsiezyca[index].transform.position.y;
      this.kawalkiKsiezyca[index].transform.position = new Vector3(0.0f, 0.0f, this.kawalkiKsiezyca[index].transform.position.z);
    }
    this.destIndex1 = GameDataController.gd.getObjectiveIndex("moonfall_progress_3");
    this.destIndex2 = GameDataController.gd.getObjectiveIndex("moonfall_progress_4");
    this.destructionProgress = (float) GameDataController.gd.objectives[this.destIndex1].detail;
    this.destructionProgress2 = (float) GameDataController.gd.objectives[this.destIndex2].detail;
    this.destructionProgress /= 1000f;
    this.destructionProgress2 /= 1000f;
    this.startdestruction1 = GameDataController.gd.getObjective("moon_card_taken");
    this.startdestruction2 = this.startdestruction1;
    this.cloudProgress1 = Random.Range(0.0f, 1f);
    this.cloudProgress2 = Random.Range(0.0f, 1f);
    this.windowMayCrack = false;
    if (!GameDataController.gd.getObjective("moon_light_restored") || GameDataController.gd.getObjective("moon_window_cracked"))
      return;
    this.windowMayCrack = true;
  }

  private void Update()
  {
    this.secToSave += Time.deltaTime;
    if ((double) this.secToSave > 1.0)
    {
      int num1 = (int) ((double) this.destructionProgress * 1000.0);
      int num2 = (int) ((double) this.destructionProgress2 * 1000.0);
      this.secToSave = 0.0f;
      GameDataController.gd.objectives[this.destIndex1].detail = num1;
      GameDataController.gd.objectives[this.destIndex2].detail = num2;
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
    if (this.windowMayCrack && (double) PlayerController.wc.currentXY.x < 160.0)
    {
      this.windowMayCrack = false;
      GameDataController.gd.setObjective("moon_window_cracked", true);
      GameObject.Find("Location").transform.Find("plane00a").GetComponent<LocationMoonbase2Window>().crack();
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
    if (this.startdestruction1)
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
    }
    if (this.startdestruction2 && (double) this.destructionProgress2 > 0.75)
      this.destructionProgress += Time.deltaTime * 0.05f;
    if ((double) this.destructionProgress > 1.0)
      this.destructionProgress = 1f;
    if ((double) this.destructionProgress2 > 1.0)
      this.destructionProgress2 = 1f;
    for (int index = 0; index < 7; ++index)
    {
      this.kawalkiKsiezyca[index].transform.position = new Vector3(0.0f, this.kawalkiFinish[index] * this.destructionProgress, this.kawalkiKsiezyca[index].transform.position.z);
      this.kawalkiKsiezyca[index].transform.position = ScreenControler.roundToNearestFullPixel2(new Vector3(this.kawalkiKsiezyca[index].transform.position.x, this.kawalkiKsiezyca[index].transform.position.y, this.kawalkiKsiezyca[index].transform.position.z));
    }
    this.earth.transform.position = new Vector3(0.0f, 1f * this.destructionProgress2, this.earth.transform.position.z);
    this.earth.transform.position = ScreenControler.roundToNearestFullPixel2(new Vector3(this.earth.transform.position.x, this.earth.transform.position.y, this.earth.transform.position.z));
    this.moon_shadow.transform.position = new Vector3(0.0f, 1.025f * this.destructionProgress2, this.moon_shadow.transform.position.z);
    this.moon_shadow.transform.position = ScreenControler.roundToNearestFullPixel2(new Vector3(this.moon_shadow.transform.position.x, this.moon_shadow.transform.position.y, this.moon_shadow.transform.position.z));
    this.chmura1.transform.position = new Vector3((float) ((double) this.cloudProgress1 * 4.40000009536743 - 2.20000004768372), this.chmura1.transform.position.y, this.chmura1.transform.position.z);
    this.chmura1.transform.position = ScreenControler.roundToNearestFullPixel2(new Vector3(this.chmura1.transform.position.x, this.earth.transform.position.y - 0.45f, 0.5f));
    this.chmura2.transform.position = new Vector3((float) (2.20000004768372 - (double) this.cloudProgress2 * 4.40000009536743), this.earth.transform.position.y, this.chmura2.transform.position.z);
    this.chmura2.transform.position = ScreenControler.roundToNearestFullPixel2(new Vector3(this.chmura2.transform.position.x, this.chmura2.transform.position.y - 0.45f, 0.55f));
  }
}
