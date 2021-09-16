﻿// Decompiled with JetBrains decompiler
// Type: LocationMixerExit
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


public class LocationMixerExit : ObjectActionController
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
  }

  public override void clickAction()
  {
    if (!(this.usedItem == string.Empty))
      return;
    PlayerController.pc.spawnName = "SiderealLabMixer";
    PlayerController.wc.fullStop();
    CurtainController.cc.fadeOut("SiderealLab13", WalkController.Direction.W);
  }

  public override void whatOnClick0()
  {
  }

  public override void updateState()
  {
    if (InventoryController.ic.isItemInInventory("mixer_pills_note") || InventoryController.ic.isItemInInventory("mixer_catalyst_note"))
      this.setCollider(1);
    else
      this.setCollider(0);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
