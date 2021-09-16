// Decompiled with JetBrains decompiler
// Type: BaseEntry
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class BaseEntry : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "base_entry";
    this.doubleClickCondition = "visited_location1";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.E;
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "Door2_Exit";
    CurtainController.cc.fadeOut("Location1", WalkController.Direction.E);
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

  public override void clickAction0()
  {
  }
}
