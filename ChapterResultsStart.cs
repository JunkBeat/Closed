// Decompiled with JetBrains decompiler
// Type: ChapterResultsStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class ChapterResultsStart : MonoBehaviour
{
  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = -5f;
    PlayerController.wc.shadow.startAlpha = 0.0f;
    PlayerController.wc.shadow.source = 10f;
    PlayerController.ssg.setStepType("none");
    MonoBehaviour.print((object) "............................. LOCATION INFO  ..................................");
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(-999f, -999f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    InventoryButtonController.ibc.gameObject.transform.position = worldPoint;
    GameObject.Find("inventory_button").transform.position = worldPoint;
    MonoBehaviour.print((object) ("CHOWAM PLECAK " + (object) worldPoint + " VS " + (object) InventoryButtonController.ibc.gameObject.transform.position));
    Timeline.t.textField.directionY = 1f;
    Timeline.t.textField.shift = new Vector2(-25f, 20f);
    Timeline.defaultTwidth = 130;
    if (GameDataController.gd.getCurrentDay() == 1)
    {
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
        GameObject.Find("ResultsController").transform.Find("ResultsBugs").GetComponent<ResultsChapterBugs>().init();
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
        GameObject.Find("ResultsController").transform.Find("ResultsGas").GetComponent<ResultsChapterGas>().init();
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
        GameObject.Find("ResultsController").transform.Find("ResultsSpiders").GetComponent<ResultsChapterSpiders>().init();
    }
    else if (GameDataController.gd.getCurrentDay() == 2)
    {
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
        GameObject.Find("ResultsController").transform.Find("ResultsHot").GetComponent<ResultsChapterHot>().init();
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
        GameObject.Find("ResultsController").transform.Find("ResultsCold").GetComponent<ResultsChapterCold>().init();
    }
    else if (GameDataController.gd.getCurrentDay() == 3)
    {
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
        GameObject.Find("ResultsController").transform.Find("ResultsBandits").GetComponent<ResultsChapterBandits>().init();
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
        GameObject.Find("ResultsController").transform.Find("ResultsStorm").GetComponent<ResultsChapterStorm>().init();
    }
    else if (GameDataController.gd.getCurrentDay() == 4)
    {
      if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 0)
        GameObject.Find("ResultsController").transform.Find("ResultsShipAir").GetComponent<ResultsChapterShipAir>().init();
      if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 1)
        GameObject.Find("ResultsController").transform.Find("ResultsShipFuel").GetComponent<ResultsChapterShipFuel>().init();
    }
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_attack, minTime: 0.0f, maxTime: 0.0f);
    JukeboxAmbient.jb.changeAmbient((AudioClip) null, 0.0f);
  }

  private void Update()
  {
  }
}
