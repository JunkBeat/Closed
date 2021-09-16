// Decompiled with JetBrains decompiler
// Type: RestauranPaul
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class RestauranPaul : ObjectActionController
{
  public GameObject sarge;
  protected DialogueOptionController doc;
  public TextFieldController textField;
  private static Vector3 color = new Vector3(0.9921569f, 0.4156863f, 0.007843138f);
  public SpriteShadow shadow;
  public Vector3 position;
  public Vector2 position2;
  public Sprite last;
  private bool enabledd;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_se";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.actionType = ObjectActionController.Type.Talk;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_solider_4";
    this.range = 10f;
    this.position = ScreenControler.roundToNearestFullPixel3(this.sarge.transform.position);
    this.sarge.transform.position = this.position;
    this.position2 = new Vector2(115f, 65f);
    Vector2 vectorToChange = new Vector2();
    float z = this.sarge.transform.position.z;
    vectorToChange.x = this.position2.x;
    vectorToChange.y = this.position2.y;
    Vector2 screen = ScreenControler.gameToScreen(vectorToChange);
    this.position = new Vector3(screen.x, screen.y, this.sarge.transform.position.z);
    this.position.z = Camera.main.WorldToScreenPoint(this.sarge.transform.position).z;
    this.sarge.transform.position = Camera.main.ScreenToWorldPoint(this.position);
    this.sarge.transform.position = new Vector3(this.sarge.transform.position.x, this.sarge.transform.position.y, z);
    this.updateState();
  }

  public override void clickAction() => this.initIntroDialogue();

  public void initIntroDialogue()
  {
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    if (!GameDataController.gd.getObjective("r_paul_intro1"))
    {
      GameDataController.gd.setObjective("r_paul_intro1", true);
      DialogueController.dc.initDialogue(dialogueLines, "r_paul_intro1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.sarge.GetComponent<TextFieldController>(), RestauranPaul.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    }
    else
      DialogueController.dc.initDialogue(dialogueLines, "r_paul_intro2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.sarge.GetComponent<TextFieldController>(), RestauranPaul.color);
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    DialogueController.dc.callback = new DialogueController.Callback(this.dialogues);
    this.dialogues();
  }

  public void takeDoc(int i) => this.doc = DialogueController.dc.dialogueOptions[i].GetComponent<DialogueOptionController>();

  public void gingerTurn(string a = "") => GameObject.Find("Ginger").GetComponent<NPCWalkController>().forceAnimation("stand_ne");

  public void dialogues()
  {
    DialogueController.dc.reset();
    int i1 = 0;
    this.takeDoc(i1);
    this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_paul_catchers1_caption");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/storm");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective("r_paul_catchers1");
    DialogueController.dc.initDialogue(this.doc.lines, "r_paul_catchers1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, RestauranPaul.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    this.doc.lines[0].action = new TimelineFunction(this.gingerTurn);
    int i2 = i1 + 1;
    if (GameDataController.gd.getObjective("r_paul_catchers1") && !GameDataController.gd.getObjective("r_paul_catchers_given"))
    {
      if (!GameDataController.gd.getObjective("r_paul_catchers2"))
      {
        this.takeDoc(i2);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_paul_catchers2_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/storm2");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("r_paul_catchers2");
        DialogueController.dc.initDialogue(this.doc.lines, "r_paul_catchers2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, RestauranPaul.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
        this.doc.lines[0].action = new TimelineFunction(this.gingerTurn);
      }
      else
      {
        this.takeDoc(i2);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_paul_catchers4_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/storm2");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("r_paul_catchers4");
        DialogueController.dc.initDialogue(this.doc.lines, "r_paul_catchers4", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, RestauranPaul.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
        this.doc.lines[0].action = new TimelineFunction(this.gingerTurn);
      }
      if (!GameDataController.gd.getObjective("r_sarge_wounded_bandage") || !GameDataController.gd.getObjective("r_sarge_wounded_alcohol"))
      {
        string empty = string.Empty;
        string prefix = GameDataController.gd.getObjective("r_paul_catchers2") ? "r_paul_catchers5" : "r_paul_catchers3";
        DialogueController.dc.initDialogue(this.doc.lines, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, RestauranPaul.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
        this.doc.lines[0].action = new TimelineFunction(this.gingerTurn);
      }
      else
      {
        this.doc.setObjective("r_paul_catchers6");
        DialogueController.dc.initDialogue(this.doc.lines, "r_paul_catchers6", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, RestauranPaul.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
        this.doc.lines[0].action = new TimelineFunction(this.gingerTurn);
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.giveCatchers);
      }
      ++i2;
    }
    if (GameDataController.gd.getObjective("r_paul_catchers_given"))
    {
      this.takeDoc(i2);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_paul_catchers7_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/storm_catcher");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("r_paul_catchers7");
      DialogueController.dc.initDialogue(this.doc.lines, "r_paul_catchers7", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, RestauranPaul.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
      this.doc.lines[0].action = new TimelineFunction(this.gingerTurn);
      ++i2;
    }
    if (GameDataController.gd.getObjective("r_paul_catchers_given") && GameDataController.gd.getObjective("r_paul_mount1") && GameDataController.gd.getObjective("r_sarge_gun") && GameDataController.gd.getObjective("r_sarge_ammo"))
    {
      this.takeDoc(i2);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_paul_mount2_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/pylon2");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("r_paul_mount2");
      DialogueController.dc.initDialogue(this.doc.lines, "r_paul_mount2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, RestauranPaul.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
      this.doc.lines[0].action = new TimelineFunction(this.gingerTurn);
      ++i2;
    }
    else if (GameDataController.gd.getObjective("r_paul_catchers7"))
    {
      this.takeDoc(i2);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_paul_mount1_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/pylon");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("r_paul_mount1");
      DialogueController.dc.initDialogue(this.doc.lines, "r_paul_mount1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, RestauranPaul.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
      this.doc.lines[0].action = new TimelineFunction(this.gingerTurn);
      ++i2;
    }
    this.takeDoc(i2);
    this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_paul_come1_caption");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/sarge_ship");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective("r_paul_come1");
    DialogueController.dc.initDialogue(this.doc.lines, "r_paul_come1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, RestauranPaul.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    this.doc.lines[0].action = new TimelineFunction(this.gingerTurn);
    int i3 = i2 + 1;
    this.takeDoc(i3);
    this.doc.caption = GameStrings.getString(GameStrings.dialogues, "exit_caption");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective("r_paul_bye1");
    DialogueController.dc.initDialogue(this.doc.lines, "r_paul_bye1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, RestauranPaul.color);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalk);
    int num = i3 + 1;
    this.takeDoc(0);
    if (!(this.doc.caption != string.Empty))
      return;
    DialogueController.dc.talking = true;
  }

  public void giveCatchers(string val = "")
  {
    GameDataController.gd.setObjective("r_paul_catchers_given", true);
    InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("stormcatcher1"));
    InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("stormcatcher2"));
    InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("stormcatcher3"));
  }

  public void endTalk(string val = "")
  {
    if (GameDataController.gd.getObjective("r_sarge_wounded1"))
      GameDataController.gd.setObjective("r_sarge_wounded2", true);
    DialogueController.dc.talking = false;
    DialogueController.dc.hide();
    this.updateState();
  }

  private void Update()
  {
    if (!this.sarge.GetComponent<SpriteRenderer>().enabled || !((Object) this.last != (Object) this.sarge.GetComponent<SpriteRenderer>().sprite))
      return;
    this.shadow.update(this.position, new Vector2(this.position2.x, 45f), 0);
    this.last = this.sarge.GetComponent<SpriteRenderer>().sprite;
  }

  public override void updateState()
  {
    if (GameDataController.gd.getCurrentDay() != 3 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 1 || !GameDataController.gd.getObjective("sidereal_base_located"))
    {
      this.sarge.GetComponent<SpriteRenderer>().enabled = false;
      this.setCollider(-1);
      this.enabledd = false;
    }
    else
    {
      this.enabledd = true;
      this.shadow = new SpriteShadow(this.sarge);
      this.shadow.fadeRateV = 0.0f;
      this.shadow.fadeRateH = 0.0f;
      this.shadow.skewFactor = 0.0f;
      this.shadow.skewFactor2 = 15f;
      this.shadow.startAlpha = 0.5f;
      this.shadow.source = 140f;
      this.shadow.scaleFactor = 0.3f;
      this.shadow.downwards = true;
      this.shadow.offsetY = 20;
      this.sarge.GetComponent<SpriteRenderer>().enabled = true;
      this.setCollider(0);
      if (GameDataController.gd.getObjective("restaurant_sarge_encountered"))
        this.sarge.GetComponent<Animator>().Play("solider4_guard_loop");
      else
        this.sarge.GetComponent<Animator>().Play("solider4_aim");
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
