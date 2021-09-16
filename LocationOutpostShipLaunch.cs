// Decompiled with JetBrains decompiler
// Type: LocationOutpostShipLaunch
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class LocationOutpostShipLaunch : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    this.objectName = "ship_launch_console";
    this.range = 100f;
  }

  public override void clickAction()
  {
    Vector3 color = GingerActionController.getColor();
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    if (!GameDataController.gd.getObjective("outpost_hatch_open"))
      DialogueController.dc.initDialogue(dialogueLines, "cant_launch_hatch", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
    else if ((double) InventoryController.ic.getCurrentWeight() > 1.0)
      DialogueController.dc.initDialogue(dialogueLines, "cant_launch_weight", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
    else if (GameDataController.gd.getItemData("welder").droppedLocation == "socket_ship_inside")
    {
      DialogueController.dc.initDialogue(dialogueLines, "cant_launch_welder", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
    }
    else
    {
      DialogueController.dc.initDialogue(dialogueLines, "can_launch", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
      dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.showQuestion);
    }
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  public void showQuestion(string s = "") => GameObject.Find("clock").GetComponent<ClockController>().showEndDialogue("launch_ship", "equip_nothing2");

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
