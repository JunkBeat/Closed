// Decompiled with JetBrains decompiler
// Type: LocationOutpost8Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationOutpost8Start : MonoBehaviour
{
  public SpriteRenderer sr1;
  public SpriteRenderer sr2;
  public SpriteRenderer sr3;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 1f / 500f;
    PlayerController.wc.shadowOffsetY = -1;
    PlayerController.wc.shadow.skewFactor = 40f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.9f;
    PlayerController.wc.shadow.source = 60f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.METAL, AudioReverbPreset.Hangar);
    PlayerController.wc.shadow.scaleFactor = 0.65f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    GameDataController.gd.setObjective("visited_outpost8", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_6a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.underground_1, 1f);
    if (GameDataController.gd.getObjective("outpost_hatch_open"))
    {
      this.sr1.enabled = true;
      this.sr2.enabled = true;
      this.sr3.enabled = true;
    }
    else
    {
      this.sr1.enabled = false;
      this.sr2.enabled = false;
      this.sr3.enabled = false;
    }
  }

  private void Update()
  {
  }
}
