// Decompiled with JetBrains decompiler
// Type: Crashsite1Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Crashsite1Start : MonoBehaviour
{
  public SpriteRenderer tloD1;
  public SpriteRenderer tloD2;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = -7f;
    PlayerController.wc.shadow.startAlpha = 0.25f;
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 160f;
    PlayerController.ssg.setStepType("road");
    GameDataController.gd.setObjective("visited_crashsite1", true);
    GameDataController.gd.setObjective("bridge_westside", false);
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_1a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 1f);
    if (!GameDataController.gd.getObjective("crashsite_discovered_bugs"))
    {
      GameDataController.gd.setObjective("crashsite_discovered_bugs", true);
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      {
        Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
        {
          text = GameStrings.getString(GameStrings.actions, "crashsite_discover_bugs1")
        });
        Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
        {
          text = GameStrings.getString(GameStrings.actions, "crashsite_discover_bugs2")
        });
        Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
        {
          text = GameStrings.getString(GameStrings.actions, "crashsite_discover_bugs3")
        });
      }
      else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
      {
        Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
        {
          text = GameStrings.getString(GameStrings.actions, "crashsite_discover_gas1")
        });
        Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
        {
          text = GameStrings.getString(GameStrings.actions, "crashsite_discover_gas2")
        });
        Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
        {
          text = GameStrings.getString(GameStrings.actions, "crashsite_discover_gas3")
        });
      }
      else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
      {
        Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
        {
          text = GameStrings.getString(GameStrings.actions, "crashsite_discover_spiders1")
        });
        Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
        {
          text = GameStrings.getString(GameStrings.actions, "crashsite_discover_spiders2")
        });
        Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
        {
          text = GameStrings.getString(GameStrings.actions, "crashsite_discover_spiders3")
        });
      }
    }
    if (GameDataController.gd.getCurrentDay() > 1)
    {
      this.tloD1.enabled = false;
      this.tloD2.enabled = true;
      GameObject.Find("ExpandedPath").GetComponent<PolygonCollider2D>().enabled = true;
      GameObject.Find("ExpandedPath2").GetComponent<PolygonCollider2D>().enabled = true;
      GameObject.Find("RVWaypoint").GetComponent<RVWaypoint>().setCollider(0);
    }
    else
    {
      this.tloD1.enabled = true;
      this.tloD2.enabled = false;
      GameObject.Find("ExpandedPath").GetComponent<PolygonCollider2D>().enabled = false;
      GameObject.Find("ExpandedPath2").GetComponent<PolygonCollider2D>().enabled = false;
      GameObject.Find("RVWaypoint").GetComponent<RVWaypoint>().setCollider(-1);
    }
    GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
  }

  private void Update()
  {
  }
}
