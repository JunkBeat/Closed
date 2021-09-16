// Decompiled with JetBrains decompiler
// Type: ProgressBarController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class ProgressBarController : MonoBehaviour
{
  public float delay;
  public float percent;
  public int total = 1000;
  public int current = 1000;
  public int visibleCurrent;
  private SpriteRenderer sr;
  private GameObject bar;
  private GameObject lifeLine;
  private TextFieldController tf;
  private int timeToUpdateText = 1;
  public float surv;
  public int dayWeFace;

  private void Start()
  {
    this.sr = this.gameObject.transform.Find("bar").GetComponent<SpriteRenderer>();
    this.bar = this.gameObject.transform.Find("bar").gameObject;
    this.lifeLine = this.gameObject.transform.Find("LifeLine").gameObject;
    this.tf = this.gameObject.GetComponent<TextFieldController>();
    if (GameDataController.gd.getCurrentDay() == 1)
    {
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/progressbar_frame");
        GameObject.Find("Location").transform.Find("plane01").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/background_bugs");
      }
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
      {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/progressbar_frame_gas");
        GameObject.Find("Location").transform.Find("plane01").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/background_gas");
      }
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
      {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/progressbar_frame_spiders");
        GameObject.Find("Location").transform.Find("plane01").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/background_spiders");
      }
    }
    else if (GameDataController.gd.getCurrentDay() == 2)
    {
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
      {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/background_cold_frame");
        GameObject.Find("Location").transform.Find("plane01").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/background_cold");
      }
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
      {
        if (GameDataController.gd.previousLocation == "LocationCave")
        {
          this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/background_heat2_frame");
          GameObject.Find("Location").transform.Find("plane01").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/background_heat2");
        }
        else
        {
          this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/background_heat_frame");
          GameObject.Find("Location").transform.Find("plane01").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/background_heat");
        }
      }
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 2)
      {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/progressbar_frame_spiders");
        GameObject.Find("Location").transform.Find("plane01").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/background_spiders");
      }
    }
    else if (GameDataController.gd.getCurrentDay() == 3)
    {
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
      {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/background_d3_0_frame");
        GameObject.Find("Location").transform.Find("plane01").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/background_d3_0");
      }
      else if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
      {
        if (GameDataController.gd.getObjective("base_outside_dug"))
          this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/background_storm_b");
        else
          this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/background_storm");
        GameObject.Find("Location").transform.Find("plane01").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/background_storm2");
      }
    }
    else if (GameDataController.gd.getCurrentDay() == 4)
    {
      if (GameDataController.gd.getObjective("outpost_hatch_open"))
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/rocket_prelaunchF");
      else
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/rocket_prelaunchF2");
      GameObject.Find("Location").transform.Find("plane01").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/LocationResults/rocket_prelaunch");
    }
    this.dayWeFace = GameDataController.gd.getCurrentDay();
  }

  private void Update()
  {
    this.delay += Time.deltaTime;
    if ((double) this.delay < 0.0165999997407198)
      return;
    this.delay = 0.0f;
    bool updateText = false;
    if (this.visibleCurrent < this.current)
    {
      if (this.current - this.visibleCurrent >= 100)
        this.visibleCurrent += 10;
      else if (this.current - this.visibleCurrent >= 10)
        this.visibleCurrent += 2;
      else
        ++this.visibleCurrent;
      updateText = true;
    }
    else if (this.visibleCurrent > this.current)
    {
      if (this.visibleCurrent - this.current >= 100)
        this.visibleCurrent -= 10;
      else if (this.visibleCurrent - this.current >= 10)
        this.visibleCurrent -= 2;
      else
        --this.visibleCurrent;
      updateText = true;
    }
    this.percent = (float) this.visibleCurrent / (float) this.total;
    this.updateView(updateText);
  }

  public void setValue(int target) => this.current = target;

  private void updateView(bool updateText = false)
  {
    if (updateText)
    {
      this.tf.shift = new Vector2(0.0f, 47f);
      this.tf.center = true;
      string key = string.Empty;
      if (this.dayWeFace == 1)
      {
        if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
          key = "bugs_sufix";
        if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
          key = "gas_sufix";
        if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
          key = "spiders_sufix";
      }
      else if (this.dayWeFace == 2)
      {
        if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
          key = "cold_sufix";
        if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
          key = "hot_sufix";
      }
      else if (this.dayWeFace == 3)
      {
        if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
          key = "bandits_sufix";
        if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
          key = "rain_sufix";
      }
      else if (this.dayWeFace == 4)
      {
        if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 0)
          key = "air_sufix";
        if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 1)
          key = "fuel_sufix";
      }
      this.tf.viewText(this.visibleCurrent.ToString() + " " + GameStrings.getString(GameStrings.results, key), quick: true, instant: true, mwidth: 100, constantRefresh: true);
      this.tf.keepAlive = true;
    }
    Vector3 vector3_1 = this.coords(new Vector2(Mathf.Floor((float) ((double) this.percent * 200.0 - 200.0)), 0.0f));
    Vector3 vector3_2 = this.coords(new Vector2(Mathf.Floor(this.surv / (float) this.total * 200f), 0.0f));
    this.bar.transform.position = new Vector3(vector3_1.x, vector3_1.y, this.bar.transform.position.z);
    this.lifeLine.transform.position = new Vector3(vector3_2.x, vector3_2.y, this.lifeLine.transform.position.z);
  }

  private Vector3 coords(Vector2 source)
  {
    Vector2 screen1 = ScreenControler.gameToScreen(new Vector2(source.x, source.y));
    Vector3 worldPoint1 = Camera.main.ScreenToWorldPoint(new Vector3(screen1.x, screen1.y, 0.0f));
    Vector2 screen2 = ScreenControler.gameToScreen(new Vector2(0.0f, 0.0f));
    Vector3 worldPoint2 = Camera.main.ScreenToWorldPoint(new Vector3(screen2.x, screen2.y, 0.0f));
    worldPoint1.x -= worldPoint2.x;
    worldPoint1.y -= worldPoint2.y;
    return worldPoint1;
  }
}
