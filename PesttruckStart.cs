﻿// Decompiled with JetBrains decompiler
// Type: PesttruckStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PesttruckStart : MonoBehaviour
{
  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 1f / 1000f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = -20f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 0.0f;
    PlayerController.ssg.setStepType("normal");
    GameDataController.gd.setObjective("visited_pestTruck", true);
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_6a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_metal_inside, 1f);
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
    {
      GameObject.Find("Location").transform.Find("plane_bugs").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Location").transform.Find("plane_gas").GetComponent<SpriteRenderer>().enabled = false;
    }
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
    {
      GameObject.Find("Location").transform.Find("plane_bugs").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Location").transform.Find("plane_gas").GetComponent<SpriteRenderer>().enabled = true;
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 2)
        return;
      GameObject.Find("Location").transform.Find("plane_bugs").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Location").transform.Find("plane_gas").GetComponent<SpriteRenderer>().enabled = false;
    }
  }

  private void Update()
  {
  }
}