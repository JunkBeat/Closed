// Decompiled with JetBrains decompiler
// Type: OutpostRadarBeep
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class OutpostRadarBeep : MonoBehaviour
{
  private AudioSource aS;
  private AudioClip radar;

  private void Start()
  {
    this.radar = SoundsManagerController.sm.radarbeep;
    this.aS = this.GetComponent<AudioSource>();
  }

  public void beep() => this.aS.PlayOneShot(this.radar);

  private void Update()
  {
  }
}
