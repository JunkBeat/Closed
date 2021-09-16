// Decompiled with JetBrains decompiler
// Type: BarnCar
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarnCar : ObjectActionController
{
  public Sprite wheel_broken;
  public Sprite broken;
  public Sprite fixedC;
  public GameObject action1;
  public GameObject action2;
  public float groundItemsFix_x;
  public float groundItemsFix_y;
  public float groundItemsFixShiftX;
  public float groundItemsFixShiftY;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_ne";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "car";
    this.range = 2f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("wheel", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("car_battery", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ignitioncoil", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister_full", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister2_full", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister_empty", GameStrings.getString(GameStrings.actions, "canister_is_empty"), anim: string.Empty));
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

  public void yesCoil()
  {
    InventoryController.ic.removeItem("ignitioncoil");
    GameDataController.gd.setObjective("barn_car_coil_repaired", true);
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.NE, flipX: true, actionAfterFade: new CurtainController.Delegate(this.sayAboutCarPart));
  }

  public void yesBattery()
  {
    InventoryController.ic.removeItem("car_battery");
    GameDataController.gd.setObjective("barn_car_battery_repaired", true);
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.NE, flipX: true, actionAfterFade: new CurtainController.Delegate(this.sayAboutCarPart));
  }

  public void yesWheel()
  {
    InventoryController.ic.removeItem("wheel");
    GameDataController.gd.setObjective("barn_car_wheel_repaired", true);
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.NE, flipX: true, actionAfterFade: new CurtainController.Delegate(this.sayAboutCarPart));
  }

  public void yesExamine()
  {
    GameDataController.gd.setObjective("barn_car_inspected", true);
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.NE, flipX: true, actionAfterFade: new CurtainController.Delegate(this.sayAboutCarExamine));
  }

  public void sayAboutCarFuel() => PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_car_fueled"));

  public void sayAboutCarPart() => PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_car_installed"));

  public void sayAboutCarExamine()
  {
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_car_examined"));
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = PlayerController.pc.textField,
      text = GameStrings.getString(GameStrings.actions, "barn_car_examined")
    });
    this.sayWhatsWrong();
  }

  public bool sayWhatsWrong()
  {
    TimelineAction action = (TimelineAction) null;
    if (!GameDataController.gd.getObjective("barn_car_wheel_repaired"))
    {
      action = new TimelineAction();
      action.textfield = PlayerController.pc.textField;
      action.text = GameStrings.getString(GameStrings.actions, "barn_car_missing_wheel");
      Timeline.t.addAction(action);
    }
    if (!GameDataController.gd.getObjective("barn_car_coil_repaired"))
    {
      action = new TimelineAction();
      action.textfield = PlayerController.pc.textField;
      action.text = GameStrings.getString(GameStrings.actions, "barn_car_coil_missing");
      Timeline.t.addAction(action);
    }
    if (!GameDataController.gd.getObjective("barn_car_battery_repaired"))
    {
      action = new TimelineAction();
      action.textfield = PlayerController.pc.textField;
      action.text = GameStrings.getString(GameStrings.actions, "barn_car_battery_missing");
      Timeline.t.addAction(action);
    }
    if (!GameDataController.gd.getObjective("barn_car_refueled"))
    {
      action = new TimelineAction();
      action.textfield = PlayerController.pc.textField;
      action.text = GameStrings.getString(GameStrings.actions, "barn_car_fuel_missing");
      Timeline.t.addAction(action);
    }
    return action == null;
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("base_discovered"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_pipe_first"));
    else if (this.usedItem == "wheel")
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "barn_car_part"), yesClick: new Button.Delegate(this.yesWheel), time: 15, timeSaver: 2);
    else if (this.usedItem != string.Empty && !GameDataController.gd.getObjective("barn_car_inspected"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_car_uninspected"));
    else if (this.usedItem == string.Empty)
    {
      if (!GameDataController.gd.getObjective("barn_car_inspected"))
      {
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "barn_car_examine"), yesClick: new Button.Delegate(this.yesExamine), time: 15);
      }
      else
      {
        if (!this.sayWhatsWrong())
          return;
        GameDataController.gd.setObjective("car_travel", true);
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.car_open);
        PlayerController.pc.setBusy(true);
        PlayerController.pc.spawnName = "InfoExit";
        CurtainController.cc.fadeOut("LocationMap", WalkController.Direction.E, sound: SoundsManagerController.sm.car_start);
      }
    }
    else if (this.usedItem == "ignitioncoil")
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "barn_car_part"), yesClick: new Button.Delegate(this.yesCoil), time: 15, timeSaver: 2);
    else if (this.usedItem == "car_battery")
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "barn_car_part"), yesClick: new Button.Delegate(this.yesBattery), time: 15, timeSaver: 2);
    else if (this.usedItem == "canister_full")
    {
      if (GameDataController.gd.getObjective("barn_car_refueled") && GameDataController.gd.getObjectiveDetail("barn_car_refueled") == GameDataController.MAX_FUEL)
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "car_already_fueled"));
      else
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "barn_car_refuel"), yesClick: new Button.Delegate(this.yesFuel));
    }
    else
    {
      if (!(this.usedItem == "canister2_full"))
        return;
      if (GameDataController.gd.getObjective("barn_car_refueled") && GameDataController.gd.getObjectiveDetail("barn_car_refueled") == GameDataController.MAX_FUEL)
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "car_already_fueled"));
      else
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "barn_car_refuel"), yesClick: new Button.Delegate(this.yesFuel2));
    }
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (!GameDataController.gd.getObjective("barn_car_wheel_repaired"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.wheel_broken;
      this.actionMarker = this.action1;
    }
    else if (!GameDataController.gd.getObjective("barn_car_battery_repaired") || !GameDataController.gd.getObjective("barn_car_coil_repaired"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.broken;
      this.actionMarker = this.action1;
    }
    else
    {
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.fixedC;
      if (GameDataController.gd.getObjective("barn_car_refueled"))
      {
        if (GameDataController.KART)
        {
          GameDataController.persistentData.kong_car = true;
          GameDataController.gd.PersistentSave();
        }
        this.actionMarker = this.action2;
      }
      else
        this.actionMarker = this.action1;
    }
    if (GameDataController.gd.getObjectiveDetail("car_location") == 0 && SceneManager.GetActiveScene().name == "Barn" || GameDataController.gd.getObjectiveDetail("car_location") == 1 && SceneManager.GetActiveScene().name == "LocationBridge" || GameDataController.gd.getObjectiveDetail("car_location") == 2 && SceneManager.GetActiveScene().name == "LocationGasstation1" || GameDataController.gd.getObjectiveDetail("car_location") == 3 && SceneManager.GetActiveScene().name == "LocationHouseB" || GameDataController.gd.getObjectiveDetail("car_location") == 4 && SceneManager.GetActiveScene().name == "LocationCrashsite1" || GameDataController.gd.getObjectiveDetail("car_location") == 5 && SceneManager.GetActiveScene().name == "LocationRestaurant1")
    {
      this.colliderManager.setCollider(0);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("CarBlock").GetComponent<PolygonCollider2D>().enabled = true;
    }
    else
    {
      this.colliderManager.setCollider(-1);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
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
