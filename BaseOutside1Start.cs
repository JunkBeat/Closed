// Decompiled with JetBrains decompiler
// Type: BaseOutside1Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class BaseOutside1Start : MonoBehaviour
{
  public SpriteRenderer heli;
  public SpriteRenderer moon;
  public SpriteRenderer moong;
  public Sprite moon1;
  public Sprite moon2;
  public Sprite moon3;
  public Sprite moon4;
  public Sprite moon1g;
  public Sprite moon2g;
  public Sprite moon3g;
  public Sprite moon4g;
  public NPCWalkController cody;
  public GameObject codyRun1;
  public GameObject codyRun2;
  public GameObject codyRun3;
  public SpriteRenderer snow;
  public SpriteRenderer bugs;
  public SpriteRenderer coptercoat;
  public SpriteRenderer roof;
  public SpriteRenderer roof1;
  public SpriteRenderer piorunochron;
  private float runState;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = -5f;
    PlayerController.wc.shadow.startAlpha = 0.25f;
    PlayerController.wc.shadow.source = 10f;
    PlayerController.ssg.setStepType("dirt");
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    GameObject.Find("Bike").GetComponent<LocationBaseOutside1Bike>().updateAll();
    if (!GameDataController.gd.getObjective("visited_barn"))
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_main, false);
    else if (GameDataController.gd.getCurrentDay() == 4 && !GameDataController.gd.getObjective("d4_intro"))
      JukeboxMusic.jb.changeMusic((AudioClip) null);
    else
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_2a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 1f);
    if (GameDataController.gd.getCurrentDay() == 1)
      this.moon.sprite = this.moon1;
    if (GameDataController.gd.getCurrentDay() == 2)
      this.moon.sprite = this.moon2;
    if (GameDataController.gd.getCurrentDay() == 3)
      this.moon.sprite = this.moon3;
    if (GameDataController.gd.getCurrentDay() == 4)
      this.moon.sprite = this.moon4;
    if (GameDataController.gd.getCurrentDay() == 1)
      this.moong.sprite = this.moon1g;
    if (GameDataController.gd.getCurrentDay() == 2)
      this.moong.sprite = this.moon2g;
    if (GameDataController.gd.getCurrentDay() == 3)
      this.moong.sprite = this.moon3g;
    if (GameDataController.gd.getCurrentDay() == 4)
      this.moong.sprite = this.moon4g;
    if (GameDataController.gd.gameTime < 510 || GameDataController.gd.gameTime >= 1050)
      this.moong.enabled = true;
    else
      this.moong.enabled = false;
    if (GameDataController.gd.getCurrentDay() == 1)
      this.heli.enabled = false;
    else
      this.heli.enabled = true;
    if (!GameDataController.gd.getObjective("visited_baseOutside1"))
    {
      this.Invoke("showIntro2", 0.25f);
      this.Invoke("showIntro1b", 8f);
    }
    GameDataController.gd.setObjective("visited_baseOutside1", true);
    if (GameDataController.gd.getCurrentDay() == 4 && !GameDataController.gd.getObjective("d4_intro"))
      this.d4Intro();
    if (GameDataController.gd.getCurrentDay() != 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      this.bugs.enabled = true;
    else
      this.bugs.enabled = false;
    if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
    {
      this.snow.enabled = true;
      this.snow.color = GameDataController.gd.gameTime >= 600 ? (GameDataController.gd.gameTime >= 650 ? (GameDataController.gd.gameTime >= 700 ? (GameDataController.gd.gameTime >= 750 ? (GameDataController.gd.gameTime >= 800 ? new Color(1f, 1f, 1f, 0.1f) : new Color(1f, 1f, 1f, 0.2f)) : new Color(1f, 1f, 1f, 0.4f)) : new Color(1f, 1f, 1f, 0.6f)) : new Color(1f, 1f, 1f, 0.8f)) : new Color(1f, 1f, 1f, 1f);
    }
    else
      this.snow.enabled = false;
    if (GameDataController.gd.getObjective("helicopter_covered"))
      this.coptercoat.enabled = true;
    else
      this.coptercoat.enabled = false;
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && (!GameDataController.gd.getObjective("lighting_rod_installed") || GameDataController.gd.getObjectiveDetail("day3_complete") < 1))
    {
      this.roof1.enabled = false;
      this.roof.enabled = true;
    }
    this.piorunochron.enabled = false;
    if (GameDataController.gd.getObjective("lighting_rod_installed"))
      this.piorunochron.enabled = true;
    if (GameDataController.gd.getCurrentDay() != 4 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 1 || GameDataController.gd.getObjective("lighting_rod_installed") && GameDataController.gd.getObjectiveDetail("day3_complete") >= 1)
      return;
    this.piorunochron.enabled = false;
  }

  private void showIntro2()
  {
    GameObject.Find("TitleText").GetComponent<TextFieldController>().shift.x = 64f;
    GameObject.Find("TitleText").GetComponent<TextFieldController>().shift.y = -20f;
    if (GameDataController.gd.getObjective("intro_skipped"))
      return;
    GameObject.Find("TitleText").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "intro_4"), quick: true, instant: true, mwidth: 180, ba: 0.0f);
  }

  private void showIntro1b() => GameObject.Find("TitleText").GetComponent<TextFieldController>().viewText(" ", quick: true, instant: true, mwidth: 180, r: 0.0f, g: 0.0f, b: 0.0f, ba: 0.0f);

  private void Update()
  {
    if ((double) this.runState == 0.0)
      return;
    if ((double) this.runState == 1.0 && (double) this.cody.currentXY.x > 120.0)
    {
      this.runState = 2f;
      this.runLikeCrazy(string.Empty);
    }
    if ((double) this.runState == 2.0 && (double) this.cody.currentXY.x > 150.0)
    {
      this.runState = 3f;
      this.runLikeCrazy(string.Empty);
    }
    if ((double) this.runState != 3.0 || (double) this.cody.currentXY.x >= 95.0)
      return;
    this.runState = 1f;
    this.runLikeCrazy(string.Empty);
  }

  public void d4Intro()
  {
    GameDataController.gd.setObjective("d4_intro", true);
    TextFieldController component1 = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
    {
      if (GameDataController.gd.getObjective("thug_killed_bathroom"))
        DialogueController.dc.initDialogue(dialogueLines, "day4_intro_talk_kill", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, GingerActionController.getColor());
      else
        DialogueController.dc.initDialogue(dialogueLines, "day4_intro_talk_no_kill", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, GingerActionController.getColor());
    }
    DialogueController.dc.initDialogue(dialogueLines, "day4_intro_talk", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, GingerActionController.getColor());
    if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive"))
    {
      Vector3 color = Npc2Controller.getColor();
      TextFieldController component2 = GameObject.Find("Npc2").GetComponent<TextFieldController>();
      DialogueController.dc.initDialogue(dialogueLines, "day4_intro_talk_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, GingerActionController.getColor(), component2, color);
      if (GameDataController.gd.getObjective("npc3_joined") && !GameDataController.gd.getObjective("npc3_alive"))
        dialogueLines[dialogueLines.Count - 1 - 5].text = GameStrings.getString(GameStrings.dialogues, "day4_intro_talk_barry_2_c_no_cody");
    }
    if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
    {
      Vector3 color = Npc3Controller.getColor();
      TextFieldController component3 = GameObject.Find("Npc3").GetComponent<TextFieldController>();
      DialogueController.dc.initDialogue(dialogueLines, "day4_intro_talk_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, GingerActionController.getColor(), component3, color);
      dialogueLines[3].action = new TimelineFunction(this.turnNorth);
      dialogueLines[dialogueLines.Count / 2].action = new TimelineFunction(this.turnNorth2);
      dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.runLikeCrazy);
      dialogueLines[dialogueLines.Count - 1].actionWithText = true;
    }
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  public void turnNorth2(string s = "") => GameObject.Find("Ginger").GetComponent<NPCWalkController>().setBusy(false);

  public void turnNorth(string s = "") => GameObject.Find("Ginger").GetComponent<NPCWalkController>().forceAnimation("stand_n");

  public void runLikeCrazy(string s = "")
  {
    if ((double) this.runState == 0.0)
      this.runState = 1f;
    this.cody.speed = 4f;
    if ((double) this.runState == 1.0)
    {
      this.cody.setSimpleTargetV3(this.codyRun3.transform.position);
      this.cody.forceAnimation("cody_run");
    }
    if ((double) this.runState == 2.0)
    {
      this.cody.setSimpleTargetV3(this.codyRun1.transform.position);
      this.cody.forceAnimation("cody_run");
    }
    if ((double) this.runState != 3.0)
      return;
    this.cody.setSimpleTargetV3(this.codyRun2.transform.position);
    this.cody.forceAnimation("cody_run", true);
  }
}
