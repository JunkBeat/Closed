// Decompiled with JetBrains decompiler
// Type: LocationRVInspect
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationRVInspect : ObjectActionController
{
  private AudioSource aS;
  public ParticleGenerator smoke;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "action_stnd_";
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "rv_car";
    this.aS = this.gameObject.GetComponent<AudioSource>();
    this.updateState();
    this.range = 50f;
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("rv_inspected"))
      Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
      {
        text = GameStrings.getString(GameStrings.actions, "rv_car_1"),
        function = new TimelineFunction(this.examineCar),
        actionWithText = false
      });
    else
      this.sayAboutCarExplore2();
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("rv_inspected"))
      this.range = 3f;
    else
      this.range = 100f;
    if (!this.aS.isPlaying && GameDataController.gd.getObjective("rv_started"))
    {
      this.aS.clip = SoundsManagerController.sm.rv_engine_loop;
      this.aS.loop = true;
      this.aS.volume = 0.99f;
      this.aS.Play();
      this.smoke.started = true;
    }
    else
    {
      if (GameDataController.gd.getObjective("rv_started"))
        return;
      if (this.aS.isPlaying)
        this.aS.Stop();
      this.smoke.started = false;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
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
