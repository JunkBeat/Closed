// Decompiled with JetBrains decompiler
// Type: Tent_Waypoint_Exit
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class Tent_Waypoint_Exit : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "tent_waypoint";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.E;
    this.doubleClickCondition = "impossible";
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("tent_distance_triggered"))
    {
      PlayerController.wc.fullStop(true);
      PlayerController.pc.setBusy(false);
    }
    else
    {
      PlayerController.pc.spawnName = "Fence1Waypoint1";
      CurtainController.cc.fadeOut("LocationDesertFence1", WalkController.Direction.E);
    }
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("tent_awake"))
      this.colliderManager.setCollider(-1);
    else if (!GameDataController.gd.getObjective("tent_backpack_taken"))
    {
      this.colliderManager.setCollider(-1);
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
