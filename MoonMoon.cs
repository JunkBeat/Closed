// Decompiled with JetBrains decompiler
// Type: MoonMoon
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class MoonMoon : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_ne";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "moon";
    this.range = 8000f;
    this.teleport = false;
    this.updateState();
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction() => PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "moon"), true, mwidth: 150);

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("tent_awake"))
      this.colliderManager.setCollider(-1);
    else if (!GameDataController.gd.getObjective("tent_backpack_taken"))
    {
      this.colliderManager.setCollider(0);
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
    else
    {
      this.characterAnimationName = "action_stnd_ne";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.colliderManager.setCollider(0);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
