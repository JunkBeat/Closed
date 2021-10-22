// Decompiled with JetBrains decompiler
// Type: Restaurant4Door
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class Restaurant4Door : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_backdoor";
    this.range = 20f;
  }

  public override void clickAction() => PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "restaurant_backdoor2"), true);

  public override void updateState()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
