// Decompiled with JetBrains decompiler
// Type: Moonbase2CardReader
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Moonbase2CardReader : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "action1_e";
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "moon_card_reader";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("outpost_card", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("sidereal_id_key", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("moon_card", string.Empty, anim: string.Empty));
    this.updateAll();
  }

  public void pressit(string s = "")
  {
    this.Invoke("scansound", 0.5f);
    this.Invoke("scanfail", 1f);
  }

  public void pressit2(string s = "")
  {
    this.Invoke("scansound", 0.5f);
    this.Invoke("scansuccess", 1f);
  }

  public void scansound() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.fingerscan);

  public void failsound(string s = "") => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.fail1);

  public void successsound(string s = "")
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2);
    this.updateAll();
  }

  public void scanfail()
  {
    TimelineAction timelineAction = new TimelineAction();
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = PlayerController.pc.textField,
      textColor = new Vector3(1f, 0.0f, 0.0f),
      backgroundColor = new Vector3(0.5f, 0.0f, 0.0f),
      text = GameStrings.getString(GameStrings.actions, "card_reader_1"),
      actionWithText = true,
      function = new TimelineFunction(this.failsound)
    });
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = PlayerController.pc.textField,
      textColor = new Vector3(1f, 0.0f, 0.0f),
      backgroundColor = new Vector3(0.5f, 0.0f, 0.0f),
      text = GameStrings.getString(GameStrings.actions, "card_reader_2"),
      actionWithText = false
    });
  }

  public override void clickAction()
  {
    if (this.usedItem == "sidereal_id" || this.usedItem == "outpost_card")
      this.pressit(string.Empty);
    else if (this.usedItem == "moon_card")
      this.pressit2(string.Empty);
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "card_needed"));
  }

  public void scansuccess()
  {
    TimelineAction timelineAction = new TimelineAction();
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = PlayerController.pc.textField,
      textColor = new Vector3(0.0f, 1f, 0.0f),
      backgroundColor = new Vector3(0.0f, 0.5f, 0.0f),
      text = GameStrings.getString(GameStrings.actions, "card_reader_3"),
      actionWithText = true,
      function = new TimelineFunction(this.successsound)
    });
    GameDataController.gd.setObjective("moon_card_used", true);
  }

  public override void whatOnClick0()
  {
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    if (!(this.usedItem != string.Empty))
      return;
    this.characterAnimationName = "action_n_busy2";
    this.animationFlip = false;
    this.useCurrentDirection = false;
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
