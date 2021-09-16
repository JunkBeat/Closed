// Decompiled with JetBrains decompiler
// Type: ResultsChapterCold
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

public class ResultsChapterCold : ResultsController
{
  private string analytics_basket = "?";
  private string analytics_doors = "?";
  private string analytics_electric = "?";
  private string analytics_fireplace = "?";
  private string analytics_gas = "?";
  private string analytics_gear = "?";
  private string analytics_cooler = "?";
  private string analytics_oven = "?";
  private string analytics_stayed = "?";

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
      num10 = num1;
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
      num10 = num3;
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
      num10 = num5;
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
      num10 = num7;
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
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_foil") + " " + GameStrings.getString(GameStrings.results, "foil_none");
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
    this.surviavbleDanger = 20;
    this.danger = 0;
    this.removeDanger = 0;
    this.winQuality = 3;
    this.pbc.total = 100;
    int num1 = 30;
    int num2 = 3;
    int num3 = 3;
    this.changeDanger(this.pbc.total.ToString());
    Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
    {
      text = GameStrings.getString(GameStrings.results, "cold_intro1")
    });
    Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
    {
      text = GameStrings.getString(GameStrings.results, "cold_intro2")
    });
    if (GameDataController.gd.previousLocation == "Location1" || GameDataController.gd.previousLocation == "Location2" || GameDataController.gd.previousLocation == "LocationBaseUpstairs" || GameDataController.gd.previousLocation == "LocationBaseBathroom")
    {
      this.analytics_stayed = "base";
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        text = GameStrings.getString(GameStrings.results, "cold_house")
      });
      int num4 = this.pbc.total - this.removeDanger;
      float num5 = 3f;
      float num6 = 3f;
      float num7 = 6f;
      float num8 = 6f;
      float num9 = 6f;
      float num10 = 6f;
      num4 = this.danger - this.removeDanger - (int) num5 - (int) num6 - (int) num7 - (int) num8 - (int) num9 - (int) num10;
      int num11 = (int) num5 - 1;
      int num12 = (int) num5;
      int num13 = 0;
      this.analytics_doors = string.Empty;
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        actionWithText = true,
        param = !GameDataController.gd.getObjective("location01_door2_open") ? (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 1 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 1 ? "0|Bitmaps/Locations/LocationResults/c_door1_closed_towel" : "0|Bitmaps/Locations/LocationResults/c_door1_closed") : "0|Bitmaps/Locations/LocationResults/c_door1_open",
        text = string.Empty
      });
      TimelineAction action1 = new TimelineAction(Timeline.t.textField);
      action1.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action1.actionWithText = false;
      if (GameDataController.gd.getObjective("location01_door2_open"))
      {
        action1.param = "0";
        action1.text = GameStrings.getString(GameStrings.results, "cold_door1_open");
      }
      else if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 1 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 1)
      {
        num13 = num12;
        if ((double) num13 > (double) num5)
          num13 = (int) num5;
        this.removeDanger += num13;
        action1.param = "-" + (object) num13;
        action1.text = GameStrings.getString(GameStrings.results, "cold_door1_closed1T") + " " + (object) num13 + " " + GameStrings.getString(GameStrings.results, "cold_door1_closed2T");
      }
      else
      {
        num13 = num11;
        if ((double) num13 > (double) num5)
          num13 = (int) num5;
        this.removeDanger += num13;
        action1.param = "-" + (object) num13;
        action1.text = GameStrings.getString(GameStrings.results, "cold_door1_closed1") + " " + (object) num13 + " " + GameStrings.getString(GameStrings.results, "cold_door1_closed2");
      }
      Timeline.t.addAction(action1);
      this.analytics_doors = num13.ToString() + "/";
      TimelineAction action2 = new TimelineAction(Timeline.t.textField);
      action2.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action2.actionWithText = true;
      int num14 = 0;
      action2.param = !GameDataController.gd.getObjective("location02_door_open") ? (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 2 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 2 ? "0|Bitmaps/Locations/LocationResults/c_door2_closed_towel" : "0|Bitmaps/Locations/LocationResults/c_door2_closed") : "0|Bitmaps/Locations/LocationResults/c_door2_open";
      action2.text = string.Empty;
      Timeline.t.addAction(action2);
      TimelineAction action3 = new TimelineAction(Timeline.t.textField);
      action3.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action3.actionWithText = false;
      if (GameDataController.gd.getObjective("location02_door_open"))
      {
        action3.param = "0";
        action3.text = GameStrings.getString(GameStrings.results, "cold_door2_open");
      }
      else if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 2 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 2)
      {
        num14 = num12;
        if ((double) num14 > (double) num6)
          num14 = (int) num6;
        this.removeDanger += num14;
        action3.param = "-" + (object) num14;
        action3.text = GameStrings.getString(GameStrings.results, "cold_door2_closed1T") + " " + (object) num14 + " " + GameStrings.getString(GameStrings.results, "cold_door2_closed2T");
      }
      else
      {
        num14 = num11;
        if ((double) num14 > (double) num6)
          num14 = (int) num6;
        this.removeDanger += num14;
        action3.param = "-" + (object) num14;
        action3.text = GameStrings.getString(GameStrings.results, "cold_door2_closed1") + " " + (object) num14 + " " + GameStrings.getString(GameStrings.results, "cold_door2_closed2");
      }
      Timeline.t.addAction(action3);
      ResultsChapterCold resultsChapterCold1 = this;
      resultsChapterCold1.analytics_doors = resultsChapterCold1.analytics_doors + (object) num14 + "/";
      int num15 = (int) num7;
      int num16 = (int) num7 - 3;
      int num17 = (int) num7;
      int num18 = (int) num7 - 3;
      int num19 = (int) num7;
      int num20 = (int) num7 - 3;
      int num21 = (int) num7;
      int num22 = (int) num7 - 3;
      int num23 = 2;
      int num24 = (int) num10;
      int num25 = (int) num10;
      int num26 = (int) num10;
      int num27 = (int) num10;
      TimelineAction action4 = new TimelineAction(Timeline.t.textField);
      action4.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action4.actionWithText = true;
      int num28 = 0;
      int num29;
      if (GameDataController.gd.getObjective("base_window1_broken"))
      {
        num29 = 0;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_empty";
        action4.text = GameStrings.getString(GameStrings.results, "window1_open") + " " + GameStrings.getString(GameStrings.results, "window_broken_barricade");
      }
      else if (GameDataController.gd.getObjective("base_window_1_blanketb_nailed") && GameDataController.gd.getObjective("base_window_1_blanketb_taped"))
      {
        num29 = num15;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_blanketb_3";
        action4.text = GameStrings.getString(GameStrings.results, "window1_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_blanketb_taped"))
      {
        num29 = num15;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_blanketb_2";
        action4.text = GameStrings.getString(GameStrings.results, "window1_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_1_blanketb_nailed"))
      {
        num29 = num15 - num23;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_blanketb_1";
        action4.text = GameStrings.getString(GameStrings.results, "window1_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_blanketb"))
      {
        num29 = num16;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_blanketb_0";
        action4.text = GameStrings.getString(GameStrings.results, "window1_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_none");
      }
      else if (GameDataController.gd.getObjective("base_window_1_blanket_nailed") && GameDataController.gd.getObjective("base_window_1_blanket_taped"))
      {
        num29 = num17;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_blanket_3";
        action4.text = GameStrings.getString(GameStrings.results, "window1_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_blanket_taped"))
      {
        num29 = num17;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_blanket_2";
        action4.text = GameStrings.getString(GameStrings.results, "window1_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_1_blanket_nailed"))
      {
        num29 = num17 - num23;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_blanket_1";
        action4.text = GameStrings.getString(GameStrings.results, "window1_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_blanket"))
      {
        num29 = num18;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_blanket_0";
        action4.text = GameStrings.getString(GameStrings.results, "window1_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_none");
      }
      else if (GameDataController.gd.getObjective("base_window_1_flag_nailed") && GameDataController.gd.getObjective("base_window_1_flag_taped"))
      {
        num29 = num19;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_flag_3";
        action4.text = GameStrings.getString(GameStrings.results, "window1_flag") + " " + GameStrings.getString(GameStrings.results, "flag_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_flag_taped"))
      {
        num29 = num19;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_flag_2";
        action4.text = GameStrings.getString(GameStrings.results, "window1_flag") + " " + GameStrings.getString(GameStrings.results, "flag_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_1_flag_nailed"))
      {
        num29 = num19 - num23;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_flag_1";
        action4.text = GameStrings.getString(GameStrings.results, "window1_flag") + " " + GameStrings.getString(GameStrings.results, "flag_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_flag"))
      {
        num29 = num20;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_flag_0";
        action4.text = GameStrings.getString(GameStrings.results, "window1_flag") + " " + GameStrings.getString(GameStrings.results, "flag_none");
      }
      else if (GameDataController.gd.getObjective("base_window_1_therm_nailed") && GameDataController.gd.getObjective("base_window_1_therm_taped"))
      {
        num29 = num21;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_therm_3";
        action4.text = GameStrings.getString(GameStrings.results, "window1_therm") + " " + GameStrings.getString(GameStrings.results, "therm_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_therm_taped"))
      {
        num29 = num21;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_therm_2";
        action4.text = GameStrings.getString(GameStrings.results, "window1_therm") + " " + GameStrings.getString(GameStrings.results, "therm_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_1_therm_nailed"))
      {
        num29 = num21 - num23;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_therm_1";
        action4.text = GameStrings.getString(GameStrings.results, "window1_therm") + " " + GameStrings.getString(GameStrings.results, "therm_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_therm"))
      {
        num29 = num22;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_therm_0";
        action4.text = GameStrings.getString(GameStrings.results, "window1_therm") + " " + GameStrings.getString(GameStrings.results, "therm_none");
      }
      else if (GameDataController.gd.getObjective("base_window_1_net_nailed") && GameDataController.gd.getObjective("base_window_1_net_taped"))
      {
        num29 = 0;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_net_3";
        action4.text = GameStrings.getString(GameStrings.results, "window1_net") + " " + GameStrings.getString(GameStrings.results, "net_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_net_taped"))
      {
        num29 = 0;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_net_2";
        action4.text = GameStrings.getString(GameStrings.results, "window1_net") + " " + GameStrings.getString(GameStrings.results, "net_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_1_net_nailed"))
      {
        num29 = 0;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_net_1";
        action4.text = GameStrings.getString(GameStrings.results, "window1_net") + " " + GameStrings.getString(GameStrings.results, "net_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_net"))
      {
        num29 = 0;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_net_0";
        action4.text = GameStrings.getString(GameStrings.results, "window1_net") + " " + GameStrings.getString(GameStrings.results, "net_none");
      }
      else if (GameDataController.gd.getObjective("base_window_1_foil_nailed") && GameDataController.gd.getObjective("base_window_1_foil_taped"))
      {
        num29 = num17 / 2;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_foil_3";
        action4.text = GameStrings.getString(GameStrings.results, "window1_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_foil_taped"))
      {
        num29 = num17 / 2;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_foil_2";
        action4.text = GameStrings.getString(GameStrings.results, "window1_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_1_foil_nailed"))
      {
        num29 = num17 / 2;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_foil_1";
        action4.text = GameStrings.getString(GameStrings.results, "window1_foil") + " " + GameStrings.getString(GameStrings.results, "foil_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_foil"))
      {
        num29 = num18 / 2;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_foil_0";
        action4.text = GameStrings.getString(GameStrings.results, "window1_foil") + " " + GameStrings.getString(GameStrings.results, "foil_none");
      }
      else if (GameDataController.gd.getObjective("base_window_1_bars_nailed") && GameDataController.gd.getObjective("base_window_1_bars_taped"))
      {
        num29 = 0;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_bars_3";
        action4.text = GameStrings.getString(GameStrings.results, "window1_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_bars_taped"))
      {
        num29 = 0;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_bars_2";
        action4.text = GameStrings.getString(GameStrings.results, "window1_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_1_bars_nailed"))
      {
        num29 = 0;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_bars_1";
        action4.text = GameStrings.getString(GameStrings.results, "window1_bars") + " " + GameStrings.getString(GameStrings.results, "bars_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_bars"))
      {
        num29 = 0;
        if ((double) num29 > (double) num7)
          num29 = (int) num7;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_bars_0";
        action4.text = GameStrings.getString(GameStrings.results, "window1_bars") + " " + GameStrings.getString(GameStrings.results, "bars_none");
      }
      else
      {
        num29 = 0;
        action4.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_empty";
        action4.text = GameStrings.getString(GameStrings.results, "window1_open");
      }
      Timeline.t.addAction(action4);
      ResultsChapterCold resultsChapterCold2 = this;
      resultsChapterCold2.analytics_doors = resultsChapterCold2.analytics_doors + (object) num29 + "/";
      this.removeDanger += num29;
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        param = "-" + (object) num29,
        text = GameStrings.getString(GameStrings.results, "cold_window_result1") + " " + (object) num29 + string.Empty + GameStrings.getString(GameStrings.results, "cold_window_result2")
      });
      TimelineAction action5 = new TimelineAction(Timeline.t.textField);
      action5.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action5.actionWithText = true;
      num28 = 0;
      int num30;
      if (GameDataController.gd.getObjective("base_window2_broken"))
      {
        num30 = 0;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_empty";
        action5.text = GameStrings.getString(GameStrings.results, "window2_open") + " " + GameStrings.getString(GameStrings.results, "window_broken_barricade");
      }
      else if (GameDataController.gd.getObjective("base_window_2_blanketb_nailed") && GameDataController.gd.getObjective("base_window_2_blanketb_taped"))
      {
        num30 = num15;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_blanketb_3";
        action5.text = GameStrings.getString(GameStrings.results, "window2_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_blanketb_taped"))
      {
        num30 = num15;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_blanketb_2";
        action5.text = GameStrings.getString(GameStrings.results, "window2_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_2_blanketb_nailed"))
      {
        num30 = num15 - num23;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_blanketb_1";
        action5.text = GameStrings.getString(GameStrings.results, "window2_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_blanketb"))
      {
        num30 = num16;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_blanketb_0";
        action5.text = GameStrings.getString(GameStrings.results, "window2_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_none");
      }
      else if (GameDataController.gd.getObjective("base_window_2_blanket_nailed") && GameDataController.gd.getObjective("base_window_2_blanket_taped"))
      {
        num30 = num17;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_blanket_3";
        action5.text = GameStrings.getString(GameStrings.results, "window2_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_blanket_taped"))
      {
        num30 = num17;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_blanket_2";
        action5.text = GameStrings.getString(GameStrings.results, "window2_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_2_blanket_nailed"))
      {
        num30 = num17 - num23;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_blanket_1";
        action5.text = GameStrings.getString(GameStrings.results, "window2_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_blanket"))
      {
        num30 = num18;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_blanket_0";
        action5.text = GameStrings.getString(GameStrings.results, "window2_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_none");
      }
      else if (GameDataController.gd.getObjective("base_window_2_flag_nailed") && GameDataController.gd.getObjective("base_window_2_flag_taped"))
      {
        num30 = num19;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_flag_3";
        action5.text = GameStrings.getString(GameStrings.results, "window2_flag") + " " + GameStrings.getString(GameStrings.results, "flag_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_flag_taped"))
      {
        num30 = num19;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_flag_2";
        action5.text = GameStrings.getString(GameStrings.results, "window2_flag") + " " + GameStrings.getString(GameStrings.results, "flag_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_2_flag_nailed"))
      {
        num30 = num19 - num23;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_flag_1";
        action5.text = GameStrings.getString(GameStrings.results, "window2_flag") + " " + GameStrings.getString(GameStrings.results, "flag_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_flag"))
      {
        num30 = num20;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_flag_0";
        action5.text = GameStrings.getString(GameStrings.results, "window2_flag") + " " + GameStrings.getString(GameStrings.results, "flag_none");
      }
      else if (GameDataController.gd.getObjective("base_window_2_therm_nailed") && GameDataController.gd.getObjective("base_window_2_therm_taped"))
      {
        num30 = num21;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_therm_3";
        action5.text = GameStrings.getString(GameStrings.results, "window2_therm") + " " + GameStrings.getString(GameStrings.results, "therm_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_therm_taped"))
      {
        num30 = num21;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_therm_2";
        action5.text = GameStrings.getString(GameStrings.results, "window2_therm") + " " + GameStrings.getString(GameStrings.results, "therm_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_2_therm_nailed"))
      {
        num30 = num21 - num23;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_therm_1";
        action5.text = GameStrings.getString(GameStrings.results, "window2_therm") + " " + GameStrings.getString(GameStrings.results, "therm_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_therm"))
      {
        num30 = num22;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_therm_0";
        action5.text = GameStrings.getString(GameStrings.results, "window2_therm") + " " + GameStrings.getString(GameStrings.results, "therm_none");
      }
      else if (GameDataController.gd.getObjective("base_window_2_net_nailed") && GameDataController.gd.getObjective("base_window_2_net_taped"))
      {
        num30 = 0;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_net_3";
        action5.text = GameStrings.getString(GameStrings.results, "window2_net") + " " + GameStrings.getString(GameStrings.results, "net_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_net_taped"))
      {
        num30 = 0;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_net_2";
        action5.text = GameStrings.getString(GameStrings.results, "window2_net") + " " + GameStrings.getString(GameStrings.results, "net_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_2_net_nailed"))
      {
        num30 = 0;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_net_1";
        action5.text = GameStrings.getString(GameStrings.results, "window2_net") + " " + GameStrings.getString(GameStrings.results, "net_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_net"))
      {
        num30 = 0;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_net_0";
        action5.text = GameStrings.getString(GameStrings.results, "window2_net") + " " + GameStrings.getString(GameStrings.results, "net_none");
      }
      else if (GameDataController.gd.getObjective("base_window_2_foil_nailed") && GameDataController.gd.getObjective("base_window_2_foil_taped"))
      {
        num30 = num17 / 2;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_foil_3";
        action5.text = GameStrings.getString(GameStrings.results, "window2_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_foil_taped"))
      {
        num30 = num17 / 2;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_foil_2";
        action5.text = GameStrings.getString(GameStrings.results, "window2_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_2_foil_nailed"))
      {
        num30 = num17 / 2;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_foil_1";
        action5.text = GameStrings.getString(GameStrings.results, "window2_foil") + " " + GameStrings.getString(GameStrings.results, "foil_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_foil"))
      {
        num30 = num18 / 2;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_foil_0";
        action5.text = GameStrings.getString(GameStrings.results, "window2_foil") + " " + GameStrings.getString(GameStrings.results, "foil_none");
      }
      else if (GameDataController.gd.getObjective("base_window_2_bars_nailed") && GameDataController.gd.getObjective("base_window_2_bars_taped"))
      {
        num30 = 0;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_bars_3";
        action5.text = GameStrings.getString(GameStrings.results, "window2_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_bars_taped"))
      {
        num30 = 0;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_bars_2";
        action5.text = GameStrings.getString(GameStrings.results, "window2_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_2_bars_nailed"))
      {
        num30 = 0;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_bars_1";
        action5.text = GameStrings.getString(GameStrings.results, "window2_bars") + " " + GameStrings.getString(GameStrings.results, "bars_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_bars"))
      {
        num30 = 0;
        if ((double) num30 > (double) num8)
          num30 = (int) num8;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_bars_0";
        action5.text = GameStrings.getString(GameStrings.results, "window2_bars") + " " + GameStrings.getString(GameStrings.results, "bars_none");
      }
      else
      {
        num30 = 0;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_empty";
        action5.text = GameStrings.getString(GameStrings.results, "window2_open");
      }
      Timeline.t.addAction(action5);
      ResultsChapterCold resultsChapterCold3 = this;
      resultsChapterCold3.analytics_doors = resultsChapterCold3.analytics_doors + (object) num30 + "/";
      this.removeDanger += num30;
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        param = "-" + (object) num30,
        text = GameStrings.getString(GameStrings.results, "cold_window_result1") + " " + (object) num30 + string.Empty + GameStrings.getString(GameStrings.results, "cold_window_result2")
      });
      TimelineAction action6 = new TimelineAction(Timeline.t.textField);
      action6.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action6.actionWithText = true;
      num28 = 0;
      int num31;
      if (GameDataController.gd.getObjective("base_window3_broken"))
      {
        num31 = 0;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_empty";
        action6.text = GameStrings.getString(GameStrings.results, "window3_open") + " " + GameStrings.getString(GameStrings.results, "window_broken_barricade");
      }
      else if (GameDataController.gd.getObjective("base_window_3_blanketb_nailed") && GameDataController.gd.getObjective("base_window_3_blanketb_taped"))
      {
        num31 = num15;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_blanketb_3";
        action6.text = GameStrings.getString(GameStrings.results, "window3_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_blanketb_taped"))
      {
        num31 = num15;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_blanketb_2";
        action6.text = GameStrings.getString(GameStrings.results, "window3_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_3_blanketb_nailed"))
      {
        num31 = num15 - num23;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_blanketb_1";
        action6.text = GameStrings.getString(GameStrings.results, "window3_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_blanketb"))
      {
        num31 = num16;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_blanketb_0";
        action6.text = GameStrings.getString(GameStrings.results, "window3_blanketb") + " " + GameStrings.getString(GameStrings.results, "blanketb_none");
      }
      else if (GameDataController.gd.getObjective("base_window_3_blanket_nailed") && GameDataController.gd.getObjective("base_window_3_blanket_taped"))
      {
        num31 = num17;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_blanket_3";
        action6.text = GameStrings.getString(GameStrings.results, "window3_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_blanket_taped"))
      {
        num31 = num17;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_blanket_2";
        action6.text = GameStrings.getString(GameStrings.results, "window3_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_3_blanket_nailed"))
      {
        num31 = num17 - num23;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_blanket_1";
        action6.text = GameStrings.getString(GameStrings.results, "window3_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_blanket"))
      {
        num31 = num18;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_blanket_0";
        action6.text = GameStrings.getString(GameStrings.results, "window3_blanket") + " " + GameStrings.getString(GameStrings.results, "blanket_none");
      }
      else if (GameDataController.gd.getObjective("base_window_3_flag_nailed") && GameDataController.gd.getObjective("base_window_3_flag_taped"))
      {
        num31 = num19;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_flag_3";
        action6.text = GameStrings.getString(GameStrings.results, "window3_flag") + " " + GameStrings.getString(GameStrings.results, "flag_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_flag_taped"))
      {
        num31 = num19;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_flag_2";
        action6.text = GameStrings.getString(GameStrings.results, "window3_flag") + " " + GameStrings.getString(GameStrings.results, "flag_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_3_flag_nailed"))
      {
        num31 = num19 - num23;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_flag_1";
        action6.text = GameStrings.getString(GameStrings.results, "window3_flag") + " " + GameStrings.getString(GameStrings.results, "flag_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_flag"))
      {
        num31 = num20;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_flag_0";
        action6.text = GameStrings.getString(GameStrings.results, "window3_flag") + " " + GameStrings.getString(GameStrings.results, "flag_none");
      }
      else if (GameDataController.gd.getObjective("base_window_3_therm_nailed") && GameDataController.gd.getObjective("base_window_3_therm_taped"))
      {
        num31 = num21;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_therm_3";
        action6.text = GameStrings.getString(GameStrings.results, "window3_therm") + " " + GameStrings.getString(GameStrings.results, "therm_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_therm_taped"))
      {
        num31 = num21;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_therm_2";
        action6.text = GameStrings.getString(GameStrings.results, "window3_therm") + " " + GameStrings.getString(GameStrings.results, "therm_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_3_therm_nailed"))
      {
        num31 = num21 - num23;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_therm_1";
        action6.text = GameStrings.getString(GameStrings.results, "window3_therm") + " " + GameStrings.getString(GameStrings.results, "therm_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_therm"))
      {
        num31 = num22;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_therm_0";
        action6.text = GameStrings.getString(GameStrings.results, "window3_therm") + " " + GameStrings.getString(GameStrings.results, "therm_none");
      }
      else if (GameDataController.gd.getObjective("base_window_3_net_nailed") && GameDataController.gd.getObjective("base_window_3_net_taped"))
      {
        num31 = 0;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_net_3";
        action6.text = GameStrings.getString(GameStrings.results, "window3_net") + " " + GameStrings.getString(GameStrings.results, "net_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_net_taped"))
      {
        num31 = 0;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_net_2";
        action6.text = GameStrings.getString(GameStrings.results, "window3_net") + " " + GameStrings.getString(GameStrings.results, "net_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_3_net_nailed"))
      {
        num31 = 0;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_net_1";
        action6.text = GameStrings.getString(GameStrings.results, "window3_net") + " " + GameStrings.getString(GameStrings.results, "net_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_net"))
      {
        num31 = 0;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_net_0";
        action6.text = GameStrings.getString(GameStrings.results, "window3_net") + " " + GameStrings.getString(GameStrings.results, "net_none");
      }
      else if (GameDataController.gd.getObjective("base_window_3_foil_nailed") && GameDataController.gd.getObjective("base_window_3_foil_taped"))
      {
        num31 = num17 / 2;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_foil_3";
        action6.text = GameStrings.getString(GameStrings.results, "window3_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_foil_taped"))
      {
        num31 = num17 / 2;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_foil_2";
        action6.text = GameStrings.getString(GameStrings.results, "window3_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_3_foil_nailed"))
      {
        num31 = num17 / 2;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_foil_1";
        action6.text = GameStrings.getString(GameStrings.results, "window3_foil") + " " + GameStrings.getString(GameStrings.results, "foil_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_foil"))
      {
        num31 = num18 / 2;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_foil_0";
        action6.text = GameStrings.getString(GameStrings.results, "window3_foil") + " " + GameStrings.getString(GameStrings.results, "foil_none");
      }
      else if (GameDataController.gd.getObjective("base_window_3_bars_nailed") && GameDataController.gd.getObjective("base_window_3_bars_taped"))
      {
        num31 = 0;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_bars_3";
        action6.text = GameStrings.getString(GameStrings.results, "window3_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_bars_taped"))
      {
        num31 = 0;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_bars_2";
        action6.text = GameStrings.getString(GameStrings.results, "window3_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_3_bars_nailed"))
      {
        num31 = 0;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_bars_1";
        action6.text = GameStrings.getString(GameStrings.results, "window3_bars") + " " + GameStrings.getString(GameStrings.results, "bars_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_bars"))
      {
        num31 = 0;
        if ((double) num31 > (double) num9)
          num31 = (int) num9;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_bars_0";
        action6.text = GameStrings.getString(GameStrings.results, "window3_bars") + " " + GameStrings.getString(GameStrings.results, "bars_none");
      }
      else
      {
        num31 = 0;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_empty";
        action6.text = GameStrings.getString(GameStrings.results, "window3_open");
      }
      Timeline.t.addAction(action6);
      ResultsChapterCold resultsChapterCold4 = this;
      resultsChapterCold4.analytics_doors = resultsChapterCold4.analytics_doors + (object) num31 + "/";
      TimelineAction action7 = new TimelineAction(Timeline.t.textField);
      action7.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action7.param = "-" + (object) num31;
      action7.text = GameStrings.getString(GameStrings.results, "cold_window_result1") + " " + (object) num31 + string.Empty + GameStrings.getString(GameStrings.results, "cold_window_result2");
      this.removeDanger += num31;
      Timeline.t.addAction(action7);
      TimelineAction action8 = new TimelineAction(Timeline.t.textField);
      action8.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action8.actionWithText = true;
      num28 = 0;
      int num32;
      if (GameDataController.gd.getObjective("base_hatch_therm"))
      {
        num32 = num27;
        if ((double) num32 > (double) num9)
          num32 = (int) num10;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_hatch_therm";
        action8.text = GameStrings.getString(GameStrings.results, "hatch_therm");
      }
      else if (GameDataController.gd.getObjective("base_hatch_flag"))
      {
        num32 = num26;
        if ((double) num32 > (double) num9)
          num32 = (int) num10;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_hatch_flag";
        action8.text = GameStrings.getString(GameStrings.results, "hatch_flag");
      }
      else if (GameDataController.gd.getObjective("base_hatch_blanketb"))
      {
        num32 = num24;
        if ((double) num32 > (double) num9)
          num32 = (int) num10;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_hatch_blanketb";
        action8.text = GameStrings.getString(GameStrings.results, "hatch_blanketb");
      }
      else if (GameDataController.gd.getObjective("base_hatch_blanket"))
      {
        num32 = num25;
        if ((double) num32 > (double) num9)
          num32 = (int) num10;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_hatch_blanket";
        action8.text = GameStrings.getString(GameStrings.results, "hatch_blanket");
      }
      else
      {
        num32 = 0;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_hatch_empty";
        action8.text = GameStrings.getString(GameStrings.results, "hatch_empty");
      }
      Timeline.t.addAction(action8);
      ResultsChapterCold resultsChapterCold5 = this;
      resultsChapterCold5.analytics_doors = resultsChapterCold5.analytics_doors + (object) num32 + string.Empty;
      TimelineAction action9 = new TimelineAction(Timeline.t.textField);
      action9.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action9.param = "-" + (object) num32;
      action9.text = GameStrings.getString(GameStrings.results, "cold_hatch_result1") + " " + (object) num32 + string.Empty + GameStrings.getString(GameStrings.results, "cold_hatch_result2");
      this.removeDanger += num32;
      Timeline.t.addAction(action9);
      TimelineAction action10 = new TimelineAction(Timeline.t.textField);
      action10.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action10.actionWithText = true;
      num28 = 0;
      if (GameDataController.gd.getObjective("base_fireplace_lit"))
      {
        action10.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_fire_lit";
        action10.text = GameStrings.getString(GameStrings.results, "cold_fire_lit");
        Timeline.t.addAction(action10);
        TimelineAction action11 = new TimelineAction(Timeline.t.textField);
        action11.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action11.param = "-" + (object) num1;
        action11.text = GameStrings.getString(GameStrings.results, "cold_fire_lit_result_1") + " " + (object) num1 + " " + GameStrings.getString(GameStrings.results, "cold_fire_lit_result_2");
        this.removeDanger += num1;
        Timeline.t.addAction(action11);
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          param = "-" + (object) 0,
          text = GameStrings.getString(GameStrings.results, "cold_fire_cold_wind")
        });
        int num33 = 0;
        if (GameDataController.gd.getObjective("basket_note"))
          ++num33;
        if (GameDataController.gd.getObjective("basket_papers"))
          ++num33;
        if (GameDataController.gd.getObjective("basket_cash"))
          ++num33;
        if (GameDataController.gd.getObjective("basket_bag"))
          ++num33;
        this.analytics_basket = num33.ToString() + string.Empty;
        if (num33 >= 2)
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            param = "-" + (object) 0,
            text = GameStrings.getString(GameStrings.results, "cold_fire_extra_kindling2")
          });
        else if (num33 > 0)
        {
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            param = "-" + (object) 0,
            text = GameStrings.getString(GameStrings.results, "cold_fire_extra_kindling1")
          });
          TimelineAction action12 = new TimelineAction(Timeline.t.textField);
          action12.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action12.param = string.Empty + (object) num3;
          this.removeDanger -= num3;
          action12.text = GameStrings.getString(GameStrings.results, "cold_fire_extra_kindling_result1") + " " + (object) num3 + " " + GameStrings.getString(GameStrings.results, "cold_fire_extra_kindling_result2");
          Timeline.t.addAction(action12);
        }
        else
        {
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            param = "-" + (object) 0,
            text = GameStrings.getString(GameStrings.results, "cold_fire_no_extra_kindling")
          });
          TimelineAction action13 = new TimelineAction(Timeline.t.textField);
          action13.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action13.param = string.Empty + (object) (num3 * 2);
          this.removeDanger -= num3 * 2;
          action13.text = GameStrings.getString(GameStrings.results, "cold_fire_extra_kindling_result1") + " " + (object) (num3 * 2) + " " + GameStrings.getString(GameStrings.results, "cold_fire_extra_kindling_result2");
          Timeline.t.addAction(action13);
        }
        int num34 = 0 + GameDataController.gd.getObjectiveDetail("basket_wood");
        if (GameDataController.gd.getObjective("basket_charcoal"))
          ++num34;
        this.analytics_fireplace = num34.ToString() + string.Empty;
        if (num34 == 4)
        {
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            actionWithText = true,
            param = "-" + (object) 0,
            text = GameStrings.getString(GameStrings.results, "cold_fire_supplies_full")
          });
        }
        else
        {
          if (num34 > 0)
            Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
            {
              function = new TimelineFunction(((ResultsController) this).changeDanger),
              actionWithText = true,
              param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_fire_no_lit",
              text = GameStrings.getString(GameStrings.results, "cold_fire_supplies_some")
            });
          else
            Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
            {
              function = new TimelineFunction(((ResultsController) this).changeDanger),
              actionWithText = true,
              param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_fire_no_lit",
              text = GameStrings.getString(GameStrings.results, "cold_fire_supplies_none")
            });
          TimelineAction action14 = new TimelineAction(Timeline.t.textField);
          action14.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action14.param = string.Empty + (object) ((4 - num34) * num2);
          this.removeDanger -= (4 - num34) * num2;
          action14.text = GameStrings.getString(GameStrings.results, "cold_fire_supplies_result_1") + " " + (object) ((4 - num34) * num2) + " " + GameStrings.getString(GameStrings.results, "cold_fire_supplies_result_2");
          action14.text = GameStrings.getString(GameStrings.results, "cold_fire_supplies_result_1") + " " + (object) (4 - num34) + " " + GameStrings.getString(GameStrings.results, "cold_fire_supplies_result_2") + " " + (object) ((4 - num34) * num2) + GameStrings.getString(GameStrings.results, "cold_fire_supplies_result_3");
          Timeline.t.addAction(action14);
        }
      }
      else
      {
        action10.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_fire_no_lit";
        action10.text = GameStrings.getString(GameStrings.results, "fire_no_lit");
        Timeline.t.addAction(action10);
        this.analytics_fireplace = "0";
        if (GameDataController.gd.getObjective("chimney_cleaned"))
        {
          int num35 = this.removeDanger <= 10 ? this.removeDanger : 10;
          TimelineAction action15 = new TimelineAction(Timeline.t.textField);
          action15.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action15.param = "+" + (object) num35;
          this.removeDanger -= num35;
          action15.text = GameStrings.getString(GameStrings.results, "fire_not_lit_unclogged_1") + " " + (object) num35 + GameStrings.getString(GameStrings.results, "fire_not_lit_unclogged_2");
          Timeline.t.addAction(action15);
          this.analytics_fireplace = "-1";
        }
      }
      if (GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 1)
      {
        if (GameDataController.gd.getObjective("kitchen_oven_open"))
        {
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            actionWithText = true,
            param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_oven",
            text = GameStrings.getString(GameStrings.results, "cold_kitchen_oven")
          });
          this.analytics_oven = "enabled";
          int num36 = 14;
          if (GameDataController.gd.previousLocation != "Location2")
          {
            TimelineAction action16 = new TimelineAction(Timeline.t.textField);
            action16.function = new TimelineFunction(((ResultsController) this).changeDanger);
            action16.actionWithText = true;
            action16.param = "-0";
            num36 /= 2;
            action16.text = GameStrings.getString(GameStrings.results, "cold_oven_wrong_room");
            Timeline.t.addAction(action16);
            this.analytics_oven = "wrong_room";
          }
          TimelineAction action17 = new TimelineAction(Timeline.t.textField);
          action17.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action17.param = "-" + (object) num36;
          this.removeDanger += num36;
          action17.text = GameStrings.getString(GameStrings.results, "cold_oven_result_1") + " " + (object) num36 + " " + GameStrings.getString(GameStrings.results, "cold_oven_result_2");
          Timeline.t.addAction(action17);
        }
        if (GameDataController.gd.getObjective("kitchen_heater_plugged") || GameDataController.gd.getObjective("base_heater_cord_plugged"))
        {
          if (GameDataController.gd.getObjective("kitchen_heater_plugged"))
            Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
            {
              function = new TimelineFunction(((ResultsController) this).changeDanger),
              actionWithText = true,
              param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_heater",
              text = GameStrings.getString(GameStrings.results, "cold_kitchen_heater")
            });
          else if (GameDataController.gd.getObjective("base_heater_cord_plugged"))
            Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
            {
              function = new TimelineFunction(((ResultsController) this).changeDanger),
              actionWithText = true,
              param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_heater",
              text = GameStrings.getString(GameStrings.results, "cold_base_heater")
            });
          this.analytics_electric = "enabled";
          int num37 = 22;
          if (GameDataController.gd.getObjective("kitchen_heater_plugged") && GameDataController.gd.previousLocation != "Location2" || GameDataController.gd.getObjective("base_heater_cord_plugged") && GameDataController.gd.previousLocation != "Location1")
          {
            TimelineAction action18 = new TimelineAction(Timeline.t.textField);
            action18.function = new TimelineFunction(((ResultsController) this).changeDanger);
            action18.actionWithText = true;
            action18.param = "-0";
            num37 /= 2;
            action18.text = GameStrings.getString(GameStrings.results, "cold_heater_wrong_room");
            Timeline.t.addAction(action18);
            this.analytics_electric = "wrong_room";
          }
          TimelineAction action19 = new TimelineAction(Timeline.t.textField);
          action19.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action19.param = "-" + (object) num37;
          this.removeDanger += num37;
          action19.text = GameStrings.getString(GameStrings.results, "cold_heater_result_1") + " " + (object) num37 + " " + GameStrings.getString(GameStrings.results, "cold_heater_result_2");
          Timeline.t.addAction(action19);
        }
        if (ItemsManager.im.getItem("gasheater").dataRef.droppedLocation == "Location1" || ItemsManager.im.getItem("gasheater").dataRef.droppedLocation == "Location2" || ItemsManager.im.getItem("gasheater").dataRef.droppedLocation == "LocationBaseUpstairs" || ItemsManager.im.getItem("gasheater").dataRef.droppedLocation == "LocationBaseBathroom")
        {
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            actionWithText = true,
            param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_gasheater",
            text = GameStrings.getString(GameStrings.results, "cold_gasheater")
          });
          int num38 = 24;
          this.analytics_gas = "enabled";
          if (ItemsManager.im.getItem("gasheater").dataRef.droppedLocation != GameDataController.gd.previousLocation)
          {
            TimelineAction action20 = new TimelineAction(Timeline.t.textField);
            action20.function = new TimelineFunction(((ResultsController) this).changeDanger);
            action20.actionWithText = true;
            action20.param = "-0";
            num38 /= 2;
            action20.text = GameStrings.getString(GameStrings.results, "cold_gasheater_wrong_room");
            Timeline.t.addAction(action20);
            this.analytics_gas = "wrong_room";
          }
          TimelineAction action21 = new TimelineAction(Timeline.t.textField);
          action21.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action21.param = "-" + (object) num38;
          this.removeDanger += num38;
          action21.text = GameStrings.getString(GameStrings.results, "cold_gasheater_result_1") + " " + (object) num38 + " " + GameStrings.getString(GameStrings.results, "cold_gasheater_result_2");
          Timeline.t.addAction(action21);
        }
      }
      else
      {
        if (GameDataController.gd.getObjective("kitchen_oven_open"))
        {
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            actionWithText = true,
            param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_oven_off",
            text = GameStrings.getString(GameStrings.results, "cold_kitchen_oven_off")
          });
          this.analytics_oven = "no_power";
        }
        if (GameDataController.gd.getObjective("kitchen_heater_plugged") || GameDataController.gd.getObjective("base_heater_cord_plugged"))
        {
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            actionWithText = true,
            param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_heater_off",
            text = GameStrings.getString(GameStrings.results, "cold_heater_off")
          });
          this.analytics_electric = "no_power";
        }
      }
      int num39 = 0;
      if (ItemsManager.im.getItem("heat_absorber1A").dataRef.droppedLocation == "Location1" || ItemsManager.im.getItem("heat_absorber1A").dataRef.droppedLocation == "Location2" || ItemsManager.im.getItem("heat_absorber1A").dataRef.droppedLocation == "LocationBaseUpstairs" || ItemsManager.im.getItem("heat_absorber1A").dataRef.droppedLocation == "LocationBaseBathroom")
        ++num39;
      if (ItemsManager.im.getItem("heat_absorber2A").dataRef.droppedLocation == "Location1" || ItemsManager.im.getItem("heat_absorber2A").dataRef.droppedLocation == "Location2" || ItemsManager.im.getItem("heat_absorber2A").dataRef.droppedLocation == "LocationBaseUpstairs" || ItemsManager.im.getItem("heat_absorber2A").dataRef.droppedLocation == "LocationBaseBathroom")
        ++num39;
      if (ItemsManager.im.getItem("heat_absorber3A").dataRef.droppedLocation == "Location1" || ItemsManager.im.getItem("heat_absorber3A").dataRef.droppedLocation == "Location2" || ItemsManager.im.getItem("heat_absorber3A").dataRef.droppedLocation == "LocationBaseUpstairs" || ItemsManager.im.getItem("heat_absorber3A").dataRef.droppedLocation == "LocationBaseBathroom")
        ++num39;
      if (num39 > 0)
      {
        TimelineAction action22 = new TimelineAction(Timeline.t.textField);
        action22.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action22.actionWithText = true;
        action22.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_absorber";
        if (num39 == 1)
          action22.text = GameStrings.getString(GameStrings.results, "cold_absorber_1");
        if (num39 == 2)
          action22.text = GameStrings.getString(GameStrings.results, "cold_absorber_2");
        if (num39 == 3)
          action22.text = GameStrings.getString(GameStrings.results, "cold_absorber_3");
        Timeline.t.addAction(action22);
        int num40 = 3 * num39;
        TimelineAction action23 = new TimelineAction(Timeline.t.textField);
        action23.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action23.param = string.Empty + (object) num40;
        this.removeDanger += -num40;
        action23.text = GameStrings.getString(GameStrings.results, "cold_absorber_result_1") + " " + (object) num40 + " " + GameStrings.getString(GameStrings.results, "cold_absorber_result_2");
        Timeline.t.addAction(action23);
      }
      this.analytics_cooler = num39.ToString() + string.Empty;
      if (this.removeDanger >= this.pbc.total)
        this.winQuality = 3;
      else
        this.winQuality = 2;
      this.analytics_gear = GameDataController.gd.equipped;
      if (ItemsManager.im.getItem("coat1").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("coat2").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("coat3").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("coat4").dataRef.droppedLocation == "ginger")
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_ginger_coat",
          text = GameStrings.getString(GameStrings.results, "cold_ginger_coat")
        });
      if (GameDataController.gd.getObjective("npc2_joined") && (ItemsManager.im.getItem("coat1").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("coat2").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("coat3").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("coat4").dataRef.droppedLocation == "npc2"))
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_barry_coat",
          text = GameStrings.getString(GameStrings.results, "cold_barry_coat")
        });
      if (GameDataController.gd.getObjective("npc3_joined"))
      {
        if (ItemsManager.im.getItem("coat1").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("coat2").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("coat3").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("coat4").dataRef.droppedLocation == "npc3")
        {
          if (this.removeDanger >= 80)
          {
            Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
            {
              function = new TimelineFunction(((ResultsController) this).changeDanger),
              actionWithText = true,
              param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_cody_coated",
              text = GameStrings.getString(GameStrings.results, "cold_cody_coat")
            });
          }
          else
          {
            TimelineAction action24 = new TimelineAction(Timeline.t.textField);
            action24.function = new TimelineFunction(((ResultsController) this).changeDanger);
            action24.actionWithText = true;
            action24.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_cody_dead_coat";
            action24.text = GameStrings.getString(GameStrings.results, "cold_cody_dead_coat");
            this.winQuality = 1;
            Timeline.t.addAction(action24);
            GameDataController.gd.setObjective("npc3_alive", false);
            GameDataController.gd.setObjectiveDetail("npc3_alive", 0);
          }
        }
        else if (this.removeDanger < 100)
        {
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            actionWithText = true,
            param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_cody_dead_cold",
            text = GameStrings.getString(GameStrings.results, "cold_cody_dead_cold")
          });
          this.winQuality = 1;
          GameDataController.gd.setObjective("npc3_alive", false);
          GameDataController.gd.setObjectiveDetail("npc3_alive", 0);
        }
      }
      if (InventoryController.ic.isItemEquipped("coat1") || InventoryController.ic.isItemEquipped("coat2") || InventoryController.ic.isItemEquipped("coat3") || InventoryController.ic.isItemEquipped("coat4"))
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_coat",
          text = GameStrings.getString(GameStrings.results, "cold_coat")
        });
        TimelineAction action25 = new TimelineAction(Timeline.t.textField);
        action25.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action25.param = "-" + (object) 10;
        this.removeDanger += 10;
        action25.text = GameStrings.getString(GameStrings.results, "cold_coat_result_1") + " " + (object) 10 + " " + GameStrings.getString(GameStrings.results, "cold_coat_result_2");
        Timeline.t.addAction(action25);
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
        text = GameStrings.getString(GameStrings.results, "cold_no_house"),
        function = new TimelineFunction(((ResultsController) this).liveOrDie)
      });
      this.analytics_stayed = "outside";
    }
  }
}
