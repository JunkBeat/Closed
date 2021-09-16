// Decompiled with JetBrains decompiler
// Type: LocationHouseBDeadBarry
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationHouseBDeadBarry : ObjectActionController
{
  public Sprite heat;
  public Sprite cold;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "dead_barry";
    this.range = 50f;
    this.teleport = false;
    this.updateState();
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    Vector3 color = GingerActionController.getColor();
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    string prefix = GameDataController.gd.getObjective("dialogue_npc2_house_blocked") || GameDataController.gd.getObjective("dialogue_npc2_intro") ? "houseb_dead_barry_known" : "houseb_dead_barry_unknown";
    DialogueController.dc.initDialogue(dialogueLines, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    GameDataController.gd.setObjective("house_b_dead_barry_commented", true);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getCurrentDay() > 2 && !GameDataController.gd.getObjective("npc2_joined"))
    {
      this.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
      {
        this.GetComponent<SpriteRenderer>().sprite = this.heat;
        this.objectName = "dead_barry_heat";
      }
      else
      {
        this.GetComponent<SpriteRenderer>().sprite = this.cold;
        this.objectName = "dead_barry_cold";
      }
    }
    else
    {
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
