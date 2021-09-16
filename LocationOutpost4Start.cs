// Decompiled with JetBrains decompiler
// Type: LocationOutpost4Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationOutpost4Start : MonoBehaviour
{
  public SpriteRenderer light1;
  public SpriteRenderer light2;
  public SpriteRenderer light3;
  public bool lights_bool;
  public int lights_int;
  public GameObject npc1_target;
  public GameObject npc2_target;
  public GameObject npc3_target;
  public bool gingerShowFinger;
  public NPCWalkController ginger;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 3f / 500f;
    PlayerController.wc.shadowOffsetY = -2;
    PlayerController.wc.shadow.skewFactor = 70f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    this.gingerShowFinger = false;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.source = 160f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.NORMAL, AudioReverbPreset.Hallway);
    PlayerController.wc.shadow.scaleFactor = 0.25f;
    PlayerController.wc.shadow.downwards = true;
    GameDataController.gd.setObjective("outpost_spaceship_discovered", true);
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    if (PlayerController.pc.spawnName != "Waypoint_Outpost4_3" && PlayerController.pc.spawnName != "previous")
      GameObject.Find("Waypoint_Outpost4_3").GetComponent<Waypoint_Outpost4_3>().closeDoorQuickAndFast();
    if (GameDataController.gd.getObjective("outpost_elevator_open"))
      GameObject.Find("Waypoint_Outpost4_3").GetComponent<Waypoint_Outpost4_3>().closeDoorInFive();
    GameDataController.gd.setObjective("visited_outpost4", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_6a);
    if (GameDataController.gd.getObjective("outpost_elevator_open"))
    {
      GameObject.Find("Location").GetComponent<PolygonCollider2D>().enabled = true;
      GameObject.Find("ClosedElevator").GetComponent<PolygonCollider2D>().enabled = false;
      GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
    }
    else
    {
      GameObject.Find("Location").GetComponent<PolygonCollider2D>().enabled = false;
      GameObject.Find("ClosedElevator").GetComponent<PolygonCollider2D>().enabled = true;
      GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
    }
    if (GameDataController.gd.getObjectiveDetail("outpost_underground_light") == 0)
    {
      this.light1.enabled = true;
      this.light2.enabled = false;
      this.light3.enabled = false;
      JukeboxAmbient.jb.changeAmbient((AudioClip) null, 1f);
    }
    if (GameDataController.gd.getObjectiveDetail("outpost_underground_light") == 1)
    {
      this.light1.enabled = false;
      this.light2.enabled = true;
      this.light3.enabled = false;
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.buzz, 0.15f);
    }
    if (GameDataController.gd.getObjectiveDetail("outpost_underground_light") == 2)
    {
      this.light1.enabled = false;
      this.light2.enabled = false;
      this.light3.enabled = true;
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.buzz, 0.3f);
    }
    this.lights_bool = GameDataController.gd.getObjective("outpost_underground_light");
    this.lights_int = GameDataController.gd.getObjectiveDetail("outpost_underground_light");
  }

  public void moveNpc2() => GameObject.Find("Npc2").GetComponent<NPCWalkController>().setSimpleTargetV3(this.npc2_target.transform.position);

  public void moveNpc3() => GameObject.Find("Npc3").GetComponent<NPCWalkController>().setSimpleTargetV3(this.npc3_target.transform.position);

  private void Update()
  {
    if (this.gingerShowFinger && (double) this.ginger.currentXY.y >= 30.0 && (double) this.ginger.currentXY.y <= 32.0 && (double) this.ginger.currentXY.x <= 68.0 && (double) this.ginger.currentXY.x >= 66.0)
    {
      this.gingerShowFinger = false;
      TextFieldController component1 = GameObject.Find("Ginger").GetComponent<TextFieldController>();
      TextFieldController component2 = GameObject.Find("diode").GetComponent<TextFieldController>();
      GameObject.Find("diode").GetComponent<Locationoutpost4FingerScanner>().scansound();
      TimelineAction timelineAction = new TimelineAction();
      Timeline.t.addAction(new TimelineAction()
      {
        textfield = component2,
        textColor = new Vector3(1f, 0.0f, 0.0f),
        backgroundColor = new Vector3(0.5f, 0.0f, 0.0f),
        text = GameStrings.getString(GameStrings.actions, "fingerprint_reader3"),
        actionWithText = true,
        function = new TimelineFunction(GameObject.Find("diode").GetComponent<Locationoutpost4FingerScanner>().failsound)
      });
      Timeline.t.addAction(new TimelineAction()
      {
        textfield = component1,
        backgroundColor = new Vector3(0.0f, 0.0f, 0.0f),
        textColor = GingerActionController.getColor(),
        text = GameStrings.getString(GameStrings.actions, "fingerprint_reader_cate"),
        actionWithText = true,
        function = new TimelineFunction(this.gingerGoAway)
      });
    }
    PlayerController.wc.shadow.source = (double) PlayerController.wc.currentXY.x <= 100.0 ? 40f : 160f;
    PlayerController.pc.allowDrop = (double) PlayerController.wc.currentXY.x <= 190.0;
    PlayerController.wc.shadow.scaleFactor = (float) (0.100000001490116 + (double) Mathf.Abs(PlayerController.wc.currentXY.y - 25f) / 60.0);
    PlayerController.wc.shadow.downwards = (double) PlayerController.wc.currentXY.y <= 25.0;
    if (this.lights_int == 0)
    {
      if ((double) PlayerController.wc.currentXY.x >= 200.0)
        return;
      GameDataController.gd.setObjectiveDetail("outpost_underground_light", 1);
      this.lights_int = 1;
      this.light1.enabled = false;
      this.light2.enabled = true;
      this.light3.enabled = false;
      this.lights_bool = true;
      GameDataController.gd.setObjective("outpost_underground_light", true);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.lamp_on);
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.buzz, 0.15f);
      GameObject.Find("diode").GetComponent<Locationoutpost4FingerScanner>().updateAll();
      GameObject.Find("Ginger").GetComponent<NPCWalkController>().setSimpleTargetV3(this.npc1_target.transform.position);
      if (GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjective("npc2_joined"))
        this.Invoke("moveNpc2", 0.5f);
      if (!GameDataController.gd.getObjective("npc3_alive") || !GameDataController.gd.getObjective("npc3_joined"))
        return;
      this.Invoke("moveNpc3", 1f);
    }
    else
    {
      if (this.lights_int != 1 || (double) PlayerController.wc.currentXY.x >= 100.0)
        return;
      GameDataController.gd.setObjectiveDetail("outpost_underground_light", 2);
      this.lights_int = 2;
      GameObject.Find("diode").GetComponent<Locationoutpost4FingerScanner>().updateAll();
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.neon_on);
      this.light1.enabled = false;
      this.light2.enabled = false;
      this.light3.enabled = true;
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.buzz, 0.3f);
    }
  }

  public void gingerGoAway(string val = "") => this.ginger.setSimpleTarget(new Vector2(80f, 30f));
}
