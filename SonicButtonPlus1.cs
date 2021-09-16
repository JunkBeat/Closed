// Decompiled with JetBrains decompiler
// Type: SonicButtonPlus1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class SonicButtonPlus1 : ObjectActionController
{
  public Sprite up;
  public Sprite down;
  public int delta;
  private SpriteRenderer sr;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = string.Empty;
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "button";
    this.teleport = true;
    this.range = 100f;
    this.transform.position = ScreenControler.roundToNearestFullPixel2(this.transform.position);
    this.sr = this.GetComponent<SpriteRenderer>();
  }

  public override void clickAction()
  {
    int detail = GameDataController.gd.getObjectiveDetail("sonic_frequency") + this.delta;
    if (detail > 999)
      detail = 999;
    if (detail < 100)
      detail = 100;
    GameDataController.gd.setObjectiveDetail("sonic_frequency", detail);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.button_click);
    this.sr.sprite = this.down;
    this.setCollider(-1);
    this.Invoke("restore", 0.05f);
  }

  public void restore()
  {
    this.setCollider(0);
    this.sr.sprite = this.up;
  }

  public void updateAfterAnimation() => this.updateAll();

  public override void updateState()
  {
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
