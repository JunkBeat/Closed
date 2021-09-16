// Decompiled with JetBrains decompiler
// Type: WaypointRV12
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class WaypointRV12 : ObjectActionController
{
  public Sprite doorClosed;
  public Sprite doorOpen;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "rv_door";
    this.actionType = ObjectActionController.Type.Transition;
    this.doubleClickCondition = "visited_rv2";
    this.trans_dir = WalkController.Direction.N;
    this.range = 2f;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("rv_door_open"))
    {
      PlayerController.pc.spawnName = "WaypointRV21";
      CurtainController.cc.fadeOut("LocationRV2", WalkController.Direction.N);
    }
    else
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.fridge);
      GameDataController.gd.setObjective("rv_door_open", true);
      this.updateAll();
    }
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjective("rv_door_open"))
    {
      this.GetComponent<SpriteRenderer>().sprite = this.doorOpen;
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.actionType = ObjectActionController.Type.Transition;
    }
    else
    {
      this.GetComponent<SpriteRenderer>().sprite = this.doorClosed;
      this.characterAnimationName = "action_open_ne";
      this.animationFlip = true;
      this.useCurrentDirection = false;
      this.actionType = ObjectActionController.Type.NormalAction;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
