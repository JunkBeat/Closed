// Decompiled with JetBrains decompiler
// Type: JournalTexts
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JournalTexts : MonoBehaviour
{
  public static string textToType = string.Empty;
  public static string textToType2 = string.Empty;
  public static List<Objective> journalTimeItems;
  public static JournalButtonController jbc;

  private void Start()
  {
  }

  private void Update()
  {
  }

  private static bool anotherText(string condition, string text) => JournalTexts.anotherText(GameDataController.gd.getObjective(condition), text, string.Empty);

  private static int findOldestJournalEntry()
  {
    if (GameDataController.gd.journals.Count == 0)
      return 0;
    int[] numArray = new int[GameDataController.gd.journals.Count];
    for (int index = 0; index < GameDataController.gd.journals.Count; ++index)
    {
      numArray[index] = GameDataController.gd.journals[index].detail - GameDataController.gd.getCurrentDay() * 10000000 - GameDataController.gd.gameTime * 1000;
      if (numArray[index] < 0)
        numArray[index] = 0;
    }
    return ((IEnumerable<int>) numArray).Max();
  }

  private static bool anotherText(bool condition, string text, string text2 = "")
  {
    if (GameDataController.gd.getJournalDetail(text) == -100)
    {
      MonoBehaviour.print((object) ("MISSING JOURNAL DATA FOR " + text));
      GameDataController.gd.journals.Add(new Objective(text, false));
    }
    if (condition)
    {
      if (GameDataController.gd.getJournalDetail(string.Empty + text) > 0 && GameDataController.gd.getJournalDetail(string.Empty + text) < 10000000)
        GameDataController.gd.setJournalDetail(text, GameDataController.gd.getJournalDetail(string.Empty + text) * 1000);
      if (GameDataController.gd.getJournalDetail(string.Empty + text) == 0)
      {
        int num = JournalTexts.findOldestJournalEntry() + 1;
        if (num > 999)
          num = 999;
        GameDataController.gd.setJournalDetail(string.Empty + text, GameDataController.gd.gameTime * 1000 + GameDataController.gd.getCurrentDay() * 10000000 + num);
        GameDataController.gd.setJournalDetail("journal_changed", 1);
      }
      else if (GameDataController.gd.getJournalDetail(string.Empty + text) < GameDataController.gd.getCurrentDay() * 10000000)
        GameDataController.gd.setJournalDetail(string.Empty + text, -1);
      MonoBehaviour.print((object) ("CREATING NEW JOURNAL TIME ITEM: " + text + " | " + (object) GameDataController.gd.getJournalDetail(string.Empty + text)));
      if (text2 == string.Empty)
        text2 = text;
      JournalTexts.journalTimeItems.Add(new Objective(text2, false, GameDataController.gd.getJournalDetail(string.Empty + text) - GameDataController.gd.getCurrentDay() * 10000000));
      return true;
    }
    if (GameDataController.gd.getJournalDetail(string.Empty + text) != 0)
      GameDataController.gd.setJournalDetail(string.Empty + text, 0);
    return false;
  }

  public static string pickTexts(int chapter, bool updateNumber = false)
  {
    JournalTexts.textToType = string.Empty;
    JournalTexts.textToType2 = string.Empty;
    JournalTexts.journalTimeItems = new List<Objective>();
    if (chapter == 1)
      JournalTexts.textToType = JournalTexts.chapter1Texts();
    if (chapter == 2)
      JournalTexts.textToType = JournalTexts.chapter2Texts();
    if (chapter == 3)
      JournalTexts.textToType = JournalTexts.chapter3Texts();
    if (chapter == 4)
      JournalTexts.textToType = JournalTexts.chapter4Texts();
    JournalTexts.journalTimeItems.Sort((Comparison<Objective>) ((x, y) =>
    {
      if (x.detail > y.detail)
        return 1;
      return x.detail < y.detail ? -1 : 0;
    }));
    int num = -10;
    bool flag = false;
    for (int index = 0; index < JournalTexts.journalTimeItems.Count; ++index)
    {
      if (JournalTexts.journalTimeItems[index].detail < 0)
        flag = true;
    }
    if (flag)
      JournalTexts.textToType = JournalTexts.textToType + " ^ " + GameStrings.getString(GameStrings.journal, "yesterday");
    for (int index = 0; index < JournalTexts.journalTimeItems.Count; ++index)
    {
      if (JournalTexts.journalTimeItems[index].detail < 0)
        JournalTexts.textToType = JournalTexts.textToType + " ^ " + GameStrings.getString(GameStrings.gui, "journal_bullet") + GameStrings.getString(GameStrings.journal, JournalTexts.journalTimeItems[index].id);
    }
    for (int index = 0; index < JournalTexts.journalTimeItems.Count; ++index)
    {
      if (JournalTexts.journalTimeItems[index].detail > 0)
      {
        JournalTexts.textToType += " ^ ^";
        if (num != JournalTexts.journalTimeItems[index].detail / 1000)
        {
          JournalTexts.textToType = JournalTexts.textToType + ClockController.getClockTime(JournalTexts.journalTimeItems[index].detail / 1000) + " ^";
          num = JournalTexts.journalTimeItems[index].detail / 1000;
        }
        JournalTexts.textToType = JournalTexts.textToType + GameStrings.getString(GameStrings.gui, "journal_bullet") + GameStrings.getString(GameStrings.journal, JournalTexts.journalTimeItems[index].id);
      }
    }
    JournalTexts.textToType = JournalTexts.textToType + " ^ ^ " + JournalTexts.textToType2;
    if (!updateNumber)
    {
      if ((UnityEngine.Object) JournalTexts.jbc == (UnityEngine.Object) null)
      {
        GameObject gameObject = GameObject.Find("journal");
        if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
          JournalTexts.jbc = gameObject.GetComponent<JournalButtonController>();
      }
      if ((UnityEngine.Object) JournalTexts.jbc != (UnityEngine.Object) null)
      {
        if (GameDataController.gd.getJournalDetail("journal_changed") == 1)
        {
          MonoBehaviour.print((object) "JOURNAL WARNING VISIBLE");
          JournalTexts.jbc.setWarning(true);
        }
        else
          JournalTexts.jbc.setWarning(false);
      }
    }
    return JournalTexts.textToType;
  }

  public static string chapter4Texts()
  {
    JournalTexts.textToType = GameStrings.getString(GameStrings.journal, "entry_intro_day4_intro");
    bool flag = false;
    if (!GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjectiveDetail("npc3_alive") == 2 && GameDataController.gd.getObjective("npc3_joined"))
    {
      JournalTexts.textToType = JournalTexts.textToType + " " + GameStrings.getString(GameStrings.journal, "entry_intro_day4_cody_dead");
      flag = true;
    }
    if (!GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjectiveDetail("npc2_alive") == 2 && GameDataController.gd.getObjective("npc2_joined"))
    {
      flag = true;
      JournalTexts.textToType = JournalTexts.textToType + " " + GameStrings.getString(GameStrings.journal, "entry_intro_day4_barry_dead");
    }
    if (flag)
      JournalTexts.textToType = GameDataController.gd.getObjective("npc2_alive") || GameDataController.gd.getObjectiveDetail("npc2_alive") != 2 || !GameDataController.gd.getObjective("npc2_joined") || GameDataController.gd.getObjective("npc3_alive") || GameDataController.gd.getObjectiveDetail("npc3_alive") != 2 || !GameDataController.gd.getObjective("npc3_joined") ? JournalTexts.textToType + " " + GameStrings.getString(GameStrings.journal, "day4_funeral_b") : JournalTexts.textToType + " " + GameStrings.getString(GameStrings.journal, "day4_funeral_a");
    JournalTexts.textToType = JournalTexts.textToType + " " + GameStrings.getString(GameStrings.journal, "entry_intro_day4_both");
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
    {
      JournalTexts.anotherText(!GameDataController.gd.getObjective("thug_to_kill_bathroom") && GameDataController.gd.getObjective("thug_killed_bathroom"), "day4_razor_killed", string.Empty);
      JournalTexts.anotherText(!GameDataController.gd.getObjective("thug_to_kill_bathroom") && !GameDataController.gd.getObjective("thug_killed_bathroom"), "day4_razor_spared", string.Empty);
    }
    JournalTexts.anotherText("visited_outpost1", "day4_outpost_arrive");
    JournalTexts.anotherText("visited_outpost5", "day4_outpost_spaceship");
    JournalTexts.anotherText("outpost_hatch_open", "day4_hatch_open");
    int num = 0 + GameDataController.gd.getObjectiveDetail("outpost_score_a") + GameDataController.gd.getObjectiveDetail("outpost_score_b") + GameDataController.gd.getObjectiveDetail("outpost_score_c") + GameDataController.gd.getObjectiveDetail("outpost_score_d") + GameDataController.gd.getObjectiveDetail("outpost_score_e");
    if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 0)
    {
      JournalTexts.anotherText(num > 0, "day4_outpost_air_mixture", string.Empty);
      JournalTexts.anotherText("outpost_lioh_filters_inserted", "day4_outpost_lioh");
      JournalTexts.anotherText("outpost_air_tanks_inserted", "day4_outpost_airtanks");
      JournalTexts.anotherText("outpost_hull_repaired_inside", "day4_outpost_hullinside");
      JournalTexts.anotherText("barry_pills_taken", "day4_outpost_barrypills");
      JournalTexts.anotherText("cody_pills_taken", "day4_outpost_codypills");
      JournalTexts.anotherText("cate_pills_taken", "day4_outpost_catepills");
    }
    else
    {
      JournalTexts.anotherText(num > 0, "day4_outpost_fuel_mixture", string.Empty);
      JournalTexts.anotherText("outpost_navigation_chip_inserted", "day4_outpost_navchip");
      JournalTexts.anotherText("outpost_calibrator_inserted", "day4_outpost_calibrator");
      JournalTexts.anotherText("outpost_catalyst_used", "day4_outpost_catlyst");
      JournalTexts.anotherText("outpost_hull_repaired_outside", "day4_outpost_hulloutside");
    }
    int count = JournalTexts.journalTimeItems.Count;
    if (!GameDataController.gd.getObjective("visited_outpost1"))
      JournalTexts.textToType2 += GameStrings.getString(GameStrings.journal, "entry_objs_no4a");
    if (GameDataController.gd.getObjective("visited_outpost5"))
      JournalTexts.textToType2 += GameStrings.getString(GameStrings.journal, "entry_objs_no4b");
    return JournalTexts.textToType;
  }

  public static string chapter3Texts()
  {
    JournalTexts.textToType = GameStrings.getString(GameStrings.journal, "entry_intro_day3_intro");
    bool flag = false;
    if (!GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjectiveDetail("npc3_alive") == 0 && GameDataController.gd.getObjective("npc3_joined"))
    {
      JournalTexts.textToType = JournalTexts.textToType + " " + GameStrings.getString(GameStrings.journal, "entry_intro_day3_cody_dead");
      flag = true;
    }
    if (!GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjectiveDetail("npc2_alive") == 0 && GameDataController.gd.getObjective("npc2_joined"))
    {
      flag = true;
      JournalTexts.textToType = JournalTexts.textToType + " " + GameStrings.getString(GameStrings.journal, "entry_intro_day3_barry_dead");
    }
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
      JournalTexts.textToType = JournalTexts.textToType + " " + GameStrings.getString(GameStrings.journal, "entry_intro_day3_thugs");
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
      JournalTexts.textToType = JournalTexts.textToType + " " + GameStrings.getString(GameStrings.journal, "entry_intro_day3_storm");
    if (flag)
      JournalTexts.textToType = JournalTexts.textToType + " " + GameStrings.getString(GameStrings.journal, "day3_funeral");
    if (!GameDataController.gd.getObjective("visited_sidereal_outside_1"))
      JournalTexts.textToType = JournalTexts.textToType + "^ " + GameStrings.getString(GameStrings.journal, "entry_objs_no3a");
    JournalTexts.anotherText("visited_sidereal_outside_1", "day3_sidereal_arrive");
    JournalTexts.anotherText(GameDataController.gd.getObjectiveDetail("map_hunters_revealed") != TravelAgency.LOCATION_STATUS_UNDISCOVERED, "day3_sidereal_lodge_location", string.Empty);
    JournalTexts.anotherText("sidereal_base_located", "day3_sidereal_outpost_location");
    JournalTexts.anotherText(!GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjectiveDetail("npc3_alive") == 1 && GameDataController.gd.getObjective("npc3_joined"), "day3_sidereal_cody_dead", string.Empty);
    JournalTexts.anotherText(!GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjectiveDetail("npc2_alive") == 1 && GameDataController.gd.getObjective("npc2_joined"), "day3_sidereal_barry_dead", string.Empty);
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
    {
      JournalTexts.anotherText(InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_6") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_5") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_4") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_3") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_2") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_1"), "day1_rifle", "day3_rifle");
      JournalTexts.anotherText(InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_s_0") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_s_1") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_s_2") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_s_3") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_s_4") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_s_5") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_s_6"), "day3_silencer_constructed", string.Empty);
      JournalTexts.anotherText(InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_o_0") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_o_1") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_o_2") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_o_3") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_o_4") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_o_5") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_o_6"), "day3_sniper_constructed", string.Empty);
      JournalTexts.anotherText(InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_so_0") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_so_1") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_so_2") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_so_3") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_so_4") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_so_5") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_so_6"), "day3_silencer_sniper_constructed", string.Empty);
      JournalTexts.anotherText("thugs_gasstation_talk", "day3_thugs_heard");
      JournalTexts.anotherText("day3_sarge_shot", "day3_sarge_shot");
      JournalTexts.anotherText("day3_sarge_convinced", "day3_sarge_convinced");
      JournalTexts.anotherText("day3_guard_killed", "day3_guard_killed");
      JournalTexts.anotherText("day3_whiskey_left", "day3_whiskey_left");
      JournalTexts.anotherText("day3_food_poisoned", "day3_food_poisoned");
      JournalTexts.anotherText("day3_ammo_spoiled", "day3_ammo_spoiled");
      int num1 = 0;
      for (int index = 1; index <= 4; ++index)
      {
        if (ItemsManager.im.getItem("bear_trap_" + (object) index).dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1 && ItemsManager.im.getItem("bear_trap_" + (object) index).dataRef.droppedLocation.ToLower().IndexOf("nowhere") == -1)
        {
          if (ItemsManager.im.getItem("bear_trap_" + (object) index).dataRef.droppedLocation.ToLower().IndexOf("locationbaseoutside") != -1)
            ++num1;
          else if (ItemsManager.im.getItem("bear_trap_" + (object) index).dataRef.droppedLocation.ToLower().IndexOf("location1") != -1 || ItemsManager.im.getItem("bear_trap_" + (object) index).dataRef.droppedLocation.ToLower().IndexOf("location2") != -1 || ItemsManager.im.getItem("bear_trap_" + (object) index).dataRef.droppedLocation.ToLower().IndexOf("upstairs") != -1 || ItemsManager.im.getItem("bear_trap_" + (object) index).dataRef.droppedLocation.ToLower().IndexOf("locationbase") != -1)
            ++num1;
        }
      }
      JournalTexts.anotherText(num1 > 0, "day3_traps", string.Empty);
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      int num5 = 0;
      if ((GameDataController.gd.getObjective("base_window_1_bars_nailed") || GameDataController.gd.getObjective("base_window_1_bars_taped")) && !GameDataController.gd.getObjective("base_window1_broken"))
        ++num2;
      if ((GameDataController.gd.getObjective("base_window_2_bars_nailed") || GameDataController.gd.getObjective("base_window_2_bars_taped")) && !GameDataController.gd.getObjective("base_window2_broken"))
        ++num2;
      if ((GameDataController.gd.getObjective("base_window_3_bars_nailed") || GameDataController.gd.getObjective("base_window_3_bars_taped")) && !GameDataController.gd.getObjective("base_window3_broken"))
        ++num2;
      if ((GameDataController.gd.getObjective("base_window_1_net_nailed") || GameDataController.gd.getObjective("base_window_1_net_taped")) && !GameDataController.gd.getObjective("base_window1_broken"))
        ++num3;
      if ((GameDataController.gd.getObjective("base_window_2_net_nailed") || GameDataController.gd.getObjective("base_window_2_net_taped")) && !GameDataController.gd.getObjective("base_window2_broken"))
        ++num3;
      if ((GameDataController.gd.getObjective("base_window_3_net_nailed") || GameDataController.gd.getObjective("base_window_3_net_taped")) && !GameDataController.gd.getObjective("base_window3_broken"))
        ++num3;
      if ((GameDataController.gd.getObjective("base_window_1_blanketb_nailed") || GameDataController.gd.getObjective("base_window_1_blanketb_taped")) && !GameDataController.gd.getObjective("base_window1_broken"))
        ++num4;
      if ((GameDataController.gd.getObjective("base_window_2_blanketb_nailed") || GameDataController.gd.getObjective("base_window_2_blanketb_taped")) && !GameDataController.gd.getObjective("base_window2_broken"))
        ++num4;
      if ((GameDataController.gd.getObjective("base_window_3_blanketb_nailed") || GameDataController.gd.getObjective("base_window_3_blanketb_taped")) && !GameDataController.gd.getObjective("base_window3_broken"))
        ++num4;
      if ((GameDataController.gd.getObjective("base_window_1_blanket_nailed") || GameDataController.gd.getObjective("base_window_1_blanket_taped")) && !GameDataController.gd.getObjective("base_window1_broken"))
        ++num4;
      if ((GameDataController.gd.getObjective("base_window_2_blanket_nailed") || GameDataController.gd.getObjective("base_window_2_blanket_taped")) && !GameDataController.gd.getObjective("base_window2_broken"))
        ++num4;
      if ((GameDataController.gd.getObjective("base_window_3_blanket_nailed") || GameDataController.gd.getObjective("base_window_3_blanket_taped")) && !GameDataController.gd.getObjective("base_window3_broken"))
        ++num4;
      if ((GameDataController.gd.getObjective("base_window_1_flag_nailed") || GameDataController.gd.getObjective("base_window_1_flag_taped")) && !GameDataController.gd.getObjective("base_window1_broken"))
        ++num4;
      if ((GameDataController.gd.getObjective("base_window_2_flag_nailed") || GameDataController.gd.getObjective("base_window_2_flag_taped")) && !GameDataController.gd.getObjective("base_window2_broken"))
        ++num4;
      if ((GameDataController.gd.getObjective("base_window_3_flag_nailed") || GameDataController.gd.getObjective("base_window_3_flag_taped")) && !GameDataController.gd.getObjective("base_window3_broken"))
        ++num4;
      if ((GameDataController.gd.getObjective("base_window_1_therm_nailed") || GameDataController.gd.getObjective("base_window_1_therm_taped")) && !GameDataController.gd.getObjective("base_window1_broken"))
        ++num4;
      if ((GameDataController.gd.getObjective("base_window_2_therm_nailed") || GameDataController.gd.getObjective("base_window_2_therm_taped")) && !GameDataController.gd.getObjective("base_window2_broken"))
        ++num4;
      if ((GameDataController.gd.getObjective("base_window_3_therm_nailed") || GameDataController.gd.getObjective("base_window_3_therm_taped")) && !GameDataController.gd.getObjective("base_window3_broken"))
        ++num4;
      if ((GameDataController.gd.getObjective("base_window_1_foil_nailed") || GameDataController.gd.getObjective("base_window_1_foil_taped")) && !GameDataController.gd.getObjective("base_window1_broken"))
        ++num5;
      if ((GameDataController.gd.getObjective("base_window_2_foil_nailed") || GameDataController.gd.getObjective("base_window_2_foil_taped")) && !GameDataController.gd.getObjective("base_window2_broken"))
        ++num5;
      if ((GameDataController.gd.getObjective("base_window_3_foil_nailed") || GameDataController.gd.getObjective("base_window_3_foil_taped")) && !GameDataController.gd.getObjective("base_window3_broken"))
        ++num5;
      JournalTexts.anotherText(!JournalTexts.anotherText(!JournalTexts.anotherText(num2 == 1, "windows_bars_1", string.Empty) && num2 == 2, "windows_bars_2", string.Empty) && num2 == 3, "windows_bars_3", string.Empty);
      JournalTexts.anotherText(!JournalTexts.anotherText(!JournalTexts.anotherText(num3 == 1, "windows_net_1", string.Empty) && num3 == 2, "windows_net_2", string.Empty) && num3 == 3, "windows_net_3", string.Empty);
      JournalTexts.anotherText(!JournalTexts.anotherText(!JournalTexts.anotherText(num5 == 1, "windows_foil_1", string.Empty) && num5 == 2, "windows_foil_2", string.Empty) && num5 == 3, "windows_foil_3", string.Empty);
      JournalTexts.anotherText(!JournalTexts.anotherText(!JournalTexts.anotherText(num4 == 1, "windows_blankets_1_d2", string.Empty) && num4 == 2, "windows_blankets_2_d2", string.Empty) && num4 == 3, "windows_blankets_3_d2", string.Empty);
      if (ItemsManager.im.getItem("revolver_6").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("revolver_5").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("revolver_4").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("revolver_3").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("revolver_2").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("revolver_1").dataRef.droppedLocation == "npc3")
        JournalTexts.anotherText(true, "day3_revolver_cody", string.Empty);
      if (ItemsManager.im.getItem("revolver_6").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("revolver_5").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("revolver_4").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("revolver_3").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("revolver_2").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("revolver_1").dataRef.droppedLocation == "npc2")
        JournalTexts.anotherText(true, "day3_revolver_barry", string.Empty);
      int num6 = JournalTexts.journalTimeItems.Count;
      if (num6 > 7)
        num6 = 7;
      if (num6 < 6 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
        JournalTexts.textToType2 = JournalTexts.textToType2 + " ^ " + GameStrings.getString(GameStrings.journal, "entry_obj0_no3a");
    }
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
    {
      JournalTexts.anotherText("restaurant_sarge_encountered", "restaurant_sarge_encountered");
      JournalTexts.anotherText("r_sarge_catcher", "d3_1_catcher_restaurant");
      JournalTexts.anotherText(GameDataController.gd.getObjective("cs_engine_fueled") && GameDataController.gd.getObjective("cs_engine_started") && GameDataController.gd.getObjective("cs_stormcatcher_installed"), "d3_1_catcher_construction", string.Empty);
      JournalTexts.anotherText(GameDataController.gd.getObjective("lodge_tree_stormcatcher") && GameDataController.gd.getObjective("lodge_roof_cleaned"), "d3_1_catcher_forest", string.Empty);
      JournalTexts.anotherText("base_outside_dug", "base_outside_dug");
      JournalTexts.anotherText(!GameDataController.gd.getObjective("attic_hatch_open"), "attic_hatch_open", string.Empty);
      JournalTexts.anotherText("helicopter_covered", "helicopter_covered");
      JournalTexts.anotherText("helicopter_covered_taped", "helicopter_covered_taped");
      JournalTexts.anotherText("lighting_rod_installed", "lighting_rod_installed");
      int num7 = 0;
      int num8 = 0;
      int num9 = 0;
      int num10 = 0;
      int num11 = 0;
      for (int index = 1; index <= 3; ++index)
      {
        if (GameDataController.gd.getObjective("base_window_" + (object) index + "_board_nailed") || GameDataController.gd.getObjective("base_window_" + (object) index + "_board_taped"))
          ++num11;
        if (GameDataController.gd.getObjective("base_window_" + (object) index + "_blanketb_nailed") || GameDataController.gd.getObjective("base_window_" + (object) index + "_blanketb_taped"))
          ++num9;
        if (GameDataController.gd.getObjective("base_window_" + (object) index + "_blanket_nailed") || GameDataController.gd.getObjective("base_window_" + (object) index + "_blanket_taped"))
          ++num9;
        if (GameDataController.gd.getObjective("base_window_" + (object) index + "_flag_nailed") || GameDataController.gd.getObjective("base_window_" + (object) index + "_flag_taped"))
          ++num9;
        if (GameDataController.gd.getObjective("base_window_" + (object) index + "_therm_nailed") || GameDataController.gd.getObjective("base_window_" + (object) index + "_therm_taped"))
          ++num9;
        if (GameDataController.gd.getObjective("base_window_" + (object) index + "_net_nailed") || GameDataController.gd.getObjective("base_window_" + (object) index + "_net_taped"))
          ++num8;
        if (GameDataController.gd.getObjective("base_window_" + (object) index + "_bars_nailed") || GameDataController.gd.getObjective("base_window_" + (object) index + "_bars_taped"))
          ++num7;
        if (GameDataController.gd.getObjective("base_window_" + (object) index + "_foil_nailed") || GameDataController.gd.getObjective("base_window_" + (object) index + "_foil_taped"))
          ++num10;
      }
      JournalTexts.anotherText(!JournalTexts.anotherText(!JournalTexts.anotherText(num11 == 1, "windows_boards_1", string.Empty) && num11 == 2, "windows_boards_2", string.Empty) && num11 == 3, "windows_boards_3", string.Empty);
      JournalTexts.anotherText(!JournalTexts.anotherText(!JournalTexts.anotherText(num7 == 1, "windows_bars_1", string.Empty) && num7 == 2, "windows_bars_2", string.Empty) && num7 == 3, "windows_bars_3", string.Empty);
      JournalTexts.anotherText(!JournalTexts.anotherText(!JournalTexts.anotherText(num8 == 1, "windows_net_1", string.Empty) && num8 == 2, "windows_net_2", string.Empty) && num8 == 3, "windows_net_3", string.Empty);
      JournalTexts.anotherText(!JournalTexts.anotherText(!JournalTexts.anotherText(num10 == 1, "windows_foil_1", string.Empty) && num10 == 2, "windows_foil_2", string.Empty) && num10 == 3, "windows_foil_3", string.Empty);
      JournalTexts.anotherText(!JournalTexts.anotherText(!JournalTexts.anotherText(num9 == 1, "windows_blankets_1_d2", string.Empty) && num9 == 2, "windows_blankets_2_d2", string.Empty) && num9 == 3, "windows_blankets_3_d2", string.Empty);
      int num12 = JournalTexts.journalTimeItems.Count;
      if (num12 > 7)
        num12 = 7;
      if (num12 < 6)
        JournalTexts.textToType2 = JournalTexts.textToType2 + " ^ " + GameStrings.getString(GameStrings.journal, "entry_obj0_no3b");
    }
    return JournalTexts.textToType;
  }

  public static string chapter2Texts()
  {
    JournalTexts.textToType = GameDataController.gd.getObjectiveDetail("day_2_threat") != 0 ? JournalTexts.textToType + GameStrings.getString(GameStrings.journal, "entry_intro_day2_cold") : JournalTexts.textToType + GameStrings.getString(GameStrings.journal, "entry_intro_day2_hot");
    JournalTexts.textToType = JournalTexts.textToType + " " + GameStrings.getString(GameStrings.journal, "entry_intro_day2_heli");
    JournalTexts.anotherText("dialogue_ginger_intro", "day2_ginger");
    JournalTexts.anotherText("npc2_joined", "day2_barry");
    JournalTexts.anotherText("npc3_joined", "day2_cody");
    int num1 = 0;
    int num2 = 0;
    if (GameDataController.gd.getObjective("base_window_1_blanketb_nailed") || GameDataController.gd.getObjective("base_window_1_blanketb_taped"))
      ++num1;
    if (GameDataController.gd.getObjective("base_window_2_blanketb_nailed") || GameDataController.gd.getObjective("base_window_2_blanketb_taped"))
      ++num1;
    if (GameDataController.gd.getObjective("base_window_3_blanketb_nailed") || GameDataController.gd.getObjective("base_window_3_blanketb_taped"))
      ++num1;
    if (GameDataController.gd.getObjective("base_window_1_blanket_nailed") || GameDataController.gd.getObjective("base_window_1_blanket_taped"))
      ++num1;
    if (GameDataController.gd.getObjective("base_window_2_blanket_nailed") || GameDataController.gd.getObjective("base_window_2_blanket_taped"))
      ++num1;
    if (GameDataController.gd.getObjective("base_window_3_blanket_nailed") || GameDataController.gd.getObjective("base_window_3_blanket_taped"))
      ++num1;
    if (GameDataController.gd.getObjective("base_window_1_flag_nailed") || GameDataController.gd.getObjective("base_window_1_flag_taped"))
      ++num1;
    if (GameDataController.gd.getObjective("base_window_2_flag_nailed") || GameDataController.gd.getObjective("base_window_2_flag_taped"))
      ++num1;
    if (GameDataController.gd.getObjective("base_window_3_flag_nailed") || GameDataController.gd.getObjective("base_window_3_flag_taped"))
      ++num1;
    if (GameDataController.gd.getObjective("base_window_1_therm_nailed") || GameDataController.gd.getObjective("base_window_1_therm_taped"))
      ++num1;
    if (GameDataController.gd.getObjective("base_window_2_therm_nailed") || GameDataController.gd.getObjective("base_window_2_therm_taped"))
      ++num1;
    if (GameDataController.gd.getObjective("base_window_3_therm_nailed") || GameDataController.gd.getObjective("base_window_3_therm_taped"))
      ++num1;
    if ((GameDataController.gd.getObjective("base_window_1_foil_nailed") || GameDataController.gd.getObjective("base_window_1_foil_taped")) && !GameDataController.gd.getObjective("base_window1_broken"))
      ++num2;
    if ((GameDataController.gd.getObjective("base_window_2_foil_nailed") || GameDataController.gd.getObjective("base_window_2_foil_taped")) && !GameDataController.gd.getObjective("base_window2_broken"))
      ++num2;
    if ((GameDataController.gd.getObjective("base_window_3_foil_nailed") || GameDataController.gd.getObjective("base_window_3_foil_taped")) && !GameDataController.gd.getObjective("base_window3_broken"))
      ++num2;
    JournalTexts.anotherText(!JournalTexts.anotherText(!JournalTexts.anotherText(num1 == 1, "windows_blankets_1_d2", string.Empty) && num1 == 2, "windows_blankets_2_d2", string.Empty) && num1 == 3, "windows_blankets_3_d2", string.Empty);
    JournalTexts.anotherText(!JournalTexts.anotherText(!JournalTexts.anotherText(num2 == 1, "windows_foil_1", "windows_foil_1_d2") && num2 == 2, "windows_foil_2", "windows_foil_2_d2") && num2 == 3, "windows_foil_3", "windows_foil_3_d2");
    JournalTexts.anotherText(GameDataController.gd.getObjective("base_hatch_therm") || GameDataController.gd.getObjective("base_hatch_blanket") || GameDataController.gd.getObjective("base_hatch_blanketb") || GameDataController.gd.getObjective("base_hatch_flag"), "hatch_blanket_d2", string.Empty);
    if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
    {
      int num3 = 0;
      if (ItemsManager.im.getItem("heat_absorber1A").dataRef.droppedLocation == "Location1" || ItemsManager.im.getItem("heat_absorber1A").dataRef.droppedLocation == "Location2" || ItemsManager.im.getItem("heat_absorber1A").dataRef.droppedLocation == "LocationBaseUpstairs" || ItemsManager.im.getItem("heat_absorber1A").dataRef.droppedLocation == "LocationBaseBathroom")
        ++num3;
      if (ItemsManager.im.getItem("heat_absorber2A").dataRef.droppedLocation == "Location1" || ItemsManager.im.getItem("heat_absorber2A").dataRef.droppedLocation == "Location2" || ItemsManager.im.getItem("heat_absorber2A").dataRef.droppedLocation == "LocationBaseUpstairs" || ItemsManager.im.getItem("heat_absorber2A").dataRef.droppedLocation == "LocationBaseBathroom")
        ++num3;
      if (ItemsManager.im.getItem("heat_absorber3A").dataRef.droppedLocation == "Location1" || ItemsManager.im.getItem("heat_absorber3A").dataRef.droppedLocation == "Location2" || ItemsManager.im.getItem("heat_absorber3A").dataRef.droppedLocation == "LocationBaseUpstairs" || ItemsManager.im.getItem("heat_absorber3A").dataRef.droppedLocation == "LocationBaseBathroom")
        ++num3;
      if (num3 > 0)
      {
        JournalTexts.anotherText(num3 == 1, "heat_absorber_base_1", string.Empty);
        JournalTexts.anotherText(num3 == 2, "heat_absorber_base_2", string.Empty);
        JournalTexts.anotherText(num3 == 3, "heat_absorber_base_3", string.Empty);
      }
    }
    JournalTexts.anotherText(GameDataController.gd.getObjective("base_ac_cord_plugged") && GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 1, "house_ac", string.Empty);
    JournalTexts.anotherText((GameDataController.gd.getObjective("kitchen_fan_plugged") || GameDataController.gd.getObjective("base_fan_cord_plugged")) && GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 1, "house_fan", string.Empty);
    if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
      JournalTexts.anotherText(GameDataController.gd.getObjective("kitchen_oven_open") && GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 1, "house_oven", string.Empty);
    if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
      JournalTexts.anotherText((GameDataController.gd.getObjective("kitchen_heater_plugged") || GameDataController.gd.getObjective("base_heater_cord_plugged")) && GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 1, "house_heater", string.Empty);
    if (ItemsManager.im.getItem("gasheater").dataRef.droppedLocation.ToLower().IndexOf("location1") != -1 || ItemsManager.im.getItem("gasheater").dataRef.droppedLocation.ToLower().IndexOf("location2") != -1 || ItemsManager.im.getItem("gasheater").dataRef.droppedLocation.ToLower().IndexOf("upstairs") != -1 || ItemsManager.im.getItem("gasheater").dataRef.droppedLocation.ToLower().IndexOf("locationbase") != -1)
      JournalTexts.anotherText(true, "house_gasheater", string.Empty);
    if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
    {
      JournalTexts.anotherText(GameDataController.gd.getObjective("rv_cave_therm") || GameDataController.gd.getObjective("rv_cave_flag") || GameDataController.gd.getObjective("rv_cave_blanket") || GameDataController.gd.getObjective("rv_cave_blanketb"), "cave_blanket_d2", string.Empty);
      JournalTexts.anotherText("cave_ac_cord_plugged", "cave_ac");
      JournalTexts.anotherText("cave_fan_cord_plugged", "cave_fan");
      if (GameDataController.gd.getObjective("cave_fan_cord_plugged") || GameDataController.gd.getObjective("cave_ac_cord_plugged"))
        JournalTexts.anotherText("rv_started", "rv_started");
      int num4 = 0;
      if (ItemsManager.im.getItem("heat_absorber1A").dataRef.droppedLocation == "LocationCave")
        ++num4;
      if (ItemsManager.im.getItem("heat_absorber2A").dataRef.droppedLocation == "LocationCave")
        ++num4;
      if (ItemsManager.im.getItem("heat_absorber3A").dataRef.droppedLocation == "LocationCave")
        ++num4;
      if (num4 > 0)
      {
        JournalTexts.anotherText(num4 == 1, "heat_absorber_cave_1", string.Empty);
        JournalTexts.anotherText(num4 == 2, "heat_absorber_cave_2", string.Empty);
        JournalTexts.anotherText(num4 == 3, "heat_absorber_cave_3", string.Empty);
      }
    }
    if (ItemsManager.im.getItem("water1").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("water2").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("water3").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("water4").dataRef.droppedLocation == "ginger")
      JournalTexts.anotherText(true, "ginger_water", string.Empty);
    if (ItemsManager.im.getItem("water1").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("water2").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("water3").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("water4").dataRef.droppedLocation == "npc2")
      JournalTexts.anotherText(true, "barry_water", string.Empty);
    if (ItemsManager.im.getItem("water1").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("water2").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("water3").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("water4").dataRef.droppedLocation == "npc3")
      JournalTexts.anotherText(true, "cody_water", string.Empty);
    if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0 && (InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("water1") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("water2") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("water3") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("water4")))
      JournalTexts.anotherText(true, "david_water", string.Empty);
    if (ItemsManager.im.getItem("coat1").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("coat2").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("coat3").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("coat4").dataRef.droppedLocation == "ginger")
      JournalTexts.anotherText(true, "ginger_coat", string.Empty);
    if (ItemsManager.im.getItem("coat1").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("coat2").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("coat3").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("coat4").dataRef.droppedLocation == "npc2")
      JournalTexts.anotherText(true, "barry_coat", string.Empty);
    if (ItemsManager.im.getItem("coat1").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("coat2").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("coat3").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("coat4").dataRef.droppedLocation == "npc3")
      JournalTexts.anotherText(true, "cody_coat", string.Empty);
    if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1 && (InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("coat1") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("coat2") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("coat3") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("coat4")))
      JournalTexts.anotherText(true, "david_coat", string.Empty);
    int count = JournalTexts.journalTimeItems.Count;
    if (JournalTexts.anotherText(GameDataController.gd.getObjectiveDetail("towel_1_at_door") != 0 && GameDataController.gd.getObjectiveDetail("towel_2_at_door") != 0, "day1_doors_towels", string.Empty))
      ;
    if (count < 5)
    {
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
        JournalTexts.textToType2 = JournalTexts.textToType2 + "^" + GameStrings.getString(GameStrings.journal, "entry_obj0_no2a");
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
        JournalTexts.textToType2 = JournalTexts.textToType2 + "^" + GameStrings.getString(GameStrings.journal, "entry_obj0_no2b");
    }
    return JournalTexts.textToType;
  }

  public static string chapter1Texts()
  {
    string str1 = GameStrings.getString(GameStrings.journal, "entry_intro_day1");
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      str1 += GameStrings.getString(GameStrings.journal, "entry_intro_day1_bugs");
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
      str1 += GameStrings.getString(GameStrings.journal, "entry_intro_day1_gas");
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
      str1 += GameStrings.getString(GameStrings.journal, "entry_intro_day1_spiders");
    string str2 = str1 + "^" + GameStrings.getString(GameStrings.journal, "entry_obj0_no1");
    if (JournalTexts.anotherText(GameDataController.gd.getObjective("base_discovered"), "day1_base", string.Empty))
      ;
    JournalTexts.anotherText(GameDataController.gd.getItemData("sonic").droppedLocation.ToLower().IndexOf("outside") != -1, "day1_sonic", string.Empty);
    int num1 = 0;
    int num2 = 0;
    if (ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1 && ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("nowhere") == -1)
      num1 = ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("outside") == -1 ? (ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("location1") != -1 || ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("location2") != -1 || ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("upstairs") != -1 || ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("locationbase") != -1 ? 2 : 3) : 1;
    if (ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1 && ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("nowhere") == -1)
      num2 = ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("outside") == -1 ? (ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("location1") != -1 || ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("location2") != -1 || ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("upstairs") != -1 || ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("locationbase") != -1 ? 2 : 3) : 1;
    if (!JournalTexts.anotherText(num1 == 1 && num2 == 1, "day1_spider_trap11", string.Empty) && !JournalTexts.anotherText(num1 == 2 && num2 == 2, "day1_spider_trap22", string.Empty))
    {
      JournalTexts.anotherText(num1 == 1 || num2 == 1, "day1_spider_trap1", string.Empty);
      JournalTexts.anotherText(num1 == 2 || num2 == 2, "day1_spider_trap2", string.Empty);
    }
    if (GameDataController.gd.getObjective("barn_sprinklers_enabled"))
    {
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      {
        if (!JournalTexts.anotherText(GameDataController.gd.getObjective("barn_sprinklers_fed1"), "day1_spray_pest", string.Empty))
          JournalTexts.anotherText(true, "day1_spray_water_bugs", string.Empty);
      }
      else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
      {
        if (!JournalTexts.anotherText(ItemsManager.im.getItem("chem_glass_12").dataRef.droppedLocation == "sprinklers" || ItemsManager.im.getItem("chem_glass_13").dataRef.droppedLocation == "sprinklers" || ItemsManager.im.getItem("chem_glass_23").dataRef.droppedLocation == "sprinklers", "day1_spray_chem_gas", string.Empty))
          JournalTexts.anotherText(true, "day1_spray_water_gas", string.Empty);
      }
      else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !JournalTexts.anotherText(GameDataController.gd.getObjective("barn_sprinklers_fed1"), "day1_spray_pest_spiders", string.Empty))
        JournalTexts.anotherText(true, "day1_spray_water_spiders", string.Empty);
    }
    int num3 = 0;
    int num4 = 0;
    int num5 = 0;
    if (GameDataController.gd.getObjective("base_window_1_net_nailed") || GameDataController.gd.getObjective("base_window_1_net_taped"))
      ++num3;
    if (GameDataController.gd.getObjective("base_window_2_net_nailed") || GameDataController.gd.getObjective("base_window_2_net_taped"))
      ++num3;
    if (GameDataController.gd.getObjective("base_window_3_net_nailed") || GameDataController.gd.getObjective("base_window_3_net_taped"))
      ++num3;
    if (GameDataController.gd.getObjective("base_window_1_bars_nailed") || GameDataController.gd.getObjective("base_window_1_bars_taped"))
      ++num4;
    if (GameDataController.gd.getObjective("base_window_2_bars_nailed") || GameDataController.gd.getObjective("base_window_2_bars_taped"))
      ++num4;
    if (GameDataController.gd.getObjective("base_window_3_bars_nailed") || GameDataController.gd.getObjective("base_window_3_bars_taped"))
      ++num4;
    if (GameDataController.gd.getObjective("base_window_1_foil_nailed") || GameDataController.gd.getObjective("base_window_1_foil_taped"))
      ++num5;
    if (GameDataController.gd.getObjective("base_window_2_foil_nailed") || GameDataController.gd.getObjective("base_window_2_foil_taped"))
      ++num5;
    if (GameDataController.gd.getObjective("base_window_3_foil_nailed") || GameDataController.gd.getObjective("base_window_3_foil_taped"))
      ++num5;
    if (!JournalTexts.anotherText(num3 == 1, "windows_net_1", string.Empty) && !JournalTexts.anotherText(num3 == 2, "windows_net_2", string.Empty))
      JournalTexts.anotherText(num3 == 3, "windows_net_3", string.Empty);
    if (!JournalTexts.anotherText(num4 == 1, "windows_bars_1", string.Empty) && !JournalTexts.anotherText(num4 == 2, "windows_bars_2", string.Empty))
      JournalTexts.anotherText(num4 == 3, "windows_bars_3", string.Empty);
    if (!JournalTexts.anotherText(num5 == 1, "windows_foil_1", string.Empty) && !JournalTexts.anotherText(num5 == 2, "windows_foil_2", string.Empty))
      JournalTexts.anotherText(num5 == 3, "windows_foil_3", string.Empty);
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 1)
    {
      if (!JournalTexts.anotherText(InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("flamethrower"), "day1_flamethrower", string.Empty) && !JournalTexts.anotherText(InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("pestsprayer"), "day1_pestspray", string.Empty))
        JournalTexts.anotherText(InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_6") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_5") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_4") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_3") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_2") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("rifle_1"), "day1_rifle", string.Empty);
    }
    else
      JournalTexts.anotherText(InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("chemsuit_dmg_dmg") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("chemsuit_rep_dmg") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("chemsuit_dmg_rep") || InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("chemsuit_rep_rep"), "day1_hazmat", string.Empty);
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
      JournalTexts.anotherText(GameDataController.gd.getObjective("crashsite_gas_note_read"), "day1_gas_density", string.Empty);
    int num6 = JournalTexts.journalTimeItems.Count;
    if (JournalTexts.anotherText(GameDataController.gd.getObjectiveDetail("towel_1_at_door") != 0 && GameDataController.gd.getObjectiveDetail("towel_2_at_door") != 0, "day1_doors_towels", string.Empty))
      ;
    if (num6 > 7)
      num6 = 7;
    if (num6 > 0)
      JournalTexts.textToType2 += GameStrings.getString(GameStrings.journal, "entry_obj" + (object) num6 + "_no1");
    return str2;
  }
}
