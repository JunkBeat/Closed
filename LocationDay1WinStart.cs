// Decompiled with JetBrains decompiler
// Type: LocationDay1WinStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationDay1WinStart : MonoBehaviour
{
  public LocationDay1WinHouse house;

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
    TimelineAction action1 = new TimelineAction(Timeline.t.textField);
    action1.param = "0";
    Timeline.t.textField.directionY = 1f;
    action1.textWidth = 190;
    Timeline.t.textField.shift.x = -80f;
    GameDataController.Achievement("DAY_1");
    GameDataController.gd.gameTime = 480;
    if (GameDataController.gd.getObjectiveDetail("day1_complete") == 1)
    {
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
      {
        GameDataController.Achievement("P_SPIDERS");
        action1.text = GameStrings.getString(GameStrings.results, "day1_spiders_perfect");
        Timeline.t.addAction(action1);
      }
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
      {
        GameDataController.Achievement("P_GAS");
        action1.text = GameStrings.getString(GameStrings.results, "day1_gas_perfect");
        Timeline.t.addAction(action1);
      }
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      {
        GameDataController.Achievement("P_LOCUST");
        action1.text = GameStrings.getString(GameStrings.results, "day1_bugs_perfect");
        Timeline.t.addAction(action1);
      }
      action1 = new TimelineAction(Timeline.t.textField);
      action1.function = new TimelineFunction(this.continueGame);
      action1.actionWithText = false;
      action1.param = "0";
      Timeline.t.textField.directionY = 1f;
      action1.textWidth = 190;
      Timeline.t.textField.shift.x = -80f;
      action1.text = GameStrings.getString(GameStrings.results, "day1_bonus");
      Timeline.t.addAction(action1);
    }
    if (GameDataController.gd.getObjectiveDetail("day1_complete") == 0)
    {
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
      {
        action1.text = GameStrings.getString(GameStrings.results, "day1_spiders_good");
        Timeline.t.addAction(action1);
      }
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
      {
        action1.text = GameStrings.getString(GameStrings.results, "day1_gas_good");
        Timeline.t.addAction(action1);
      }
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      {
        action1.text = GameStrings.getString(GameStrings.results, "day1_bugs_good");
        Timeline.t.addAction(action1);
      }
      action1 = new TimelineAction(Timeline.t.textField);
      action1.function = new TimelineFunction(this.continueGame);
      action1.actionWithText = false;
      action1.param = "0";
      Timeline.t.textField.directionY = 1f;
      action1.textWidth = 190;
      Timeline.t.textField.shift.x = -80f;
      action1.text = GameStrings.getString(GameStrings.results, "day1_normal");
      Timeline.t.addAction(action1);
    }
    if (GameDataController.gd.getObjectiveDetail("day1_complete") < 0)
    {
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
      {
        action1.text = GameStrings.getString(GameStrings.results, "day1_spiders_poor1") + " " + (object) -GameDataController.gd.getObjectiveDetail("day1_complete") + " " + GameStrings.getString(GameStrings.results, "day1_spiders_poor2");
        Timeline.t.addAction(action1);
      }
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
      {
        action1.text = GameStrings.getString(GameStrings.results, "day1_gas_poor1") + " " + (object) -GameDataController.gd.getObjectiveDetail("day1_complete") + " " + GameStrings.getString(GameStrings.results, "day1_gas_poor2");
        Timeline.t.addAction(action1);
      }
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      {
        action1.text = GameStrings.getString(GameStrings.results, "day1_bugs_poor1") + " " + (object) -GameDataController.gd.getObjectiveDetail("day1_complete") + " " + GameStrings.getString(GameStrings.results, "day1_bugs_poor2");
        Timeline.t.addAction(action1);
      }
      GameDataController.gd.gameTime = 540;
      TimelineAction action2 = new TimelineAction(Timeline.t.textField);
      action2.function = new TimelineFunction(this.continueGame);
      action2.actionWithText = false;
      action2.param = "0";
      Timeline.t.textField.directionY = 1f;
      action2.textWidth = 190;
      Timeline.t.textField.shift.x = -80f;
      action2.text = GameStrings.getString(GameStrings.results, "day1_penalty");
      Timeline.t.addAction(action2);
    }
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_success);
    JukeboxAmbient.jb.changeAmbient((AudioClip) null, 0.0f);
    if (GameDataController.gd.getObjective("base_window_1_net_nailed") || GameDataController.gd.getObjective("base_window_1_net_taped") || GameDataController.gd.getObjective("base_window_1_foil_nailed") || GameDataController.gd.getObjective("base_window_1_foil_taped") || GameDataController.gd.getObjective("base_window_1_bars_nailed") || GameDataController.gd.getObjective("base_window_1_bars_taped"))
      GameDataController.gd.setObjective("base_window1_broken", true);
    if (GameDataController.gd.getObjective("base_window_2_net_nailed") || GameDataController.gd.getObjective("base_window_2_net_taped") || GameDataController.gd.getObjective("base_window_2_foil_nailed") || GameDataController.gd.getObjective("base_window_2_foil_taped") || GameDataController.gd.getObjective("base_window_2_bars_nailed") || GameDataController.gd.getObjective("base_window_2_bars_taped"))
      GameDataController.gd.setObjective("base_window2_broken", true);
    if (GameDataController.gd.getObjective("base_window_3_net_nailed") || GameDataController.gd.getObjective("base_window_3_net_taped") || GameDataController.gd.getObjective("base_window_3_foil_nailed") || GameDataController.gd.getObjective("base_window_3_foil_taped") || GameDataController.gd.getObjective("base_window_3_bars_nailed") || GameDataController.gd.getObjective("base_window_3_bars_taped"))
      GameDataController.gd.setObjective("base_window3_broken", true);
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0 || GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
    {
      if (GameDataController.gd.getObjective("base_window_1_bars") && !GameDataController.gd.getObjective("base_window_1_bars_taped") && !GameDataController.gd.getObjective("base_window_1_bars_nailed"))
      {
        GameDataController.gd.setObjective("base_window_1_bars", false);
        Item[] objArray = new Item[3]
        {
          ItemsManager.im.getItem("window_bars1"),
          ItemsManager.im.getItem("window_bars2"),
          ItemsManager.im.getItem("window_bars3")
        };
        for (int index = 0; index < objArray.Length; ++index)
        {
          if (objArray[index].dataRef.droppedLocation == "window1")
          {
            objArray[index].dataRef.locX = 15;
            objArray[index].dataRef.locY = 25;
            objArray[index].dataRef.droppedLocation = "Location1";
          }
        }
      }
      if (GameDataController.gd.getObjective("base_window_2_bars") && !GameDataController.gd.getObjective("base_window_2_bars_taped") && !GameDataController.gd.getObjective("base_window_2_bars_nailed"))
      {
        GameDataController.gd.setObjective("base_window_2_bars", false);
        Item[] objArray = new Item[3]
        {
          ItemsManager.im.getItem("window_bars1"),
          ItemsManager.im.getItem("window_bars2"),
          ItemsManager.im.getItem("window_bars3")
        };
        for (int index = 0; index < objArray.Length; ++index)
        {
          if (objArray[index].dataRef.droppedLocation == "window2")
          {
            objArray[index].dataRef.locX = 150;
            objArray[index].dataRef.locY = 35;
            objArray[index].dataRef.droppedLocation = "LocationBaseUpstairs";
          }
        }
      }
      if (GameDataController.gd.getObjective("base_window_3_bars") && !GameDataController.gd.getObjective("base_window_3_bars_taped") && !GameDataController.gd.getObjective("base_window_3_bars_nailed"))
      {
        GameDataController.gd.setObjective("base_window_3_bars", false);
        Item[] objArray = new Item[3]
        {
          ItemsManager.im.getItem("window_bars1"),
          ItemsManager.im.getItem("window_bars2"),
          ItemsManager.im.getItem("window_bars3")
        };
        for (int index = 0; index < objArray.Length; ++index)
        {
          if (objArray[index].dataRef.droppedLocation == "window3")
          {
            objArray[index].dataRef.locX = 65;
            objArray[index].dataRef.locY = 25;
            objArray[index].dataRef.droppedLocation = "LocationBaseBathroom";
          }
        }
      }
      if (GameDataController.gd.getObjective("base_window_1_net") && !GameDataController.gd.getObjective("base_window_1_net_taped") && !GameDataController.gd.getObjective("base_window_1_net_nailed"))
      {
        GameDataController.gd.setObjective("base_window_1_net", false);
        Item[] objArray = new Item[3]
        {
          ItemsManager.im.getItem("window_net1"),
          ItemsManager.im.getItem("window_net2"),
          ItemsManager.im.getItem("window_net3")
        };
        for (int index = 0; index < objArray.Length; ++index)
        {
          if (objArray[index].dataRef.droppedLocation == "window1")
          {
            objArray[index].dataRef.locX = 15;
            objArray[index].dataRef.locY = 25;
            objArray[index].dataRef.droppedLocation = "Location1";
          }
        }
      }
      if (GameDataController.gd.getObjective("base_window_2_net") && !GameDataController.gd.getObjective("base_window_2_net_taped") && !GameDataController.gd.getObjective("base_window_2_net_nailed"))
      {
        GameDataController.gd.setObjective("base_window_2_net", false);
        Item[] objArray = new Item[3]
        {
          ItemsManager.im.getItem("window_net1"),
          ItemsManager.im.getItem("window_net2"),
          ItemsManager.im.getItem("window_net3")
        };
        for (int index = 0; index < objArray.Length; ++index)
        {
          if (objArray[index].dataRef.droppedLocation == "window2")
          {
            objArray[index].dataRef.locX = 150;
            objArray[index].dataRef.locY = 35;
            objArray[index].dataRef.droppedLocation = "LocationBaseUpstairs";
          }
        }
      }
      if (GameDataController.gd.getObjective("base_window_3_net") && !GameDataController.gd.getObjective("base_window_3_net_taped") && !GameDataController.gd.getObjective("base_window_3_net_nailed"))
      {
        GameDataController.gd.setObjective("base_window_3_net", false);
        Item[] objArray = new Item[3]
        {
          ItemsManager.im.getItem("window_net1"),
          ItemsManager.im.getItem("window_net2"),
          ItemsManager.im.getItem("window_net3")
        };
        for (int index = 0; index < objArray.Length; ++index)
        {
          if (objArray[index].dataRef.droppedLocation == "window3")
          {
            objArray[index].dataRef.locX = 65;
            objArray[index].dataRef.locY = 25;
            objArray[index].dataRef.droppedLocation = "LocationBaseBathroom";
          }
        }
      }
      if (GameDataController.gd.getObjective("base_window_1_foil") && !GameDataController.gd.getObjective("base_window_1_foil_taped") && !GameDataController.gd.getObjective("base_window_1_foil_nailed"))
      {
        GameDataController.gd.setObjective("base_window_1_foil", false);
        Item[] objArray = new Item[3]
        {
          ItemsManager.im.getItem("window_foil1"),
          ItemsManager.im.getItem("window_foil2"),
          ItemsManager.im.getItem("window_foil3")
        };
        for (int index = 0; index < objArray.Length; ++index)
        {
          if (objArray[index].dataRef.droppedLocation == "window1")
          {
            objArray[index].dataRef.locX = 15;
            objArray[index].dataRef.locY = 25;
            objArray[index].dataRef.droppedLocation = "Location1";
          }
        }
      }
      if (GameDataController.gd.getObjective("base_window_2_foil") && !GameDataController.gd.getObjective("base_window_2_foil_taped") && !GameDataController.gd.getObjective("base_window_2_foil_nailed"))
      {
        GameDataController.gd.setObjective("base_window_2_foil", false);
        Item[] objArray = new Item[3]
        {
          ItemsManager.im.getItem("window_foil1"),
          ItemsManager.im.getItem("window_foil2"),
          ItemsManager.im.getItem("window_foil3")
        };
        for (int index = 0; index < objArray.Length; ++index)
        {
          if (objArray[index].dataRef.droppedLocation == "window2")
          {
            objArray[index].dataRef.locX = 150;
            objArray[index].dataRef.locY = 35;
            objArray[index].dataRef.droppedLocation = "LocationBaseUpstairs";
          }
        }
      }
      if (GameDataController.gd.getObjective("base_window_3_foil") && !GameDataController.gd.getObjective("base_window_3_foil_taped") && !GameDataController.gd.getObjective("base_window_3_foil_nailed"))
      {
        GameDataController.gd.setObjective("base_window_3_foil", false);
        Item[] objArray = new Item[3]
        {
          ItemsManager.im.getItem("window_foil1"),
          ItemsManager.im.getItem("window_foil2"),
          ItemsManager.im.getItem("window_foil3")
        };
        for (int index = 0; index < objArray.Length; ++index)
        {
          if (objArray[index].dataRef.droppedLocation == "window3")
          {
            objArray[index].dataRef.locX = 65;
            objArray[index].dataRef.locY = 25;
            objArray[index].dataRef.droppedLocation = "LocationBaseBathroom";
          }
        }
      }
    }
    if (ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("outside") != -1 || ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("location1") != -1 || ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("location2") != -1 || ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("upstairs") != -1 || ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("locationbase") != -1)
    {
      ItemsManager.im.getItem("bear_trap_1b").dataRef.droppedLocation = ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation;
      ItemsManager.im.getItem("bear_trap_1b").dataRef.locX = ItemsManager.im.getItem("bear_trap_1").dataRef.locX;
      ItemsManager.im.getItem("bear_trap_1b").dataRef.locY = ItemsManager.im.getItem("bear_trap_1").dataRef.locY;
      ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation = "nowhere";
    }
    if (ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("outside") != -1 || ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("location1") != -1 || ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("location2") != -1 || ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("upstairs") != -1 || ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("locationbase") != -1)
    {
      ItemsManager.im.getItem("bear_trap_2b").dataRef.droppedLocation = ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation;
      ItemsManager.im.getItem("bear_trap_2b").dataRef.locX = ItemsManager.im.getItem("bear_trap_2").dataRef.locX;
      ItemsManager.im.getItem("bear_trap_2b").dataRef.locY = ItemsManager.im.getItem("bear_trap_2").dataRef.locY;
      ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation = "nowhere";
    }
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && GameDataController.gd.getObjectiveDetail("day1_complete") != 1)
    {
      if (InventoryController.ic.isItemEquipped("rifle_5"))
      {
        ItemsManager.im.getItem("rifle_5").dataRef.droppedLocation = "nowhere";
        ItemsManager.im.getItem("rifle_0").dataRef.droppedLocation = "inventory";
        ItemsManager.im.getItem("rifle_0").dataRef.locX = ItemsManager.im.getItem("rifle_5").dataRef.locX;
        ItemsManager.im.getItem("rifle_0").dataRef.locY = ItemsManager.im.getItem("rifle_5").dataRef.locY;
      }
      if (InventoryController.ic.isItemEquipped("flamethrower"))
      {
        ItemsManager.im.getItem("flamethrower").dataRef.droppedLocation = "nowhere";
        ItemsManager.im.getItem("flamethrower_empty").dataRef.droppedLocation = "inventory";
        ItemsManager.im.getItem("flamethrower_empty").dataRef.locX = ItemsManager.im.getItem("flamethrower").dataRef.locX;
        ItemsManager.im.getItem("flamethrower_empty").dataRef.locY = ItemsManager.im.getItem("flamethrower").dataRef.locY;
      }
    }
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0 && GameDataController.gd.getObjectiveDetail("day1_complete") != 1)
    {
      if (InventoryController.ic.isItemEquipped("rifle_6"))
      {
        ItemsManager.im.getItem("rifle_6").dataRef.droppedLocation = "nowhere";
        ItemsManager.im.getItem("rifle_0").dataRef.droppedLocation = "inventory";
        ItemsManager.im.getItem("rifle_0").dataRef.locX = ItemsManager.im.getItem("rifle_6").dataRef.locX;
        ItemsManager.im.getItem("rifle_0").dataRef.locY = ItemsManager.im.getItem("rifle_6").dataRef.locY;
      }
      if (InventoryController.ic.isItemEquipped("flamethrower"))
      {
        ItemsManager.im.getItem("flamethrower").dataRef.droppedLocation = "nowhere";
        ItemsManager.im.getItem("flamethrower_empty").dataRef.droppedLocation = "inventory";
        ItemsManager.im.getItem("flamethrower_empty").dataRef.locX = ItemsManager.im.getItem("flamethrower").dataRef.locX;
        ItemsManager.im.getItem("flamethrower_empty").dataRef.locY = ItemsManager.im.getItem("flamethrower").dataRef.locY;
      }
    }
    ItemsManager.im.getItem("sonic2").dataRef.droppedLocation = ItemsManager.im.getItem("sonic").dataRef.droppedLocation;
    ItemsManager.im.getItem("sonic2").dataRef.locX = ItemsManager.im.getItem("sonic").dataRef.locX;
    ItemsManager.im.getItem("sonic2").dataRef.locY = ItemsManager.im.getItem("sonic").dataRef.locY;
    ItemsManager.im.getItem("sonic").dataRef.droppedLocation = "nowhere";
    if (!GameDataController.gd.getObjective("barn_pump_started"))
      return;
    GameDataController.gd.setObjective("barn_pump_fueled", false);
    GameDataController.gd.setObjective("barn_pump_started", false);
  }

  private void continueGame(string param)
  {
    this.house.startAnim();
    JukeboxMusic.jb.changeMusic((AudioClip) null);
  }

  private void Update()
  {
  }
}
