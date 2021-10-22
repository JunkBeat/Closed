// Decompiled with JetBrains decompiler
// Type: TravelAgency
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class TravelAgency : ObjectActionController
{
  public static int LOCATION_STATUS_UNDISCOVERED;
  public static int LOCATION_STATUS_UNREACHABLE = 2;
  public static int LOCATION_STATUS_REACHABLE = 1;
  private MapXController xMark;
  private MapOController oMark;
  public string locationName;
  private bool hoverThis;
  private SpriteRenderer sr;
  public List<TravelAgency> nodes;
  public List<Sprite> travelDots;
  public List<int> travelTimes;
  public string[] locations;
  public string[] spawns;
  public WalkController.Direction[] facing;
  public MapTextController topText;
  private int calculatedTime;
  private int fuel;
  private SpriteRenderer routeRenderer;
  public List<List<TravelAgency>> routes;
  public List<TravelAgency> fastestRoute;
  public string unlockingDataRefName;
  public FuelController fc;

  private void Start()
  {
    this.fc = GameObject.Find("Fuel").GetComponent<FuelController>();
    this.topText = GameObject.Find("TopText").GetComponent<MapTextController>();
    this.locationName = this.gameObject.name;
    this.routeRenderer = this.gameObject.transform.Find("router").GetComponent<SpriteRenderer>();
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
    this.characterAnimationName = string.Empty;
    this.range = 1000f;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.map;
    this.objectName = this.locationName;
    this.colliderManager.setTarget(this.gameObject);
    this.colliderManager.setCollider(0);
    this.xMark = GameObject.Find("travel_target").GetComponent<MapXController>();
    this.oMark = GameObject.Find("travel_home").GetComponent<MapOController>();
  }

  public void renderRoute(Sprite spr = null, bool red = false)
  {
    if ((Object) spr == (Object) null)
    {
      this.routeRenderer.sprite = (Sprite) null;
    }
    else
    {
      if (red)
      {
        this.routeRenderer.color = new Color(0.65f, 0.0f, 0.0f, 1f);
        this.xMark.GetComponent<SpriteRenderer>().color = new Color(0.65f, 0.0f, 0.0f, 1f);
        this.oMark.GetComponent<SpriteRenderer>().color = new Color(0.65f, 0.0f, 0.0f, 1f);
      }
      else
      {
        this.routeRenderer.color = new Color(0.0f, 0.05882353f, 0.4078431f, 1f);
        this.xMark.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.05882353f, 0.4078431f, 1f);
        this.oMark.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.05882353f, 0.4078431f, 1f);
      }
      if (GameDataController.gd.getObjective("car_travel"))
        this.xMark.GetComponent<SpriteRenderer>().sprite = this.xMark.GetComponent<MapXController>().targetCar;
      else
        this.xMark.GetComponent<SpriteRenderer>().sprite = this.xMark.GetComponent<MapXController>().target;
      this.routeRenderer.sprite = spr;
    }
  }

  public void travel(List<TravelAgency> travelNodes)
  {
    if (travelNodes.IndexOf(this) != -1)
      return;
    travelNodes.Add(this);
    if ((Object) this.oMark.currentTravelAgency == (Object) this)
    {
      travelNodes[0].addRoute(travelNodes);
    }
    else
    {
      for (int index1 = 0; index1 < this.nodes.Count; ++index1)
      {
        List<TravelAgency> travelNodes1 = new List<TravelAgency>();
        for (int index2 = 0; index2 < travelNodes.Count; ++index2)
          travelNodes1.Add(travelNodes[index2]);
        this.nodes[index1].travel(travelNodes1);
      }
    }
  }

  public void addRoute(List<TravelAgency> ta)
  {
    if (this.routes == null)
      this.routes = new List<List<TravelAgency>>();
    this.routes.Add(ta);
  }

  public override void mouseOver()
  {
    if (PlayerController.wc.busy)
      return;
    this.hoverThis = true;
    this.oMark.clearRoutes();
    this.xMark.updateLocation(this);
    this.routes = (List<List<TravelAgency>>) null;
    this.travel(new List<TravelAgency>());
    int index1 = 0;
    int num1 = 9999999;
    for (int index2 = 0; index2 < this.routes.Count; ++index2)
    {
      int num2 = 0;
      for (int index3 = 0; index3 < this.routes[index2].Count - 1; ++index3)
        num2 += this.routes[index2][index3].travelTimes[this.routes[index2][index3].nodes.IndexOf(this.routes[index2][index3 + 1])];
      if (num2 < num1)
      {
        num1 = num2;
        index1 = index2;
      }
    }
    float r = 1f;
    float g = 1f;
    float b = 1f;
    if (this.routes == null)
      return;
    this.fuel = num1;
    if (GameDataController.gd.getObjective("barry_improved_car"))
      this.fuel = (int) Mathf.Ceil((float) this.fuel * 0.6f);
    for (int index4 = 0; index4 < this.routes[index1].Count - 1; ++index4)
    {
      bool red = false;
      if (GameDataController.gd.getObjective("car_travel") && num1 > this.fc.checkFuel())
      {
        red = true;
        r = 1f;
        g = 0.0f;
        b = 0.0f;
      }
      this.routes[index1][index4].renderRoute(this.routes[index1][index4].travelDots[this.routes[index1][index4].nodes.IndexOf(this.routes[index1][index4 + 1])], red);
      this.fastestRoute = this.routes[index1];
    }
    string key = "travel_time";
    if (GameDataController.gd.getObjective("car_travel"))
    {
      key = "ride_time";
      this.fc.updateFuelMeter();
      this.fc.updateFuelMissingMeter(this.fuel);
      if (num1 != 0)
        num1 = num1 / 5 + 1;
      else
        this.fc.hideFuelMissingMeter();
    }
    string text = GameStrings.getPrefixedShort(this.dkvs, this.objectName, true) + ". ^" + GameStrings.getString(GameStrings.gui, key) + " " + (object) num1 + " " + GameStrings.getString(GameStrings.gui, "minutes") + ".";
    if (GameDataController.gd.getObjective("car_travel"))
    {
      float num3 = Mathf.Round(100f * this.fc.getPercent()) - Mathf.Round(100f * this.fc.getPercent(this.fuel));
      text = text + " ^" + GameStrings.getString(GameStrings.gui, "fuel_used") + ": " + (object) num3 + " %";
      if (this.fuel > this.fc.checkFuel())
        text = text + " [" + GameStrings.getString(GameStrings.gui, "not_enough_fuel") + "]";
    }
    this.textfield.viewText(text, quick: true, mwidth: ObjectActionController.BOTTOM_TEXT_WIDTH, r: r, g: g, b: b);
    this.topText.updateTime();
    this.calculatedTime = num1;
  }

  public override void mouseOut()
  {
    if (PlayerController.wc.busy && this.colliderManager.currentColider.pathCount != 0)
      return;
    this.hoverThis = false;
    this.fc.hideFuelMissingMeter();
    this.xMark.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.05882353f, 0.4078431f, 1f);
    this.oMark.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.05882353f, 0.4078431f, 1f);
    this.oMark.clearRoutes();
  }

  public override void updateState()
  {
    this.setCollider(-1);
    if (GameDataController.gd.getObjectiveDetail(this.unlockingDataRefName) == TravelAgency.LOCATION_STATUS_REACHABLE && !GameDataController.gd.getObjective(this.unlockingDataRefName))
    {
      this.changeLocationIcon("iconGrayed", "iconOn");
      this.setCollider(0);
    }
    else if (GameDataController.gd.getObjectiveDetail(this.unlockingDataRefName) == TravelAgency.LOCATION_STATUS_UNREACHABLE && !GameDataController.gd.getObjective(this.unlockingDataRefName))
    {
      this.changeLocationIcon("iconOff", "iconGrayed");
      this.setCollider(-1);
    }
    else if (GameDataController.gd.getObjectiveDetail(this.unlockingDataRefName) == TravelAgency.LOCATION_STATUS_REACHABLE)
    {
      this.iconOn();
      this.setCollider(0);
    }
    else if (GameDataController.gd.getObjectiveDetail(this.unlockingDataRefName) == TravelAgency.LOCATION_STATUS_UNREACHABLE)
    {
      this.iconGrayed();
      this.setCollider(-1);
    }
    else if (GameDataController.gd.getObjectiveDetail(this.unlockingDataRefName) == TravelAgency.LOCATION_STATUS_UNDISCOVERED)
    {
      this.iconOff();
      this.setCollider(-1);
    }
    if (!GameDataController.gd.getObjective("just_visiting_map"))
      return;
    this.setCollider(-1);
  }

  public void changeLocationIcon(string a, string b)
  {
    GameDataController.gd.setObjective(this.unlockingDataRefName, true);
    PlayerController.pc.setBusy(true);
    this.Invoke(b, 0.0f);
    this.Invoke(a, 0.55f);
    this.Invoke(b, 0.85f);
    this.Invoke(a, 1.15f);
    this.Invoke(b, 1.45f);
    this.Invoke(a, 1.75f);
    this.Invoke(b, 2.05f);
    this.Invoke("unlockGame", 2.05f);
  }

  public void revealThisLocation()
  {
    GameDataController.gd.setObjective(this.unlockingDataRefName, true);
    this.iconOn();
    PlayerController.pc.setBusy(true);
    this.Invoke("iconOff", 0.3f);
    this.Invoke("iconOn", 0.6f);
    this.Invoke("iconOff", 0.9f);
    this.Invoke("iconOn", 1.2f);
    this.Invoke("iconOff", 1.5f);
    this.Invoke("iconOn", 1.8f);
    this.Invoke("unlockGame", 1.8f);
  }

  public void unlockGame()
  {
    PlayerController.pc.setBusy(false);
    this.updateAll();
  }

  public void iconOn() => this.GetComponent<SpriteRenderer>().color = (Color) new Vector4(1f, 1f, 1f, 1f);

  public void iconOff() => this.GetComponent<SpriteRenderer>().color = (Color) new Vector4(1f, 1f, 1f, 0.0f);

  public void iconGrayed() => this.GetComponent<SpriteRenderer>().color = (Color) new Vector4(1f, 1f, 1f, 0.6f);

  public override void whatOnClick0()
  {
  }

  private bool isOnRoute(string name)
  {
    if (this.fastestRoute != null)
    {
      for (int index = 0; index < this.fastestRoute.Count; ++index)
      {
        if (this.fastestRoute[index].locationName == name)
          return true;
      }
    }
    return false;
  }

  public override void clickAction()
  {
    PlayerController.pc.setBusy(true);
    PlayerController.pc.spawnName = this.spawns[0];
    string target = this.locations[0];
    WalkController.Direction targetDir = this.facing[0];
    if (GameDataController.gd.getObjective("car_travel") && this.fuel > this.fc.checkFuel())
    {
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "travel_no_fuel"), QuestionController.PopupType.STATEMENT);
    }
    else
    {
      if (this.locationName == "map_bridge")
      {
        if (this.isOnRoute("map_gasstation") || this.isOnRoute("map_houseb"))
        {
          PlayerController.pc.spawnName = this.spawns[0];
          GameDataController.gd.setObjective("bridge_westside", true);
          targetDir = this.facing[0];
        }
        else if (GameDataController.gd.getObjective("bridge_westside"))
        {
          PlayerController.pc.spawnName = this.spawns[0];
          targetDir = this.facing[0];
        }
        else
        {
          PlayerController.pc.spawnName = this.spawns[1];
          targetDir = this.facing[1];
        }
      }
      if (this.locationName == "map_base")
      {
        if (this.isOnRoute("map_bridge"))
        {
          PlayerController.pc.spawnName = this.spawns[0];
          targetDir = this.facing[0];
        }
        else
        {
          PlayerController.pc.spawnName = this.spawns[1];
          targetDir = this.facing[1];
        }
      }
      if (this.locationName == "map_base" && this.calculatedTime == 0 && !GameDataController.gd.getObjective("car_travel"))
      {
        if (GameDataController.gd.getObjective("crossroads_left"))
        {
          PlayerController.pc.spawnName = this.spawns[0];
          targetDir = this.facing[0];
        }
        else
        {
          PlayerController.pc.spawnName = this.spawns[1];
          targetDir = this.facing[1];
        }
      }
      AudioClip sound = (AudioClip) null;
      float tSpeed = 0.025f;
      if (GameDataController.gd.getObjective("car_travel") && this.canIGoThereByCar())
      {
        if ((Object) this.oMark.currentTravelAgency != (Object) this)
        {
          PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.car_drive2);
          sound = SoundsManagerController.sm.car_close;
          tSpeed = 0.01f;
          GameDataController.gd.setObjective("car_driven", true);
        }
        else
        {
          PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.car_stop);
          sound = SoundsManagerController.sm.car_close;
        }
        PlayerController.pc.spawnName = "car";
        targetDir = WalkController.Direction.SE;
        if (target == "LocationCrossroad")
          target = "Barn";
        if (target == "Barn")
          GameDataController.gd.setObjectiveDetail("car_location", 0);
        if (target == "LocationBridge")
          GameDataController.gd.setObjectiveDetail("car_location", 1);
        if (target == "LocationGasstation1")
          GameDataController.gd.setObjectiveDetail("car_location", 2);
        if (target == "LocationHouseB")
          GameDataController.gd.setObjectiveDetail("car_location", 3);
        if (target == "LocationCrashsite1")
          GameDataController.gd.setObjectiveDetail("car_location", 4);
        if (target == "LocationRestaurant1")
          GameDataController.gd.setObjectiveDetail("car_location", 5);
        if (target == "LocationRV")
          GameDataController.gd.setObjectiveDetail("car_location", 6);
        if (target == "HuntersLodgeOutside1")
          GameDataController.gd.setObjectiveDetail("car_location", 7);
        if (target == "SiderealOutside1")
          GameDataController.gd.setObjectiveDetail("car_location", 8);
        if (target == "CS1")
          GameDataController.gd.setObjectiveDetail("car_location", 9);
        if (target == "LocationOutpostOutside1")
          GameDataController.gd.setObjectiveDetail("car_location", 10);
        if (target == "LocationBus1")
          GameDataController.gd.setObjectiveDetail("car_location", 11);
        if (target == "LocationAirplane1")
          GameDataController.gd.setObjectiveDetail("car_location", 12);
      }
      if (GameDataController.gd.getObjective("car_travel") && !this.canIGoThereByCar())
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "car_travel_bridge"), yesClick: new Button.Delegate(this.yesGoToBridgeInstead));
      else if (this.locationName == "map_restaurant" && GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && !GameDataController.gd.getObjective("gasstation_map_warned") && GameDataController.gd.getObjective("sidereal_base_located"))
      {
        GameDataController.gd.setObjective("gasstation_map_warned", true);
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "map_gasstation_thugs"), yesClick: new Button.Delegate(this.yesInvestigateGasStation), noClick: new Button.Delegate(this.noDoNotInvestigateGasStation));
      }
      else if (this.locationName == "map_gasstation" && GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && !GameDataController.gd.getObjective("gasstation_map_warned") && GameDataController.gd.getObjective("sidereal_base_located"))
      {
        GameDataController.gd.setObjective("gasstation_map_warned", true);
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "map_gasstation_soliders"), QuestionController.PopupType.STATEMENT);
      }
      else if (this.locationName == "map_outpost" && GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjectiveDetail("map_bus_revealed") == TravelAgency.LOCATION_STATUS_UNDISCOVERED)
      {
        GameDataController.gd.setObjectiveDetail("map_bus_revealed", TravelAgency.LOCATION_STATUS_REACHABLE);
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "map_bus_investigate"), yesClick: new Button.Delegate(this.yesInvestigateBus), noClick: new Button.Delegate(this.noDoNotInvestigateBus));
      }
      else
      {
        if (!ClockController.advanceTime(this.calculatedTime, true))
          return;
        if (GameDataController.gd.getObjective("car_travel"))
          this.fc.useFuel(this.fuel);
        GameDataController.gd.setObjective("car_travel", false);
        CurtainController.cc.fadeOut(target, targetDir, sound: sound, tSpeed: tSpeed);
      }
    }
  }

  public void yesInvestigateGasStation()
  {
    GameObject.Find("map_gasstation").GetComponent<TravelAgency>().mouseOver();
    GameObject.Find("map_gasstation").GetComponent<TravelAgency>().clickAction();
  }

  public void yesInvestigateBus()
  {
    GameObject.Find("map_bus").GetComponent<TravelAgency>().mouseOver();
    GameObject.Find("map_bus").GetComponent<TravelAgency>().clickAction();
  }

  public void noDoNotInvestigateGasStation()
  {
    GameObject.Find("map_restaurant").GetComponent<TravelAgency>().mouseOver();
    GameObject.Find("map_restaurant").GetComponent<TravelAgency>().clickAction();
  }

  public void noDoNotInvestigateBus()
  {
    GameObject.Find("map_outpost").GetComponent<TravelAgency>().mouseOver();
    GameObject.Find("map_outpost").GetComponent<TravelAgency>().clickAction();
  }

  public void yesGoToSiderealOnFoot()
  {
    if (GameDataController.gd.getObjectiveDetail("car_location") == 6)
      ClockController.advanceTime(60, true);
    else
      ClockController.advanceTime(55, true);
    GameDataController.gd.setObjectiveDetail("car_location", 1);
    GameDataController.gd.setObjective("car_travel", false);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.car_drive2);
    CurtainController.cc.fadeOut("SiderealOutside1", WalkController.Direction.N, tSpeed: 0.025f);
  }

  public void yesGoToBridgeInstead()
  {
    GameObject.Find("map_bridge").GetComponent<TravelAgency>().mouseOver();
    GameObject.Find("map_bridge").GetComponent<TravelAgency>().clickAction();
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public bool canIGoThereByCar() => !(this.locationName == "map_gasstation") && !(this.locationName == "map_houseb") && !(this.locationName == "map_restaurant") && !(this.locationName == "map_sidereal") && !(this.locationName == "map_construction") || GameDataController.gd.getObjective("bridge_planks_used_2");
}
