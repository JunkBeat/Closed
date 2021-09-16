// Decompiled with JetBrains decompiler
// Type: HuntersLodgeInside1_Waypoint_2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class HuntersLodgeInside1_Waypoint_2 : ObjectActionController
{
  public Sprite no_trap;
  public Sprite boards;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "lodge_to_inside2";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.doubleClickCondition = "visited_hunters_lodge_2";
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "HuntersLodgeInside2_Waypoint_1";
    CurtainController.cc.fadeOut("HuntersLodgeInside2", WalkController.Direction.N);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("hunters_lodge_trap4_taken") || GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
    {
      this.GetComponent<SpriteRenderer>().enabled = true;
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && GameDataController.gd.getObjectiveDetail("lodge_board_taken") < 3)
        this.GetComponent<SpriteRenderer>().sprite = this.boards;
      else
        this.GetComponent<SpriteRenderer>().sprite = this.no_trap;
    }
    else
      this.GetComponent<SpriteRenderer>().enabled = false;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
