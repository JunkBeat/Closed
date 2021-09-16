// Decompiled with JetBrains decompiler
// Type: DreamMaggie
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class DreamMaggie : ObjectActionController
{
  public GameObject sarge;
  protected DialogueOptionController doc;
  public TextFieldController textField;
  private static Vector3 color = new Vector3(0.6f, 0.4156863f, 0.4f);
  public Vector3 position;
  public Vector2 position2;
  public GameObject actionmarker1;
  public GameObject actionmarker2;
  public SpriteShadow shadow;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = true;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.actionType = ObjectActionController.Type.Talk;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_freezer";
    this.range = 30f;
    this.shadow = new SpriteShadow(this.sarge);
    this.shadow.fadeRateV = 1f / 500f;
    this.shadow.fadeRateH = 1f / 500f;
    this.shadow.skewFactor = 25f;
    this.shadow.skewFactor2 = 0.0f;
    this.shadow.startAlpha = 0.75f;
    this.shadow.source = 180f;
    this.shadow.scaleFactor = 0.75f;
    this.shadow.downwards = true;
    this.position = ScreenControler.roundToNearestFullPixel3(this.sarge.transform.position);
    this.sarge.transform.position = this.position;
    this.position2 = new Vector2(210f, 45f);
    this.shadow.offsetY = 18;
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

  public override void whatOnClick0()
  {
    if (this.usedItem != string.Empty)
    {
      this.actionMarker = this.actionmarker2;
      this.range = 4f;
    }
    else
    {
      this.actionMarker = this.actionmarker1;
      this.range = 30f;
    }
  }

  public override void clickAction()
  {
    if (!(this.usedItem == string.Empty))
      return;
    this.initIntroDialogue();
  }

  public void initIntroDialogue()
  {
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    if (!GameDataController.gd.getObjective("r_steve_intro1"))
    {
      GameDataController.gd.setObjective("r_steve_intro1", true);
      DialogueController.dc.initDialogue(dialogueLines, "r_steve_intro1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.sarge.GetComponent<TextFieldController>(), DreamMaggie.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    }
    else
      DialogueController.dc.initDialogue(dialogueLines, "r_steve_intro2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.sarge.GetComponent<TextFieldController>(), DreamMaggie.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
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
    this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_steve_come1_caption");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/sarge_ship");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective("r_steve_come1");
    DialogueController.dc.initDialogue(this.doc.lines, "r_steve_come1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, DreamMaggie.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    int i2 = i1 + 1;
    string empty = string.Empty;
    string prefix = !GameDataController.gd.getObjective("r_sarge_wounded_bandage") || !GameDataController.gd.getObjective("r_sarge_wounded_bandage") ? (!GameDataController.gd.getObjective("r_sarge_wounded_alcohol") ? (!GameDataController.gd.getObjective("r_sarge_wounded_bandage") ? "r_steve_you2" : "r_steve_you3") : "r_steve_you4") : string.Empty;
    if (GameDataController.gd.getObjective("r_sarge_wounded_bandage") && GameDataController.gd.getObjective("r_sarge_wounded_alcohol"))
    {
      this.takeDoc(i2);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_steve_you1_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/wounded");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("r_steve_you1");
      DialogueController.dc.initDialogue(this.doc.lines, "r_steve_you5", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, DreamMaggie.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    }
    else
    {
      this.takeDoc(i2);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "r_steve_you1_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/wounded");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("r_steve_you1");
      DialogueController.dc.initDialogue(this.doc.lines, "r_steve_you1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, DreamMaggie.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
      DialogueController.dc.initDialogue(this.doc.lines, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, DreamMaggie.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    }
    int i3 = i2 + 1;
    this.takeDoc(i3);
    this.doc.caption = GameStrings.getString(GameStrings.dialogues, "exit_caption");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective("r_steve_bye_1");
    DialogueController.dc.initDialogue(this.doc.lines, "r_steve_bye_1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.textField, DreamMaggie.color, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalk);
    int num = i3 + 1;
    this.takeDoc(0);
    if (!(this.doc.caption != string.Empty))
      return;
    DialogueController.dc.talking = true;
  }

  public void endTalk(string val = "")
  {
    DialogueController.dc.talking = false;
    DialogueController.dc.hide();
    this.updateState();
  }

  private void Update() => this.shadow.update(this.position, this.position2, 20);

  public override void updateState()
  {
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
