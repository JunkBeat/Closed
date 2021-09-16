// Decompiled with JetBrains decompiler
// Type: LocationMoonIntro0Ship
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationMoonIntro0Ship : MonoBehaviour
{
  private void Start()
  {
  }

  private void Update()
  {
  }

  public void goToNextScene()
  {
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("MoonIntro", WalkController.Direction.N, tSpeed: 0.1f);
  }
}
