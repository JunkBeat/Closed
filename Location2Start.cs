// Decompiled with JetBrains decompiler
// Type: Location2Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Location2Start : MonoBehaviour
{
  public KitchenOven ko;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.005f;
    PlayerController.wc.shadow.fadeRateH = 0.005f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 40f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.25f;
    PlayerController.wc.shadow.source = 16f;
    PlayerController.ssg.setStepType("normal");
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    GameDataController.gd.setObjective("visited_location2", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_5a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 0.25f);
    if (!GameDataController.gd.getObjective("kitchen_oven_open") || !GameDataController.gd.getObjective("barn_pump_started") || GameDataController.gd.getObjectiveDetail("barn_pump_started") != 1)
      return;
    this.ko.lightAlfa = 1f;
    this.ko.GetComponent<SpriteRenderer>().enabled = true;
  }

  private void Update()
  {
  }
}
