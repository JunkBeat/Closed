// Decompiled with JetBrains decompiler
// Type: RestaurantSarge
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class RestaurantSarge : ObjectActionController
{
  public GameObject sarge;
  protected DialogueOptionController doc;
  public TextFieldController textField;
  public static Vector3 color = new Vector3(1f, 1f, 0.0f);
  public Vector3 position;
  public Vector2 position2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.actionType = ObjectActionController.Type.Talk;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_sarge";
    this.range = 30f;
    this.position = ScreenControler.roundToNearestFullPixel3(this.sarge.transform.position);
    this.sarge.transform.position = this.position;
    this.position2 = new Vector2(75f, 92f);
    Vector2 vectorToChange = new Vector2();
    float z = this.sarge.transform.position.z;
    vectorToChange.x = this.position2.x;
    vectorToChange.y = this.position2.y;
    Vector2 screen = ScreenControler.gameToScreen(vectorToChange);
    this.position = new Vector3(screen.x, screen.y, this.sarge.transform.position.z);
    this.position.z = Camera.main.WorldToScreenPoint(this.sarge.transform.position).z;
    this.sarge.transform.position = Camera.main.ScreenToWorldPoint(this.position);
    this.sarge.transform.position = new Vector3(this.sarge.transform.position.x, this.sarge.transform.position.y, z);
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("rifle_0", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_6", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_0", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_6", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_0", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_6", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_0", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_6", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_0", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_6", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("gun_ammo", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_ammo", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("bandage", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("whiskey", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("stormcatcher1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("stormcatcher2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("stormcatcher3", string.Empty, anim: string.Empty));
    this.updateState();
  }

  private void takeCatcher(string item)
  {
    GameDataController.gd.setObjective("r_sarge_catcher", true);
    InventoryController.ic.removeItem(item);
  }

  public override void clickAction()
  {
    if (this.usedItem == string.Empty)
      this.initIntroDialogue();
    else if (this.usedItem.IndexOf("stormcatcher") != -1)
    {
      GameDataController.gd.setObjective("r_paul_mount1", true);
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      if (!GameDataController.gd.getObjective("r_sarge_catchers1"))
      {
        GameDataController.gd.setObjective("r_sarge_catchers1", true);
        DialogueController.dc.initDialogue(dialogueLines, "r_sarge_catchers1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
      }
      else if (!GameDataController.gd.getObjective("r_sarge_gun") || !GameDataController.gd.getObjective("r_sarge_ammo"))
        DialogueController.dc.initDialogue(dialogueLines, "r_sarge_catchers2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
      else if (!GameDataController.gd.getObjective("r_sarge_catcher"))
      {
        DialogueController.dc.initDialogue(dialogueLines, "r_sarge_catchers4", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.sarge.GetComponent<TextFieldController>(), RestaurantSarge.color);
        dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.takeCatcher);
        dialogueLines[dialogueLines.Count - 1].actionParam = this.usedItem;
      }
      else
        DialogueController.dc.initDialogue(dialogueLines, "r_sarge_catchers5", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
    }
    else if (this.usedItem.IndexOf("rifle") != -1 || this.usedItem.IndexOf("revolver") != -1 || this.usedItem.IndexOf("ammo") != -1)
    {
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      if (GameDataController.gd.getObjective("r_sarge_catchers1"))
      {
        if (GameDataController.gd.getObjective("r_sarge_gun") && GameDataController.gd.getObjective("r_sarge_ammo"))
        {
          DialogueController.dc.initDialogue(dialogueLines, "r_sarge_catchers_gun3", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.sarge.GetComponent<TextFieldController>(), RestaurantSarge.color);
        }
        else
        {
          if (this.usedItem.IndexOf("rifle") != -1 && this.usedItem.IndexOf("ammo") == -1)
            DialogueController.dc.initDialogue(dialogueLines, "r_sarge_catchers_gun2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.sarge.GetComponent<TextFieldController>(), RestaurantSarge.color);
          if (this.usedItem.IndexOf("gun_ammo") != -1)
          {
            if (GameDataController.gd.getObjective("r_sarge_gun"))
            {
              DialogueController.dc.initDialogue(dialogueLines, "r_sarge_catchers_ammo1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.sarge.GetComponent<TextFieldController>(), RestaurantSarge.color);
              InventoryController.ic.removeItem("gun_ammo");
              GameDataController.gd.setObjective("r_sarge_ammo", true);
            }
            else
              DialogueController.dc.initDialogue(dialogueLines, "r_sarge_catchers_ammo3", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.sarge.GetComponent<TextFieldController>(), RestaurantSarge.color);
          }
          if (this.usedItem.IndexOf("revolver") != -1)
          {
            DialogueController.dc.initDialogue(dialogueLines, "r_sarge_catchers_gun1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.sarge.GetComponent<TextFieldController>(), RestaurantSarge.color);
            InventoryController.ic.removeItem(this.usedItem);
            GameDataController.gd.setObjective("r_sarge_gun", true);
          }
          if (this.usedItem.IndexOf("rifle_ammo") != -1)
          {
            if (GameDataController.gd.getObjective("r_sarge_gun"))
              DialogueController.dc.initDialogue(dialogueLines, "r_sarge_catchers_ammo2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.sarge.GetComponent<TextFieldController>(), RestaurantSarge.color);
            else
              DialogueController.dc.initDialogue(dialogueLines, "r_sarge_catchers_ammo3", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.sarge.GetComponent<TextFieldController>(), RestaurantSarge.color);
          }
        }
      }
      else
        DialogueController.dc.initDialogue(dialogueLines, "r_sarge_catchers_deal0", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.sarge.GetComponent<TextFieldController>(), RestaurantSarge.color);
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.dialogues, "r_sarge_medical"));
  }

  public void initIntroDialogue()
  {
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    if (!GameDataController.gd.getObjective("restaurant_sarge_encountered"))
    {
      DialogueController.dc.initDialogue(dialogueLines, "r_sarge_intro1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.sarge.GetComponent<TextFieldController>(), RestaurantSarge.color);
      if (GameDataController.gd.getObjective("npc3_alive"))
        DialogueController.dc.initDialogue(dialogueLines, "r_sarge_intro1_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.sarge.GetComponent<TextFieldController>(), RestaurantSarge.color, GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor());
      if (GameDataController.gd.getObjective("npc2_alive"))
        DialogueController.dc.initDialogue(dialogueLines, "r_sarge_intro1_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.sarge.GetComponent<TextFieldController>(), RestaurantSarge.color, GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor());
      dialogueLines[dialogueLines.Count - 2].action = new TimelineFunction(this.blockanim);
    }
    else
      DialogueController.dc.initDialogue(dialogueLines, "sarge_intro", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.sarge.GetComponent<TextFieldController>(), RestaurantSarge.color);
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    DialogueController.dc.callback = new DialogueController.Callback(this.dialogues);
    this.dialogues();
  }

  public void takeDoc(int i) => this.doc = DialogueController.dc.dialogueOptions[i].GetComponent<DialogueOptionController>();

  public void blockanim(string a = "") => PlayerController.pc.gameObject.GetComponent<Animator>().enabled = false;

  public void dialogueintro2(string s = "")
  {
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "r_sarge_intro2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.sarge.GetComponent<TextFieldController>(), RestaurantSarge.color);
    dialogueLines[dialogueLines.Count - 2].action = new TimelineFunction(this.playerStandUp);
    dialogueLines[dialogueLines.Count - 2].actionWithText = false;
    dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.atEase);
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  public void dialogueintro3()
  {
    GameObject.Find("solider1").GetComponent<SpriteRenderer>().enabled = false;
    GameObject.Find("solider2").GetComponent<SpriteRenderer>().enabled = false;
    GameObject.Find("solider4").GetComponent<SpriteRenderer>().enabled = false;
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "r_sarge_intro3", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.sarge.GetComponent<TextFieldController>(), RestaurantSarge.color);
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    DialogueController.dc.talking = true;
    DialogueController.dc.callback = new DialogueController.Callback(this.dialogues);
    this.dialogues();
  }

  public void atEase(string s = "")
  {
    DialogueController.dc.talking = false;
    Timeline.t.doNotUnlock = true;
    PlayerController.pc.setBusy(true);
    CurtainController.cc.fadeOut(actionAfterFade: new CurtainController.Delegate(this.dialogueintro3));
  }

  public void playerStandUp(string v = "")
  {
    Timeline.t.doNotUnlock = true;
    PlayerController.pc.gameObject.GetComponent<Animator>().enabled = true;
    PlayerController.pc.forceAnimation("surr_end");
    PlayerController.wc.forceDirection(WalkController.Direction.NW);
    GameObject.Find("Ginger").GetComponent<NPCWalkController>().forceAnimation("surr_end", true);
    if (GameDataController.gd.getObjective("npc2_alive"))
      GameObject.Find("Npc2").GetComponent<NPCWalkController>().forceAnimation("surr_end", true);
    if (!GameDataController.gd.getObjective("npc3_alive"))
      return;
    GameObject.Find("Npc3").GetComponent<NPCWalkController>().forceAnimation("surr_end", true);
  }

  public void dialogues()
  {
    DialogueController.dc.reset();
    int i1 = 0;
    int num;
    if (!GameDataController.gd.getObjective("restaurant_sarge_encountered"))
    {
      PlayerController.pc.gameObject.GetComponent<Animator>().enabled = true;
      PlayerController.wc.forceAnimation("surr", true);
      PlayerController.pc.gameObject.GetComponent<Animator>().enabled = false;
      this.takeDoc(i1);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_sarge_hello1_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/us");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("restaurant_sarge_encountered");
      DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_hello1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.sarge.GetComponent<TextFieldController>(), RestaurantSarge.color);
      if (GameDataController.gd.getObjective("npc3_alive"))
        DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_hello1_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor());
      if (GameDataController.gd.getObjective("npc2_alive"))
        DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_hello1_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor());
      this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.dialogueintro2);
      int i2 = i1 + 1;
      this.takeDoc(i2);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_sarge_hello3_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/we_family");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("restaurant_sarge_encountered");
      DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_hello3", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.sarge.GetComponent<TextFieldController>(), RestaurantSarge.color);
      if (GameDataController.gd.getObjective("npc3_alive"))
        DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_hello3_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor());
      if (GameDataController.gd.getObjective("npc2_alive"))
        DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_hello3_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor());
      this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.dialogueintro2);
      int i3 = i2 + 1;
      this.takeDoc(i3);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_sarge_hello2_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/we_noneofyour");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("restaurant_sarge_encountered");
      DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_hello2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.sarge.GetComponent<TextFieldController>(), RestaurantSarge.color);
      if (GameDataController.gd.getObjective("npc3_alive"))
        DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_hello1_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor());
      if (GameDataController.gd.getObjective("npc2_alive"))
        DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_hello1_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor());
      this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.dialogueintro2);
      num = i3 + 1;
    }
    else
    {
      if (!GameDataController.gd.getObjective("r_sarge_wounded2"))
      {
        this.takeDoc(i1);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_sarge_wounded1_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/wounded");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("r_sarge_wounded1");
        DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_wounded1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
        if (GameDataController.gd.getObjective("r_sarge_wounded_bandage") && GameDataController.gd.getObjective("r_sarge_wounded_alcohol"))
          DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_wounded8", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
        else if (GameDataController.gd.getObjective("r_sarge_wounded_bandage"))
          DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_wounded4", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
        else if (GameDataController.gd.getObjective("r_sarge_wounded_alcohol"))
          DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_wounded3", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
        else
          DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_wounded2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
        ++i1;
      }
      else if (!GameDataController.gd.getObjective("r_sarge_wounded_bandage") && !GameDataController.gd.getObjective("r_sarge_wounded_alcohol"))
      {
        this.takeDoc(i1);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_sarge_wounded6_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/wounded");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("r_sarge_wounded3");
        DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_wounded6", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
        if (GameDataController.gd.getObjective("r_sarge_wounded_bandage"))
          DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_wounded4", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
        else if (GameDataController.gd.getObjective("r_sarge_wounded_alcohol"))
          DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_wounded3", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
        else
          DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_wounded2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
        ++i1;
      }
      this.takeDoc(i1);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_sarge_plans1_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/army");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("r_sarge_plans1");
      DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_plans1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
      int i4 = i1 + 1;
      this.takeDoc(i4);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_sarge_places_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/map");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("r_sarge_places1");
      DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_places1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
      this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.addConstruction);
      int i5 = i4 + 1;
      if (GameDataController.gd.getObjective("r_sarge_plans1"))
      {
        this.takeDoc(i5);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_sarge_plans2_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/east");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("r_sarge_plans2");
        DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_plans2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
        ++i5;
      }
      if (GameDataController.gd.getObjective("r_sarge_plans2"))
      {
        this.takeDoc(i5);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_sarge_survive1_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/storm");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("r_sarge_survive1");
        DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_survive1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
        ++i5;
      }
      if (GameDataController.gd.getObjective("r_sarge_plans2") && GameDataController.gd.getObjective("gasstation_sarge_ship"))
      {
        this.takeDoc(i5);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_sarge_plans3_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/sarge_ship");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("r_sarge_plans3");
        DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_plans3", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
        string key = string.Empty;
        if (GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjective("npc3_alive"))
          key = "r_sarge_plans3_cody_barry";
        else if (GameDataController.gd.getObjective("npc2_alive"))
          key = "r_sarge_plans3_barry";
        else if (GameDataController.gd.getObjective("npc3_alive"))
          key = "r_sarge_plans3_cody";
        if (key != string.Empty)
        {
          this.doc.lines.Add(new DialogueLine(GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), GameStrings.getString(GameStrings.dialogues, key), (TimelineFunction) null));
          this.doc.lines.Add(new DialogueLine(GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), GameStrings.getString(GameStrings.dialogues, "r_sarge_plans3_company"), (TimelineFunction) null));
        }
        else
          this.doc.lines.Add(new DialogueLine(GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), GameStrings.getString(GameStrings.dialogues, "r_sarge_plans3_single"), (TimelineFunction) null));
        DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_plans4", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
        ++i5;
      }
      this.takeDoc(i5);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_moon_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/moon");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("gasstation_sarge_moon");
      DialogueController.dc.initDialogue(this.doc.lines, "sarge_moon", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, RestaurantSarge.color);
      int i6 = i5 + 1;
      this.takeDoc(i6);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "sarge_spaceship_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/ship");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("gasstation_sarge_ship");
      DialogueController.dc.initDialogue(this.doc.lines, "sarge_spaceship", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, RestaurantSarge.color);
      int i7 = i6 + 1;
      if (GameDataController.gd.getObjective("r_paul_mount1") && !GameDataController.gd.getObjective("r_sarge_catcher"))
      {
        if (!GameDataController.gd.getObjective("r_sarge_catchers1"))
        {
          this.takeDoc(i7);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_sarge_catchers1_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/pylon2");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("r_sarge_catchers1");
          DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_catchers1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
          ++i7;
        }
        else if (!GameDataController.gd.getObjective("r_sarge_gun") || !GameDataController.gd.getObjective("r_sarge_ammo"))
        {
          this.takeDoc(i7);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_sarge_catchers2_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/pylon2");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("r_sarge_catchers2");
          DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_catchers2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
          ++i7;
        }
        else if (!GameDataController.gd.getObjective("r_sarge_catcher"))
        {
          this.takeDoc(i7);
          this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_sarge_catchers3_caption");
          this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/pylon2");
          this.doc.lines = new List<DialogueLine>();
          this.doc.setObjective("r_sarge_catchers3");
          DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_catchers3", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSarge.color);
          ++i7;
        }
      }
      this.takeDoc(i7);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "exit_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("r_sarge_first_bye");
      if (!GameDataController.gd.getObjective("r_sarge_first_bye"))
        DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_first_bye", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, RestaurantSarge.color);
      else
        DialogueController.dc.initDialogue(this.doc.lines, "r_sarge_bye", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, RestaurantSarge.color);
      this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalk);
      num = i7 + 1;
    }
    this.takeDoc(0);
    if (!(this.doc.caption != string.Empty))
      return;
    DialogueController.dc.talking = true;
  }

  public void endTalk(string val = "")
  {
    if (GameDataController.gd.getObjective("r_sarge_wounded1"))
      GameDataController.gd.setObjective("r_sarge_wounded2", true);
    DialogueController.dc.talking = false;
    DialogueController.dc.hide();
    this.updateState();
  }

  public void addConstruction(string val = "")
  {
    GameDataController.gd.setObjectiveDetail("map_construction_revealed", TravelAgency.LOCATION_STATUS_REACHABLE);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.page_turn_01);
  }

  private void Update()
  {
  }

  public override void updateState()
  {
    if (GameDataController.gd.getCurrentDay() != 3 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 1 || !GameDataController.gd.getObjective("sidereal_base_located"))
    {
      this.sarge.GetComponent<SpriteRenderer>().enabled = false;
      this.setCollider(-1);
    }
    else
    {
      this.sarge.GetComponent<SpriteRenderer>().enabled = true;
      this.setCollider(0);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
