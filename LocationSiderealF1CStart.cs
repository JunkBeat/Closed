// Decompiled with JetBrains decompiler
// Type: LocationSiderealF1CStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationSiderealF1CStart : MonoBehaviour
{
  public SpriteRenderer red;
  public SpriteRenderer red2;
  public SpriteRenderer black;
  public PolygonCollider2D darkness;
  public PolygonCollider2D pipeobs;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateH = 0.005f;
    PlayerController.wc.shadowOffsetY = 2;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.scaleFactor = 0.5f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    if (GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_A") != 15 || GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_B") != 40)
    {
      this.red.enabled = false;
      this.red2.enabled = false;
      this.black.enabled = true;
      PlayerController.wc.shadow.source = 130f;
      PlayerController.wc.shadow.skewFactor = 40f;
      PlayerController.wc.shadow.fadeRateV = 0.01f;
      this.darkness.enabled = true;
    }
    else
    {
      this.red.enabled = true;
      this.red2.enabled = true;
      this.black.enabled = false;
      PlayerController.wc.shadow.source = 50f;
      PlayerController.wc.shadow.skewFactor = 30f;
      PlayerController.wc.shadow.fadeRateV = 1f / 1000f;
      this.darkness.enabled = false;
    }
    GameDataController.gd.setObjective("visited_sidereal_f1c", true);
    PlayerController.ssg.setStepType2(StepSoundGenerator.NORMAL, AudioReverbPreset.StoneCorridor);
    PlayerController.pc.copySettingsToNPCs();
    if (!GameDataController.gd.getObjective("sidereal_barry_pipe_moved"))
      this.pipeobs.enabled = true;
    else
      this.pipeobs.enabled = false;
    GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_mystery);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.underground_1, 1f);
  }

  private void Update()
  {
  }
}
