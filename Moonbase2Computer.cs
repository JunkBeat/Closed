// Decompiled with JetBrains decompiler
// Type: Moonbase2Computer
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Moonbase2Computer : ObjectActionController
{
  public MoonbaseLightFlicker mlf;
  public Sprite screen;

  public void updateMLF()
  {
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.pc_noise, 0.75f, AudioReverbPreset.Bathroom);
    this.mlf.lightsFailed = false;
  }

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "action_n_busy2";
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "moon_computer";
    this.range = 2f;
    this.updateAll();
  }

  public void pressit(string s = "")
  {
    this.Invoke("scansound", 0.1f);
    this.Invoke("scanfail", 1.1f);
  }

  public void pressit2()
  {
    PlayerController.pc.setBusy(true);
    this.Invoke("scansound", 0.1f);
    this.Invoke("scansuccess", 1.1f);
  }

  public void pressit3()
  {
    PlayerController.pc.setBusy(true);
    this.Invoke("scansound", 0.1f);
    this.Invoke("scansuccess2", 1.1f);
  }

  public void scansound() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.keyboard);

  public void failsound(string s = "") => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.fail1);

  public void successsound(string s = "")
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2);
    this.updateAll();
  }

  public void successsound2(string s = "")
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.power_up_big, 0.5f);
    this.updateMLF();
    this.updateAll();
    GameDataController.gd.setObjective("moon_light_restored", true);
    GameObject.Find("LocationManager").GetComponent<LocationMoonbase2Start>().windowMayCrack = true;
  }

  public void scanfail()
  {
    TimelineAction timelineAction = new TimelineAction();
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = PlayerController.pc.textField,
      textColor = new Vector3(1f, 0.0f, 0.0f),
      backgroundColor = new Vector3(0.5f, 0.0f, 0.0f),
      text = GameStrings.getString(GameStrings.actions, "moon_computer_1"),
      actionWithText = true,
      function = new TimelineFunction(this.failsound)
    });
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("moon_card_used"))
      this.pressit(string.Empty);
    else if (GameDataController.gd.getObjective("moon_light_failed") && !GameDataController.gd.getObjective("moon_light_restored"))
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.world_labels, "moon_restore_power"), yesClick: new Button.Delegate(this.pressit3), customYesLabel: GameStrings.getString(GameStrings.world_labels, "moon_restore_p_yes"), customNoLabel: GameStrings.getString(GameStrings.world_labels, "moon_restore_p_no"), image: this.screen);
    else if (!GameDataController.gd.getObjective("moon_console_unlocked"))
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.world_labels, "moon_restore_console_unlock"), yesClick: new Button.Delegate(this.pressit2), customYesLabel: GameStrings.getString(GameStrings.world_labels, "moon_restore_c_yes"), customNoLabel: GameStrings.getString(GameStrings.world_labels, "moon_restore_c_no"), image: this.screen);
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moon_computer_all"));
  }

  public void scansuccess()
  {
    TimelineAction timelineAction = new TimelineAction();
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = PlayerController.pc.textField,
      textColor = new Vector3(0.0f, 1f, 0.0f),
      backgroundColor = new Vector3(0.0f, 0.5f, 0.0f),
      text = GameStrings.getString(GameStrings.actions, "moon_computer_3"),
      actionWithText = true,
      function = new TimelineFunction(this.successsound)
    });
    GameDataController.gd.setObjective("moon_console_unlocked", true);
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = PlayerController.pc.textField,
      textColor = new Vector3(0.0f, 1f, 0.0f),
      backgroundColor = new Vector3(0.0f, 0.5f, 0.0f),
      text = GameStrings.getString(GameStrings.actions, "moon_computer_2"),
      actionWithText = false
    });
  }

  public void scansuccess2()
  {
    TimelineAction timelineAction = new TimelineAction();
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = PlayerController.pc.textField,
      textColor = new Vector3(0.0f, 1f, 0.0f),
      backgroundColor = new Vector3(0.0f, 0.5f, 0.0f),
      text = GameStrings.getString(GameStrings.actions, "moon_computer_4"),
      actionWithText = true,
      function = new TimelineFunction(this.successsound2)
    });
    GameDataController.gd.setObjective("moon_light_restored", true);
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = PlayerController.pc.textField,
      textColor = new Vector3(0.0f, 1f, 0.0f),
      backgroundColor = new Vector3(0.0f, 0.5f, 0.0f),
      text = GameStrings.getString(GameStrings.actions, "moon_computer_5"),
      actionWithText = false
    });
  }

  public override void whatOnClick0()
  {
    this.animationFlip = false;
    this.characterAnimationName = "action_n_busy2";
    this.useCurrentDirection = false;
    if (GameDataController.gd.getObjective("moon_light_failed") && !GameDataController.gd.getObjective("moon_light_restored") || !GameDataController.gd.getObjective("moon_console_unlocked"))
      ;
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("moon_card_used"))
      this.GetComponent<SpriteRenderer>().enabled = false;
    else
      this.GetComponent<SpriteRenderer>().enabled = true;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
