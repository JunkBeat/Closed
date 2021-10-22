// Decompiled with JetBrains decompiler
// Type: LocationSiderealF1C_Waypoint_S
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationSiderealF1C_Waypoint_S : ObjectActionController
{
  public Sprite pipe;
  public Sprite door;
  public Sprite open;
  public PolygonCollider2D pipeobs;
  public GameObject actionMarker1;
  public GameObject actionMarker2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "pull2_w";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_pipe";
    this.range = 3f;
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("sidereal_barry_pipe_moved"))
      return;
    if (GameDataController.gd.getObjective("sidereal_f1c_s_open"))
    {
      PlayerController.pc.spawnName = "LocationSiderealF1S_Waypoint_C";
      CurtainController.cc.fadeOut("SiderealF1S", WalkController.Direction.W);
    }
    else
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_door_open);
      GameDataController.gd.setObjective("sidereal_f1c_s_open", true);
      this.updateAll();
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_A") != 15 || GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_B") != 40)
    {
      this.setCollider(-1);
    }
    else
    {
      if (GameDataController.gd.getObjective("sidereal_barry_pipe_moved"))
      {
        this.actionMarker = this.actionMarker2;
        this.setCollider(1);
        if (GameDataController.gd.getObjective("sidereal_f1c_s_open"))
        {
          this.gameObject.GetComponent<SpriteRenderer>().sprite = this.open;
          this.characterAnimationName = "stop";
          this.animationFlip = false;
          this.useCurrentDirection = true;
          this.objectName = "sidereal_exit4";
          this.actionType = ObjectActionController.Type.Transition;
          this.trans_dir = WalkController.Direction.W;
        }
        else
        {
          this.characterAnimationName = "open_door2";
          this.animationFlip = true;
          this.useCurrentDirection = false;
          this.objectName = "sidereal_door2";
          this.gameObject.GetComponent<SpriteRenderer>().sprite = this.door;
          this.actionType = ObjectActionController.Type.NormalAction;
        }
      }
      else
      {
        this.characterAnimationName = "pull2_w";
        this.animationFlip = false;
        this.useCurrentDirection = false;
        this.objectName = "sidereal_pipe";
        this.actionType = ObjectActionController.Type.NormalAction;
        this.actionMarker = this.actionMarker1;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.pipe;
        this.setCollider(0);
      }
      GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
    }
  }

  public override void clickAction2()
  {
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "sidereal_pipe_too_heavy"), true);
    GameDataController.gd.setObjective("sidereal_pipe_tried", true);
  }

  public override void clickAction0()
  {
  }

  public void pushLittleCart()
  {
    GameDataController.gd.setObjective("sidereal_barry_pipe_moved", true);
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.SW, animation: "stand_se", flipX: true, actionAfterFade: new CurtainController.Delegate(this.positionThem));
    this.pipeobs.enabled = false;
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_moan);
    GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
  }

  public void positionThem()
  {
    DialogueController.dc.talking = false;
    DialogueController.dc.hide();
    PlayerController.pc.setBusy(false);
    GameObject.Find("Npc2").GetComponent<NPCWalkController>().currentXY = new Vector2(40f, 35f);
    GameObject.Find("Npc2").GetComponent<NPCWalkController>().setSimpleTarget(GameObject.Find("Npc2").GetComponent<NPCWalkController>().currentXY);
    GameObject.Find("Player").GetComponent<WalkController>().currentXY = new Vector2(55f, 45f);
    GameObject.Find("Player").GetComponent<WalkController>().setSimpleTarget(GameObject.Find("Player").GetComponent<WalkController>().currentXY);
  }
}
