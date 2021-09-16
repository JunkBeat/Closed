// Decompiled with JetBrains decompiler
// Type: LocationHouseBBackStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class LocationHouseBBackStart : MonoBehaviour
{
  public NPCWalkController barry;
  public SpriteRenderer snow;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.03f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = -5f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.source = 140f;
    PlayerController.ssg.setStepType(StepSoundGenerator.DIRT);
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    GameDataController.gd.setObjective("visited_house_b_back", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_4a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 1f);
    GameObject.Find("Location").transform.Find("plane00a (2)").GetComponent<SpriteRenderer>().enabled = false;
    if (!GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("house_b_grave_filled"))
    {
      GameObject.Find("Npc2").GetComponent<SpriteRenderer>().flipX = false;
      List<DialogueLine> dialogueLineList = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLineList, "npc2_burial3", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor());
      dialogueLineList[0].action = new TimelineFunction(this.joinTeam);
      if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
      {
        DialogueController.dc.initDialogue(dialogueLineList, "cody_barry_first_meet", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor(), GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor());
        dialogueLineList[dialogueLineList.Count - 15].action = new TimelineFunction(this.codyJump0);
        dialogueLineList[dialogueLineList.Count - 12].action = new TimelineFunction(this.codyJump);
        dialogueLineList[dialogueLineList.Count - 10].action = new TimelineFunction(this.codyJump2);
        dialogueLineList[dialogueLineList.Count - 7].action = new TimelineFunction(this.codyJump4);
        dialogueLineList[dialogueLineList.Count - 1].action = new TimelineFunction(this.codyJump3);
      }
      else
        dialogueLineList[dialogueLineList.Count - 1].action = new TimelineFunction(this.codyJump4);
      Timeline.t.addDialogueLines(dialogueLineList);
    }
    if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
    {
      this.snow.enabled = true;
      if (GameDataController.gd.gameTime < 600)
        this.snow.color = new Color(1f, 1f, 1f, 1f);
      else if (GameDataController.gd.gameTime < 650)
        this.snow.color = new Color(1f, 1f, 1f, 0.8f);
      else if (GameDataController.gd.gameTime < 700)
        this.snow.color = new Color(1f, 1f, 1f, 0.6f);
      else if (GameDataController.gd.gameTime < 750)
        this.snow.color = new Color(1f, 1f, 1f, 0.4f);
      else if (GameDataController.gd.gameTime < 800)
        this.snow.color = new Color(1f, 1f, 1f, 0.2f);
      else
        this.snow.color = new Color(1f, 1f, 1f, 0.1f);
    }
    else
      this.snow.enabled = false;
  }

  public void codyJump0(string v = "")
  {
    GameObject.Find("Npc2").GetComponent<NPCWalkController>().forceAnimation("stand_s");
    GameObject.Find("Npc3").GetComponent<NPCWalkController>().forceAnimation("stand_n");
  }

  public void codyJump(string v = "") => GameObject.Find("Npc3").GetComponent<NPCWalkController>().forceAnimation("can_shake");

  public void codyJump2(string v = "") => GameObject.Find("Npc3").GetComponent<NPCWalkController>().forceAnimation("stand_n");

  public void codyJump4(string v = "") => GameObject.Find("Npc2").GetComponent<NPCWalkController>().forceAnimation("stand_se", true);

  public void codyJump3(string v = "")
  {
    GameObject.Find("Npc3").GetComponent<NPCWalkController>().forceAnimation("stand_se");
    PlayerController.wc.dir = WalkController.Direction.SE;
    PlayerController.wc.forceAnimation("stand_se", makeBusy: false);
    PlayerController.wc.dir = WalkController.Direction.SE;
  }

  public void joinTeam(string val = "")
  {
    GameDataController.gd.setObjective("npc2_joined", true);
    GameDataController.gd.setObjectiveDetail("chitchat", -50);
    GameObject.Find("Npc2").GetComponent<Npc2Controller>().updateState();
  }

  private void Update()
  {
  }
}
