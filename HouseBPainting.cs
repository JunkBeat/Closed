// Decompiled with JetBrains decompiler
// Type: HouseBPainting
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class HouseBPainting : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "house_b_painting";
    this.range = 10f;
  }

  public override void clickAction()
  {
    List<DialogueLine> dialogueLineList = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLineList, "house_b_painting", PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
    Timeline.t.addDialogueLines(dialogueLineList);
  }

  public void gateIsOpen()
  {
  }

  public void gateIsOpening()
  {
  }

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
