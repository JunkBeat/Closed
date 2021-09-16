// Decompiled with JetBrains decompiler
// Type: LanguageSelectorButton
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class LanguageSelectorButton : ObjectActionController
{
  public Sprite flag_pl;
  public Sprite flag_en;
  public Sprite flag_de;
  public SpriteRenderer flag;
  public LanguageSelectorCaption languageSelectorCaption;
  protected DialogueOptionController doc;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = string.Empty;
    this.range = 999f;
    this.updateState();
  }

  public void takeDoc(int i) => this.doc = DialogueController.dc.dialogueOptions[i].GetComponent<DialogueOptionController>();

  public override void clickAction()
  {
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(23f, 21f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    GameObject.Find("BottomText").transform.position = worldPoint;
    this.languageSelectorCaption.hideText();
    DialogueController.dc.callback = (DialogueController.Callback) null;
    this.takeDoc(0);
    MonoBehaviour.print((object) "PICKING LANGUAGE");
    DialogueController.dc.reset();
    int i1 = 0;
    this.takeDoc(i1);
    this.doc.caption = GameStrings.getString(GameStrings.languages, GameStrings.Language.EN.ToString());
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/l_eng");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.changeLanguage);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = GameStrings.Language.EN.ToString();
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int i2 = i1 + 1;
    this.doc.caption = GameStrings.getString(GameStrings.languages, GameStrings.Language.PL.ToString());
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/l_pl");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective(string.Empty);
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.changeLanguage);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = GameStrings.Language.PL.ToString();
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    this.takeDoc(i2);
    this.doc.caption = GameStrings.getString(GameStrings.languages, GameStrings.Language.DE.ToString());
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/l_de");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective(string.Empty);
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.changeLanguage);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = GameStrings.Language.DE.ToString();
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    this.doc.caption = GameStrings.getString(GameStrings.gui, "cancel");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective(string.Empty);
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalk);
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    int num = i2 + 1;
    this.takeDoc(0);
    if (!(this.doc.caption != string.Empty))
      return;
    DialogueController.dc.talking = true;
  }

  public void changeLanguage(string lang)
  {
    PlayerPrefs.SetString(nameof (lang), lang);
    PlayerPrefs.Save();
    GameStrings.readStrings(lang);
    ItemsManager.im.reloadAfterLanguageChange();
    this.endTalk(string.Empty);
    GameObject.Find("Caption").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "font_pick0"), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    GameObject.Find("Caption2").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "font_pick3"), quick: true, instant: true, mwidth: 100, ba: 0.0f);
    Button component1 = GameObject.Find("PixelBtn").GetComponent<Button>();
    component1.buttonText.viewText("[" + GameStrings.getString(GameStrings.gui, "font_pick1") + "]", quick: true, instant: true, mwidth: 200);
    component1.buttonText.keepAlive = true;
    component1.buttonText.setTextColor(1f, 0.73f, 0.0f);
    component1.buttonText.black.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    Button component2 = GameObject.Find("SmoothBtn").GetComponent<Button>();
    component2.buttonText.viewText("[" + GameStrings.getString(GameStrings.gui, "font_pick2") + "]", quick: true, instant: true, mwidth: 200);
    component2.buttonText.keepAlive = true;
    component2.buttonText.setTextColor(1f, 0.73f, 0.0f);
    component2.buttonText.black.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
  }

  public void endTalk(string val = "")
  {
    this.languageSelectorCaption.updateText();
    DialogueController.dc.talking = false;
    DialogueController.dc.hide();
    this.updateState();
  }

  public override void updateState()
  {
    this.languageSelectorCaption.updateText();
    if (PlayerPrefs.GetString("lang", GameStrings.Language.EN.ToString()) == GameStrings.Language.EN.ToString())
      this.flag.sprite = this.flag_en;
    if (PlayerPrefs.GetString("lang", GameStrings.Language.EN.ToString()) == GameStrings.Language.PL.ToString())
      this.flag.sprite = this.flag_pl;
    if (!(PlayerPrefs.GetString("lang", GameStrings.Language.DE.ToString()) == GameStrings.Language.DE.ToString()))
      return;
    this.flag.sprite = this.flag_de;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}
