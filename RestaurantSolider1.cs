// Decompiled with JetBrains decompiler
// Type: RestaurantSolider1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class RestaurantSolider1 : ObjectActionController
{
  public GameObject sarge;
  protected DialogueOptionController doc;
  public TextFieldController textField;
  public static Vector3 color = new Vector3(0.6980392f, 1f, 0.7882353f);
  public SpriteShadow shadow;
  public int joshOffset = 20;
  public Vector3 position;
  public Vector2 position2;
  public bool enabledd;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.actionType = ObjectActionController.Type.Talk;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_solider_1";
    this.range = 30f;
    this.position = ScreenControler.roundToNearestFullPixel3(this.sarge.transform.position);
    this.sarge.transform.position = this.position;
    this.position2 = new Vector2(74f, 30f);
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
    DialogueController.dc.initDialogue(dialogueLines, "r_josh_intro1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.sarge.GetComponent<TextFieldController>(), RestaurantSolider1.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    DialogueController.dc.callback = new DialogueController.Callback(this.dialogues);
    this.dialogues();
  }

  public void takeDoc(int i) => this.doc = DialogueController.dc.dialogueOptions[i].GetComponent<DialogueOptionController>();

  public void dialogues()
  {
    DialogueController.dc.reset();
    int i1 = 0;
    this.takeDoc(i1);
    this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_josh_sarge1_caption");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/sarge");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective("r_josh_sarge1");
    DialogueController.dc.initDialogue(this.doc.lines, "r_josh_sarge1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSolider1.color);
    int i2 = i1 + 1;
    this.takeDoc(i2);
    this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_josh_come1_caption");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/sarge_ship");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective("r_josh_come1");
    DialogueController.dc.initDialogue(this.doc.lines, "r_josh_come1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), this.textField, RestaurantSolider1.color);
    int i3 = i2 + 1;
    this.takeDoc(i3);
    this.doc.caption = GameStrings.getString(GameStrings.dialogues, "exit_caption");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective("r_josh_bye1");
    DialogueController.dc.initDialogue(this.doc.lines, "r_josh_bye1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, RestaurantSolider1.color);
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
    if (!this.enabledd)
      return;
    this.shadow.offsetY = this.joshOffset;
    this.shadow.update(this.position, new Vector2(this.position2.x, 10f), 0);
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
      this.shadow.offsetY = this.joshOffset;
      this.shadow.scaleFactor = 0.3f;
      this.shadow.downwards = true;
      this.sarge.GetComponent<SpriteRenderer>().enabled = true;
      this.setCollider(0);
      if (GameDataController.gd.getObjective("restaurant_sarge_encountered"))
        this.sarge.GetComponent<Animator>().Play("solider1_guard_loop");
      else
        this.sarge.GetComponent<Animator>().Play("solider1_aim_start");
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
