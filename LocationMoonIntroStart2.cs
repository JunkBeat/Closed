// Decompiled with JetBrains decompiler
// Type: LocationMoonIntroStart2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationMoonIntroStart2 : MonoBehaviour
{
  public List<float> realX;
  public List<float> speed;
  public List<float> target;
  public GameObject shuttle;
  public GameObject shuttleShadow;
  public List<GameObject> layer;
  public GameObject bruzda;
  public float speedMod;
  public bool transition;
  public float realFakePlayerX;
  public float animProgress0;
  public float animProgress1;
  public float animProgress2;
  public float animProgress3;
  public float animProgress4;
  public float animProgress25;
  public float ambientVol = 1f;
  public ParticleGenerator dust;
  public ParticleGenerator dust2;
  public ParticleGenerator dust3;
  public ParticleGenerator dust4;
  private bool landed;
  private bool crashed;
  private bool stopping;
  private bool jetStarted;
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
    this.transition = false;
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.moon, 0.75f);
    PlayerController.wc.fullStop(true);
    this.realFakePlayerX = -0.9f;
  }

  public void robSypuSypu()
  {
    if ((double) this.realX[0] <= -3.3199999332428)
      return;
    int num = Random.Range(0, 4);
    if (num == 0)
      this.aS.PlayOneShot(SoundsManagerController.sm.sand_pour1);
    if (num == 1)
      this.aS.PlayOneShot(SoundsManagerController.sm.sand_pour2);
    if (num == 2)
      this.aS.PlayOneShot(SoundsManagerController.sm.sand_pour3);
    if (num == 3)
      this.aS.PlayOneShot(SoundsManagerController.sm.sand_pour4);
    this.Invoke(nameof (robSypuSypu), Random.Range(0.25f, 1.25f));
  }

  private void Update()
  {
    this.animProgress0 += Time.deltaTime * 0.25f;
    if ((double) this.animProgress0 > 0.200000002980232 && !this.jetStarted)
    {
      this.jetStarted = true;
      this.aS.PlayOneShot(SoundsManagerController.sm.jet2_mono);
    }
    if ((double) this.animProgress0 >= 1.0)
    {
      this.animProgress0 = 1f;
      this.animProgress1 += Time.deltaTime * 0.17f;
      if ((double) this.animProgress1 >= 1.0)
      {
        this.animProgress1 = 1f;
        this.shuttleShadow.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      }
      else
        this.shuttleShadow.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, this.animProgress2 * 0.75f);
      this.animProgress2 += Time.deltaTime * 0.1f;
      if ((double) this.animProgress2 >= 1.0)
        this.animProgress2 = 1f;
    }
    else
      this.shuttleShadow.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    this.speedMod = 0.0f;
    this.speedMod += this.animProgress0 / 2f;
    this.speedMod += this.animProgress1;
    if ((double) this.realX[1] < 0.5)
      this.speedMod *= 1f;
    if ((double) this.realX[0] < -2.5)
    {
      this.speedMod *= (float) (1.0 - ((double) this.realX[0] + 2.5) / -0.819999933242798);
      if ((double) this.speedMod < 0.100000001490116)
        this.speedMod = 0.1f;
    }
    if ((double) this.realX[0] < -2.0 && !this.stopping)
    {
      this.stopping = true;
      this.shuttle.GetComponent<Animator>().Play("shuttle_stopping");
      this.dust2.started = false;
      this.Invoke("nextScene", 10f);
    }
    if ((double) this.realX[1] < 0.2 && !this.crashed)
    {
      this.crashed = true;
      this.shuttle.GetComponent<Animator>().Play("shuttle_crash");
      this.Invoke("robSypuSypu", 1f);
      this.aS.PlayOneShot(SoundsManagerController.sm.heli_crash);
    }
    this.dust.maxParticles = 20 + (int) (20.0 * (1.0 - (double) this.realX[0] / -3.3199999332428));
    if ((double) this.realX[0] <= -2.5)
    {
      this.dust3.maxParticles = 10 + (int) (30.0 * (1.0 - (double) this.realX[0] / -3.3199999332428));
      this.dust4.maxParticles = 10 + (int) (30.0 * (1.0 - (double) this.realX[0] / -3.3199999332428));
      this.dust.started = false;
    }
    if ((double) this.realX[0] <= -3.3199999332428)
    {
      this.dust3.started = false;
      this.dust4.started = false;
      this.dust.started = false;
      this.speedMod = 0.0f;
    }
    for (int index1 = 0; index1 < 2; ++index1)
    {
      List<float> realX;
      int index2;
      (realX = this.realX)[index2 = index1] = realX[index2] - this.speed[index1] * Time.deltaTime * this.speedMod;
      this.layer[index1].transform.position = new Vector3(this.realX[index1], this.layer[index1].transform.position.y, this.layer[index1].transform.position.z);
      this.layer[index1].transform.position = ScreenControler.roundToNearestFullPixel2(this.layer[index1].transform.position);
    }
    this.bruzda.transform.position = new Vector3(this.layer[0].transform.position.x, this.layer[0].transform.position.y, 0.4f);
    float num1 = this.animProgress1;
    float num2 = (float) ((double) this.animProgress1 / 1.0 - (double) Mathf.Pow(-this.animProgress3 + this.animProgress4, 2f) * 0.100000001490116);
    if ((double) num1 > 1.0)
      num1 = 1f;
    this.shuttle.transform.position = new Vector3((float) (-1.25999999046326 * (1.0 - (double) num1)), (float) (1.11000001430511 * (1.0 - (double) num2)), this.shuttle.transform.position.z);
    this.shuttle.transform.position = ScreenControler.roundToNearestFullPixel2(this.shuttle.transform.position);
    this.shuttleShadow.transform.position = ScreenControler.roundToNearestFullPixel2(this.shuttleShadow.transform.position);
    this.shuttleShadow.transform.position = new Vector3(this.shuttle.transform.position.x, this.shuttle.transform.position.y * 0.25f, this.shuttle.transform.position.z + 0.1f);
  }

  private void nextScene()
  {
    GameDataController.gd.setObjective("moon_shocked1", true);
    GameDataController.gd.setObjective("moon_shocked2", true);
    GameDataController.gd.setObjective("moon_shocked3", true);
    PlayerController.pc.spawnName = "WakeUp";
    CurtainController.cc.fadeOut("MoonShip", WalkController.Direction.E, "wake_up", tSpeed: 0.01f);
  }
}
