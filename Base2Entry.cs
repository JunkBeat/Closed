// Decompiled with JetBrains decompiler
// Type: Base2Entry
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class Base2Entry : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "kitchen_entry";
    this.doubleClickCondition = "visited_location2";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.W;
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "KitchenExitWay";
    CurtainController.cc.fadeOut("Location2", WalkController.Direction.W);
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
