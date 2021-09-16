// Decompiled with JetBrains decompiler
// Type: WindBlower
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class WindBlower : MonoBehaviour
{
  public static float globalSpeedX;
  public static float globalSpeedY;
  public float targetSpeedX;
  public float targetSpeedY;
  public float deltaX = 0.1f;
  public float deltaY = 0.1f;
  private int currentDelta;
  private int delta;
  public int maxDelta = 300;
  public int minDelta = 100;
  public float maxSpeedX;
  public float maxSpeedY;
  public float minSpeedX;
  public float minSpeedY;

  private void Start()
  {
    WindBlower.globalSpeedX = 0.0f;
    WindBlower.globalSpeedY = 0.0f;
  }

  private void Update()
  {
    if (this.currentDelta >= this.delta)
    {
      this.currentDelta = 0;
      this.delta = Random.Range(this.minDelta, this.maxDelta);
      this.targetSpeedX = Random.Range(this.minSpeedX, this.maxSpeedX);
      this.targetSpeedY = Random.Range(this.minSpeedY, this.maxSpeedY);
    }
    else
      ++this.currentDelta;
    if ((double) WindBlower.globalSpeedX < (double) this.targetSpeedX)
      WindBlower.globalSpeedX += this.deltaX;
    if ((double) WindBlower.globalSpeedX > (double) this.targetSpeedX)
      WindBlower.globalSpeedX -= this.deltaX;
    if ((double) Mathf.Abs(WindBlower.globalSpeedX - this.targetSpeedX) < (double) this.deltaX)
      WindBlower.globalSpeedX = this.targetSpeedX;
    if ((double) WindBlower.globalSpeedY < (double) this.targetSpeedY)
      WindBlower.globalSpeedY += this.deltaY;
    if ((double) WindBlower.globalSpeedY > (double) this.targetSpeedY)
      WindBlower.globalSpeedY -= this.deltaY;
    if ((double) Mathf.Abs(WindBlower.globalSpeedY - this.targetSpeedY) >= (double) this.deltaY)
      return;
    WindBlower.globalSpeedY = this.targetSpeedY;
  }
}
