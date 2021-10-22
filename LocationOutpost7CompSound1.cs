// Decompiled with JetBrains decompiler
// Type: LocationOutpost7CompSound1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationOutpost7CompSound1 : MonoBehaviour
{
  private List<AudioClip> dzwieki;
  private AudioSource aS;

  private void Start()
  {
    this.dzwieki = new List<AudioClip>();
    this.dzwieki.Add(SoundsManagerController.sm.hdd1);
    this.dzwieki.Add(SoundsManagerController.sm.hdd2);
    this.dzwieki.Add(SoundsManagerController.sm.hdd3);
    this.dzwieki.Add(SoundsManagerController.sm.hdd4);
    this.dzwieki.Add(SoundsManagerController.sm.hdd5);
    this.dzwieki.Add(SoundsManagerController.sm.hdd6);
    this.dzwieki.Add(SoundsManagerController.sm.hdd7);
    this.dzwieki.Add(SoundsManagerController.sm.comp_beeps6);
    this.dzwieki.Add(SoundsManagerController.sm.comp_beeps5);
    this.dzwieki.Add(SoundsManagerController.sm.comp_beeps4);
    this.dzwieki.Add(SoundsManagerController.sm.comp_beeps3);
    this.dzwieki.Add(SoundsManagerController.sm.comp_beeps2);
    this.dzwieki.Add(SoundsManagerController.sm.comp_beeps1);
    this.aS = this.GetComponent<AudioSource>();
    this.Invoke("makeDatSound", Random.Range(2f, 8f));
    this.GetComponent<AudioReverbFilter>().reverbPreset = AudioReverbPreset.Bathroom;
  }

  private void Update()
  {
  }

  private void makeDatSound()
  {
    this.aS.PlayOneShot(this.dzwieki[Random.Range(0, this.dzwieki.Count)]);
    this.aS.pitch = Random.Range(0.8f, 1.25f);
    this.Invoke(nameof (makeDatSound), Random.Range(2f, 8f));
  }
}
