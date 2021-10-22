// Decompiled with JetBrains decompiler
// Type: SiderealOutside3_Waypoint_Inside
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class SiderealOutside3_Waypoint_Inside : ObjectActionController
{
  public Sprite closed;
  public Sprite open;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "pull2_w";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_outside_door2";
    this.range = 1f;
    this.teleport = false;
    this.updateState();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("crowbar", string.Empty, anim: string.Empty));
    this.trans_dir = WalkController.Direction.N;
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void whatOnClick0()
  {
    if (this.usedItem == "crowbar")
    {
      this.characterAnimationName = "crowbar_e";
      this.animationFlip = false;
    }
    else
    {
      if (GameDataController.gd.getObjective("sidereal_exit_unlocked"))
        this.characterAnimationName = "action_stnd_n";
      else
        this.characterAnimationName = "pull2_w";
      this.animationFlip = true;
    }
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("sidereal_exit_unlocked"))
    {
      PlayerController.pc.spawnName = "LocationSiderealF0C2_Waypoint_Outside";
      CurtainController.cc.fadeOut("SiderealF0C2", WalkController.Direction.S);
    }
    else if (this.usedItem == "crowbar")
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_crowbar_fail"));
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_entrance_locked_from_other_side"));
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("sidereal_exit_unlocked"))
    {
      this.actionType = ObjectActionController.Type.Transition;
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.objectName = "sidereal_outside_door2";
      this.doubleClickCondition = "visited_sidereal_f0c3";
    }
    else
    {
      this.objectName = "sidereal_outside_door";
      this.actionType = ObjectActionController.Type.NormalAction;
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.doubleClickCondition = string.Empty;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
