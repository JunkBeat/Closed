// Decompiled with JetBrains decompiler
// Type: SiderealF1B_Photocopier
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class SiderealF1B_Photocopier : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_photocopier";
    this.actionType = ObjectActionController.Type.NormalAction;
  }

  public override void clickAction() => Timeline.t.addAction(new TimelineAction()
  {
    textfield = PlayerController.pc.textField,
    text = GameStrings.getString(GameStrings.actions, "sidereal_photocopier"),
    actionWithText = false
  });

  public override void updateState()
  {
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.range = 50f;
    this.objectName = "sidereal_photocopier";
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
