// Decompiled with JetBrains decompiler
// Type: ResultsChapterShipFuel
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class ResultsChapterShipFuel : ResultsController
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
  private string analytics_calib = "false";
  private string analytics_catalyst = "false";
  private string analytics_hull = "false";
  private string analytics_launched = "false";
  private string analytics_mixture = "0";
  private string analytics_nav = "false";

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
      int num = 0 + GameDataController.gd.getObjectiveDetail("outpost_score_a") + GameDataController.gd.getObjectiveDetail("outpost_score_b") + GameDataController.gd.getObjectiveDetail("outpost_score_c") + GameDataController.gd.getObjectiveDetail("outpost_score_d") + GameDataController.gd.getObjectiveDetail("outpost_score_e");
      this.analytics_mixture = num.ToString() + "/10";
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(this.changeView),
        actionWithText = true,
        param = "-" + (object) 0 + "|hide",
        text = GameStrings.getString(GameStrings.results, "r_d4_fuel_mixture1")
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
        text = GameStrings.getString(GameStrings.results, "r_d4_fuel_mixture2")
      });
      string key = string.Empty;
      string str = string.Empty;
      if (num == 0)
        key = "r_d4_fuel_mixture_0";
      if (num > 0 && num <= 3)
        key = "r_d4_fuel_mixture_1";
      if (num > 3 && num <= 6)
        key = "r_d4_fuel_mixture_2";
      if (num > 6 && num <= 9)
        key = "r_d4_fuel_mixture_3";
      if (num == 10)
        key = "r_d4_fuel_mixture_4";
      if (num == 0)
        str = "c_mix_1";
      if (num > 0 && num <= 3)
        str = "c_mix_2";
      if (num > 3 && num <= 6)
        str = "c_mix_3";
      if (num > 6 && num <= 9)
        str = "c_mix_4";
      if (num == 10)
        str = "c_mix_5";
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(((ResultsController) this).changeDanger),
        actionWithText = true,
        param = "-" + (object) 0 + "|Bitmaps/Locations/LocationResults/" + str,
        text = GameStrings.getString(GameStrings.results, "r_d4_fuel_mixture3")
      });
      TimelineAction action = new TimelineAction(Timeline.t.textField);
      action.function = new TimelineFunction(((ResultsController) this).changeDanger);
      action.actionWithText = false;
      action.param = "-" + (object) (num * 2);
      this.removeDanger += num * 2;
      action.text = GameStrings.getString(GameStrings.results, key);
      Timeline.t.addAction(action);
      if (GameDataController.gd.getObjective("outpost_navigation_chip_inserted"))
      {
        this.analytics_nav = "true";
        this.check(label: "r_d4_nav_inserted", pic: "c_nav_inserted");
        this.check(20, "r_d4_nav_inserted2", string.Empty);
      }
      else
      {
        this.check(label: "r_d4_nav_missing", pic: "c_nav_missing");
        this.check(label: "r_d4_nav_missing2", pic: string.Empty);
      }
      if (GameDataController.gd.getObjective("outpost_calibrator_inserted"))
      {
        this.analytics_calib = "true";
        this.check(label: "r_d4_calibrator_inserted", pic: "c_calibrator_inserted");
        this.check(20, "r_d4_calibrator_inserted2", string.Empty);
      }
      else
      {
        this.check(label: "r_d4_calibrator_missing", pic: "c_calibrator_missing");
        this.check(label: "r_d4_calibrator_missing2", pic: string.Empty);
      }
      if (GameDataController.gd.getObjective("outpost_hull_repaired_outside"))
      {
        this.analytics_hull = "true";
        this.check(label: "r_d4_hull_outside_fixed", pic: "c_hull_outside_fixed");
        this.check(20, "r_d4_hull_outside_fixed2", string.Empty);
      }
      else
      {
        this.check(label: "r_d4_hull_outside_broken", pic: "c_hull_outside_broken");
        this.check(label: "r_d4_hull_outside_broken2", pic: string.Empty);
      }
      if (GameDataController.gd.getObjective("outpost_catalyst_used"))
      {
        this.analytics_catalyst = "true";
        this.check(label: "r_d4_catalyst_inserted", pic: "c_ship_catalyst");
        this.check(20, "r_d4_catalyst_inserted2", string.Empty);
      }
      else
      {
        this.check(label: "r_d4_catalyst_missing", pic: "c_ship_catalyst");
        this.check(label: "r_d4_catalyst_missing2", pic: string.Empty);
      }
      if (this.danger - this.removeDanger <= this.surviavbleDanger)
      {
        this.check(label: "r_d4_no_fuel1", pic: "c_ship_cate");
        this.check(label: "r_d4_no_fuel2", pic: "hide");
        this.check(label: "r_d4_no_fuel3", pic: string.Empty);
        this.check(label: "r_d4_no_fuel4", pic: string.Empty);
        this.check(label: "r_d4_no_fuel5", pic: string.Empty);
        this.check(label: "r_d4_no_fuel6", pic: string.Empty);
      }
      else
      {
        this.check(label: "r_d4_no_fuel_dead1", pic: string.Empty);
        this.check(label: "r_d4_no_fuel_dead2", pic: string.Empty);
        this.check(label: "r_d4_no_fuel_dead3", pic: string.Empty);
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
