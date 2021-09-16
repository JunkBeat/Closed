// Decompiled with JetBrains decompiler
// Type: LocationSiderealF0S_Logo
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class LocationSiderealF0S_Logo : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.range = 50f;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_logo";
    this.actionType = ObjectActionController.Type.NormalAction;
  }

  public override void clickAction() => Timeline.t.addAction(new TimelineAction()
  {
    textfield = PlayerController.pc.textField,
    text = GameStrings.getString(GameStrings.actions, "sidereal_logo"),
    actionWithText = false
  });

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
