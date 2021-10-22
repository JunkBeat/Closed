// Decompiled with JetBrains decompiler
// Type: Waypoint_Outpost6_7
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class Waypoint_Outpost6_7 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_control_room";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.range = 2f;
    this.doubleClickCondition = "visited_outpost7";
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("outpost_control_room_open"))
    {
      PlayerController.pc.spawnName = "Waypoint_Outpost7_6";
      CurtainController.cc.fadeOut("LocationOutpost7", WalkController.Direction.S);
    }
    else
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_door_open);
      GameDataController.gd.setObjective("outpost_control_room_open", true);
      this.updateAll();
    }
  }

  public void rideDown()
  {
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("outpost_control_room_open"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.actionType = ObjectActionController.Type.Transition;
      this.trans_dir = WalkController.Direction.N;
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.actionType = ObjectActionController.Type.NormalAction;
      this.characterAnimationName = "action_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
