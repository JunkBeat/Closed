// Decompiled with JetBrains decompiler
// Type: LocationMoon2Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationMoon2Start : MonoBehaviour
{
  public float time;
  public PolygonCollider2D pc2;
  public AudioSource audioSouruce;
  public AudioSource rumbler;

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
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED / 2f;
    PlayerController.wc.GetComponent<Animator>().speed = 0.5f;
    PlayerController.pc.copySettingsToNPCs();
    this.audioSouruce.loop = true;
    this.audioSouruce.clip = SoundsManagerController.sm.moon;
    this.audioSouruce.volume = 1f;
    this.audioSouruce.Play();
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.suit_breathing, 0.75f, AudioReverbPreset.Underwater);
    PlayerController.ssg.setStepType2(StepSoundGenerator.MOON, AudioReverbPreset.Underwater);
    if (GameDataController.gd.getObjectiveDetail("airlock_ring_1") == 0 && GameDataController.gd.getObjectiveDetail("airlock_ring_2") == 0 && GameDataController.gd.getObjectiveDetail("airlock_ring_3") == 0 && GameDataController.gd.getObjectiveDetail("airlock_ring_4") == 0 && GameDataController.gd.getObjectiveDetail("airlock_ring_5") == 0)
      this.pc2.enabled = true;
    else
      this.pc2.enabled = false;
    GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
    this.time = Random.Range(1f, 5f);
  }

  private void Update()
  {
    this.time -= Time.deltaTime;
    if ((double) this.time > 0.0)
      return;
    this.time = GameDataController.gd.getObjectiveDetail("airlock_ring_1") != 0 || GameDataController.gd.getObjectiveDetail("airlock_ring_2") != 0 || GameDataController.gd.getObjectiveDetail("airlock_ring_3") != 0 || GameDataController.gd.getObjectiveDetail("airlock_ring_4") != 0 || GameDataController.gd.getObjectiveDetail("airlock_ring_5") != 0 ? Random.Range(1f, 10f) : Random.Range(1f, 5f);
    float num = Random.Range(0.2f, 3f);
    if ((double) num < 1.0)
      this.rumbler.PlayOneShot(SoundsManagerController.sm.rumble_2s);
    else
      this.rumbler.PlayOneShot(SoundsManagerController.sm.rumble_4s);
    this.rumbler.pitch = Random.Range(0.9f, 1.1f);
    GameObject.Find("Location").GetComponent<LocationManager>().needShake = num;
  }
}
