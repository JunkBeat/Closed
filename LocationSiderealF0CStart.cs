// Decompiled with JetBrains decompiler
// Type: LocationSiderealF0CStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationSiderealF0CStart : MonoBehaviour
{
  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.01f;
    PlayerController.wc.shadow.fadeRateH = 1f / 400f;
    PlayerController.wc.shadowOffsetY = 2;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = -20f;
    PlayerController.wc.shadow.startAlpha = 0.56f;
    PlayerController.wc.shadow.scaleFactor = 0.5f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 0.0f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.NORMAL, AudioReverbPreset.Cave);
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.underground_1, 1f);
    GameDataController.gd.setObjective("visited_sidereal_f0c", true);
  }

  private void Update()
  {
  }
}
