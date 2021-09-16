// Decompiled with JetBrains decompiler
// Type: BarnButtonX
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class BarnButtonX : ObjectActionController
{
  private AudioSource aS;
  private AudioClip engineRun;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = string.Empty;
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "barn_console_reset";
    this.teleport = true;
    this.engineRun = SoundsManagerController.sm.engine_run;
    this.aS = this.gameObject.AddComponent<AudioSource>();
    this.transform.position = ScreenControler.roundToNearestFullPixel2(this.transform.position);
    if (GameDataController.gd.getObjectiveDetail("barn_pump_started") <= 0 || !GameDataController.gd.getObjective("barn_pump_started"))
      return;
    this.aS.clip = this.engineRun;
    this.aS.loop = true;
    this.aS.volume = 0.25f;
    this.aS.Play();
  }

  public override void clickAction()
  {
    GameDataController.gd.setObjective("barn_sprinklers_b1", false);
    GameDataController.gd.setObjective("barn_sprinklers_b2", false);
    GameDataController.gd.setObjective("barn_sprinklers_b3", false);
    GameDataController.gd.setObjective("barn_sprinklers_b4", false);
    GameDataController.gd.setObjective("barn_sprinklers_b5", false);
    GameDataController.gd.setObjective("barn_sprinklers_b6", false);
    GameDataController.gd.setObjective("barn_sprinklers_b7", false);
    GameDataController.gd.setObjective("barn_sprinklers_b8", false);
    this.GetComponent<Animator>().Play("b_x_press", 0);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.button_click);
  }

  public void updateAfterAnimation() => this.updateAll();

  public override void updateState() => this.GetComponent<Animator>().Play("b_x_off", 0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
