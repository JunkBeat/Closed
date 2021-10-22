// Decompiled with JetBrains decompiler
// Type: Locationoutpost4FingerScanner
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Locationoutpost4FingerScanner : ObjectActionController
{
  public Sprite red;
  public Sprite green;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_fingerscanner";
    this.actionType = ObjectActionController.Type.NormalAction;
    this.range = 2f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("fingerprint", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("finger", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("sidereal_id", GameStrings.getString(GameStrings.actions, "fingerprint_no_card"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("outpost_card", GameStrings.getString(GameStrings.actions, "fingerprint_no_card"), anim: string.Empty));
  }

  public void pressit(string s = "")
  {
    PlayerController.wc.forceAnimation("action_n_busy2");
    Timeline.t.doNotUnlock = true;
    this.Invoke("scansound", 0.5f);
    this.Invoke("scanfail", 1f);
  }

  public void pressit2(string s = "")
  {
    PlayerController.wc.forceAnimation("action_n_busy2");
    Timeline.t.doNotUnlock = true;
    this.Invoke("scansound", 0.5f);
    this.Invoke("scansuccess", 1f);
  }

  public void pressit3(string s = "")
  {
    PlayerController.wc.forceAnimation("action_n_busy2");
    Timeline.t.doNotUnlock = true;
    this.Invoke("scansound", 0.5f);
    this.Invoke("scanfail2", 1f);
  }

  public void scansound() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.fingerscan);

  public void failsound(string s = "") => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.fail1);

  public void successsound(string s = "")
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.auto_unlock);
    this.updateAll();
  }

  public void scanfail()
  {
    TimelineAction timelineAction = new TimelineAction();
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = this.GetComponent<TextFieldController>(),
      textColor = new Vector3(1f, 0.0f, 0.0f),
      backgroundColor = new Vector3(0.5f, 0.0f, 0.0f),
      text = GameStrings.getString(GameStrings.actions, "fingerprint_reader3"),
      actionWithText = true,
      function = new TimelineFunction(this.failsound)
    });
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = PlayerController.pc.textField,
      backgroundColor = new Vector3(0.0f, 0.0f, 0.0f),
      textColor = new Vector3(1f, 1f, 1f),
      text = GameStrings.getString(GameStrings.actions, "fingerprint_reader4"),
      actionWithText = false
    });
  }

  public void scanfail2()
  {
    TimelineAction timelineAction = new TimelineAction();
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = this.GetComponent<TextFieldController>(),
      textColor = new Vector3(1f, 0.0f, 0.0f),
      backgroundColor = new Vector3(0.5f, 0.0f, 0.0f),
      text = GameStrings.getString(GameStrings.actions, "fingerprint_finger2"),
      actionWithText = true,
      function = new TimelineFunction(this.failsound)
    });
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = this.GetComponent<TextFieldController>(),
      textColor = new Vector3(1f, 0.0f, 0.0f),
      backgroundColor = new Vector3(0.5f, 0.0f, 0.0f),
      text = GameStrings.getString(GameStrings.actions, "fingerprint_finger3"),
      actionWithText = true,
      function = new TimelineFunction(this.failsound)
    });
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = PlayerController.pc.textField,
      backgroundColor = new Vector3(0.0f, 0.0f, 0.0f),
      textColor = new Vector3(1f, 1f, 1f),
      text = GameStrings.getString(GameStrings.actions, "fingerprint_finger4"),
      actionWithText = false
    });
  }

  public override void clickAction()
  {
    if (this.usedItem == string.Empty)
    {
      Timeline.t.addAction(new TimelineAction()
      {
        textfield = PlayerController.pc.textField,
        textColor = new Vector3(1f, 1f, 1f),
        backgroundColor = new Vector3(0.0f, 0.0f, 0.0f),
        text = GameStrings.getString(GameStrings.actions, "fingerprint_reader1"),
        actionWithText = false
      });
      Timeline.t.addAction(new TimelineAction()
      {
        textfield = PlayerController.pc.textField,
        textColor = new Vector3(1f, 1f, 1f),
        text = GameStrings.getString(GameStrings.actions, "fingerprint_reader2"),
        actionWithText = true,
        function = new TimelineFunction(this.pressit)
      });
    }
    else if (this.usedItem == "fingerprint")
    {
      InventoryController.ic.removeItem("fingerprint");
      GameDataController.gd.setObjective("outpost_fingerprint_unlocked", true);
      TimelineAction timelineAction = new TimelineAction();
      Timeline.t.addAction(new TimelineAction()
      {
        textfield = PlayerController.pc.textField,
        textColor = new Vector3(1f, 1f, 1f),
        text = GameStrings.getString(GameStrings.actions, "fingerprint_reader5"),
        actionWithText = true,
        function = new TimelineFunction(this.pressit2)
      });
    }
    else
    {
      if (!(this.usedItem == "finger"))
        return;
      InventoryController.ic.removeItem("finger");
      GameDataController.gd.setObjective("outpost_fingerprint_unlocked", true);
      TimelineAction timelineAction = new TimelineAction();
      Timeline.t.addAction(new TimelineAction()
      {
        textfield = PlayerController.pc.textField,
        textColor = new Vector3(1f, 1f, 1f),
        text = GameStrings.getString(GameStrings.actions, "fingerprint_finger1"),
        actionWithText = true,
        function = new TimelineFunction(this.pressit2)
      });
    }
  }

  public void scansuccess()
  {
    TimelineAction timelineAction = new TimelineAction();
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = this.GetComponent<TextFieldController>(),
      textColor = new Vector3(0.0f, 1f, 0.0f),
      backgroundColor = new Vector3(0.0f, 0.5f, 0.0f),
      text = GameStrings.getString(GameStrings.actions, "fingerprint_reader6"),
      actionWithText = true,
      function = new TimelineFunction(this.successsound)
    });
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("outpost_underground_light") < 2)
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.setCollider(-1);
    }
    else if (!GameDataController.gd.getObjective("outpost_fingerprint_unlocked"))
    {
      this.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.GetComponent<SpriteRenderer>().sprite = this.red;
    }
    else
    {
      if (!GameDataController.gd.getObjective("outpost_fingerprint_unlocked"))
        return;
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.GetComponent<SpriteRenderer>().sprite = this.green;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
