// Decompiled with JetBrains decompiler
// Type: BarnButtonSmall2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class BarnButtonSmall2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = string.Empty;
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "barn_console_ground";
    this.teleport = true;
    this.transform.position = ScreenControler.roundToNearestFullPixel2(this.transform.position);
  }

  public override void clickAction() => PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "barn_console_no_ground"), true, true);

  public void updateAfterAnimation() => this.updateState();

  public override void updateState() => this.GetComponent<Animator>().Play("b_small_off", 0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
