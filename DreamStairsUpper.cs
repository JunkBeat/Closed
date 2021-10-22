﻿// Decompiled with JetBrains decompiler
// Type: DreamStairsUpper
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class DreamStairsUpper : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "dream_stairs";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.S;
    this.doubleClickCondition = string.Empty;
  }

  public override void clickAction()
  {
    GameDataController.gd.setObjective("dream_day_3b_started", false);
    PlayerController.pc.spawnName = "DreamStairs";
    CurtainController.cc.fadeOut("Dream3", WalkController.Direction.W);
  }

  private void climbCrane()
  {
  }

  public override void updateState() => this.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
