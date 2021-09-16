// Decompiled with JetBrains decompiler
// Type: BarnButtonGenSprinklers
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class BarnButtonGenSprinklers : ObjectActionController
{
  public BarnButtonGenOff bbgo;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = string.Empty;
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "barn_generator_button_sprinklers";
    this.teleport = true;
    this.bbgo = GameObject.Find("ButtonOff").GetComponent<BarnButtonGenOff>();
    this.transform.position = ScreenControler.roundToNearestFullPixel2(this.transform.position);
  }

  public void unlockIt()
  {
    PlayerController.pc.setBusy(false);
    this.updateAll();
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjectiveDetail("barn_pump_started") == 2)
      return;
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.button_click);
    PlayerController.pc.setBusy(true);
    this.Invoke("unlockIt", 0.1f);
    GameDataController.gd.setObjectiveDetail("barn_pump_started", 2);
  }

  public void updateAfterAnimation() => this.updateState();

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("barn_pump_started") == 2)
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
