// Decompiled with JetBrains decompiler
// Type: LocationSkyStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class LocationSkyStart : MonoBehaviour
{
  public GameObject fakePlayer;
  public List<float> realY;
  public List<float> speed;
  public List<float> target;
  public List<GameObject> layer;
  public float speedMod;
  public bool transition;
  public float realFakePlayerX;
  public float ambientVol = 1f;

  private void Start()
  {
    for (int index = 0; index < 4; ++index)
      this.realY[index] = this.layer[index].transform.position.y;
    this.speedMod = 0.0f;
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0015f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 8f;
    PlayerController.wc.shadow.startAlpha = 0.25f;
    PlayerController.wc.shadow.source = 200f;
    PlayerController.ssg.setStepType("dirt");
    GameObject.Find("FakePlayer").GetComponent<StepSoundGenerator>().setStepType("dirt");
    PlayerController.wc.shadow.scaleFactor = 0.3f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    this.transition = false;
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 1f);
    PlayerController.wc.fullStop(true);
    this.realFakePlayerX = -0.9f;
    this.fakePlayer.GetComponent<StepSoundGenerator>().useDoubleStepSound = false;
  }

  private void Update()
  {
    if ((double) this.realY[3] < -0.9 && (double) this.speedMod > 0.0)
    {
      this.speedMod -= 0.3f * Time.deltaTime;
      if ((double) this.speedMod < 0.0)
        this.speedMod = 0.0f;
    }
    else if ((double) this.speedMod < 1.0)
    {
      this.speedMod += 0.3f * Time.deltaTime;
      if ((double) this.speedMod > 1.0)
        this.speedMod = 1f;
    }
    if ((double) this.realFakePlayerX < 0.0)
      this.speedMod = 0.0f;
    for (int index1 = 0; index1 < 4; ++index1)
    {
      List<float> realY;
      int index2;
      (realY = this.realY)[index2 = index1] = realY[index2] - this.speed[index1] * Time.deltaTime * this.speedMod;
      this.layer[index1].transform.position = new Vector3(this.layer[index1].transform.position.x, this.realY[index1], this.layer[index1].transform.position.z);
      this.layer[index1].transform.position = ScreenControler.roundToNearestFullPixel2(this.layer[index1].transform.position);
    }
    if (GameDataController.gd.getObjective("intro_desert_walked"))
    {
      this.realFakePlayerX += 0.19f * Time.deltaTime;
      float newVolume = 1.5f - this.realFakePlayerX;
      if ((double) newVolume < 0.0)
        newVolume = 0.0f;
      if ((double) newVolume > 1.0)
        newVolume = 1f;
      this.fakePlayer.GetComponent<AudioSource>().volume = newVolume;
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, newVolume);
      this.fakePlayer.transform.position = ScreenControler.roundToNearestFullPixel2(new Vector3(this.realFakePlayerX, this.fakePlayer.transform.position.y, this.fakePlayer.transform.position.z));
    }
    else
      GameObject.Find("FakePlayer").GetComponent<Animator>().Play("FakePlayerStand");
    if ((double) this.realFakePlayerX <= 3.5 || this.transition)
      return;
    this.transition = true;
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("LocationDesertTitle", tSpeed: 1f);
  }
}
