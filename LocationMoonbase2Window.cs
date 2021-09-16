// Decompiled with JetBrains decompiler
// Type: LocationMoonbase2Window
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationMoonbase2Window : MonoBehaviour
{
  private void Start()
  {
    if (GameDataController.gd.getObjective("moon_window_cracked"))
      this.GetComponent<Animator>().Play("window_cracked");
    else
      this.GetComponent<Animator>().Play("window_normal");
  }

  private void Update()
  {
  }

  public void crack() => this.GetComponent<Animator>().Play("window_crack");

  public void sound1() => this.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.glass_crack_1);

  public void sound2() => this.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.glass_crack_2);
}
