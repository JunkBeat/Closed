// Decompiled with JetBrains decompiler
// Type: HouseBBackBody
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class HouseBBackBody : ObjectActionController
{
  public Sprite sprite1;
  public Sprite sprite2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.range = 20f;
    this.dkvs = GameStrings.objects;
    this.objectName = "house_b_back_body";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("shovel", GameStrings.getString(GameStrings.actions, "shovel_body"), anim: string.Empty));
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() > 2)
    {
      List<DialogueLine> dialogueLineList = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLineList, "wife_too_late", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<GingerActionController>().textField, GingerActionController.getColor());
      Timeline.t.addDialogueLines(dialogueLineList);
    }
    else if (GameDataController.gd.getObjective("house_b_grave_dug") && !GameDataController.gd.getObjective("house_b_grave_filled"))
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "house_b_wife_time_for_barry"), true);
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "house_b_wife_needs_grave"), true);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("house_b_grave_filled") || !GameDataController.gd.getObjective("house_b_wife_moved"))
    {
      this.colliderManager.setCollider(-1);
      this.characterAnimationName = "stand_";
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Body2").GetComponent<SpriteRenderer>().enabled = false;
    }
    else if (!GameDataController.gd.getObjective("house_b_grave_filled") && GameDataController.gd.getObjective("house_b_body_in_grave"))
    {
      this.colliderManager.setCollider(0);
      this.characterAnimationName = "stand_";
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Body2").GetComponent<SpriteRenderer>().enabled = true;
    }
    else
    {
      this.colliderManager.setCollider(0);
      this.characterAnimationName = "stand_";
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Body2").GetComponent<SpriteRenderer>().enabled = false;
    }
  }

  public override void whatOnClick()
  {
    if (!GameDataController.gd.getObjective("house_b_grave_dug"))
      this.characterAnimationName = "action_stnd_";
    else
      this.characterAnimationName = "action_stnd_";
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
