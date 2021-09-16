// Decompiled with JetBrains decompiler
// Type: DuskController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class DuskController : MonoBehaviour
{
  public SpriteRenderer sr;
  public Sprite dusk1;
  public Sprite dusk2;
  public Sprite dusk3;
  public Sprite dusk4;
  public Sprite dusk5;
  public Sprite dawn1;
  public Sprite dawn2;
  public Sprite dawn3;
  public Sprite dawn4;
  public Sprite dawn5;
  public Sprite dawn6;
  public Material ov;
  public Material ml;

  private void Start()
  {
    this.sr.enabled = true;
    this.sr.material = this.ml;
    if (GameDataController.gd.gameTime < 490 && GameDataController.gd.getCurrentDay() > 1)
      this.sr.sprite = this.dawn1;
    else if (GameDataController.gd.gameTime < 510 && GameDataController.gd.getCurrentDay() > 1)
      this.sr.sprite = this.dawn2;
    else if (GameDataController.gd.gameTime < 570 && GameDataController.gd.getCurrentDay() > 1)
      this.sr.sprite = this.dawn3;
    else if (GameDataController.gd.gameTime < 600)
      this.sr.enabled = false;
    else if (GameDataController.gd.gameTime < 720)
    {
      this.sr.sprite = this.dawn4;
      this.sr.material = this.ov;
    }
    else if (GameDataController.gd.gameTime < 750)
    {
      this.sr.sprite = this.dawn5;
      this.sr.material = this.ov;
    }
    else if (GameDataController.gd.gameTime < 780)
    {
      this.sr.sprite = this.dawn6;
      this.sr.material = this.ov;
    }
    else if (GameDataController.gd.gameTime < 810)
    {
      this.sr.sprite = this.dawn5;
      this.sr.material = this.ov;
    }
    else if (GameDataController.gd.gameTime < 840)
    {
      this.sr.sprite = this.dawn4;
      this.sr.material = this.ov;
    }
    else if (GameDataController.gd.gameTime < 1010)
      this.sr.enabled = false;
    else
      this.sr.sprite = GameDataController.gd.gameTime >= 1020 ? (GameDataController.gd.gameTime >= 1090 ? (GameDataController.gd.gameTime >= 1130 ? (GameDataController.gd.gameTime >= 1170 ? this.dusk5 : this.dusk4) : this.dusk3) : this.dusk2) : this.dusk1;
    this.gameObject.transform.position = new Vector3(0.0f, 0.0f, -1.5f);
  }

  private void Update()
  {
  }

  public void manualUpdate() => this.Start();
}
