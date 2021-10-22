// Decompiled with JetBrains decompiler
// Type: ClockController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
  private string frame_name_sufix;
  private string sufix_minutes;
  private string sufix_hours;
  private int equip_i;
  public GameObject minutesHand;
  public GameObject hoursHand;
  private SpriteRenderer spriteRenderer1;
  private SpriteRenderer spriteRenderer2;
  private SpriteRenderer spriteRenderer3;
  public Sprite invEquip;
  public Sprite waitBcg;
  protected DialogueOptionController doc;

  private void Start()
  {
    this.sufix_minutes = "0";
    this.sufix_hours = "0";
    if (GameDataController.gd.getObjective("wall_encountered"))
      this.show();
    else
      this.hide();
  }

  public void showClock(string param = "")
  {
    this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
    this.Invoke("show", 0.25f);
    this.Invoke("hide", 0.5f);
    this.Invoke("show", 0.75f);
    this.Invoke("hide", 1f);
    this.Invoke("show", 1.25f);
    this.Invoke("hide", 1.5f);
    this.Invoke("show", 1.75f);
    this.Invoke("hide", 2f);
    this.Invoke("showFinal", 2.25f);
  }

  public void showFinal()
  {
    this.show();
    this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
  }

  private void show()
  {
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(205f, 125f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -2.5f;
    this.gameObject.transform.position = worldPoint;
  }

  public void hide()
  {
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(-9999f, -9999f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -4f;
    this.gameObject.transform.position = worldPoint;
  }

  public static string getClockTimeWithRemaining()
  {
    string str1 = GameStrings.getString(GameStrings.gui, "left_prefix");
    if (str1.Length > 0)
      str1 += " ";
    string str2 = GameStrings.getString(GameStrings.gui, "left");
    if (str2.Length > 0)
      str2 = " " + str2;
    return ClockController.getClockTime() + " (" + str1 + ClockController.getTimeLeft() + str2 + ")";
  }

  public static Vector3 getTimeColor()
  {
    int num = GameDataController.gd.timeLimit - GameDataController.gd.gameTime;
    Vector3 vector3 = new Vector3(1f, 1f, 1f);
    if (num < 120)
      vector3 = new Vector3(1f, 1f, 0.0f);
    if (num < 60)
      vector3 = new Vector3(1f, 0.0f, 0.0f);
    return vector3;
  }

  public static bool advanceTime(int amount, bool traveling = false)
  {
    GameDataController.gd.gameTime += amount;
    if (traveling)
      GameDataController.gd.traveledTime += amount;
    else
      GameDataController.gd.workedTime += amount;
    if (GameDataController.gd.gameTime < GameDataController.gd.timeLimit)
      return true;
    GameDataController.gd.gameTime -= amount;
    GameDataController.gd.equipped = string.Empty;
    GameDataController.gd.setObjective("ship_launched", false);
    ClockController.endTime(true);
    return false;
  }

  public static void endTime(bool accident = false)
  {
    if (GameDataController.gd.getCurrentDay() == 1)
      GameDataController.gd.saveIfOK(GameDataController.CHAPTER_1_COMPLETE_AUTOSAVE);
    if (GameDataController.gd.getCurrentDay() == 2)
      GameDataController.gd.saveIfOK(GameDataController.CHAPTER_2_COMPLETE_AUTOSAVE);
    if (GameDataController.gd.getCurrentDay() == 3)
      GameDataController.gd.saveIfOK(GameDataController.CHAPTER_3_COMPLETE_AUTOSAVE);
    if (GameDataController.gd.getCurrentDay() == 4)
      GameDataController.gd.saveIfOK(GameDataController.CHAPTER_4_COMPLETE_AUTOSAVE);
    GameDataController.gd.previousLocation = GameDataController.gd.location;
    PlayerController.pc.spawnName = "LocationDefaultSpawn";
    CurtainController.cc.fadeOut("ChapterResults", WalkController.Direction.W);
  }

  public static string getClockTime(int timeToTranslate = -1)
  {
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    int num1 = timeToTranslate != -1 ? timeToTranslate : GameDataController.gd.gameTime;
    int num2 = num1 / 60;
    int num3 = num1 % 60;
    if (GameStrings.getString(GameStrings.gui, "am") != "-")
    {
      if (num2 < 12)
      {
        empty2 = GameStrings.getString(GameStrings.gui, "am");
      }
      else
      {
        empty2 = GameStrings.getString(GameStrings.gui, "pm");
        if (empty2.Length > 0)
          num2 -= 12;
      }
    }
    if (num2 == 0 && empty2.Length > 0)
      num2 = 12;
    if (num2 < 10)
      empty1 += "0";
    string str = empty1 + num2.ToString() + ":";
    if (num3 < 10)
      str += "0";
    return str + (object) num3 + " " + empty2;
  }

  public static string getTimeLeft()
  {
    string str = string.Empty;
    int num1 = GameDataController.gd.timeLimit - GameDataController.gd.gameTime;
    int num2 = num1 / 60;
    int num3 = num1 % 60;
    if (num2 > 1)
      str = str + num2.ToString() + " " + GameStrings.getString(GameStrings.gui, "hours");
    else if (num2 == 1)
      str = str + num2.ToString() + " " + GameStrings.getString(GameStrings.gui, "hour");
    if (num2 > 0 && num3 > 0)
      str += " ";
    if (num3 > 1)
      str = str + num3.ToString() + " " + GameStrings.getString(GameStrings.gui, "minutes");
    else if (num3 == 1)
      str = str + num3.ToString() + " " + GameStrings.getString(GameStrings.gui, "minute");
    return str;
  }

  private void Update()
  {
    for (int index = 0; index < 12; ++index)
    {
      if (GameDataController.gd.gameTime >= 60 * index && GameDataController.gd.gameTime < 60 * (index + 1) || GameDataController.gd.gameTime >= 60 * (index + 12) && GameDataController.gd.gameTime < 60 * (index + 13))
        this.sufix_hours = index.ToString();
    }
    for (int index = 0; index < 60; ++index)
    {
      int num = GameDataController.gd.gameTime % 60;
      if (num >= 5 * index && num < 5 * (index + 1))
        this.sufix_minutes = index.ToString();
    }
    this.minutesHand.GetComponent<Animator>().Play("clock_hand1_" + this.sufix_minutes, 0);
    this.hoursHand.GetComponent<Animator>().Play("clock_hand2_" + this.sufix_hours, 0);
  }

  private void OnMouseOver()
  {
    if (!PlayerController.wc.busy && PlayerController.pc.dialogue == PlayerController.DialogueState.NONE)
    {
      GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>().showCursor(CursorController.PixelCursor.ACTIVE);
      if (!(this.frame_name_sufix != "1"))
        return;
      this.frame_name_sufix = "1";
      this.gameObject.GetComponent<Animator>().Play("clock_" + this.frame_name_sufix, 0);
      GameObject gameObject = GameObject.Find("BottomText");
      string text = ClockController.getClockTimeWithRemaining() + " ^" + GameStrings.getString(GameStrings.gui, "clock");
      Vector3 timeColor = ClockController.getTimeColor();
      gameObject.GetComponent<TextFieldController>().viewText(text, quick: true, mwidth: BottomTextController.bottomTextWidth, r: timeColor.x, g: timeColor.y, b: timeColor.z);
    }
    else
      this.OnMouseExit();
  }

  private void OnMouseExit()
  {
    if (PlayerController.wc.busy && PlayerController.pc.dialogue != PlayerController.DialogueState.NONE)
      return;
    this.hideText();
  }

  public void hideText()
  {
    GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>().showCursor(CursorController.PixelCursor.NORMAL);
    GameObject.Find("BottomText").GetComponent<TextFieldController>().keepAlive = false;
    this.frame_name_sufix = "0";
    this.gameObject.GetComponent<Animator>().Play("clock_" + this.frame_name_sufix, 0);
  }

  public void takeDoc(int i) => this.doc = DialogueController.dc.dialogueOptions[i].GetComponent<DialogueOptionController>();

  public void endTalk(string val = "")
  {
    PlayerController.pc.clickedSomething = true;
    DialogueController.dc.talking = false;
    DialogueController.dc.hide();
  }

  public void equipItem(string item)
  {
    if (GameDataController.gd.getCurrentDay() == 4)
      GameDataController.gd.setObjective("ship_launched", true);
    GameDataController.gd.equipped = item;
    this.endTalk(string.Empty);
    ClockController.endTime();
  }

  private void OnMouseDown()
  {
    if (PlayerController.wc.busy || PlayerController.pc.dialogue != PlayerController.DialogueState.NONE)
      return;
    PlayerController.pc.clickedSomething = true;
    this.hideText();
    PlayerController.wc.fullStop(true);
    Timeline.t.stopChitChat();
    if (InventoryButtonController.ibc.gameObject.GetComponent<BoxCollider2D>().enabled)
      InventoryButtonController.ibc.close();
    CursorController.cc.deselectItem();
    if ((bool) (Object) InventoryController.ic)
      InventoryController.ic.gameObject.SetActive(false);
    if (GameDataController.gd.getCurrentDay() == 4)
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "day4_no_clock"));
    else if (!GameDataController.gd.getObjective("base_discovered"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "clock_not_yet"));
    else if (GameDataController.gd.getCurrentDay() == 2 && !GameDataController.gd.getObjective("dialogue_ginger_intro"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "heli_crash_check"));
    else if (GameDataController.gd.getCurrentDay() == 3 && !GameDataController.gd.getObjective("sidereal_base_located"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_base_check"));
    else
      this.showEndDialogue();
  }

  public void showEndDialogue(string s = "clock_click", string s2 = "equip_nothing")
  {
    DialogueController.dc.callback = (DialogueController.Callback) null;
    this.takeDoc(0);
    DialogueController.dc.ShowText(GameStrings.getString(GameStrings.warnings, s));
    DialogueController.dc.reset();
    this.equip_i = 0;
    this.takeDoc(this.equip_i);
    this.doc.caption = GameStrings.getString(GameStrings.gui, s2);
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/hand");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.equipItem);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = string.Empty;
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    ++this.equip_i;
    this.addItem("pipe", "equip_arm");
    this.addItem("crowbar", "equip_arm");
    this.addItem("wrench", "equip_arm");
    this.addItem("rifle_1", "equip_arm");
    this.addItem("rifle_2", "equip_arm");
    this.addItem("rifle_3", "equip_arm");
    this.addItem("rifle_4", "equip_arm");
    this.addItem("rifle_5", "equip_arm");
    this.addItem("rifle_6", "equip_arm");
    this.addItem("rifle_o_1", "equip_arm");
    this.addItem("rifle_o_2", "equip_arm");
    this.addItem("rifle_o_3", "equip_arm");
    this.addItem("rifle_o_4", "equip_arm");
    this.addItem("rifle_o_5", "equip_arm");
    this.addItem("rifle_o_6", "equip_arm");
    this.addItem("rifle_s_1", "equip_arm");
    this.addItem("rifle_s_2", "equip_arm");
    this.addItem("rifle_s_3", "equip_arm");
    this.addItem("rifle_s_4", "equip_arm");
    this.addItem("rifle_s_5", "equip_arm");
    this.addItem("rifle_s_6", "equip_arm");
    this.addItem("rifle_so_1", "equip_arm");
    this.addItem("rifle_so_2", "equip_arm");
    this.addItem("rifle_so_3", "equip_arm");
    this.addItem("rifle_so_4", "equip_arm");
    this.addItem("rifle_so_5", "equip_arm");
    this.addItem("rifle_so_6", "equip_arm");
    this.addItem("flamethrower", "equip_arm");
    this.addItem("knife", "equip_arm");
    this.addItem("water1", "equip_take");
    this.addItem("water2", "equip_take");
    this.addItem("water3", "equip_take");
    this.addItem("water4", "equip_take");
    this.addItem("coat1", "equip_wear");
    this.addItem("coat2", "equip_wear");
    this.addItem("coat3", "equip_wear");
    this.addItem("coat4", "equip_wear");
    this.addItem("chemsuit_dmg_dmg", "equip_wear");
    this.addItem("chemsuit_dmg_rep", "equip_wear");
    this.addItem("chemsuit_rep_dmg", "equip_wear");
    this.addItem("chemsuit_rep_rep", "equip_wear");
    this.addItem("pills", "equip_take");
    this.takeDoc(this.equip_i);
    this.doc.caption = GameStrings.getString(GameStrings.gui, "cancel");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/bye");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective(string.Empty);
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), background: Resources.Load<Sprite>("Bitmaps/Misc/wait_bck"));
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.endTalk);
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    ++this.equip_i;
    this.takeDoc(0);
    if (!(this.doc.caption != string.Empty))
      return;
    DialogueController.dc.talking = true;
  }

  private void addItem(string item, string how)
  {
    if (!InventoryController.ic.isItemInInventory(item))
      return;
    this.takeDoc(this.equip_i);
    this.doc.caption = GameStrings.getString(GameStrings.gui, how) + " " + GameStrings.getPrefixedShort(GameStrings.items, item).ToLower();
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Items/" + item + "_inv");
    this.doc.lines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(this.doc.lines, string.Empty, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    this.doc.setObjective(string.Empty);
    this.doc.lines[this.doc.lines.Count - 1].action = new TimelineFunction(this.equipItem);
    this.doc.lines[this.doc.lines.Count - 1].actionParam = item;
    this.doc.lines[this.doc.lines.Count - 1].actionWithText = true;
    ++this.equip_i;
  }
}
