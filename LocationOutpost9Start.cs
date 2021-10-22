// Decompiled with JetBrains decompiler
// Type: LocationOutpost9Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationOutpost9Start : MonoBehaviour
{
  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 1f / 500f;
    PlayerController.wc.shadowOffsetY = -1;
    PlayerController.wc.shadow.skewFactor = 40f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.9f;
    PlayerController.wc.shadow.source = 60f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.METAL, AudioReverbPreset.Hangar);
    PlayerController.wc.shadow.scaleFactor = 0.65f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    PlayerController.pc.allowDrop = false;
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_6a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.underground_1, 1f);
  }

  private void Update()
  {
  }
}
