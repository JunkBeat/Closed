// Decompiled with JetBrains decompiler
// Type: LocationRV1Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class LocationRV1Start : MonoBehaviour
{
  public Sprite snow;
  public Sprite normal;
  public Sprite scorch;
  public SpriteRenderer sr;
  public bool codyLives;
  public bool codyTalked;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = -2;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 5f;
    PlayerController.wc.shadow.startAlpha = 0.25f;
    PlayerController.wc.shadow.source = 10f;
    PlayerController.ssg.setStepType("dirt");
    PlayerController.wc.shadow.scaleFactor = 0.5f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    if (!GameDataController.gd.getObjective("visited_rv"))
    {
      Vector3 color = GingerActionController.getColor();
      TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "rv_encounter", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
      for (int index = 0; index < 5; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
        Timeline.t.addDialogue(dialogueLines[5]);
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
        Timeline.t.addDialogue(dialogueLines[6]);
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
        Timeline.t.addDialogue(dialogueLines[7]);
    }
    if (!GameDataController.gd.getObjective("rv_started"))
      GameObject.Find("Smoke").GetComponent<ParticleGenerator>().started = false;
    else
      GameObject.Find("Smoke").GetComponent<ParticleGenerator>().started = true;
    GameDataController.gd.setObjective("visited_rv", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_3a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 0.4f);
    if (GameDataController.gd.getCurrentDay() == 3)
    {
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
      {
        this.sr.sprite = this.snow;
        this.sr.color = GameDataController.gd.gameTime >= 600 ? (GameDataController.gd.gameTime >= 650 ? (GameDataController.gd.gameTime >= 700 ? (GameDataController.gd.gameTime >= 750 ? (GameDataController.gd.gameTime >= 800 ? new Color(1f, 1f, 1f, 0.1f) : new Color(1f, 1f, 1f, 0.2f)) : new Color(1f, 1f, 1f, 0.4f)) : new Color(1f, 1f, 1f, 0.6f)) : new Color(1f, 1f, 1f, 0.8f)) : new Color(1f, 1f, 1f, 1f);
      }
      else
        this.sr.sprite = this.scorch;
    }
    else
      this.sr.sprite = this.normal;
    this.codyTalked = GameDataController.gd.getObjective("place_rv_cody");
    this.codyLives = false;
    if (GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjective("npc3_joined"))
      this.codyLives = true;
    this.Invoke("checkCodyTalk", 2f);
  }

  private void checkCodyTalk()
  {
    this.codyTalked = GameDataController.gd.getObjective("place_rv_cody");
    if (this.codyTalked)
      return;
    this.Invoke(nameof (checkCodyTalk), 2f);
  }

  private void Update()
  {
    if (!this.codyTalked || !this.codyLives || !(CursorController.cc.selectedItemName == "shovel"))
      return;
    CursorController.cc.deselectItem();
    InventoryButtonController.ibc.close();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "dig_treasure", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.grantAchievment);
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  private void grantAchievment(string s = "") => GameDataController.Achievement("S_TREASURE");
}
