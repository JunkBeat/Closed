// Decompiled with JetBrains decompiler
// Type: LoctionAttic1Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LoctionAttic1Start : MonoBehaviour
{
  public SpriteRenderer destroyed;
  public SpriteRenderer holes;
  public SpriteRenderer rays;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.1f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 5f;
    PlayerController.wc.shadow.startAlpha = 0.75f;
    PlayerController.wc.shadow.source = 240f;
    PlayerController.ssg.setStepType(StepSoundGenerator.WOOD);
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    GameDataController.gd.setObjective("visited_attic1", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_5a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 0.5f);
    this.backgroundCheck();
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && (!GameDataController.gd.getObjective("lighting_rod_installed") || GameDataController.gd.getObjectiveDetail("day3_complete") < 1))
    {
      this.destroyed.enabled = true;
      this.holes.enabled = false;
      this.rays.enabled = false;
    }
    else if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
    {
      this.holes.enabled = true;
      this.rays.enabled = true;
    }
    else
    {
      this.holes.enabled = false;
      this.rays.enabled = false;
    }
  }

  private void Update()
  {
  }

  public void backgroundCheck()
  {
    if (!GameDataController.gd.getObjective("attic_hatch_open"))
    {
      GameObject.Find("Location").transform.Find("plane00a").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Location").transform.Find("plane00b").GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      GameObject.Find("Location").transform.Find("plane00a").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Location").transform.Find("plane00b").GetComponent<SpriteRenderer>().enabled = true;
    }
  }
}
