﻿// Decompiled with JetBrains decompiler
// Type: OutpostBarsExit
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

public class OutpostBarsExit : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "leave";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.S;
    this.range = 2f;
    this.doubleClickCondition = string.Empty;
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "Waypoint_Outpost7_Bars";
    CurtainController.cc.fadeOut("LocationOutpost7", WalkController.Direction.SW);
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
