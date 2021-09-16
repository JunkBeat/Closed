// Decompiled with JetBrains decompiler
// Type: LocationGasstationRoom2Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationGasstationRoom2Start : MonoBehaviour
{
  public SpriteRenderer thug;
  public SpriteRenderer sargeA;
  public SpriteRenderer sargeB;
  public SpriteRenderer sargeC;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.004f;
    PlayerController.wc.shadow.fadeRateH = 0.004f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 20f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 120f;
    PlayerController.ssg.setStepType("normal");
    GameDataController.gd.setObjective("visited_gasstationRoom2", true);
    PlayerController.pc.copySettingsToNPCs();
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 0.25f);
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
    {
      GameObject.Find("Location").transform.Find("plane00").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Location").transform.Find("plane01").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Location").transform.Find("plane00_spiders").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Location").transform.Find("plane01_spiders").GetComponent<SpriteRenderer>().enabled = true;
    }
    else
    {
      GameObject.Find("Location").transform.Find("plane00").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Location").transform.Find("plane01").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Location").transform.Find("plane00_spiders").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Location").transform.Find("plane01_spiders").GetComponent<SpriteRenderer>().enabled = false;
    }
    if (GameDataController.gd.getCurrentDay() == 1 && !GameDataController.gd.getObjective("gasstation_spider_shot") && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_scare_loop, minTime: 1f, maxTime: 3f);
    else if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getObjective("sidereal_base_located") && !GameDataController.gd.getObjective("gasstation_sarge_reason"))
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_6a);
    else if (GameDataController.gd.getObjective("gasstation_sarge_shot"))
      JukeboxMusic.jb.changeMusic((AudioClip) null);
    else
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_3a);
    this.sargeA.enabled = false;
    this.sargeB.enabled = false;
    this.sargeC.enabled = false;
    if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && !GameDataController.gd.getObjective("thugs_gasstation_talk") && GameDataController.gd.getObjective("sidereal_base_located"))
    {
      this.thug.enabled = true;
      this.sargeA.enabled = true;
    }
    else
    {
      this.thug.enabled = false;
      if (GameDataController.gd.getCurrentDay() != 3 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 0 || !GameDataController.gd.getObjective("sidereal_base_located"))
      {
        this.sargeA.enabled = false;
        this.sargeB.enabled = false;
        this.sargeC.enabled = false;
      }
      else
      {
        if (GameDataController.gd.getObjective("gasstation_sarge_shot"))
          this.sargeC.enabled = true;
        else if (GameDataController.gd.getObjective("gasstation_sarge_canister_filled"))
          this.sargeA.enabled = true;
        else
          this.sargeB.enabled = true;
        if (!GameDataController.gd.getObjective("gasstation_sarge_shot") && GameDataController.gd.getObjective("gasstation_sarge_convinced"))
        {
          this.sargeA.enabled = false;
          this.sargeB.enabled = false;
          this.sargeC.enabled = false;
        }
      }
    }
    if (GameDataController.gd.getCurrentDay() <= 3)
      return;
    this.sargeA.enabled = false;
    this.sargeB.enabled = false;
    this.sargeC.enabled = false;
  }

  private void Update()
  {
  }
}
