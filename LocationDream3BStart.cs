// Decompiled with JetBrains decompiler
// Type: LocationDream3BStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationDream3BStart : MonoBehaviour
{
  private SpriteRenderer plane0bla;
  private SpriteRenderer plane01;
  public SpriteRenderer plane01bed;
  private SpriteRenderer dream_stairs_front;
  private float alpha;
  private float alpha1;
  private float alpha2;
  public ObjectZController zc1;
  public ObjectZController zc2;

  private void Start() => this.reset();

  public void reset()
  {
    this.plane0bla = GameObject.Find("plane0bla").GetComponent<SpriteRenderer>();
    this.plane01 = GameObject.Find("plane01").GetComponent<SpriteRenderer>();
    this.dream_stairs_front = GameObject.Find("dream_stairs_front").GetComponent<SpriteRenderer>();
    this.dream_stairs_front.color = new Color(1f, 1f, 1f, 0.0f);
    this.plane01.color = new Color(1f, 1f, 1f, 0.0f);
    this.alpha = 0.0f;
    this.alpha1 = 2f;
    this.alpha2 = 0.0f;
    this.zc1.enabled = true;
    this.zc2.enabled = false;
    PlayerController.wc.shadow.fadeRateV = 1f / 500f;
    PlayerController.wc.shadow.fadeRateH = 1f / 500f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 25f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.source = 180f;
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.ssg.setStepType2("wood", AudioReverbPreset.Psychotic);
    PlayerController.pc.copySettingsToNPCs();
    MonoBehaviour.print((object) "............................. LOCATION INFO  ..................................");
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(-999f, -999f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    InventoryButtonController.ibc.gameObject.transform.position = worldPoint;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED / 4f;
    PlayerController.wc.GetComponent<Animator>().speed = 0.5f;
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.underground_1, 1f);
    if (!GameDataController.gd.getObjective("dream_day_3b_started"))
    {
      PlayerController.wc.currentXY.x = 90f;
      PlayerController.wc.currentXY.y = 0.0f;
      this.walkThere1();
    }
    else
    {
      this.zc1.enabled = false;
      this.zc2.enabled = true;
      this.alpha = 1f;
      this.alpha1 = 0.0f;
      this.alpha2 = 1f;
    }
    GameDataController.gd.setObjective("dream_tiger_future", false);
    GameDataController.gd.setObjective("dream_maggie_future", false);
    GameObject.Find("DreamStairs").GetComponent<DreamStairsUpper>().setCollider(-1);
    GameObject.Find("tiger").GetComponent<DreamTiger>().setCollider(-1);
  }

  private void walkThere1() => this.Invoke("walkThere", 0.25f);

  private void walkThere()
  {
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED / 4f;
    PlayerController.wc.GetComponent<Animator>().speed = 0.5f;
    Vector2 newTarget = new Vector2(150f, 40f);
    PlayerController.wc.setSimpleTarget(newTarget);
    PlayerController.wc.forceAnimation("walk_e");
  }

  private void unlock()
  {
    MonoBehaviour.print((object) "UNLOCK");
    this.zc1.enabled = false;
    this.zc2.enabled = true;
    PlayerController.wc.fullStop();
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED * 0.75f;
    PlayerController.wc.GetComponent<Animator>().speed = 0.75f;
    PlayerController.pc.setBusy(false);
    PlayerController.wc.forceAnimation("action_stnd_e");
    PlayerController.wc.forceDirection(WalkController.Direction.SW);
    this.unlockThings(string.Empty);
  }

  private void unlockThings(string param)
  {
    PlayerController.wc.forceAnimation("look_around", true);
    this.Invoke("unlockThings2", 0.25f);
  }

  private void unlockThings2() => GameObject.Find("DreamStairs").GetComponent<DreamStairsUpper>().updateAll();

  private void Update()
  {
    if (GameDataController.gd.getObjective("dream_tiger_future") || GameDataController.gd.getObjective("dream_maggie_future") || CurtainController.cc.targetLocaiton == "Dream3")
      return;
    if ((double) PlayerController.wc.currentXY.x >= 135.0 && !GameDataController.gd.getObjective("dream_day_3b_started"))
    {
      this.zc1.enabled = false;
      this.zc2.enabled = true;
    }
    if ((double) PlayerController.wc.currentXY.x >= 140.0 && !GameDataController.gd.getObjective("dream_day_3b_started"))
    {
      GameDataController.gd.setObjective("dream_day_3b_started", true);
      this.unlock();
    }
    this.plane01bed.color = new Color(1f, 1f, 1f, this.alpha);
    this.plane01.color = new Color(1f, 1f, 1f, this.alpha);
    this.dream_stairs_front.color = new Color(this.alpha, this.alpha, this.alpha, 1f);
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
