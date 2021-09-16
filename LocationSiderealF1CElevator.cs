// Decompiled with JetBrains decompiler
// Type: LocationSiderealF1CElevator
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationSiderealF1CElevator : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_elevator_closed";
    this.range = 1f;
    this.teleport = false;
    this.updateState();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("fire_hose", string.Empty, anim: string.Empty));
  }

  private void Update()
  {
  }

  public override void whatOnClick0()
  {
    if (GameDataController.gd.getObjective("sidereal_elevator_f1_hosed") || this.usedItem == "fire_hose" && GameDataController.gd.getObjective("sidereal_elevator_f1_open"))
    {
      if (GameDataController.gd.getObjective("sidereal_elevator_f1_hosed"))
      {
        this.characterAnimationName = "kneel_in_n";
        this.animationFlip = false;
        this.useCurrentDirection = false;
      }
      else
      {
        this.characterAnimationName = "kneel_";
        this.animationFlip = false;
        this.useCurrentDirection = true;
      }
      this.range = 1f;
    }
    else if (GameDataController.gd.getObjective("sidereal_elevator_f1_open") || this.usedItem == "fire_hose")
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 100f;
    }
    else
    {
      this.characterAnimationName = "action1_e";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.range = 1f;
    }
  }

  private void climb()
  {
    PlayerController.pc.spawnName = "LocationSiderealF0C_Waypoint_F1";
    CurtainController.cc.fadeOut("SiderealF0C", WalkController.Direction.E);
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("sidereal_elevator_f1_open"))
    {
      if (this.usedItem == "fire_hose")
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.rope);
        GameDataController.gd.setObjective("sidereal_elevator_f1_hosed", true);
        this.updateAll();
      }
      else if (GameDataController.gd.getObjective("sidereal_elevator_f1_hosed"))
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "sidereal_elevator_down"), yesClick: new Button.Delegate(this.climb), time: 5);
      else
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "sidereal_elevator1"), true, mwidth: 150);
    }
    else if (this.usedItem == "fire_hose")
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_elevator_open_first"));
    }
    else
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_creak1);
      GameDataController.gd.setObjective("sidereal_elevator_f1_open", true);
      this.updateState();
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("sidereal_elevator_f1_hosed"))
    {
      this.objectName = "sidereal_elevator_1";
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.actionType = ObjectActionController.Type.Transition;
      this.trans_dir = WalkController.Direction.S;
      this.doubleClickCondition = string.Empty;
    }
    else if (GameDataController.gd.getObjective("sidereal_elevator_f1_open"))
    {
      this.objectName = "sidereal_elevator_2";
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.actionType = ObjectActionController.Type.NormalAction;
      this.doubleClickCondition = string.Empty;
    }
    else
    {
      this.objectName = "sidereal_elevator_closed";
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.actionType = ObjectActionController.Type.NormalAction;
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
