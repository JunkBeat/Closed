// Decompiled with JetBrains decompiler
// Type: LocationRestaurant1Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationRestaurant1Start : MonoBehaviour
{
  public SpriteRenderer solider1;
  public SpriteRenderer solider2;
  public RestaurantSolider1 s1;
  public RestaurantSolider2 s2;
  public SpriteRenderer pylon;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = -4;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 15f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.source = 140f;
    PlayerController.ssg.setStepType(StepSoundGenerator.ROAD);
    PlayerController.wc.shadow.scaleFactor = 0.3f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    GameDataController.gd.setObjective("visited_restaurant_front", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_3a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_flag, 1f);
    if (GameDataController.gd.getCurrentDay() != 3 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 1 || !GameDataController.gd.getObjective("sidereal_base_located"))
    {
      this.solider1.enabled = false;
      this.solider2.enabled = false;
    }
    else
    {
      this.solider1.enabled = true;
      this.solider2.enabled = true;
      if (!GameDataController.gd.getObjective("restaurant_sarge_encountered"))
      {
        this.solider1.gameObject.GetComponent<Animator>().Play("solider1_aim_start");
        this.solider2.gameObject.GetComponent<Animator>().Play("solider2_aim_start");
        GameDataController.gd.setObjective("gasstation_map_warned", true);
        PlayerController.wc.forceAnimation("stand_ne", true);
        GameObject.Find("Ginger").GetComponent<NPCWalkController>().setFlipped(true);
        List<DialogueLine> dialogueLines = new List<DialogueLine>();
        Vector3 color = GingerActionController.getColor();
        TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
        DialogueController.dc.initDialogue(dialogueLines, "soliders_intro1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.s1.textField, RestaurantSolider1.color, this.s2.textField, RestaurantSolider2.color);
        DialogueController.dc.initDialogue(dialogueLines, "soliders_intro2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.s1.textField, RestaurantSolider1.color, component, color);
        if (GameDataController.gd.getObjective("npc3_alive"))
        {
          GameObject.Find("Npc3").GetComponent<NPCWalkController>().setFlipped(true);
          DialogueController.dc.initDialogue(dialogueLines, "soliders_intro1_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color, GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor());
        }
        if (GameDataController.gd.getObjective("npc2_alive"))
        {
          GameObject.Find("Npc2").GetComponent<NPCWalkController>().setFlipped(true);
          DialogueController.dc.initDialogue(dialogueLines, "soliders_intro1_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.s1.textField, RestaurantSolider1.color, GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor());
        }
        DialogueController.dc.initDialogue(dialogueLines, "soliders_intro3", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.s1.textField, RestaurantSolider1.color, this.s2.textField, RestaurantSolider2.color);
        dialogueLines[1].action = new TimelineFunction(this.playerRotate);
        dialogueLines[2].action = new TimelineFunction(this.npcSurr);
        dialogueLines[2].actionWithText = true;
        dialogueLines[5].action = new TimelineFunction(this.playerSurr);
        dialogueLines[5].actionWithText = true;
        dialogueLines[7].action = new TimelineFunction(this.cateSurr);
        dialogueLines[7].actionWithText = true;
        dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.gotoRestaurant);
        Timeline.t.doNotUnlock = true;
        for (int index = 0; index < dialogueLines.Count; ++index)
          Timeline.t.addDialogue(dialogueLines[index]);
      }
      else
      {
        this.solider1.gameObject.GetComponent<Animator>().Play("solider1_guard_loop");
        this.solider2.gameObject.GetComponent<Animator>().Play("solider2_guard_loop");
      }
    }
    this.pylon.enabled = false;
    if (!GameDataController.gd.getObjective("r_sarge_catcher"))
      return;
    this.pylon.enabled = true;
  }

  public void playerRotate(string s = "")
  {
    PlayerController.pc.setBusy(true);
    PlayerController.pc.gameObject.GetComponent<Animator>().enabled = true;
    PlayerController.wc.dir = WalkController.Direction.NW;
    PlayerController.wc.forceAnimation("stand_ne", true);
    PlayerController.wc.dir = WalkController.Direction.NW;
  }

  public void playerSurr(string s = "") => PlayerController.wc.forceAnimation("surr_start", true);

  public void npcSurr(string s = "")
  {
    if (GameDataController.gd.getObjective("npc2_alive"))
      GameObject.Find("Npc2").GetComponent<NPCWalkController>().forceAnimation("surr_start", true);
    if (!GameDataController.gd.getObjective("npc3_alive"))
      return;
    GameObject.Find("Npc3").GetComponent<NPCWalkController>().forceAnimation("surr_start", true);
  }

  public void cateSurr(string s = "") => GameObject.Find("Ginger").GetComponent<NPCWalkController>().forceAnimation("surr_start", true);

  public void gotoRestaurant(string s = "")
  {
    PlayerController.pc.spawnName = "WaypointRestaurantArrest";
    CurtainController.cc.fadeOut("LocationRestaurant3", WalkController.Direction.N, "surr", flipX: true);
  }

  private void Update()
  {
  }
}
