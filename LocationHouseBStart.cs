// Decompiled with JetBrains decompiler
// Type: LocationHouseBStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationHouseBStart : MonoBehaviour
{
  public SpriteRenderer snow;
  public SpriteRenderer snow2;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 1.2f;
    PlayerController.wc.shadow.startAlpha = 0.25f;
    PlayerController.wc.shadow.source = 140f;
    PlayerController.ssg.setStepType(StepSoundGenerator.DIRT);
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.ssg.setStepType("road");
    PlayerController.pc.copySettingsToNPCs();
    GameDataController.gd.setObjective("visited_house_b", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_4a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 1f);
    if (GameDataController.gd.getObjective("dialogue_ginger_barry_distracted"))
    {
      if (PlayerController.pc.spawnName.Equals("WaypointHouseB2") || PlayerController.pc.spawnName.Equals("WaypointHouseB1"))
        GameObject.Find("Ginger").GetComponent<GingerActionController>().distractBarryEnd();
      else
        GameObject.Find("Ginger").GetComponent<GingerActionController>().distractBarry();
    }
    if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
    {
      this.snow.enabled = true;
      this.snow.color = GameDataController.gd.gameTime >= 600 ? (GameDataController.gd.gameTime >= 650 ? (GameDataController.gd.gameTime >= 700 ? (GameDataController.gd.gameTime >= 750 ? (GameDataController.gd.gameTime >= 800 ? new Color(1f, 1f, 1f, 0.1f) : new Color(1f, 1f, 1f, 0.2f)) : new Color(1f, 1f, 1f, 0.4f)) : new Color(1f, 1f, 1f, 0.6f)) : new Color(1f, 1f, 1f, 0.8f)) : new Color(1f, 1f, 1f, 1f);
      this.snow2.enabled = true;
      this.snow2.color = this.snow.color;
    }
    else
    {
      this.snow.enabled = false;
      this.snow2.enabled = false;
    }
  }

  private void zalosne() => GameObject.Find("Npc2").GetComponent<Npc2Controller>().updateState();

  private void Update()
  {
  }
}
