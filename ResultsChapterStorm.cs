// Decompiled with JetBrains decompiler
// Type: ResultsChapterStorm
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class ResultsChapterStorm : ResultsController
{
  private string analytics_stayed = string.Empty;
  private string analytics_sarge_status = "neutral";
  private string analytics_ammo_sabotaged = "false";
  private string analytics_doors_and_windows = "?";
  private string analytics_food_poisoned = "false";
  private string analytics_guard_killed = "false";
  private string analytics_traps = "0/4";
  private string analytics_weapon = "none";
  private string analytics_whiskey_dumped = "false";

  public int checkTrap(string trapname)
  {
    int num = 0;
    if (ItemsManager.im.getItem(trapname).dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1 && ItemsManager.im.getItem(trapname).dataRef.droppedLocation.ToLower().IndexOf("nowhere") == -1)
      num = ItemsManager.im.getItem(trapname).dataRef.droppedLocation.ToLower().IndexOf("baseoutside") == -1 ? (ItemsManager.im.getItem(trapname).dataRef.droppedLocation.ToLower().IndexOf("location1") != -1 || ItemsManager.im.getItem(trapname).dataRef.droppedLocation.ToLower().IndexOf("location2") != -1 || ItemsManager.im.getItem(trapname).dataRef.droppedLocation.ToLower().IndexOf("upstairs") != -1 || ItemsManager.im.getItem(trapname).dataRef.droppedLocation.ToLower().IndexOf("locationbase") != -1 ? 2 : 3) : 1;
    return num;
  }

  public int checkWindows(TimelineAction tla, string name1, string name2, int value1)
  {
    int num1 = value1;
    int num2 = value1 / 3;
    int num3 = value1 / 2;
    int num4 = value1 / 6;
    int num5 = value1 / 2;
    int num6 = value1 / 6;
    int num7 = value1 / 2;
    int num8 = value1 / 6;
    int num9 = value1 / 2;
    int num10 = value1 / 6;
    int num11 = 1;
    int num12;
    if (GameDataController.gd.getObjective("base_" + name1 + "_broken"))
    {
      num12 = 0;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_empty";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_open") + " " + GameStrings.getString(GameStrings.results, "window_broken_barricade");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_board_nailed") && GameDataController.gd.getObjective("base_" + name2 + "_board_taped"))
    {
      num12 = num1;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_board_3";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_board") + " " + GameStrings.getString(GameStrings.results, "board_taped_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_board_taped"))
    {
      num12 = num1 - num11;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_board_2";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_board") + " " + GameStrings.getString(GameStrings.results, "board_taped");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_board_nailed"))
    {
      num12 = num1 - num11;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_board_1";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_board") + " " + GameStrings.getString(GameStrings.results, "board_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_board"))
    {
      num12 = num2;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_board_0";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_board") + " " + GameStrings.getString(GameStrings.results, "board_none");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_blanketb_nailed") && GameDataController.gd.getObjective("base_" + name2 + "_blanketb_taped"))
    {
      num12 = num3;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_blanketb_3";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_taped_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_blanketb_taped"))
    {
      num12 = num3 - num11;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_blanketb_2";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_taped");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_blanketb_nailed"))
    {
      num12 = num3 - num11;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_blanketb_1";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_blanketb"))
    {
      num12 = num4;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_blanketb_0";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_none");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_blanket_nailed") && GameDataController.gd.getObjective("base_" + name2 + "_blanket_taped"))
    {
      num12 = num5;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_blanket_3";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_taped_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_blanket_taped"))
    {
      num12 = num5 - num11;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_blanket_2";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_taped");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_blanket_nailed"))
    {
      num12 = num5 - num11;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_blanket_1";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_blanket"))
    {
      num12 = num6;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_blanket_0";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_none");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_flag_nailed") && GameDataController.gd.getObjective("base_" + name2 + "_flag_taped"))
    {
      num12 = num7;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_flag_3";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_flag") + " " + GameStrings.getString(GameStrings.results, "flag_taped_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_flag_taped"))
    {
      num12 = num7 - num11;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_flag_2";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_flag") + " " + GameStrings.getString(GameStrings.results, "flag_taped");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_flag_nailed"))
    {
      num12 = num7 - num11;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_flag_1";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_flag") + GameStrings.getString(GameStrings.results, "flag_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_flag"))
    {
      num12 = num8;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_flag_0";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_flag") + " " + GameStrings.getString(GameStrings.results, "flag_none");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_therm_nailed") && GameDataController.gd.getObjective("base_" + name2 + "_therm_taped"))
    {
      num12 = num9;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_therm_3";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_therm") + " " + GameStrings.getString(GameStrings.results, "therm_taped_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_therm_taped"))
    {
      num12 = num9 - num11;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_value1_therm_2";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_therm") + " " + GameStrings.getString(GameStrings.results, "therm_taped");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_therm_nailed"))
    {
      num12 = num9 - num11;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_therm_1";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_therm") + " " + GameStrings.getString(GameStrings.results, "therm_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_therm"))
    {
      num12 = num10;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_therm_0";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_therm") + " " + GameStrings.getString(GameStrings.results, "therm_none");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_net_nailed") && GameDataController.gd.getObjective("base_" + name2 + "_net_taped"))
    {
      num12 = 0;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_net_3";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_net") + " " + GameStrings.getString(GameStrings.results, "net_taped_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_net_taped"))
    {
      num12 = 0;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_net_2";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_net") + " " + GameStrings.getString(GameStrings.results, "net_taped");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_net_nailed"))
    {
      num12 = 0;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_net_1";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_net") + " " + GameStrings.getString(GameStrings.results, "net_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_net"))
    {
      num12 = 0;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_net_0";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_net") + " " + GameStrings.getString(GameStrings.results, "net_none");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_foil_nailed") && GameDataController.gd.getObjective("base_" + name2 + "_foil_taped"))
    {
      num12 = num5;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_foil_3";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_foil_taped"))
    {
      num12 = num5;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_foil_2";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_foil_nailed"))
    {
      num12 = num5;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_foil_1";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_foil") + " " + GameStrings.getString(GameStrings.results, "foil_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_foil"))
    {
      num12 = num6;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_foil_0";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_foil") + " " + GameStrings.getString(GameStrings.results, "foil_none");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_bars_nailed") && GameDataController.gd.getObjective("base_" + name2 + "_bars_taped"))
    {
      num12 = 0;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_bars_3";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_bars_taped"))
    {
      num12 = 0;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_bars_2";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_bars_nailed"))
    {
      num12 = 0;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_bars_1";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_bars") + " " + GameStrings.getString(GameStrings.results, "bars_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_bars"))
    {
      num12 = 0;
      if (num12 > value1)
        num12 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_bars_0";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_bars") + " " + GameStrings.getString(GameStrings.results, "bars_none");
    }
    else
    {
      num12 = 0;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_empty";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_open");
    }
    if (num12 < 0)
      num12 = 0;
    return num12;
  }

  public override void chapterResult()
  {
    this.surviavbleDanger = 20;
    this.danger = 0;
    this.removeDanger = 0;
    this.winQuality = 3;
    this.pbc.total = 100;
    this.changeDanger(this.pbc.total.ToString());
    Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
    {
      text = GameStrings.getString(GameStrings.results, "r_d3_1_1a1")
    });
    if (GameDataController.gd.previousLocation == "Location1" || GameDataController.gd.previousLocation == "Location2" || GameDataController.gd.previousLocation == "LocationBaseUpstairs" || GameDataController.gd.previousLocation == "LocationBaseBathroom" || GameDataController.gd.previousLocation == "LocationAttic1" || GameDataController.gd.previousLocation == "LocationAttic2")
    {
      this.analytics_stayed = "base";
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        text = GameStrings.getString(GameStrings.results, "r_d3_1_1a2")
      });
      this.check(label: "r_d3_1_1a3", pic: string.Empty);
      int num1 = 0;
      if (GameDataController.gd.getObjective("cs_engine_fueled") && GameDataController.gd.getObjective("cs_engine_started") && GameDataController.gd.getObjective("cs_stormcatcher_installed"))
      {
        ++num1;
        this.removeDanger += this.check(label: "r_d3_1_catcher_construction_1", pic: "c_storm_catcher_construction");
        this.removeDanger += this.check(5, "r_d3_1_catcher_construction_2", string.Empty);
      }
      if (GameDataController.gd.getObjective("lodge_tree_stormcatcher") && GameDataController.gd.getObjective("lodge_roof_cleaned"))
      {
        ++num1;
        this.removeDanger += this.check(label: "r_d3_1_catcher_lodge_1", pic: "c_storm_catcher_forest");
        this.removeDanger += this.check(5, "r_d3_1_catcher_lodge_2", string.Empty);
      }
      if (GameDataController.gd.getObjective("r_sarge_catcher"))
      {
        ++num1;
        this.removeDanger += this.check(label: "r_d3_1_catcher_restaurant_1", pic: "c_storm_catcher_restaurant");
        this.removeDanger += this.check(5, "r_d3_1_catcher_restaurant_2", string.Empty);
      }
      if (num1 > 0 && num1 < 3)
      {
        this.removeDanger += this.check(label: "r_d3_1_catchers_0a", pic: "hide");
        this.removeDanger += this.check(label: "r_d3_1_catchers_0b", pic: string.Empty);
      }
      if (num1 == 3)
      {
        this.removeDanger += this.check(label: "r_d3_1_catchers_3a", pic: "c_map_catchers");
        this.removeDanger += this.check(20, "r_d3_1_catchers_3b", string.Empty);
      }
      if (GameDataController.gd.getObjective("base_outside_dug"))
      {
        this.removeDanger += this.check(label: "r_d3_1_ditch_1a", pic: "c_dig");
        this.removeDanger += this.check(15, "r_d3_1_ditch_1b", string.Empty);
      }
      else
      {
        this.removeDanger += this.check(label: "r_d3_1_ditch_2a", pic: "hide");
        this.removeDanger += this.check(label: "r_d3_1_ditch_2b", pic: string.Empty);
      }
      if (GameDataController.gd.getObjective("helicopter_covered") && GameDataController.gd.getObjective("helicopter_covered_taped"))
      {
        this.removeDanger += this.check(label: "r_d3_1_heli_1a", pic: "c_helicopter");
        this.removeDanger += this.check(20, "r_d3_1_heli_1b", string.Empty);
      }
      else if (GameDataController.gd.getObjective("helicopter_covered"))
      {
        this.removeDanger += this.check(label: "r_d3_1_heli_2a", pic: "c_helicopter");
        this.removeDanger += this.check(10, "r_d3_1_heli_2b", string.Empty);
      }
      else
      {
        this.removeDanger += this.check(label: "r_d3_1_heli_3a", pic: "hide");
        this.removeDanger += this.check(label: "r_d3_1_heli_3b", pic: string.Empty);
      }
      int num2 = this.pbc.total - this.removeDanger;
      if (num2 > 10)
        num2 = 10;
      if (!GameDataController.gd.getObjective("attic_hatch_open"))
      {
        this.removeDanger += this.check(label: "r_d3_hatch_1a", pic: "roof_hatch_closed");
        this.removeDanger += this.check(10, GameStrings.getString(GameStrings.results, "r_d3_hatch_1b") + " " + (object) num2 + GameStrings.getString(GameStrings.results, "r_d3_hatch_1c"), string.Empty, false);
      }
      else
      {
        this.removeDanger += this.check(label: "r_d3_hatch_2a", pic: "roof_hatch_open");
        this.removeDanger += this.check(label: "r_d3_hatch_2b", pic: string.Empty);
      }
      if (GameDataController.gd.getObjective("lighting_rod_installed"))
      {
        this.removeDanger += this.check(label: "r_d3_1_rod_1a", pic: "c_thunder_rod");
        this.removeDanger += this.check(20, "r_d3_1_rod_1b", string.Empty);
      }
      else
      {
        this.removeDanger += this.check(label: "r_d3_1_rod_2a", pic: "hide");
        this.removeDanger += this.check(label: "r_d3_1_rod_2b", pic: string.Empty);
      }
      if (this.removeDanger >= this.pbc.total)
        this.winQuality = 3;
      else
        this.winQuality = 2;
      int num3 = this.pbc.total - this.removeDanger;
      float num4 = 4f;
      float num5 = 4f;
      float num6 = 8f;
      float num7 = 8f;
      float num8 = 8f;
      float num9 = 8f;
      num3 = this.danger - this.removeDanger - (int) num4 - (int) num5 - (int) num6 - (int) num7 - (int) num8 - (int) num9;
      int danger1 = (int) num4 - 1;
      int danger2 = (int) num4;
      if (!GameDataController.gd.getObjective("location01_door2_open"))
      {
        if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 1 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 1)
        {
          this.removeDanger += this.check(label: "r_d3_1_door1_1a", pic: "c_door1_closed_towel");
          this.removeDanger += this.check(danger2, "r_d3_1_door1_1b", string.Empty);
        }
        else
        {
          this.removeDanger += this.check(label: "r_d3_1_door1_2a", pic: "c_door1_closed");
          this.removeDanger += this.check(danger1, "r_d3_1_door1_2b", string.Empty);
        }
      }
      else
      {
        this.removeDanger += this.check(label: "r_d3_1_door1_3a", pic: "c_door1_open");
        this.removeDanger += this.check(danger1, "r_d3_1_door1_3b", string.Empty);
      }
      if (!GameDataController.gd.getObjective("location02_door_open"))
      {
        if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 2 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 2)
        {
          this.removeDanger += this.check(label: "r_d3_1_door2_1a", pic: "c_door2_closed_towel");
          this.removeDanger += this.check(danger2, "r_d3_1_door2_1b", string.Empty);
        }
        else
        {
          this.removeDanger += this.check(label: "r_d3_1_door2_2a", pic: "c_door2_closed");
          this.removeDanger += this.check(danger1, "r_d3_1_door2_2b", string.Empty);
        }
      }
      else
      {
        this.removeDanger += this.check(label: "r_d3_1_door2_3a", pic: "c_door2_open");
        this.removeDanger += this.check(danger1, "r_d3_1_door2_3b", string.Empty);
      }
      TimelineAction timelineAction1 = new TimelineAction(Timeline.t.textField);
      timelineAction1.function = new TimelineFunction(((ResultsController) this).changeDanger);
      timelineAction1.actionWithText = true;
      int num10 = 0;
      int num11 = this.checkWindows(timelineAction1, "window1", "window_1", (int) num6);
      Timeline.t.addAction(timelineAction1);
      this.removeDanger += num11;
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        param = "-" + (object) num11,
        text = GameStrings.getString(GameStrings.results, "r_d3_1_window_result1") + " " + (object) num11 + " " + GameStrings.getString(GameStrings.results, "r_d3_1_window_result2")
      });
      TimelineAction timelineAction2 = new TimelineAction(Timeline.t.textField);
      timelineAction2.function = new TimelineFunction(((ResultsController) this).changeDanger);
      timelineAction2.actionWithText = true;
      num10 = 0;
      int num12 = this.checkWindows(timelineAction2, "window2", "window_2", (int) num7);
      Timeline.t.addAction(timelineAction2);
      this.removeDanger += num12;
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        param = "-" + (object) num12,
        text = GameStrings.getString(GameStrings.results, "r_d3_1_window_result1") + " " + (object) num12 + " " + GameStrings.getString(GameStrings.results, "r_d3_1_window_result2")
      });
      TimelineAction timelineAction3 = new TimelineAction(Timeline.t.textField);
      timelineAction3.function = new TimelineFunction(((ResultsController) this).changeDanger);
      timelineAction3.actionWithText = true;
      num10 = 0;
      int num13 = this.checkWindows(timelineAction3, "window3", "window_3", (int) num8);
      Timeline.t.addAction(timelineAction3);
      TimelineAction action1 = new TimelineAction(Timeline.t.textField);
      action1.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action1.param = "-" + (object) num13;
      action1.text = GameStrings.getString(GameStrings.results, "r_d3_1_window_result1") + " " + (object) num13 + " " + GameStrings.getString(GameStrings.results, "r_d3_1_window_result2");
      this.removeDanger += num13;
      Timeline.t.addAction(action1);
      TimelineAction action2 = new TimelineAction(Timeline.t.textField);
      action2.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action2.actionWithText = true;
      num10 = 0;
      int danger3;
      if (GameDataController.gd.getObjective("base_hatch_therm"))
      {
        danger3 = (int) num9;
        action2.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_hatch_therm";
        action2.text = GameStrings.getString(GameStrings.results, "hatch_therm");
      }
      else if (GameDataController.gd.getObjective("base_hatch_flag"))
      {
        danger3 = (int) num9;
        action2.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_hatch_flag";
        action2.text = GameStrings.getString(GameStrings.results, "hatch_flag");
      }
      else if (GameDataController.gd.getObjective("base_hatch_blanketb"))
      {
        danger3 = (int) num9;
        action2.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_hatch_blanketb";
        action2.text = GameStrings.getString(GameStrings.results, "hatch_blanketb");
      }
      else if (GameDataController.gd.getObjective("base_hatch_blanket"))
      {
        danger3 = (int) num9;
        action2.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_hatch_blanket";
        action2.text = GameStrings.getString(GameStrings.results, "hatch_blanket");
      }
      else
      {
        danger3 = 0;
        action2.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_hatch_empty";
        action2.text = GameStrings.getString(GameStrings.results, "hatch_empty");
      }
      Timeline.t.addAction(action2);
      this.removeDanger += this.check(danger3, GameStrings.getString(GameStrings.results, "r_d3_1_hatch_result1") + " " + (object) danger3 + " " + GameStrings.getString(GameStrings.results, "r_d3_1_hatch_result2"), string.Empty, false);
      if (this.danger - this.removeDanger > 10)
      {
        this.removeDanger += this.check(label: (GameStrings.getString(GameStrings.results, "r_d3_1_bad_1a") + " " + GameStrings.getString(GameStrings.results, "r_d3_1_bad_1b")), pic: "hide", trackWasShortened: false);
        if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
        {
          this.removeDanger += this.check(label: "r_d3_1_cody_1a", pic: "c_cody_drowned");
          this.removeDanger += this.check(label: "r_d3_1_cody_1b", pic: string.Empty);
          this.winQuality = 1;
          GameDataController.gd.setObjective("npc3_alive", false);
          GameDataController.gd.setObjectiveDetail("npc3_alive", 2);
        }
        if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive"))
        {
          this.removeDanger += this.check(label: "r_d3_1_barry_1a", pic: "c_barry_drowned");
          this.removeDanger += this.check(label: "r_d3_1_barry_1b", pic: string.Empty);
          this.winQuality = 1;
          GameDataController.gd.setObjective("npc2_alive", false);
          GameDataController.gd.setObjectiveDetail("npc2_alive", 2);
        }
      }
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).liveOrDie),
        actionWithText = true,
        param = "0",
        text = string.Empty
      });
    }
    else
    {
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        text = GameStrings.getString(GameStrings.results, "r_d3_1_1b1"),
        function = new TimelineFunction(((ResultsController) this).liveOrDie)
      });
      this.analytics_stayed = "outside";
    }
  }
}
