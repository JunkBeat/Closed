// Decompiled with JetBrains decompiler
// Type: TentTent
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class TentTent : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "tent_tent";
    this.range = 80f;
    this.teleport = true;
    this.updateState();
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("tent_distance_checked"))
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "tent_tent"), true, mwidth: 150);
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "tent_tent_2"), true, mwidth: 150);
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("tent_awake"))
      this.colliderManager.setCollider(-1);
    else if (!GameDataController.gd.getObjective("tent_backpack_taken"))
    {
      this.colliderManager.setCollider(0);
      this.teleport = true;
    }
    else
    {
      this.teleport = false;
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
