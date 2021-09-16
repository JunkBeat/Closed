// Decompiled with JetBrains decompiler
// Type: Waypoint_Bridge_Ravine
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Waypoint_Bridge_Ravine : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "bridge_ravine";
    this.range = 70f;
  }

  public override void clickAction()
  {
    string label = GameStrings.getString(GameStrings.warnings, "bridge_ravine1");
    if ((double) InventoryController.ic.getCurrentWeight() > 10.0)
      label = label + "^" + GameStrings.getString(GameStrings.warnings, "bridge_ravine2") + " " + (object) InventoryController.ic.getCurrentWeight() + " " + GameStrings.getString(GameStrings.gui, "kg") + " " + GameStrings.getString(GameStrings.warnings, "bridge_ravine3");
    int time = 2 + (int) (2.0 * ((double) InventoryController.ic.getCurrentWeight() / 5.0));
    QuestionController.qc.showQuestion(label, yesClick: new Button.Delegate(this.yesClicked), time: time);
  }

  private void yesClicked()
  {
    PlayerController.pc.setBusy(true);
    if (!GameDataController.gd.getObjective("bridge_westside"))
    {
      GameDataController.gd.setObjective("bridge_westside", true);
      PlayerController.pc.spawnName = "Waypoint_Ravine_West";
      CurtainController.cc.fadeOut("LocationBridge", WalkController.Direction.W);
      this.updateState();
    }
    else
    {
      GameDataController.gd.setObjective("bridge_westside", false);
      PlayerController.pc.spawnName = "Waypoint_Ravine_East";
      CurtainController.cc.fadeOut("LocationBridge", WalkController.Direction.E);
      this.updateState();
    }
  }

  public override void updateState()
  {
    MonoBehaviour.print((object) "UPDATING RAVINE");
    if (GameDataController.gd.getObjective("bridge_planks_used_1"))
    {
      this.colliderManager.setCollider(-1);
      GameObject.Find("Location").GetComponent<PolygonCollider2D>().enabled = true;
      GameObject.Find("LocationEast").GetComponent<PolygonCollider2D>().enabled = false;
      GameObject.Find("LocationWest").GetComponent<PolygonCollider2D>().enabled = false;
      GameObject.Find("bridge_area_collider").GetComponent<PolygonCollider2D>().enabled = true;
      if (GameDataController.gd.getObjective("bridge_planks_used_2"))
        GameObject.Find("LocationMoreBridge").GetComponent<PolygonCollider2D>().enabled = true;
      else
        GameObject.Find("LocationMoreBridge").GetComponent<PolygonCollider2D>().enabled = false;
    }
    else
    {
      MonoBehaviour.print((object) "BRIDGE IS NOT FIXED, SO...");
      GameObject.Find("Location").GetComponent<PolygonCollider2D>().enabled = false;
      GameObject.Find("LocationMoreBridge").GetComponent<PolygonCollider2D>().enabled = false;
      if (GameDataController.gd.getObjective("bridge_westside"))
      {
        this.actionType = ObjectActionController.Type.Transition;
        this.trans_dir = WalkController.Direction.E;
        MonoBehaviour.print((object) "ENABLING WEST SIDE");
        this.colliderManager.setCollider(1);
        GameObject.Find("LocationEast").GetComponent<PolygonCollider2D>().enabled = false;
        GameObject.Find("LocationWest").GetComponent<PolygonCollider2D>().enabled = true;
        GameObject.Find("bridge_area_collider").GetComponent<PolygonCollider2D>().enabled = false;
      }
      else
      {
        MonoBehaviour.print((object) "ENABLING EAST SIDE");
        this.actionType = ObjectActionController.Type.Transition;
        this.trans_dir = WalkController.Direction.W;
        this.colliderManager.setCollider(0);
        GameObject.Find("LocationEast").GetComponent<PolygonCollider2D>().enabled = true;
        GameObject.Find("LocationWest").GetComponent<PolygonCollider2D>().enabled = false;
        GameObject.Find("bridge_area_collider").GetComponent<PolygonCollider2D>().enabled = false;
      }
    }
    GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
