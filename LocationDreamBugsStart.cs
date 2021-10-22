// Decompiled with JetBrains decompiler
// Type: LocationDreamBugsStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationDreamBugsStart : MonoBehaviour
{
  private SpriteRenderer plane0bla;
  private SpriteRenderer plane01;
  private SpriteRenderer window;
  private float alpha;
  private float alpha1;

  private void Start()
  {
    this.plane0bla = GameObject.Find("plane0bla").GetComponent<SpriteRenderer>();
    this.window = GameObject.Find("Window").GetComponent<SpriteRenderer>();
    this.plane01 = GameObject.Find("plane01").GetComponent<SpriteRenderer>();
    this.plane01.color = new Color(1f, 1f, 1f, 0.0f);
    this.alpha = 0.0f;
    this.alpha1 = 2f;
    GameDataController.gd.autoSave();
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
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED / 2f;
    PlayerController.wc.GetComponent<Animator>().speed = 0.75f;
    GameObject.Find("bugs_feast_1").GetComponent<SpriteRenderer>().enabled = false;
    if (!GameDataController.gd.getObjective("dream_day_1_started"))
    {
      PlayerController.wc.currentXY.x = 280f;
      PlayerController.wc.currentXY.y = 20f;
      this.walkThere1();
    }
    else
    {
      this.alpha = 1f;
      this.alpha1 = 0.0f;
    }
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 0.5f);
  }

  private void walkThere1() => this.Invoke("walkThere", 0.25f);

  private void walkThere()
  {
    PlayerController.wc.currentXY.x = 290f;
    PlayerController.wc.currentXY.y = 25f;
    Vector2 newTarget = new Vector2(120f, 25f);
    PlayerController.wc.setSimpleTarget(newTarget);
    PlayerController.wc.forceAnimation("walk_e", true);
  }

  private void unlock()
  {
    MonoBehaviour.print((object) "UNLOCK");
    GameObject.Find("Window").GetComponent<DreamWindow>().updateAll();
    PlayerController.wc.fullStop();
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED * 0.75f;
    PlayerController.wc.GetComponent<Animator>().speed = 0.75f;
    PlayerController.pc.setBusy(false);
    PlayerController.wc.forceAnimation("action_stnd_e", true);
    PlayerController.wc.forceDirection(WalkController.Direction.W);
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = string.Empty,
      blockG = false,
      function = new TimelineFunction(this.sayDots),
      actionWithText = true,
      textWidth = 170
    });
    Timeline.t.addAction(new TimelineAction(GameObject.Find("BottomText").GetComponent<TextFieldController>())
    {
      text = "[" + GameStrings.getString(GameStrings.gui, "controls_hint") + "]",
      blockG = true,
      function = new TimelineFunction(this.unlockThings),
      textWidth = 220
    });
    TimelineAction action = new TimelineAction(GameObject.Find("UpperText").GetComponent<TextFieldController>());
    action.text = "[" + GameStrings.getString(GameStrings.gui, "tutorial_gears") + "]";
    GameObject.Find("UpperText").GetComponent<TextFieldController>().OPTIONAL_MARGIN = 20;
    action.textWidth = 100;
    action.blockG = false;
    Timeline.t.addAction(action);
  }

  private void sayDots(string p = "")
  {
    PlayerController.pc.textField.viewText("...");
    PlayerController.pc.textField.setTime(3f);
  }

  private void unlockThings(string param)
  {
    GameObject.Find("gears").GetComponent<GearsController>().showGears(false);
    PlayerController.wc.forceAnimation("stand_se", true);
    PlayerController.wc.forceDirection(WalkController.Direction.SW);
    this.Invoke("unlockThings2", 0.25f);
  }

  private void unlockThings2()
  {
    GameDataController.gd.setObjective("dream_day_1_started", true);
    GameObject.Find("FirstEncounter").GetComponent<FirstEncounterHouse>().updateAll();
  }

  private void Update()
  {
    if ((double) PlayerController.wc.currentXY.x <= 120.0 && !GameDataController.gd.getObjective("dream_day_1_started"))
    {
      GameDataController.gd.setObjective("dream_day_1_started", true);
      this.unlock();
    }
    this.window.color = new Color(1f, 1f, 1f, this.alpha);
    this.plane01.color = new Color(1f, 1f, 1f, this.alpha);
    float a = this.alpha1;
    if ((double) a > 1.0)
      a = 1f;
    this.plane0bla.color = new Color(0.0f, 0.0f, 0.0f, a);
    if ((double) this.alpha1 <= 0.0 && (double) this.alpha < 1.0)
      this.alpha += 0.07f * Time.deltaTime;
    if ((double) this.alpha1 <= 0.0)
      return;
    this.alpha1 -= 0.4f * Time.deltaTime;
  }
}
