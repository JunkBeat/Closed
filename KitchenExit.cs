// Decompiled with JetBrains decompiler
// Type: KitchenExit
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class KitchenExit : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "kitchen_exit";
    this.actionType = ObjectActionController.Type.Transition;
    this.doubleClickCondition = "visited_baseOutside2";
    this.trans_dir = WalkController.Direction.E;
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "Base_Entry";
    CurtainController.cc.fadeOut("LocationBaseOutside2", WalkController.Direction.E);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("location02_door_open"))
      this.colliderManager.setCollider(0);
    else
      this.colliderManager.setCollider(-1);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
