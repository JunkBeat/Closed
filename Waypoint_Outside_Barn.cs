// Decompiled with JetBrains decompiler
// Type: Waypoint_Outside_Barn
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class Waypoint_Outside_Barn : ObjectActionController
{
  private AudioSource aS;
  private AudioClip engineRun;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "barn_entry";
    this.doubleClickCondition = "visited_barn";
    this.engineRun = SoundsManagerController.sm.engine_run;
    this.aS = this.gameObject.AddComponent<AudioSource>();
    if (GameDataController.gd.getObjectiveDetail("barn_pump_started") != 0 && GameDataController.gd.getObjective("barn_pump_started"))
    {
      this.aS.clip = this.engineRun;
      this.aS.loop = true;
      this.aS.volume = 0.1f;
      this.aS.Play();
    }
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "Waypoint_Barn_Outside";
    CurtainController.cc.fadeOut("Barn", WalkController.Direction.E);
  }

  public override void updateState() => this.colliderManager.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
