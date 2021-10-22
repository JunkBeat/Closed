// Decompiled with JetBrains decompiler
// Type: Location2Fridge
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class Location2Fridge : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action2_ne";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.range = 1f;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "base_fridge";
    this.updateState();
  }

  public override void clickAction()
  {
    PlayerController.wc.forceAnimation("stand_n");
    TimelineAction action = new TimelineAction();
    action.textfield = PlayerController.pc.textField;
    action.text = GameStrings.getString(GameStrings.actions, "base_fridge");
    action.actionWithText = false;
    action.function = new TimelineFunction(this.closeFridge);
    Timeline.t.doNotUnlock = true;
    Timeline.t.addAction(action);
  }

  public void closeSound() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.fridge);

  public void closeFridge(string param = "")
  {
    PlayerController.wc.forceAnimation("action2_ne", true);
    this.gameObject.GetComponent<Animator>().Play("FridgeDoorClose");
  }

  public override void updateState()
  {
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0() => this.gameObject.GetComponent<Animator>().Play("FridgeDoor");

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}
