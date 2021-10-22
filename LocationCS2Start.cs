// Decompiled with JetBrains decompiler
// Type: LocationCS2Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationCS2Start : MonoBehaviour
{
  public Animator thug;
  public Animator crow;
  public bool shootArea;
  public bool playerShot;
  public ObjectActionController exitcs1;
  public ObjectActionController exitcs3;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.01f;
    PlayerController.wc.shadow.fadeRateH = 1f / 1000f;
    PlayerController.wc.shadowOffsetY = 2;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 10f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.scaleFactor = 0.4f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 240f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.ROAD, AudioReverbPreset.Off);
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_metal, 1f);
    GameDataController.gd.setObjective("visited_cs_2", true);
    this.shootArea = false;
    this.Invoke("shootOrNot", 0.25f);
    if (GameDataController.gd.getObjective("cs_crow_away"))
      this.crow.Play("crow_empty");
    else
      this.crow.Play("crow_peck");
    if (!GameDataController.gd.getObjective("cs_thug_shot") && GameDataController.gd.getObjective("cs_arrive_from_inside") && !GameDataController.gd.getObjective("cs_safe"))
      this.thug.Play("thug_reload");
    else if (!GameDataController.gd.getObjective("cs_thug_shot") && !GameDataController.gd.getObjective("cs_safe"))
      this.thug.Play("thug_watch");
    else
      this.thug.gameObject.GetComponent<CSThugSprite>().hide();
    if (GameDataController.gd.getObjective("cs_thug_shot") || GameDataController.gd.getCurrentDay() != 3 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 0)
    {
      this.exitcs1.doubleClickCondition = "visited_cs_1";
      this.exitcs3.doubleClickCondition = "visited_cs_3";
    }
    else if ((double) PlayerController.wc.currentXY.x > 120.0)
    {
      this.exitcs1.doubleClickCondition = string.Empty;
      this.exitcs3.doubleClickCondition = "visited_cs_3";
    }
    else
    {
      this.exitcs1.doubleClickCondition = "visited_cs_1";
      this.exitcs3.doubleClickCondition = string.Empty;
    }
  }

  private void shootOrNot()
  {
    MonoBehaviour.print((object) "Shoot or not");
    if (GameDataController.gd.getObjective("cs_safe"))
      return;
    if (this.shootArea && !this.playerShot && !GameDataController.gd.getObjective("cs_guard_distracted") && !GameDataController.gd.getObjective("cs_arrive_from_inside") && !GameDataController.gd.getObjective("cs_thug_shot"))
    {
      PlayerController.wc.fullStop(true);
      PlayerController.pc.setBusy(true);
      PlayerController.wc.forceAnimation("surprised_ne", true);
      PlayerController.pc.interruptDialogueProbablyToKillPlayer();
      this.thug.Play("thug_shoot");
      this.shootArea = false;
      this.playerShot = true;
    }
    this.Invoke(nameof (shootOrNot), 0.5f);
  }

  private void Update()
  {
  }
}
