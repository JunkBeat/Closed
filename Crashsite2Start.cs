// Decompiled with JetBrains decompiler
// Type: Crashsite2Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class Crashsite2Start : MonoBehaviour
{
  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 5f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 0.0f;
    PlayerController.ssg.setStepType("road");
    GameDataController.gd.setObjective("visited_crashsite2", true);
    GameDataController.gd.setObjective("bridge_westside", false);
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_1a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_metal, 0.5f);
  }

  private void Update()
  {
  }
}
