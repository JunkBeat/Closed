// Decompiled with JetBrains decompiler
// Type: LocationMoon2_3
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationMoon2_3 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "moon_base_entrance";
    this.range = 1f;
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.doubleClickCondition = string.Empty;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjectiveDetail("airlock_ring_1") == 0 && GameDataController.gd.getObjectiveDetail("airlock_ring_2") == 0 && GameDataController.gd.getObjectiveDetail("airlock_ring_3") == 0 && GameDataController.gd.getObjectiveDetail("airlock_ring_4") == 0 && GameDataController.gd.getObjectiveDetail("airlock_ring_5") == 0)
    {
      PlayerController.pc.spawnName = "LocationMoon3_Moonbase1";
      CurtainController.cc.fadeOut("LocationMoonbase1", WalkController.Direction.S, "stand_s");
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "airlock_locked"));
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("airlock_ring_1") == 0 && GameDataController.gd.getObjectiveDetail("airlock_ring_2") == 0 && GameDataController.gd.getObjectiveDetail("airlock_ring_3") == 0 && GameDataController.gd.getObjectiveDetail("airlock_ring_4") == 0 && GameDataController.gd.getObjectiveDetail("airlock_ring_5") == 0)
    {
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.actionMarker = this.gameObject.transform.Find("Action_Marker2").gameObject;
      this.range = 1f;
      this.actionType = ObjectActionController.Type.Transition;
      this.trans_dir = WalkController.Direction.N;
      this.GetComponent<SpriteRenderer>().enabled = true;
    }
    else
    {
      this.characterAnimationName = "suit_action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.range = 10f;
      this.actionType = ObjectActionController.Type.NormalAction;
      this.trans_dir = WalkController.Direction.N;
      this.GetComponent<SpriteRenderer>().enabled = false;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
