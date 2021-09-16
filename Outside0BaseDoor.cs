// Decompiled with JetBrains decompiler
// Type: Outside0BaseDoor
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class Outside0BaseDoor : ObjectActionController
{
  private AudioClip soundOpen;
  private AudioClip soundClose;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "action1_e";
    this.actionMarker = this.gameObject.transform.Find("Action_Open").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "basedoor";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("key2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("pipe", GameStrings.getString(GameStrings.actions, "pipe_door"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("crowbar", GameStrings.getString(GameStrings.actions, "crowbar_door"), anim: string.Empty));
  }

  public override void clickAction()
  {
    if (this.usedItem == "key2")
    {
      if (GameDataController.gd.getObjective("location01_door2_open"))
      {
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "generic_close_first"), true);
      }
      else
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_lock_unlock);
        GameDataController.gd.setObjective("location01_door2_locked", !GameDataController.gd.getObjective("location01_door2_locked"));
      }
    }
    else if (GameDataController.gd.getObjective("location01_door2_locked"))
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_locked);
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "generic_locked"), true);
    }
    else if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 1 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 1)
    {
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "generic_blocked"), true);
    }
    else
    {
      if (GameDataController.gd.getObjective("location01_door2_open"))
      {
        this.gameObject.GetComponent<Animator>().Play("DoorClose", 0);
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_close_02);
      }
      else
      {
        this.gameObject.GetComponent<Animator>().Play("DoorOpen", 0);
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_open_02);
      }
      GameDataController.gd.setObjective("location01_door2_open", !GameDataController.gd.getObjective("location01_door2_open"));
      GameObject.Find("Base_Entry").GetComponent<BaseEntry>().updateState();
    }
  }

  public override void updateState()
  {
    MonoBehaviour.print((object) "UPDATING DOOR STATE");
    if (GameDataController.gd.getObjective("location01_door2_open"))
    {
      this.characterAnimationName = "open_door2";
      this.actionMarker = this.gameObject.transform.Find("Action_Close").gameObject;
      this.gameObject.GetComponent<Animator>().Play("DoorOpened", 0);
      this.colliderManager.setCollider(1);
      this.interactions = new List<ItemInteraction>();
      this.interactions.Add(new ItemInteraction("key2", string.Empty, anim: string.Empty));
    }
    else
    {
      this.characterAnimationName = "action1_e";
      this.actionMarker = this.gameObject.transform.Find("Action_Open").gameObject;
      this.gameObject.GetComponent<Animator>().Play("DoorClosed", 0);
      this.colliderManager.setCollider(0);
      this.interactions = new List<ItemInteraction>();
      this.interactions.Add(new ItemInteraction("key2", string.Empty, anim: string.Empty));
      this.interactions.Add(new ItemInteraction("pipe", GameStrings.getString(GameStrings.actions, "pipe_door"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("crowbar", GameStrings.getString(GameStrings.actions, "crowbar_door"), anim: string.Empty));
    }
    GameObject.Find("Base_Entry").GetComponent<BaseEntry>().updateState();
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick()
  {
    if (this.usedItem == "key2")
    {
      if (GameDataController.gd.getObjective("location01_door2_open"))
        this.characterAnimationName = "action_stnd_e";
      else
        this.characterAnimationName = "action1_e_lock";
    }
    else if (GameDataController.gd.getObjective("location01_door2_locked") || GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 1 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 1)
      this.characterAnimationName = "action1_e_lock";
    else if (GameDataController.gd.getObjective("location01_door2_open"))
      this.characterAnimationName = "open_door2";
    else
      this.characterAnimationName = "action1_e";
  }
}
