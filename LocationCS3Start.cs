// Decompiled with JetBrains decompiler
// Type: LocationCS3Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationCS3Start : MonoBehaviour
{
  public SpriteRenderer tlo1;
  public SpriteRenderer tlo2;
  public SpriteRenderer sciana1;
  public SpriteRenderer sciana2;
  public SpriteRenderer dzwig;
  public PolygonCollider2D areaThugs;
  public PolygonCollider2D areaRain1;
  public PolygonCollider2D areaRain2;
  public PolygonCollider2D areaRainFull;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.01f;
    PlayerController.wc.shadow.fadeRateH = 1f / 1000f;
    PlayerController.wc.shadowOffsetY = 2;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 20f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.scaleFactor = 0.4f;
    PlayerController.wc.shadow.downwards = false;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 240f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.DIRT, AudioReverbPreset.Off);
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_metal, 1f);
    GameDataController.gd.setObjective("visited_cs_3", true);
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
    {
      GameDataController.gd.setObjective("cs_safe", true);
      this.sciana1.enabled = false;
      this.sciana2.enabled = false;
      this.dzwig.enabled = true;
      this.tlo1.enabled = false;
      this.tlo2.enabled = true;
      if (GameDataController.gd.getObjective("cs_pack_lifted"))
      {
        this.areaRainFull.enabled = true;
        this.areaRain1.enabled = false;
        this.areaRain2.enabled = false;
        this.areaThugs.enabled = false;
      }
      else if (GameDataController.gd.getObjective("cs_rain_enter_left"))
      {
        this.areaRainFull.enabled = false;
        this.areaRain1.enabled = true;
        this.areaRain2.enabled = false;
        this.areaThugs.enabled = false;
      }
      else
      {
        this.areaRainFull.enabled = false;
        this.areaRain1.enabled = false;
        this.areaRain2.enabled = true;
        this.areaThugs.enabled = false;
      }
    }
    else
    {
      this.sciana1.enabled = true;
      this.sciana2.enabled = true;
      this.dzwig.enabled = false;
      this.tlo1.enabled = true;
      this.tlo2.enabled = false;
      this.areaRainFull.enabled = false;
      this.areaRain1.enabled = false;
      this.areaRain2.enabled = false;
      this.areaThugs.enabled = true;
    }
    GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
    if (!GameDataController.gd.getObjective("cs_safe"))
      GameObject.Find("Smoker").GetComponent<ParticleGenerator>().started = true;
    else
      GameObject.Find("Smoker").GetComponent<ParticleGenerator>().started = false;
  }

  private void Update()
  {
    Vector3 vector3 = new Vector3(PlayerController.wc.currentXY.x, 0.0f, PlayerController.pc.transform.position.z);
    if (GameDataController.gd.getObjective("cs_safe") || (double) PlayerController.wc.currentXY.x <= 145.0)
      return;
    PlayerController.wc.currentXY.x = 144f;
    PlayerController.wc.fullStop(true);
    PlayerController.wc.forceAnimation("stand_e");
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.actions, "cs_dont_walk_there")
    });
  }
}
