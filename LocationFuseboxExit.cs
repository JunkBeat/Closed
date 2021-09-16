// Decompiled with JetBrains decompiler
// Type: LocationFuseboxExit
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;

public class LocationFuseboxExit : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "leave";
    this.teleport = true;
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.S;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("puzzle_cable", string.Empty, anim: string.Empty));
  }

  public override void clickAction()
  {
    if (!(this.usedItem == string.Empty))
      return;
    PlayerController.pc.spawnName = "Waypoint_Outpost3_Fusebox";
    PlayerController.wc.fullStop();
    CurtainController.cc.fadeOut("LocationOutpost3", WalkController.Direction.SE);
  }

  public override void whatOnClick0()
  {
    if (this.usedItem == string.Empty)
      this.characterAnimationName = "stop";
    else
      this.characterAnimationName = "action_stnd_";
  }

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
