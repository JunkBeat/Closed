// Decompiled with JetBrains decompiler
// Type: LocationDay3WinStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationDay3WinStart : MonoBehaviour
{
  public SpriteRenderer noroof;

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
    GameDataController.Achievement("DAY_3");
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_success);
    GameDataController.gd.gameTime = 480;
    this.noroof.enabled = false;
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && (!GameDataController.gd.getObjective("lighting_rod_installed") || GameDataController.gd.getObjectiveDetail("day3_complete") < 1))
      this.noroof.enabled = true;
    if (GameDataController.gd.getObjective("barn_pump_started"))
    {
      GameDataController.gd.setObjective("barn_pump_fueled", false);
      GameDataController.gd.setObjective("barn_pump_started", false);
    }
    if (InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("heat_absorber1A"))
      InventoryController.ic.removeItem("heat_absorber1A");
    if (InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("heat_absorber2A"))
      InventoryController.ic.removeItem("heat_absorber2A");
    if (InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("heat_absorber3A"))
      InventoryController.ic.removeItem("heat_absorber3A");
    ItemsManager.im.getItem("heat_absorber1A").dataRef.droppedLocation = "nowhere";
    ItemsManager.im.getItem("heat_absorber2A").dataRef.droppedLocation = "nowhere";
    ItemsManager.im.getItem("heat_absorber3A").dataRef.droppedLocation = "nowhere";
    if (GameDataController.gd.getObjective("base_fireplace_lit"))
    {
      GameDataController.gd.setObjective("base_fireplace_lit", false);
      GameDataController.gd.setObjective("chimney_wood", false);
      GameDataController.gd.setObjectiveDetail("chimney_wood", 0);
      GameDataController.gd.setObjective("chimney_note", false);
      GameDataController.gd.setObjective("chimney_papers", false);
      GameDataController.gd.setObjective("chimney_cash", false);
      GameDataController.gd.setObjective("chimney_charcoal", false);
      GameDataController.gd.setObjective("chimney_bag", false);
      GameDataController.gd.setObjective("basket_wood", false);
      GameDataController.gd.setObjectiveDetail("basket_wood", 0);
      GameDataController.gd.setObjective("basket_note", false);
      GameDataController.gd.setObjective("basket_papers", false);
      GameDataController.gd.setObjective("basket_cash", false);
      GameDataController.gd.setObjective("basket_charcoal", false);
      GameDataController.gd.setObjective("basket_bag", false);
    }
    if (ItemsManager.im.getItem("gasheater").dataRef.droppedLocation.ToLower().IndexOf("nowhere") == -1 && ItemsManager.im.getItem("gasheater").dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1)
    {
      ItemsManager.im.getItem("gasheater_empty").dataRef.droppedLocation = ItemsManager.im.getItem("gasheater").dataRef.droppedLocation;
      ItemsManager.im.getItem("gasheater_empty").dataRef.locX = ItemsManager.im.getItem("gasheater").dataRef.locX;
      ItemsManager.im.getItem("gasheater_empty").dataRef.locY = ItemsManager.im.getItem("gasheater").dataRef.locY;
      ItemsManager.im.getItem("gasheater").dataRef.droppedLocation = "nowhere";
    }
    TimelineAction action1 = new TimelineAction(Timeline.t.textField);
    if (GameDataController.gd.getObjectiveDetail("day3_complete") == 1)
    {
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
      {
        GameDataController.Achievement("P_BANDITS");
        action1.text = GameStrings.getString(GameStrings.results, "day3_thugs_perfect");
        Timeline.t.addAction(action1);
      }
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
      {
        GameDataController.Achievement("P_STORM");
        action1.text = GameStrings.getString(GameStrings.results, "day3_storm_perfect");
        Timeline.t.addAction(action1);
      }
      TimelineAction action2 = new TimelineAction(Timeline.t.textField);
      action2.function = new TimelineFunction(this.continueGame);
      action2.actionWithText = false;
      action2.param = "0";
      Timeline.t.textField.directionY = 1f;
      action2.textWidth = 190;
      Timeline.t.textField.shift.x = -80f;
      action2.text = GameStrings.getString(GameStrings.results, "day3_bonus");
      Timeline.t.addAction(action2);
    }
    else if (GameDataController.gd.getObjectiveDetail("day3_complete") == 0)
    {
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
      {
        action1.text = GameStrings.getString(GameStrings.results, "day3_thugs_good");
        Timeline.t.addAction(action1);
      }
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
      {
        action1.text = GameStrings.getString(GameStrings.results, "day3_storm_good");
        Timeline.t.addAction(action1);
      }
      TimelineAction action3 = new TimelineAction(Timeline.t.textField);
      action3.function = new TimelineFunction(this.continueGame);
      action3.actionWithText = false;
      action3.param = "0";
      Timeline.t.textField.directionY = 1f;
      action3.textWidth = 190;
      Timeline.t.textField.shift.x = -80f;
      action3.text = GameStrings.getString(GameStrings.results, "day3_normal");
      Timeline.t.addAction(action3);
    }
    else if (GameDataController.gd.getObjectiveDetail("day3_complete") < 0)
    {
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
      {
        action1.text = GameStrings.getString(GameStrings.results, "day3_thugs_poor");
        Timeline.t.addAction(action1);
      }
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
      {
        action1.text = GameStrings.getString(GameStrings.results, "day3_storm_poor");
        Timeline.t.addAction(action1);
      }
      TimelineAction action4 = new TimelineAction(Timeline.t.textField);
      action4.function = new TimelineFunction(this.continueGame);
      action4.actionWithText = false;
      action4.param = "0";
      Timeline.t.textField.directionY = 1f;
      action4.textWidth = 190;
      Timeline.t.textField.shift.x = -80f;
      if (GameDataController.gd.getObjectiveDetail("npc2_alive") == 2 && GameDataController.gd.getObjectiveDetail("npc3_alive") == 2)
      {
        action4.text = GameStrings.getString(GameStrings.results, "day3_penalty2");
        GameDataController.gd.gameTime = 600;
      }
      else
      {
        action4.text = GameStrings.getString(GameStrings.results, "day3_penalty1");
        GameDataController.gd.gameTime = 540;
      }
      Timeline.t.addAction(action4);
    }
    for (int index = 1; index <= 4; ++index)
    {
      if (ItemsManager.im.getItem("bear_trap_" + (object) index).dataRef.droppedLocation.ToLower().IndexOf("outside") != -1 || ItemsManager.im.getItem("bear_trap_" + (object) index).dataRef.droppedLocation.ToLower().IndexOf("location1") != -1 || ItemsManager.im.getItem("bear_trap_" + (object) index).dataRef.droppedLocation.ToLower().IndexOf("location2") != -1 || ItemsManager.im.getItem("bear_trap_" + (object) index).dataRef.droppedLocation.ToLower().IndexOf("upstairs") != -1 || ItemsManager.im.getItem("bear_trap_" + (object) index).dataRef.droppedLocation.ToLower().IndexOf("locationbase") != -1)
        ItemsManager.im.getItem("bear_trap_" + (object) index).dataRef.droppedLocation = "nowhere";
    }
    if (ItemsManager.im.getItem("whiskey").dataRef.droppedLocation == "CS3")
      ItemsManager.im.getItem("whiskey").dataRef.droppedLocation = "nowhere";
    GameDataController.gd.setObjectiveDetail("map_outpost_revealed", TravelAgency.LOCATION_STATUS_REACHABLE);
    GameDataController.gd.setObjective("map_outpost_revealed", false);
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
    {
      ItemsManager.im.getItem("gloves").dataRef.droppedLocation = "LocationRestaurant3";
      ItemsManager.im.getItem("gloves").dataRef.locX = 110;
      ItemsManager.im.getItem("gloves").dataRef.locY = 50;
    }
    if (GameDataController.gd.getObjective("cs_engine_started"))
    {
      GameDataController.gd.setObjective("cs_engine_fueled", false);
      GameDataController.gd.setObjective("cs_engine_started", false);
    }
    string str1 = string.Empty;
    string str2 = !GameDataController.gd.getObjective("npc3_joined") ? "not joined/" : "joined/";
    if (GameDataController.gd.getObjective("npc3_alive"))
    {
      str1 = str2 + "alive";
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("npc3_alive") == 0)
        str2 += "died on day 2";
      if (GameDataController.gd.getObjectiveDetail("npc3_alive") == 1)
        str2 += "died in Sidereal";
      if (GameDataController.gd.getObjectiveDetail("npc3_alive") == 2)
        str1 = str2 + "died on day 3";
    }
    string str3 = string.Empty;
    string str4 = !GameDataController.gd.getObjective("npc2_joined") ? "not joined/" : "joined/";
    if (GameDataController.gd.getObjective("npc2_alive"))
    {
      str3 = str4 + "alive";
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("npc2_alive") == 0)
        str4 += "died on day 2";
      if (GameDataController.gd.getObjectiveDetail("npc2_alive") == 1)
        str4 += "died in Sidereal";
      if (GameDataController.gd.getObjectiveDetail("npc2_alive") == 2)
        str3 = str4 + "died on day 3";
    }
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") != 1)
      return;
    if (GameDataController.gd.getObjective("base_window_1_net_nailed") || GameDataController.gd.getObjective("base_window_1_net_taped") || GameDataController.gd.getObjective("base_window_1_foil_nailed") || GameDataController.gd.getObjective("base_window_1_foil_taped") || GameDataController.gd.getObjective("base_window_1_bars_nailed") || GameDataController.gd.getObjective("base_window_1_bars_taped") || GameDataController.gd.getObjective("base_window_1_board_taped") || GameDataController.gd.getObjective("base_window_1_board_nailed"))
      GameDataController.gd.setObjective("base_window1_broken", true);
    if (GameDataController.gd.getObjective("base_window_2_net_nailed") || GameDataController.gd.getObjective("base_window_2_net_taped") || GameDataController.gd.getObjective("base_window_2_foil_nailed") || GameDataController.gd.getObjective("base_window_2_foil_taped") || GameDataController.gd.getObjective("base_window_2_board_nailed") || GameDataController.gd.getObjective("base_window_2_board_taped") || GameDataController.gd.getObjective("base_window_2_bars_nailed") || GameDataController.gd.getObjective("base_window_2_bars_taped"))
      GameDataController.gd.setObjective("base_window2_broken", true);
    if (!GameDataController.gd.getObjective("base_window_3_net_nailed") && !GameDataController.gd.getObjective("base_window_3_net_taped") && !GameDataController.gd.getObjective("base_window_3_foil_nailed") && !GameDataController.gd.getObjective("base_window_3_foil_taped") && !GameDataController.gd.getObjective("base_window_3_board_nailed") && !GameDataController.gd.getObjective("base_window_3_board_taped") && !GameDataController.gd.getObjective("base_window_3_bars_nailed") && !GameDataController.gd.getObjective("base_window_3_bars_taped"))
      return;
    GameDataController.gd.setObjective("base_window3_broken", true);
  }

  private void continueGame(string param)
  {
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("LocationDream4", WalkController.Direction.E);
  }

  private void Update()
  {
  }
}
