// Decompiled with JetBrains decompiler
// Type: Outpost7_HatchControl
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class Outpost7_HatchControl : ObjectActionController
{
  public Sprite background;
  public Animator animator;
  public ParticleGenerator pg1;
  public ParticleGenerator pg2;
  public ParticleGenerator pg3;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_hatch_computer";
    this.range = 1f;
  }

  public void yesOpen()
  {
    PlayerController.pc.setBusy(true);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click1, 0.5f);
    if (GameDataController.gd.getObjective("outpost_belt_hatch"))
    {
      this.animator.Play("hatch_open");
      this.pg1.started = true;
      this.pg2.started = true;
      this.pg3.started = true;
      this.Invoke("stopSand", 3f);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.sand_big, 0.75f);
      this.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.big_door_open);
      this.Invoke("succeed", 3f);
      GameDataController.gd.setObjective("outpost_hatch_open", true);
    }
    else
      this.Invoke("failed", 1f);
  }

  public void succeed()
  {
    TimelineAction timelineAction = new TimelineAction();
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = PlayerController.pc.textField,
      textColor = new Vector3(0.0f, 1f, 0.0f),
      backgroundColor = new Vector3(0.0f, 0.5f, 0.0f),
      text = GameStrings.getString(GameStrings.actions, "outpost_hatch_opening"),
      actionWithText = true
    });
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2);
  }

  public void stopSand()
  {
    this.pg1.started = false;
    this.pg2.started = false;
    this.pg3.started = false;
  }

  public void failed()
  {
    TimelineAction timelineAction = new TimelineAction();
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = PlayerController.pc.textField,
      textColor = new Vector3(1f, 0.0f, 0.0f),
      backgroundColor = new Vector3(0.5f, 0.0f, 0.0f),
      text = GameStrings.getString(GameStrings.actions, "outpost_hatch_engine_broken"),
      actionWithText = true
    });
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.fail1);
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("outpost_hatch_open"))
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "outpost_hatch_open"), yesClick: new Button.Delegate(this.yesOpen), image: this.background);
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "outpost_hatch_opened"));
  }

  public override void updateState() => this.colliderManager.setCollider(0);

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
