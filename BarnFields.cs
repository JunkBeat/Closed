// Decompiled with JetBrains decompiler
// Type: BarnFields
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class BarnFields : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "barn_fields";
    this.range = 300f;
  }

  public override void clickAction()
  {
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "barn_fields"), true);
    PlayerController.wc.forceAnimation("stand_n");
    PlayerController.wc.dir = WalkController.Direction.N;
  }

  public override void updateState() => this.colliderManager.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
