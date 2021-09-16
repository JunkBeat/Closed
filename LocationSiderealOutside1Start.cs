// Decompiled with JetBrains decompiler
// Type: LocationSiderealOutside1Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationSiderealOutside1Start : MonoBehaviour
{
  public SpriteRenderer plane1;
  public SpriteRenderer plane2;

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
    PlayerController.ssg.setStepType2(StepSoundGenerator.ROAD, AudioReverbPreset.Off);
    PlayerController.pc.copySettingsToNPCs();
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 1f);
    if (GameDataController.gd.getObjective("barry_warned"))
      GameDataController.gd.setObjective("npc2_joined", true);
    if (GameDataController.gd.getObjective("cody_warned"))
      GameDataController.gd.setObjective("npc3_joined", true);
    if (GameDataController.gd.getCurrentDay() == 4)
      GameDataController.gd.setObjectiveDetail("map_outpost_revealed", TravelAgency.LOCATION_STATUS_REACHABLE);
    if (!GameDataController.gd.getObjective("visited_sidereal_outside_1"))
    {
      if (GameDataController.gd.getObjectiveDetail("visited_sidereal_outside_1") == 0)
      {
        GameDataController.gd.setObjectiveDetail("visited_sidereal_outside_1", 1);
        PlayerController.pc.spawnName = "InfoExit";
        GameDataController.gd.previousLocation = SceneManager.GetActiveScene().name;
        GameDataController.gd.previousX = (int) PlayerController.wc.currentXY.x;
        GameDataController.gd.previousY = (int) PlayerController.wc.currentXY.y;
        CurtainController.cc.fadeOut("Day3Cutscene");
      }
      else
      {
        PlayerController.pc.clickedAlreadyForSomething = false;
        PlayerController.pc.clickedSomething = false;
        PlayerController.pc.setBusy(true);
        this.Invoke("talkafterawhile", 1f);
      }
    }
    if (GameDataController.gd.getObjective("sidereal_roof_collapsed"))
    {
      this.plane1.enabled = false;
      this.plane2.enabled = true;
    }
    else
    {
      this.plane1.enabled = true;
      this.plane2.enabled = false;
    }
  }

  private void talkafterawhile()
  {
    GameDataController.gd.setObjective("visited_sidereal_outside_1", true);
    GameObject.Find("Ginger").GetComponent<GingerActionController>().npcClickAction(string.Empty);
  }

  private void Update()
  {
  }
}
