// Decompiled with JetBrains decompiler
// Type: BarnButtonGenOff
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class BarnButtonGenOff : ObjectActionController
{
  public AudioClip engineStart;
  public AudioClip engineDie;
  public AudioClip engineRun;
  public AudioSource aS;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = string.Empty;
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "barn_generator_button_off";
    this.teleport = true;
    this.aS = this.gameObject.AddComponent<AudioSource>();
    this.engineStart = SoundsManagerController.sm.engine_start;
    this.engineRun = SoundsManagerController.sm.engine_run;
    this.engineDie = SoundsManagerController.sm.engine_die;
    if (GameDataController.gd.getObjective("barn_pump_started"))
    {
      this.aS.clip = this.engineRun;
      this.aS.loop = true;
      this.aS.volume = 0.4f;
      this.aS.Play();
    }
    this.transform.position = ScreenControler.roundToNearestFullPixel2(this.transform.position);
  }

  public void unlockIt() => PlayerController.pc.setBusy(false);

  public override void clickAction()
  {
    if (GameDataController.gd.getObjectiveDetail("barn_pump_started") == 0)
      return;
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.button_click);
    if (GameDataController.gd.getObjectiveDetail("barn_pump_started") != 0 && GameDataController.gd.getObjective("barn_pump_started"))
    {
      this.aS.Stop();
      this.aS.volume = 0.4f;
      this.aS.PlayOneShot(this.engineDie);
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_generator_off"));
    }
    GameDataController.gd.setObjectiveDetail("barn_pump_started", 0);
    GameDataController.gd.setObjective("barn_pump_started", false);
    this.updateAll();
    PlayerController.pc.setBusy(true);
    this.Invoke("unlockIt", 0.1f);
  }

  public void updateAfterAnimation() => this.updateState();

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("barn_pump_started") == 0)
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    else
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
