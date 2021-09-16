// Decompiled with JetBrains decompiler
// Type: ResultsChapterGas
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ResultsChapterGas : ResultsController
{
  private string analytics_doors = "open";
  private string analytics_floor = "?";
  private string analytics_sprinklers = "false";
  private string analytics_stayed = "?";
  private string analytics_chemichal = "?";
  private string analytics_gear = "?";
  private string analytics_window_1 = "?";
  private string analytics_window_2 = "?";
  private string analytics_window_3 = "?";

  public override void chapterResult()
  {
    this.surviavbleDanger = 15;
    this.danger = 0;
    this.removeDanger = 0;
    this.pbc.total = 100;
    this.winQuality = 3;
    this.changeDanger(this.pbc.total.ToString());
    Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
    {
      text = GameStrings.getString(GameStrings.results, "gas_intro")
    });
    if (GameDataController.gd.getObjective("base_discovered") && (GameDataController.gd.previousLocation == "Location1" || GameDataController.gd.previousLocation == "Location2" || GameDataController.gd.previousLocation == "LocationBaseUpstairs" || GameDataController.gd.previousLocation == "LocationBaseBathroom"))
    {
      this.analytics_stayed = "base";
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        text = GameStrings.getString(GameStrings.results, "gas_house")
      });
      if (GameDataController.gd.getObjective("barn_sprinklers_enabled") && GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 2)
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = GameDataController.gd.getItemData("chem_glass_12").droppedLocation == "sprinklers" || GameDataController.gd.getItemData("chem_glass_13").droppedLocation == "sprinklers" || GameDataController.gd.getItemData("chem_glass_23").droppedLocation == "sprinklers" ? "0|Bitmaps/Locations/LocationResults/c_sprinklers_1c" : "0|Bitmaps/Locations/LocationResults/c_sprinklers_0b",
          text = GameStrings.getString(GameStrings.results, "gas_sprinklers_on")
        });
        int num1 = 0;
        if (GameDataController.gd.getObjective("barn_sprinklers_b1"))
          ++num1;
        if (GameDataController.gd.getObjective("barn_sprinklers_b2"))
          ++num1;
        if (GameDataController.gd.getObjective("barn_sprinklers_b3"))
          ++num1;
        if (GameDataController.gd.getObjective("barn_sprinklers_b4"))
          ++num1;
        if (GameDataController.gd.getObjective("barn_sprinklers_b5"))
          ++num1;
        if (GameDataController.gd.getObjective("barn_sprinklers_b6"))
          ++num1;
        if (GameDataController.gd.getObjective("barn_sprinklers_b7"))
          ++num1;
        if (GameDataController.gd.getObjective("barn_sprinklers_b8"))
          ++num1;
        this.analytics_sprinklers = num1.ToString() + "/";
        if (!GameDataController.gd.getObjective("barn_pipe_fixed"))
        {
          this.analytics_sprinklers = "leaking";
          num1 /= 2;
        }
        else
          this.analytics_sprinklers += "fixed";
        TimelineAction action1 = new TimelineAction(Timeline.t.textField);
        if (num1 == 0)
          action1.text = GameStrings.getString(GameStrings.results, "sprinklers_0%");
        else if (num1 <= 2)
          action1.text = GameStrings.getString(GameStrings.results, "sprinklers_25%");
        else if (num1 <= 4)
          action1.text = GameStrings.getString(GameStrings.results, "sprinklers_50%");
        else if (num1 <= 7)
          action1.text = GameStrings.getString(GameStrings.results, "sprinklers_75%");
        else if (num1 == 8)
          action1.text = GameStrings.getString(GameStrings.results, "sprinklers_100%");
        action1.function = new TimelineFunction(((ResultsController) this).changeDanger);
        int num2 = num1 * 2;
        this.removeDanger += num2;
        TimelineAction timelineAction1 = action1;
        timelineAction1.text = timelineAction1.text + " ^" + GameStrings.getString(GameStrings.results, "gas_sprinklers_result1") + " " + (object) num2 + " " + GameStrings.getString(GameStrings.results, "gas_sprinklers_result2");
        action1.param = (-num2).ToString();
        Timeline.t.addAction(action1);
        if (GameDataController.gd.getItemData("chem_glass_12").droppedLocation == "sprinklers" || GameDataController.gd.getItemData("chem_glass_13").droppedLocation == "sprinklers" || GameDataController.gd.getItemData("chem_glass_23").droppedLocation == "sprinklers")
        {
          TimelineAction action2 = new TimelineAction(Timeline.t.textField);
          int num3;
          if ((GameDataController.gd.getObjectiveDetail("gas_ph") == 0 || GameDataController.gd.getObjectiveDetail("gas_ph") == 1 || GameDataController.gd.getObjectiveDetail("gas_ph") == 2) && GameDataController.gd.getItemData("chem_glass_12").droppedLocation == "sprinklers")
          {
            this.analytics_chemichal = "correct";
            action2.text = GameStrings.getString(GameStrings.results, "gas_sprinklers_chem_good");
            num3 = 3;
          }
          else if ((GameDataController.gd.getObjectiveDetail("gas_ph") == 3 || GameDataController.gd.getObjectiveDetail("gas_ph") == 4 || GameDataController.gd.getObjectiveDetail("gas_ph") == 5) && GameDataController.gd.getItemData("chem_glass_13").droppedLocation == "sprinklers")
          {
            this.analytics_chemichal = "correct";
            action2.text = GameStrings.getString(GameStrings.results, "gas_sprinklers_chem_good");
            num3 = 3;
          }
          else if ((GameDataController.gd.getObjectiveDetail("gas_ph") == 6 || GameDataController.gd.getObjectiveDetail("gas_ph") == 7) && GameDataController.gd.getItemData("chem_glass_23").droppedLocation == "sprinklers")
          {
            this.analytics_chemichal = "correct";
            action2.text = GameStrings.getString(GameStrings.results, "gas_sprinklers_chem_good");
            num3 = 3;
          }
          else
          {
            this.analytics_chemichal = "wrong";
            action2.text = GameStrings.getString(GameStrings.results, "gas_sprinklers_chem_bad");
            num3 = 0;
          }
          int num4 = num3 * num1;
          action2.function = new TimelineFunction(((ResultsController) this).changeDanger);
          this.removeDanger += num4;
          action2.param = (-num4).ToString();
          TimelineAction timelineAction2 = action2;
          timelineAction2.text = timelineAction2.text + " ^" + GameStrings.getString(GameStrings.results, "gas_sprinklers_result1b") + " " + (object) num4 + " " + GameStrings.getString(GameStrings.results, "gas_sprinklers_result2b");
          Timeline.t.addAction(action2);
        }
      }
      int num5 = this.pbc.total - this.removeDanger;
      int num6 = num5 / 5;
      int num7 = num5 / 5;
      int num8 = num5 / 5;
      int num9 = num5 / 5;
      int num10 = num5 / 5;
      MonoBehaviour.print((object) num5);
      MonoBehaviour.print((object) num5);
      MonoBehaviour.print((object) num5);
      MonoBehaviour.print((object) num5);
      MonoBehaviour.print((object) num5);
      MonoBehaviour.print((object) num5);
      MonoBehaviour.print((object) num5);
      MonoBehaviour.print((object) num5);
      MonoBehaviour.print((object) num5);
      MonoBehaviour.print((object) num5);
      MonoBehaviour.print((object) num5);
      MonoBehaviour.print((object) num5);
      int num11 = this.danger - this.removeDanger - num6 - num7 - num8 - num9 - num10;
      while (num11 > 0)
      {
        if (num11 > 0)
        {
          --num11;
          ++num6;
        }
        if (num11 > 0)
        {
          --num11;
          ++num7;
        }
        if (num11 > 0)
        {
          --num11;
          ++num8;
        }
        if (num11 > 0)
        {
          --num11;
          ++num9;
        }
        if (num11 > 0)
        {
          --num11;
          ++num10;
        }
      }
      MonoBehaviour.print((object) num6);
      MonoBehaviour.print((object) num7);
      MonoBehaviour.print((object) num8);
      MonoBehaviour.print((object) num9);
      MonoBehaviour.print((object) num10);
      int num12 = 4;
      int num13 = 8;
      TimelineAction action3 = new TimelineAction(Timeline.t.textField);
      action3.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action3.actionWithText = true;
      if (GameDataController.gd.getObjective("location01_door2_open"))
      {
        this.analytics_doors = "open";
        action3.param = "0|Bitmaps/Locations/LocationResults/c_door1_open";
      }
      else if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 1 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 1)
      {
        this.analytics_doors = "closed+towel";
        action3.param = "0|Bitmaps/Locations/LocationResults/c_door1_closed_towel";
      }
      else
      {
        this.analytics_doors = "closed";
        action3.param = "0|Bitmaps/Locations/LocationResults/c_door1_closed";
      }
      action3.text = string.Empty;
      Timeline.t.addAction(action3);
      TimelineAction action4 = new TimelineAction(Timeline.t.textField);
      action4.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action4.actionWithText = false;
      if (GameDataController.gd.getObjective("location01_door2_open"))
      {
        action4.param = "0";
        action4.text = GameStrings.getString(GameStrings.results, "gas_door1_open");
      }
      else if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 1 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 1)
      {
        int num14 = num13;
        if (num14 > num6)
          num14 = num6;
        this.removeDanger += num14;
        action4.param = "-" + (object) num14;
        action4.text = GameStrings.getString(GameStrings.results, "gas_door1_closed1T") + " " + (object) num14 + " " + GameStrings.getString(GameStrings.results, "gas_door1_closed2T");
      }
      else
      {
        int num15 = num12;
        if (num15 > num6)
          num15 = num6;
        this.removeDanger += num15;
        action4.param = "-" + (object) num15;
        action4.text = GameStrings.getString(GameStrings.results, "gas_door1_closed1") + " " + (object) num15 + " " + GameStrings.getString(GameStrings.results, "gas_door1_closed2");
      }
      Timeline.t.addAction(action4);
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        actionWithText = true,
        param = !GameDataController.gd.getObjective("location02_door_open") ? (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 2 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 2 ? "0|Bitmaps/Locations/LocationResults/c_door2_closed_towel" : "0|Bitmaps/Locations/LocationResults/c_door2_closed") : "0|Bitmaps/Locations/LocationResults/c_door2_open",
        text = string.Empty
      });
      TimelineAction action5 = new TimelineAction(Timeline.t.textField);
      action5.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action5.actionWithText = false;
      if (GameDataController.gd.getObjective("location02_door_open"))
      {
        this.analytics_doors += "/open";
        action5.param = "0";
        action5.text = GameStrings.getString(GameStrings.results, "gas_door2_open");
      }
      else if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 2 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 2)
      {
        this.analytics_doors += "/closed+towel";
        int num16 = num13;
        if (num16 > num7)
          num16 = num7;
        this.removeDanger += num16;
        action5.param = "-" + (object) num16;
        action5.text = GameStrings.getString(GameStrings.results, "gas_door2_closed1T") + " " + (object) num16 + " " + GameStrings.getString(GameStrings.results, "gas_door2_closed2T");
      }
      else
      {
        this.analytics_doors += "/closed";
        int num17 = num12;
        if (num17 > num7)
          num17 = num7;
        this.removeDanger += num17;
        action5.param = "-" + (object) num17;
        action5.text = GameStrings.getString(GameStrings.results, "gas_door2_closed1") + " " + (object) num17 + " " + GameStrings.getString(GameStrings.results, "gas_door2_closed2");
      }
      Timeline.t.addAction(action5);
      int num18 = 0;
      int num19 = 0;
      int num20 = 8;
      int num21 = 2;
      int num22 = 0;
      int num23 = 0;
      TimelineAction action6 = new TimelineAction(Timeline.t.textField);
      action6.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action6.actionWithText = true;
      int num24 = 0;
      int num25;
      if (GameDataController.gd.getObjective("base_window_1_net_nailed") && GameDataController.gd.getObjective("base_window_1_net_taped"))
      {
        this.analytics_window_1 = "net/attached";
        num25 = num18;
        if (num25 > num8)
          num25 = num8;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_net_3";
        action6.text = GameStrings.getString(GameStrings.results, "window1_net") + " " + GameStrings.getString(GameStrings.results, "net_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_net_taped"))
      {
        this.analytics_window_1 = "net/attached";
        num25 = num18;
        if (num25 > num8)
          num25 = num8;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_net_2";
        action6.text = GameStrings.getString(GameStrings.results, "window1_net") + " " + GameStrings.getString(GameStrings.results, "net_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_1_net_nailed"))
      {
        this.analytics_window_1 = "net/attached";
        num25 = num18;
        if (num25 > num8)
          num25 = num8;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_net_1";
        action6.text = GameStrings.getString(GameStrings.results, "window1_net") + " " + GameStrings.getString(GameStrings.results, "net_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_net"))
      {
        this.analytics_window_1 = "net/loose";
        num25 = num19;
        if (num25 > num8)
          num25 = num8;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_net_0";
        action6.text = GameStrings.getString(GameStrings.results, "window1_net") + " " + GameStrings.getString(GameStrings.results, "net_none");
      }
      else if (GameDataController.gd.getObjective("base_window_1_foil_nailed") && GameDataController.gd.getObjective("base_window_1_foil_taped"))
      {
        this.analytics_window_1 = "foil/attached";
        num25 = num20;
        if (num25 > num8)
          num25 = num8;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_foil_3";
        action6.text = GameStrings.getString(GameStrings.results, "window1_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_foil_taped"))
      {
        this.analytics_window_1 = "foil/attached";
        num25 = num20;
        if (num25 > num8)
          num25 = num8;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_foil_2";
        action6.text = GameStrings.getString(GameStrings.results, "window1_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_1_foil_nailed"))
      {
        this.analytics_window_1 = "foil/attached";
        num25 = num20;
        if (num25 > num8)
          num25 = num8;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_foil_1";
        action6.text = GameStrings.getString(GameStrings.results, "window1_foil") + " " + GameStrings.getString(GameStrings.results, "foil_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_foil"))
      {
        this.analytics_window_1 = "foil/loose";
        num25 = num21;
        if (num25 > num8)
          num25 = num8;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_foil_0";
        action6.text = GameStrings.getString(GameStrings.results, "window1_foil") + " " + GameStrings.getString(GameStrings.results, "foil_none");
      }
      else if (GameDataController.gd.getObjective("base_window_1_bars_nailed") && GameDataController.gd.getObjective("base_window_1_bars_taped"))
      {
        this.analytics_window_1 = "bars/attached";
        num25 = num22;
        if (num25 > num8)
          num25 = num8;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_bars_3";
        action6.text = GameStrings.getString(GameStrings.results, "window1_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_bars_taped"))
      {
        this.analytics_window_1 = "bars/attached";
        num25 = num22;
        if (num25 > num8)
          num25 = num8;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_bars_2";
        action6.text = GameStrings.getString(GameStrings.results, "window1_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_1_bars_nailed"))
      {
        this.analytics_window_1 = "bars/attached";
        num25 = num22;
        if (num25 > num8)
          num25 = num8;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_bars_1";
        action6.text = GameStrings.getString(GameStrings.results, "window1_bars") + " " + GameStrings.getString(GameStrings.results, "bars_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_bars"))
      {
        this.analytics_window_1 = "bars/loose";
        num25 = num23;
        if (num25 > num8)
          num25 = num8;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_bars_0";
        action6.text = GameStrings.getString(GameStrings.results, "window1_bars") + " " + GameStrings.getString(GameStrings.results, "bars_none");
      }
      else
      {
        this.analytics_window_1 = "empty";
        num25 = 0;
        action6.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_empty";
        action6.text = GameStrings.getString(GameStrings.results, "window1_open");
      }
      Timeline.t.addAction(action6);
      this.removeDanger += num25;
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        param = "-" + (object) num25,
        text = GameStrings.getString(GameStrings.results, "gas_window_result1") + " " + (object) num25 + string.Empty + GameStrings.getString(GameStrings.results, "gas_window_result2")
      });
      TimelineAction action7 = new TimelineAction(Timeline.t.textField);
      action7.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action7.actionWithText = true;
      num24 = 0;
      int num26;
      if (GameDataController.gd.getObjective("base_window_2_net_nailed") && GameDataController.gd.getObjective("base_window_2_net_taped"))
      {
        this.analytics_window_2 = "net/attached";
        num26 = num18;
        if (num26 > num9)
          num26 = num9;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_net_3";
        action7.text = GameStrings.getString(GameStrings.results, "window2_net") + " " + GameStrings.getString(GameStrings.results, "net_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_net_taped"))
      {
        this.analytics_window_2 = "net/attached";
        num26 = num18;
        if (num26 > num9)
          num26 = num9;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_net_2";
        action7.text = GameStrings.getString(GameStrings.results, "window2_net") + " " + GameStrings.getString(GameStrings.results, "net_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_2_net_nailed"))
      {
        this.analytics_window_2 = "net/attached";
        num26 = num18;
        if (num26 > num9)
          num26 = num9;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_net_1";
        action7.text = GameStrings.getString(GameStrings.results, "window2_net") + " " + GameStrings.getString(GameStrings.results, "net_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_net"))
      {
        this.analytics_window_2 = "net/loose";
        num26 = num19;
        if (num26 > num9)
          num26 = num9;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_net_0";
        action7.text = GameStrings.getString(GameStrings.results, "window2_net") + " " + GameStrings.getString(GameStrings.results, "net_none");
      }
      else if (GameDataController.gd.getObjective("base_window_2_foil_nailed") && GameDataController.gd.getObjective("base_window_2_foil_taped"))
      {
        this.analytics_window_2 = "foil/attached";
        num26 = num20;
        if (num26 > num9)
          num26 = num9;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_foil_3";
        action7.text = GameStrings.getString(GameStrings.results, "window2_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_foil_taped"))
      {
        this.analytics_window_2 = "foil/attached";
        num26 = num20;
        if (num26 > num9)
          num26 = num9;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_foil_2";
        action7.text = GameStrings.getString(GameStrings.results, "window2_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_2_foil_nailed"))
      {
        this.analytics_window_2 = "foil/attached";
        num26 = num20;
        if (num26 > num9)
          num26 = num9;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_foil_1";
        action7.text = GameStrings.getString(GameStrings.results, "window2_foil") + " " + GameStrings.getString(GameStrings.results, "foil_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_foil"))
      {
        this.analytics_window_2 = "foil/loose";
        num26 = num21;
        if (num26 > num9)
          num26 = num9;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_foil_0";
        action7.text = GameStrings.getString(GameStrings.results, "window2_foil") + " " + GameStrings.getString(GameStrings.results, "foil_none");
      }
      else if (GameDataController.gd.getObjective("base_window_2_bars_nailed") && GameDataController.gd.getObjective("base_window_2_bars_taped"))
      {
        this.analytics_window_2 = "bars/attached";
        num26 = num22;
        if (num26 > num9)
          num26 = num9;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_bars_3";
        action7.text = GameStrings.getString(GameStrings.results, "window2_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_bars_taped"))
      {
        this.analytics_window_2 = "bars/attached";
        num26 = num22;
        if (num26 > num9)
          num26 = num9;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_bars_2";
        action7.text = GameStrings.getString(GameStrings.results, "window2_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_2_bars_nailed"))
      {
        this.analytics_window_2 = "bars/attached";
        num26 = num22;
        if (num26 > num9)
          num26 = num9;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_bars_1";
        action7.text = GameStrings.getString(GameStrings.results, "window2_bars") + " " + GameStrings.getString(GameStrings.results, "bars_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_bars"))
      {
        this.analytics_window_2 = "bars/loose";
        num26 = num23;
        if (num26 > num9)
          num26 = num9;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_bars_0";
        action7.text = GameStrings.getString(GameStrings.results, "window2_bars") + " " + GameStrings.getString(GameStrings.results, "bars_none");
      }
      else
      {
        this.analytics_window_2 = "empty";
        num26 = 0;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_empty";
        action7.text = GameStrings.getString(GameStrings.results, "window2_open");
      }
      Timeline.t.addAction(action7);
      this.removeDanger += num26;
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        param = "-" + (object) num26,
        text = GameStrings.getString(GameStrings.results, "gas_window_result1") + " " + (object) num26 + string.Empty + GameStrings.getString(GameStrings.results, "gas_window_result2")
      });
      TimelineAction action8 = new TimelineAction(Timeline.t.textField);
      action8.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action8.actionWithText = true;
      num24 = 0;
      int num27;
      if (GameDataController.gd.getObjective("base_window_3_net_nailed") && GameDataController.gd.getObjective("base_window_3_net_taped"))
      {
        this.analytics_window_3 = "net/attached";
        num27 = num18;
        if (num27 > num10)
          num27 = num10;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_net_3";
        action8.text = GameStrings.getString(GameStrings.results, "window3_net") + " " + GameStrings.getString(GameStrings.results, "net_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_net_taped"))
      {
        this.analytics_window_3 = "net/attached";
        num27 = num18;
        if (num27 > num10)
          num27 = num10;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_net_2";
        action8.text = GameStrings.getString(GameStrings.results, "window3_net") + " " + GameStrings.getString(GameStrings.results, "net_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_3_net_nailed"))
      {
        this.analytics_window_3 = "net/attached";
        num27 = num18;
        if (num27 > num10)
          num27 = num10;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_net_1";
        action8.text = GameStrings.getString(GameStrings.results, "window3_net") + " " + GameStrings.getString(GameStrings.results, "net_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_net"))
      {
        num27 = num19;
        if (num27 > num10)
          num27 = num10;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_net_0";
        action8.text = GameStrings.getString(GameStrings.results, "window3_net") + " " + GameStrings.getString(GameStrings.results, "net_none");
      }
      else if (GameDataController.gd.getObjective("base_window_3_foil_nailed") && GameDataController.gd.getObjective("base_window_3_foil_taped"))
      {
        this.analytics_window_3 = "net/loose";
        num27 = num20;
        if (num27 > num10)
          num27 = num10;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_foil_3";
        action8.text = GameStrings.getString(GameStrings.results, "window3_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_foil_taped"))
      {
        this.analytics_window_3 = "foil/attached";
        num27 = num20;
        if (num27 > num10)
          num27 = num10;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_foil_2";
        action8.text = GameStrings.getString(GameStrings.results, "window3_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_3_foil_nailed"))
      {
        this.analytics_window_3 = "foil/attached";
        num27 = num20;
        if (num27 > num10)
          num27 = num10;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_foil_1";
        action8.text = GameStrings.getString(GameStrings.results, "window3_foil") + " " + GameStrings.getString(GameStrings.results, "foil_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_foil"))
      {
        this.analytics_window_3 = "foil/loose";
        num27 = num21;
        if (num27 > num10)
          num27 = num10;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_foil_0";
        action8.text = GameStrings.getString(GameStrings.results, "window3_foil") + " " + GameStrings.getString(GameStrings.results, "foil_none");
      }
      else if (GameDataController.gd.getObjective("base_window_3_bars_nailed") && GameDataController.gd.getObjective("base_window_3_bars_taped"))
      {
        this.analytics_window_3 = "bars/attached";
        num27 = num22;
        if (num27 > num10)
          num27 = num10;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_bars_3";
        action8.text = GameStrings.getString(GameStrings.results, "window3_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_bars_taped"))
      {
        this.analytics_window_3 = "bars/attached";
        num27 = num22;
        if (num27 > num10)
          num27 = num10;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_bars_2";
        action8.text = GameStrings.getString(GameStrings.results, "window3_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_3_bars_nailed"))
      {
        this.analytics_window_3 = "bars/attached";
        num27 = num22;
        if (num27 > num10)
          num27 = num10;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_bars_1";
        action8.text = GameStrings.getString(GameStrings.results, "window3_bars") + " " + GameStrings.getString(GameStrings.results, "bars_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_bars"))
      {
        this.analytics_window_3 = "bars/loose";
        num27 = num23;
        if (num27 > num10)
          num27 = num10;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_bars_0";
        action8.text = GameStrings.getString(GameStrings.results, "window3_bars") + " " + GameStrings.getString(GameStrings.results, "bars_none");
      }
      else
      {
        this.analytics_window_3 = "empty";
        num27 = 0;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_empty";
        action8.text = GameStrings.getString(GameStrings.results, "window3_open");
      }
      Timeline.t.addAction(action8);
      TimelineAction action9 = new TimelineAction(Timeline.t.textField);
      action9.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action9.param = "-" + (object) num27;
      action9.text = GameStrings.getString(GameStrings.results, "gas_window_result1") + " " + (object) num27 + string.Empty + GameStrings.getString(GameStrings.results, "gas_window_result2");
      this.removeDanger += num27;
      Timeline.t.addAction(action9);
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        param = "0",
        text = GameStrings.getString(GameStrings.results, "gas_enter1") + " " + (object) (this.danger - this.removeDanger) + GameStrings.getString(GameStrings.results, "gas_enter2")
      });
      TimelineAction action10 = new TimelineAction(Timeline.t.textField);
      action10.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action10.actionWithText = true;
      action10.text = string.Empty;
      if (GameDataController.gd.previousLocation == "Location1" || GameDataController.gd.previousLocation == "Location2")
        action10.param = "0|Bitmaps/Locations/LocationResults/c_groundfloor";
      else if (GameDataController.gd.previousLocation == "LocationBaseUpstairs" || GameDataController.gd.previousLocation == "LocationBaseBathroom")
        action10.param = "0|Bitmaps/Locations/LocationResults/c_firstfloor";
      Timeline.t.addAction(action10);
      TimelineAction timelineAction = new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        actionWithText = true,
        text = string.Empty
      };
      TimelineAction action11 = new TimelineAction(Timeline.t.textField);
      action11.function = new TimelineFunction(((ResultsController) this).changeDanger);
      if (GameDataController.gd.previousLocation == "Location1" || GameDataController.gd.previousLocation == "Location2")
      {
        int num28;
        if (GameDataController.gd.getObjectiveDetail("gas_dens") < 161)
        {
          num28 = 20;
          action11.text = GameStrings.getString(GameStrings.results, "gas_groundfloor_good1") + " " + (object) num28 + GameStrings.getString(GameStrings.results, "gas_groundfloor_good2");
          this.removeDanger += num28;
          this.analytics_floor = "correct";
        }
        else
        {
          this.analytics_floor = "wrong";
          num28 = 0;
          action11.text = GameStrings.getString(GameStrings.results, "gas_groundfloor_wrong");
        }
        action11.param = "-" + (object) num28;
      }
      else if (GameDataController.gd.previousLocation == "LocationBaseUpstairs" || GameDataController.gd.previousLocation == "LocationBaseBathroom")
      {
        int num29;
        if (GameDataController.gd.getObjectiveDetail("gas_dens") < 161)
        {
          num29 = 0;
          action11.text = GameStrings.getString(GameStrings.results, "gas_firstfloor_wrong");
        }
        else
        {
          num29 = 20;
          action11.text = GameStrings.getString(GameStrings.results, "gas_firstfloor_good1") + " " + (object) num29 + GameStrings.getString(GameStrings.results, "gas_firstfloor_good2");
          this.removeDanger += num29;
        }
        action11.param = "-" + (object) num29;
      }
      Timeline.t.addAction(action11);
      if (this.removeDanger >= this.pbc.total)
        this.winQuality = 3;
      else
        this.winQuality = 2;
      this.analytics_gear = GameDataController.gd.equipped;
      if (InventoryController.ic.isItemEquipped("chemsuit_dmg_dmg") || InventoryController.ic.isItemEquipped("chemsuit_rep_dmg") || InventoryController.ic.isItemEquipped("chemsuit_dmg_rep") || InventoryController.ic.isItemEquipped("chemsuit_rep_rep"))
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "0|Bitmaps/Locations/LocationResults/c_hazmat",
          text = string.Empty
        });
        TimelineAction action12 = new TimelineAction(Timeline.t.textField);
        action12.function = new TimelineFunction(((ResultsController) this).changeDanger);
        int num30 = 40;
        if (ItemsManager.im.getItem("chemsuit_dmg_dmg").dataRef.droppedLocation.ToLower().IndexOf("inventory") != -1)
        {
          num30 = 10;
          action12.text = GameStrings.getString(GameStrings.results, "gas_hazmat_dd_1") + " " + (object) num30 + GameStrings.getString(GameStrings.results, "gas_hazmat_dd_2");
        }
        if (ItemsManager.im.getItem("chemsuit_rep_dmg").dataRef.droppedLocation.ToLower().IndexOf("inventory") != -1)
        {
          num30 = 25;
          action12.text = GameStrings.getString(GameStrings.results, "gas_hazmat_rd_1") + " " + (object) num30 + GameStrings.getString(GameStrings.results, "gas_hazmat_rd_2");
        }
        if (ItemsManager.im.getItem("chemsuit_dmg_rep").dataRef.droppedLocation.ToLower().IndexOf("inventory") != -1)
        {
          num30 = 25;
          action12.text = GameStrings.getString(GameStrings.results, "gas_hazmat_dr_1") + " " + (object) num30 + GameStrings.getString(GameStrings.results, "gas_hazmat_dr_2");
        }
        if (ItemsManager.im.getItem("chemsuit_rep_rep").dataRef.droppedLocation.ToLower().IndexOf("inventory") != -1)
        {
          num30 = 40;
          action12.text = GameStrings.getString(GameStrings.results, "gas_hazmat_rr_1") + " " + (object) num30 + GameStrings.getString(GameStrings.results, "gas_hazmat_dd_2");
        }
        this.removeDanger += num30;
        action12.param = "-" + (object) num30;
        Timeline.t.addAction(action12);
      }
      else
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "0|Bitmaps/Locations/LocationResults/c_hazmat_no",
          text = GameStrings.getString(GameStrings.results, "gas_hazmat_no")
        });
      if (this.removeDanger < this.pbc.total)
        this.winQuality = 1;
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
        text = GameStrings.getString(GameStrings.results, "gas_no_house"),
        function = new TimelineFunction(((ResultsController) this).liveOrDie)
      });
      this.analytics_stayed = "outside";
    }
  }
}
