// Decompiled with JetBrains decompiler
// Type: HeatVisualController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class HeatVisualController : MonoBehaviour
{
  private SpriteRenderer sr;
  public Sprite s1;
  public Sprite s2;
  public Sprite s3;
  public Sprite s4;
  public Sprite s5;
  public float alfa = 1f;
  private float delay;
  private int lastran;

  private void Start()
  {
    this.sr = this.GetComponent<SpriteRenderer>();
    if (GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
    {
      this.sr.enabled = true;
      int num = GameDataController.gd.timeLimit - GameDataController.gd.gameTime;
      this.alfa = (float) (1.0 - (double) num / 1000.0);
      if ((double) this.alfa < 0.0)
        this.alfa = 0.0f;
      if ((double) this.alfa > 1.0)
        this.alfa = 1f;
      this.sr.color = new Color(1f, 1f, 1f, this.alfa);
      MonoBehaviour.print((object) (num.ToString() + " " + (object) this.alfa));
    }
    else
      this.sr.enabled = false;
  }

  private void Update()
  {
    if (GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
    {
      if ((double) this.delay <= 0.0)
      {
        int num;
        do
        {
          num = Random.Range(0, 5);
        }
        while (num == this.lastran);
        this.lastran = num;
        switch (num)
        {
          case 0:
            this.sr.sprite = this.s1;
            break;
          case 1:
            this.sr.sprite = this.s2;
            break;
          case 2:
            this.sr.sprite = this.s3;
            break;
          case 3:
            this.sr.sprite = this.s4;
            break;
          case 4:
            this.sr.sprite = this.s5;
            break;
        }
        this.delay = 0.02f;
        this.sr.enabled = true;
        this.alfa = (float) (1.20000004768372 - (double) (GameDataController.gd.timeLimit - GameDataController.gd.gameTime) / 1500.0);
        if ((double) this.alfa < 0.0)
          this.alfa = 0.0f;
        if ((double) this.alfa > 1.0)
          this.alfa = 1f;
        this.sr.color = new Color(1f, 1f, 1f, this.alfa);
      }
      else
        this.delay -= Time.deltaTime;
    }
    else
      this.sr.enabled = false;
  }
}
