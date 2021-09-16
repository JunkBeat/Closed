// Decompiled with JetBrains decompiler
// Type: LocationMoonbase2_1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationMoonbase2_1 : ObjectActionController
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
    this.trans_dir = WalkController.Direction.W;
    this.doubleClickCondition = "moon_allow_fast_travel_now";
    if (!GameDataController.gd.getObjective("moon_light_failed"))
      return;
    this.GetComponent<AudioSource>().clip = SoundsManagerController.sm.ambient_ship_crashed;
    this.GetComponent<AudioSource>().gameObject.GetComponent<AudioReverbFilter>().reverbPreset = AudioReverbPreset.PaddedCell;
    this.GetComponent<AudioSource>().volume = 0.75f;
    this.GetComponent<AudioSource>().loop = true;
    this.GetComponent<AudioSource>().pitch = 0.25f;
    this.GetComponent<AudioSource>().time = this.GetComponent<AudioSource>().clip.length * Random.Range(0.0f, 0.9f);
    this.GetComponent<AudioSource>().Play();
  }

  public void jump() => PlayerController.wc.setSimpleTargetV3(GameObject.Find("jump_here").transform.position);

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "LocationMoonbase1_2";
    if (GameDataController.gd.getObjective("moon_window_cracked"))
      CurtainController.cc.fadeOut("LocationMoonbase1", WalkController.Direction.W, "jump_side", SoundsManagerController.sm.break_glass_big, true);
    else
      CurtainController.cc.fadeOut("LocationMoonbase1", WalkController.Direction.W);
  }

  public override void updateState()
  {
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
