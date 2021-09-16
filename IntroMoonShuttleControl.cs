// Decompiled with JetBrains decompiler
// Type: IntroMoonShuttleControl
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class IntroMoonShuttleControl : MonoBehaviour
{
  public ParticleGenerator d1;
  public ParticleGenerator d2;
  public ParticleGenerator d3;
  public ParticleGenerator d4;
  public ParticleGenerator d5;
  public ParticleGenerator d6;
  public AudioSource aS;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void enableBackDust()
  {
    this.d1.started = true;
    this.d2.started = true;
  }

  public void enableBackDust2()
  {
    this.d5.started = true;
    this.d6.started = true;
  }

  public void enablefrontDust()
  {
    this.d3.started = true;
    this.d4.started = true;
  }

  public void disableBackDust()
  {
    this.d1.started = false;
    this.d2.started = false;
  }

  public void disablefrontDust() => this.d3.started = false;

  public void startSound() => this.aS.PlayOneShot(SoundsManagerController.sm.ship_drag);

  public void startSound2() => this.aS.PlayOneShot(SoundsManagerController.sm.ship_drag2);

  public void soundBum() => this.aS.PlayOneShot(SoundsManagerController.sm.heli_crash, 0.5f);

  public void soundPisk() => this.aS.PlayOneShot(SoundsManagerController.sm.pisk, 0.25f);
}
