// Decompiled with JetBrains decompiler
// Type: LocationCSCraneStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationCSCraneStart : MonoBehaviour
{
  public SpriteRenderer craneContrBack;
  public CraneLeverController l1;
  public CraneLeverController l2;
  public CraneLeverController l3;
  public CraneThing craneThing;
  public bool firstTime;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.01f;
    PlayerController.wc.shadow.fadeRateH = 1f / 1000f;
    PlayerController.wc.shadowOffsetY = 2;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 10f;
    PlayerController.wc.shadow.startAlpha = 0.0f;
    PlayerController.wc.shadow.scaleFactor = 0.3f;
    PlayerController.wc.shadow.downwards = false;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 240f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.METAL, AudioReverbPreset.Arena);
    this.craneThing.updateState();
    this.craneThing.currentX = this.craneThing.targetX;
    this.craneThing.currentY = this.craneThing.targetY;
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_metal, 1f);
    this.craneContrBack.enabled = false;
    this.l1.hideLever();
    this.l2.hideLever();
    this.l3.hideLever();
    this.firstTime = true;
  }

  private void zzz()
  {
    this.l1.hideLever();
    this.l2.hideLever();
    this.l3.hideLever();
  }

  private void Update()
  {
    if (!this.craneContrBack.enabled && !this.firstTime || (double) PlayerController.wc.currentXY.x >= 120.0 && !this.firstTime)
      return;
    this.firstTime = false;
    this.craneContrBack.enabled = false;
    this.l1.hideLever();
    this.l2.hideLever();
    this.l3.hideLever();
  }
}
