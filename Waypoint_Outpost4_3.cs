// Decompiled with JetBrains decompiler
// Type: Waypoint_Outpost4_3
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class Waypoint_Outpost4_3 : ObjectActionController
{
  private SpriteRenderer sr;
  private Animator animator;
  private AudioSource aS;
  public GameObject actionRide;
  public GameObject actionCall;
  public ObjectZController zindex;
  public ObjectZController zindex2;
  private bool cickedAlready;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_elevator2";
    this.actionType = ObjectActionController.Type.NormalAction;
    this.range = 0.0f;
    this.aS = this.gameObject.GetComponent<AudioSource>();
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
    this.animator = this.gameObject.GetComponent<Animator>();
    this.doubleClickCondition = "none";
  }

  public void playAnimation(string param) => this.animator.Play(param);

  public override void clickAction()
  {
    if (this.cickedAlready)
      this.cickedAlready = false;
    else if (GameDataController.gd.getObjective("outpost_elevator_open"))
    {
      this.playSound("elevator_away");
      this.Invoke("rideDown", 1f);
      PlayerController.wc.forceAnimationForAnimationEvent("stand_n");
    }
    else
      PlayerController.pc.setBusy(false);
  }

  public void rideDown()
  {
    GameDataController.gd.setObjective("outpost_elevator_travel", true);
    PlayerController.pc.spawnName = "Waypoint_Outpost3_4";
    CurtainController.cc.fadeOut("LocationOutpost3", WalkController.Direction.W);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("outpost_elevator_travel"))
    {
      this.playSound("elevator_ding");
      this.playAnimation("elevator2_open");
      GameDataController.gd.setObjective("outpost_elevator_travel", false);
      this.zindex.enabled = false;
      this.zindex2.enabled = true;
      PlayerController.pc.setBusy(true);
    }
    else if (GameDataController.gd.getObjective("outpost_elevator_open"))
    {
      this.playAnimation("elevator2_opened");
      this.zindex.enabled = true;
      this.zindex2.enabled = false;
    }
    else
    {
      this.playAnimation("elevator2_closed");
      this.zindex.enabled = true;
      this.zindex2.enabled = false;
    }
    this.updateElevatorLogic();
  }

  public void playSound(string soundName)
  {
    if (soundName == "elevator_away")
      this.aS.PlayOneShot(SoundsManagerController.sm.elevator_away);
    if (soundName == "elevator_come")
      this.aS.PlayOneShot(SoundsManagerController.sm.elevator_come);
    if (soundName == "elevator_ding")
      this.aS.PlayOneShot(SoundsManagerController.sm.elevator_ding);
    if (!(soundName == "elevator_door"))
      return;
    this.aS.PlayOneShot(SoundsManagerController.sm.elevator_door);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
    this.cickedAlready = false;
    if (GameDataController.gd.getObjective("outpost_elevator_open"))
      return;
    this.cickedAlready = true;
    this.playAnimation("elevator2_open");
    GameDataController.gd.setObjective("outpost_elevator_open", true);
  }

  public void closeDoorQuickAndFast()
  {
    GameDataController.gd.setObjective("outpost_elevator_open", false);
    this.updateElevatorLogic();
    this.playAnimation("elevator2_closed");
  }

  public void elevatorReady()
  {
    PlayerController.pc.setBusy(false);
    PlayerController.wc.forceAnimationForAnimationEvent("action_stnd_n");
    this.updateAll();
    this.closeDoorInFive();
    this.zindex.enabled = true;
    this.zindex2.enabled = false;
  }

  public void closeDoorInFive() => this.Invoke("closeDoorKindly", 5f);

  public void lookAtIt()
  {
  }

  public void clickIt() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.button_click2);

  public void updateElevatorLogic()
  {
    if (GameDataController.gd.getObjective("outpost_elevator_open"))
    {
      GameObject.Find("Location").GetComponent<PolygonCollider2D>().enabled = true;
      GameObject.Find("ClosedElevator").GetComponent<PolygonCollider2D>().enabled = false;
      GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 0.0f;
      this.setCollider(1);
      this.actionMarker = this.actionRide;
      this.actionType = ObjectActionController.Type.Transition;
      this.trans_dir = WalkController.Direction.N;
      this.objectName = "outpost_elevator_open";
    }
    else
    {
      GameObject.Find("Location").GetComponent<PolygonCollider2D>().enabled = false;
      GameObject.Find("ClosedElevator").GetComponent<PolygonCollider2D>().enabled = true;
      GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
      if (GameDataController.gd.getObjective("outpost_elevator_powered"))
      {
        this.characterAnimationName = "action1_e_animation";
        this.animationFlip = false;
        this.useCurrentDirection = false;
      }
      this.setCollider(0);
      this.actionType = ObjectActionController.Type.NormalAction;
      this.objectName = "outpost_elevator";
      this.actionMarker = this.actionCall;
      this.range = 0.0f;
    }
  }

  public void closeDoorKindly()
  {
    if (!GameDataController.gd.getObjective("outpost_elevator_open"))
      return;
    if ((double) PlayerController.wc.currentXY.x > 165.0)
    {
      this.closeDoorInFive();
    }
    else
    {
      GameDataController.gd.setObjective("outpost_elevator_open", false);
      this.updateElevatorLogic();
      this.playAnimation("elevator2_close");
      if ((double) PlayerController.wc.getFinalTarget().x < 165.0 && (double) PlayerController.wc.currentXY.x < 165.0)
        return;
      PlayerController.wc.fullStop(true);
    }
  }
}
