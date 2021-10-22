// Decompiled with JetBrains decompiler
// Type: LocationMoonShipStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationMoonShipStart : MonoBehaviour
{
  public List<ParticleGenerator> sparks;
  public List<float> times;
  public AudioSource audioSouruce;
  public AudioSource audioSource2;
  public AudioSource audioSource3;
  public AudioSource rumbler;
  public float time;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = -2;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 15f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.source = 10f;
    PlayerController.wc.shadow.scaleFactor = 0.25f;
    PlayerController.wc.shadow.downwards = false;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    this.audioSouruce.loop = true;
    this.audioSouruce.clip = SoundsManagerController.sm.moon;
    this.audioSouruce.volume = 0.5f;
    this.audioSouruce.Play();
    GameDataController.gd.setObjective("visited_moon_ship", true);
    this.updateThings();
  }

  public void updateThings()
  {
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    if (GameDataController.gd.getObjective("moon_door_open"))
    {
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.suit_breathing, 1f, AudioReverbPreset.Underwater);
      this.GetComponent<AudioSource>().Stop();
      PlayerController.ssg.setStepType2("rubber", AudioReverbPreset.Underwater);
      PlayerController.wc.speed = PlayerController.wc.MAX_SPEED / 2f;
      this.audioSource3.Stop();
      this.audioSource2.Stop();
      PlayerController.wc.GetComponent<Animator>().speed = 0.5f;
    }
    else if (GameDataController.gd.getObjective("moon_suited_up"))
    {
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.suit_breathing, 1f, AudioReverbPreset.Underwater);
      this.GetComponent<AudioSource>().Stop();
      this.GetComponent<AudioSource>().clip = SoundsManagerController.sm.alert2;
      this.GetComponent<AudioReverbFilter>().reverbPreset = AudioReverbPreset.Bathroom;
      this.GetComponent<AudioSource>().volume = 0.1f;
      this.GetComponent<AudioSource>().loop = true;
      this.GetComponent<AudioSource>().Play();
      PlayerController.ssg.setStepType2("rubber", AudioReverbPreset.Underwater);
      this.audioSource2.clip = SoundsManagerController.sm.ambient_ship_crashed;
      this.audioSource2.gameObject.GetComponent<AudioReverbFilter>().reverbPreset = AudioReverbPreset.Underwater;
      this.audioSource2.volume = 0.3f;
      this.audioSource2.loop = true;
      this.audioSource2.Play();
      this.audioSource3.clip = SoundsManagerController.sm.ambient_sparks;
      this.audioSource3.gameObject.GetComponent<AudioReverbFilter>().reverbPreset = AudioReverbPreset.PaddedCell;
      this.audioSource3.volume = 0.2f;
      this.audioSource3.loop = true;
      this.audioSource3.Play();
      PlayerController.wc.speed = PlayerController.wc.MAX_SPEED * 0.75f;
      PlayerController.wc.GetComponent<Animator>().speed = 0.75f;
    }
    else
    {
      PlayerController.ssg.setStepType2("rubber", AudioReverbPreset.CarpetedHallway);
      JukeboxAmbient.jb.changeAmbient((AudioClip) null, 0.0f);
      PlayerController.wc.GetComponent<Animator>().speed = 1f;
      this.GetComponent<AudioSource>().Stop();
      this.GetComponent<AudioSource>().clip = SoundsManagerController.sm.alert2;
      this.GetComponent<AudioReverbFilter>().reverbPreset = AudioReverbPreset.CarpetedHallway;
      this.GetComponent<AudioSource>().volume = 0.2f;
      this.GetComponent<AudioSource>().loop = true;
      this.GetComponent<AudioSource>().Play();
      this.audioSource2.clip = SoundsManagerController.sm.ambient_ship_crashed;
      this.audioSource2.gameObject.GetComponent<AudioReverbFilter>().reverbPreset = AudioReverbPreset.Underwater;
      this.audioSource2.volume = 0.5f;
      this.audioSource2.loop = true;
      this.audioSource2.Play();
      this.audioSource3.clip = SoundsManagerController.sm.ambient_sparks;
      this.audioSource3.gameObject.GetComponent<AudioReverbFilter>().reverbPreset = AudioReverbPreset.PaddedCell;
      this.audioSource3.volume = 0.2f;
      this.audioSource3.loop = true;
      this.audioSource3.Play();
    }
    this.time = Random.Range(5f, 15f);
  }

  private void Update()
  {
    this.time -= Time.deltaTime;
    if ((double) this.time <= 0.0)
    {
      this.time = Random.Range(5f, 20f);
      float num = Random.Range(0.2f, 2f);
      GameObject.Find("Location").GetComponent<LocationManager>().needShake = num;
      this.rumbler.PlayOneShot(SoundsManagerController.sm.rumble_2s);
      this.rumbler.pitch = Random.Range(0.85f, 1.15f);
    }
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
          if (!this.sparks[index1].started)
          {
            this.sparks[index1].started = true;
          }
          else
          {
            this.sparks[index1].started = false;
            for (int index3 = 0; index3 < this.sparks[index1].particles.Count; index3 = index3 - 1 + 1)
            {
              GameObject gameObject = this.sparks[index1].particles[index3].gameObject;
              this.sparks[index1].particles.RemoveAt(index3);
              Object.Destroy((Object) gameObject);
            }
          }
        }
      }
    }
  }
}
