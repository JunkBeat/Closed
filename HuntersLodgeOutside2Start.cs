// Decompiled with JetBrains decompiler
// Type: HuntersLodgeOutside2Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class HuntersLodgeOutside2Start : MonoBehaviour
{
  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.03f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 2;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = -20f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.scaleFactor = 0.5f;
    PlayerController.wc.shadow.downwards = false;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 0.0f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.GRASS, AudioReverbPreset.Forest);
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_4a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_forest, 0.9f);
    if (!GameDataController.gd.getObjective("visited_hunters_lodge_outside_2") && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "hunters_lodge_smell"));
    GameDataController.gd.setObjective("visited_hunters_lodge_outside_2", true);
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 || GameDataController.gd.getCurrentDay() != 3 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 0)
      return;
    if (ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation == "nowhere")
    {
      ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation = "HuntersLodgeOutside2";
      ItemsManager.im.getItem("bear_trap_1").dataRef.locX = 180;
      ItemsManager.im.getItem("bear_trap_1").dataRef.locY = 50;
    }
    if (ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation == "nowhere")
    {
      ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation = "HuntersLodgeOutside2";
      ItemsManager.im.getItem("bear_trap_2").dataRef.locX = 185;
      ItemsManager.im.getItem("bear_trap_2").dataRef.locY = 20;
    }
    ItemsManager.im.initGroundAndInv();
  }

  private void Update()
  {
  }
}
