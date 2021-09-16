// Decompiled with JetBrains decompiler
// Type: LocationBugDeathStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationBugDeathStart : MonoBehaviour
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
    PlayerController.pc.copySettingsToNPCs();
    MonoBehaviour.print((object) "............................. LOCATION INFO  ..................................");
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(-999f, -999f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    InventoryButtonController.ibc.gameObject.transform.position = worldPoint;
    TimelineAction action1 = new TimelineAction(Timeline.t.textField);
    action1.param = "0";
    action1.textWidth = 190;
    Timeline.t.textField.shift.x = -80f;
    Timeline.t.textField.shift.y = 50f;
    Timeline.t.textField.directionY = 1f;
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
    {
      action1.text = GameStrings.getString(GameStrings.results, "day1_spiders_bad1") + " " + (object) -GameDataController.gd.getObjectiveDetail("day1_complete") + " " + GameStrings.getString(GameStrings.results, "day1_spiders_bad2");
      Timeline.t.addAction(action1);
    }
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
    {
      action1.text = GameStrings.getString(GameStrings.results, "day1_bugs_bad1") + " " + (object) -GameDataController.gd.getObjectiveDetail("day1_complete") + " " + GameStrings.getString(GameStrings.results, "day1_bugs_bad2");
      Timeline.t.addAction(action1);
    }
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
    {
      action1.text = GameStrings.getString(GameStrings.results, "day1_gas_bad1") + " " + (object) -GameDataController.gd.getObjectiveDetail("day1_complete") + " " + GameStrings.getString(GameStrings.results, "day1_gas_bad2");
      Timeline.t.addAction(action1);
    }
    TimelineAction action2 = new TimelineAction(Timeline.t.textField);
    action2.function = new TimelineFunction(this.end);
    action2.actionWithText = false;
    action2.param = "0";
    Timeline.t.textField.directionY = 1f;
    action2.textWidth = 190;
    Timeline.t.textField.shift.x = -80f;
    Timeline.t.textField.shift.y = 50f;
    action2.text = GameStrings.getString(GameStrings.results, "day1_death");
    Timeline.t.addAction(action2);
    GameObject.Find("Spider (1)").gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(GameObject.Find("Spider (1)").gameObject.transform.position);
    GameObject.Find("Spider (2)").gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(GameObject.Find("Spider (2)").gameObject.transform.position);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_game_over);
    JukeboxAmbient.jb.changeAmbient((AudioClip) null, 0.0f);
    if (GameDataController.gd.finishingLocation == "Location1" || GameDataController.gd.finishingLocation == "Location2" || GameDataController.gd.finishingLocation == "LocationBaseUpstairs" || GameDataController.gd.finishingLocation == "LocationBaseBathroom")
    {
      GameObject.Find("Location").transform.Find("black").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Location").transform.Find("plane01").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Location").transform.Find("plane02").GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      GameObject.Find("Location").transform.Find("black").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Location").transform.Find("plane01").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Location").transform.Find("plane02").GetComponent<SpriteRenderer>().enabled = true;
    }
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
    {
      GameObject.Find("player_gas_dead_body").gameObject.GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("player_bugs_dead_body").gameObject.GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("bugs_feast_1").transform.position = ScreenControler.roundToNearestFullPixel2(GameObject.Find("bugs_feast_1").transform.position);
      GameObject.Find("bugs_feast_1").gameObject.GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Gas (1)").gameObject.GetComponent<ParticleGenerator>().started = false;
      GameObject.Find("Gas (2)").gameObject.GetComponent<ParticleGenerator>().started = false;
      GameObject.Find("Gas (3)").gameObject.GetComponent<ParticleGenerator>().started = false;
      GameObject.Find("Gas (4)").gameObject.GetComponent<ParticleGenerator>().started = false;
      GameObject.Find("Gas (5)").gameObject.GetComponent<ParticleGenerator>().started = false;
      GameObject.Find("Gas").gameObject.GetComponent<ParticleGenerator>().started = false;
      GameObject.Find("Spider (1)").gameObject.GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Spider (2)").gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
    {
      GameObject.Find("player_gas_dead_body").gameObject.GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("player_bugs_dead_body").gameObject.GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("bugs_feast_1").gameObject.GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Gas (1)").gameObject.GetComponent<ParticleGenerator>().started = true;
      GameObject.Find("Gas (2)").gameObject.GetComponent<ParticleGenerator>().started = true;
      GameObject.Find("Gas (3)").gameObject.GetComponent<ParticleGenerator>().started = true;
      GameObject.Find("Gas (4)").gameObject.GetComponent<ParticleGenerator>().started = true;
      GameObject.Find("Gas (5)").gameObject.GetComponent<ParticleGenerator>().started = true;
      GameObject.Find("Gas").gameObject.GetComponent<ParticleGenerator>().started = true;
      GameObject.Find("Spider (1)").gameObject.GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Spider (2)").gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 2)
      return;
    GameObject.Find("player_gas_dead_body").gameObject.GetComponent<SpriteRenderer>().enabled = true;
    GameObject.Find("player_bugs_dead_body").gameObject.GetComponent<SpriteRenderer>().enabled = false;
    GameObject.Find("bugs_feast_1").gameObject.GetComponent<SpriteRenderer>().enabled = false;
    GameObject.Find("Gas (1)").gameObject.GetComponent<ParticleGenerator>().started = false;
    GameObject.Find("Gas (2)").gameObject.GetComponent<ParticleGenerator>().started = false;
    GameObject.Find("Gas (3)").gameObject.GetComponent<ParticleGenerator>().started = false;
    GameObject.Find("Gas (4)").gameObject.GetComponent<ParticleGenerator>().started = false;
    GameObject.Find("Gas (5)").gameObject.GetComponent<ParticleGenerator>().started = false;
    GameObject.Find("Gas").gameObject.GetComponent<ParticleGenerator>().started = false;
    GameObject.Find("Spider (1)").gameObject.GetComponent<SpriteRenderer>().enabled = true;
    GameObject.Find("Spider (2)").gameObject.GetComponent<SpriteRenderer>().enabled = true;
    GameObject.Find("Spider (1)").gameObject.GetComponent<Animator>().Play("eat_fast");
    GameObject.Find("Spider (2)").gameObject.GetComponent<Animator>().Play("eat_fast");
  }

  private void end(string param) => GameDataController.gd.politeLoad(GameDataController.CHAPTER_1_COMPLETE_AUTOSAVE);

  private void Update()
  {
  }
}
