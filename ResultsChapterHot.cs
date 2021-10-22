// Decompiled with JetBrains decompiler
// Type: ResultsChapterHot
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class ResultsChapterHot : ResultsController
{
  private string analytics_ac = "?";
  private string analytics_cooler = "?";
  private string analytics_doors = "?";
  private string analytics_fan = "?";
  private string analytics_gear = "?";
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
    int num9 = 2;
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
      tla.text = GameStrings.getString(GameStrings.results, string.Empty + name1 + "_net") + GameStrings.getString(GameStrings.results, "net_nailed");
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
    this.changeDanger(this.pbc.total.ToString());
    Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
    {
      text = GameStrings.getString(GameStrings.results, "hot_intro1")
    });
    Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
    {
      text = GameStrings.getString(GameStrings.results, "hot_intro2")
    });
    if (GameDataController.gd.previousLocation == "Location1" || GameDataController.gd.previousLocation == "Location2" || GameDataController.gd.previousLocation == "LocationBaseUpstairs" || GameDataController.gd.previousLocation == "LocationBaseBathroom")
    {
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        text = GameStrings.getString(GameStrings.results, "hot_house")
      });
      this.analytics_stayed = "base";
      int num1 = this.pbc.total - this.removeDanger;
      float num2 = 4f;
      float num3 = 4f;
      float num4 = 8f;
      float num5 = 8f;
      float num6 = 8f;
      float num7 = 8f;
      num1 = this.danger - this.removeDanger - (int) num2 - (int) num3 - (int) num4 - (int) num5 - (int) num6 - (int) num7;
      int num8 = (int) num2 - 1;
      int num9 = (int) num2;
      int num10 = 0;
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
        action1.text = GameStrings.getString(GameStrings.results, "hot_door1_open");
      }
      else if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 1 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 1)
      {
        num10 = num9;
        if ((double) num10 > (double) num2)
          num10 = (int) num2;
        this.removeDanger += num10;
        action1.param = "-" + (object) num10;
        action1.text = GameStrings.getString(GameStrings.results, "hot_door1_closed1T") + " " + (object) num10 + " " + GameStrings.getString(GameStrings.results, "hot_door1_closed2T");
      }
      else
      {
        num10 = num8;
        if ((double) num10 > (double) num2)
          num10 = (int) num2;
        this.removeDanger += num10;
        action1.param = "-" + (object) num10;
        action1.text = GameStrings.getString(GameStrings.results, "hot_door1_closed1") + " " + (object) num10 + " " + GameStrings.getString(GameStrings.results, "hot_door1_closed2");
      }
      Timeline.t.addAction(action1);
      this.analytics_doors = num10.ToString() + "/";
      TimelineAction action2 = new TimelineAction(Timeline.t.textField);
      action2.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action2.actionWithText = true;
      int num11 = 0;
      action2.param = !GameDataController.gd.getObjective("location02_door_open") ? (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 2 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 2 ? "0|Bitmaps/Locations/LocationResults/c_door2_closed_towel" : "0|Bitmaps/Locations/LocationResults/c_door2_closed") : "0|Bitmaps/Locations/LocationResults/c_door2_open";
      action2.text = string.Empty;
      Timeline.t.addAction(action2);
      TimelineAction action3 = new TimelineAction(Timeline.t.textField);
      action3.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action3.actionWithText = false;
      if (GameDataController.gd.getObjective("location02_door_open"))
      {
        action3.param = "0";
        action3.text = GameStrings.getString(GameStrings.results, "hot_door2_open");
      }
      else if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 2 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 2)
      {
        num11 = num9;
        if ((double) num11 > (double) num3)
          num11 = (int) num3;
        this.removeDanger += num11;
        action3.param = "-" + (object) num11;
        action3.text = GameStrings.getString(GameStrings.results, "hot_door2_closed1T") + " " + (object) num11 + " " + GameStrings.getString(GameStrings.results, "hot_door2_closed2T");
      }
      else
      {
        num11 = num8;
        if ((double) num11 > (double) num3)
          num11 = (int) num3;
        this.removeDanger += num11;
        action3.param = "-" + (object) num11;
        action3.text = GameStrings.getString(GameStrings.results, "hot_door2_closed1") + " " + (object) num11 + " " + GameStrings.getString(GameStrings.results, "hot_door2_closed2");
      }
      Timeline.t.addAction(action3);
      ResultsChapterHot resultsChapterHot1 = this;
      resultsChapterHot1.analytics_doors = resultsChapterHot1.analytics_doors + (object) num11 + "/";
      int num12 = (int) num7;
      int num13 = (int) num7;
      int num14 = (int) num7;
      int num15 = (int) num7;
      TimelineAction timelineAction1 = new TimelineAction(Timeline.t.textField);
      timelineAction1.function = new TimelineFunction(((ResultsController) this).changeDanger);
      timelineAction1.actionWithText = true;
      int num16 = 0;
      int num17 = this.checkWindows(timelineAction1, "window1", "window_1", (int) num4);
      Timeline.t.addAction(timelineAction1);
      this.removeDanger += num17;
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        param = "-" + (object) num17,
        text = GameStrings.getString(GameStrings.results, "hot_window_result1") + " " + (object) num17 + string.Empty + GameStrings.getString(GameStrings.results, "hot_window_result2")
      });
      ResultsChapterHot resultsChapterHot2 = this;
      resultsChapterHot2.analytics_doors = resultsChapterHot2.analytics_doors + (object) num17 + "/";
      TimelineAction timelineAction2 = new TimelineAction(Timeline.t.textField);
      timelineAction2.function = new TimelineFunction(((ResultsController) this).changeDanger);
      timelineAction2.actionWithText = true;
      num16 = 0;
      int num18 = this.checkWindows(timelineAction2, "window2", "window_2", (int) num5);
      Timeline.t.addAction(timelineAction2);
      this.removeDanger += num18;
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        param = "-" + (object) num18,
        text = GameStrings.getString(GameStrings.results, "hot_window_result1") + " " + (object) num18 + string.Empty + GameStrings.getString(GameStrings.results, "hot_window_result2")
      });
      ResultsChapterHot resultsChapterHot3 = this;
      resultsChapterHot3.analytics_doors = resultsChapterHot3.analytics_doors + (object) num18 + "/";
      TimelineAction timelineAction3 = new TimelineAction(Timeline.t.textField);
      timelineAction3.function = new TimelineFunction(((ResultsController) this).changeDanger);
      timelineAction3.actionWithText = true;
      num16 = 0;
      int num19 = this.checkWindows(timelineAction3, "window3", "window_3", (int) num6);
      Timeline.t.addAction(timelineAction3);
      TimelineAction action4 = new TimelineAction(Timeline.t.textField);
      action4.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action4.param = "-" + (object) num19;
      action4.text = GameStrings.getString(GameStrings.results, "hot_window_result1") + " " + (object) num19 + string.Empty + GameStrings.getString(GameStrings.results, "hot_window_result2");
      this.removeDanger += num19;
      Timeline.t.addAction(action4);
      ResultsChapterHot resultsChapterHot4 = this;
      resultsChapterHot4.analytics_doors = resultsChapterHot4.analytics_doors + (object) num19 + "/";
      TimelineAction action5 = new TimelineAction(Timeline.t.textField);
      action5.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action5.actionWithText = true;
      num16 = 0;
      int num20;
      if (GameDataController.gd.getObjective("base_hatch_therm"))
      {
        num20 = num15;
        if ((double) num20 > (double) num6)
          num20 = (int) num7;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_hatch_therm";
        action5.text = GameStrings.getString(GameStrings.results, "hatch_therm");
      }
      else if (GameDataController.gd.getObjective("base_hatch_flag"))
      {
        num20 = num14;
        if ((double) num20 > (double) num6)
          num20 = (int) num7;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_hatch_flag";
        action5.text = GameStrings.getString(GameStrings.results, "hatch_flag");
      }
      else if (GameDataController.gd.getObjective("base_hatch_blanketb"))
      {
        num20 = num12;
        if ((double) num20 > (double) num6)
          num20 = (int) num7;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_hatch_blanketb";
        action5.text = GameStrings.getString(GameStrings.results, "hatch_blanketb");
      }
      else if (GameDataController.gd.getObjective("base_hatch_blanket"))
      {
        num20 = num13;
        if ((double) num20 > (double) num6)
          num20 = (int) num7;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_hatch_blanket";
        action5.text = GameStrings.getString(GameStrings.results, "hatch_blanket");
      }
      else
      {
        num20 = 0;
        action5.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_hatch_empty";
        action5.text = GameStrings.getString(GameStrings.results, "hatch_empty");
      }
      Timeline.t.addAction(action5);
      ResultsChapterHot resultsChapterHot5 = this;
      resultsChapterHot5.analytics_doors = resultsChapterHot5.analytics_doors + (object) num20 + "/";
      TimelineAction action6 = new TimelineAction(Timeline.t.textField);
      action6.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action6.param = "-" + (object) num20;
      action6.text = GameStrings.getString(GameStrings.results, "hot_hatch_result1") + " " + (object) num20 + string.Empty + GameStrings.getString(GameStrings.results, "hot_hatch_result2");
      this.removeDanger += num20;
      Timeline.t.addAction(action6);
      if (GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 1)
      {
        this.analytics_oven = "disabled";
        if (GameDataController.gd.getObjective("kitchen_oven_open"))
        {
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            actionWithText = true,
            param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_oven",
            text = GameStrings.getString(GameStrings.results, "hot_kitchen_oven")
          });
          int num21 = 4;
          TimelineAction action7 = new TimelineAction(Timeline.t.textField);
          action7.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action7.param = string.Empty + (object) num21;
          this.removeDanger += -num21;
          action7.text = GameStrings.getString(GameStrings.results, "hot_oven_result_1") + " " + (object) num21 + " " + GameStrings.getString(GameStrings.results, "hot_oven_result_2");
          Timeline.t.addAction(action7);
          this.analytics_oven = "enabled";
        }
        this.analytics_fan = "disabled";
        if (GameDataController.gd.getObjective("kitchen_fan_plugged") || GameDataController.gd.getObjective("base_fan_cord_plugged"))
        {
          if (GameDataController.gd.getObjective("kitchen_fan_plugged"))
            Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
            {
              function = new TimelineFunction(((ResultsController) this).changeDanger),
              actionWithText = true,
              param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_fan",
              text = GameStrings.getString(GameStrings.results, "hot_kitchen_fan")
            });
          else if (GameDataController.gd.getObjective("base_fan_cord_plugged"))
            Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
            {
              function = new TimelineFunction(((ResultsController) this).changeDanger),
              actionWithText = true,
              param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_fan",
              text = GameStrings.getString(GameStrings.results, "hot_base_fan")
            });
          int num22 = 24;
          this.analytics_fan = "enabled";
          if (GameDataController.gd.getObjective("kitchen_fan_plugged") && GameDataController.gd.previousLocation != "Location2" || GameDataController.gd.getObjective("base_fan_cord_plugged") && GameDataController.gd.previousLocation != "Location1")
          {
            TimelineAction action8 = new TimelineAction(Timeline.t.textField);
            action8.function = new TimelineFunction(((ResultsController) this).changeDanger);
            action8.actionWithText = true;
            action8.param = "-0";
            num22 /= 2;
            action8.text = GameStrings.getString(GameStrings.results, "hot_fan_wrong_room");
            Timeline.t.addAction(action8);
            this.analytics_fan = "wrong_room";
          }
          TimelineAction action9 = new TimelineAction(Timeline.t.textField);
          action9.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action9.param = "-" + (object) num22;
          this.removeDanger += num22;
          action9.text = GameStrings.getString(GameStrings.results, "hot_fan_result_1") + " " + (object) num22 + " " + GameStrings.getString(GameStrings.results, "hot_fan_result_2");
          Timeline.t.addAction(action9);
        }
        this.analytics_ac = "disabled";
        if (GameDataController.gd.getObjective("base_ac_cord_plugged"))
        {
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            actionWithText = true,
            param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_ac",
            text = GameStrings.getString(GameStrings.results, "hot_base_ac")
          });
          int num23 = 26;
          this.analytics_ac = "enabled";
          if (GameDataController.gd.previousLocation != "Location1")
          {
            TimelineAction action10 = new TimelineAction(Timeline.t.textField);
            action10.function = new TimelineFunction(((ResultsController) this).changeDanger);
            action10.actionWithText = true;
            action10.param = "-0";
            num23 /= 2;
            action10.text = GameStrings.getString(GameStrings.results, "hot_ac_base_wrong");
            Timeline.t.addAction(action10);
            this.analytics_ac = "wrong_room";
          }
          TimelineAction action11 = new TimelineAction(Timeline.t.textField);
          action11.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action11.param = "-" + (object) num23;
          this.removeDanger += num23;
          action11.text = GameStrings.getString(GameStrings.results, "hot_ac_result_1") + " " + (object) num23 + " " + GameStrings.getString(GameStrings.results, "hot_ac_result_2");
          Timeline.t.addAction(action11);
        }
      }
      else
      {
        if (GameDataController.gd.getObjective("base_ac_cord_plugged"))
        {
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            actionWithText = true,
            param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_ac",
            text = GameStrings.getString(GameStrings.results, "hot_ac_off")
          });
          this.analytics_ac = "no_power";
        }
        if (GameDataController.gd.getObjective("kitchen_fan_plugged") || GameDataController.gd.getObjective("base_fan_cord_plugged"))
        {
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            actionWithText = true,
            param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_fan",
            text = GameStrings.getString(GameStrings.results, "hot_fan_off")
          });
          this.analytics_fan = "no_power";
        }
      }
      int num24 = 0;
      if (ItemsManager.im.getItem("heat_absorber1A").dataRef.droppedLocation == "Location1" || ItemsManager.im.getItem("heat_absorber1A").dataRef.droppedLocation == "Location2" || ItemsManager.im.getItem("heat_absorber1A").dataRef.droppedLocation == "LocationBaseUpstairs" || ItemsManager.im.getItem("heat_absorber1A").dataRef.droppedLocation == "LocationBaseBathroom")
        ++num24;
      if (ItemsManager.im.getItem("heat_absorber2A").dataRef.droppedLocation == "Location1" || ItemsManager.im.getItem("heat_absorber2A").dataRef.droppedLocation == "Location2" || ItemsManager.im.getItem("heat_absorber2A").dataRef.droppedLocation == "LocationBaseUpstairs" || ItemsManager.im.getItem("heat_absorber2A").dataRef.droppedLocation == "LocationBaseBathroom")
        ++num24;
      if (ItemsManager.im.getItem("heat_absorber3A").dataRef.droppedLocation == "Location1" || ItemsManager.im.getItem("heat_absorber3A").dataRef.droppedLocation == "Location2" || ItemsManager.im.getItem("heat_absorber3A").dataRef.droppedLocation == "LocationBaseUpstairs" || ItemsManager.im.getItem("heat_absorber3A").dataRef.droppedLocation == "LocationBaseBathroom")
        ++num24;
      if (num24 > 0)
      {
        TimelineAction action12 = new TimelineAction(Timeline.t.textField);
        action12.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action12.actionWithText = true;
        action12.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_absorbertile";
        if (num24 == 1)
          action12.text = GameStrings.getString(GameStrings.results, "hot_absorber_base_1");
        if (num24 == 2)
          action12.text = GameStrings.getString(GameStrings.results, "hot_absorber_base_2");
        if (num24 == 3)
          action12.text = GameStrings.getString(GameStrings.results, "hot_absorber_base_3");
        Timeline.t.addAction(action12);
        int num25 = 0;
        if (ItemsManager.im.getItem("heat_absorber1A").dataRef.droppedLocation != GameDataController.gd.previousLocation)
          ++num25;
        if (ItemsManager.im.getItem("heat_absorber2A").dataRef.droppedLocation != GameDataController.gd.previousLocation)
          ++num25;
        if (ItemsManager.im.getItem("heat_absorber3A").dataRef.droppedLocation != GameDataController.gd.previousLocation)
          ++num25;
        if (num25 > 0)
        {
          TimelineAction action13 = new TimelineAction(Timeline.t.textField);
          action13.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action13.actionWithText = true;
          action13.param = "-0";
          if (num25 == 1)
            action13.text = GameStrings.getString(GameStrings.results, "hot_wrong_absorber_1");
          if (num25 == 2)
            action13.text = GameStrings.getString(GameStrings.results, "hot_wrong_absorber_2");
          if (num25 == 3)
            action13.text = GameStrings.getString(GameStrings.results, "hot_wrong_absorber_3");
          Timeline.t.addAction(action13);
        }
        this.analytics_cooler = num24.ToString() + "/" + (object) num25;
        int num26 = (int) ((double) (7 * num24) - (double) (num24 * num25) / 2.0);
        TimelineAction action14 = new TimelineAction(Timeline.t.textField);
        action14.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action14.param = "-" + (object) num26;
        this.removeDanger += num26;
        if (num24 == 1)
          action14.text = GameStrings.getString(GameStrings.results, "hot_absorber_result_1a") + " " + (object) num26 + " " + GameStrings.getString(GameStrings.results, "hot_absorber_result_2");
        else
          action14.text = GameStrings.getString(GameStrings.results, "hot_absorber_result_1b") + " " + (object) num26 + " " + GameStrings.getString(GameStrings.results, "hot_absorber_result_2");
        Timeline.t.addAction(action14);
      }
    }
    else if (GameDataController.gd.previousLocation == "LocationCave")
    {
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        text = GameStrings.getString(GameStrings.results, "hot_cave")
      });
      int num27 = 15;
      int num28 = 20;
      this.analytics_stayed = "cave";
      TimelineAction action15 = new TimelineAction(Timeline.t.textField);
      action15.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action15.actionWithText = true;
      int num29;
      if (GameDataController.gd.getObjective("rv_cave_therm"))
      {
        num29 = num28;
        action15.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_cave_therm";
        action15.text = GameStrings.getString(GameStrings.results, "cave_therm");
      }
      else if (GameDataController.gd.getObjective("rv_cave_flag"))
      {
        num29 = num28;
        action15.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_cave_flag";
        action15.text = GameStrings.getString(GameStrings.results, "cave_flag");
      }
      else if (GameDataController.gd.getObjective("rv_cave_blanketb"))
      {
        num29 = num28;
        action15.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_cave_blanketb";
        action15.text = GameStrings.getString(GameStrings.results, "cave_blanketb");
      }
      else if (GameDataController.gd.getObjective("rv_cave_blanket"))
      {
        num29 = num28;
        action15.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_cave_blanket";
        action15.text = GameStrings.getString(GameStrings.results, "cave_blanket");
      }
      else
      {
        num29 = 0;
        action15.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_cave_empty";
        action15.text = GameStrings.getString(GameStrings.results, "cave_empty");
      }
      Timeline.t.addAction(action15);
      int num30 = num29 + num27;
      this.analytics_doors = num30.ToString() + string.Empty;
      TimelineAction action16 = new TimelineAction(Timeline.t.textField);
      action16.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action16.param = "-" + (object) num30;
      action16.text = GameStrings.getString(GameStrings.results, "hot_cave_result1") + " " + (object) num30 + string.Empty + GameStrings.getString(GameStrings.results, "hot_cave_result2");
      this.removeDanger += num30;
      Timeline.t.addAction(action16);
      if (GameDataController.gd.getObjective("cave_ac_cord_plugged"))
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_ac",
          text = GameStrings.getString(GameStrings.results, "hot_cave_ac")
        });
        this.analytics_ac = "enabled";
        int num31 = 26;
        if (!GameDataController.gd.getObjective("rv_started"))
        {
          TimelineAction action17 = new TimelineAction(Timeline.t.textField);
          action17.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action17.actionWithText = true;
          action17.param = "-0";
          num31 /= 2;
          action17.text = GameStrings.getString(GameStrings.results, "hot_ac_cave_no_fuel");
          Timeline.t.addAction(action17);
          this.analytics_ac = "low_power";
        }
        TimelineAction action18 = new TimelineAction(Timeline.t.textField);
        action18.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action18.param = "-" + (object) num31;
        this.removeDanger += num31;
        action18.text = GameStrings.getString(GameStrings.results, "hot_ac_result_1") + " " + (object) num31 + " " + GameStrings.getString(GameStrings.results, "hot_ac_result_2");
        Timeline.t.addAction(action18);
      }
      if (GameDataController.gd.getObjective("cave_fan_cord_plugged"))
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_fan",
          text = GameStrings.getString(GameStrings.results, "hot_cave_fan")
        });
        this.analytics_fan = "enabled";
        int num32 = 24;
        if (!GameDataController.gd.getObjective("rv_started"))
        {
          TimelineAction action19 = new TimelineAction(Timeline.t.textField);
          action19.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action19.actionWithText = true;
          action19.param = "-0";
          num32 /= 2;
          action19.text = GameStrings.getString(GameStrings.results, "hot_fan_cave_no_fuel");
          Timeline.t.addAction(action19);
          this.analytics_fan = "low_power";
        }
        TimelineAction action20 = new TimelineAction(Timeline.t.textField);
        action20.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action20.param = "-" + (object) num32;
        this.removeDanger += num32;
        action20.text = GameStrings.getString(GameStrings.results, "hot_fan_result_1") + " " + (object) num32 + " " + GameStrings.getString(GameStrings.results, "hot_fan_result_2");
        Timeline.t.addAction(action20);
      }
      int num33 = 0;
      if (ItemsManager.im.getItem("heat_absorber1A").dataRef.droppedLocation == "LocationCave")
        ++num33;
      if (ItemsManager.im.getItem("heat_absorber2A").dataRef.droppedLocation == "LocationCave")
        ++num33;
      if (ItemsManager.im.getItem("heat_absorber3A").dataRef.droppedLocation == "LocationCave")
        ++num33;
      this.analytics_cooler = num33.ToString() + string.Empty;
      if (num33 > 0)
      {
        TimelineAction action21 = new TimelineAction(Timeline.t.textField);
        action21.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action21.actionWithText = true;
        action21.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_absorbertile";
        if (num33 == 1)
          action21.text = GameStrings.getString(GameStrings.results, "hot_absorber_cave_1");
        if (num33 == 2)
          action21.text = GameStrings.getString(GameStrings.results, "hot_absorber_cave_2");
        if (num33 == 3)
          action21.text = GameStrings.getString(GameStrings.results, "hot_absorber_cave_3");
        Timeline.t.addAction(action21);
        int num34 = 0;
        int num35 = (int) ((double) (7 * num33) - (double) (num33 * num34) / 2.0);
        TimelineAction action22 = new TimelineAction(Timeline.t.textField);
        action22.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action22.param = "-" + (object) num35;
        this.removeDanger += num35;
        if (num33 == 1)
          action22.text = GameStrings.getString(GameStrings.results, "hot_absorber_result_1a") + " " + (object) num35 + " " + GameStrings.getString(GameStrings.results, "hot_absorber_result_2");
        else
          action22.text = GameStrings.getString(GameStrings.results, "hot_absorber_result_1b") + " " + (object) num35 + " " + GameStrings.getString(GameStrings.results, "hot_absorber_result_2");
        Timeline.t.addAction(action22);
      }
    }
    else
    {
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        text = GameStrings.getString(GameStrings.results, "hot_no_house"),
        function = new TimelineFunction(((ResultsController) this).liveOrDie)
      });
      this.analytics_stayed = "outside";
    }
    if (!(GameDataController.gd.previousLocation == "Location1") && !(GameDataController.gd.previousLocation == "Location2") && !(GameDataController.gd.previousLocation == "LocationBaseUpstairs") && !(GameDataController.gd.previousLocation == "LocationBaseBathroom") && !(GameDataController.gd.previousLocation == "LocationCave"))
      return;
    this.analytics_gear = GameDataController.gd.equipped;
    if (ItemsManager.im.getItem("water1").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("water2").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("water3").dataRef.droppedLocation == "ginger" || ItemsManager.im.getItem("water4").dataRef.droppedLocation == "ginger")
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        actionWithText = true,
        param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_water",
        text = GameStrings.getString(GameStrings.results, "hot_ginger_water")
      });
    if (GameDataController.gd.getObjective("npc3_joined") && (ItemsManager.im.getItem("water1").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("water2").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("water3").dataRef.droppedLocation == "npc3" || ItemsManager.im.getItem("water4").dataRef.droppedLocation == "npc3"))
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        actionWithText = true,
        param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_water",
        text = GameStrings.getString(GameStrings.results, "hot_cody_water")
      });
    if (this.removeDanger >= this.pbc.total)
      this.winQuality = 3;
    else
      this.winQuality = 2;
    if (GameDataController.gd.getObjective("npc2_joined"))
    {
      if (ItemsManager.im.getItem("water1").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("water2").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("water3").dataRef.droppedLocation == "npc2" || ItemsManager.im.getItem("water4").dataRef.droppedLocation == "npc2")
      {
        if (this.removeDanger >= 80)
        {
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            actionWithText = true,
            param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_water",
            text = GameStrings.getString(GameStrings.results, "hot_barry_water")
          });
        }
        else
        {
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            actionWithText = true,
            param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_barry_dead_hot",
            text = GameStrings.getString(GameStrings.results, "hot_barry_dead_water")
          });
          GameDataController.gd.setObjective("npc2_alive", false);
          GameDataController.gd.setObjectiveDetail("npc2_alive", 0);
          this.winQuality = 1;
        }
      }
      else if (this.removeDanger < 100)
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_barry_dead_hot",
          text = GameStrings.getString(GameStrings.results, "hot_barry_dead_hot")
        });
        GameDataController.gd.setObjective("npc2_alive", false);
        GameDataController.gd.setObjectiveDetail("npc2_alive", 0);
        this.winQuality = 1;
      }
    }
    if (InventoryController.ic.isItemEquipped("water1") || InventoryController.ic.isItemEquipped("water2") || InventoryController.ic.isItemEquipped("water3") || InventoryController.ic.isItemEquipped("water4"))
    {
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        actionWithText = true,
        param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_water",
        text = GameStrings.getString(GameStrings.results, "hot_water")
      });
      TimelineAction action = new TimelineAction(Timeline.t.textField);
      action.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action.param = "-" + (object) 10;
      this.removeDanger += 10;
      action.text = GameStrings.getString(GameStrings.results, "hot_water_result_1") + " " + (object) 10 + " " + GameStrings.getString(GameStrings.results, "hot_water_result_2");
      Timeline.t.addAction(action);
    }
    if (this.winQuality != 1)
    {
      if (this.removeDanger >= this.pbc.total)
        this.winQuality = 3;
      else
        this.winQuality = 2;
    }
    Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
    {
      function = new TimelineFunction(((ResultsController) this).liveOrDie),
      actionWithText = true,
      param = "0",
      text = string.Empty
    });
  }
}
