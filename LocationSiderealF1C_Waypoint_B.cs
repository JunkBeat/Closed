// Decompiled with JetBrains decompiler
// Type: LocationSiderealF1C_Waypoint_B
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationSiderealF1C_Waypoint_B : ObjectActionController
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
    this.characterAnimationName = "locked_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_door2";
    this.range = 2f;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("sidereal_f1c_b_open"))
    {
      PlayerController.pc.spawnName = "LocationSiderealF1B_Waypoint_C";
      CurtainController.cc.fadeOut("SiderealF1B", WalkController.Direction.N);
    }
    else
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_locked_1);
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_cody_door_locked"));
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
      this.setCollider(0);
      if (GameDataController.gd.getObjective("sidereal_f1c_b_open"))
      {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        this.characterAnimationName = "stop";
        this.animationFlip = false;
        this.useCurrentDirection = false;
        this.objectName = "sidereal_exit4";
        this.actionType = ObjectActionController.Type.Transition;
        this.trans_dir = WalkController.Direction.N;
      }
      else
      {
        this.characterAnimationName = "locked_n";
        this.animationFlip = false;
        this.useCurrentDirection = false;
        this.objectName = "sidereal_door2";
        this.actionType = ObjectActionController.Type.NormalAction;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      }
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public void pushLittleCart()
  {
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.N, animation: "stand_n", actionAfterFade: new CurtainController.Delegate(this.positionThem));
    GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
  }

  public void positionThem()
  {
    GameDataController.gd.setObjective("sidereal_f1c_b_open", true);
    this.updateAll();
    GameObject.Find("Npc3").GetComponent<NPCWalkController>().currentXY = new Vector2(80f, 60f);
    GameObject.Find("Npc3").GetComponent<NPCWalkController>().setSimpleTarget(GameObject.Find("Npc3").GetComponent<NPCWalkController>().currentXY);
    this.Invoke("walkDown", 1f);
  }

  public void walkDown()
  {
    Vector3 color = Npc3Controller.getColor();
    TextFieldController component = GameObject.Find("Npc3").GetComponent<TextFieldController>();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "cody_vent_open", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    GameObject.Find("Npc3").GetComponent<NPCWalkController>().setSimpleTarget(new Vector2(80f, 30f));
  }
}
