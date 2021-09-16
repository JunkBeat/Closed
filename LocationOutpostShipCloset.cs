// Decompiled with JetBrains decompiler
// Type: LocationOutpostShipCloset
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class LocationOutpostShipCloset : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_s";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_ship_closet";
    this.range = 1f;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("outpost_cabinet_open"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "outpost_cabinet_open"));
    }
    else
    {
      GameDataController.gd.setObjective("outpost_cabinet_open", true);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.cabinet_open);
      this.gameObject.GetComponent<Animator>().Play("closet_open");
      Vector3 color_b = new Vector3(0.8078431f, 0.2235294f, 0.1764706f);
      TextFieldController component = GameObject.Find("ExamineSprite").GetComponent<TextFieldController>();
      ExamineSprite.es.textField.shift.x = -40f;
      ExamineSprite.es.textField.shift.y = 70f;
      ExamineSprite.es.textField.center = true;
      ExamineSprite.es.textField.directionY = -1f;
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "ship_closet", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color_b);
      dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.upd);
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
    }
  }

  public void upd(string a = "") => this.updateState();

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("outpost_cabinet_open"))
    {
      this.colliderManager.setCollider(1);
      this.GetComponent<Animator>().Play("closet_opened");
      this.objectName = "outpost_ship_closet_open";
      this.characterAnimationName = "action_stnd_s";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.range = 3f;
    }
    else
    {
      this.colliderManager.setCollider(0);
      this.GetComponent<Animator>().Play("closet_closed");
      this.objectName = "outpost_ship_closet";
      this.characterAnimationName = "kneel_s";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.range = 1f;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}
