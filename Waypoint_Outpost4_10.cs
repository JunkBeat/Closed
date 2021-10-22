// Decompiled with JetBrains decompiler
// Type: Waypoint_Outpost4_10
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class Waypoint_Outpost4_10 : ObjectActionController
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
    this.doubleClickCondition = "visited_outpost10";
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("outpost_storage_open"))
    {
      PlayerController.pc.spawnName = "Waypoint_Outpost10_4";
      CurtainController.cc.fadeOut("LocationOutpost10", WalkController.Direction.N);
    }
    else if (GameDataController.gd.getObjective("outpost_fingerprint_unlocked"))
    {
      GameDataController.gd.setObjective("outpost_storage_open", true);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_door_open);
      this.updateAll();
    }
    else
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_door_locked);
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "locked_fingerprint"));
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("outpost_storage_open"))
      this.GetComponent<SpriteRenderer>().enabled = true;
    else
      this.GetComponent<SpriteRenderer>().enabled = false;
    if (GameDataController.gd.getObjective("outpost_storage_open"))
    {
      this.actionType = ObjectActionController.Type.Transition;
      this.trans_dir = WalkController.Direction.N;
      this.range = 2f;
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else
    {
      this.actionType = ObjectActionController.Type.NormalAction;
      this.trans_dir = WalkController.Direction.N;
      this.range = 2f;
      if (GameDataController.gd.getObjective("outpost_fingerprint_unlocked"))
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
