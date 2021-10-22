// Decompiled with JetBrains decompiler
// Type: CarTravel
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarTravel : ObjectActionController
{
  public Sprite sign;
  public GameObject trunk;
  public float groundItemsFix_x;
  public float groundItemsFix_y;
  public float groundItemsFixShiftX;
  public float groundItemsFixShiftY;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "car";
    this.range = 2f;
    this.trunk = GameObject.Find("Trunk");
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("canister_full", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister_empty", GameStrings.getString(GameStrings.actions, "canister_is_empty"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister2_full", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister2_empty", GameStrings.getString(GameStrings.actions, "canister_is_empty"), anim: string.Empty));
    this.updateState();
  }

  public void yesFuel()
  {
    InventoryController.ic.removeItem("canister_full");
    InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("canister_empty"));
    GameDataController.gd.setObjective("barn_car_refueled", true);
    GameDataController.gd.setObjectiveDetail("barn_car_refueled", GameDataController.MAX_FUEL);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.liquid_pour);
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.NE, flipX: true, actionAfterFade: new CurtainController.Delegate(this.sayAboutCarFuel));
  }

  public void yesFuel2()
  {
    InventoryController.ic.removeItem("canister2_full");
    InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("canister2_empty"));
    GameDataController.gd.setObjective("barn_car_refueled", true);
    GameDataController.gd.setObjectiveDetail("barn_car_refueled", GameDataController.MAX_FUEL);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.liquid_pour);
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.NE, flipX: true, actionAfterFade: new CurtainController.Delegate(this.sayAboutCarFuel));
  }

  public void sayAboutCarFuel() => PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_car_fueled"));

  public override void clickAction()
  {
    if (this.usedItem == "canister_full")
    {
      if (GameDataController.gd.getObjective("barn_car_refueled") && GameDataController.gd.getObjectiveDetail("barn_car_refueled") == GameDataController.MAX_FUEL)
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "car_already_fueled"));
      else
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "barn_car_refuel"), yesClick: new Button.Delegate(this.yesFuel));
    }
    else if (this.usedItem == "canister2_full")
    {
      if (GameDataController.gd.getObjective("barn_car_refueled") && GameDataController.gd.getObjectiveDetail("barn_car_refueled") == GameDataController.MAX_FUEL)
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "car_already_fueled"));
      else
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "barn_car_refuel"), yesClick: new Button.Delegate(this.yesFuel2));
    }
    else if (GameDataController.gd.getObjectiveDetail("barn_car_refueled") == 0)
    {
      Timeline.t.addAction(new TimelineAction()
      {
        textfield = PlayerController.pc.textField,
        text = GameStrings.getString(GameStrings.actions, "barn_car_fuel_missing")
      });
    }
    else
    {
      if (SceneManager.GetActiveScene().name == "LocationBridge")
      {
        if (GameDataController.gd.getObjectiveDetail("map_restaurant_revealed") == TravelAgency.LOCATION_STATUS_UNREACHABLE)
          GameDataController.gd.setObjectiveDetail("map_restaurant_revealed", TravelAgency.LOCATION_STATUS_REACHABLE);
        if (GameDataController.gd.getObjectiveDetail("map_houseb_revealed") == TravelAgency.LOCATION_STATUS_UNREACHABLE)
          GameDataController.gd.setObjectiveDetail("map_houseb_revealed", TravelAgency.LOCATION_STATUS_REACHABLE);
      }
      if (SceneManager.GetActiveScene().name == "SiderealOutside1" && !GameDataController.gd.getObjective("sidereal_base_located"))
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_cant_leave"));
      }
      else
      {
        GameDataController.gd.setObjective("car_travel", true);
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.car_open);
        PlayerController.pc.setBusy(true);
        PlayerController.pc.spawnName = "InfoExit";
        CurtainController.cc.fadeOut("LocationMap", WalkController.Direction.E, sound: SoundsManagerController.sm.car_start);
      }
    }
  }

  public override void updateState()
  {
    if ((Object) this.trunk == (Object) null)
      this.trunk = GameObject.Find("Trunk");
    if (GameDataController.gd.getObjectiveDetail("car_location") == 0 && SceneManager.GetActiveScene().name == "Barn" || GameDataController.gd.getObjectiveDetail("car_location") == 1 && SceneManager.GetActiveScene().name == "LocationBridge" || GameDataController.gd.getObjectiveDetail("car_location") == 2 && SceneManager.GetActiveScene().name == "LocationGasstation1" || GameDataController.gd.getObjectiveDetail("car_location") == 3 && SceneManager.GetActiveScene().name == "LocationHouseB" || GameDataController.gd.getObjectiveDetail("car_location") == 4 && SceneManager.GetActiveScene().name == "LocationCrashsite1" || GameDataController.gd.getObjectiveDetail("car_location") == 5 && SceneManager.GetActiveScene().name == "LocationRestaurant1" || GameDataController.gd.getObjectiveDetail("car_location") == 6 && SceneManager.GetActiveScene().name == "LocationRV" || GameDataController.gd.getObjectiveDetail("car_location") == 7 && SceneManager.GetActiveScene().name == "HuntersLodgeOutside1" || GameDataController.gd.getObjectiveDetail("car_location") == 8 && SceneManager.GetActiveScene().name == "SiderealOutside1" || GameDataController.gd.getObjectiveDetail("car_location") == 9 && SceneManager.GetActiveScene().name == "CS1" || GameDataController.gd.getObjectiveDetail("car_location") == 10 && SceneManager.GetActiveScene().name == "LocationOutpostOutside1" || GameDataController.gd.getObjectiveDetail("car_location") == 11 && SceneManager.GetActiveScene().name == "LocationBus1" || GameDataController.gd.getObjectiveDetail("car_location") == 12 && SceneManager.GetActiveScene().name == "LocationAirplane1")
    {
      this.colliderManager.setCollider(0);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.trunk.GetComponent<CarTrunk>().setCollider(0);
      GameObject.Find("CarBlock").GetComponent<PolygonCollider2D>().enabled = true;
    }
    else
    {
      this.colliderManager.setCollider(-1);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.trunk.GetComponent<CarTrunk>().setCollider(-1);
      GameObject.Find("CarBlock").GetComponent<PolygonCollider2D>().enabled = false;
    }
    ItemsManager.im.fixGroundItems(new Vector2(this.groundItemsFix_x, this.groundItemsFix_y), new Vector2(this.groundItemsFixShiftX, this.groundItemsFixShiftY));
    ItemsManager.im.initGroundAndInv();
    GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}
