// Decompiled with JetBrains decompiler
// Type: LocationBaseBathroomStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationBaseBathroomStart : MonoBehaviour
{
  public Sprite ded;
  public SpriteRenderer holes;
  public SpriteRenderer rays;
  public SpriteRenderer rays2;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.004f;
    PlayerController.wc.shadow.fadeRateH = 0.004f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 40f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.source = 140f;
    PlayerController.ssg.setStepType2("normal", AudioReverbPreset.Bathroom);
    GameDataController.gd.setObjective("visited_baseBathroom", true);
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_5a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 0.25f);
    GameObject.Find("thug").GetComponent<SpriteRenderer>().enabled = false;
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjective("thug_to_kill_bathroom"))
    {
      GameObject.Find("thug").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("thug").GetComponent<Animator>().enabled = true;
      this.startTalk();
    }
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjective("thug_killed_bathroom"))
    {
      GameObject.Find("thug").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("thug").GetComponent<Animator>().enabled = false;
      GameObject.Find("thug").GetComponent<SpriteRenderer>().sprite = this.ded;
    }
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
    {
      this.holes.enabled = true;
      this.rays.enabled = true;
      this.rays2.enabled = true;
    }
    else
    {
      this.holes.enabled = false;
      this.rays.enabled = false;
      this.rays2.enabled = false;
    }
  }

  public void startTalk()
  {
    PlayerController.wc.forceAnimation("stand_se", true);
    GameObject.Find("Ginger").GetComponent<GingerActionController>().npcClickAction(string.Empty);
  }

  private void Update()
  {
  }
}
