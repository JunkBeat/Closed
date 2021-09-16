// Decompiled with JetBrains decompiler
// Type: Waypoint_Outpost3_Fusebox
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class Waypoint_Outpost3_Fusebox : ObjectActionController
{
  private SpriteRenderer sr;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "fusebox";
    this.actionType = ObjectActionController.Type.NormalAction;
    this.range = 2f;
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("outpost_elevator_powered") && !GameDataController.gd.getObjective("outpost_door_powered"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "outpost_fusebox_done"));
    else if (GameDataController.gd.getObjective("outpost_fusebox_open"))
    {
      PlayerController.pc.spawnName = "ElectricExit";
      CurtainController.cc.fadeOut("LocationFuseBox", WalkController.Direction.W);
      GameDataController.gd.setObjective("outpost_elevator_open", false);
    }
    else
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.locker_01);
      GameDataController.gd.setObjective("outpost_fusebox_open", true);
      this.updateAll();
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("outpost_fusebox_open"))
    {
      this.sr.enabled = true;
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
    else
    {
      this.sr.enabled = false;
      this.characterAnimationName = "action1_e";
      this.animationFlip = true;
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
