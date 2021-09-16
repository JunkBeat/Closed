// Decompiled with JetBrains decompiler
// Type: LocationMoonbase1_2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationMoonbase1_2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "moonbase_passage";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.E;
    this.doubleClickCondition = "moon_allow_fast_travel_now";
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("moon_door_closed"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moon_window_broken"));
    }
    else
    {
      PlayerController.pc.spawnName = "LocationMoonbase2_1";
      CurtainController.cc.fadeOut("LocationMoonbase2", WalkController.Direction.E);
    }
  }

  public void zamyk() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_slide);

  public void unlock() => this.Invoke("unlockPlayer", 2f);

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("moon_door_closed"))
    {
      this.GetComponent<Animator>().Play("moon_door_closed");
      this.objectName = "moonbase_passage";
      this.actionType = ObjectActionController.Type.NormalAction;
    }
    else
    {
      this.objectName = "moonbase_passage";
      this.actionType = ObjectActionController.Type.Transition;
      this.trans_dir = WalkController.Direction.E;
      this.GetComponent<Animator>().Play("moon_door_open");
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
