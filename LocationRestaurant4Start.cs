// Decompiled with JetBrains decompiler
// Type: LocationRestaurant4Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationRestaurant4Start : MonoBehaviour
{
  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0035f;
    PlayerController.wc.shadowOffsetY = -4;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = -15f;
    PlayerController.wc.shadow.startAlpha = 0.75f;
    PlayerController.wc.shadow.source = 0.0f;
    PlayerController.ssg.setStepType(StepSoundGenerator.NORMAL);
    PlayerController.wc.shadow.scaleFactor = 0.4f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    GameDataController.gd.setObjective("visited_restaurant_inside", true);
    GameDataController.gd.setObjective("visited_restaurant_kitchen", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_3a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_flag, 0.25f);
    if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
      return;
    ItemsManager.im.getItem("gasheater_empty").dataRef.droppedLocation = "nowhere";
    ItemsManager.im.removeGroundItem("gasheater_empty");
  }

  private void Update()
  {
  }
}
