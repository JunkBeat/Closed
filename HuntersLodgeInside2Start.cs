// Decompiled with JetBrains decompiler
// Type: HuntersLodgeInside2Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HuntersLodgeInside2Start : MonoBehaviour
{
  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.04f;
    PlayerController.wc.shadow.fadeRateH = 1f / 1000f;
    PlayerController.wc.shadowOffsetY = 2;
    PlayerController.wc.shadow.skewFactor = 30f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.6f;
    PlayerController.wc.shadow.scaleFactor = 0.5f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 160f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.WOOD, AudioReverbPreset.Livingroom);
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_4a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_forest, 0.5f);
    GameDataController.gd.setObjective("visited_hunters_lodge_2", true);
  }

  private void Update()
  {
    if ((double) PlayerController.wc.currentXY.x > 120.0)
    {
      PlayerController.wc.shadow.skewFactor = 30f;
      PlayerController.wc.shadow.skewFactor2 = 0.0f;
      PlayerController.wc.shadow.source = 160f;
    }
    else
    {
      PlayerController.wc.shadow.skewFactor = 0.0f;
      PlayerController.wc.shadow.skewFactor2 = -30f;
      PlayerController.wc.shadow.source = -10f;
    }
  }
}
