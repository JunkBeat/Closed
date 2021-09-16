// Decompiled with JetBrains decompiler
// Type: ParticleController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ParticleController : MonoBehaviour
{
  private SpriteRenderer spriteR;
  private float alpha;
  public int speedXMin;
  public int speedXMax;
  public int speedYMin;
  public int speedYMax;
  public int lifetime;
  public float fadeInStep = 0.1f;
  public float fadeOutStep = 0.1f;
  public int currentSpeedX;
  public int currentSpeedY;
  public float minAlpha;
  public float maxAlpha;
  public float targetAlpha;
  public float currentLifetime;
  public Vector2 currentXY;
  public float speedDiv = 10f;
  public bool globalized = true;
  public bool die;
  private float takeItEasy;

  private void Start()
  {
    this.spriteR = this.gameObject.GetComponent<SpriteRenderer>();
    this.alpha = 0.0f;
    this.targetAlpha = Random.Range(this.minAlpha, this.maxAlpha);
  }

  private void Update()
  {
    if (this.globalized)
    {
      this.currentXY.x += (float) (((double) this.currentSpeedX / (double) this.speedDiv + (double) WindBlower.globalSpeedX / (double) this.speedDiv) * (double) Time.deltaTime * 60.0);
      this.currentXY.y += (float) (((double) this.currentSpeedY / (double) this.speedDiv + (double) WindBlower.globalSpeedY / (double) this.speedDiv) * (double) Time.deltaTime * 60.0);
    }
    else
    {
      this.currentXY.x += (float) ((double) this.currentSpeedX / (double) this.speedDiv * (double) Time.deltaTime * 60.0);
      this.currentXY.y += (float) ((double) this.currentSpeedY / (double) this.speedDiv * (double) Time.deltaTime * 60.0);
    }
    if ((double) Random.value > 0.5)
      ++this.currentSpeedX;
    else
      --this.currentSpeedX;
    if ((double) Random.value > 0.5)
      ++this.currentSpeedY;
    else
      --this.currentSpeedY;
    if (this.currentSpeedX > this.speedXMax)
      this.currentSpeedX = this.speedXMax;
    if (this.currentSpeedX < this.speedXMin)
      this.currentSpeedX = this.speedXMin;
    if (this.currentSpeedY > this.speedYMax)
      this.currentSpeedY = this.speedYMax;
    if (this.currentSpeedY < this.speedYMin)
      this.currentSpeedY = this.speedYMin;
    this.spriteR.color = new Color(1f, 1f, 1f, this.alpha);
    this.currentLifetime += 60f * Time.deltaTime;
    if ((double) this.currentLifetime > (double) this.lifetime)
    {
      this.alpha -= this.fadeOutStep;
      if ((double) this.alpha <= 0.0)
        this.die = true;
    }
    else if ((double) this.alpha < (double) this.targetAlpha)
      this.alpha += this.fadeInStep;
    this.gameObject.transform.position = Camera.main.ScreenToWorldPoint((Vector3) ScreenControler.gameToScreen(this.currentXY));
  }
}
