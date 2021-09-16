// Decompiled with JetBrains decompiler
// Type: LocationDream4Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationDream4Start : MonoBehaviour
{
  private SpriteRenderer plane0bla;
  private SpriteRenderer plane01;
  private SpriteRenderer window;
  private SpriteRenderer hot;
  private SpriteRenderer cold;
  public SpriteRenderer door;
  private float alpha;
  private float alpha1;
  private float alpha2;
  public SpriteRenderer moon1;
  public SpriteRenderer moon2;
  public SpriteRenderer moon3;
  public SpriteRenderer meteor1;
  public SpriteRenderer meteor2;
  private float animationProgress0 = -1f;
  private float animationProgress;
  private float animationProgress2;
  private float animationProgress3;

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
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.moon, 0.5f);
    GameDataController.gd.traveledTime = 0;
    GameDataController.gd.workedTime = 0;
    this.alpha = 0.0f;
    this.alpha1 = 2f;
    this.alpha2 = 0.0f;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED / 2f;
    PlayerController.wc.GetComponent<Animator>().speed = 0.75f;
    if (!GameDataController.gd.getObjective("dream_day_4_started"))
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
    }
    this.animationProgress0 = -1f;
  }

  private void walkThere1() => this.Invoke("walkThere", 0.25f);

  private void walkThere()
  {
    PlayerController.wc.currentXY.x = 150f;
    PlayerController.wc.currentXY.y = 25f;
    Vector2 newTarget = new Vector2(98f, 25f);
    PlayerController.wc.setSimpleTarget(newTarget);
    PlayerController.wc.forceAnimation("walk_e", true);
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

  private void unlockThings2() => GameObject.Find("FirstEncounter").GetComponent<FirstEncounterHouse>().updateAll();

  public void fallMoon()
  {
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.moon, 1.5f);
    PlayerController.wc.currentXY.x = -999f;
    PlayerController.wc.currentXY.y = -999f;
    PlayerController.wc.fullStop();
    this.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.low_rumble2);
    GameObject.Find("SoundsManager").GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.chorus2);
    this.animationProgress0 = 0.0f;
    this.Invoke("rumble", 3f);
    this.Invoke("nextscene", 10f);
  }

  public void rumble() => this.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.low_rumble);

  public void nextscene()
  {
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
    {
      PlayerController.pc.spawnName = "WakeUp";
      CurtainController.cc.fadeOut("LocationBaseUpstairs", WalkController.Direction.S, "stand_up", flipX: true, tSpeed: 0.2f);
    }
    else
    {
      GameDataController.gd.setObjective("location01_door2_locked", false);
      GameDataController.gd.setObjective("location01_door2_open", true);
      if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 1)
      {
        GameDataController.gd.setObjectiveDetail("towel_1_at_door", 0);
        Item obj = ItemsManager.im.getItem("towel_1");
        obj.dataRef.locX = 35;
        obj.dataRef.locY = 35;
        obj.dataRef.droppedLocation = "Location1";
      }
      if (GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 1)
      {
        GameDataController.gd.setObjectiveDetail("towel_2_at_door", 0);
        Item obj = ItemsManager.im.getItem("towel_2");
        obj.dataRef.locX = 35;
        obj.dataRef.locY = 35;
        obj.dataRef.droppedLocation = "Location1";
      }
      PlayerController.pc.spawnName = "Day4_morning";
      CurtainController.cc.fadeOut("LocationBaseOutside1", WalkController.Direction.N);
    }
  }

  private void Update()
  {
    if ((double) PlayerController.wc.currentXY.x <= 100.0 && !GameDataController.gd.getObjective("dream_day_4_started"))
    {
      GameDataController.gd.setObjective("dream_day_4_started", true);
      this.unlock();
    }
    this.window.color = new Color(1f, 1f, 1f, this.alpha);
    this.plane01.color = new Color(1f, 1f, 1f, this.alpha);
    float a = this.alpha1;
    if ((double) a > 1.0)
      a = 1f;
    this.plane0bla.color = new Color(0.0f, 0.0f, 0.0f, a);
    this.door.color = new Color(1f, 1f, 1f, this.alpha);
    if ((double) this.alpha1 <= 0.0 && (double) this.alpha < 1.0)
      this.alpha += 0.27f * Time.deltaTime;
    if ((double) this.alpha1 > 0.0)
      this.alpha1 -= 0.8f * Time.deltaTime;
    this.moon1.transform.position = new Vector3(0.0f, (float) (0.542999982833862 + -0.100999981164932 * (double) this.animationProgress2), this.moon1.transform.position.z);
    this.moon2.transform.position = new Vector3(0.0f, (float) (0.649999976158142 + -0.801999986171722 * (double) this.animationProgress), this.moon2.transform.position.z);
    this.moon3.transform.position = new Vector3(0.0f, (float) (1.09599995613098 + -1.94999992847443 * (double) this.animationProgress), this.moon3.transform.position.z);
    this.meteor1.transform.position = new Vector3((float) (0.773000001907349 * (double) this.animationProgress3 * 1.5), (float) (1.19000005722046 + -2.08400011062622 * (double) this.animationProgress3 * 1.5), this.meteor1.transform.position.z);
    this.meteor2.transform.position = new Vector3((float) (0.737999975681305 + -1.52600002288818 * (double) this.animationProgress3 * 2.0), (float) (1.45500004291534 + -2.47300004959106 * (double) this.animationProgress3 * 2.0), this.meteor2.transform.position.z);
    this.moon1.transform.position = ScreenControler.roundToNearestFullPixel3(this.moon1.transform.position);
    this.moon2.transform.position = ScreenControler.roundToNearestFullPixel3(this.moon2.transform.position);
    this.moon3.transform.position = ScreenControler.roundToNearestFullPixel3(this.moon3.transform.position);
    this.meteor1.transform.position = ScreenControler.roundToNearestFullPixel3(this.meteor1.transform.position);
    this.meteor2.transform.position = ScreenControler.roundToNearestFullPixel3(this.meteor2.transform.position);
    if ((double) this.animationProgress0 < 0.0)
    {
      this.moon1.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      this.moon2.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      this.moon3.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      this.meteor1.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      this.meteor2.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }
    else
    {
      this.moon1.color = new Color(this.animationProgress0, this.animationProgress0, this.animationProgress0, 1f);
      this.moon2.color = new Color(this.animationProgress0, this.animationProgress0, this.animationProgress0, 1f);
      this.moon3.color = new Color(this.animationProgress0, this.animationProgress0, this.animationProgress0, 1f);
      this.meteor1.color = new Color(1f, 1f, 1f, 1f);
      this.meteor2.color = new Color(1f, 1f, 1f, 1f);
      this.animationProgress0 += Time.deltaTime * 0.5f;
      if ((double) this.animationProgress0 > 1.0)
        this.animationProgress0 = 1f;
      this.animationProgress += Time.deltaTime / 10f;
      if ((double) this.animationProgress >= 1.0)
        this.animationProgress = 1f;
      this.animationProgress3 += Time.deltaTime / 5f;
      this.animationProgress2 += Time.deltaTime / 5f;
      if ((double) this.animationProgress2 >= 1.0)
        this.animationProgress2 = 1f;
      if ((double) this.animationProgress3 < 1.0)
        return;
      this.animationProgress3 = 0.0f;
    }
  }
}
