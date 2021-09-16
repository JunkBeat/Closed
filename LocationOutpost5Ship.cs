// Decompiled with JetBrains decompiler
// Type: LocationOutpost5Ship
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

public class LocationOutpost5Ship : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_ship";
    this.actionType = ObjectActionController.Type.NormalAction;
  }

  public override void clickAction()
  {
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = PlayerController.pc.textField,
      text = GameStrings.getString(GameStrings.actions, "outpost_ship_1"),
      actionWithText = false
    });
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = PlayerController.pc.textField,
      text = GameStrings.getString(GameStrings.actions, "outpost_ship_2"),
      actionWithText = false
    });
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = PlayerController.pc.textField,
      text = GameStrings.getString(GameStrings.actions, "outpost_ship_3"),
      actionWithText = false
    });
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = PlayerController.pc.textField,
      text = GameStrings.getString(GameStrings.actions, "outpost_ship_4"),
      actionWithText = false
    });
  }

  public override void updateState()
  {
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.range = 50f;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
