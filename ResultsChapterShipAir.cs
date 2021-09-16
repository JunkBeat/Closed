// Decompiled with JetBrains decompiler
// Type: ResultsChapterShipAir
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ResultsChapterShipAir : ResultsController
{
  private float time;
  private SpriteRenderer sr;
  private SpriteRenderer sr2;
  private Sprite launch_sprite;
  private Sprite fly_sprite_1;
  private Sprite fly_sprite_2;
  private Sprite fly_sprite_3;
  private Sprite fly_sprite_4;
  private Sprite launch_spriteF;
  private Sprite fly_sprite_1F;
  private Sprite fly_sprite_2F;
  private Sprite fly_sprite_3F;
  private Sprite fly_sprite_4F;
  private float show_launch;
  private bool show_flight;
  private string analytics_aux_tanks = "false";
  private string analytics_filters = "false";
  private string analytics_hull = "false";
  private string analytics_launched = "false";
  private string analytics_mixture = "0";
  private string analytics_pills = "0";

  public void changeMusic(string s = "")
  {
    this.rf.move(-0.63f, -0.25f);
    this.show_launch = 1f;
    Timeline.t.textField.directionY = -1f;
    Timeline.defaultTwidth = 140;
    Timeline.t.textField.shift = new Vector2(-35f, -60f);
    this.changeDanger(s);
    GameObject.Find("Location").GetComponent<LocationManager>().needShake = 5f;
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_attack2, minTime: 0.0f, maxTime: 1f);
    GameObject.Find("Location").transform.Find("plane01").GetComponent<SpriteRenderer>().sprite = this.launch_sprite;
    GameObject.Find("ProgressBar").GetComponent<SpriteRenderer>().sprite = this.launch_spriteF;
  }

  public void changeView(string s = "")
  {
    Timeline.t.textField.directionY = -1f;
    Timeline.defaultTwidth = 140;
    Timeline.t.textField.shift = new Vector2(-35f, -60f);
    this.changeDanger(s);
    this.show_flight = true;
  }

  private void Update()
  {
    if ((Object) this.sr == (Object) null)
      return;
    this.sr2.color = new Color(1f, 1f, 1f, 1f - this.show_launch);
    if ((double) this.show_launch > 0.0)
      this.show_launch -= Time.deltaTime;
    if ((double) this.show_launch < 0.0)
      this.show_launch = 0.0f;
    if (!this.show_flight)
      return;
    this.time += Time.deltaTime * 2f;
    this.sr.sprite = (double) this.time <= 0.75 ? ((double) this.time <= 0.5 ? ((double) this.time <= 0.25 ? this.fly_sprite_4 : this.fly_sprite_3) : this.fly_sprite_2) : this.fly_sprite_1;
    this.sr2.sprite = (double) this.time <= 0.75 ? ((double) this.time <= 0.5 ? ((double) this.time <= 0.25 ? this.fly_sprite_4F : this.fly_sprite_3F) : this.fly_sprite_2F) : this.fly_sprite_1F;
    if ((double) this.time <= 1.0)
      return;
    this.time = 0.0f;
  }

  public override void chapterResult()
  {
    Timeline.t.textField.shift = new Vector2(-25f, 20f);
    this.sr = GameObject.Find("Location").transform.Find("plane01").GetComponent<SpriteRenderer>();
    this.sr2 = GameObject.Find("ProgressBar").GetComponent<SpriteRenderer>();
    this.launch_sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/rocket_start");
    this.fly_sprite_1 = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/end_flight0");
    this.fly_sprite_2 = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/end_flight1");
    this.fly_sprite_3 = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/end_flight2");
    this.fly_sprite_4 = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/end_flight3");
    this.launch_spriteF = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/rocket_start_f");
    this.fly_sprite_1F = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/end_flight0_f");
    this.fly_sprite_2F = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/end_flight1_f");
    this.fly_sprite_3F = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/end_flight2_f");
    this.fly_sprite_4F = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/end_flight3_f");
    this.show_flight = false;
    this.time = 0.0f;
    this.surviavbleDanger = 20;
    this.danger = 0;
    this.removeDanger = 0;
    this.pbc.total = 100;
    this.changeDanger(this.pbc.total.ToString());
    Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
    {
      text = GameStrings.getString(GameStrings.results, "r_d4_0")
    });
    if (GameDataController.gd.getObjective("ship_launched"))
    {
      this.analytics_launched = "true";
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        text = GameStrings.getString(GameStrings.results, "r_d4_launched")
      });
      this.check(label: "r_d4_cate", pic: "c_ship_cate");
      this.check(label: "r_d4_hatch1", pic: "c_ship_hatch");
      this.check(label: "r_d4_hatch2", pic: string.Empty);
      this.check(label: "r_d4_hatch3", pic: string.Empty);
      this.check(label: "r_d4_hatch4", pic: string.Empty);
      this.check(label: "r_d4_hatch5", pic: string.Empty);
      this.check(label: "r_d4_cate2", pic: "c_ship_cate");
      this.check(label: "r_d4_cate3", pic: string.Empty);
      this.check(label: "r_d4_cate4", pic: string.Empty);
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(this.changeMusic),
        actionWithText = true,
        param = "-" + (object) 0 + "|hide",
        text = GameStrings.getString(GameStrings.results, "r_d4_1")
      });
      if (GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjective("npc2_alive"))
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_seat_cody_barry",
          text = GameStrings.getString(GameStrings.results, "r_d4_cody_barry")
        });
      else if (GameDataController.gd.getObjective("npc3_alive"))
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_seat_cody",
          text = GameStrings.getString(GameStrings.results, "r_d4_cody")
        });
        if (GameDataController.gd.getObjective("npc2_joined"))
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            actionWithText = true,
            param = "-" + (object) 0,
            text = GameStrings.getString(GameStrings.results, "r_d4_barry_dead")
          });
      }
      else if (GameDataController.gd.getObjective("npc2_alive"))
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_seat_barry",
          text = GameStrings.getString(GameStrings.results, "r_d4_barry")
        });
        if (GameDataController.gd.getObjective("npc3_joined"))
          Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
          {
            function = new TimelineFunction(((ResultsController) this).changeDanger),
            actionWithText = true,
            param = "-" + (object) 0,
            text = GameStrings.getString(GameStrings.results, "r_d4_cody_dead")
          });
      }
      else
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_seat_nobody",
          text = GameStrings.getString(GameStrings.results, "r_d4_nobody")
        });
      int num1 = 0 + GameDataController.gd.getObjectiveDetail("outpost_score_a") + GameDataController.gd.getObjectiveDetail("outpost_score_b") + GameDataController.gd.getObjectiveDetail("outpost_score_c") + GameDataController.gd.getObjectiveDetail("outpost_score_d") + GameDataController.gd.getObjectiveDetail("outpost_score_e");
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(this.changeView),
        actionWithText = true,
        param = "-" + (object) 0 + "|hide",
        text = GameStrings.getString(GameStrings.results, "r_d4_air_mixture1")
      });
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && !GameDataController.gd.getObjective("thug_killed_bathroom"))
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_ship_razor",
          text = GameStrings.getString(GameStrings.results, "r_d4_razor1")
        });
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + string.Empty,
          text = GameStrings.getString(GameStrings.results, "r_d4_razor2")
        });
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + string.Empty,
          text = GameStrings.getString(GameStrings.results, "r_d4_razor3")
        });
      }
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getObjective("gasstation_sarge_convinced") && !GameDataController.gd.getObjective("cs_food_poisioned") || GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && GameDataController.gd.getObjective("restaurant_sarge_encountered"))
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_ship_sarge",
          text = GameStrings.getString(GameStrings.results, "r_d4_sarge1")
        });
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + string.Empty,
          text = GameStrings.getString(GameStrings.results, "r_d4_sarge2")
        });
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + string.Empty,
          text = GameStrings.getString(GameStrings.results, "r_d4_sarge3")
        });
      }
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        actionWithText = true,
        param = "-" + (object) 0 + "|hide",
        text = GameStrings.getString(GameStrings.results, "r_d4_air_mixture2")
      });
      string key = string.Empty;
      string str = string.Empty;
      if (num1 == 0)
        key = "r_d4_air_mixture_0";
      if (num1 > 0 && num1 <= 3)
        key = "r_d4_air_mixture_1";
      if (num1 > 3 && num1 <= 6)
        key = "r_d4_air_mixture_2";
      if (num1 > 6 && num1 <= 9)
        key = "r_d4_air_mixture_3";
      if (num1 == 10)
        key = "r_d4_air_mixture_4";
      if (num1 == 0)
        str = "c_mix_1";
      if (num1 > 0 && num1 <= 3)
        str = "c_mix_2";
      if (num1 > 3 && num1 <= 6)
        str = "c_mix_3";
      if (num1 > 6 && num1 <= 9)
        str = "c_mix_4";
      if (num1 == 10)
        str = "c_mix_5";
      this.analytics_mixture = num1.ToString() + "/10";
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        actionWithText = true,
        param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/" + str,
        text = GameStrings.getString(GameStrings.results, "r_d4_air_mixture3")
      });
      TimelineAction action1 = new TimelineAction(Timeline.t.textField);
      action1.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action1.actionWithText = false;
      action1.param = "-" + (object) (num1 * 2);
      this.removeDanger += num1 * 2;
      action1.text = GameStrings.getString(GameStrings.results, key);
      Timeline.t.addAction(action1);
      if (GameDataController.gd.getObjective("outpost_lioh_filters_inserted"))
      {
        this.analytics_filters = "true";
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_lioh_filters_inserted",
          text = GameStrings.getString(GameStrings.results, "r_d4_lioh_filters_inserted")
        });
        TimelineAction action2 = new TimelineAction(Timeline.t.textField);
        action2.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action2.actionWithText = false;
        action2.param = "-" + (object) 20;
        this.removeDanger += 20;
        action2.text = GameStrings.getString(GameStrings.results, "r_d4_lioh_filters_inserted2");
        Timeline.t.addAction(action2);
      }
      else
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_lioh_filters_missing",
          text = GameStrings.getString(GameStrings.results, "r_d4_lioh_filters_missing")
        });
        TimelineAction action3 = new TimelineAction(Timeline.t.textField);
        action3.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action3.actionWithText = false;
        action3.param = "-" + (object) 0;
        ResultsChapterShipAir resultsChapterShipAir = this;
        resultsChapterShipAir.removeDanger = resultsChapterShipAir.removeDanger;
        action3.text = GameStrings.getString(GameStrings.results, "r_d4_lioh_filters_missing2");
        Timeline.t.addAction(action3);
      }
      if (GameDataController.gd.getObjective("outpost_air_tanks_inserted"))
      {
        this.analytics_aux_tanks = "true";
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_air_tanks_inserted",
          text = GameStrings.getString(GameStrings.results, "r_d4_air_tanks_inserted")
        });
        TimelineAction action4 = new TimelineAction(Timeline.t.textField);
        action4.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action4.actionWithText = false;
        action4.param = "-" + (object) 20;
        this.removeDanger += 20;
        action4.text = GameStrings.getString(GameStrings.results, "r_d4_air_tanks_inserted2");
        Timeline.t.addAction(action4);
      }
      else
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_air_tanks_missing",
          text = GameStrings.getString(GameStrings.results, "r_d4_air_tanks_missing")
        });
        TimelineAction action5 = new TimelineAction(Timeline.t.textField);
        action5.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action5.actionWithText = false;
        action5.param = "-" + (object) 0;
        ResultsChapterShipAir resultsChapterShipAir = this;
        resultsChapterShipAir.removeDanger = resultsChapterShipAir.removeDanger;
        action5.text = GameStrings.getString(GameStrings.results, "r_d4_air_tanks_missing2");
        Timeline.t.addAction(action5);
      }
      if (GameDataController.gd.getObjective("outpost_hull_repaired_inside"))
      {
        this.analytics_hull = "true";
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_hull_inside_fixed",
          text = GameStrings.getString(GameStrings.results, "r_d4_hull_inside_fixed")
        });
        TimelineAction action6 = new TimelineAction(Timeline.t.textField);
        action6.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action6.actionWithText = false;
        action6.param = "-" + (object) 20;
        this.removeDanger += 20;
        action6.text = GameStrings.getString(GameStrings.results, "r_d4_hull_inside_fixed2");
        Timeline.t.addAction(action6);
      }
      else
      {
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_hull_inside_broken",
          text = GameStrings.getString(GameStrings.results, "r_d4_hull_inside_broken")
        });
        TimelineAction action7 = new TimelineAction(Timeline.t.textField);
        action7.function = new TimelineFunction(((ResultsController) this).changeDanger);
        action7.actionWithText = false;
        action7.param = "-" + (object) 0;
        ResultsChapterShipAir resultsChapterShipAir = this;
        resultsChapterShipAir.removeDanger = resultsChapterShipAir.removeDanger;
        action7.text = GameStrings.getString(GameStrings.results, "r_d4_hull_inside_broken2");
        Timeline.t.addAction(action7);
      }
      if (InventoryController.ic.isItemEquipped("pills") || GameDataController.gd.getObjective("cate_pills_taken") || GameDataController.gd.getObjective("barry_pills_taken") || GameDataController.gd.getObjective("cody_pills_taken"))
      {
        int num2 = 2;
        int num3 = 0;
        int num4 = 0;
        if (GameDataController.gd.getObjective("npc2_alive"))
          ++num2;
        if (GameDataController.gd.getObjective("npc3_alive"))
          ++num2;
        if (num2 == 2)
          num4 = 10;
        if (num2 == 3)
          num4 = 7;
        if (num2 == 4)
          num4 = 5;
        Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
        {
          function = new TimelineFunction(((ResultsController) this).changeDanger),
          actionWithText = true,
          param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/c_pills",
          text = GameStrings.getString(GameStrings.results, "r_d4_pills")
        });
        if (InventoryController.ic.isItemEquipped("pills"))
        {
          ++num3;
          TimelineAction action8 = new TimelineAction(Timeline.t.textField);
          action8.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action8.actionWithText = false;
          action8.param = "-" + (object) num4;
          this.removeDanger += num4;
          action8.text = GameStrings.getString(GameStrings.results, "r_d4_pills_you");
          Timeline.t.addAction(action8);
        }
        else
        {
          TimelineAction action9 = new TimelineAction(Timeline.t.textField);
          action9.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action9.actionWithText = false;
          action9.param = "-" + (object) 0;
          ResultsChapterShipAir resultsChapterShipAir = this;
          resultsChapterShipAir.removeDanger = resultsChapterShipAir.removeDanger;
          action9.text = GameStrings.getString(GameStrings.results, "r_d4_no_pills_you");
          Timeline.t.addAction(action9);
        }
        if (GameDataController.gd.getObjective("cate_pills_taken"))
        {
          ++num3;
          int num5 = num4;
          if (num4 == 7)
            num5 = 6;
          TimelineAction action10 = new TimelineAction(Timeline.t.textField);
          action10.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action10.actionWithText = false;
          action10.param = "-" + (object) num5;
          this.removeDanger += num5;
          action10.text = GameStrings.getString(GameStrings.results, "r_d4_pills_cate");
          Timeline.t.addAction(action10);
        }
        else
        {
          TimelineAction action11 = new TimelineAction(Timeline.t.textField);
          action11.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action11.actionWithText = false;
          action11.param = "-" + (object) 0;
          ResultsChapterShipAir resultsChapterShipAir = this;
          resultsChapterShipAir.removeDanger = resultsChapterShipAir.removeDanger;
          action11.text = GameStrings.getString(GameStrings.results, "r_d4_no_pills_cate");
          Timeline.t.addAction(action11);
        }
        if (GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjective("barry_pills_taken"))
        {
          ++num3;
          TimelineAction action12 = new TimelineAction(Timeline.t.textField);
          action12.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action12.actionWithText = false;
          action12.param = "-" + (object) num4;
          this.removeDanger += num4;
          action12.text = GameStrings.getString(GameStrings.results, "r_d4_pills_barry");
          Timeline.t.addAction(action12);
        }
        else if (GameDataController.gd.getObjective("npc2_alive"))
        {
          TimelineAction action13 = new TimelineAction(Timeline.t.textField);
          action13.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action13.actionWithText = false;
          action13.param = "-" + (object) 0;
          ResultsChapterShipAir resultsChapterShipAir = this;
          resultsChapterShipAir.removeDanger = resultsChapterShipAir.removeDanger;
          action13.text = GameStrings.getString(GameStrings.results, "r_d4_no_pills_barry");
          Timeline.t.addAction(action13);
        }
        if (GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjective("cody_pills_taken"))
        {
          ++num3;
          TimelineAction action14 = new TimelineAction(Timeline.t.textField);
          action14.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action14.actionWithText = false;
          action14.param = "-" + (object) num4;
          this.removeDanger += num4;
          action14.text = GameStrings.getString(GameStrings.results, "r_d4_pills_cody");
          Timeline.t.addAction(action14);
        }
        else if (GameDataController.gd.getObjective("npc3_alive"))
        {
          TimelineAction action15 = new TimelineAction(Timeline.t.textField);
          action15.function = new TimelineFunction(((ResultsController) this).changeDanger);
          action15.actionWithText = false;
          action15.param = "-" + (object) 0;
          ResultsChapterShipAir resultsChapterShipAir = this;
          resultsChapterShipAir.removeDanger = resultsChapterShipAir.removeDanger;
          action15.text = GameStrings.getString(GameStrings.results, "r_d4_no_pills_cody");
          Timeline.t.addAction(action15);
        }
        this.analytics_pills = num3.ToString() + "/" + (object) num2;
      }
      if (this.danger - this.removeDanger <= this.surviavbleDanger)
      {
        this.check(label: "r_d4_no_air1", pic: "c_ship_cate");
        this.check(label: "r_d4_no_air2", pic: "hide");
        this.check(label: "r_d4_no_air3", pic: string.Empty);
        this.check(label: "r_d4_no_air4", pic: string.Empty);
        this.check(label: "r_d4_no_air5", pic: string.Empty);
        this.check(label: "r_d4_no_air6", pic: string.Empty);
        this.check(label: "r_d4_no_air7", pic: string.Empty);
      }
      else
      {
        this.check(label: "r_d4_no_air_dead1", pic: string.Empty);
        this.check(label: "r_d4_no_air_dead2", pic: string.Empty);
        this.check(label: "r_d4_no_air_dead3", pic: string.Empty);
      }
      if (this.danger - this.removeDanger <= 0)
        this.winQuality = 3;
      else
        this.winQuality = 2;
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).liveOrDie),
        actionWithText = true,
        param = "0",
        text = string.Empty
      });
    }
    else
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        text = GameStrings.getString(GameStrings.results, "r_d4_no_launch"),
        function = new TimelineFunction(((ResultsController) this).liveOrDie)
      });
  }
}
