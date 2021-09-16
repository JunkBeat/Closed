// Decompiled with JetBrains decompiler
// Type: LocationDay2WinStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationDay2WinStart : MonoBehaviour
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
    GameDataController.Achievement("DAY_2");
    string empty = string.Empty;
    string str1;
    if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
    {
      str1 = "npc2";
      GameObject.Find("plane01").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("plane02").GetComponent<SpriteRenderer>().enabled = true;
    }
    else
    {
      str1 = "npc3";
      GameObject.Find("plane02").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("plane01").GetComponent<SpriteRenderer>().enabled = true;
    }
    if (GameDataController.gd.getObjective("rv_started"))
    {
      GameDataController.gd.setObjective("rv_started", false);
      GameDataController.gd.setObjective("rv_fueled", false);
    }
    if (GameDataController.gd.getObjective("barn_pump_started"))
    {
      GameDataController.gd.setObjective("barn_pump_fueled", false);
      GameDataController.gd.setObjective("barn_pump_started", false);
    }
    if (InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("heat_absorber1A"))
      InventoryController.ic.removeItem("heat_absorber1A");
    if (InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("heat_absorber2A"))
      InventoryController.ic.removeItem("heat_absorber2A");
    if (InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("heat_absorber3A"))
      InventoryController.ic.removeItem("heat_absorber3A");
    ItemsManager.im.getItem("heat_absorber1A").dataRef.droppedLocation = "nowhere";
    ItemsManager.im.getItem("heat_absorber2A").dataRef.droppedLocation = "nowhere";
    ItemsManager.im.getItem("heat_absorber3A").dataRef.droppedLocation = "nowhere";
    if (GameDataController.gd.getObjective("base_fireplace_lit"))
    {
      GameDataController.gd.setObjective("base_fireplace_lit", false);
      GameDataController.gd.setObjective("chimney_wood", false);
      GameDataController.gd.setObjectiveDetail("chimney_wood", 0);
      GameDataController.gd.setObjective("chimney_note", false);
      GameDataController.gd.setObjective("chimney_papers", false);
      GameDataController.gd.setObjective("chimney_cash", false);
      GameDataController.gd.setObjective("chimney_charcoal", false);
      GameDataController.gd.setObjective("chimney_bag", false);
      GameDataController.gd.setObjective("basket_wood", false);
      GameDataController.gd.setObjectiveDetail("basket_wood", 0);
      GameDataController.gd.setObjective("basket_note", false);
      GameDataController.gd.setObjective("basket_papers", false);
      GameDataController.gd.setObjective("basket_cash", false);
      GameDataController.gd.setObjective("basket_charcoal", false);
      GameDataController.gd.setObjective("basket_bag", false);
    }
    if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0 && GameDataController.gd.equipped.IndexOf("water") != -1)
    {
      ItemsManager.im.getItem(GameDataController.gd.equipped).dataRef.droppedLocation = "nowhere";
      InventoryController.ic.removeItem(GameDataController.gd.equipped);
    }
    if (ItemsManager.im.getItem("gasheater").dataRef.droppedLocation.ToLower().IndexOf("nowhere") == -1 && ItemsManager.im.getItem("gasheater").dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1)
    {
      ItemsManager.im.getItem("gasheater_empty").dataRef.droppedLocation = ItemsManager.im.getItem("gasheater").dataRef.droppedLocation;
      ItemsManager.im.getItem("gasheater_empty").dataRef.locX = ItemsManager.im.getItem("gasheater").dataRef.locX;
      ItemsManager.im.getItem("gasheater_empty").dataRef.locY = ItemsManager.im.getItem("gasheater").dataRef.locY;
      ItemsManager.im.getItem("gasheater").dataRef.droppedLocation = "nowhere";
    }
    GameDataController.gd.gameTime = 480;
    bool flag = false;
    if (str1 == "npc2" && GameDataController.gd.getObjective("npc2_joined"))
      flag = true;
    if (str1 == "npc3" && GameDataController.gd.getObjective("npc3_joined"))
      flag = true;
    TimelineAction action1 = new TimelineAction(Timeline.t.textField);
    if (GameDataController.gd.getObjectiveDetail("day2_complete") == 1)
    {
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
      {
        GameDataController.Achievement("P_HEAT");
        action1.text = GameStrings.getString(GameStrings.results, "day2_heat_perfect");
        Timeline.t.addAction(action1);
      }
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
      {
        GameDataController.Achievement("P_COLD");
        action1.text = GameStrings.getString(GameStrings.results, "day2_cold_perfect");
        Timeline.t.addAction(action1);
      }
      TimelineAction action2 = new TimelineAction(Timeline.t.textField);
      action2.function = new TimelineFunction(this.continueGame);
      action2.actionWithText = false;
      action2.param = "0";
      Timeline.t.textField.directionY = 1f;
      action2.textWidth = 190;
      Timeline.t.textField.shift.x = -80f;
      action2.text = GameStrings.getString(GameStrings.results, "day2_bonus");
      Timeline.t.addAction(action2);
    }
    else if (GameDataController.gd.getObjectiveDetail("day2_complete") == 0)
    {
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
      {
        action1.text = GameStrings.getString(GameStrings.results, "day2_heat_good");
        Timeline.t.addAction(action1);
      }
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
      {
        action1.text = GameStrings.getString(GameStrings.results, "day2_cold_good");
        Timeline.t.addAction(action1);
      }
      TimelineAction action3 = new TimelineAction(Timeline.t.textField);
      action3.function = new TimelineFunction(this.continueGame);
      action3.actionWithText = false;
      action3.param = "0";
      Timeline.t.textField.directionY = 1f;
      action3.textWidth = 190;
      Timeline.t.textField.shift.x = -80f;
      action3.text = GameStrings.getString(GameStrings.results, "day2_normal");
      Timeline.t.addAction(action3);
    }
    else if (GameDataController.gd.getObjectiveDetail("day2_complete") < 0)
    {
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
      {
        action1.text = GameStrings.getString(GameStrings.results, "day2_heat_poor");
        Timeline.t.addAction(action1);
      }
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
      {
        action1.text = GameStrings.getString(GameStrings.results, "day2_cold_poor");
        Timeline.t.addAction(action1);
      }
      GameDataController.gd.gameTime = 540;
      TimelineAction action4 = new TimelineAction(Timeline.t.textField);
      action4.function = new TimelineFunction(this.continueGame);
      action4.actionWithText = false;
      action4.param = "0";
      Timeline.t.textField.directionY = 1f;
      action4.textWidth = 190;
      Timeline.t.textField.shift.x = -80f;
      action4.text = GameStrings.getString(GameStrings.results, "day2_penalty");
      Timeline.t.addAction(action4);
    }
    if (!GameDataController.gd.getObjective("npc2_joined"))
    {
      GameDataController.gd.setObjective("npc2_alive", false);
      GameDataController.gd.setObjectiveDetail("npc2_alive", 0);
    }
    if (!GameDataController.gd.getObjective("npc2_joined") && !GameDataController.gd.getObjective("house_b_garage_open"))
    {
      GameDataController.gd.setObjective("npc2_alive", false);
      GameDataController.gd.setObjectiveDetail("npc2_alive", 0);
      ItemsManager.im.getItem("key4").dataRef.droppedLocation = "LocationHouseB";
      ItemsManager.im.getItem("key4").dataRef.locX = 215;
      ItemsManager.im.getItem("key4").dataRef.locY = 10;
    }
    if (!GameDataController.gd.getObjective("npc3_joined"))
    {
      GameDataController.gd.setObjective("npc3_alive", false);
      GameDataController.gd.setObjectiveDetail("npc3_alive", 0);
    }
    string str2 = string.Empty;
    string str3 = !GameDataController.gd.getObjective("npc3_joined") ? "not joined/" : "joined/";
    if (GameDataController.gd.getObjective("npc3_alive"))
    {
      str2 = str3 + "alive";
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("npc3_alive") == 0)
        str3 += "died on day 2";
      if (GameDataController.gd.getObjectiveDetail("npc3_alive") == 1)
        str3 += "died in Sidereal";
      if (GameDataController.gd.getObjectiveDetail("npc3_alive") == 2)
        str2 = str3 + "died on day 3";
    }
    string str4 = string.Empty;
    string str5 = !GameDataController.gd.getObjective("npc2_joined") ? "not joined/" : "joined/";
    if (GameDataController.gd.getObjective("npc2_alive"))
    {
      str4 = str5 + "alive";
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("npc2_alive") == 0)
        str5 += "died on day 2";
      if (GameDataController.gd.getObjectiveDetail("npc2_alive") == 1)
        str5 += "died in Sidereal";
      if (GameDataController.gd.getObjectiveDetail("npc2_alive") == 2)
        str4 = str5 + "died on day 3";
    }
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_success);
  }

  private void continueGame(string param)
  {
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("Dream3", WalkController.Direction.E);
  }

  private void Update()
  {
  }
}
