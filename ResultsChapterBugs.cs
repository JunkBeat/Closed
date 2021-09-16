// Decompiled with JetBrains decompiler
// Type: ResultsChapterBugs
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ResultsChapterBugs : ResultsController
{
  private string analytics_stayed = "?";
  private string analytics_doors = "0";
  private string analytics_window_1 = "0";
  private string analytics_window_2 = "0";
  private string analytics_window_3 = "0";
  private string analytics_pest = "false";
  private string analytics_sonic = "0";
  private string analytics_sprinklers = "false";
  private string analytics_weapon = "?";

  public override void chapterResult()
  {
    this.surviavbleDanger = 10;
    this.danger = 0;
    this.removeDanger = 0;
    this.winQuality = 3;
    this.pbc.total = 200;
    this.changeDanger(this.pbc.total.ToString());
    Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
    {
      text = GameStrings.getString(GameStrings.results, "bugs_intro")
    });
    if (GameDataController.gd.getObjective("base_discovered") && (GameDataController.gd.previousLocation == "Location1" || GameDataController.gd.previousLocation == "Location2" || GameDataController.gd.previousLocation == "LocationBaseUpstairs" || GameDataController.gd.previousLocation == "LocationBaseBathroom"))
    {
      this.analytics_stayed = "base";
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        text = GameStrings.getString(GameStrings.results, "bugs_house")
      });
      if (GameDataController.gd.getObjective("barn_sprinklers_enabled") && GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 2)
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = !GameDataController.gd.getObjective("barn_sprinklers_fed2") ? (!GameDataController.gd.getObjective("barn_sprinklers_fed1") ? "0|Bitmaps/Locations/LocationResults/c_sprinklers_0" : "0|Bitmaps/Locations/LocationResults/c_sprinklers_1") : "0|Bitmaps/Locations/LocationResults/c_sprinklers_2",
          text = GameStrings.getString(GameStrings.results, "bugs_sprinklers_on")
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
          num1 /= 2;
          this.analytics_sprinklers += "leaking";
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
        int num2 = num1 * 4;
        this.removeDanger += num2;
        TimelineAction timelineAction1 = action1;
        timelineAction1.text = timelineAction1.text + " ^" + GameStrings.getString(GameStrings.results, "bugs_sprinklers_result1") + " " + (object) num2 + " " + GameStrings.getString(GameStrings.results, "bugs_sprinklers_result2");
        action1.param = (-num2).ToString();
        Timeline.t.addAction(action1);
        if (GameDataController.gd.getObjective("barn_sprinklers_fed1"))
        {
          int num3 = 0;
          TimelineAction action2 = new TimelineAction(Timeline.t.textField);
          if (GameDataController.gd.getObjective("barn_sprinklers_fed2"))
          {
            action2.text = GameStrings.getString(GameStrings.results, "bugs_sprinklers_pest2");
            num3 = 6;
          }
          else if (GameDataController.gd.getObjective("barn_sprinklers_fed1"))
          {
            action2.text = GameStrings.getString(GameStrings.results, "bugs_sprinklers_pest1");
            num3 = 3;
          }
          this.analytics_pest = num3.ToString() + "/20";
          int num4 = num3 * num1;
          action2.function = new TimelineFunction(((ResultsController) this).changeDanger);
          this.removeDanger += num4;
          action2.param = (-num4).ToString();
          TimelineAction timelineAction2 = action2;
          timelineAction2.text = timelineAction2.text + " ^" + GameStrings.getString(GameStrings.results, "bugs_sprinklers_result1b") + " " + (object) num4 + " " + GameStrings.getString(GameStrings.results, "bugs_sprinklers_result2b");
          Timeline.t.addAction(action2);
        }
      }
      if (ItemsManager.im.getItem("sonic").dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1 && ItemsManager.im.getItem("sonic").dataRef.droppedLocation.ToLower().IndexOf("nowhere") == -1)
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          text = GameStrings.getString(GameStrings.results, "bugs_sonic_on"),
          actionWithText = true,
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          param = ItemsManager.im.getItem("sonic").dataRef.droppedLocation.ToLower().IndexOf("outside") == -1 ? (ItemsManager.im.getItem("sonic").dataRef.droppedLocation.ToLower().IndexOf("location1") != -1 || ItemsManager.im.getItem("sonic").dataRef.droppedLocation.ToLower().IndexOf("location2") != -1 || ItemsManager.im.getItem("sonic").dataRef.droppedLocation.ToLower().IndexOf("locationbase") != -1 ? "0|Bitmaps/Locations/LocationResults/c_sonic_house" : "0|Bitmaps/Locations/LocationResults/c_sonic_outside") : "0|Bitmaps/Locations/LocationResults/c_sonic_outside"
        });
        TimelineAction action3 = new TimelineAction(Timeline.t.textField);
        action3.function = new TimelineFunction(((ResultsController) this).changeDanger);
        float num5;
        if (ItemsManager.im.getItem("sonic").dataRef.droppedLocation.ToLower().IndexOf("outside") != -1)
        {
          action3.text = GameStrings.getString(GameStrings.results, "bugs_sonic_location_OK");
          num5 = 1f;
          this.analytics_sonic = "outside";
        }
        else if (ItemsManager.im.getItem("sonic").dataRef.droppedLocation.ToLower().IndexOf("location1") != -1 || ItemsManager.im.getItem("sonic").dataRef.droppedLocation.ToLower().IndexOf("location2") != -1 || ItemsManager.im.getItem("sonic").dataRef.droppedLocation.ToLower().IndexOf("locationbase") != -1)
        {
          action3.text = GameStrings.getString(GameStrings.results, "bugs_sonic_location_inside");
          num5 = 0.5f;
          this.analytics_sonic = "inside";
        }
        else
        {
          action3.text = GameStrings.getString(GameStrings.results, "bugs_sonic_location_wrong");
          this.analytics_sonic = "elsewhere";
          num5 = 0.0f;
        }
        Timeline.t.addAction(action3);
        if (ItemsManager.im.getItem("sonic").dataRef.droppedLocation.ToLower().IndexOf("outside") != -1 || ItemsManager.im.getItem("sonic").dataRef.droppedLocation.ToLower().IndexOf("location1") != -1 || ItemsManager.im.getItem("sonic").dataRef.droppedLocation.ToLower().IndexOf("location2") != -1 || ItemsManager.im.getItem("sonic").dataRef.droppedLocation.ToLower().IndexOf("locationbase") != -1)
        {
          bool flag = false;
          if (GameDataController.gd.getObjectiveDetail("bug_type") == 1 && GameDataController.gd.getObjectiveDetail("sonic_frequency") == 110)
            flag = true;
          if (GameDataController.gd.getObjectiveDetail("bug_type") == 2 && GameDataController.gd.getObjectiveDetail("sonic_frequency") == 135)
            flag = true;
          if (GameDataController.gd.getObjectiveDetail("bug_type") == 3 && GameDataController.gd.getObjectiveDetail("sonic_frequency") == 200)
            flag = true;
          if (GameDataController.gd.getObjectiveDetail("bug_type") == 4 && GameDataController.gd.getObjectiveDetail("sonic_frequency") == 385)
            flag = true;
          if (GameDataController.gd.getObjectiveDetail("bug_type") == 5 && GameDataController.gd.getObjectiveDetail("sonic_frequency") == 420)
            flag = true;
          if (GameDataController.gd.getObjectiveDetail("bug_type") == 6 && GameDataController.gd.getObjectiveDetail("sonic_frequency") == 430)
            flag = true;
          if (GameDataController.gd.getObjectiveDetail("bug_type") == 7 && GameDataController.gd.getObjectiveDetail("sonic_frequency") == 720)
            flag = true;
          if (GameDataController.gd.getObjectiveDetail("bug_type") == 8 && GameDataController.gd.getObjectiveDetail("sonic_frequency") == 800)
            flag = true;
          TimelineAction action4 = new TimelineAction(Timeline.t.textField);
          action4.function = new TimelineFunction(((ResultsController) this).changeDanger);
          if (flag)
          {
            this.analytics_sonic += "_good";
            int num6 = (int) ((double) num5 * 50.0);
            this.removeDanger += num6;
            action4.param = (-num6).ToString();
            action4.text = GameStrings.getString(GameStrings.results, "bugs_sonic_result1") + " " + (object) num6 + " " + GameStrings.getString(GameStrings.results, "bugs_sonic_result2");
          }
          else
          {
            this.analytics_sonic += "_wrong";
            int num7 = (int) ((double) num5 * 10.0);
            action4.text = GameStrings.getString(GameStrings.results, "bugs_sonic_frequency_wrong1") + " " + (object) num7 + " " + GameStrings.getString(GameStrings.results, "bugs_sonic_frequency_wrong2");
            action4.param = (-num7).ToString();
            this.removeDanger += num7;
          }
          Timeline.t.addAction(action4);
        }
      }
      int num8 = this.pbc.total - this.removeDanger;
      int num9 = num8 / 5;
      int num10 = num8 / 5;
      int num11 = num8 / 5;
      int num12 = num8 / 5;
      int num13 = num8 / 5;
      MonoBehaviour.print((object) num8);
      MonoBehaviour.print((object) num8);
      MonoBehaviour.print((object) num8);
      MonoBehaviour.print((object) num8);
      MonoBehaviour.print((object) num8);
      MonoBehaviour.print((object) num8);
      MonoBehaviour.print((object) num8);
      MonoBehaviour.print((object) num8);
      MonoBehaviour.print((object) num8);
      MonoBehaviour.print((object) num8);
      MonoBehaviour.print((object) num8);
      MonoBehaviour.print((object) num8);
      int num14 = this.danger - this.removeDanger - num9 - num10 - num11 - num12 - num13;
      while (num14 > 0)
      {
        if (num14 > 0)
        {
          --num14;
          ++num9;
        }
        if (num14 > 0)
        {
          --num14;
          ++num10;
        }
        if (num14 > 0)
        {
          --num14;
          ++num11;
        }
        if (num14 > 0)
        {
          --num14;
          ++num12;
        }
        if (num14 > 0)
        {
          --num14;
          ++num13;
        }
      }
      MonoBehaviour.print((object) num9);
      MonoBehaviour.print((object) num10);
      MonoBehaviour.print((object) num11);
      MonoBehaviour.print((object) num12);
      MonoBehaviour.print((object) num13);
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        actionWithText = true,
        param = !GameDataController.gd.getObjective("location01_door2_open") ? "0|Bitmaps/Locations/LocationResults/c_door1_closed" : "0|Bitmaps/Locations/LocationResults/c_door1_open",
        text = string.Empty
      });
      TimelineAction action5 = new TimelineAction(Timeline.t.textField);
      action5.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action5.actionWithText = false;
      if (GameDataController.gd.getObjective("location01_door2_open"))
      {
        this.analytics_doors = "open";
        action5.param = "0";
        action5.text = GameStrings.getString(GameStrings.results, "bugs_door1_open");
      }
      else
      {
        this.analytics_doors = "closed";
        this.removeDanger += num9;
        action5.param = "-" + (object) num9;
        action5.text = GameStrings.getString(GameStrings.results, "bugs_door1_closed1") + " " + (object) num9 + " " + GameStrings.getString(GameStrings.results, "bugs_door1_closed2");
      }
      Timeline.t.addAction(action5);
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        actionWithText = true,
        param = !GameDataController.gd.getObjective("location02_door_open") ? "0|Bitmaps/Locations/LocationResults/c_door2_closed" : "0|Bitmaps/Locations/LocationResults/c_door2_open",
        text = string.Empty
      });
      TimelineAction action6 = new TimelineAction(Timeline.t.textField);
      action6.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action6.actionWithText = false;
      if (GameDataController.gd.getObjective("location02_door_open"))
      {
        this.analytics_doors += "/open";
        action6.param = "0";
        action6.text = GameStrings.getString(GameStrings.results, "bugs_door2_open");
      }
      else
      {
        this.analytics_doors += "/closed";
        this.removeDanger += num10;
        action6.text = GameStrings.getString(GameStrings.results, "bugs_door2_closed1") + " " + (object) num10 + " " + GameStrings.getString(GameStrings.results, "bugs_door2_closed2");
        action6.param = (-num10).ToString() + "|Bitmaps/Locations/LocationResults/c_door2_closed";
      }
      Timeline.t.addAction(action6);
      int num15 = 22;
      int num16 = 10;
      int num17 = 17;
      int num18 = 9;
      int num19 = 10;
      int num20 = 5;
      TimelineAction action7 = new TimelineAction(Timeline.t.textField);
      action7.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action7.actionWithText = true;
      int num21 = 0;
      int num22;
      if (GameDataController.gd.getObjective("base_window_1_net_nailed") && GameDataController.gd.getObjective("base_window_1_net_taped"))
      {
        this.analytics_window_1 = "net/attached";
        num22 = num15;
        if (num22 > num11)
          num22 = num11;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_net_3";
        action7.text = GameStrings.getString(GameStrings.results, "window1_net") + " " + GameStrings.getString(GameStrings.results, "net_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_net_taped"))
      {
        this.analytics_window_1 = "net/attached";
        num22 = num15 - 2;
        if (num22 > num11)
          num22 = num11;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_net_2";
        action7.text = GameStrings.getString(GameStrings.results, "window1_net") + " " + GameStrings.getString(GameStrings.results, "net_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_1_net_nailed"))
      {
        this.analytics_window_1 = "net/attached";
        num22 = num15 - 1;
        if (num22 > num11)
          num22 = num11;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_net_1";
        action7.text = GameStrings.getString(GameStrings.results, "window1_net") + " " + GameStrings.getString(GameStrings.results, "net_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_net"))
      {
        this.analytics_window_1 = "net/loose";
        num22 = num16;
        if (num22 > num11)
          num22 = num11;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_net_0";
        action7.text = GameStrings.getString(GameStrings.results, "window1_net") + " " + GameStrings.getString(GameStrings.results, "net_none");
      }
      else if (GameDataController.gd.getObjective("base_window_1_foil_nailed") && GameDataController.gd.getObjective("base_window_1_foil_taped"))
      {
        this.analytics_window_1 = "foil/attached";
        num22 = num17;
        if (num22 > num11)
          num22 = num11;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_foil_3";
        action7.text = GameStrings.getString(GameStrings.results, "window1_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_foil_taped"))
      {
        this.analytics_window_1 = "foil/attached";
        num22 = num17 - 3;
        if (num22 > num11)
          num22 = num11;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_foil_2";
        action7.text = GameStrings.getString(GameStrings.results, "window1_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_1_foil_nailed"))
      {
        this.analytics_window_1 = "foil/attached";
        num22 = num17 - 1;
        if (num22 > num11)
          num22 = num11;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_foil_1";
        action7.text = GameStrings.getString(GameStrings.results, "window1_foil") + " " + GameStrings.getString(GameStrings.results, "foil_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_foil"))
      {
        this.analytics_window_1 = "foil/loose";
        num22 = num18;
        if (num22 > num11)
          num22 = num11;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_foil_0";
        action7.text = GameStrings.getString(GameStrings.results, "window1_foil") + " " + GameStrings.getString(GameStrings.results, "foil_none");
      }
      else if (GameDataController.gd.getObjective("base_window_1_bars_nailed") && GameDataController.gd.getObjective("base_window_1_bars_taped"))
      {
        this.analytics_window_1 = "bars/attached";
        num22 = num19;
        if (num22 > num11)
          num22 = num11;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_bars_3";
        action7.text = GameStrings.getString(GameStrings.results, "window1_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_bars_taped"))
      {
        this.analytics_window_1 = "bars/attached";
        num22 = num19 - 3;
        if (num22 > num11)
          num22 = num11;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_bars_2";
        action7.text = GameStrings.getString(GameStrings.results, "window1_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_1_bars_nailed"))
      {
        this.analytics_window_1 = "bars/attached";
        num22 = num19 - 1;
        if (num22 > num11)
          num22 = num11;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_bars_1";
        action7.text = GameStrings.getString(GameStrings.results, "window1_bars") + " " + GameStrings.getString(GameStrings.results, "bars_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_1_bars"))
      {
        this.analytics_window_1 = "bars/loose";
        num22 = num20;
        if (num22 > num11)
          num22 = num11;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_bars_0";
        action7.text = GameStrings.getString(GameStrings.results, "window1_bars") + " " + GameStrings.getString(GameStrings.results, "bars_none");
      }
      else
      {
        this.analytics_window_1 = "empty";
        num22 = 0;
        action7.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_empty";
        action7.text = GameStrings.getString(GameStrings.results, "window1_open");
      }
      Timeline.t.addAction(action7);
      this.removeDanger += num22;
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        param = "-" + (object) num22,
        text = GameStrings.getString(GameStrings.results, "bugs_window_result1") + " " + (object) num11 + " " + GameStrings.getString(GameStrings.results, "bugs_window_result2") + " " + (object) num22 + " " + GameStrings.getString(GameStrings.results, "bugs_window_result3")
      });
      TimelineAction action8 = new TimelineAction(Timeline.t.textField);
      action8.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action8.actionWithText = true;
      num21 = 0;
      int num23;
      if (GameDataController.gd.getObjective("base_window_2_net_nailed") && GameDataController.gd.getObjective("base_window_2_net_taped"))
      {
        this.analytics_window_2 = "net/attached";
        num23 = num15;
        if (num23 > num12)
          num23 = num12;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_net_3";
        action8.text = GameStrings.getString(GameStrings.results, "window2_net") + " " + GameStrings.getString(GameStrings.results, "net_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_net_taped"))
      {
        this.analytics_window_2 = "net/attached";
        num23 = num15;
        if (num23 > num12)
          num23 = num12;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_net_2";
        action8.text = GameStrings.getString(GameStrings.results, "window2_net") + " " + GameStrings.getString(GameStrings.results, "net_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_2_net_nailed"))
      {
        this.analytics_window_2 = "net/attached";
        num23 = num15;
        if (num23 > num12)
          num23 = num12;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_net_1";
        action8.text = GameStrings.getString(GameStrings.results, "window2_net") + " " + GameStrings.getString(GameStrings.results, "net_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_net"))
      {
        this.analytics_window_2 = "net/loose";
        num23 = num16;
        if (num23 > num12)
          num23 = num12;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_net_0";
        action8.text = GameStrings.getString(GameStrings.results, "window2_net") + " " + GameStrings.getString(GameStrings.results, "net_none");
      }
      else if (GameDataController.gd.getObjective("base_window_2_foil_nailed") && GameDataController.gd.getObjective("base_window_2_foil_taped"))
      {
        this.analytics_window_2 = "foil/attached";
        num23 = num17;
        if (num23 > num12)
          num23 = num12;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_foil_3";
        action8.text = GameStrings.getString(GameStrings.results, "window2_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_foil_taped"))
      {
        this.analytics_window_2 = "foil/attached";
        num23 = num17;
        if (num23 > num12)
          num23 = num12;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_foil_2";
        action8.text = GameStrings.getString(GameStrings.results, "window2_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_2_foil_nailed"))
      {
        this.analytics_window_2 = "foil/attached";
        num23 = num17;
        if (num23 > num12)
          num23 = num12;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_foil_1";
        action8.text = GameStrings.getString(GameStrings.results, "window2_foil") + " " + GameStrings.getString(GameStrings.results, "foil_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_foil"))
      {
        this.analytics_window_2 = "foil/loose";
        num23 = num18;
        if (num23 > num12)
          num23 = num12;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_foil_0";
        action8.text = GameStrings.getString(GameStrings.results, "window2_foil") + " " + GameStrings.getString(GameStrings.results, "foil_none");
      }
      else if (GameDataController.gd.getObjective("base_window_2_bars_nailed") && GameDataController.gd.getObjective("base_window_2_bars_taped"))
      {
        this.analytics_window_2 = "bars/attached";
        num23 = num19;
        if (num23 > num12)
          num23 = num12;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_bars_3";
        action8.text = GameStrings.getString(GameStrings.results, "window2_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_bars_taped"))
      {
        this.analytics_window_2 = "bars/attached";
        num23 = num19;
        if (num23 > num12)
          num23 = num12;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_bars_2";
        action8.text = GameStrings.getString(GameStrings.results, "window2_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_2_bars_nailed"))
      {
        this.analytics_window_2 = "bars/attached";
        num23 = num19;
        if (num23 > num12)
          num23 = num12;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_bars_1";
        action8.text = GameStrings.getString(GameStrings.results, "window2_bars") + " " + GameStrings.getString(GameStrings.results, "bars_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_2_bars"))
      {
        this.analytics_window_2 = "bars/loose";
        num23 = num20;
        if (num23 > num12)
          num23 = num12;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_bars_0";
        action8.text = GameStrings.getString(GameStrings.results, "window2_bars") + " " + GameStrings.getString(GameStrings.results, "bars_none");
      }
      else
      {
        this.analytics_window_2 = "empty";
        num23 = 0;
        action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_empty";
        action8.text = GameStrings.getString(GameStrings.results, "window2_open");
      }
      Timeline.t.addAction(action8);
      this.removeDanger += num23;
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        param = "-" + (object) num23,
        text = GameStrings.getString(GameStrings.results, "bugs_window_result1") + " " + (object) num12 + " " + GameStrings.getString(GameStrings.results, "bugs_window_result2") + " " + (object) num23 + " " + GameStrings.getString(GameStrings.results, "bugs_window_result3")
      });
      TimelineAction action9 = new TimelineAction(Timeline.t.textField);
      action9.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action9.actionWithText = true;
      num21 = 0;
      int num24;
      if (GameDataController.gd.getObjective("base_window_3_net_nailed") && GameDataController.gd.getObjective("base_window_3_net_taped"))
      {
        this.analytics_window_3 = "net/attached";
        num24 = num15;
        if (num24 > num13)
          num24 = num13;
        action9.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_net_3";
        action9.text = GameStrings.getString(GameStrings.results, "window3_net") + " " + GameStrings.getString(GameStrings.results, "net_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_net_taped"))
      {
        this.analytics_window_3 = "net/attached";
        num24 = num15;
        if (num24 > num13)
          num24 = num13;
        action9.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_net_2";
        action9.text = GameStrings.getString(GameStrings.results, "window3_net") + " " + GameStrings.getString(GameStrings.results, "net_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_3_net_nailed"))
      {
        this.analytics_window_3 = "net/attached";
        num24 = num15;
        if (num24 > num13)
          num24 = num13;
        action9.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_net_1";
        action9.text = GameStrings.getString(GameStrings.results, "window3_net") + " " + GameStrings.getString(GameStrings.results, "net_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_net"))
      {
        this.analytics_window_3 = "net/loose";
        num24 = num16;
        if (num24 > num13)
          num24 = num13;
        action9.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_net_0";
        action9.text = GameStrings.getString(GameStrings.results, "window3_net") + " " + GameStrings.getString(GameStrings.results, "net_none");
      }
      else if (GameDataController.gd.getObjective("base_window_3_foil_nailed") && GameDataController.gd.getObjective("base_window_3_foil_taped"))
      {
        this.analytics_window_3 = "foil/attached";
        num24 = num17;
        if (num24 > num13)
          num24 = num13;
        action9.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_foil_3";
        action9.text = GameStrings.getString(GameStrings.results, "window3_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_foil_taped"))
      {
        this.analytics_window_3 = "foil/attached";
        num24 = num17;
        if (num24 > num13)
          num24 = num13;
        action9.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_foil_2";
        action9.text = GameStrings.getString(GameStrings.results, "window3_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_3_foil_nailed"))
      {
        this.analytics_window_3 = "foil/attached";
        num24 = num17;
        if (num24 > num13)
          num24 = num13;
        action9.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_foil_1";
        action9.text = GameStrings.getString(GameStrings.results, "window3_foil") + " " + GameStrings.getString(GameStrings.results, "foil_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_foil"))
      {
        this.analytics_window_3 = "foil/loose";
        num24 = num18;
        if (num24 > num13)
          num24 = num13;
        action9.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_foil_0";
        action9.text = GameStrings.getString(GameStrings.results, "window3_foil") + " " + GameStrings.getString(GameStrings.results, "foil_none");
      }
      else if (GameDataController.gd.getObjective("base_window_3_bars_nailed") && GameDataController.gd.getObjective("base_window_3_bars_taped"))
      {
        this.analytics_window_3 = "bars/attached";
        num24 = num19;
        if (num24 > num13)
          num24 = num13;
        action9.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_bars_3";
        action9.text = GameStrings.getString(GameStrings.results, "window3_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_bars_taped"))
      {
        this.analytics_window_3 = "bars/attached";
        num24 = num19;
        if (num24 > num13)
          num24 = num13;
        action9.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_bars_2";
        action9.text = GameStrings.getString(GameStrings.results, "window3_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped");
      }
      else if (GameDataController.gd.getObjective("base_window_3_bars_nailed"))
      {
        this.analytics_window_3 = "bars/attached";
        num24 = num19;
        if (num24 > num13)
          num24 = num13;
        action9.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_bars_1";
        action9.text = GameStrings.getString(GameStrings.results, "window3_bars") + " " + GameStrings.getString(GameStrings.results, "bars_nailed");
      }
      else if (GameDataController.gd.getObjective("base_window_3_bars"))
      {
        this.analytics_window_3 = "bars/loose";
        num24 = num20;
        if (num24 > num13)
          num24 = num13;
        action9.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_bars_0";
        action9.text = GameStrings.getString(GameStrings.results, "window3_bars") + " " + GameStrings.getString(GameStrings.results, "bars_none");
      }
      else
      {
        this.analytics_window_3 = "empty";
        num24 = 0;
        action9.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_empty";
        action9.text = GameStrings.getString(GameStrings.results, "window3_open");
      }
      Timeline.t.addAction(action9);
      TimelineAction action10 = new TimelineAction(Timeline.t.textField);
      action10.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action10.param = "-" + (object) num24;
      action10.text = GameStrings.getString(GameStrings.results, "bugs_window_result1") + " " + (object) num13 + " " + GameStrings.getString(GameStrings.results, "bugs_window_result2") + " " + (object) num24 + " " + GameStrings.getString(GameStrings.results, "bugs_window_result3");
      this.removeDanger += num24;
      Timeline.t.addAction(action10);
      if (this.removeDanger >= this.pbc.total)
        this.winQuality = 3;
      else
        this.winQuality = 2;
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        param = "0",
        text = GameStrings.getString(GameStrings.results, "bugs_enter1") + " " + (object) (this.danger - this.removeDanger) + " " + GameStrings.getString(GameStrings.results, "bugs_enter2")
      });
      if (GameDataController.gd.getObjective("bugs_bath"))
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "0|Bitmaps/Locations/LocationResults/c_bath",
          text = string.Empty
        });
        TimelineAction action11 = new TimelineAction(Timeline.t.textField);
        action11.function = new TimelineFunction(((ResultsController) this).changeDanger);
        int num25 = 25;
        if (num25 > this.danger - this.removeDanger)
          num25 = this.danger - this.removeDanger;
        this.removeDanger += num25;
        action11.param = "-" + (object) num25;
        action11.text = GameStrings.getString(GameStrings.results, "bugs_bath1") + " " + (object) num25 + " " + GameStrings.getString(GameStrings.results, "bugs_bath2");
        Timeline.t.addAction(action11);
      }
      this.analytics_weapon = GameDataController.gd.equipped;
      if (GameDataController.gd.equipped == "flamethrower")
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "0|Bitmaps/Locations/LocationResults/c_flamethrower_bugs",
          text = string.Empty
        });
        TimelineAction action12 = new TimelineAction(Timeline.t.textField);
        action12.function = new TimelineFunction(((ResultsController) this).changeDanger);
        int num26 = 40;
        if (num26 > this.danger - this.removeDanger)
          num26 = this.danger - this.removeDanger;
        this.removeDanger += num26;
        action12.param = "-" + (object) num26;
        action12.text = GameStrings.getString(GameStrings.results, "bugs_flamethrower1") + " " + (object) num26 + " " + GameStrings.getString(GameStrings.results, "bugs_flamethrower2");
        Timeline.t.addAction(action12);
      }
      else if (GameDataController.gd.equipped == "pestsprayer")
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "0|Bitmaps/Locations/LocationResults/c_spray_bugs",
          text = string.Empty
        });
        TimelineAction action13 = new TimelineAction(Timeline.t.textField);
        action13.function = new TimelineFunction(((ResultsController) this).changeDanger);
        int num27 = 30;
        if (num27 > this.danger - this.removeDanger)
          num27 = this.danger - this.removeDanger;
        this.removeDanger += num27;
        action13.param = "-" + (object) num27;
        action13.text = GameStrings.getString(GameStrings.results, "bugs_spray1") + " " + (object) num27 + " " + GameStrings.getString(GameStrings.results, "bugs_spray2");
        Timeline.t.addAction(action13);
      }
      else
      {
        TimelineAction action14 = new TimelineAction(Timeline.t.textField);
        action14.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action14.actionWithText = true;
        string str = "fists";
        int num28 = 5;
        if (GameDataController.gd.equipped == "wrench")
        {
          str = "wrench";
          num28 = 20;
        }
        else if (GameDataController.gd.equipped == "crowbar")
        {
          str = "crowbar";
          num28 = 20;
        }
        else if (GameDataController.gd.equipped == "pipe")
        {
          str = "pipe";
          num28 = 20;
        }
        else if (GameDataController.gd.equipped.IndexOf("rifle") != -1)
        {
          str = "rifle";
          num28 = 25;
        }
        action14.param = "0|Bitmaps/Locations/LocationResults/c_bugfight_" + str;
        action14.text = string.Empty;
        Timeline.t.addAction(action14);
        TimelineAction action15 = new TimelineAction(Timeline.t.textField);
        action15.function = new TimelineFunction(((ResultsController) this).changeDanger);
        if (num28 > this.danger - this.removeDanger)
          num28 = this.danger - this.removeDanger;
        this.removeDanger += num28;
        action15.param = "-" + (object) num28;
        action15.text = GameStrings.getString(GameStrings.results, "bugs_fight_" + str + "1") + " " + (object) num28 + " " + GameStrings.getString(GameStrings.results, "bugs_fight_" + str + "2");
        Timeline.t.addAction(action15);
      }
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
      this.analytics_stayed = "outside";
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        text = GameStrings.getString(GameStrings.results, "bugs_no_house"),
        function = new TimelineFunction(((ResultsController) this).liveOrDie)
      });
    }
  }
}
