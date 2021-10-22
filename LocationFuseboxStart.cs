// Decompiled with JetBrains decompiler
// Type: LocationFuseboxStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationFuseboxStart : MonoBehaviour
{
  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = -2;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 1f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.source = 10f;
    PlayerController.ssg.setStepType("rubber");
    PlayerController.wc.shadow.scaleFactor = 0.5f;
    PlayerController.wc.shadow.downwards = false;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_6a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_metal_inside, 0.6f);
    if (!GameDataController.gd.getObjective("visited_fusebox"))
    {
      PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "outpost_fuse_briefning_1"));
      PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "outpost_fuse_briefning_2"));
      PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "outpost_fuse_briefning_3"));
      PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "outpost_fuse_briefning_4"));
    }
    GameDataController.gd.setObjective("visited_fusebox", true);
  }

  private void Update()
  {
  }
}
