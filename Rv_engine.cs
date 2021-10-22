// Decompiled with JetBrains decompiler
// Type: Rv_engine
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class Rv_engine : ObjectActionController
{
  private AudioSource aS;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.aS = this.gameObject.GetComponent<AudioSource>();
    this.range = 1f;
    this.characterAnimationName = "walk2_low2";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "rv_seats";
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("rv_inspected"))
      Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
      {
        text = GameStrings.getString(GameStrings.actions, "rv_car_1b"),
        function = new TimelineFunction(this.examineCar),
        actionWithText = false
      });
    else if (GameDataController.gd.getObjective("rv_fueled") && !GameDataController.gd.getObjective("rv_started"))
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.rv_engine_start);
    else if (!GameDataController.gd.getObjective("rv_fueled") && !GameDataController.gd.getObjective("rv_started"))
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.rv_engine_fail);
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "rv_already_running"));
  }

  public override void updateState()
  {
    if (!this.aS.isPlaying && GameDataController.gd.getObjective("rv_started"))
    {
      this.aS.clip = SoundsManagerController.sm.rv_engine_loop;
      this.aS.loop = true;
      this.aS.volume = 0.75f;
      this.aS.Play();
    }
    else
    {
      if (GameDataController.gd.getObjective("rv_started") || !this.aS.isPlaying)
        return;
      this.aS.Stop();
    }
  }

  public override void clickAction2()
  {
    if (GameDataController.gd.getObjective("rv_fueled") && !GameDataController.gd.getObjective("rv_started"))
    {
      GameDataController.gd.setObjective("rv_started", true);
      Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
      {
        text = GameStrings.getString(GameStrings.actions, "rv_started")
      });
      Timeline.t.doNotUnlock = true;
    }
    else if (!GameDataController.gd.getObjective("rv_fueled") && !GameDataController.gd.getObjective("rv_started"))
    {
      Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
      {
        text = GameStrings.getString(GameStrings.actions, "rv_no_fuel")
      });
      Timeline.t.doNotUnlock = true;
    }
    this.updateState();
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
    if (!GameDataController.gd.getObjective("rv_inspected"))
    {
      this.range = 1f;
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
    else if (GameDataController.gd.getObjective("rv_fueled") && !GameDataController.gd.getObjective("rv_started"))
    {
      this.range = 1f;
      this.characterAnimationName = "walk2_low2";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else if (!GameDataController.gd.getObjective("rv_fueled") && !GameDataController.gd.getObjective("rv_started"))
    {
      this.range = 1f;
      this.characterAnimationName = "walk2_low2";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else
    {
      this.range = 1111f;
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
  }

  private void examineCar(string str) => QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "rv_inspect"), yesClick: new Button.Delegate(this.doExamineCar), time: 5, timeSaver: 1);

  private void doExamineCar()
  {
    GameDataController.gd.setObjective("rv_inspected", true);
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.N, animation: "stop", flipX: true, actionAfterFade: new CurtainController.Delegate(this.sayAboutCarExplore));
  }

  public void sayAboutCarExplore2()
  {
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "rv_car_2"), true);
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.actions, "rv_car_2a")
    });
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.actions, "rv_car_2b")
    });
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.actions, "rv_car_2c")
    });
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.actions, "rv_car_2d")
    });
    this.updateAll();
  }

  public void sayAboutCarExplore()
  {
    PlayerController.pc.setBusy(true);
    this.Invoke("sayAboutCarExplore2", 1f);
  }
}
