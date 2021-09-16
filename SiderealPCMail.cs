// Decompiled with JetBrains decompiler
// Type: SiderealPCMail
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class SiderealPCMail : ObjectActionController
{
  public SpriteRenderer spriter;
  public SiderealComputerSound beeper;
  public Sprite icon;
  public Sprite window;
  public WorldCaption mailCaption;
  public WorldCaption mail;
  public WorldCaption iconCaption;
  public Button buttonLeft;
  public Button buttonRight;
  public Button buttonAtt;
  public WorldCaption pageNumber;
  public Sprite errorImg;
  public Sprite mapLodge;
  public Sprite mapBase;
  public Sprite mailNorml;
  public Sprite mailRead;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_mail_app";
    this.range = 8000f;
    this.teleport = true;
    this.updateState();
    this.buttonLeft.workIfBusy = false;
    this.buttonLeft.onClick = new Button.Delegate(this.prevPage);
    this.buttonRight.workIfBusy = false;
    this.buttonRight.onClick = new Button.Delegate(this.nextPage);
    this.buttonAtt.workIfBusy = false;
    this.buttonAtt.onClick = new Button.Delegate(this.showAtt);
  }

  private void Update()
  {
  }

  public void showAtt()
  {
    PlayerController.pc.clickedSomething = true;
    this.beeper.beep();
    PlayerController.pc.setBusy(true);
    this.Invoke("makeItAtt1", Random.Range(0.1f, 0.3f));
  }

  public void makeItAtt1()
  {
    PlayerController.pc.setBusy(false);
    ExamineSprite.es.textField.shift.x = -20f;
    ExamineSprite.es.textField.shift.y = 20f;
    if (GameDataController.gd.getObjectiveDetail("sidereal_email_displayed") == 3)
    {
      ExamineSprite.es.textField.shift.x = -9f;
      ExamineSprite.es.textField.shift.y = -23f;
      ExamineSprite.es.readyText(new List<string>()
      {
        GameStrings.getString(GameStrings.actions, "sidereal_lodge_discover_1"),
        GameStrings.getString(GameStrings.actions, "sidereal_lodge_discover_2")
      }, 100, 1f, 1f, 1f, 0.0f, 0.0f, 0.0f, 0.5f);
      ExamineSprite.es.show(this.mapLodge);
      this.pageNumber.hide();
      ExamineSprite.es.lookAction = new ExamineSprite.Delegate(this.seenLodge);
      ExamineSprite.es.actionOnShow = false;
    }
    if (GameDataController.gd.getObjectiveDetail("sidereal_email_displayed") == 9)
    {
      ExamineSprite.es.textField.shift.x = -9f;
      ExamineSprite.es.textField.shift.y = 0.0f;
      ExamineSprite.es.readyText(new List<string>()
      {
        GameStrings.getString(GameStrings.actions, "sidereal_base_discover_1"),
        GameStrings.getString(GameStrings.actions, "sidereal_base_discover_2"),
        GameStrings.getString(GameStrings.actions, "sidereal_base_discover_3")
      }, 100, 1f, 1f, 1f, 0.0f, 0.0f, 0.0f, 0.5f);
      ExamineSprite.es.show(this.mapBase);
      this.pageNumber.hide();
      ExamineSprite.es.lookAction = new ExamineSprite.Delegate(this.seenBase);
      ExamineSprite.es.actionOnShow = false;
    }
    if (GameDataController.gd.getObjectiveDetail("sidereal_email_displayed") != 5)
      return;
    ExamineSprite.es.readyText(new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "sidereal_pc_email_5_b_examine")
    }, 100, 0.0f, 0.0f, 0.0f, 1f, 1f, 1f, 0.0f);
    ExamineSprite.es.show(this.errorImg);
  }

  public void seenLodge()
  {
    GameDataController.gd.setObjectiveDetail("map_hunters_revealed", TravelAgency.LOCATION_STATUS_REACHABLE);
    this.updateAll();
  }

  public void seenBase()
  {
    GameDataController.gd.setObjective("sidereal_base_located", true);
    if (GameDataController.gd.getCurrentDay() == 3)
      GameDataController.gd.setObjectiveDetail("map_outpost_revealed", TravelAgency.LOCATION_STATUS_UNREACHABLE);
    else
      GameDataController.gd.setObjectiveDetail("map_outpost_revealed", TravelAgency.LOCATION_STATUS_REACHABLE);
    this.updateAll();
  }

  public void nextPage()
  {
    int detail = GameDataController.gd.getObjectiveDetail("sidereal_email_page") + 1;
    if (detail > 10)
      detail = 10;
    GameDataController.gd.setObjectiveDetail("sidereal_email_page", detail);
    this.updateState();
    if (detail != 3 || GameDataController.gd.getObjectiveDetail("sidereal_email_displayed") != 2 || GameDataController.gd.getObjective("sidereal_read_cate_mail"))
      return;
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "cate_emial", PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    GameDataController.gd.setObjective("sidereal_read_cate_mail", true);
  }

  public void makeItNext() => PlayerController.pc.setBusy(false);

  public void prevPage()
  {
    int detail = GameDataController.gd.getObjectiveDetail("sidereal_email_page") - 1;
    if (detail < 1)
      detail = 1;
    GameDataController.gd.setObjectiveDetail("sidereal_email_page", detail);
    this.updateState();
  }

  public void makeItPrev() => PlayerController.pc.setBusy(false);

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    this.beeper.beep();
    if (!GameDataController.gd.getObjective("sidereal_email_displayed"))
    {
      PlayerController.pc.setBusy(true);
      this.Invoke("makeItSo", Random.Range(0.25f, 1f));
    }
    else
      this.Invoke("makeItSo2", Random.Range(0.15f, 0.25f));
  }

  private void makeItSo2()
  {
    GameDataController.gd.setObjective("sidereal_email_displayed", false);
    PlayerController.pc.setBusy(false);
    this.updateAll();
  }

  private void makeItSo()
  {
    PlayerController.pc.setBusy(false);
    GameDataController.gd.setObjective("sidereal_email_displayed", true);
    GameDataController.gd.setObjectiveDetail("sidereal_email_displayed", 1);
    GameDataController.gd.setObjectiveDetail("sidereal_email_page", 1);
    this.updateAll();
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("sidereal_email_displayed"))
    {
      this.mailCaption.hide();
      this.spriter.sprite = this.icon;
      this.setCollider(1);
      this.mail.hide();
      this.iconCaption.manualUpdate();
      this.buttonAtt.buttonEnabled = false;
      this.buttonLeft.buttonEnabled = false;
      this.buttonRight.buttonEnabled = false;
      if ((Object) this.buttonAtt.buttonText != (Object) null)
        this.buttonAtt.buttonText.dissmiss(true);
      if ((Object) this.buttonLeft.buttonText != (Object) null)
        this.buttonLeft.buttonText.dissmiss(true);
      if ((Object) this.buttonRight.buttonText != (Object) null)
        this.buttonRight.buttonText.dissmiss(true);
      this.pageNumber.hide();
      this.objectName = "sidereal_mail_app";
    }
    else
    {
      this.mailCaption.manualUpdate();
      this.objectName = "sidereal_x_app";
      this.spriter.sprite = !GameDataController.gd.getObjective("sidereal_read_last_mail") ? this.mailNorml : this.mailRead;
      this.setCollider(0);
      this.mail.manualUpdate();
      this.iconCaption.hide();
      int detail = GameDataController.gd.getObjectiveDetail("sidereal_email_page");
      int num = 0;
      for (int index = 1; index <= 10; ++index)
      {
        if (GameStrings.getString(GameStrings.world_labels, "sidereal_pc_email_" + (object) GameDataController.gd.getObjectiveDetail("sidereal_email_displayed") + "_b_" + (object) index).Length > 1)
          num = index;
      }
      if (detail > num)
      {
        detail = num;
        GameDataController.gd.setObjectiveDetail("sidereal_email_page", detail);
      }
      this.buttonLeft.initButton("<|");
      this.buttonRight.initButton("|>");
      string label = GameStrings.getString(GameStrings.world_labels, "sidereal_pc_email_" + (object) GameDataController.gd.getObjectiveDetail("sidereal_email_displayed") + "_b_attachment");
      if (label.Length > 1)
      {
        this.buttonAtt.initButton(label);
        this.buttonAtt.buttonEnabled = true;
      }
      else
      {
        this.buttonAtt.initButton(string.Empty);
        this.buttonAtt.buttonEnabled = false;
      }
      this.buttonRight.color1 = new Vector3(0.25f, 0.25f, 0.25f);
      this.buttonRight.color2 = new Vector3(1f, 1f, 1f);
      this.buttonLeft.color1 = new Vector3(0.25f, 0.25f, 0.25f);
      this.buttonLeft.color2 = new Vector3(1f, 1f, 1f);
      this.buttonLeft.initButton("<|");
      this.buttonRight.initButton("|>");
      if (detail == 10 || detail >= num)
      {
        this.buttonRight.color1 = new Vector3(0.45f, 0.45f, 0.45f);
        this.buttonRight.color2 = new Vector3(0.45f, 0.45f, 0.45f);
        this.buttonRight.initButton("|>");
        this.buttonRight.buttonEnabled = false;
      }
      else
        this.buttonRight.buttonEnabled = true;
      if (detail == 1)
      {
        this.buttonLeft.color1 = new Vector3(0.45f, 0.45f, 0.45f);
        this.buttonLeft.color2 = new Vector3(0.45f, 0.45f, 0.45f);
        this.buttonLeft.initButton("<|");
        this.buttonLeft.buttonEnabled = false;
      }
      else
        this.buttonLeft.buttonEnabled = true;
      this.mail.nameToDisplay = "sidereal_pc_email_" + (object) GameDataController.gd.getObjectiveDetail("sidereal_email_displayed") + "_b_" + (object) GameDataController.gd.getObjectiveDetail("sidereal_email_page");
      this.mail.manualUpdate();
      this.pageNumber.overrideString = detail.ToString() + "/" + (object) num;
      this.pageNumber.manualUpdate();
      this.pageNumber.gameObject.transform.position = new Vector3(this.pageNumber.gameObject.transform.position.x, this.pageNumber.gameObject.transform.position.y, -0.1f);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
