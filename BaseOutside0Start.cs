// Decompiled with JetBrains decompiler
// Type: BaseOutside0Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class BaseOutside0Start : MonoBehaviour
{
  public SpriteRenderer spider1;
  public SpriteRenderer spider2;
  public SpriteRenderer bugs;
  public SpriteRenderer piorunochron;
  public SpriteRenderer snow;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = -5f;
    PlayerController.wc.shadow.startAlpha = 0.25f;
    PlayerController.wc.shadow.source = 10f;
    PlayerController.ssg.setStepType("dirt");
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    if (!GameDataController.gd.getObjective("visited_barn"))
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_main, false);
    else if ((Object) JukeboxMusic.jb.getCurrentMusic() == (Object) SoundsManagerController.sm.music_explore_2a)
      JukeboxMusic.jb.changeMusic((AudioClip) null, false);
    else
      JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 1f);
    GameDataController.gd.setObjective("visited_baseOutside0", true);
    if (GameDataController.gd.getCurrentDay() != 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
    {
      this.spider1.enabled = true;
      this.spider2.enabled = true;
    }
    else
    {
      this.spider1.enabled = false;
      this.spider2.enabled = false;
    }
    if (GameDataController.gd.getCurrentDay() != 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      this.bugs.enabled = true;
    else
      this.bugs.enabled = false;
    if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
    {
      this.snow.enabled = true;
      this.snow.color = GameDataController.gd.gameTime >= 600 ? (GameDataController.gd.gameTime >= 650 ? (GameDataController.gd.gameTime >= 700 ? (GameDataController.gd.gameTime >= 750 ? (GameDataController.gd.gameTime >= 800 ? new Color(1f, 1f, 1f, 0.1f) : new Color(1f, 1f, 1f, 0.2f)) : new Color(1f, 1f, 1f, 0.4f)) : new Color(1f, 1f, 1f, 0.6f)) : new Color(1f, 1f, 1f, 0.8f)) : new Color(1f, 1f, 1f, 1f);
    }
    else
      this.snow.enabled = false;
    this.piorunochron.enabled = false;
    if (GameDataController.gd.getObjective("lighting_rod_installed"))
      this.piorunochron.enabled = true;
    if (GameDataController.gd.getCurrentDay() != 4 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 1 || GameDataController.gd.getObjective("lighting_rod_installed") && GameDataController.gd.getObjectiveDetail("day3_complete") >= 1)
      return;
    this.piorunochron.enabled = false;
  }

  private void Update()
  {
  }
}
