// Decompiled with JetBrains decompiler
// Type: ResultsChapterSpiders
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class ResultsChapterSpiders : ResultsController
{
  private string analytics_stayed = "?";
  private string analytics_doors = "?";
  private string analytics_weapon = "?";
  private string analytics_repel = "?";
  private string analytics_sprinklers = "?";
  private string analytics_traps = "?";
  private string analytics_window_1 = "?";
  private string analytics_window_2 = "?";
  private string analytics_window_3 = "?";

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
      text = GameStrings.getString(GameStrings.results, "spiders_intro")
    });
    if (GameDataController.gd.getObjective("base_discovered") && (GameDataController.gd.previousLocation == "Location1" || GameDataController.gd.previousLocation == "Location2" || GameDataController.gd.previousLocation == "LocationBaseUpstairs" || GameDataController.gd.previousLocation == "LocationBaseBathroom"))
    {
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        text = GameStrings.getString(GameStrings.results, "spiders_house")
      });
      this.analytics_stayed = "base";
      if (GameDataController.gd.getObjective("barn_sprinklers_enabled") && GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 2)
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = !GameDataController.gd.getObjective("barn_sprinklers_fed1") ? "0|Bitmaps/Locations/LocationResults/c_sprinklers_0b" : "0|Bitmaps/Locations/LocationResults/c_sprinklers_1b",
          text = GameStrings.getString(GameStrings.results, "spiders_sprinklers_on")
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
          this.analytics_sprinklers += "leaking";
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
        int num2 = num1 * 0;
        this.removeDanger += num2;
        TimelineAction timelineAction1 = action1;
        timelineAction1.text = timelineAction1.text + " ^" + GameStrings.getString(GameStrings.results, "spiders_sprinklers_result");
        action1.param = (-num2).ToString();
        Timeline.t.addAction(action1);
        if (GameDataController.gd.getObjective("barn_sprinklers_fed1"))
        {
          float num3 = 0.0f;
          TimelineAction action2 = new TimelineAction(Timeline.t.textField);
          if (GameDataController.gd.getObjective("barn_sprinklers_fed1"))
          {
            action2.text = GameStrings.getString(GameStrings.results, "spiders_sprinklers_pest1");
            num3 = 0.0f;
          }
          float num4;
          if (ItemsManager.im.getItem("spiderpest1").dataRef.droppedLocation == "sprinklers" && GameDataController.gd.getObjectiveDetail("spiders_type") == 1)
          {
            num4 = 0.75f;
            this.analytics_repel = "correct";
          }
          else if (ItemsManager.im.getItem("spiderpest2").dataRef.droppedLocation == "sprinklers" && GameDataController.gd.getObjectiveDetail("spiders_type") == 0)
          {
            num4 = 0.75f;
            this.analytics_repel = "correct";
          }
          else if (ItemsManager.im.getItem("spiderpest3").dataRef.droppedLocation == "sprinklers" && GameDataController.gd.getObjectiveDetail("spiders_type") == 2)
          {
            num4 = 0.75f;
            this.analytics_repel = "correct";
          }
          else if (ItemsManager.im.getItem("spiderpest4").dataRef.droppedLocation == "sprinklers" && GameDataController.gd.getObjectiveDetail("spiders_type") == 3)
          {
            num4 = 0.75f;
            this.analytics_repel = "correct";
          }
          else
          {
            num4 = 0.0f;
            this.analytics_repel = "wrong";
          }
          float f = num4 * (float) num1;
          if ((double) f > 0.0 && (double) f < 1.0)
            f = 1f;
          float num5 = (float) (int) Mathf.Floor(f);
          action2.function = new TimelineFunction(((ResultsController) this).changeDanger);
          this.removeDanger += (int) num5;
          action2.param = (-(int) num5).ToString();
          if ((double) num5 != 0.0)
          {
            TimelineAction timelineAction2 = action2;
            timelineAction2.text = timelineAction2.text + " ^" + GameStrings.getString(GameStrings.results, "spiders_sprinklers_result1b") + " " + (object) num5 + " " + GameStrings.getString(GameStrings.results, "spiders_sprinklers_result2b");
          }
          else
          {
            action2.param = -1.ToString();
            ++this.removeDanger;
            TimelineAction timelineAction3 = action2;
            timelineAction3.text = timelineAction3.text + " ^" + GameStrings.getString(GameStrings.results, "spiders_sprinklers_result1fail");
          }
          Timeline.t.addAction(action2);
        }
      }
      this.analytics_traps = string.Empty;
      if (ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1 && ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("nowhere") == -1 || ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1 && ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("nowhere") == -1)
      {
        TimelineAction action3 = new TimelineAction(Timeline.t.textField);
        action3.text = GameStrings.getString(GameStrings.results, "spiders_trap");
        action3.actionWithText = true;
        action3.function = new TimelineFunction(((ResultsController) this).changeDanger);
        int num6 = 0;
        int num7 = 0;
        if (ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1 && ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("nowhere") == -1)
          num6 = ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("outside") == -1 ? (ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("location1") != -1 || ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("location\t2") != -1 || ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("upstairs") != -1 || ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("locationbase") != -1 ? 2 : 3) : 1;
        if (ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1 && ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("nowhere") == -1)
          num7 = ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("outside") == -1 ? (ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("location01") != -1 || ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("location02") != -1 || ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("upstairs") != -1 || ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("locationbase") != -1 ? 2 : 3) : 1;
        this.analytics_traps = num6 != 1 || num7 != 1 ? (num6 == 1 || num7 == 1 ? "1 trap outside" : "0 traps outside") : "2 traps outside";
        if (num6 == 1 || num7 == 1)
        {
          action3.param = "0|Bitmaps/Locations/LocationResults/c_beartrap_0";
          Timeline.t.addAction(action3);
        }
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          param = "0|Bitmaps/Locations/LocationResults/c_beartrap_1",
          actionWithText = true,
          instant = true
        });
        if (num6 == 1 && num7 == 1)
        {
          TimelineAction action4 = new TimelineAction(Timeline.t.textField);
          action4.function = new TimelineFunction(((ResultsController) this).changeDanger);
          int num8 = 2;
          TimelineAction timelineAction = action4;
          timelineAction.text = timelineAction.text + string.Empty + GameStrings.getString(GameStrings.results, "spiders_trap2a");
          action4.param = "-" + num8.ToString() + "|Bitmaps/Locations/LocationResults/c_beartrap_1";
          action4.actionWithText = false;
          this.removeDanger += num8;
          Timeline.t.addAction(action4);
        }
        else if (num6 == 1 || num7 == 1)
        {
          TimelineAction action5 = new TimelineAction(Timeline.t.textField);
          action5.function = new TimelineFunction(((ResultsController) this).changeDanger);
          int num9 = 1;
          TimelineAction timelineAction = action5;
          timelineAction.text = timelineAction.text + string.Empty + GameStrings.getString(GameStrings.results, "spiders_trap1a");
          action5.param = "-" + num9.ToString() + "|Bitmaps/Locations/LocationResults/c_beartrap_1";
          action5.actionWithText = false;
          this.removeDanger += num9;
          Timeline.t.addAction(action5);
        }
      }
      bool flag = false;
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        actionWithText = true,
        param = !GameDataController.gd.getObjective("location01_door2_open") ? "0|Bitmaps/Locations/LocationResults/c_door1_closed" : "0|Bitmaps/Locations/LocationResults/c_door1_open",
        text = string.Empty
      });
      TimelineAction action6 = new TimelineAction(Timeline.t.textField);
      action6.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action6.actionWithText = false;
      if (GameDataController.gd.getObjective("location01_door2_open"))
      {
        this.analytics_doors = "open";
        flag = true;
        action6.param = "0";
        action6.text = GameStrings.getString(GameStrings.results, "spiders_door1_open");
      }
      else
      {
        this.analytics_doors = "closed";
        ResultsChapterSpiders resultsChapterSpiders = this;
        resultsChapterSpiders.removeDanger = resultsChapterSpiders.removeDanger;
        action6.param = "0";
        action6.text = GameStrings.getString(GameStrings.results, "spiders_door1_closed1") + " " + GameStrings.getString(GameStrings.results, "spiders_door1_closed2");
      }
      Timeline.t.addAction(action6);
      if (!flag)
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = !GameDataController.gd.getObjective("location02_door_open") ? "0|Bitmaps/Locations/LocationResults/c_door2_closed" : "0|Bitmaps/Locations/LocationResults/c_door2_open",
          text = string.Empty
        });
        TimelineAction action7 = new TimelineAction(Timeline.t.textField);
        action7.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action7.actionWithText = false;
        if (GameDataController.gd.getObjective("location02_door_open"))
        {
          this.analytics_doors += "/open";
          flag = true;
          action7.param = "0";
          action7.text = GameStrings.getString(GameStrings.results, "spiders_door2_open");
        }
        else
        {
          this.analytics_doors += "/open";
          ResultsChapterSpiders resultsChapterSpiders = this;
          resultsChapterSpiders.removeDanger = resultsChapterSpiders.removeDanger;
          action7.text = GameStrings.getString(GameStrings.results, "spiders_door2_closed1") + " " + GameStrings.getString(GameStrings.results, "spiders_door2_closed2");
          action7.param = 0.ToString() + "|Bitmaps/Locations/LocationResults/c_door2_closed";
        }
        Timeline.t.addAction(action7);
      }
      if (!flag)
      {
        int num10 = this.pbc.total - this.removeDanger;
        int num11 = num10 / 3;
        int num12 = num10 / 3;
        int num13 = num10 / 3;
        MonoBehaviour.print((object) num10);
        MonoBehaviour.print((object) num10);
        MonoBehaviour.print((object) num10);
        MonoBehaviour.print((object) num10);
        MonoBehaviour.print((object) num10);
        MonoBehaviour.print((object) num10);
        MonoBehaviour.print((object) num10);
        int num14 = this.danger - this.removeDanger - num11 - num12 - num13;
        while (num14 > 0)
        {
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
        MonoBehaviour.print((object) num11);
        MonoBehaviour.print((object) num12);
        MonoBehaviour.print((object) num13);
        int num15 = 2;
        int num16 = 0;
        int num17 = 2;
        int num18 = 0;
        int num19 = 4;
        int num20 = 2;
        TimelineAction action8 = new TimelineAction(Timeline.t.textField);
        action8.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action8.actionWithText = true;
        int num21 = 0;
        int num22;
        if (GameDataController.gd.getObjective("base_window_1_net_nailed") && GameDataController.gd.getObjective("base_window_1_net_taped"))
        {
          this.analytics_window_1 = "net/attached";
          num22 = num15 + 1;
          if (num22 > num11)
            num22 = num11;
          action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_net_3";
          action8.text = GameStrings.getString(GameStrings.results, "window1_net") + " " + GameStrings.getString(GameStrings.results, "net_taped_nailed");
        }
        else if (GameDataController.gd.getObjective("base_window_1_net_taped"))
        {
          this.analytics_window_1 = "net/attached";
          num22 = num15 - 1;
          if (num22 > num11)
            num22 = num11;
          action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_net_2";
          action8.text = GameStrings.getString(GameStrings.results, "window1_net") + " " + GameStrings.getString(GameStrings.results, "net_taped");
        }
        else if (GameDataController.gd.getObjective("base_window_1_net_nailed"))
        {
          this.analytics_window_1 = "net/attached";
          num22 = num15;
          if (num22 > num11)
            num22 = num11;
          action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_net_1";
          action8.text = GameStrings.getString(GameStrings.results, "window1_net") + " " + GameStrings.getString(GameStrings.results, "net_nailed");
        }
        else if (GameDataController.gd.getObjective("base_window_1_net"))
        {
          this.analytics_window_1 = "net/loose";
          num22 = num16;
          if (num22 > num11)
            num22 = num11;
          action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_net_0";
          action8.text = GameStrings.getString(GameStrings.results, "window1_net") + " " + GameStrings.getString(GameStrings.results, "net_none");
        }
        else if (GameDataController.gd.getObjective("base_window_1_foil_nailed") && GameDataController.gd.getObjective("base_window_1_foil_taped"))
        {
          this.analytics_window_1 = "foil/attached";
          num22 = num17 + 1;
          if (num22 > num11)
            num22 = num11;
          action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_foil_3";
          action8.text = GameStrings.getString(GameStrings.results, "window1_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped_nailed");
        }
        else if (GameDataController.gd.getObjective("base_window_1_foil_taped"))
        {
          this.analytics_window_1 = "foil/attached";
          num22 = num17 - 1;
          if (num22 > num11)
            num22 = num11;
          action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_foil_2";
          action8.text = GameStrings.getString(GameStrings.results, "window1_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped");
        }
        else if (GameDataController.gd.getObjective("base_window_1_foil_nailed"))
        {
          this.analytics_window_1 = "foil/attached";
          num22 = num17;
          if (num22 > num11)
            num22 = num11;
          action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_foil_1";
          action8.text = GameStrings.getString(GameStrings.results, "window1_foil") + " " + GameStrings.getString(GameStrings.results, "foil_nailed");
        }
        else if (GameDataController.gd.getObjective("base_window_1_foil"))
        {
          this.analytics_window_1 = "foil/loose";
          num22 = num18;
          if (num22 > num11)
            num22 = num11;
          action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_foil_0";
          action8.text = GameStrings.getString(GameStrings.results, "window1_foil") + " " + GameStrings.getString(GameStrings.results, "foil_none");
        }
        else if (GameDataController.gd.getObjective("base_window_1_bars_nailed") && GameDataController.gd.getObjective("base_window_1_bars_taped"))
        {
          this.analytics_window_1 = "bars/attached";
          num22 = num19 + 1;
          if (num22 > num11)
            num22 = num11;
          action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_bars_3";
          action8.text = GameStrings.getString(GameStrings.results, "window1_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped_nailed");
        }
        else if (GameDataController.gd.getObjective("base_window_1_bars_taped"))
        {
          this.analytics_window_1 = "bars/attached";
          num22 = num19 - 1;
          if (num22 > num11)
            num22 = num11;
          action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_bars_2";
          action8.text = GameStrings.getString(GameStrings.results, "window1_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped");
        }
        else if (GameDataController.gd.getObjective("base_window_1_bars_nailed"))
        {
          this.analytics_window_1 = "bars/attached";
          num22 = num19;
          if (num22 > num11)
            num22 = num11;
          action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_bars_1";
          action8.text = GameStrings.getString(GameStrings.results, "window1_bars") + " " + GameStrings.getString(GameStrings.results, "bars_nailed");
        }
        else if (GameDataController.gd.getObjective("base_window_1_bars"))
        {
          this.analytics_window_1 = "bars/loose";
          num22 = num20;
          if (num22 > num11)
            num22 = num11;
          action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_bars_0";
          action8.text = GameStrings.getString(GameStrings.results, "window1_bars") + " " + GameStrings.getString(GameStrings.results, "bars_none");
        }
        else
        {
          this.analytics_window_1 = "empty";
          num22 = 0;
          action8.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window1_empty";
          action8.text = GameStrings.getString(GameStrings.results, "window1_open");
        }
        Timeline.t.addAction(action8);
        this.removeDanger += num22;
        TimelineAction action9 = new TimelineAction(Timeline.t.textField);
        action9.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action9.param = "-" + (object) num22;
        action9.text = GameStrings.getString(GameStrings.results, "spiders_window_result1") + " " + (object) num11 + " " + GameStrings.getString(GameStrings.results, "spiders_window_result2") + " " + (object) num22 + " ";
        if (num22 == 1)
          action9.text += GameStrings.getString(GameStrings.results, "spiders_window_result_singular");
        else
          action9.text += GameStrings.getString(GameStrings.results, "spiders_window_result3");
        if (num11 - num22 > 0)
        {
          TimelineAction timelineAction = action9;
          timelineAction.text = timelineAction.text + " " + GameStrings.getString(GameStrings.results, "spiders_window_break");
        }
        Timeline.t.addAction(action9);
        TimelineAction action10 = new TimelineAction(Timeline.t.textField);
        action10.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action10.actionWithText = true;
        num21 = 0;
        int num23;
        if (GameDataController.gd.getObjective("base_window_2_net_nailed") && GameDataController.gd.getObjective("base_window_2_net_taped"))
        {
          this.analytics_window_2 = "net/attached";
          num23 = num15 + 1;
          if (num23 > num12)
            num23 = num12;
          action10.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_net_3";
          action10.text = GameStrings.getString(GameStrings.results, "window2_net") + " " + GameStrings.getString(GameStrings.results, "net_taped_nailed");
        }
        else if (GameDataController.gd.getObjective("base_window_2_net_taped"))
        {
          this.analytics_window_2 = "net/attached";
          num23 = num15 - 1;
          if (num23 > num12)
            num23 = num12;
          action10.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_net_2";
          action10.text = GameStrings.getString(GameStrings.results, "window2_net") + " " + GameStrings.getString(GameStrings.results, "net_taped");
        }
        else if (GameDataController.gd.getObjective("base_window_2_net_nailed"))
        {
          this.analytics_window_2 = "net/attached";
          num23 = num15;
          if (num23 > num12)
            num23 = num12;
          action10.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_net_1";
          action10.text = GameStrings.getString(GameStrings.results, "window2_net") + " " + GameStrings.getString(GameStrings.results, "net_nailed");
        }
        else if (GameDataController.gd.getObjective("base_window_2_net"))
        {
          this.analytics_window_2 = "net/loose";
          num23 = num16;
          if (num23 > num12)
            num23 = num12;
          action10.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_net_0";
          action10.text = GameStrings.getString(GameStrings.results, "window2_net") + " " + GameStrings.getString(GameStrings.results, "net_none");
        }
        else if (GameDataController.gd.getObjective("base_window_2_foil_nailed") && GameDataController.gd.getObjective("base_window_2_foil_taped"))
        {
          this.analytics_window_2 = "foil/attached";
          num23 = num17 + 1;
          if (num23 > num12)
            num23 = num12;
          action10.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_foil_3";
          action10.text = GameStrings.getString(GameStrings.results, "window2_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped_nailed");
        }
        else if (GameDataController.gd.getObjective("base_window_2_foil_taped"))
        {
          this.analytics_window_2 = "foil/attached";
          num23 = num17 - 1;
          if (num23 > num12)
            num23 = num12;
          action10.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_foil_2";
          action10.text = GameStrings.getString(GameStrings.results, "window2_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped");
        }
        else if (GameDataController.gd.getObjective("base_window_2_foil_nailed"))
        {
          this.analytics_window_2 = "foil/attached";
          num23 = num17;
          if (num23 > num12)
            num23 = num12;
          action10.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_foil_1";
          action10.text = GameStrings.getString(GameStrings.results, "window2_foil") + " " + GameStrings.getString(GameStrings.results, "foil_nailed");
        }
        else if (GameDataController.gd.getObjective("base_window_2_foil"))
        {
          this.analytics_window_2 = "foil/loose";
          num23 = num18;
          if (num23 > num12)
            num23 = num12;
          action10.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_foil_0";
          action10.text = GameStrings.getString(GameStrings.results, "window2_foil") + " " + GameStrings.getString(GameStrings.results, "foil_none");
        }
        else if (GameDataController.gd.getObjective("base_window_2_bars_nailed") && GameDataController.gd.getObjective("base_window_2_bars_taped"))
        {
          this.analytics_window_2 = "bars/attached";
          num23 = num19 + 1;
          if (num23 > num12)
            num23 = num12;
          action10.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_bars_3";
          action10.text = GameStrings.getString(GameStrings.results, "window2_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped_nailed");
        }
        else if (GameDataController.gd.getObjective("base_window_2_bars_taped"))
        {
          this.analytics_window_2 = "bars/attached";
          num23 = num19 - 1;
          if (num23 > num12)
            num23 = num12;
          action10.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_bars_2";
          action10.text = GameStrings.getString(GameStrings.results, "window2_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped");
        }
        else if (GameDataController.gd.getObjective("base_window_2_bars_nailed"))
        {
          this.analytics_window_2 = "bars/attached";
          num23 = num19;
          if (num23 > num12)
            num23 = num12;
          action10.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_bars_1";
          action10.text = GameStrings.getString(GameStrings.results, "window2_bars") + " " + GameStrings.getString(GameStrings.results, "bars_nailed");
        }
        else if (GameDataController.gd.getObjective("base_window_2_bars"))
        {
          this.analytics_window_2 = "bars/loose";
          num23 = num20;
          if (num23 > num12)
            num23 = num12;
          action10.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_bars_0";
          action10.text = GameStrings.getString(GameStrings.results, "window2_bars") + " " + GameStrings.getString(GameStrings.results, "bars_none");
        }
        else
        {
          this.analytics_window_2 = "empty";
          num23 = 0;
          action10.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window2_empty";
          action10.text = GameStrings.getString(GameStrings.results, "window2_open");
        }
        Timeline.t.addAction(action10);
        TimelineAction action11 = new TimelineAction(Timeline.t.textField);
        action11.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action11.param = "-" + (object) num23;
        action11.text = GameStrings.getString(GameStrings.results, "spiders_window_result1") + " " + (object) num12 + " " + GameStrings.getString(GameStrings.results, "spiders_window_result2") + " " + (object) num23 + " ";
        if (num23 == 1)
          action11.text += GameStrings.getString(GameStrings.results, "spiders_window_result_singular");
        else
          action11.text += GameStrings.getString(GameStrings.results, "spiders_window_result3");
        if (num12 - num23 > 0)
        {
          TimelineAction timelineAction = action11;
          timelineAction.text = timelineAction.text + " " + GameStrings.getString(GameStrings.results, "spiders_window_break");
        }
        this.removeDanger += num23;
        Timeline.t.addAction(action11);
        TimelineAction action12 = new TimelineAction(Timeline.t.textField);
        action12.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action12.actionWithText = true;
        num21 = 0;
        int num24;
        if (GameDataController.gd.getObjective("base_window_3_net_nailed") && GameDataController.gd.getObjective("base_window_3_net_taped"))
        {
          this.analytics_window_3 = "net/attached";
          num24 = num15 + 1;
          if (num24 > num13)
            num24 = num13;
          action12.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_net_3";
          action12.text = GameStrings.getString(GameStrings.results, "window3_net") + " " + GameStrings.getString(GameStrings.results, "net_taped_nailed");
        }
        else if (GameDataController.gd.getObjective("base_window_3_net_taped"))
        {
          this.analytics_window_3 = "net/attached";
          num24 = num15 - 1;
          if (num24 > num13)
            num24 = num13;
          action12.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_net_2";
          action12.text = GameStrings.getString(GameStrings.results, "window3_net") + " " + GameStrings.getString(GameStrings.results, "net_taped");
        }
        else if (GameDataController.gd.getObjective("base_window_3_net_nailed"))
        {
          this.analytics_window_3 = "net/attached";
          num24 = num15;
          if (num24 > num13)
            num24 = num13;
          action12.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_net_1";
          action12.text = GameStrings.getString(GameStrings.results, "window3_net") + " " + GameStrings.getString(GameStrings.results, "net_nailed");
        }
        else if (GameDataController.gd.getObjective("base_window_3_net"))
        {
          this.analytics_window_3 = "net/loose";
          num24 = num16;
          if (num24 > num13)
            num24 = num13;
          action12.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_net_0";
          action12.text = GameStrings.getString(GameStrings.results, "window3_net") + " " + GameStrings.getString(GameStrings.results, "net_none");
        }
        else if (GameDataController.gd.getObjective("base_window_3_foil_nailed") && GameDataController.gd.getObjective("base_window_3_foil_taped"))
        {
          this.analytics_window_3 = "foil/attached";
          num24 = num17 + 1;
          if (num24 > num13)
            num24 = num13;
          action12.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_foil_3";
          action12.text = GameStrings.getString(GameStrings.results, "window3_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped_nailed");
        }
        else if (GameDataController.gd.getObjective("base_window_3_foil_taped"))
        {
          this.analytics_window_3 = "foil/attached";
          num24 = num17 - 1;
          if (num24 > num13)
            num24 = num13;
          action12.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_foil_2";
          action12.text = GameStrings.getString(GameStrings.results, "window3_foil") + " " + GameStrings.getString(GameStrings.results, "foil_taped");
        }
        else if (GameDataController.gd.getObjective("base_window_3_foil_nailed"))
        {
          this.analytics_window_3 = "foil/attached";
          num24 = num17;
          if (num24 > num13)
            num24 = num13;
          action12.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_foil_1";
          action12.text = GameStrings.getString(GameStrings.results, "window3_foil") + " " + GameStrings.getString(GameStrings.results, "foil_nailed");
        }
        else if (GameDataController.gd.getObjective("base_window_3_foil"))
        {
          this.analytics_window_3 = "foil/loose";
          num24 = num18;
          if (num24 > num13)
            num24 = num13;
          action12.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_foil_0";
          action12.text = GameStrings.getString(GameStrings.results, "window3_foil") + " " + GameStrings.getString(GameStrings.results, "foil_none");
        }
        else if (GameDataController.gd.getObjective("base_window_3_bars_nailed") && GameDataController.gd.getObjective("base_window_3_bars_taped"))
        {
          this.analytics_window_3 = "bars/attached";
          num24 = num19 + 1;
          if (num24 > num13)
            num24 = num13;
          action12.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_bars_3";
          action12.text = GameStrings.getString(GameStrings.results, "window3_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped_nailed");
        }
        else if (GameDataController.gd.getObjective("base_window_3_bars_taped"))
        {
          this.analytics_window_3 = "bars/attached";
          num24 = num19 - 1;
          if (num24 > num13)
            num24 = num13;
          action12.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_bars_2";
          action12.text = GameStrings.getString(GameStrings.results, "window3_bars") + " " + GameStrings.getString(GameStrings.results, "bars_taped");
        }
        else if (GameDataController.gd.getObjective("base_window_3_bars_nailed"))
        {
          this.analytics_window_3 = "bars/attached";
          num24 = num19;
          if (num24 > num13)
            num24 = num13;
          action12.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_bars_1";
          action12.text = GameStrings.getString(GameStrings.results, "window3_bars") + " " + GameStrings.getString(GameStrings.results, "bars_nailed");
        }
        else if (GameDataController.gd.getObjective("base_window_3_bars"))
        {
          this.analytics_window_3 = "bars/loose";
          num24 = num20;
          if (num24 > num13)
            num24 = num13;
          action12.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_bars_0";
          action12.text = GameStrings.getString(GameStrings.results, "window3_bars") + " " + GameStrings.getString(GameStrings.results, "bars_none");
        }
        else
        {
          this.analytics_window_3 = "empty";
          num24 = 0;
          action12.param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_window3_empty";
          action12.text = GameStrings.getString(GameStrings.results, "window3_open");
        }
        Timeline.t.addAction(action12);
        TimelineAction action13 = new TimelineAction(Timeline.t.textField);
        action13.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action13.param = "-" + (object) num24;
        action13.text = GameStrings.getString(GameStrings.results, "spiders_window_result1") + " " + (object) num13 + " " + GameStrings.getString(GameStrings.results, "spiders_window_result2") + " " + (object) num24 + " ";
        if (num24 == 1)
          action13.text += GameStrings.getString(GameStrings.results, "spiders_window_result_singular");
        else
          action13.text += GameStrings.getString(GameStrings.results, "spiders_window_result3");
        if (num13 - num24 > 0)
        {
          TimelineAction timelineAction = action13;
          timelineAction.text = timelineAction.text + " " + GameStrings.getString(GameStrings.results, "spiders_window_break");
        }
        this.removeDanger += num24;
        Timeline.t.addAction(action13);
      }
      if (this.removeDanger >= this.pbc.total)
        this.winQuality = 3;
      else
        this.winQuality = 2;
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        param = "0",
        text = GameStrings.getString(GameStrings.results, "spiders_enter1") + " " + (object) (this.danger - this.removeDanger) + " " + GameStrings.getString(GameStrings.results, "spiders_enter2")
      });
      if (ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1 && ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("nowhere") == -1 || ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1 && ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("nowhere") == -1)
      {
        TimelineAction action14 = new TimelineAction(Timeline.t.textField);
        action14.text = GameStrings.getString(GameStrings.results, "spiders_trap_b");
        action14.actionWithText = true;
        action14.function = new TimelineFunction(((ResultsController) this).changeDanger);
        int num25 = 0;
        int num26 = 0;
        if (ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1 && ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("nowhere") == -1)
          num25 = ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("outside") == -1 ? (ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("location1") != -1 || ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("location2") != -1 || ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("upstairs") != -1 || ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation.ToLower().IndexOf("locationbase") != -1 ? 2 : 3) : 1;
        if (ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1 && ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("nowhere") == -1)
          num26 = ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("outside") == -1 ? (ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("location1") != -1 || ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("location2") != -1 || ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("upstairs") != -1 || ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation.ToLower().IndexOf("locationbase") != -1 ? 2 : 3) : 1;
        if (num25 == 2 && num26 == 2)
          this.analytics_traps += "/2 traps inside";
        else if (num25 == 2 || num26 == 2)
          this.analytics_traps += "/1 trap inside";
        else
          this.analytics_traps += "/0 traps inside";
        if (num25 == 2 || num26 == 2)
        {
          action14.param = "0|Bitmaps/Locations/LocationResults/c_beartrap_0";
          Timeline.t.addAction(action14);
        }
        MonoBehaviour.print((object) ("TRAP STATUS: " + (object) num25 + " " + (object) num26 + " BECAUSE DROP LOCATIONS ARE " + ItemsManager.im.getItem("bear_trap_1").dataRef.droppedLocation + " " + ItemsManager.im.getItem("bear_trap_2").dataRef.droppedLocation));
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          param = "0|Bitmaps/Locations/LocationResults/c_beartrap_1",
          actionWithText = true,
          instant = true
        });
        if (num25 == 2 && num26 == 2)
        {
          TimelineAction action15 = new TimelineAction(Timeline.t.textField);
          action15.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action15.actionWithText = false;
          int num27 = 2;
          TimelineAction timelineAction = action15;
          timelineAction.text = timelineAction.text + string.Empty + GameStrings.getString(GameStrings.results, "spiders_trap2b");
          action15.param = "-" + num27.ToString() + "|Bitmaps/Locations/LocationResults/c_beartrap_1";
          this.removeDanger += num27;
          Timeline.t.addAction(action15);
        }
        else if (num25 == 2 || num26 == 2)
        {
          TimelineAction action16 = new TimelineAction(Timeline.t.textField);
          action16.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action16.actionWithText = false;
          int num28 = 1;
          TimelineAction timelineAction = action16;
          timelineAction.text = timelineAction.text + string.Empty + GameStrings.getString(GameStrings.results, "spiders_trap1b");
          action16.param = "-" + num28.ToString() + "|Bitmaps/Locations/LocationResults/c_beartrap_1";
          this.removeDanger += num28;
          Timeline.t.addAction(action16);
        }
      }
      this.analytics_weapon = GameDataController.gd.equipped;
      if (InventoryController.ic.isItemEquipped("rifle_1") || InventoryController.ic.isItemEquipped("rifle_2") || InventoryController.ic.isItemEquipped("rifle_5") || InventoryController.ic.isItemEquipped("rifle_3") || InventoryController.ic.isItemEquipped("rifle_4") || InventoryController.ic.isItemEquipped("rifle_6"))
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "0|Bitmaps/Locations/LocationResults/c_rifle_spiders",
          text = string.Empty
        });
        TimelineAction action17 = new TimelineAction(Timeline.t.textField);
        action17.function = new TimelineFunction(((ResultsController) this).changeDanger);
        int num = 5;
        if (num > this.danger - this.removeDanger)
          num = this.danger - this.removeDanger;
        this.removeDanger += num;
        action17.param = "-" + (object) num;
        action17.text = GameStrings.getString(GameStrings.results, "spiders_rifle1") + " " + (object) num + " " + GameStrings.getString(GameStrings.results, "spiders_rifle2");
        Timeline.t.addAction(action17);
      }
      else if (InventoryController.ic.isItemEquipped("flamethrower"))
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "0|Bitmaps/Locations/LocationResults/c_flamethrower_spiders",
          text = string.Empty
        });
        TimelineAction action18 = new TimelineAction(Timeline.t.textField);
        action18.function = new TimelineFunction(((ResultsController) this).changeDanger);
        int num = 7;
        if (num > this.danger - this.removeDanger)
          num = this.danger - this.removeDanger;
        this.removeDanger += num;
        action18.param = "-" + (object) num;
        action18.text = GameStrings.getString(GameStrings.results, "spiders_flamethrower1") + " " + (object) num + " " + GameStrings.getString(GameStrings.results, "spiders_flamethrower2");
        Timeline.t.addAction(action18);
      }
      else
      {
        TimelineAction action19 = new TimelineAction(Timeline.t.textField);
        action19.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action19.actionWithText = true;
        string str = "fists";
        int num = 1;
        if (InventoryController.ic.isItemEquipped("wrench"))
        {
          str = "wrench";
          num = 2;
        }
        else if (InventoryController.ic.isItemEquipped("crowbar"))
        {
          str = "crowbar";
          num = 2;
        }
        else if (InventoryController.ic.isItemEquipped("pipe"))
        {
          str = "pipe";
          num = 2;
        }
        action19.param = "0|Bitmaps/Locations/LocationResults/c_spiderfight_" + str;
        action19.text = string.Empty;
        Timeline.t.addAction(action19);
        TimelineAction action20 = new TimelineAction(Timeline.t.textField);
        action20.function = new TimelineFunction(((ResultsController) this).changeDanger);
        if (num > this.danger - this.removeDanger)
          num = this.danger - this.removeDanger;
        this.removeDanger += num;
        action20.param = "-" + (object) num;
        action20.text = GameStrings.getString(GameStrings.results, "spiders_fight_" + str + "1") + " " + (object) num + " " + GameStrings.getString(GameStrings.results, "spiders_fight_" + str + "2");
        Timeline.t.addAction(action20);
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
      this.winQuality = 0;
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        text = GameStrings.getString(GameStrings.results, "bugs_no_house"),
        function = new TimelineFunction(((ResultsController) this).liveOrDie)
      });
    }
  }
}
