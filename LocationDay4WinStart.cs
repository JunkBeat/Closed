// Decompiled with JetBrains decompiler
// Type: LocationDay4WinStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationDay4WinStart : MonoBehaviour
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
    GameDataController.Achievement("DAY_4");
    GameDataController.gd.gameTime = 480;
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_success);
    TimelineAction timelineAction = new TimelineAction(Timeline.t.textField);
    if (GameDataController.gd.getObjectiveDetail("day4_complete") > 0)
    {
      GameDataController.gd.setObjective("npc1_alive", true);
      TimelineAction action = new TimelineAction(Timeline.t.textField);
      action.function = new TimelineFunction(this.continueGame);
      action.actionWithText = false;
      action.param = "0";
      Timeline.t.textField.directionY = -1f;
      action.textWidth = 190;
      Timeline.t.textField.shift.x = -80f;
      action.text = GameStrings.getString(GameStrings.results, "day4_normal");
      Timeline.t.addAction(action);
      if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 0)
        GameDataController.Achievement("P_AIR");
      else if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 1)
        GameDataController.Achievement("P_FUEL");
    }
    else if (GameDataController.gd.getObjectiveDetail("day4_complete") <= 0)
    {
      GameDataController.gd.setObjective("npc1_alive", false);
      TimelineAction action = new TimelineAction(Timeline.t.textField);
      action.function = new TimelineFunction(this.continueGame);
      action.actionWithText = false;
      action.param = "0";
      Timeline.t.textField.directionY = -1f;
      action.textWidth = 190;
      Timeline.t.textField.shift.x = -80f;
      action.text = GameStrings.getString(GameStrings.results, "day4_penalty");
      Timeline.t.addAction(action);
    }
    if (GameDataController.gd.equipped == "pills")
      InventoryController.ic.removeItem(GameDataController.gd.equipped);
    string str1 = string.Empty;
    string str2 = !GameDataController.gd.getObjective("npc3_joined") ? "not joined/" : "joined/";
    if (GameDataController.gd.getObjective("npc3_alive"))
    {
      str1 = str2 + "alive";
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("npc3_alive") == 0)
        str2 += "died on day 2";
      if (GameDataController.gd.getObjectiveDetail("npc3_alive") == 1)
        str2 += "died in Sidereal";
      if (GameDataController.gd.getObjectiveDetail("npc3_alive") == 2)
        str1 = str2 + "died on day 3";
    }
    string str3 = string.Empty;
    string str4 = !GameDataController.gd.getObjective("npc2_joined") ? "not joined/" : "joined/";
    if (GameDataController.gd.getObjective("npc2_alive"))
    {
      str3 = str4 + "alive";
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("npc2_alive") == 0)
        str4 += "died on day 2";
      if (GameDataController.gd.getObjectiveDetail("npc2_alive") == 1)
        str4 += "died in Sidereal";
      if (GameDataController.gd.getObjectiveDetail("npc2_alive") == 2)
        str3 = str4 + "died on day 3";
    }
    string str5 = string.Empty;
    if (GameDataController.gd.getObjective("npc1_alive"))
      str5 = "alive";
    else
      str5 = "died on day 4";
  }

  private void continueGame(string param)
  {
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("MoonIntro0", WalkController.Direction.E);
  }

  private void Update()
  {
  }
}
