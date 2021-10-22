// Decompiled with JetBrains decompiler
// Type: ParticleGenerator
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
  public int maxParticles;
  public int minDelayBetweeenParticles;
  public int maxDelayBetweeenParticles;
  public int speedXMin;
  public int speedXMax;
  public int speedYMin;
  public int speedYMax;
  public int lifetimeMin;
  public int lifetimeMax;
  public float fadeInStep = 0.1f;
  public float fadeOutStep = 0.1f;
  public float minAlpha = 1f;
  public float maxAlpha = 1f;
  public List<GameObject> particles;
  public float currentDelay;
  private int delay;
  public float zShift;
  public int xSpread;
  public int ySpread;
  public int xStart;
  public int yStart;
  public float speedDiv;
  public bool useGlobalWind = true;
  public Sprite[] sprites;
  public bool glow;
  private int index;
  public bool started = true;

  private void Start()
  {
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    this.index = 0;
  }

  private void Update()
  {
    if (!this.started)
      return;
    if ((double) this.currentDelay >= (double) this.delay)
    {
      this.delay = Random.Range(this.minDelayBetweeenParticles, this.maxDelayBetweeenParticles);
      this.currentDelay = 0.0f;
      int maxParticles = this.maxParticles;
      if (this.particles.Count < (int) Mathf.Round((float) this.maxParticles * 1f))
      {
        GameObject gameObject = this.glow ? Object.Instantiate(Resources.Load("Prefabs/ParticleGlow"), this.gameObject.transform.position, new Quaternion()) as GameObject : Object.Instantiate(Resources.Load("Prefabs/Particle"), this.gameObject.transform.position, new Quaternion()) as GameObject;
        gameObject.transform.parent = this.gameObject.transform;
        ParticleController component = gameObject.GetComponent<ParticleController>();
        component.speedXMax = this.speedXMax;
        component.speedYMax = this.speedYMax;
        component.speedXMin = this.speedXMin;
        component.speedYMin = this.speedYMin;
        component.fadeInStep = this.fadeInStep;
        component.fadeOutStep = this.fadeOutStep;
        component.minAlpha = this.minAlpha;
        component.maxAlpha = this.maxAlpha;
        component.globalized = this.useGlobalWind;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z));
        component.currentXY = ScreenControler.screenToGame(new Vector2(screenPoint.x, screenPoint.y));
        component.currentXY.x += (float) this.xStart;
        component.currentXY.y += (float) this.yStart;
        Vector3 vector3 = new Vector3(0.0f, this.zShift, 0.0f);
        gameObject.transform.Find("Z_Marker").transform.position = vector3;
        component.currentXY.x += Random.Range((float) -this.xSpread / 2f, (float) this.xSpread / 2f);
        component.currentXY.y += Random.Range((float) -this.ySpread / 2f, (float) this.ySpread / 2f);
        component.lifetime = Random.Range(this.lifetimeMin, this.lifetimeMax);
        gameObject.GetComponent<SpriteRenderer>().sprite = this.sprites[Random.Range(0, this.sprites.Length)];
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.0f);
        this.particles.Add(gameObject);
      }
    }
    else
      this.currentDelay += Time.deltaTime * 60f;
    for (int index = 0; index < this.particles.Count; ++index)
    {
      if (this.particles.Count != 0)
      {
        if ((Object) this.particles[index] == (Object) null)
        {
          this.particles.RemoveAt(index);
          --index;
          this.index = 0;
        }
        else if (this.particles[index].GetComponent<ParticleController>().die)
        {
          GameObject gameObject = this.particles[index].gameObject;
          this.particles.RemoveAt(index);
          Object.Destroy((Object) gameObject);
          --index;
          this.index = 0;
        }
      }
    }
  }

  public void removeParticles()
  {
    for (int index = 0; index < this.particles.Count; ++index)
    {
      if (this.particles.Count != 0)
      {
        if ((Object) this.particles[index] == (Object) null)
        {
          this.particles.RemoveAt(index);
          --index;
          this.index = 0;
        }
        else
        {
          this.particles[index].GetComponent<ParticleController>().die = true;
          GameObject gameObject = this.particles[index].gameObject;
          this.particles.RemoveAt(index);
          Object.Destroy((Object) gameObject);
          --index;
          this.index = 0;
        }
      }
    }
  }
}
