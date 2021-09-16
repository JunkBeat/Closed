// Decompiled with JetBrains decompiler
// Type: LocationSiderealF2BStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationSiderealF2BStart : MonoBehaviour
{
  public SpriteRenderer p1a;
  public SpriteRenderer p2a;
  public SpriteRenderer p3a;
  public SpriteRenderer p4a;
  public SpriteRenderer p1b;
  public SpriteRenderer p2b;
  public SpriteRenderer p3b;
  public SpriteRenderer p4b;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.005f;
    PlayerController.wc.shadow.fadeRateH = 0.005f;
    PlayerController.wc.shadowOffsetY = 2;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.scaleFactor = 1f;
    PlayerController.wc.shadow.downwards = false;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 120f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.NORMAL, AudioReverbPreset.StoneCorridor);
    PlayerController.pc.copySettingsToNPCs();
    GameDataController.gd.setObjective("visited_sidereal_f2b", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_mystery);
    if (GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_A") == 50 && GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_B") == 10)
    {
      this.p1a.enabled = false;
      this.p2a.enabled = false;
      this.p3a.enabled = false;
      this.p4a.enabled = false;
      this.p1b.enabled = true;
      this.p2b.enabled = true;
      this.p3b.enabled = true;
      this.p4b.enabled = true;
      PlayerController.wc.shadow.fadeRateV = 0.005f;
      PlayerController.wc.shadow.fadeRateH = 0.005f;
      PlayerController.wc.shadowOffsetY = 2;
      PlayerController.wc.shadow.skewFactor = 20f;
      PlayerController.wc.shadow.skewFactor2 = 0.0f;
      PlayerController.wc.shadow.startAlpha = 0.5f;
      PlayerController.wc.shadow.scaleFactor = 0.5f;
      PlayerController.wc.shadow.downwards = true;
      PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
      PlayerController.wc.GetComponent<Animator>().speed = 1f;
      PlayerController.wc.shadow.source = 120f;
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.buzz, 0.75f);
    }
    else
    {
      this.p1a.enabled = true;
      this.p2a.enabled = true;
      this.p3a.enabled = true;
      this.p4a.enabled = true;
      this.p1b.enabled = false;
      this.p2b.enabled = false;
      this.p3b.enabled = false;
      this.p4b.enabled = false;
      PlayerController.wc.shadow.fadeRateV = 0.005f;
      PlayerController.wc.shadow.fadeRateH = 0.005f;
      PlayerController.wc.shadowOffsetY = 2;
      PlayerController.wc.shadow.skewFactor = 0.0f;
      PlayerController.wc.shadow.skewFactor2 = 0.0f;
      PlayerController.wc.shadow.scaleFactor = 1f;
      PlayerController.wc.shadow.downwards = false;
      PlayerController.wc.shadow.source = 120f;
      PlayerController.wc.shadow.startAlpha = 0.5f;
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.underground_1, 1f);
    }
  }

  private void Update()
  {
    PlayerController.wc.shadow.scaleFactor = (float) (1.0 * ((double) Mathf.Abs(PlayerController.wc.currentXY.y - 35f) / 35.0));
    if ((double) PlayerController.wc.shadow.scaleFactor < 0.100000001490116)
      PlayerController.wc.shadow.scaleFactor = 0.1f;
    if ((double) PlayerController.wc.currentXY.y < 35.0)
      PlayerController.wc.shadow.downwards = true;
    else
      PlayerController.wc.shadow.downwards = false;
  }
}
