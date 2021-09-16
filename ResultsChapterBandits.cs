// Decompiled with JetBrains decompiler
// Type: ResultsChapterBandits
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class ResultsChapterBandits : ResultsController
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
    int num2 = value1 - 3;
    int num3 = value1;
    int num4 = value1 - 3;
    int num5 = value1;
    int num6 = value1 - 3;
    int num7 = value1;
    int num8 = value1 - 3;
    int num9 = 1;
    int num10;
    if (GameDataController.gd.getObjective("base_" + name1 + "_broken"))
    {
      num10 = 0;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_empty";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_open") + " " + GameStrings.getString(GameStrings.results, "window_broken_barricade");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_blanketb_nailed") && GameDataController.gd.getObjective("base_" + name2 + "_blanketb_taped"))
    {
      num10 = num1;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_blanketb_3";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_taped_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_blanketb_taped"))
    {
      num10 = num1 - num9;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_blanketb_2";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_taped");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_blanketb_nailed"))
    {
      num10 = num1 - num9;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_blanketb_1";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_blanketb"))
    {
      num10 = num2;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_blanketb_0";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_none");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_blanket_nailed") && GameDataController.gd.getObjective("base_" + name2 + "_blanket_taped"))
    {
      num10 = num3;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_blanket_3";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_taped_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_blanket_taped"))
    {
      num10 = num3 - num9;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_blanket_2";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_taped");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_blanket_nailed"))
    {
      num10 = num3 - num9;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_blanket_1";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_blanket"))
    {
      num10 = num4;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_blanket_0";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_none");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_flag_nailed") && GameDataController.gd.getObjective("base_" + name2 + "_flag_taped"))
    {
      num10 = num5;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_flag_3";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_flag") + " " + GameStrings.getString(GameStrings.results, "flag_taped_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_flag_taped"))
    {
      num10 = num5 - num9;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_flag_2";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_flag") + " " + GameStrings.getString(GameStrings.results, "flag_taped");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_flag_nailed"))
    {
      num10 = num5 - num9;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_flag_1";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_flag") + " " + GameStrings.getString(GameStrings.results, "flag_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_flag"))
    {
      num10 = num6;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_flag_0";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_flag") + " " + GameStrings.getString(GameStrings.results, "flag_none");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_therm_nailed") && GameDataController.gd.getObjective("base_" + name2 + "_therm_taped"))
    {
      num10 = num7;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_therm_3";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_therm") + " " + GameStrings.getString(GameStrings.results, "therm_taped_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_therm_taped"))
    {
      num10 = num7 - num9;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_value1_therm_2";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_therm") + " " + GameStrings.getString(GameStrings.results, "therm_taped");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_therm_nailed"))
    {
      num10 = num7 - num9;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_therm_1";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_therm") + " " + GameStrings.getString(GameStrings.results, "therm_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_therm"))
    {
      num10 = num8;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_therm_0";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_therm") + " " + GameStrings.getString(GameStrings.results, "therm_none");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_net_nailed") && GameDataController.gd.getObjective("base_" + name2 + "_net_taped"))
    {
      num10 = 0;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_net_3";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_net") + " " + GameStrings.getString(GameStrings.results, "net_taped_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_net_taped"))
    {
      num10 = 0;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_net_2";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_net") + " " + GameStrings.getString(GameStrings.results, "net_taped");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_net_nailed"))
    {
      num10 = 0;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_net_1";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_net") + " " + GameStrings.getString(GameStrings.results, "net_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_net"))
    {
      num10 = 0;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_net_0";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_net") + " " + GameStrings.getString(GameStrings.results, "net_none");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_foil_nailed") && GameDataController.gd.getObjective("base_" + name2 + "_foil_taped"))
    {
      num10 = num3 / 2;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_foil_3";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_foil_taped"))
    {
      num10 = num3 / 2;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_foil_2";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_foil_nailed"))
    {
      num10 = num3 / 2;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_foil_1";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_foil") + " " + GameStrings.getString(GameStrings.results, "foil_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_foil"))
    {
      num10 = num4 / 2;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_foil_0";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_foil") + GameStrings.getString(GameStrings.results, "foil_none");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_bars_nailed") && GameDataController.gd.getObjective("base_" + name2 + "_bars_taped"))
    {
      num10 = 0;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_bars_3";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_bars_taped"))
    {
      num10 = 0;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_bars_2";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_bars_nailed"))
    {
      num10 = 0;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_bars_1";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_bars") + " " + GameStrings.getString(GameStrings.results, "bars_nailed");
    }
    else if (GameDataController.gd.getObjective("base_" + name2 + "_bars"))
    {
      num10 = 0;
      if (num10 > value1)
        num10 = value1;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_bars_0";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_bars") + " " + GameStrings.getString(GameStrings.results, "bars_none");
    }
    else
    {
      num10 = 0;
      tla.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_" + name1 + "_empty";
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_open");
    }
    return num10;
  }

  public override void chapterResult()
  {
    this.surviavbleDanger = 1;
    this.danger = 0;
    this.removeDanger = 0;
    this.winQuality = 3;
    this.pbc.total = 20;
    this.changeDanger(this.pbc.total.ToString());
    Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
    {
      text = GameStrings.getString(GameStrings.results, "r_d3_0_1a1")
    });
    if (GameDataController.gd.previousLocation == "Location1" || GameDataController.gd.previousLocation == "Location2" || GameDataController.gd.previousLocation == "LocationBaseUpstairs" || GameDataController.gd.previousLocation == "LocationBaseBathroom" || GameDataController.gd.previousLocation == "LocationRoof1" || GameDataController.gd.previousLocation == "LocationRoof2" || GameDataController.gd.previousLocation == "LocationAttic1" || GameDataController.gd.previousLocation == "LocationAttic2")
    {
      this.analytics_stayed = "base";
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        text = GameStrings.getString(GameStrings.results, "r_d3_0_1a2")
      });
      if (GameDataController.gd.getObjective("gasstation_sarge_shot") || GameDataController.gd.getObjective("gasstation_sarge_convinced") || GameDataController.gd.getObjective("cs_food_poisioned") || GameDataController.gd.getObjective("cs_thug_shot") || ItemsManager.im.getItem("whiskey").dataRef.droppedLocation == "CS3")
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0,
          text = GameStrings.getString(GameStrings.results, "r_d3_0_2")
        });
        if (ItemsManager.im.getItem("whiskey").dataRef.droppedLocation == "CS3")
        {
          this.analytics_whiskey_dumped = "true";
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            actionWithText = true,
            param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_alcohol",
            text = GameStrings.getString(GameStrings.results, "r_d3_0_3a1")
          });
          TimelineAction action = new TimelineAction(Timeline.t.textField);
          action.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action.actionWithText = false;
          action.param = "-" + (object) 2;
          this.removeDanger += 2;
          action.text = GameStrings.getString(GameStrings.results, "r_d3_0_3a2");
          Timeline.t.addAction(action);
        }
        if (GameDataController.gd.getObjective("cs_food_poisioned"))
        {
          this.analytics_food_poisoned = "true";
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            actionWithText = true,
            param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_poision",
            text = GameStrings.getString(GameStrings.results, "r_d3_0_4a1")
          });
          TimelineAction action = new TimelineAction(Timeline.t.textField);
          action.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action.actionWithText = false;
          action.param = "-" + (object) 3;
          this.removeDanger += 3;
          action.text = GameStrings.getString(GameStrings.results, "r_d3_0_4a2");
          Timeline.t.addAction(action);
        }
        if (GameDataController.gd.getObjective("cs_thug_shot"))
        {
          if (GameDataController.gd.getObjectiveDetail("cs_thug_shot") == 0)
          {
            this.analytics_guard_killed = "true";
            Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
            {
              function = new TimelineFunction(((ResultsController) this).changeDanger),
              actionWithText = true,
              param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_thugshot",
              text = GameStrings.getString(GameStrings.results, "r_d3_0_5a1")
            });
            TimelineAction action = new TimelineAction(Timeline.t.textField);
            action.function = new TimelineFunction(((ResultsController) this).changeDanger);
            action.actionWithText = false;
            action.param = "-" + (object) 1;
            ++this.removeDanger;
            action.text = GameStrings.getString(GameStrings.results, "r_d3_0_5a2");
            Timeline.t.addAction(action);
          }
          else
          {
            Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
            {
              function = new TimelineFunction(((ResultsController) this).changeDanger),
              actionWithText = true,
              param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_thugshot",
              text = GameStrings.getString(GameStrings.results, "r_d3_0_5b1")
            });
            TimelineAction action = new TimelineAction(Timeline.t.textField);
            action.function = new TimelineFunction(((ResultsController) this).changeDanger);
            action.actionWithText = false;
            action.param = "-" + (object) 1;
            ++this.removeDanger;
            action.text = GameStrings.getString(GameStrings.results, "r_d3_0_5b2");
            Timeline.t.addAction(action);
          }
        }
        if (GameDataController.gd.getObjective("gasstation_sarge_shot"))
        {
          this.analytics_sarge_status = "killed";
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            actionWithText = true,
            param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_sarge_dead",
            text = GameStrings.getString(GameStrings.results, "r_d3_0_6a1")
          });
          TimelineAction action = new TimelineAction(Timeline.t.textField);
          action.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action.actionWithText = false;
          action.param = "-" + (object) 1;
          ++this.removeDanger;
          action.text = GameStrings.getString(GameStrings.results, "r_d3_0_6a2");
          Timeline.t.addAction(action);
        }
        if (GameDataController.gd.getObjective("gasstation_sarge_convinced"))
        {
          this.analytics_sarge_status = "convinced";
          if (GameDataController.gd.getObjective("cs_food_poisioned"))
          {
            Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
            {
              function = new TimelineFunction(((ResultsController) this).changeDanger),
              actionWithText = true,
              param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_sarge_poision",
              text = GameStrings.getString(GameStrings.results, "r_d3_0_6b1")
            });
            Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
            {
              function = new TimelineFunction(((ResultsController) this).changeDanger),
              actionWithText = false,
              param = "-" + (object) 0,
              text = GameStrings.getString(GameStrings.results, "r_d3_0_6b2")
            });
          }
          else
          {
            Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
            {
              function = new TimelineFunction(((ResultsController) this).changeDanger),
              actionWithText = true,
              param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_sarge_leave",
              text = GameStrings.getString(GameStrings.results, "r_d3_0_6c1")
            });
            TimelineAction action = new TimelineAction(Timeline.t.textField);
            action.function = new TimelineFunction(((ResultsController) this).changeDanger);
            action.actionWithText = false;
            action.param = "-" + (object) 5;
            this.removeDanger += 5;
            action.text = GameStrings.getString(GameStrings.results, "r_d3_0_6c2");
            Timeline.t.addAction(action);
          }
        }
      }
      this.removeDanger += this.check(label: ((this.danger - this.removeDanger).ToString() + " " + GameStrings.getString(GameStrings.results, "r_d3_0_7")), pic: string.Empty, trackWasShortened: false);
      this.removeDanger += this.check(label: "r_d3_0_9a1", pic: "c_thugsfire");
      this.removeDanger += this.check(label: "r_d3_0_9a2", pic: string.Empty);
      if (GameDataController.gd.getObjective("cs_ammo_oiled") || GameDataController.gd.getObjective("cs_ammo_watered"))
      {
        this.analytics_ammo_sabotaged = "true";
        this.removeDanger += this.check(label: "r_d3_0_10a1", pic: "c_ammo");
        this.removeDanger += this.check(3, "r_d3_0_10a2", string.Empty);
      }
      if (InventoryController.ic.isItemEquipped("rifle_so_6") || InventoryController.ic.isItemEquipped("rifle_so_5") || InventoryController.ic.isItemEquipped("rifle_so_4") || InventoryController.ic.isItemEquipped("rifle_so_3") || InventoryController.ic.isItemEquipped("rifle_so_2") || InventoryController.ic.isItemEquipped("rifle_so_1") || InventoryController.ic.isItemEquipped("rifle_s_6") || InventoryController.ic.isItemEquipped("rifle_s_5") || InventoryController.ic.isItemEquipped("rifle_s_4") || InventoryController.ic.isItemEquipped("rifle_s_3") || InventoryController.ic.isItemEquipped("rifle_s_2") || InventoryController.ic.isItemEquipped("rifle_s_1") || InventoryController.ic.isItemEquipped("rifle_o_6") || InventoryController.ic.isItemEquipped("rifle_o_5") || InventoryController.ic.isItemEquipped("rifle_o_4") || InventoryController.ic.isItemEquipped("rifle_o_3") || InventoryController.ic.isItemEquipped("rifle_o_2") || InventoryController.ic.isItemEquipped("rifle_o_1") || InventoryController.ic.isItemEquipped("rifle_6") || InventoryController.ic.isItemEquipped("rifle_5") || InventoryController.ic.isItemEquipped("rifle_4") || InventoryController.ic.isItemEquipped("rifle_3") || InventoryController.ic.isItemEquipped("rifle_2") || InventoryController.ic.isItemEquipped("rifle_1"))
      {
        if (InventoryController.ic.isItemEquipped("rifle_so_6") || InventoryController.ic.isItemEquipped("rifle_so_5") || InventoryController.ic.isItemEquipped("rifle_so_4") || InventoryController.ic.isItemEquipped("rifle_so_3") || InventoryController.ic.isItemEquipped("rifle_so_2") || InventoryController.ic.isItemEquipped("rifle_so_1") || InventoryController.ic.isItemEquipped("rifle_o_6") || InventoryController.ic.isItemEquipped("rifle_o_5") || InventoryController.ic.isItemEquipped("rifle_o_4") || InventoryController.ic.isItemEquipped("rifle_o_3") || InventoryController.ic.isItemEquipped("rifle_o_2") || InventoryController.ic.isItemEquipped("rifle_o_1"))
        {
          int danger = 6;
          if (GameDataController.gd.equipped.IndexOf("_6") != -1)
            danger = 5;
          if (GameDataController.gd.equipped.IndexOf("_5") != -1)
            danger = 4;
          if (GameDataController.gd.equipped.IndexOf("_4") != -1)
            danger = 3;
          if (GameDataController.gd.equipped.IndexOf("_3") != -1)
            danger = 2;
          if (GameDataController.gd.equipped.IndexOf("_2") != -1)
            danger = 2;
          if (GameDataController.gd.equipped.IndexOf("_1") != -1)
            danger = 1;
          if (GameDataController.gd.equipped.IndexOf("_0") != -1)
            danger = 0;
          string str = "_a";
          if (GameDataController.gd.previousLocation == "Location1" || GameDataController.gd.previousLocation == "Location2")
          {
            str = "_b";
            if (danger >= 2)
              --danger;
          }
          else if (GameDataController.gd.previousLocation == "LocationBaseUpstairs" || GameDataController.gd.previousLocation == "LocationBaseBathroom")
            str = "_a";
          else if (GameDataController.gd.previousLocation == "LocationRoof1" || GameDataController.gd.previousLocation == "LocationRoof2")
          {
            str = "_d";
            if (danger >= 4)
              ++danger;
          }
          else if (GameDataController.gd.previousLocation == "LocationAttic1" || GameDataController.gd.previousLocation == "LocationAttic2")
            str = "_c";
          this.removeDanger += this.check(label: ("r_d3_0_11c1" + str), pic: ("c_rifle_bandits" + str));
          this.removeDanger += this.check(danger, "r_d3_0_11c2-" + (object) danger, string.Empty);
          this.analytics_weapon = "sniper_rifle_" + (object) danger;
        }
        else
        {
          int danger = 3;
          int num = 0;
          if (GameDataController.gd.equipped.IndexOf("_6") != -1)
          {
            danger = 3;
            num = 6;
          }
          if (GameDataController.gd.equipped.IndexOf("_5") != -1)
          {
            danger = 3;
            num = 5;
          }
          if (GameDataController.gd.equipped.IndexOf("_4") != -1)
          {
            danger = 2;
            num = 4;
          }
          if (GameDataController.gd.equipped.IndexOf("_3") != -1)
          {
            danger = 2;
            num = 3;
          }
          if (GameDataController.gd.equipped.IndexOf("_2") != -1)
          {
            danger = 1;
            num = 2;
          }
          if (GameDataController.gd.equipped.IndexOf("_1") != -1)
          {
            danger = 1;
            num = 1;
          }
          if (GameDataController.gd.equipped.IndexOf("_0") != -1)
          {
            danger = 0;
            num = 0;
          }
          this.analytics_weapon = "rifle_" + (object) num;
          string str = "_a";
          if (GameDataController.gd.previousLocation == "Location1" || GameDataController.gd.previousLocation == "Location2")
          {
            str = "_b";
            if (danger >= 2)
              --danger;
          }
          else if (GameDataController.gd.previousLocation == "LocationBaseUpstairs" || GameDataController.gd.previousLocation == "LocationBaseBathroom")
            str = "_a";
          else if (GameDataController.gd.previousLocation == "LocationRoof1" || GameDataController.gd.previousLocation == "LocationRoof2")
          {
            str = "_d";
            if (danger == 3)
              ++danger;
          }
          else if (GameDataController.gd.previousLocation == "LocationAttic1" || GameDataController.gd.previousLocation == "LocationAttic2")
            str = "_c";
          this.removeDanger += this.check(label: ("r_d3_0_11b1" + str), pic: ("c_rifle_bandits" + str));
          this.removeDanger += this.check(danger, "r_d3_0_11b2-" + (object) danger, string.Empty);
        }
        if (InventoryController.ic.isItemInInventory("rifle_ammo"))
        {
          this.analytics_weapon += "+clip";
          this.removeDanger += this.check(label: "r_d3_0_12a0", pic: "c_rifle_ammo");
          if (this.danger - this.removeDanger > 1)
            this.removeDanger += this.check(1, "r_d3_0_12a1", string.Empty);
          else
            this.removeDanger += this.check(1, "r_d3_0_12a_last", string.Empty);
        }
      }
      int num1 = this.checkTrap("bear_trap_1");
      int num2 = this.checkTrap("bear_trap_2");
      int num3 = this.checkTrap("bear_trap_3");
      int num4 = this.checkTrap("bear_trap_4");
      int num5 = 0;
      if (num1 == 1)
        ++num5;
      if (num2 == 1)
        ++num5;
      if (num3 == 1)
        ++num5;
      if (num4 == 1)
        ++num5;
      this.analytics_traps = string.Empty + (object) num5 + "/4";
      if (num5 == 1)
      {
        this.removeDanger += this.check(label: "r_d3_0_13a1", pic: "c_beartrap_0");
        this.removeDanger += this.check(label: "r_d3_0_13a2", pic: string.Empty);
      }
      if (num5 > 1)
      {
        int danger = num5 - 1;
        if (danger >= this.danger - this.removeDanger)
          danger = this.danger - this.removeDanger - 1;
        this.removeDanger += this.check(label: "r_d3_0_13b1", pic: "c_beartrap_0");
        if (danger > 1)
          this.removeDanger += this.check(danger, GameStrings.getString(GameStrings.results, "r_d3_0_13b2") + " " + (object) num5 + " " + GameStrings.getString(GameStrings.results, "r_d3_0_13b3") + " " + (object) danger + " " + GameStrings.getString(GameStrings.results, "r_d3_0_13b4a1"), "c_beartrap_bandits", false);
        else if (danger == 1)
          this.removeDanger += this.check(danger, GameStrings.getString(GameStrings.results, "r_d3_0_13b2") + " " + (object) num5 + " " + GameStrings.getString(GameStrings.results, "r_d3_0_13b3") + " " + GameStrings.getString(GameStrings.results, "r_d3_0_13b4b1"), "c_beartrap_bandits", false);
        else if (this.danger - this.removeDanger == 1)
          this.removeDanger += this.check(danger, GameStrings.getString(GameStrings.results, "r_d3_0_13b4c1"), "c_trap_razor", false);
      }
      int num6 = 2;
      if (GameDataController.gd.getObjective("location01_door2_locked") && !GameDataController.gd.getObjective("location01_door2_open"))
        this.removeDanger += this.check(label: "r_d3_0_14a1", pic: "c_door1_closed");
      else if (!GameDataController.gd.getObjective("location01_door2_locked") && !GameDataController.gd.getObjective("location01_door2_open"))
      {
        this.removeDanger += this.check(label: "r_d3_0_14b1", pic: "c_door1_closed");
        num6 = 1;
      }
      else if (GameDataController.gd.getObjective("location01_door2_open"))
      {
        this.removeDanger += this.check(label: "r_d3_0_14c1", pic: "c_door1_open");
        num6 = 0;
      }
      if (GameDataController.gd.getObjective("location02_door_locked") && !GameDataController.gd.getObjective("location02_door_open"))
        this.removeDanger += this.check(label: "r_d3_0_15a1", pic: "c_door2_closed");
      else if (!GameDataController.gd.getObjective("location02_door_locked") && !GameDataController.gd.getObjective("location02_door_open"))
      {
        this.removeDanger += this.check(label: "r_d3_0_15b1", pic: "c_door2_closed");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("location02_door_open"))
      {
        this.removeDanger += this.check(label: "r_d3_0_15c1", pic: "c_door2_open");
        num6 = 0;
      }
      if (GameDataController.gd.getObjective("base_window1_broken"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16c1", pic: "c_window1_empty");
        num6 = 0;
      }
      else if (GameDataController.gd.getObjective("base_window_1_bars_nailed") && GameDataController.gd.getObjective("base_window_1_bars_taped"))
        this.removeDanger += this.check(label: "r_d3_0_16a1", pic: "c_window1_bars_3");
      else if (GameDataController.gd.getObjective("base_window_1_bars_nailed"))
        this.removeDanger += this.check(label: "r_d3_0_16a1", pic: "c_window1_bars_1");
      else if (GameDataController.gd.getObjective("base_window_1_bars_taped"))
        this.removeDanger += this.check(label: "r_d3_0_16a1", pic: "c_window1_bars_2");
      else if (GameDataController.gd.getObjective("base_window_1_net") && GameDataController.gd.getObjective("base_window_1_net_nailed") && GameDataController.gd.getObjective("base_window_1_net_taped"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_net_3");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_net") && GameDataController.gd.getObjective("base_window_1_net_taped"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_net_2");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_net") && GameDataController.gd.getObjective("base_window_1_net_nailed"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_net_1");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_net"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_net_0");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_foil") && GameDataController.gd.getObjective("base_window_1_foil_nailed") && GameDataController.gd.getObjective("base_window_1_foil_taped"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_foil_3");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_foil") && GameDataController.gd.getObjective("base_window_1_foil_taped"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_foil_2");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_foil") && GameDataController.gd.getObjective("base_window_1_foil_nailed"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_foil_1");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_foil"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_foil_0");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_bars"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_bars_0");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_blanketb") && GameDataController.gd.getObjective("base_window_1_blanketb_nailed") && GameDataController.gd.getObjective("base_window_1_blanketb_taped"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_blanketb_3");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_blanketb") && GameDataController.gd.getObjective("base_window_1_blanketb_taped"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_blanketb_2");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_blanketb") && GameDataController.gd.getObjective("base_window_1_blanketb_nailed"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_blanketb_1");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_blanketb"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_blanketb_0");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_blanket") && GameDataController.gd.getObjective("base_window_1_blanket_nailed") && GameDataController.gd.getObjective("base_window_1_blanket_taped"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_blanket_3");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_blanket") && GameDataController.gd.getObjective("base_window_1_blanket_taped"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_blanket_2");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_blanket") && GameDataController.gd.getObjective("base_window_1_blanket_nailed"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_blanket_1");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_blanket"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_blanket_0");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_flag") && GameDataController.gd.getObjective("base_window_1_flag_nailed") && GameDataController.gd.getObjective("base_window_1_flag_taped"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_flag_3");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_flag") && GameDataController.gd.getObjective("base_window_1_flag_taped"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_flag_2");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_flag") && GameDataController.gd.getObjective("base_window_1_flag_nailed"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_flag_1");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_flag"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_flag_0");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_therm") && GameDataController.gd.getObjective("base_window_1_therm_nailed") && GameDataController.gd.getObjective("base_window_1_therm_taped"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_therm_3");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_therm") && GameDataController.gd.getObjective("base_window_1_therm_taped"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_therm_2");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_therm") && GameDataController.gd.getObjective("base_window_1_therm_nailed"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_therm_1");
        if (num6 >= 1)
          num6 = 1;
      }
      else if (GameDataController.gd.getObjective("base_window_1_therm"))
      {
        this.removeDanger += this.check(label: "r_d3_0_16b1", pic: "c_window1_therm_0");
        if (num6 >= 1)
          num6 = 1;
      }
      else
      {
        this.removeDanger += this.check(label: "r_d3_0_16c1", pic: "c_window1_empty");
        num6 = 0;
      }
      this.analytics_doors_and_windows = num6.ToString() + string.Empty;
      if (this.removeDanger + 1 >= this.pbc.total)
        this.winQuality = 3;
      else
        this.winQuality = 2;
      if (num6 < 2)
      {
        if (this.removeDanger < this.pbc.total)
          this.winQuality = 2;
        if (this.danger - this.removeDanger > 1)
        {
          string pic = "c_bandits_enter";
          if (this.danger - this.removeDanger == 2)
            pic = "c_bandits_enter_2";
          this.removeDanger += this.check(label: (GameStrings.getString(GameStrings.results, "r_d3_0_17a1a1") + " " + (object) (this.danger - this.removeDanger) + " " + GameStrings.getString(GameStrings.results, "r_d3_0_17a1a2")), pic: pic, trackWasShortened: false);
          if (num6 == 1)
            this.removeDanger += this.check(1, "r_d3_0_17a1a3", string.Empty);
          else
            this.removeDanger += this.check(label: "r_d3_0_17a1a4", pic: string.Empty);
        }
        else
        {
          this.removeDanger += this.check(label: "r_d3_0_17a1b1", pic: "c_bandits_enter_razor");
          if (num6 == 1)
            this.removeDanger += this.check(1, "r_d3_0_17a1b2", string.Empty);
        }
      }
      else
      {
        int danger = 2;
        if (this.danger - this.removeDanger > 1)
        {
          if (this.danger - this.removeDanger == 2)
            danger = 1;
          this.removeDanger += this.check(label: (GameStrings.getString(GameStrings.results, "r_d3_0_17b1a1") + " " + (object) danger + " " + GameStrings.getString(GameStrings.results, "r_d3_0_17b1a2")), pic: "c_cate_bandits", trackWasShortened: false);
          this.removeDanger += this.check(danger, "r_d3_0_17b1a3", string.Empty);
        }
        else
        {
          this.removeDanger += this.check(label: "r_d3_0_17b1b1", pic: "c_razor");
          this.removeDanger += this.check(1, "r_d3_0_17b1b2", string.Empty);
        }
      }
      if (GameDataController.gd.getObjective("npc3_alive"))
      {
        if (ItemsManager.im.getItem("revolver_6").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("revolver_5").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("revolver_4").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("revolver_3").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("revolver_2").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("revolver_1").dataRef.droppedLocation == "npc3")
        {
          this.removeDanger += this.check(label: "r_d3_0_18a1", pic: "c_cody_bandits");
          this.removeDanger += this.check(label: "r_d3_0_18a2", pic: string.Empty);
          if (this.danger - this.removeDanger > 1)
          {
            this.removeDanger += this.check(1, "r_d3_0_18a3a1", string.Empty);
            GameDataController.gd.setObjective("cody_killed_someone", true);
          }
          else
            this.removeDanger += this.check(1, "r_d3_0_18a3b1", string.Empty);
        }
        else
          this.removeDanger += this.check(label: "r_d3_0_18b1", pic: "c_cody2_bandits");
      }
      if (GameDataController.gd.getObjective("npc2_alive"))
      {
        if (ItemsManager.im.getItem("revolver_6").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("revolver_5").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("revolver_4").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("revolver_3").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("revolver_2").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("revolver_1").dataRef.droppedLocation == "npc2")
        {
          this.removeDanger += this.check(label: "r_d3_0_19a1", pic: "c_barry_bandits");
          if (this.danger - this.removeDanger > 2)
            this.removeDanger += this.check(2, "r_d3_0_19a2a1", string.Empty);
          else if (this.danger - this.removeDanger > 1)
            this.removeDanger += this.check(1, "r_d3_0_19a2b1", string.Empty);
          else
            this.removeDanger += this.check(1, "r_d3_0_19a2c1", string.Empty);
        }
        else
        {
          this.removeDanger += this.check(label: "r_d3_0_19b1a1", pic: "c_barry2_bandits");
          if (this.danger - this.removeDanger > 1)
          {
            this.removeDanger += this.check(1, "r_d3_0_19b1a2", string.Empty);
          }
          else
          {
            this.removeDanger += this.check(label: "r_d3_0_19b1b1", pic: string.Empty);
            this.removeDanger += this.check(1, "r_d3_0_19b1b2", string.Empty);
          }
        }
      }
      if (GameDataController.gd.equipped.IndexOf("rifle") == -1)
        this.analytics_weapon = GameDataController.gd.equipped;
      if (GameDataController.gd.equipped.IndexOf("rifle") == -1 && GameDataController.gd.equipped != "flamethrower" && GameDataController.gd.equipped.IndexOf("revolver") == -1 && GameDataController.gd.equipped != string.Empty)
      {
        string str = "c_banditfight_" + GameDataController.gd.equipped;
        if (this.danger - this.removeDanger > 1)
        {
          this.removeDanger += this.check(label: (GameStrings.getString(GameStrings.results, "r_d3_0_20a1a1") + " " + (object) (this.danger - this.removeDanger) + " " + GameStrings.getString(GameStrings.results, "r_d3_0_20a1a2")), pic: string.Empty, trackWasShortened: false);
          this.removeDanger += this.check(label: (GameStrings.getString(GameStrings.results, "r_d3_0_20a1a3") + " " + GameStrings.getPrefixedShort(GameStrings.items, GameDataController.gd.equipped) + " " + GameStrings.getString(GameStrings.results, "r_d3_0_20a1a4")), pic: string.Empty, trackWasShortened: false);
          this.removeDanger += this.check(1, "r_d3_0_20a1a5", string.Empty);
        }
        else
        {
          this.removeDanger += this.check(label: GameStrings.getString(GameStrings.results, "r_d3_0_20a1b1"), pic: string.Empty, trackWasShortened: false);
          this.removeDanger += this.check(label: (GameStrings.getString(GameStrings.results, "r_d3_0_20a1a3") + " " + GameStrings.getPrefixedShort(GameStrings.items, GameDataController.gd.equipped) + " " + GameStrings.getString(GameStrings.results, "r_d3_0_20a1a4")), pic: "c_razor", trackWasShortened: false);
          this.removeDanger += this.check(1, "r_d3_0_20a1b2", string.Empty);
        }
      }
      else if (GameDataController.gd.equipped == "flamethrower")
      {
        if (this.danger - this.removeDanger > 1)
        {
          this.removeDanger += this.check(label: (GameStrings.getString(GameStrings.results, "r_d3_0_20b1a1") + " " + (object) (this.danger - this.removeDanger) + " " + GameStrings.getString(GameStrings.results, "r_d3_0_20b1a2")), pic: "c_flamethrower_bandits", trackWasShortened: false);
          this.removeDanger += this.check(1, GameStrings.getString(GameStrings.results, "r_d3_0_20b1a3"), string.Empty, false);
        }
        else
        {
          this.removeDanger += this.check(label: GameStrings.getString(GameStrings.results, "r_d3_0_20b1b1"), pic: "c_razor", trackWasShortened: false);
          this.removeDanger += this.check(1, GameStrings.getString(GameStrings.results, "r_d3_0_20b1b2"), string.Empty, false);
        }
      }
      else if (GameDataController.gd.equipped.IndexOf("rifle") == -1 && GameDataController.gd.equipped != string.Empty)
      {
        if (this.danger - this.removeDanger > 1)
        {
          this.removeDanger += this.check(label: (GameStrings.getString(GameStrings.results, "r_d3_0_20c1a1") + " " + (object) (this.danger - this.removeDanger) + " " + GameStrings.getString(GameStrings.results, "r_d3_0_20c1a2")), pic: "c_banditfight_gun", trackWasShortened: false);
          int danger = 2;
          if (this.danger - this.removeDanger == 2)
            danger = 1;
          this.removeDanger += this.check(danger, GameStrings.getString(GameStrings.results, "r_d3_0_20c1a3") + " " + (object) danger + " " + GameStrings.getString(GameStrings.results, "r_d3_0_20c1a4"), string.Empty, false);
        }
        else
        {
          this.removeDanger += this.check(label: GameStrings.getString(GameStrings.results, "r_d3_0_20c1b1"), pic: "c_razor", trackWasShortened: false);
          this.removeDanger += this.check(label: GameStrings.getString(GameStrings.results, "r_d3_0_20c1b2"), pic: string.Empty, trackWasShortened: false);
          this.removeDanger += this.check(1, GameStrings.getString(GameStrings.results, "r_d3_0_20c1b3"), string.Empty, false);
        }
        if (InventoryController.ic.isItemInInventory("gun_ammo"))
        {
          this.removeDanger += this.check(label: "r_d3_0_21a1", pic: "c_gun_ammo");
          if (this.danger - this.removeDanger > 1)
            this.removeDanger += this.check(1, "r_d3_0_21a2a1", string.Empty);
          else
            this.removeDanger += this.check(1, "r_d3_0_21a2b1", string.Empty);
        }
      }
      if (this.danger - this.removeDanger > 1)
      {
        this.removeDanger += this.check(label: (GameStrings.getString(GameStrings.results, "r_d3_0_22a1") + " " + (object) (this.danger - this.removeDanger) + " " + GameStrings.getString(GameStrings.results, "r_d3_0_22a2")), pic: string.Empty, trackWasShortened: false);
        if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive"))
        {
          this.removeDanger += this.check(label: "r_d3_0_22a3a1", pic: "c_barry_dead_bandits");
          this.winQuality = 1;
          GameDataController.gd.setObjective("npc2_alive", false);
          GameDataController.gd.setObjectiveDetail("npc2_alive", 2);
        }
        if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
        {
          this.removeDanger += this.check(label: "r_d3_0_22a3a2", pic: "c_cody_dead_bandits");
          this.winQuality = 1;
          GameDataController.gd.setObjective("npc3_alive", false);
          GameDataController.gd.setObjectiveDetail("npc3_alive", 2);
        }
        if (GameDataController.gd.getObjective("npc2_joined") && !GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjectiveDetail("npc2_alive") == 2 || GameDataController.gd.getObjective("npc3_joined") && !GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjectiveDetail("npc3_alive") == 2)
        {
          this.removeDanger += this.check(label: "r_d3_0_22a3a3", pic: string.Empty);
          this.removeDanger += this.check(label: "r_d3_0_22a3a4", pic: string.Empty);
          if (this.danger - this.removeDanger <= 3)
          {
            this.removeDanger += this.check(this.danger - this.removeDanger - 1, "r_d3_0_22a3a5", string.Empty);
            this.removeDanger += this.check(1, "r_d3_0_22a3a6", string.Empty);
          }
          else
          {
            this.removeDanger += this.check(label: "r_d3_0_22a3b1", pic: string.Empty);
            this.removeDanger += this.check(label: "r_d3_0_22a3b2", pic: string.Empty);
          }
        }
        else
        {
          this.removeDanger += this.check(label: "r_d3_0_22a3b1", pic: string.Empty);
          this.removeDanger += this.check(label: "r_d3_0_22a3b2", pic: string.Empty);
        }
      }
      else
      {
        this.removeDanger += this.check(label: "r_d3_0_22a3c1", pic: "c_razor");
        this.removeDanger += this.check(label: "r_d3_0_22a3c2", pic: string.Empty);
        this.removeDanger += this.check(label: "r_d3_0_22a3c3", pic: string.Empty);
        this.removeDanger += this.check(1, "r_d3_0_22a3c4", string.Empty);
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
        text = GameStrings.getString(GameStrings.results, "r_d3_0_1b1"),
        function = new TimelineFunction(((ResultsController) this).liveOrDie)
      });
      this.analytics_stayed = "outside";
    }
  }
}
