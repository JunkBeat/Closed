// Decompiled with JetBrains decompiler
// Type: Waypoint_Outpost3_4
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class Waypoint_Outpost3_4 : ObjectActionController
{
  private SpriteRenderer sr;
  private Animator animator;
  private AudioSource aS;
  public GameObject actionRide;
  public GameObject actionCall;
  private bool cickedAlready;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_elevator";
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
    {
      this.cickedAlready = false;
    }
    else
    {
      if (!GameDataController.gd.getObjective("outpost_elevator_powered"))
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "outpost_elevator_no_power"));
        this.clickIt();
      }
      if (!GameDataController.gd.getObjective("outpost_elevator_up"))
        return;
      if (GameDataController.gd.getObjective("outpost_elevator_open"))
      {
        if (!GameDataController.gd.getObjective("outpost_door_powered"))
        {
          this.playSound("elevator_away");
          this.Invoke("rideDown", 1f);
          PlayerController.wc.forceAnimationForAnimationEvent("stand_n");
        }
        else
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "outpost_elevator_no_doormat"));
      }
      else
        PlayerController.pc.setBusy(false);
    }
  }

  public void rideDown0()
  {
  }

  public void rideDown()
  {
    GameDataController.gd.setObjective("outpost_elevator_travel", true);
    PlayerController.pc.spawnName = "Waypoint_Outpost4_3";
    CurtainController.cc.fadeOut("LocationOutpost4", WalkController.Direction.W);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("outpost_elevator_travel"))
    {
      this.playSound("elevator_ding");
      this.playAnimation("elevator_open");
      GameDataController.gd.setObjective("outpost_elevator_travel", false);
      PlayerController.pc.setBusy(true);
      PlayerController.wc.forceAnimation("stand_se", true);
      PlayerController.pc.resumeSoftLockProbe();
    }
    else if (!GameDataController.gd.getObjective("outpost_elevator_powered"))
      this.playAnimation("elevator_closed0");
    else if (GameDataController.gd.getObjective("outpost_elevator_open"))
      this.playAnimation("elevator_opened");
    else if (GameDataController.gd.getObjective("outpost_elevator_up"))
      this.playAnimation("elevator_closed1");
    else
      this.playAnimation("elevator_closed0");
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
    PlayerController.pc.haltSoftLockProbe();
    if (GameDataController.gd.getObjective("outpost_elevator_open") || !GameDataController.gd.getObjective("outpost_elevator_powered"))
      return;
    if (GameDataController.gd.getObjective("outpost_elevator_up"))
    {
      this.cickedAlready = true;
      this.playAnimation("elevator_open");
      GameDataController.gd.setObjective("outpost_elevator_open", true);
    }
    else
    {
      this.cickedAlready = true;
      this.playAnimation("elevator_up");
      GameDataController.gd.setObjective("outpost_elevator_up", true);
      GameDataController.gd.setObjective("outpost_elevator_open", true);
    }
  }

  public void elevatorReady()
  {
    PlayerController.pc.resumeSoftLockProbe();
    PlayerController.wc.fullStop(true);
    PlayerController.pc.setBusy(false);
    PlayerController.wc.forceAnimationForAnimationEvent("action_stnd_n");
    this.updateAll();
    this.closeDoorInFive();
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
      if (GameDataController.gd.getObjective("outpost_door_powered"))
      {
        this.characterAnimationName = "action_stnd_";
        this.animationFlip = false;
        this.useCurrentDirection = true;
        this.range = 100f;
      }
      else
      {
        this.characterAnimationName = "stop";
        this.animationFlip = false;
        this.useCurrentDirection = true;
        this.range = 0.0f;
      }
      this.setCollider(1);
      this.actionMarker = this.actionRide;
      this.actionType = ObjectActionController.Type.Transition;
      this.trans_dir = WalkController.Direction.S;
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
      else
      {
        this.characterAnimationName = "action1_e";
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

  public void closeDoorQuickAndFast()
  {
    GameDataController.gd.setObjective("outpost_elevator_open", false);
    this.updateElevatorLogic();
    this.playAnimation("elevator_closed1");
  }

  public void closeDoorKindly()
  {
    if (!GameDataController.gd.getObjective("outpost_elevator_open"))
      return;
    if ((double) PlayerController.wc.currentXY.x > 150.0 && (double) PlayerController.wc.currentXY.y > 40.0)
    {
      this.closeDoorInFive();
    }
    else
    {
      GameDataController.gd.setObjective("outpost_elevator_open", false);
      this.updateElevatorLogic();
      this.playAnimation("elevator_close");
      if ((double) PlayerController.wc.getFinalTarget().x <= 150.0 && ((double) PlayerController.wc.currentXY.x <= 150.0 || (double) PlayerController.wc.currentXY.y <= 40.0))
        return;
      PlayerController.wc.fullStop(true);
    }
  }
}
