// Decompiled with JetBrains decompiler
// Type: SaveSlotButton
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System;
using UnityEngine;

public class SaveSlotButton : ObjectActionController
{
  public Sprite thumb;
  public Sprite bigThumb;
  public bool saveMode;
  public string slotName;
  public SpriteRenderer bigSpriteRenderer;
  public SpriteRenderer thumbSpriteRenderer;
  public Vector2 gts = new Vector2(16f, 55f);
  public Vector2 position = new Vector2(16f, 55f);
  public TextFieldController labelSlotName;
  public TextFieldController labelSlotDay;
  public TextFieldController labelSlotDate;
  public AudioSource audioSource;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.gui;
    this.objectName = "blank";
    this.range = 9999f;
    this.teleport = true;
    this.allowAllItems = true;
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    this.bigSpriteRenderer.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.bigSpriteRenderer.gameObject.transform.position);
    this.thumbSpriteRenderer = this.GetComponent<SpriteRenderer>();
    Vector2 screen = ScreenControler.gameToScreen(this.gts);
    this.bigSpriteRenderer.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, -0.01f));
    this.bigSpriteRenderer.gameObject.transform.position = new Vector3(this.bigSpriteRenderer.gameObject.transform.position.x, this.bigSpriteRenderer.gameObject.transform.position.y, -3f);
    if (!((UnityEngine.Object) this.audioSource == (UnityEngine.Object) null))
      return;
    if ((UnityEngine.Object) GameObject.Find("static_dust").GetComponent<AudioSource>() == (UnityEngine.Object) null)
    {
      this.audioSource = GameObject.Find("static_dust").AddComponent<AudioSource>();
      this.audioSource.ignoreListenerPause = true;
      this.audioSource.ignoreListenerVolume = true;
    }
    else
      this.audioSource = GameObject.Find("static_dust").GetComponent<AudioSource>();
  }

  private void Update()
  {
    Vector2 screen = ScreenControler.gameToScreen(this.position);
    this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, -0.01f));
    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -3f);
    if (!this.needUpdate)
      return;
    this.updateState();
    this.needUpdate = false;
  }

  private void OnMouseEnter()
  {
    if (PlayerController.wc.busy)
      return;
    if ((UnityEngine.Object) this.audioSource == (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) GameObject.Find("static_dust").GetComponent<AudioSource>() == (UnityEngine.Object) null)
      {
        this.audioSource = GameObject.Find("static_dust").AddComponent<AudioSource>();
        this.audioSource.ignoreListenerPause = true;
        this.audioSource.ignoreListenerVolume = true;
      }
      else
        this.audioSource = GameObject.Find("static_dust").GetComponent<AudioSource>();
    }
    this.audioSource.volume = (float) PlayerPrefs.GetInt("sound") / 100f;
    this.audioSource.PlayOneShot(SoundsManagerController.sm.ui_hover);
  }

  public override void mouseOver()
  {
    if (PlayerController.wc.busy)
      return;
    if (GameDataController.gd.checkSave(this.slotName))
    {
      SaveData savePreview = GameDataController.gd.getSavePreview(this.slotName);
      if (savePreview.gameDay < 5)
        this.labelSlotDay.viewText(GameStrings.capitalise(GameStrings.getString(GameStrings.gui, "day")) + " " + (object) savePreview.gameDay + " " + ClockController.getClockTime(savePreview.gameTime), quick: true, instant: true, mwidth: 200, ba: 0.0f);
      else
        this.labelSlotDay.viewText(GameStrings.capitalise(GameStrings.getString(GameStrings.gui, "epilogue")) + " ", quick: true, instant: true, mwidth: 200, ba: 0.0f);
      this.labelSlotDay.keepAlive = true;
      string str = string.Empty;
      if (savePreview.objectives.Find((Predicate<Objective>) (x => x.id.Contains("previous_disc_barry"))).state || savePreview.objectives.Find((Predicate<Objective>) (x => x.id.Contains("previous_disc_cody"))).state)
        str = "- " + GameStrings.getString(GameStrings.gui, "newGamePlus") + " -";
      this.labelSlotDate.directionY = 1f;
      this.labelSlotDate.viewText(str + " ^" + savePreview.dateTime.ToShortTimeString() + " " + savePreview.dateTime.ToShortDateString(), quick: true, instant: true, mwidth: 200, ba: 0.0f);
      this.labelSlotDate.keepAlive = true;
    }
    string empty = string.Empty;
    string text = GameStrings.getString(GameStrings.gui, "slot_name") + " ";
    if (this.slotName == "save1")
      text += "1";
    if (this.slotName == "save2")
      text += "2";
    if (this.slotName == "save3")
      text += "3";
    if (this.slotName == "save4")
      text += "4";
    if (this.slotName == "save5")
      text += "5";
    if (this.slotName == "save6")
      text += "6";
    if (this.slotName == "save7")
      text += "7";
    if (this.slotName == "save8")
      text += "8";
    if (this.slotName == "save9")
      text += "9";
    if (this.slotName == "save10")
      text += "10";
    if (this.slotName == "autosave0")
      text = GameStrings.getString(GameStrings.gui, "autosave_name");
    else if (this.slotName.IndexOf("autosave") != -1)
    {
      string str = GameStrings.getString(GameStrings.gui, "autosave_chapter_name1") + " ";
      if (this.slotName == "chapter_1_autosave")
        str += "1";
      if (this.slotName == "chapter_2_autosave")
        str += "2";
      if (this.slotName == "chapter_3_autosave")
        str += "3";
      if (this.slotName == "chapter_4_autosave")
        str += "4";
      text = str + " " + GameStrings.getString(GameStrings.gui, "autosave_chapter_name2") + " - " + GameStrings.getString(GameStrings.gui, "autosave_name");
    }
    this.labelSlotName.viewText(text, quick: true, instant: true, mwidth: 200, ba: 0.0f);
    this.labelSlotName.keepAlive = true;
    if (GameDataController.gd.checkSave(this.slotName))
      this.bigSpriteRenderer.enabled = true;
    else
      this.bigSpriteRenderer.enabled = false;
    this.bigSpriteRenderer.sprite = this.bigThumb;
  }

  public override void mouseOut()
  {
    if (PlayerController.wc.busy)
      return;
    this.labelSlotName.keepAlive = false;
    this.labelSlotDate.keepAlive = false;
    this.labelSlotDay.keepAlive = false;
    this.bigSpriteRenderer.sprite = (Sprite) null;
  }

  public override void clickAction()
  {
    if ((UnityEngine.Object) this.audioSource == (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) GameObject.Find("static_dust").GetComponent<AudioSource>() == (UnityEngine.Object) null)
      {
        this.audioSource = GameObject.Find("static_dust").AddComponent<AudioSource>();
        this.audioSource.ignoreListenerPause = true;
        this.audioSource.ignoreListenerVolume = true;
      }
      else
        this.audioSource = GameObject.Find("static_dust").GetComponent<AudioSource>();
    }
    this.audioSource.volume = (float) PlayerPrefs.GetInt("sound") / 100f;
    this.audioSource.PlayOneShot(SoundsManagerController.sm.ui_click, 0.5f);
    if (GameDataController.wantSave)
    {
      if (GameDataController.gd.checkSave(this.slotName))
      {
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.gui, "save_overwrite_warning"), yesClick: new Button.Delegate(this.overwriteSave), noClick: new Button.Delegate(this.cancel));
      }
      else
      {
        ScreenShots.ss.saveShots(this.slotName);
        GameDataController.gd.Save(this.slotName);
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.gui, "save_done"), QuestionController.PopupType.STATEMENT);
        this.updateState();
      }
    }
    else
    {
      if (!GameDataController.gd.checkSave(this.slotName))
        return;
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.gui, "load_warning"), yesClick: new Button.Delegate(this.loadSave), noClick: new Button.Delegate(this.cancel));
    }
  }

  private void cancel()
  {
    this.labelSlotName.keepAlive = false;
    this.labelSlotDate.keepAlive = false;
    this.labelSlotDay.keepAlive = false;
    this.bigSpriteRenderer.sprite = (Sprite) null;
  }

  private void overwriteSave()
  {
    ScreenShots.ss.saveShots(this.slotName);
    GameDataController.gd.Save(this.slotName);
    QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.gui, "save_done"), QuestionController.PopupType.STATEMENT);
    this.updateState();
  }

  private void loadSave() => GameDataController.gd.politeLoad(this.slotName);

  public override void updateState()
  {
    if (this.slotName.IndexOf("autosave") != -1)
    {
      if (GameDataController.wantSave)
      {
        this.gameObject.transform.Find("back").GetComponent<SpriteRenderer>().enabled = false;
        this.thumbSpriteRenderer.enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        return;
      }
      this.thumbSpriteRenderer.enabled = true;
      this.GetComponent<BoxCollider2D>().enabled = true;
      if (GameDataController.gd.checkSave(this.slotName))
        this.gameObject.transform.Find("back").GetComponent<SpriteRenderer>().enabled = true;
      else
        this.gameObject.transform.Find("back").GetComponent<SpriteRenderer>().enabled = false;
    }
    if (GameDataController.wantSave || GameDataController.gd.checkSave(this.slotName))
    {
      this.GetComponent<BoxCollider2D>().enabled = true;
      this.thumb = ScreenShots.ss.getSprite(this.slotName);
      this.bigThumb = ScreenShots.ss.getSprite(this.slotName, true);
      this.thumbSpriteRenderer.sprite = this.thumb;
    }
    else
      this.GetComponent<BoxCollider2D>().enabled = false;
    if (GameDataController.gd.checkSave(this.slotName))
      this.thumbSpriteRenderer.enabled = true;
    else
      this.thumbSpriteRenderer.enabled = false;
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
