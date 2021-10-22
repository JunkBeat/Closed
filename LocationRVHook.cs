// Decompiled with JetBrains decompiler
// Type: LocationRVHook
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationRVHook : ObjectActionController
{
  public Sprite painting;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "rv_hook";
    this.range = 2f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("wrench", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rope", string.Empty, anim: string.Empty));
  }

  public override void clickAction()
  {
    if (this.usedItem == "wrench")
    {
      InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("hook"));
      GameDataController.gd.setObjective("rv_hook_taken", true);
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "rv_hook_detach"));
      this.updateState();
    }
    else if (this.usedItem == "rope")
    {
      Vector3 color = GingerActionController.getColor();
      TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "rv_rope", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
      Timeline.t.addDialogue(dialogueLines[0]);
      for (int index = 1; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "rv_hook"));
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjective("rv_hook_taken"))
    {
      this.colliderManager.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      this.colliderManager.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
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
    if (this.usedItem == "wrench")
    {
      this.range = 2f;
      this.characterAnimationName = "kneel_n";
      this.useCurrentDirection = false;
    }
    else
    {
      this.range = 20f;
      this.characterAnimationName = "action_stnd_";
      this.useCurrentDirection = true;
    }
  }

  public override void whatOnClick()
  {
  }
}
