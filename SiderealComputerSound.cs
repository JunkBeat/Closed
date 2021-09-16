// Decompiled with JetBrains decompiler
// Type: SiderealComputerSound
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class SiderealComputerSound : MonoBehaviour
{
  public AudioSource aS;
  public List<AudioClip> sounds;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void beep()
  {
    AudioClip sound = this.sounds[0];
    int num = Random.Range(this.sounds.Count / 2, this.sounds.Count);
    this.sounds.RemoveAt(0);
    this.sounds.Insert(num - 1, sound);
    this.aS.PlayOneShot(sound, 1f);
  }
}
