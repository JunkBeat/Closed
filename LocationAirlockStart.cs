// Decompiled with JetBrains decompiler
// Type: LocationAirlockStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationAirlockStart : MonoBehaviour
{
  public float time;
  public AudioSource audioSouruce;
  public AudioSource rumbler;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = -5f;
    PlayerController.wc.shadow.startAlpha = 0.0f;
    PlayerController.wc.shadow.source = 10f;
    PlayerController.ssg.setStepType("none");
    PlayerController.pc.copySettingsToNPCs();
    MonoBehaviour.print((object) "............................. LOCATION INFO  ..................................");
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(-999f, -999f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    InventoryButtonController.ibc.gameObject.transform.position = worldPoint;
    GameObject.Find("Location").GetComponent<LocationManager>().esc = (ObjectActionController) GameObject.Find("MoonAirlockExit").GetComponent<MoonAirlockExit>();
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.suit_breathing, 1f);
    this.audioSouruce.loop = true;
    this.audioSouruce.clip = SoundsManagerController.sm.moon;
    this.audioSouruce.volume = 1f;
    this.audioSouruce.Play();
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.suit_breathing, 0.75f, AudioReverbPreset.Underwater);
    PlayerController.ssg.setStepType2(StepSoundGenerator.MOON, AudioReverbPreset.Underwater);
  }

  private void Update()
  {
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
