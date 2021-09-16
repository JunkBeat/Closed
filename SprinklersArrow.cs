// Decompiled with JetBrains decompiler
// Type: SprinklersArrow
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SprinklersArrow : MonoBehaviour
{
  public Sprite[] arrows;
  private int delay;
  private int maxDelay = 8;
  private int currentDisplay;
  private int maxDisplay = 16;
  private SpriteRenderer sr;
  public bool fastUpdate = true;

  private void Start()
  {
    this.sr = this.GetComponent<SpriteRenderer>();
    this.fastUpdate = true;
  }

  private void Update()
  {
    int num1 = 0;
    if (GameDataController.gd.getObjective("barn_sprinklers_b1"))
      ++num1;
    if (GameDataController.gd.getObjective("barn_sprinklers_b2"))
      ++num1;
    if (GameDataController.gd.getObjective("barn_sprinklers_b3"))
      ++num1;
    if (GameDataController.gd.getObjective("barn_sprinklers_b4"))
      ++num1;
    if (GameDataController.gd.getObjective("barn_sprinklers_b5"))
      ++num1;
    if (GameDataController.gd.getObjective("barn_sprinklers_b6"))
      ++num1;
    if (GameDataController.gd.getObjective("barn_sprinklers_b7"))
      ++num1;
    if (GameDataController.gd.getObjective("barn_sprinklers_b8"))
      ++num1;
    int num2 = num1 * 2;
    if (this.fastUpdate)
    {
      this.currentDisplay = num2;
      this.sr.sprite = this.arrows[this.currentDisplay];
    }
    if (num2 == this.currentDisplay)
      return;
    if (this.delay >= this.maxDelay)
    {
      this.delay = 0;
      if (num2 < this.currentDisplay)
        --this.currentDisplay;
      else if (num2 > this.currentDisplay)
        ++this.currentDisplay;
      this.sr.sprite = this.arrows[this.currentDisplay];
    }
    else
      ++this.delay;
  }
}
