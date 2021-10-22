// Decompiled with JetBrains decompiler
// Type: Door2_Exit
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class Door2_Exit : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "base_exit";
    this.doubleClickCondition = "visited_baseOutside0";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.W;
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "Base_Entry";
    CurtainController.cc.fadeOut("LocationBaseOutside0", WalkController.Direction.SW);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("location01_door2_open"))
      this.colliderManager.setCollider(0);
    else
      this.colliderManager.setCollider(-1);
  }

  public override void clickAction2()
  {
  }

  private void Update()
  {
  }

  public override void clickAction0()
  {
  }
}
