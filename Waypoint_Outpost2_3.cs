// Decompiled with JetBrains decompiler
// Type: Waypoint_Outpost2_3
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Waypoint_Outpost2_3 : ObjectActionController
{
  public SpriteRenderer mataEl;
  public LocationOutpostOutside2Start loc;
  public SpriteRenderer sr;
  public Animator animator;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_base_entrance1";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.doubleClickCondition = "outpost_door_open";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("sidereal_id", string.Empty, anim: string.Empty));
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("outpost_door_open"))
    {
      PlayerController.pc.spawnName = "Waypoint_Outpost3_2";
      CurtainController.cc.fadeOut("LocationOutpost3", WalkController.Direction.E);
    }
    else if (this.usedItem == string.Empty)
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_door_locked);
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "generic_locked"));
    }
    else
    {
      GameDataController.gd.setObjective("outpost_door_open", true);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_slide);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click1);
      GameDataController.gd.setObjective("outpost_doormat_triggered", false);
      GameDataController.gd.setObjectiveDetail("outpost_doormat_triggered", 0);
      this.mataEl.enabled = false;
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.small_powerdown);
      this.loc.letItGo();
      this.animator.Play("outside_door_opening");
      this.actionType = ObjectActionController.Type.Transition;
      this.objectName = "outpost_base_entrance2";
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
  }

  public void closedo()
  {
    this.actionType = ObjectActionController.Type.NormalAction;
    this.animator.Play("outside_door_closing");
    this.objectName = "outpost_base_entrance1";
    this.characterAnimationName = "action_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("outpost_door_open"))
    {
      this.animator.Play("outside_door_open");
      this.actionType = ObjectActionController.Type.Transition;
      this.objectName = "outpost_base_entrance2";
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
    else
    {
      this.actionType = ObjectActionController.Type.NormalAction;
      this.animator.Play("outside_door_closed");
      this.objectName = "outpost_base_entrance1";
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
