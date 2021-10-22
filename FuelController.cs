// Decompiled with JetBrains decompiler
// Type: FuelController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour
{
  public List<Sprite> fuelSprites;
  public List<Sprite> missingSprites;
  public TextFieldController tfc;
  public SpriteRenderer fuelRenderer;
  public SpriteRenderer missingRenderer;
  public SpriteRenderer reservesRenderer;

  public int checkFuel() => !GameDataController.gd.getObjective("barn_car_refueled") ? 0 : GameDataController.gd.getObjectiveDetail("barn_car_refueled");

  public float getPercent(int fuelToUse = 0) => ((float) this.checkFuel() - (float) fuelToUse) / (float) GameDataController.MAX_FUEL;

  public void updateFuelMeter()
  {
    this.checkFuel();
    float percent = this.getPercent();
    this.fuelRenderer.sprite = this.fuelSprites[Mathf.CeilToInt(percent * (float) (this.fuelSprites.Count - 1))];
    this.tfc.viewText(Mathf.RoundToInt(percent * 100f).ToString() + "%", quick: true, instant: true, mwidth: 100, ba: 0.0f, mute: true);
    this.tfc.keepAlive = true;
    this.tfc.shift.y = 57f;
    this.tfc.shift.x = 93f;
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(120f, 67f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    this.tfc.transform.position = worldPoint;
    if (GameDataController.gd.getObjective("car_travel"))
      return;
    this.tfc.viewText(" ", quick: true, instant: true, mwidth: 100, r: 0.0f, g: 0.0f, b: 0.0f, ba: 0.0f);
    this.tfc.dissmiss(true);
  }

  public void updateFuelMissingMeter(int fuelToUse)
  {
    int num1 = this.checkFuel();
    if (fuelToUse > num1)
      this.reservesRenderer.enabled = true;
    else
      this.reservesRenderer.enabled = false;
    if (num1 - fuelToUse < 0)
      ;
    float percent = this.getPercent(fuelToUse);
    int num2 = Mathf.FloorToInt(percent * (float) (this.missingSprites.Count - 1));
    if (num2 < 0)
      num2 = 0;
    if (num2 > this.missingSprites.Count - 1)
      num2 = this.missingSprites.Count - 1;
    this.missingRenderer.sprite = this.missingSprites[this.missingSprites.Count - 1 - num2];
    MonoBehaviour.print((object) ("Frame: " + (object) num2 + " | " + (object) percent + " | " + (object) fuelToUse + " : " + (object) Mathf.RoundToInt((float) (100.0 * ((double) fuelToUse / (double) GameDataController.MAX_FUEL))) + " | " + (object) (float) ((double) fuelToUse / (double) GameDataController.MAX_FUEL)));
    int num3 = Mathf.RoundToInt(percent * 100f);
    if (num3 < 0)
      num3 = 0;
    this.tfc.viewText(num3.ToString() + "%", quick: true, instant: true, mwidth: 100, ba: 0.0f, mute: true);
    if (GameDataController.gd.getObjective("car_travel"))
      return;
    this.tfc.viewText(" ", quick: true, instant: true, mwidth: 100, r: 0.0f, g: 0.0f, b: 0.0f, ba: 0.0f);
    this.tfc.dissmiss(true);
  }

  public void hideFuelMissingMeter()
  {
    this.missingRenderer.sprite = this.missingSprites[0];
    this.updateFuelMeter();
    this.reservesRenderer.enabled = false;
  }

  public void useFuel(int amount)
  {
    int detail = GameDataController.gd.getObjectiveDetail("barn_car_refueled") - amount;
    if (detail < 0)
      detail = 0;
    GameDataController.gd.setObjectiveDetail("barn_car_refueled", detail);
  }

  private void Start() => this.fuelRenderer.color = new Color(1f, 1f, 1f, 0.75f);

  private void Update()
  {
  }
}
