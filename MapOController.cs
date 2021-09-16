// Decompiled with JetBrains decompiler
// Type: MapOController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class MapOController : MonoBehaviour
{
  public TravelAgency currentTravelAgency;
  public TravelAgency[] travelAgencies;
  private MapXController xMark;

  private void Start()
  {
    this.transform.position = ScreenControler.roundToNearestFullPixel2(this.transform.position);
    this.travelAgencies = Object.FindObjectsOfType(typeof (TravelAgency)) as TravelAgency[];
    this.currentTravelAgency = this.getCurrentTravelAgency();
    this.updateLocation(this.currentTravelAgency);
    this.xMark = GameObject.Find("travel_target").GetComponent<MapXController>();
    this.xMark.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.05882353f, 0.4078431f, 1f);
    this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.05882353f, 0.4078431f, 1f);
  }

  private void Update()
  {
  }

  public TravelAgency getCurrentTravelAgency()
  {
    for (int index1 = 0; index1 < this.travelAgencies.Length; ++index1)
    {
      for (int index2 = 0; index2 < this.travelAgencies[index1].locations.Length; ++index2)
      {
        if (GameDataController.gd.previousLocation == this.travelAgencies[index1].locations[index2])
          return this.travelAgencies[index1];
      }
    }
    return (TravelAgency) null;
  }

  public void clearRoutes()
  {
    this.xMark.hide();
    for (int index = 0; index < this.travelAgencies.Length; ++index)
      this.travelAgencies[index].renderRoute();
  }

  public void updateLocation(TravelAgency target)
  {
    this.currentTravelAgency = target;
    this.transform.position = ScreenControler.roundToNearestFullPixel2(target.gameObject.transform.Find("Action_Marker").transform.position);
  }
}
