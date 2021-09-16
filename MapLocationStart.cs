// Decompiled with JetBrains decompiler
// Type: MapLocationStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class MapLocationStart : MonoBehaviour
{
  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = -5f;
    PlayerController.wc.shadow.startAlpha = 0.0f;
    PlayerController.wc.shadow.source = 10f;
    PlayerController.ssg.setStepType("none");
    MonoBehaviour.print((object) "............................. LOCATION INFO  ..................................");
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(-999f, -999f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    InventoryButtonController.ibc.gameObject.transform.position = worldPoint;
    GameDataController.gd.setObjective("dialogue_ginger_barry_distracted", false);
    GameDataController.gd.setObjectiveDetail("dialogue_ginger_barry_distracted", 0);
    int num = 2 + (int) (2.0 * ((double) InventoryController.ic.getCurrentWeight() / 5.0));
    if (GameDataController.gd.getObjective("bridge_westside") && !GameDataController.gd.getObjective("bridge_planks_used_1"))
    {
      GameObject.Find("map_gasstation").GetComponent<TravelAgency>().travelTimes[0] = 10;
      GameObject.Find("map_base").GetComponent<TravelAgency>().travelTimes[1] = 15 + num;
    }
    else if (!GameDataController.gd.getObjective("bridge_planks_used_1"))
    {
      GameObject.Find("map_gasstation").GetComponent<TravelAgency>().travelTimes[0] = 10 + num;
      GameObject.Find("map_base").GetComponent<TravelAgency>().travelTimes[1] = 15;
    }
    else
    {
      GameObject.Find("map_gasstation").GetComponent<TravelAgency>().travelTimes[0] = 10;
      GameObject.Find("map_base").GetComponent<TravelAgency>().travelTimes[1] = 15;
    }
    GameObject.Find("Fuel").GetComponent<FuelController>().updateFuelMeter();
    GameObject.Find("Fuel").GetComponent<FuelController>().hideFuelMissingMeter();
    if (GameDataController.gd.getObjective("car_travel"))
      return;
    GameObject.Find("Fuel").transform.Find("reserves").GetComponent<SpriteRenderer>().enabled = false;
    GameObject.Find("Fuel").transform.Find("back").GetComponent<SpriteRenderer>().enabled = false;
    GameObject.Find("Fuel").transform.Find("fuel").GetComponent<SpriteRenderer>().enabled = false;
    GameObject.Find("percent").GetComponent<TextFieldController>().keepAlive = false;
    GameObject.Find("percent").GetComponent<TextFieldController>().dissmiss(true);
  }

  private void Update()
  {
  }
}
