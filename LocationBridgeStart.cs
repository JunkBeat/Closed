// Decompiled with JetBrains decompiler
// Type: LocationBridgeStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationBridgeStart : MonoBehaviour
{
  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.031f;
    PlayerController.wc.shadow.fadeRateH = 0.005f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 5f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.source = 200f;
    PlayerController.ssg.setStepType("road");
    GameDataController.gd.setObjective("visited_bridge", true);
    if (GameDataController.gd.getObjectiveDetail("map_houseb_revealed") == TravelAgency.LOCATION_STATUS_UNREACHABLE)
      GameDataController.gd.setObjectiveDetail("map_houseb_revealed", TravelAgency.LOCATION_STATUS_REACHABLE);
    if (GameDataController.gd.getObjectiveDetail("map_restaurant_revealed") == TravelAgency.LOCATION_STATUS_UNREACHABLE)
      GameDataController.gd.setObjectiveDetail("map_restaurant_revealed", TravelAgency.LOCATION_STATUS_REACHABLE);
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_1a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 1f);
  }

  private void Update()
  {
    if ((double) PlayerController.wc.currentXY.x > 100.0)
    {
      PlayerController.wc.shadow.source = 200f;
      PlayerController.wc.shadow.fadeRateH = 0.005f;
    }
    else
    {
      PlayerController.wc.shadow.source = 0.0f;
      PlayerController.wc.shadow.fadeRateH = 0.01f;
    }
  }
}
