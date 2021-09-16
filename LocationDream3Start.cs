// Decompiled with JetBrains decompiler
// Type: LocationDream3Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationDream3Start : MonoBehaviour
{
  private SpriteRenderer plane0bla;
  private SpriteRenderer plane01;
  private SpriteRenderer window;
  private SpriteRenderer hot;
  private SpriteRenderer cold;
  public SpriteRenderer stairs;
  private float alpha;
  private float alpha1;
  private float alpha2;

  private void Start()
  {
    this.plane0bla = GameObject.Find("plane0bla").GetComponent<SpriteRenderer>();
    this.window = GameObject.Find("Window").GetComponent<SpriteRenderer>();
    this.plane01 = GameObject.Find("plane01").GetComponent<SpriteRenderer>();
    this.plane01.color = new Color(1f, 1f, 1f, 0.0f);
    this.alpha = 0.0f;
    this.alpha1 = 2f;
    this.alpha2 = 0.0f;
    PlayerController.wc.shadow.fadeRateV = 1f / 500f;
    PlayerController.wc.shadow.fadeRateH = 1f / 500f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 30f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 60f;
    PlayerController.ssg.setStepType2("wood", AudioReverbPreset.Psychotic);
    PlayerController.pc.copySettingsToNPCs();
    MonoBehaviour.print((object) "............................. LOCATION INFO  ..................................");
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(-999f, -999f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    InventoryButtonController.ibc.gameObject.transform.position = worldPoint;
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 0.5f);
    GameDataController.gd.traveledTime = 0;
    GameDataController.gd.workedTime = 0;
    GameObject.Find("StairEmmiter").GetComponent<ParticleGenerator>().started = false;
    if (GameDataController.gd.getCurrentDay() == 3 && !GameDataController.gd.getObjective("dream_day_3_started"))
    {
      PlayerController.wc.currentXY.x = 180f;
      PlayerController.wc.currentXY.y = 20f;
      this.walkThere1();
    }
    else
    {
      this.alpha = 1f;
      this.alpha1 = 0.0f;
      this.alpha2 = 1f;
      PlayerController.wc.speed = PlayerController.wc.MAX_SPEED / 2f;
      PlayerController.wc.GetComponent<Animator>().speed = 0.75f;
      if (!GameDataController.gd.getObjective("previous_disc_barry") && !GameDataController.gd.getObjective("previous_disc_cody") || !GameDataController.gd.getObjective("npc3_alive") || !GameDataController.gd.getObjective("npc2_alive") || !GameDataController.gd.getObjective("npc3_joined") || !GameDataController.gd.getObjective("npc2_joined"))
        return;
      GameObject.Find("StairEmmiter").GetComponent<ParticleGenerator>().started = true;
    }
  }

  private void walkThere1() => this.Invoke("walkThere", 0.25f);

  private void walkThere()
  {
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED / 2f;
    PlayerController.wc.GetComponent<Animator>().speed = 0.75f;
    PlayerController.wc.currentXY.x = 150f;
    PlayerController.wc.currentXY.y = 25f;
    Vector2 newTarget = new Vector2(98f, 25f);
    PlayerController.wc.setSimpleTarget(newTarget);
    PlayerController.wc.forceAnimation("walk_e", true);
    if (!GameDataController.gd.getObjective("previous_disc_barry") && !GameDataController.gd.getObjective("previous_disc_cody") || !GameDataController.gd.getObjective("npc3_alive") || !GameDataController.gd.getObjective("npc2_alive") || !GameDataController.gd.getObjective("npc3_joined") || !GameDataController.gd.getObjective("npc2_joined"))
      return;
    GameObject.Find("StairEmmiter").GetComponent<ParticleGenerator>().started = true;
  }

  private void unlock()
  {
    MonoBehaviour.print((object) "UNLOCK");
    GameObject.Find("Window").GetComponent<DreamWindow>().updateAll();
    GameObject.Find("gears").GetComponent<GearsController>().showGears();
    PlayerController.wc.fullStop();
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED * 0.75f;
    PlayerController.wc.GetComponent<Animator>().speed = 0.75f;
    PlayerController.pc.setBusy(false);
    PlayerController.wc.forceAnimation("action_stnd_e", true);
    PlayerController.wc.forceDirection(WalkController.Direction.SW);
    this.unlockThings(string.Empty);
  }

  private void unlockThings(string param)
  {
    PlayerController.wc.forceAnimation("look_around", true);
    this.Invoke("unlockThings2", 0.25f);
  }

  private void unlockThings3(string param) => GameObject.Find("FirstEncounter").GetComponent<FirstEncounterHouse>().updateAll();

  private void unlockThings2()
  {
    if ((GameDataController.gd.getObjective("previous_disc_barry") || GameDataController.gd.getObjective("previous_disc_cody")) && GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc2_joined"))
    {
      PlayerController.wc.forceAnimation("stand_ne");
      Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
      {
        function = new TimelineFunction(this.unlockThings3),
        actionWithText = false,
        text = GameStrings.getString(GameStrings.actions, "day3_dream_stairs")
      });
    }
    else
      GameObject.Find("FirstEncounter").GetComponent<FirstEncounterHouse>().updateAll();
  }

  private void Update()
  {
    if ((double) PlayerController.wc.currentXY.x <= 100.0 && !GameDataController.gd.getObjective("dream_day_3_started"))
    {
      GameDataController.gd.setObjective("dream_day_3_started", true);
      this.unlock();
    }
    this.window.color = new Color(1f, 1f, 1f, this.alpha);
    this.plane01.color = new Color(1f, 1f, 1f, this.alpha);
    this.stairs.color = new Color(1f, 1f, 1f, this.alpha);
    float a = this.alpha1;
    if ((double) a > 1.0)
      a = 1f;
    this.plane0bla.color = new Color(0.0f, 0.0f, 0.0f, a);
    if ((double) this.alpha1 <= 0.0 && (double) this.alpha < 1.0)
      this.alpha += 0.27f * Time.deltaTime;
    if ((double) this.alpha1 <= 0.0)
      return;
    this.alpha1 -= 0.8f * Time.deltaTime;
  }
}
