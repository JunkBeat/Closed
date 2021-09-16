// Decompiled with JetBrains decompiler
// Type: LocationSiderealRoofStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationSiderealRoofStart : MonoBehaviour
{
  public LetterFall lf;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = -3f;
    PlayerController.wc.shadow.startAlpha = 0.25f;
    PlayerController.wc.shadow.source = 140f;
    PlayerController.ssg.setStepType(StepSoundGenerator.ROAD);
    PlayerController.wc.shadow.scaleFactor = 0.6f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    PlayerController.pc.allowDrop = false;
    GameDataController.gd.setObjective("visited_sidereal_roof", true);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_3, 1f);
    if (GameDataController.gd.getObjective("barry_warned"))
      GameDataController.gd.setObjective("npc2_joined", false);
    if (GameDataController.gd.getObjective("cody_warned"))
      GameDataController.gd.setObjective("npc3_joined", false);
    this.lf.hideAndWait();
    this.setWalkablePath();
    if (GameDataController.gd.getObjective("sidereal_roof_collapsed"))
    {
      this.lf.quickFall();
      if (GameDataController.gd.getObjective("sidereal_roof_wait_for_rescue"))
        JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_action_loop, minTime: 0.0f, maxTime: 0.0f);
      else
        JukeboxMusic.jb.changeMusic((AudioClip) null);
    }
    else
      JukeboxMusic.jb.changeMusic((AudioClip) null);
  }

  public void setWalkablePath()
  {
    if (!GameDataController.gd.getObjective("sidereal_roof_collapsed"))
    {
      GameObject.Find("Location").GetComponent<PolygonCollider2D>().enabled = true;
      GameObject.Find("LocationCollapsed").GetComponent<PolygonCollider2D>().enabled = false;
      GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
    }
    else
    {
      GameObject.Find("Location").GetComponent<PolygonCollider2D>().enabled = false;
      GameObject.Find("LocationCollapsed").GetComponent<PolygonCollider2D>().enabled = true;
      GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
    }
  }

  private void Update()
  {
  }
}
