// Decompiled with JetBrains decompiler
// Type: GasstationSargeObject
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class GasstationSargeObject : NPCActionController
{
  public GasstationSarge sarge;
  private static Vector3 color = new Vector3(1f, 1f, 0.0f);
  public GameObject am1;
  public GameObject am2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    if (GameDataController.gd.getObjective("gasstation_spy_mode"))
    {
      this.actionMarker = this.am1;
      this.range = 3000f;
      this.teleport = true;
    }
    else
    {
      this.actionMarker = this.am2;
      this.range = 100f;
      this.teleport = false;
    }
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_sarge1";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("rifle_so_6", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_0", GameStrings.getString(GameStrings.actions, "rifle_no_ammo"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_6", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_0", GameStrings.getString(GameStrings.actions, "rifle_no_ammo"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_6", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_0", GameStrings.getString(GameStrings.actions, "rifle_no_ammo"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_6", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("wrench", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("whiskey", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("knife", GameStrings.getString(GameStrings.actions, "sarge_knife"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("sidereal_id", GameStrings.getString(GameStrings.actions, "sarge_sidereal_id"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_0", GameStrings.getString(GameStrings.actions, "rifle_no_ammo"), anim: string.Empty));
    this.updateState();
    if (GameDataController.gd.getObjective("gasstation_sarge_shot"))
    {
      if (GameDataController.gd.getObjectiveDetail("gasstation_sarge_shot") == 0)
        this.sarge.GetComponent<Animator>().Play("sarge_dead_back");
      else
        this.sarge.GetComponent<Animator>().Play("sarge_dead_front");
    }
    else if (GameDataController.gd.getObjective("thugs_gasstation_talk") && !GameDataController.gd.getObjective("gasstation_sarge_canister_filled"))
      this.sarge.GetComponent<Animator>().Play("sarge_strugle");
    else
      this.sarge.GetComponent<Animator>().Play("sarge_idle");
  }

  private void Update()
  {
  }

  public override void whatOnClick0()
  {
    if (GameDataController.gd.getObjective("gasstation_spy_mode"))
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 3000f;
    }
    else
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 50f;
    }
  }

  public void stopAim(string a = "")
  {
    this.sarge.GetComponent<Animator>().Play("sarge_aim_down");
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_2a);
  }

  public void getToWork(string a = "") => this.sarge.GetComponent<Animator>().Play("sarge_kneel");

  public void stopWork(string a = "") => this.sarge.GetComponent<Animator>().Play("sarge_stand_up");

  public void shootHim()
  {
    PlayerController.pc.setBusy(true);
    this.Invoke("shootHim2", 0.5f);
  }

  public void shootHim2()
  {
    ItemsManager.im.rifleShot(this.usedItem);
    this.Invoke("shootHim3", 0.1f);
  }

  public void shootHim3()
  {
    GameDataController.gd.setObjective("gasstation_sarge_shot", true);
    if (GameDataController.gd.getObjective("gasstation_sarge_canister_filled"))
      GameDataController.gd.setObjectiveDetail("gasstation_sarge_shot", 1);
    else
      GameDataController.gd.setObjectiveDetail("gasstation_sarge_shot", 0);
    this.sarge.shot();
    if (GameDataController.gd.getObjective("npc2_alive"))
    {
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "gasstation_sarge_shot_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor());
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
    }
    if (GameDataController.gd.getObjective("npc3_alive"))
    {
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "gasstation_sarge_shot_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor());
      dialogueLines[3].actionWithText = false;
      dialogueLines[3].action = new TimelineFunction(this.puke);
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
    }
    List<DialogueLine> dialogueLines1 = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines1, "gasstation_sarge_shot_cate", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    for (int index = 0; index < dialogueLines1.Count; ++index)
      Timeline.t.addDialogue(dialogueLines1[index]);
    GameDataController.gd.setObjective("thugs_gasstation_talk", true);
    ItemsManager.im.fixGroundItems(new Vector2(175f, 35f), new Vector2(5f, 2f));
    GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
    ItemsManager.im.initGroundAndInv();
  }

  public void initIntroDialogue()
  {
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    if (!GameDataController.gd.getObjective("gasstation_sarge_intro"))
    {
      DialogueController.dc.initDialogue(dialogueLines, "sarge_first_intro", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("sarge").GetComponent<TextFieldController>(), GasstationSargeObject.color);
      this.sarge.aS.PlayOneShot(ItemsManager.im.getItem("rifle_5").sound);
      this.sarge.GetComponent<Animator>().Play("sarge_stand_up_aim");
    }
    else
    {
      if (!GameDataController.gd.getObjective("gasstation_sarge_canister_filled"))
        this.sarge.GetComponent<Animator>().Play("sarge_stand_up");
      else
        this.sarge.decideRotation();
      DialogueController.dc.initDialogue(dialogueLines, "sarge_intro", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("sarge").GetComponent<TextFieldController>(), GasstationSargeObject.color);
    }
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    DialogueController.dc.callback = new DialogueController.Callback(this.dialogues);
    this.dialogues();
  }

  public void dialogues()
  {
    DialogueController.dc.reset();
    int i1 = 0;
    int num;
    if (!GameDataController.gd.getObjective("gasstation_sarge_reason"))
    {
      this.takeDoc(i1);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_reason_couldkill_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/couldkill");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("gasstation_sarge_reason");
      DialogueController.dc.initDialogue(this.doc.lines, "sarge_reason_couldkill", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
      this.doc.lines[3].action = new TimelineFunction(this.stopAim);
      int i2 = i1 + 1;
      this.takeDoc(i2);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_reason_sniper_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/sniper");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("gasstation_sarge_reason");
      DialogueController.dc.initDialogue(this.doc.lines, "sarge_reason_sniper", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
      this.doc.lines[3].action = new TimelineFunction(this.stopAim);
      int i3 = i2 + 1;
      this.takeDoc(i3);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_reason_surrender_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/surrender");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("gasstation_sarge_reason");
      DialogueController.dc.initDialogue(this.doc.lines, "sarge_reason_surrender", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
      this.doc.lines[3].action = new TimelineFunction(this.stopAim);
      num = i3 + 1;
    }
    else if (GameDataController.gd.getObjective("gasstation_sarge_convincing5"))
    {
      this.takeDoc(i1);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_memory_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/sarge");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective(string.Empty);
      DialogueController.dc.initDialogue(this.doc.lines, "sarge_memory", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
      int i4 = i1 + 1;
      if (GameDataController.gd.getObjective("gasstation_sarge_army"))
      {
        this.takeDoc(i4);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_for_your_squad_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/army");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("gasstation_sarge_convinced");
        DialogueController.dc.initDialogue(this.doc.lines, "sarge_for_your_squad", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
        DialogueController.dc.initDialogue(this.doc.lines, "sarge_ok", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
        num = i4 + 1;
      }
      GameDataController.gd.setObjective("gasstation_sarge_convincing5", false);
    }
    else if (GameDataController.gd.getObjective("gasstation_sarge_convincing4"))
    {
      this.takeDoc(i1);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_decent_life_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/sarge");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("gasstation_sarge_convincing5");
      DialogueController.dc.initDialogue(this.doc.lines, "sarge_decent_life", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
      int i5 = i1 + 1;
      if (GameDataController.gd.getObjective("gasstation_sarge_razor_army"))
      {
        this.takeDoc(i5);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_razor_sucks_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/razor");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("gasstation_sarge_convinced");
        DialogueController.dc.initDialogue(this.doc.lines, "sarge_razor_sucks", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
        DialogueController.dc.initDialogue(this.doc.lines, "sarge_ok", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
        num = i5 + 1;
      }
      GameDataController.gd.setObjective("gasstation_sarge_convincing4", false);
    }
    else if (GameDataController.gd.getObjective("gasstation_sarge_convincing3"))
    {
      this.takeDoc(i1);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_let_us_go_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/us");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective(string.Empty);
      DialogueController.dc.initDialogue(this.doc.lines, "sarge_let_us_go", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
      int i6 = i1 + 1;
      this.takeDoc(i6);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_leave_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/army");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("gasstation_sarge_convincing4");
      DialogueController.dc.initDialogue(this.doc.lines, "sarge_leave", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
      num = i6 + 1;
      GameDataController.gd.setObjective("gasstation_sarge_convincing3", false);
    }
    else if (GameDataController.gd.getObjective("gasstation_sarge_convincing2"))
    {
      this.takeDoc(i1);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_no_threat_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/surrender");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective(string.Empty);
      DialogueController.dc.initDialogue(this.doc.lines, "sarge_no_threat", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
      int i7 = i1 + 1;
      if (GameDataController.gd.getObjective("gasstation_sarge_moon"))
      {
        this.takeDoc(i7);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_end_of_days_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/moon");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("gasstation_sarge_convincing3");
        DialogueController.dc.initDialogue(this.doc.lines, "sarge_end_of_days", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
        ++i7;
      }
      this.takeDoc(i7);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_honor2_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/rank");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective(string.Empty);
      DialogueController.dc.initDialogue(this.doc.lines, "sarge_honor2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
      num = i7 + 1;
      GameDataController.gd.setObjective("gasstation_sarge_convincing2", false);
    }
    else if (GameDataController.gd.getObjective("gasstation_sarge_convincing1"))
    {
      GameDataController.gd.setObjectiveDetail("gasstation_sarge_canister_filled", 1);
      if (GameDataController.gd.getObjective("npc3_alive"))
      {
        this.takeDoc(i1);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_cody_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/cody");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective(string.Empty);
        DialogueController.dc.initDialogue(this.doc.lines, "sarge_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
        ++i1;
      }
      this.takeDoc(i1);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_just_let_go_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/surrender");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective(string.Empty);
      DialogueController.dc.initDialogue(this.doc.lines, "sarge_just_let_go", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
      int i8 = i1 + 1;
      if (GameDataController.gd.getObjective("gasstation_sarge_rank"))
      {
        this.takeDoc(i8);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_honor_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/rank");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("gasstation_sarge_convincing2");
        DialogueController.dc.initDialogue(this.doc.lines, "sarge_honor", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
        num = i8 + 1;
      }
      GameDataController.gd.setObjective("gasstation_sarge_convincing1", false);
    }
    else
    {
      this.takeDoc(i1);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_rank_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/rank");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("gasstation_sarge_rank");
      DialogueController.dc.initDialogue(this.doc.lines, "sarge_rank", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
      int i9 = i1 + 1;
      if (GameDataController.gd.getObjective("gasstation_sarge_rank"))
      {
        this.takeDoc(i9);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_troops_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/army");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("gasstation_sarge_army");
        DialogueController.dc.initDialogue(this.doc.lines, "sarge_troops", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
        ++i9;
      }
      this.takeDoc(i9);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_razor_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/razor");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("gasstation_sarge_razor");
      DialogueController.dc.initDialogue(this.doc.lines, "sarge_razor", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
      int i10 = i9 + 1;
      if (GameDataController.gd.getObjective("gasstation_sarge_razor") && GameDataController.gd.getObjective("gasstation_sarge_army"))
      {
        this.takeDoc(i10);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_razor_army_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/razor_army");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("gasstation_sarge_razor_army");
        DialogueController.dc.initDialogue(this.doc.lines, "sarge_razor_army", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
        ++i10;
      }
      if (GameDataController.gd.getObjective("gasstation_sarge_canister_filled"))
      {
        if (!GameDataController.gd.getObjective("gasstation_sarge_convinced"))
        {
          this.takeDoc(i10);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_bargain_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/wrench");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("gasstation_sarge_convincing1");
          if (GameDataController.gd.getObjectiveDetail("gasstation_sarge_canister_filled") == 0)
            DialogueController.dc.initDialogue(this.doc.lines, "sarge_bargain", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
          else
            DialogueController.dc.initDialogue(this.doc.lines, "sarge_bargain2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
          ++i10;
        }
        this.takeDoc(i10);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_moon_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/moon");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("gasstation_sarge_moon");
        DialogueController.dc.initDialogue(this.doc.lines, "sarge_moon", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
        int i11 = i10 + 1;
        this.takeDoc(i11);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_spaceship_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/ship");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("gasstation_sarge_ship");
        DialogueController.dc.initDialogue(this.doc.lines, "sarge_spaceship", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
        i10 = i11 + 1;
      }
      this.takeDoc(i10);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "exit_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective(string.Empty);
      if (GameDataController.gd.getObjective("gasstation_sarge_convinced"))
      {
        DialogueController.dc.initDialogue(this.doc.lines, "sarge_last_bye", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.farewell);
        Timeline.t.doNotUnlock = true;
      }
      else if (!GameDataController.gd.getObjective("gasstation_sarge_first_bye"))
      {
        DialogueController.dc.initDialogue(this.doc.lines, "sarge_first_bye", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalk1);
      }
      else
      {
        DialogueController.dc.initDialogue(this.doc.lines, "sarge_bye", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, GasstationSargeObject.color);
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalk1);
      }
    }
    this.takeDoc(0);
    if (!(this.doc.caption != string.Empty))
      return;
    DialogueController.dc.talking = true;
  }

  private void endTalk1(string val = "")
  {
    GameDataController.gd.setObjective("gasstation_sarge_intro", true);
    GameDataController.gd.setObjective("gasstation_sarge_first_bye", true);
    if (!GameDataController.gd.getObjective("gasstation_sarge_canister_filled"))
      this.getToWork(string.Empty);
    this.endTalk(string.Empty);
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("gasstation_spy_mode"))
    {
      if (GameDataController.gd.getObjective("gasstation_sarge_shot"))
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "gasstation_sarge_dead"));
      else if (this.usedItem.IndexOf("rifle") != -1)
      {
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "shoot_sarge"), yesClick: new Button.Delegate(this.shootHim));
      }
      else
      {
        if (!(this.usedItem == "wrench"))
          return;
        if (GameDataController.gd.getObjective("gasstation_sarge_canister_filled"))
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "gasstation_sarge_wrench_done"));
        else
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "gasstation_sarge_wrench_far"));
      }
    }
    else if (GameDataController.gd.getObjective("gasstation_sarge_shot"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "gasstation_sarge_dead"));
    else if (this.usedItem.IndexOf("rifle") != -1)
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "gasstation_sarge_shoot_not_here"));
    else if (this.usedItem == "wrench")
    {
      if (!GameDataController.gd.getObjective("gasstation_sarge_canister_filled"))
      {
        this.sarge.GetComponent<Animator>().Play("sarge_stand_up");
        List<DialogueLine> dialogueLines = new List<DialogueLine>();
        DialogueController.dc.initDialogue(dialogueLines, "sarge_wrench", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("sarge").GetComponent<TextFieldController>(), GasstationSargeObject.color);
        dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.endWrench);
        for (int index = 0; index < dialogueLines.Count; ++index)
          Timeline.t.addDialogue(dialogueLines[index]);
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "gasstation_sarge_wrench_done"));
    }
    else if (this.usedItem == "whiskey")
    {
      if (!GameDataController.gd.getObjective("gasstation_sarge_canister_filled"))
        this.sarge.GetComponent<Animator>().Play("sarge_stand_up");
      else
        this.sarge.decideRotation();
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "sarge_whiskey", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("sarge").GetComponent<TextFieldController>(), GasstationSargeObject.color);
      dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.endTalk1);
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
    }
    else
      this.initIntroDialogue();
  }

  public void endWrench(string a = "")
  {
    this.endTalk(string.Empty);
    PlayerController.pc.setBusy(true);
    this.sarge.aS.PlayOneShot(SoundsManagerController.sm.liquid_pour);
    GameDataController.gd.setObjective("gasstation_sarge_canister_filled", true);
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.E, actionAfterFade: new CurtainController.Delegate(this.doneFuel), tSpeed: 0.02f);
  }

  public void farewell(string a = "")
  {
    DialogueController.dc.talking = false;
    DialogueController.dc.hide();
    PlayerController.pc.setBusy(true);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.motorbikes);
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.E, actionAfterFade: new CurtainController.Delegate(this.hideBike));
  }

  private void hideBike() => GameObject.Find("LocationManager").GetComponent<Gasstation2Start>().starter();

  public void doneFuel()
  {
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "sarge_thanks", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("sarge").GetComponent<TextFieldController>(), GasstationSargeObject.color);
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  public void puke(string aaa = "") => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.vomit);

  public override void updateState()
  {
    if (GameDataController.gd.getCurrentDay() != 3 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 0 || !GameDataController.gd.getObjective("sidereal_base_located"))
    {
      this.setCollider(-1);
      this.sarge.GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      this.setCollider(0);
      this.sarge.GetComponent<SpriteRenderer>().enabled = true;
      if (GameDataController.gd.getObjective("gasstation_sarge_canister_filled"))
        this.setCollider(1);
      if (GameDataController.gd.getObjective("gasstation_sarge_shot"))
        this.setCollider(2);
    }
    if (GameDataController.gd.getObjective("gasstation_sarge_convinced"))
    {
      this.setCollider(-1);
      this.sarge.GetComponent<SpriteRenderer>().enabled = false;
    }
    if (GameDataController.gd.getCurrentDay() > 3 && !GameDataController.gd.getObjective("gasstation_sarge_shot"))
    {
      this.setCollider(-1);
      this.sarge.GetComponent<SpriteRenderer>().enabled = false;
    }
    if (GameDataController.gd.getObjective("gasstation_spy_mode") || GameDataController.gd.getObjective("gasstation_sarge_shot"))
      this.actionType = ObjectActionController.Type.NormalAction;
    else
      this.actionType = ObjectActionController.Type.Talk;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public void dontTouchThat()
  {
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "gasstation_sarge_dont_touch", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("sarge").GetComponent<TextFieldController>(), GasstationSargeObject.color);
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  public void talkWrench()
  {
    this.usedItem = "wrench";
    this.clickAction();
  }
}
