// Decompiled with JetBrains decompiler
// Type: rv_body2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class rv_body2 : ObjectActionController
{
  public Sprite gas;
  public Sprite bugs;
  public Sprite ice;
  public Sprite heat;
  public Sprite spiders;
  public Sprite gone;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "rv_body2_gas";
    this.range = 1f;
  }

  public override void clickAction()
  {
    Vector3 color = GingerActionController.getColor();
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, nameof (rv_body2), PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
    Timeline.t.addDialogue(dialogueLines[0]);
    if (!GameDataController.gd.getObjective("npc2_joined"))
      return;
    for (int index = 1; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getCurrentDay() < 3)
    {
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      {
        this.objectName = "rv_body2_bugs";
        this.GetComponent<SpriteRenderer>().sprite = this.bugs;
      }
      else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
      {
        this.objectName = "rv_body2_gas";
        this.GetComponent<SpriteRenderer>().sprite = this.gas;
      }
      else
      {
        if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 2)
          return;
        this.objectName = "rv_body2_spiders";
        this.GetComponent<SpriteRenderer>().sprite = this.spiders;
      }
    }
    else if (GameDataController.gd.getCurrentDay() == 3)
    {
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
      {
        this.objectName = "rv_body2_hot";
        this.GetComponent<SpriteRenderer>().sprite = this.heat;
      }
      else
      {
        if (GameDataController.gd.getObjectiveDetail("day_2_threat") != 1)
          return;
        this.objectName = "rv_body2_cold";
        this.GetComponent<SpriteRenderer>().sprite = this.ice;
      }
    }
    else
    {
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().sprite = this.gone;
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
