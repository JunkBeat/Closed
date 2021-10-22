// Decompiled with JetBrains decompiler
// Type: LocationBaseUpstairsStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationBaseUpstairsStart : MonoBehaviour
{
  public SpriteRenderer szejk;
  public SpriteRenderer holes;
  public SpriteRenderer rays;
  public SpriteRenderer rays2;
  public SpriteRenderer darknessNormal;
  public SpriteRenderer darknessNoRoof;
  public float aaa;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 1f / 500f;
    PlayerController.wc.shadow.fadeRateH = 1f / 500f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 25f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.source = 150f;
    PlayerController.ssg.setStepType("wood");
    GameDataController.gd.setObjective("visited_baseUpstairs", true);
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_5a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 0.25f);
    GameObject.Find("Ladder").transform.Find("faller").GetComponent<SpriteRenderer>().enabled = false;
    GameObject.Find("Ladder").transform.Find("faller").GetComponent<Animator>().Play("klapa_0");
    if (!GameDataController.gd.getObjective("dream_day_2_awake") && GameDataController.gd.getCurrentDay() == 2)
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.heli_crash);
      GameObject.Find("Location").GetComponent<LocationManager>().needShake = 1.75f;
      GameObject.Find("Duster").GetComponent<ParticleGenerator>().started = true;
      GameObject.Find("Duster2").GetComponent<ParticleGenerator>().started = true;
      GameDataController.gd.setObjective("dream_day_2_awake", true);
      PlayerController.pc.haltSoftLockProbe();
      if (GameDataController.gd.getObjectiveDetail("day1_complete") >= 0)
      {
        PlayerController.wc.setSimpleTarget(new Vector2(165f, 35f));
        this.Invoke("unlockPlayer", 4f);
      }
      else
        this.Invoke("continueSleeping", 4f);
      this.Invoke("fallKlapa", 2f);
    }
    else if (GameDataController.gd.getObjective("dream_day_2_awake") && GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjectiveDetail("day1_complete") < 0 && !GameDataController.gd.getObjective("dialogue_ginger_intro"))
    {
      PlayerController.wc.forceAnimation("stand_up");
      PlayerController.wc.setSimpleTarget(new Vector2(165f, 29f));
      GameObject.Find("WakeUp").transform.Find("GingerSpawner").GetComponent<NPCSpawner>().spawnOrNot();
      GameObject.Find("Ginger").GetComponent<GingerActionController>().npcClickAction(string.Empty);
      GameObject.Find("Ginger").GetComponent<NPCWalkController>().setFlipped(true);
      GameObject.Find("Ginger").GetComponent<NPCWalkController>().dir = NPCWalkController.Direction.SW;
      PlayerController.wc.dir = WalkController.Direction.SE;
    }
    if (!GameDataController.gd.getObjective("dream_day_4_awake") && GameDataController.gd.getCurrentDay() == 4)
    {
      GameDataController.gd.setObjective("dream_day_4_awake", true);
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
      {
        PlayerController.pc.haltSoftLockProbe();
        PlayerController.wc.setSimpleTarget(new Vector2(165f, 35f));
        this.Invoke("unlockPlayer2", 2f);
      }
      else
        PlayerController.pc.setBusy(false);
    }
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
    {
      this.darknessNormal.enabled = true;
      this.darknessNoRoof.enabled = false;
      if (!GameDataController.gd.getObjective("lighting_rod_installed") || GameDataController.gd.getObjectiveDetail("day3_complete") < 1)
      {
        this.darknessNormal.enabled = false;
        this.darknessNoRoof.enabled = true;
      }
      this.holes.enabled = true;
      this.rays.enabled = true;
      this.rays2.enabled = true;
    }
    else
    {
      this.darknessNormal.enabled = true;
      this.darknessNoRoof.enabled = false;
      this.holes.enabled = false;
      this.rays.enabled = false;
      this.rays2.enabled = false;
    }
  }

  private void ignoreClicks(string a = "")
  {
    PlayerController.pc.clickedAlreadyForSomething = true;
    PlayerController.pc.clickedSomething = true;
  }

  private void continueSleeping()
  {
    GameObject.Find("Stairs_Exit").GetComponent<SpriteRenderer>().enabled = true;
    GameObject.Find("Duster2").GetComponent<ParticleGenerator>().started = false;
    PlayerController.pc.clickedSomething = true;
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "day2_overslept", GameObject.Find("BottomText").GetComponent<TextFieldController>(), new Vector3(1f, 1f, 1f));
    GameObject.Find("BottomText").GetComponent<TextFieldController>().maxWidth = 200;
    dialogueLines[dialogueLines.Count - 1].actionWithText = false;
    dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.continueSleeping2);
    dialogueLines[0].actionWithText = false;
    dialogueLines[0].action = new TimelineFunction(this.ignoreClicks);
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    Timeline.t.doNotUnlock = true;
  }

  private void continueSleeping2(string val = "")
  {
    Timeline.t.doNotUnlock = true;
    GameObject.Find("BottomText").GetComponent<TextFieldController>().terminate();
    GameObject.Find("BottomText").GetComponent<TextFieldController>().dissmiss(true);
    GameDataController.gd.setObjective("ginger_from_attic", true);
    CurtainController.cc.fadeOut(animation: "sleep", tSpeed: 0.02f);
    this.Invoke("Start", 1.5f);
  }

  private void unlockPlayer2()
  {
    PlayerController.pc.setBusy(false);
    PlayerController.pc.resumeSoftLockProbe();
    if (GameDataController.gd.getObjective("npc3_alive") || GameDataController.gd.getObjective("npc2_alive"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "dream4_ended_multi"));
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "dream4_ended_cate"));
    if (GameDataController.gd.getCurrentDay() != 4 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 0)
      return;
    GameDataController.gd.setObjective("thug_to_kill_bathroom", true);
  }

  private void unlockPlayer()
  {
    PlayerController.pc.setBusy(false);
    PlayerController.pc.resumeSoftLockProbe();
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "heli_crash_what"));
    GameObject.Find("Stairs_Exit").GetComponent<SpriteRenderer>().enabled = true;
    GameObject.Find("Duster2").GetComponent<ParticleGenerator>().started = false;
  }

  private void fallKlapa()
  {
    GameObject.Find("Duster").GetComponent<ParticleGenerator>().started = false;
    GameObject.Find("Ladder").GetComponent<SpriteRenderer>().enabled = false;
    GameObject.Find("Ladder").transform.Find("faller").GetComponent<SpriteRenderer>().enabled = true;
    GameObject.Find("Ladder").transform.Find("faller").GetComponent<Animator>().Play("klapa_fall");
  }

  private void Update()
  {
  }
}
