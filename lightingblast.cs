// Decompiled with JetBrains decompiler
// Type: lightingblast
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class lightingblast : MonoBehaviour
{
  private SpriteRenderer light;
  private AudioSource aS;
  private float prelight;
  private bool postlight;
  private float maxAlpha;
  public float autoblastDelay = -111f;

  private void Start()
  {
    this.light = this.GetComponent<SpriteRenderer>();
    this.aS = this.GetComponent<AudioSource>();
  }

  public void initthis()
  {
    this.light = this.GetComponent<SpriteRenderer>();
    this.aS = this.GetComponent<AudioSource>();
  }

  public void strike(AudioClip thunder, float pre, bool post, float vol = 1f, float ma = 0.5f)
  {
    this.aS.pitch = Random.Range(0.8f, 1.2f);
    this.aS.PlayOneShot(thunder, vol);
    this.light.enabled = true;
    this.light.color = new Color(1f, 1f, 1f, 1f);
    if ((double) pre == 0.0 && !post)
      this.light.color = new Color(1f, 1f, 1f, 0.0f);
    this.maxAlpha = ma;
    this.prelight = pre;
    this.postlight = post;
  }

  public void startAutoBlast() => this.autoblastDelay = -50f;

  private void Update()
  {
    if (this.light.enabled)
    {
      if ((double) this.prelight > 0.0)
      {
        this.prelight -= Time.deltaTime;
        this.light.color = new Color(1f, 1f, 1f, Random.Range(0.0f, this.maxAlpha));
        if ((double) this.prelight <= 0.0 && this.postlight)
          this.light.color = new Color(1f, 1f, 1f, 1f);
        else if ((double) this.prelight <= 0.0)
          this.light.color = new Color(1f, 1f, 1f, 0.0f);
      }
      else if (this.postlight)
      {
        this.light.color = new Color(1f, 1f, 1f, this.light.color.a - Time.deltaTime);
        if ((double) this.light.color.a <= 0.0)
          this.light.enabled = false;
      }
      else
        this.light.enabled = false;
    }
    if ((double) this.autoblastDelay == -111.0)
      this.autoblastDelay = GameDataController.gd.gameTime <= 1100 ? (GameDataController.gd.gameTime <= 1000 ? (GameDataController.gd.gameTime <= 900 ? (GameDataController.gd.gameTime <= 800 ? (GameDataController.gd.gameTime <= 700 ? (GameDataController.gd.gameTime <= 600 ? (float) Random.Range(20, 70) : (float) Random.Range(15, 60)) : (float) Random.Range(10, 50)) : (float) Random.Range(8, 40)) : (float) Random.Range(6, 30)) : (float) Random.Range(4, 20)) : (float) Random.Range(2, 10);
    if ((double) this.autoblastDelay > 0.0)
      this.autoblastDelay -= Time.deltaTime;
    else if (GameDataController.gd.gameTime > 1100)
    {
      this.autoblastDelay = (float) Random.Range(5, 20);
      AudioClip thunder = (AudioClip) null;
      int num = Random.Range(0, 3);
      if (num == 0)
        thunder = SoundsManagerController.sm.thunder4;
      if (num == 1)
        thunder = SoundsManagerController.sm.thunder5;
      if (num == 2)
        thunder = SoundsManagerController.sm.thunder3;
      this.strike(thunder, Random.Range(0.5f, 1.2f), true, 0.6f);
    }
    else if (GameDataController.gd.gameTime > 1000)
    {
      this.autoblastDelay = (float) Random.Range(10, 40);
      AudioClip thunder = (AudioClip) null;
      int num = Random.Range(0, 3);
      if (num == 0)
        thunder = SoundsManagerController.sm.thunder4;
      if (num == 1)
        thunder = SoundsManagerController.sm.thunder3;
      if (num == 2)
        thunder = SoundsManagerController.sm.thunder3;
      this.strike(thunder, Random.Range(0.3f, 0.7f), true, 0.8f);
    }
    else if (GameDataController.gd.gameTime > 900)
    {
      this.autoblastDelay = (float) Random.Range(15, 45);
      AudioClip thunder = (AudioClip) null;
      int num = Random.Range(0, 2);
      if (num == 0)
        thunder = SoundsManagerController.sm.thunder3;
      if (num == 1)
        thunder = SoundsManagerController.sm.thunder2;
      this.strike(thunder, Random.Range(0.2f, 0.8f), false, 0.5f);
    }
    else if (GameDataController.gd.gameTime > 800)
    {
      this.autoblastDelay = (float) Random.Range(20, 55);
      AudioClip thunder = (AudioClip) null;
      int num = Random.Range(0, 3);
      if (num == 0)
        thunder = SoundsManagerController.sm.thunder1;
      if (num == 1)
        thunder = SoundsManagerController.sm.thunder2;
      if (num == 2)
        thunder = SoundsManagerController.sm.thunder3;
      this.strike(thunder, Random.Range(0.0f, 0.5f), false, 0.25f);
    }
    else if (GameDataController.gd.gameTime > 700)
    {
      this.autoblastDelay = (float) Random.Range(25, 70);
      AudioClip thunder = (AudioClip) null;
      int num = Random.Range(0, 3);
      if (num == 0)
        thunder = SoundsManagerController.sm.thunder1;
      if (num == 1)
        thunder = SoundsManagerController.sm.thunder2;
      if (num == 2)
        thunder = SoundsManagerController.sm.thunder3;
      this.strike(thunder, 0.0f, false);
    }
    else if (GameDataController.gd.gameTime > 600)
    {
      this.autoblastDelay = (float) Random.Range(30, 80);
      AudioClip thunder = (AudioClip) null;
      int num = Random.Range(0, 2);
      if (num == 0)
        thunder = SoundsManagerController.sm.thunder1;
      if (num == 1)
        thunder = SoundsManagerController.sm.thunder2;
      this.strike(thunder, 0.0f, false);
    }
    else
      this.autoblastDelay = (float) Random.Range(20, 30);
  }
}
