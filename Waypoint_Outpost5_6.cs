// Decompiled with JetBrains decompiler
// Type: Waypoint_Outpost5_6
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class Waypoint_Outpost5_6 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_doorway";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.range = 2f;
    this.doubleClickCondition = "visited_outpost6";
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("outpost_hall_open"))
    {
      PlayerController.pc.spawnName = "Waypoint_Outpost6_5";
      CurtainController.cc.fadeOut("LocationOutpost6", WalkController.Direction.S);
    }
    else if (GameDataController.gd.getObjective("outpost_hall_unlocked"))
    {
      GameDataController.gd.setObjective("outpost_hall_open", true);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_door_open);
      this.updateAll();
    }
    else
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_door_locked);
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "generic_locked"));
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("outpost_hall_open"))
      this.GetComponent<SpriteRenderer>().enabled = true;
    else
      this.GetComponent<SpriteRenderer>().enabled = false;
    if (GameDataController.gd.getObjective("outpost_hall_open"))
    {
      this.actionType = ObjectActionController.Type.Transition;
      this.trans_dir = WalkController.Direction.N;
      this.range = 2f;
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.objectName = "outpost_staircase";
    }
    else
    {
      this.objectName = "outpost_doorway";
      this.actionType = ObjectActionController.Type.NormalAction;
      this.trans_dir = WalkController.Direction.N;
      this.range = 2f;
      if (GameDataController.gd.getObjective("outpost_hall_unlocked"))
        this.characterAnimationName = "open_n";
      else
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
