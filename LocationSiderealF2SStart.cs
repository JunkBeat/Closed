// Decompiled with JetBrains decompiler
// Type: LocationSiderealF2SStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationSiderealF2SStart : MonoBehaviour
{
  public SpriteRenderer dark;
  public SpriteRenderer light;
  public SpriteRenderer light2;
  public SpriteRenderer shadows;
  public SpriteRenderer pc_on;
  public SpriteRenderer pc_off;

  private void Start()
  {
    if (GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_A") == 50 && GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_B") == 10)
    {
      PlayerController.wc.shadow.fadeRateV = 0.005f;
      PlayerController.wc.shadow.fadeRateH = 0.005f;
      PlayerController.wc.shadowOffsetY = 2;
      PlayerController.wc.shadow.skewFactor = 20f;
      PlayerController.wc.shadow.skewFactor2 = 0.0f;
      PlayerController.wc.shadow.startAlpha = 0.75f;
      PlayerController.wc.shadow.scaleFactor = 0.5f;
      PlayerController.wc.shadow.downwards = true;
      PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
      PlayerController.wc.GetComponent<Animator>().speed = 1f;
      PlayerController.wc.shadow.source = 120f;
      PlayerController.ssg.setStepType2(StepSoundGenerator.NORMAL, AudioReverbPreset.StoneCorridor);
      GameDataController.gd.setObjective("visited_sidereal_f2s", true);
      PlayerController.pc.copySettingsToNPCs();
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_mystery);
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.pc_noise, 0.5f);
      this.light.enabled = true;
      this.light2.enabled = true;
      this.shadows.enabled = true;
      this.pc_on.enabled = true;
      this.pc_off.enabled = false;
      this.dark.enabled = false;
    }
    else
    {
      PlayerController.wc.shadow.fadeRateV = 0.005f;
      PlayerController.wc.shadow.fadeRateH = 0.005f;
      PlayerController.wc.shadowOffsetY = 2;
      PlayerController.wc.shadow.skewFactor = 40f;
      PlayerController.wc.shadow.skewFactor2 = 0.0f;
      PlayerController.wc.shadow.startAlpha = 0.75f;
      PlayerController.wc.shadow.scaleFactor = 0.5f;
      PlayerController.wc.shadow.downwards = true;
      PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
      PlayerController.wc.GetComponent<Animator>().speed = 1f;
      PlayerController.wc.shadow.source = 230f;
      PlayerController.ssg.setStepType2(StepSoundGenerator.NORMAL, AudioReverbPreset.StoneCorridor);
      PlayerController.pc.copySettingsToNPCs();
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_mystery);
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.underground_1, 1f);
      this.light.enabled = false;
      this.light2.enabled = false;
      this.shadows.enabled = false;
      this.pc_on.enabled = false;
      this.pc_off.enabled = true;
      this.dark.enabled = true;
    }
  }

  private void Update()
  {
  }
}
