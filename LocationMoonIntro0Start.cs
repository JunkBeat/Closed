// Decompiled with JetBrains decompiler
// Type: LocationMoonIntro0Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationMoonIntro0Start : MonoBehaviour
{
  public List<float> realY;
  public List<float> speed;
  public List<float> target;
  public GameObject shuttle;
  public List<GameObject> layer;
  public float speedMod;
  public float animProgress0;
  public float animProgress1;
  public float ambientVol = 1f;
  public ParticleGenerator dust;
  public ParticleGenerator dust2;
  public ParticleGenerator dust3;
  public ParticleGenerator dust4;
  private bool landing;
  private bool jetStarted;
  private bool transitioning;
  public AudioSource aS;

  private void Start()
  {
    this.speedMod = 0.0f;
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0015f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 8f;
    PlayerController.wc.shadow.startAlpha = 0.25f;
    PlayerController.wc.shadow.source = 200f;
    PlayerController.ssg.setStepType("dirt");
    PlayerController.wc.shadow.scaleFactor = 0.3f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    PlayerController.wc.fullStop(true);
  }

  private void Update()
  {
    this.animProgress0 += Time.deltaTime * 0.5f;
    if ((double) this.animProgress1 > 0.75 && !this.jetStarted)
    {
      this.jetStarted = true;
      this.aS.PlayOneShot(SoundsManagerController.sm.jet_mono);
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.moon, 0.5f);
    }
    if ((double) this.animProgress0 >= 1.0)
    {
      this.animProgress0 = 1f;
      this.animProgress1 += Time.deltaTime * 0.5f;
      if ((double) this.animProgress1 >= 1.0)
        this.animProgress1 = 1f;
    }
    if ((double) this.realY[0] <= 1.0 && !this.landing)
    {
      this.landing = true;
      this.layer[4].GetComponent<Animator>().Play("shuttle_top_fly");
    }
    this.speedMod = 0.0f;
    this.speedMod += this.animProgress1;
    if ((double) this.realY[0] <= 2.0)
    {
      this.speedMod = this.realY[0] / 2f;
      if ((double) this.speedMod < 0.100000001490116)
        this.speedMod = 0.1f;
    }
    if ((double) this.realY[0] <= 0.699999988079071)
      this.speedMod = 0.0f;
    if ((double) this.realY[0] <= 0.699999988079071 && !this.transitioning)
    {
      this.transitioning = true;
      PlayerController.pc.spawnName = "InfoExit";
      if (GameDataController.gd.getObjective("npc1_alive"))
        CurtainController.cc.fadeOut("MoonIntro", WalkController.Direction.N, tSpeed: 0.1f);
      else
        CurtainController.cc.fadeOut("MoonIntroB", WalkController.Direction.N, tSpeed: 0.1f);
    }
    for (int index1 = 0; index1 < this.realY.Count; ++index1)
    {
      List<float> realY;
      int index2;
      (realY = this.realY)[index2 = index1] = realY[index2] - this.speed[index1] * Time.deltaTime * this.speedMod;
      this.layer[index1].transform.position = new Vector3(this.layer[index1].transform.position.x, this.realY[index1], this.layer[index1].transform.position.z);
      this.layer[index1].transform.position = ScreenControler.roundToNearestFullPixel2(this.layer[index1].transform.position);
    }
  }
}
