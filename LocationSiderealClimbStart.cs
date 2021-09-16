// Decompiled with JetBrains decompiler
// Type: LocationSiderealClimbStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationSiderealClimbStart : MonoBehaviour
{
  public GameObject tlo1;
  public GameObject tlo2;
  public GameObject tlo3;
  public GameObject tlo4;
  public SpriteRenderer moong;
  public int shift = 55;
  public NPCWalkController npc1;
  public NPCWalkController npc2;
  public NPCWalkController npc3;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 2;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.0f;
    PlayerController.wc.shadow.scaleFactor = 0.4f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED * 0.5f;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 240f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.DIRT, AudioReverbPreset.Off);
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_3, 1f);
    PlayerController.pc.allowDrop = false;
    InventoryButtonController.ibc.hide();
    GameObject.Find("journal").GetComponent<JournalButtonController>().hide();
    PlayerController.pc.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f);
    this.npc1.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f);
    this.npc2.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f);
    this.npc3.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f);
    this.npc1.currentXY = PlayerController.wc.currentXY;
    this.npc2.currentXY = PlayerController.wc.currentXY;
    this.npc3.currentXY = PlayerController.wc.currentXY;
    if (GameDataController.gd.gameTime < 510 || GameDataController.gd.gameTime >= 1050)
      this.moong.enabled = true;
    else
      this.moong.enabled = false;
    this.npc1.pathRestricted = false;
    this.npc2.pathRestricted = false;
    this.npc3.pathRestricted = false;
    this.npc1.gameObject.GetComponent<NPCActionController>().setCollider(-1);
    this.npc2.gameObject.GetComponent<NPCActionController>().setCollider(-1);
    this.npc3.gameObject.GetComponent<NPCActionController>().setCollider(-1);
    this.npc1.currentXY = PlayerController.wc.currentXY;
    this.npc2.currentXY = PlayerController.wc.currentXY;
    this.npc3.currentXY = PlayerController.wc.currentXY;
    this.npc1.setSimpleTarget(PlayerController.wc.currentXY);
    this.npc2.setSimpleTarget(PlayerController.wc.currentXY);
    this.npc3.setSimpleTarget(PlayerController.wc.currentXY);
  }

  private void suwsuw(NPCWalkController npc, int dist)
  {
    Vector2 currentXy = PlayerController.wc.currentXY;
    currentXy.x += (float) dist;
    currentXy.y += (float) dist * 0.55f;
    npc.currentXY = currentXy;
    npc.clearTarget();
    if ((double) PlayerController.wc.currentSpeed.x > 0.0)
      npc.forceAnimation("walk_e");
    else if ((double) PlayerController.wc.currentSpeed.x < 0.0)
      npc.forceAnimation("walk_e", true);
    else
      npc.forceAnimation("stand_se");
  }

  private void Update()
  {
    this.przesuw(this.tlo1, 0.2f, 0.0f);
    this.przesuw(this.tlo2, -0.04f, 7f);
    this.przesuw(this.tlo3, -0.03f, 7f);
    this.przesuw(this.tlo4, -0.02f, 7f);
    this.suwsuw(this.npc1, -20);
    this.suwsuw(this.npc2, -40);
    this.suwsuw(this.npc3, -60);
  }

  private bool nawig(NPCWalkController npc, GameObject nav)
  {
    if ((double) PlayerController.pc.gameObject.transform.position.x <= (double) nav.transform.position.x)
      return false;
    npc.setTargetV3(nav.transform.position);
    return true;
  }

  private void przesuw(GameObject go, float skala, float bonbon)
  {
    Vector2 vector2 = new Vector2();
    float z = go.transform.position.z;
    vector2.x = PlayerController.wc.currentXY.x;
    vector2.y = PlayerController.wc.currentXY.y;
    Vector3 vector3 = new Vector3(vector2.x, (float) this.shift - (float) ((double) vector2.x * (double) skala * 1.0) + bonbon, go.transform.position.z);
    Vector3 screenPoint = Camera.main.WorldToScreenPoint(go.transform.position);
    vector3.z = screenPoint.z;
    go.transform.position = Camera.main.ScreenToWorldPoint((Vector3) ScreenControler.gameToScreen((Vector2) vector3));
    go.transform.position = new Vector3(0.0f, go.transform.position.y, z);
  }
}
