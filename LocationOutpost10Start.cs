// Decompiled with JetBrains decompiler
// Type: LocationOutpost10Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationOutpost10Start : MonoBehaviour
{
  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 3f / 500f;
    PlayerController.wc.shadowOffsetY = -2;
    PlayerController.wc.shadow.skewFactor = 20f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.source = 160f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.NORMAL, AudioReverbPreset.Hallway);
    PlayerController.wc.shadow.scaleFactor = 0.25f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    GameDataController.gd.setObjective("visited_outpost10", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_6a);
  }

  private void Update()
  {
    PlayerController.wc.shadow.source = (double) PlayerController.wc.currentXY.x <= 120.0 ? 40f : 200f;
    PlayerController.wc.shadow.scaleFactor = (float) (0.100000001490116 + (double) Mathf.Abs(PlayerController.wc.currentXY.y - 25f) / 60.0);
    PlayerController.wc.shadow.downwards = (double) PlayerController.wc.currentXY.y <= 25.0;
    PlayerController.pc.copySettingsToNPCs();
  }
}
