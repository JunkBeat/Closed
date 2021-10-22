// Decompiled with JetBrains decompiler
// Type: MapXController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class MapXController : MonoBehaviour
{
  public Sprite target;
  public Sprite targetCar;
  public TravelAgency targetTravelAgency;

  private void Start()
  {
    this.transform.position = ScreenControler.roundToNearestFullPixel2(this.transform.position);
    this.hide();
  }

  private void Update()
  {
  }

  public void hide() => this.gameObject.GetComponent<SpriteRenderer>().enabled = false;

  public void updateLocation(TravelAgency target)
  {
    this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    this.targetTravelAgency = target;
    this.transform.position = ScreenControler.roundToNearestFullPixel2(target.gameObject.transform.Find("Action_Marker").transform.position);
  }
}
