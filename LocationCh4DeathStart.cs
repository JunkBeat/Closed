// Decompiled with JetBrains decompiler
// Type: LocationCh4DeathStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationCh4DeathStart : MonoBehaviour
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
    TimelineAction action = new TimelineAction(Timeline.t.textField);
    if (GameDataController.gd.getObjective("ship_launched"))
    {
      action.textWidth = 200;
      Timeline.t.textField.shift.x = -100f;
      Timeline.t.textField.shift.y = 50f;
      Timeline.t.textField.directionY = 1f;
      if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 0)
      {
        action.text = GameStrings.getString(GameStrings.results, "r_d4_no_air_bad");
        Timeline.t.addAction(action);
      }
      if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 1)
      {
        action.text = GameStrings.getString(GameStrings.results, "r_d4_no_fuel_bad");
        Timeline.t.addAction(action);
      }
    }
    Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
    {
      function = new TimelineFunction(this.end),
      actionWithText = false,
      param = "0",
      text = GameStrings.getString(GameStrings.results, "day4_death")
    });
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_game_over);
    JukeboxAmbient.jb.changeAmbient((AudioClip) null, 0.0f);
    GameObject.Find("barry_dead_body").gameObject.GetComponent<SpriteRenderer>().enabled = false;
    GameObject.Find("cody_dead_body").gameObject.GetComponent<SpriteRenderer>().enabled = false;
    if (!GameDataController.gd.getObjective("ship_launched"))
    {
      GameObject.Find("Location").transform.Find("plane01").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Location").transform.Find("plane02").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Location").transform.Find("plane03").GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      GameObject.Find("Location").transform.Find("plane01").GetComponent<SpriteRenderer>().enabled = false;
      if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 0)
      {
        GameObject.Find("Location").transform.Find("plane02").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("Location").transform.Find("plane03").GetComponent<SpriteRenderer>().enabled = false;
        if (GameDataController.gd.getObjective("npc2_alive"))
          GameObject.Find("barry_dead_body").gameObject.GetComponent<SpriteRenderer>().enabled = true;
        else
          GameObject.Find("barry_dead_body").gameObject.GetComponent<SpriteRenderer>().enabled = false;
        if (GameDataController.gd.getObjective("npc3_alive"))
          GameObject.Find("cody_dead_body").gameObject.GetComponent<SpriteRenderer>().enabled = true;
        else
          GameObject.Find("cody_dead_body").gameObject.GetComponent<SpriteRenderer>().enabled = false;
      }
      if (GameDataController.gd.getObjectiveDetail("day_4_threat") != 1)
        return;
      GameObject.Find("Location").transform.Find("plane02").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Location").transform.Find("plane03").GetComponent<SpriteRenderer>().enabled = true;
    }
  }

  private void end(string param) => GameDataController.gd.politeLoad(GameDataController.CHAPTER_4_COMPLETE_AUTOSAVE);

  private void Update()
  {
  }
}
