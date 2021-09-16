// Decompiled with JetBrains decompiler
// Type: BaseOutside3Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BaseOutside3Start : MonoBehaviour
{
  public SpriteRenderer snow;
  public SpriteRenderer snowman;

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
    GameDataController.gd.setObjective("visited_baseOutside3", true);
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    if (!GameDataController.gd.getObjective("visited_barn"))
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_main, false);
    else
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_2a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 1f);
    this.snowman.enabled = false;
    if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
    {
      this.snow.enabled = true;
      this.snow.color = GameDataController.gd.gameTime >= 600 ? (GameDataController.gd.gameTime >= 650 ? (GameDataController.gd.gameTime >= 700 ? (GameDataController.gd.gameTime >= 750 ? (GameDataController.gd.gameTime >= 800 ? new Color(1f, 1f, 1f, 0.1f) : new Color(1f, 1f, 1f, 0.2f)) : new Color(1f, 1f, 1f, 0.4f)) : new Color(1f, 1f, 1f, 0.6f)) : new Color(1f, 1f, 1f, 0.8f)) : new Color(1f, 1f, 1f, 1f);
      if (!GameDataController.gd.getObjective("npc3_alive") || !GameDataController.gd.getObjective("d2_cold_cody"))
        return;
      this.snowman.enabled = true;
      GameDataController.Achievement("S_SNOWMAN");
    }
    else
      this.snow.enabled = false;
  }

  private void Update()
  {
  }
}
