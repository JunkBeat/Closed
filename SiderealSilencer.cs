// Decompiled with JetBrains decompiler
// Type: SiderealSilencer
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class SiderealSilencer : ObjectActionController
{
  public SpriteRenderer blik;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.characterAnimationName = "kneel_";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_silencer";
    this.range = 2f;
    this.updateState();
  }

  public override void clickAction() => this.pickItUp((string) null);

  private void pickItUp(string param)
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("silencer")))
      return;
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "sidereal_silencer", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>());
    if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
    {
      Vector3 color1 = GingerActionController.getColor();
      Vector3 color2 = Npc3Controller.getColor();
      TextFieldController component = GameObject.Find("Npc3").GetComponent<TextFieldController>();
      DialogueController.dc.initDialogue(dialogueLines, "sidereal_silencer_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), color1, component, color2);
    }
    if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive"))
    {
      Vector3 color3 = GingerActionController.getColor();
      Vector3 color4 = Npc2Controller.getColor();
      TextFieldController component = GameObject.Find("Npc2").GetComponent<TextFieldController>();
      DialogueController.dc.initDialogue(dialogueLines, "sidereal_silencer_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), color3, component, color4);
    }
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    GameDataController.gd.setObjective("sidereal_silencer", true);
    this.updateAll();
  }

  public override void whatOnClick()
  {
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("sidereal_silencer"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.blik.enabled = false;
      this.colliderManager.setCollider(-1);
    }
    else
    {
      this.colliderManager.setCollider(0);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      if (GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_A") == 50 && GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_B") == 10)
        this.blik.enabled = true;
      else
        this.blik.enabled = false;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
