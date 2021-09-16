// Decompiled with JetBrains decompiler
// Type: CarTrunk
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;
using UnityEngine.SceneManagement;

public class CarTrunk : ObjectActionController
{
  public Sprite sign;
  public float timeToOpenAgain;
  public GameObject actionMarker1;
  public GameObject actionMarker2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "car_trunk";
    this.range = 2f;
    this.allowAllItems = true;
    this.updateState();
  }

  private void Update()
  {
    if (InventoryButtonController.ibc.justClosed)
    {
      this.timeToOpenAgain += Time.deltaTime;
      if ((double) this.timeToOpenAgain >= 0.25)
      {
        InventoryButtonController.ibc.justClosed = false;
        this.timeToOpenAgain = 0.0f;
      }
    }
    if (!(bool) (Object) this.actionMarker1 || !(bool) (Object) this.actionMarker2)
      return;
    if ((double) PlayerController.wc.currentXY.y < 30.0)
      this.actionMarker = this.actionMarker1;
    else
      this.actionMarker = this.actionMarker2;
  }

  public override void clickAction()
  {
    if (InventoryButtonController.ibc.justClosed)
      return;
    if (this.usedItem == string.Empty)
    {
      if (!InventoryButtonController.ibc.isItOpen())
        InventoryButtonController.ibc.openTrunk();
      else
        InventoryButtonController.ibc.close();
    }
    else
    {
      if ((double) ItemsManager.im.getItem(this.usedItem).weight < 0.0)
        return;
      InventoryController.ic.putItemInTrunk(this.usedItem);
    }
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjectiveDetail("car_location") == 0 && SceneManager.GetActiveScene().name == "Barn" || GameDataController.gd.getObjectiveDetail("car_location") == 1 && SceneManager.GetActiveScene().name == "LocationBridge" || GameDataController.gd.getObjectiveDetail("car_location") == 2 && SceneManager.GetActiveScene().name == "LocationGasstation1" || GameDataController.gd.getObjectiveDetail("car_location") == 3 && SceneManager.GetActiveScene().name == "LocationHouseB" || GameDataController.gd.getObjectiveDetail("car_location") == 4 && SceneManager.GetActiveScene().name == "LocationCrashsite1" || GameDataController.gd.getObjectiveDetail("car_location") == 5 && SceneManager.GetActiveScene().name == "LocationRestaurant1" || GameDataController.gd.getObjectiveDetail("car_location") == 6 && SceneManager.GetActiveScene().name == "LocationRV" || GameDataController.gd.getObjectiveDetail("car_location") == 7 && SceneManager.GetActiveScene().name == "HuntersLodgeOutside1" || GameDataController.gd.getObjectiveDetail("car_location") == 8 && SceneManager.GetActiveScene().name == "SiderealOutside1" || GameDataController.gd.getObjectiveDetail("car_location") == 9 && SceneManager.GetActiveScene().name == "CS1" || GameDataController.gd.getObjectiveDetail("car_location") == 10 && SceneManager.GetActiveScene().name == "LocationOutpostOutside1" || GameDataController.gd.getObjectiveDetail("car_location") == 11 && SceneManager.GetActiveScene().name == "LocationBus1" || GameDataController.gd.getObjectiveDetail("car_location") == 12 && SceneManager.GetActiveScene().name == "LocationAirplane1")
      this.colliderManager.setCollider(0);
    else
      this.colliderManager.setCollider(-1);
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
