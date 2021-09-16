// Decompiled with JetBrains decompiler
// Type: MapCarLocation
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class MapCarLocation : MonoBehaviour
{
  public List<GameObject> carLocation;

  private void Start()
  {
    this.transform.position = ScreenControler.roundToNearestFullPixel2(this.transform.position);
    if (!GameDataController.gd.getObjective("barn_car_wheel_repaired") || !GameDataController.gd.getObjective("barn_car_coil_repaired") || !GameDataController.gd.getObjective("barn_car_battery_repaired") || !GameDataController.gd.getObjective("barn_car_refueled"))
      this.hide();
    else
      this.transform.position = ScreenControler.roundToNearestFullPixel2(this.carLocation[GameDataController.gd.getObjectiveDetail("car_location")].transform.position);
  }

  private void Update()
  {
  }

  public void hide() => this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
}
