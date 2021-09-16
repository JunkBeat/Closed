// Decompiled with JetBrains decompiler
// Type: LocationSiderealF0C2_Waypoint_Outside
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationSiderealF0C2_Waypoint_Outside : ObjectActionController
{
  public SpriteRenderer light1;
  public SpriteRenderer light2;
  public SpriteRenderer overlight;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_exit5";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("sidereal_exit_unlocked"))
    {
      if (GameDataController.gd.getObjective("barry_warned"))
        GameDataController.gd.setObjective("npc2_joined", true);
      if (GameDataController.gd.getObjective("cody_warned"))
        GameDataController.gd.setObjective("npc3_joined", true);
      PlayerController.pc.spawnName = "SiderealOutside3_Waypoint_Inside";
      CurtainController.cc.fadeOut("SiderealOutside3", WalkController.Direction.S, "action_stnd_s");
    }
    else
    {
      GameDataController.gd.setObjective("sidereal_exit_unlocked", true);
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "generic_unlocked"));
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.crowbar_pry_open);
      this.updateAll();
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("sidereal_exit_unlocked"))
    {
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.doubleClickCondition = "visited_sidereal_outside_3";
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.actionType = ObjectActionController.Type.Transition;
      this.trans_dir = WalkController.Direction.N;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.light1.enabled = false;
      this.light2.enabled = true;
      this.overlight.enabled = true;
    }
    else
    {
      this.characterAnimationName = "open_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.doubleClickCondition = string.Empty;
      this.actionType = ObjectActionController.Type.NormalAction;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.light1.enabled = true;
      this.light2.enabled = false;
      this.overlight.enabled = false;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
