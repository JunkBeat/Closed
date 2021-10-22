// Decompiled with JetBrains decompiler
// Type: DreamTiger
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class DreamTiger : ObjectActionController
{
  public GameObject tiger;
  public GameObject maggie;
  protected DialogueOptionController doc;
  public TextFieldController textField;
  private static Vector3 colorTiger = new Vector3(0.5254902f, 0.4745098f, 0.3568628f);
  private static Vector3 colorMaggie = new Vector3(0.6862745f, 0.3843137f, 0.4862745f);
  public Vector3 position;
  public Vector2 position2;
  public Vector3 position_b;
  public Vector2 position2_b;
  public DreamWraith dw;
  public SpriteShadow shadow;
  public SpriteShadow shadow2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_ne";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.actionType = ObjectActionController.Type.Talk;
    this.dkvs = GameStrings.objects;
    this.objectName = "dream_tiger";
    this.range = 1f;
    this.shadow = new SpriteShadow(this.tiger);
    this.shadow2 = new SpriteShadow(this.maggie);
    this.shadow.fadeRateV = 1f / 500f;
    this.shadow.fadeRateH = 1f / 500f;
    this.shadow.skewFactor = 25f;
    this.shadow.skewFactor2 = 0.0f;
    this.shadow.startAlpha = 0.75f;
    this.shadow.source = 180f;
    this.shadow.scaleFactor = 0.5f;
    this.shadow.downwards = true;
    this.shadow2.fadeRateV = 1f / 500f;
    this.shadow2.fadeRateH = 1f / 500f;
    this.shadow2.skewFactor = 25f;
    this.shadow2.skewFactor2 = 0.0f;
    this.shadow2.startAlpha = 0.75f;
    this.shadow2.source = 180f;
    this.shadow2.scaleFactor = 0.5f;
    this.shadow2.downwards = true;
    this.position = ScreenControler.roundToNearestFullPixel3(this.tiger.transform.position);
    this.tiger.transform.position = this.position;
    this.position2 = new Vector2(195f, 65f);
    this.position2_b = new Vector2(210f, 45f);
    this.shadow.offsetY = -1;
    this.shadow2.offsetY = -1;
    Vector2 vectorToChange = new Vector2();
    float z1 = this.tiger.transform.position.z;
    vectorToChange.x = this.position2.x;
    vectorToChange.y = this.position2.y;
    Vector2 screen1 = ScreenControler.gameToScreen(vectorToChange);
    this.position = new Vector3(screen1.x, screen1.y, this.tiger.transform.position.z);
    this.position.z = Camera.main.WorldToScreenPoint(this.tiger.transform.position).z;
    this.tiger.transform.position = Camera.main.ScreenToWorldPoint(this.position);
    this.tiger.transform.position = new Vector3(this.tiger.transform.position.x, this.tiger.transform.position.y, z1);
    float z2 = this.maggie.transform.position.z;
    screen1.x = this.position2_b.x;
    screen1.y = this.position2_b.y;
    Vector2 screen2 = ScreenControler.gameToScreen(screen1);
    this.position_b = new Vector3(screen2.x, screen2.y, this.maggie.transform.position.z);
    this.position_b.z = Camera.main.WorldToScreenPoint(this.maggie.transform.position).z;
    this.maggie.transform.position = Camera.main.ScreenToWorldPoint(this.position_b);
    this.maggie.transform.position = new Vector3(this.maggie.transform.position.x, this.maggie.transform.position.y, z2);
    this.updateState();
  }

  public override void whatOnClick0()
  {
  }

  public override void clickAction()
  {
    if (!(this.usedItem == string.Empty))
      return;
    if (!GameDataController.gd.getObjective("dream_tiger_future") && !GameDataController.gd.getObjective("dream_maggie_future"))
      this.initIntroDialogue();
    else if (GameDataController.gd.getObjective("previous_disc_barry") && GameDataController.gd.getObjective("previous_disc_cody"))
      this.tiger.GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.actions, "tiger_run"), quick: true, mwidth: 100, r: DreamTiger.colorTiger.x, g: DreamTiger.colorTiger.y, b: DreamTiger.colorTiger.z);
    else if (GameDataController.gd.getObjective("previous_disc_barry"))
    {
      this.tiger.GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.actions, "tiger_run"), quick: true, mwidth: 100, r: DreamTiger.colorTiger.x, g: DreamTiger.colorTiger.y, b: DreamTiger.colorTiger.z);
    }
    else
    {
      if (!GameDataController.gd.getObjective("previous_disc_cody"))
        return;
      this.maggie.GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.actions, "maggie_run"), quick: true, mwidth: 100, r: DreamTiger.colorMaggie.x, g: DreamTiger.colorMaggie.y, b: DreamTiger.colorMaggie.z);
    }
  }

  public void initIntroDialogue()
  {
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    if (GameDataController.gd.getObjective("previous_disc_cody") && GameDataController.gd.getObjective("previous_disc_barry"))
    {
      GameDataController.gd.setObjective("dream_maggie_intro", true);
      DialogueController.dc.initDialogue(dialogueLines, "dream_maggie_tiger_intro", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.tiger.GetComponent<TextFieldController>(), DreamTiger.colorTiger, GameObject.Find("maggie_sprite").GetComponent<TextFieldController>(), DreamTiger.colorMaggie);
    }
    else if (GameDataController.gd.getObjective("previous_disc_barry"))
    {
      GameDataController.gd.setObjective("dream_tiger_intro", true);
      DialogueController.dc.initDialogue(dialogueLines, "dream_tiger_intro", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.tiger.GetComponent<TextFieldController>(), DreamTiger.colorTiger, GameObject.Find("maggie_sprite").GetComponent<TextFieldController>(), DreamTiger.colorMaggie);
    }
    else if (GameDataController.gd.getObjective("previous_disc_cody"))
    {
      GameDataController.gd.setObjective("dream_maggie_intro", true);
      DialogueController.dc.initDialogue(dialogueLines, "dream_maggie_intro", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("maggie_sprite").GetComponent<TextFieldController>(), DreamTiger.colorMaggie);
    }
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    DialogueController.dc.callback = new DialogueController.Callback(this.dialogues);
    this.dialogues();
  }

  public void takeDoc(int i) => this.doc = DialogueController.dc.dialogueOptions[i].GetComponent<DialogueOptionController>();

  public void dialogues()
  {
    DialogueController.dc.reset();
    int i = 0;
    if (GameDataController.gd.getObjective("previous_disc_barry"))
    {
      this.takeDoc(i);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dream_tiger_who_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/tiger");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dream_tiger_who");
      DialogueController.dc.initDialogue(this.doc.lines, "dream_tiger_who", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.tiger.GetComponent<TextFieldController>(), DreamTiger.colorTiger, GameObject.Find("maggie_sprite").GetComponent<TextFieldController>(), DreamTiger.colorMaggie);
      ++i;
    }
    if (GameDataController.gd.getObjective("previous_disc_barry"))
    {
      this.takeDoc(i);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dream_tiger_remember_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/dream");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dream_tiger_remember");
      DialogueController.dc.initDialogue(this.doc.lines, "dream_tiger_remember", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.tiger.GetComponent<TextFieldController>(), DreamTiger.colorTiger, GameObject.Find("maggie_sprite").GetComponent<TextFieldController>(), DreamTiger.colorMaggie);
      ++i;
    }
    if (GameDataController.gd.getObjective("previous_disc_cody"))
    {
      this.takeDoc(i);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dream_maggie_who_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/dead_wife");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dream_maggie_who");
      DialogueController.dc.initDialogue(this.doc.lines, "dream_maggie_who", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("maggie_sprite").GetComponent<TextFieldController>(), DreamTiger.colorMaggie);
      ++i;
    }
    if (GameDataController.gd.getObjective("previous_disc_cody"))
    {
      this.takeDoc(i);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dream_maggie_remember_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/dream");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dream_maggie_remember");
      DialogueController.dc.initDialogue(this.doc.lines, "dream_maggie_remember", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("maggie_sprite").GetComponent<TextFieldController>(), DreamTiger.colorMaggie);
      ++i;
    }
    if (GameDataController.gd.getObjective("previous_disc_barry") && !GameDataController.gd.getObjective("previous_disc_cody"))
    {
      if (GameDataController.gd.getObjective("dream_tiger_remember") && GameDataController.gd.getObjective("dream_tiger_who"))
      {
        this.takeDoc(i);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dream_tiger_cody_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/cody");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dream_tiger_cody");
        DialogueController.dc.initDialogue(this.doc.lines, "dream_tiger_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.tiger.GetComponent<TextFieldController>(), DreamTiger.colorTiger, GameObject.Find("maggie_sprite").GetComponent<TextFieldController>(), DreamTiger.colorMaggie);
        ++i;
      }
      if (GameDataController.gd.getObjective("dream_tiger_cody"))
      {
        this.takeDoc(i);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dream_tiger_future_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/where_go");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dream_tiger_future");
        DialogueController.dc.initDialogue(this.doc.lines, "dream_tiger_future", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.tiger.GetComponent<TextFieldController>(), DreamTiger.colorTiger, GameObject.Find("maggie_sprite").GetComponent<TextFieldController>(), DreamTiger.colorMaggie);
        this.doc.lines[this.doc.lines.Count - 6].action = new TimelineFunction(this.shadowpep);
        this.doc.lines[this.doc.lines.Count - 4].action = new TimelineFunction(this.shadowpep2);
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalk);
        ++i;
      }
    }
    if (GameDataController.gd.getObjective("previous_disc_cody") && !GameDataController.gd.getObjective("previous_disc_barry"))
    {
      if (GameDataController.gd.getObjective("dream_maggie_remember") && GameDataController.gd.getObjective("dream_maggie_who"))
      {
        this.takeDoc(i);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dream_maggie_barry_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/barry");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dream_maggie_barry");
        DialogueController.dc.initDialogue(this.doc.lines, "dream_maggie_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("maggie_sprite").GetComponent<TextFieldController>(), DreamTiger.colorMaggie);
        ++i;
      }
      if (GameDataController.gd.getObjective("dream_maggie_barry"))
      {
        this.takeDoc(i);
        this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dream_maggie_future_caption");
        this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/where_go");
        this.doc.lines = new List<DialogueLine>();
        this.doc.setObjective("dream_maggie_future");
        DialogueController.dc.initDialogue(this.doc.lines, "dream_maggie_future", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("maggie_sprite").GetComponent<TextFieldController>(), DreamTiger.colorMaggie);
        this.doc.lines[this.doc.lines.Count - 8].action = new TimelineFunction(this.shadowpep);
        this.doc.lines[this.doc.lines.Count - 6].action = new TimelineFunction(this.shadowpep2);
        this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalk);
        ++i;
      }
    }
    if (GameDataController.gd.getObjective("previous_disc_cody") && GameDataController.gd.getObjective("previous_disc_barry") && GameDataController.gd.getObjective("dream_maggie_remember") && GameDataController.gd.getObjective("dream_maggie_who") && GameDataController.gd.getObjective("dream_tiger_remember") && GameDataController.gd.getObjective("dream_tiger_who"))
    {
      this.takeDoc(i);
      this.doc.caption = GameStrings.getString(GameStrings.dialogues, "dream_maggie_tiger_future_caption");
      this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/where_go");
      this.doc.lines = new List<DialogueLine>();
      this.doc.setObjective("dream_maggie_future");
      DialogueController.dc.initDialogue(this.doc.lines, "dream_maggie_tiger_future", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("maggie_sprite").GetComponent<TextFieldController>(), DreamTiger.colorMaggie, this.tiger.GetComponent<TextFieldController>(), DreamTiger.colorTiger);
      this.doc.lines[this.doc.lines.Count - 8].action = new TimelineFunction(this.shadowpep);
      this.doc.lines[this.doc.lines.Count - 6].action = new TimelineFunction(this.shadowpep2);
      this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalk);
      int num = i + 1;
      GameDataController.gd.setObjective("dream_tiger_future", true);
    }
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
    this.dw.gogogo2 = true;
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_scare);
  }

  public void shadowpep(string val = "") => this.dw.gogogo = true;

  public void shadowpep2(string val = "")
  {
    PlayerController.wc.forceAnimation("stand_e", true);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.dumdumdum, 1f);
  }

  private void Update()
  {
    if (this.tiger.GetComponent<SpriteRenderer>().enabled)
      this.shadow.update(this.position, this.position2, 20);
    if (!this.maggie.GetComponent<SpriteRenderer>().enabled)
      return;
    this.shadow2.update(this.position_b, this.position2_b, 20);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("previous_disc_barry") && GameDataController.gd.getObjective("previous_disc_cody"))
    {
      this.tiger.GetComponent<SpriteRenderer>().enabled = true;
      this.maggie.GetComponent<SpriteRenderer>().enabled = true;
      this.setCollider(2);
      this.objectName = "dream_tiger_maggie";
    }
    else if (GameDataController.gd.getObjective("previous_disc_barry") && !GameDataController.gd.getObjective("previous_disc_cody"))
    {
      this.tiger.GetComponent<SpriteRenderer>().enabled = true;
      this.maggie.GetComponent<SpriteRenderer>().enabled = false;
      this.maggie.transform.position = new Vector3(-100f, -100f, -100f);
      this.setCollider(0);
      this.objectName = "dream_tiger";
    }
    else if (GameDataController.gd.getObjective("previous_disc_cody") && !GameDataController.gd.getObjective("previous_disc_barry"))
    {
      this.maggie.GetComponent<SpriteRenderer>().enabled = true;
      this.tiger.GetComponent<SpriteRenderer>().enabled = false;
      this.tiger.transform.position = new Vector3(-100f, -100f, -100f);
      this.setCollider(1);
      this.objectName = "dream_maggie";
    }
    else
    {
      this.tiger.GetComponent<SpriteRenderer>().enabled = false;
      this.maggie.GetComponent<SpriteRenderer>().enabled = false;
      this.setCollider(-1);
      this.maggie.transform.position = new Vector3(-100f, -100f, -100f);
      this.tiger.transform.position = new Vector3(-100f, -100f, -100f);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
