// Decompiled with JetBrains decompiler
// Type: LocationRestaurant3Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationRestaurant3Start : MonoBehaviour
{
  public SpriteRenderer solider1;
  public SpriteRenderer solider2;
  public SpriteRenderer solider4;
  public SpriteRenderer soliderStuff1;
  public SpriteRenderer soliderStuff2;
  public SpriteRenderer soliderStuff3;
  public SpriteRenderer soliderStuff4;
  public bool codySurprised;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.02f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 5f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.source = 140f;
    PlayerController.ssg.setStepType(StepSoundGenerator.NORMAL);
    PlayerController.wc.shadow.scaleFactor = 0.9f;
    PlayerController.wc.shadow.downwards = false;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    GameDataController.gd.setObjective("visited_restaurant_inside", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_3a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_flag, 0.5f);
    GameObject.Find("Npc3").GetComponent<Npc3Controller>().updateState();
    this.soliderStuff1.enabled = true;
    this.soliderStuff2.enabled = true;
    this.soliderStuff3.enabled = true;
    this.soliderStuff4.enabled = true;
    if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && GameDataController.gd.getObjective("sidereal_base_located"))
    {
      if (!GameDataController.gd.getObjective("restaurant_sarge_encountered"))
      {
        GameDataController.gd.setObjective("restaurant_sarge_awaits", false);
        this.solider1.enabled = true;
        this.solider2.enabled = true;
        this.solider4.enabled = true;
        this.solider1.gameObject.GetComponent<Animator>().Play("solider1_aim_loop");
        this.solider2.gameObject.GetComponent<Animator>().Play("solider2_aim_loop");
        this.solider4.gameObject.GetComponent<Animator>().Play("solider4_aim");
        this.solider1.gameObject.transform.position = ScreenControler.roundToNearestFullPixel3(this.solider1.gameObject.transform.position);
        this.solider2.gameObject.transform.position = ScreenControler.roundToNearestFullPixel3(this.solider2.gameObject.transform.position);
        this.solider4.gameObject.transform.position = ScreenControler.roundToNearestFullPixel3(this.solider4.gameObject.transform.position);
        GameObject.Find("SargeObject").GetComponent<RestaurantSarge>().initIntroDialogue();
        GameObject.Find("Ginger").GetComponent<NPCWalkController>().forceAnimation("surr", true);
        if (GameDataController.gd.getObjective("npc3_alive"))
          GameObject.Find("Npc3").GetComponent<NPCWalkController>().setBusy(true);
        if (GameDataController.gd.getObjective("npc3_alive"))
          GameObject.Find("Npc3").GetComponent<NPCWalkController>().forceAnimation("surr", true);
        this.Invoke("surr_npc", 0.15f);
      }
      else
      {
        this.solider1.enabled = false;
        this.solider2.enabled = false;
        this.solider4.enabled = false;
        this.Invoke("antisurr_npc", 0.15f);
      }
    }
    else
    {
      this.soliderStuff1.enabled = false;
      this.soliderStuff2.enabled = false;
      this.soliderStuff3.enabled = false;
      this.soliderStuff4.enabled = false;
      this.solider1.enabled = false;
      this.solider2.enabled = false;
      this.solider4.enabled = false;
    }
    if (!GameDataController.gd.getObjective("restaurant_door_opened") || GameDataController.gd.getObjective("dialogue_cody_door_opened"))
      return;
    this.codySurprised = true;
  }

  private void surr_npc()
  {
    if (GameDataController.gd.getObjective("npc2_alive"))
      GameObject.Find("Npc2").GetComponent<NPCWalkController>().forceAnimation("surr", true);
    if (!GameDataController.gd.getObjective("npc3_alive"))
      return;
    GameObject.Find("Npc3").GetComponent<NPCWalkController>().forceAnimation("surr", true);
  }

  private void antisurr_npc()
  {
    GameObject.Find("Ginger").GetComponent<NPCWalkController>().setBusy(false);
    if (GameDataController.gd.getObjective("npc2_alive"))
      GameObject.Find("Npc2").GetComponent<NPCWalkController>().setBusy(false);
    if (!GameDataController.gd.getObjective("npc3_alive"))
      return;
    GameObject.Find("Npc3").GetComponent<NPCWalkController>().setBusy(false);
  }

  private void Update()
  {
    if (GameDataController.gd.getCurrentDay() != 2 || (double) PlayerController.wc.currentXY.x >= 70.0 && (double) PlayerController.wc.currentXY.y <= 15.0 || GameDataController.gd.getObjective("restaurant_door_opened2"))
      return;
    if (this.codySurprised)
    {
      this.codySurprised = false;
      GameDataController.gd.setObjective("restaurant_door_opened2", true);
      GameObject.Find("Npc3").GetComponent<NPCWalkController>().forceAnimation("surprised", true);
      GameObject.Find("Npc3").GetComponent<Npc3Controller>().fakeClick();
    }
    else
    {
      if (GameDataController.gd.getObjective("restaurant_door_opened"))
        return;
      if ((double) PlayerController.wc.currentXY.y > 15.0)
        PlayerController.wc.currentXY.y = 15f;
      if ((double) PlayerController.wc.currentXY.x < 70.0)
        PlayerController.wc.currentXY.x = 70f;
      PlayerController.wc.fullStop(true);
      PlayerController.pc.clickedAlreadyForSomething = false;
      GameObject.Find("Npc3").GetComponent<Npc3Controller>().fakeClick();
    }
  }
}
