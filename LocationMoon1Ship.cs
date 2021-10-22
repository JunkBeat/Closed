// Decompiled with JetBrains decompiler
// Type: LocationMoon1Ship
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class LocationMoon1Ship : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "suit_action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "ship_derlict";
    this.range = 200f;
    this.actionType = ObjectActionController.Type.NormalAction;
    this.trans_dir = WalkController.Direction.N;
    this.doubleClickCondition = string.Empty;
  }

  public override void clickAction() => PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "no_point_going_back"));

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
