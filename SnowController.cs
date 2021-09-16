// Decompiled with JetBrains decompiler
// Type: SnowController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class SnowController : MonoBehaviour
{
  public ParticleGenerator s1;
  public ParticleGenerator s2;
  public ParticleGenerator s3;

  private void Start()
  {
    if (GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
    {
      int num = 120 - (GameDataController.gd.timeLimit - GameDataController.gd.gameTime) / 6;
      if (num < 4)
        num = 4;
      this.s1.maxParticles = num;
      this.s2.maxParticles = num;
      this.s3.maxParticles = num;
      this.s1.started = true;
      this.s2.started = true;
      this.s3.started = true;
      this.Invoke("snowRangeYChange", 1f);
    }
    else
    {
      this.s1.started = false;
      this.s2.started = false;
      this.s3.started = false;
    }
  }

  private void snowRangeYChange()
  {
    this.s1.ySpread = 0;
    this.s2.ySpread = 0;
    this.s3.ySpread = 0;
  }

  private void Update()
  {
  }
}
