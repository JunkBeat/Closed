// Decompiled with JetBrains decompiler
// Type: Door2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class Door2 : ObjectActionController
{
  private AudioClip soundOpen;
  private AudioClip soundClose;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = true;
    this.characterAnimationName = "action1_e";
    this.actionMarker = this.gameObject.transform.Find("Action_Open").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "basedoor";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("key2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("towel_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("towel_2", string.Empty, anim: string.Empty));
    this.updateState();
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
    else if (this.usedItem == "towel_1" || this.usedItem == "towel_2")
    {
      if (GameDataController.gd.getObjective("location01_door2_open"))
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "generic_close_first"), true);
      else if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 1 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 1)
      {
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "towel_already"), true);
      }
      else
      {
        if (this.usedItem == "towel_1")
        {
          InventoryController.ic.removeItem("towel_1");
          ItemsManager.im.updateItem("towel_1", "nowhere", 0, 0);
          PlayerController.pc.aS.PlayOneShot(ItemsManager.im.getItem("towel_1").sound);
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "towel_placed"), true);
          GameDataController.gd.setObjectiveDetail("towel_1_at_door", 1);
        }
        else if (this.usedItem == "towel_2")
        {
          InventoryController.ic.removeItem("towel_2");
          ItemsManager.im.updateItem("towel_2", "nowhere", 0, 0);
          PlayerController.pc.aS.PlayOneShot(ItemsManager.im.getItem("towel_1").sound);
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "towel_placed"), true);
          GameDataController.gd.setObjectiveDetail("towel_2_at_door", 1);
        }
        this.updateState();
      }
    }
    else if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 1 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 1)
    {
      if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 1 && InventoryController.ic.pickUpItem(ItemsManager.im.getItem("towel_1")))
      {
        GameDataController.gd.setObjectiveDetail("towel_1_at_door", 0);
        GameObject.Find("towels").transform.Find("towel_1_r1").GetComponent<SpriteRenderer>().enabled = false;
      }
      if (GameDataController.gd.getObjectiveDetail("towel_2_at_door") != 1 || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("towel_2")))
        return;
      GameDataController.gd.setObjectiveDetail("towel_2_at_door", 0);
      GameObject.Find("towels").transform.Find("towel_2_r1").GetComponent<SpriteRenderer>().enabled = false;
    }
    else if (GameDataController.gd.getObjective("location01_door2_locked"))
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_locked);
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "generic_locked"), true);
    }
    else
    {
      if (GameDataController.gd.getObjective("location01_door2_open"))
      {
        this.gameObject.GetComponent<Animator>().Play("door2_close", 0);
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_close_02);
      }
      else
      {
        this.gameObject.GetComponent<Animator>().Play("door2_open", 0);
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_open_02);
      }
      GameDataController.gd.setObjective("location01_door2_open", !GameDataController.gd.getObjective("location01_door2_open"));
      GameObject.Find("Door2_Exit").GetComponent<Door2_Exit>().updateState();
    }
  }

  public override void updateState()
  {
    MonoBehaviour.print((object) "UPDATING DOOR STATE");
    if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 1)
    {
      GameObject.Find("towels").transform.Find("towel_1_r1").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("towels").transform.Find("towel_2_r1").GetComponent<SpriteRenderer>().enabled = false;
    }
    else if (GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 1)
    {
      GameObject.Find("towels").transform.Find("towel_2_r1").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("towels").transform.Find("towel_1_r1").GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      GameObject.Find("towels").transform.Find("towel_2_r1").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("towels").transform.Find("towel_1_r1").GetComponent<SpriteRenderer>().enabled = false;
    }
    if (GameDataController.gd.getObjective("location01_door2_open"))
    {
      this.characterAnimationName = "action2_ne";
      this.actionMarker = this.gameObject.transform.Find("Action_Close").gameObject;
      this.gameObject.GetComponent<Animator>().Play("door2_opened", 0);
      this.colliderManager.setCollider(1);
    }
    else
    {
      this.characterAnimationName = "action1_e";
      this.actionMarker = this.gameObject.transform.Find("Action_Open").gameObject;
      this.gameObject.GetComponent<Animator>().Play("door2_closed", 0);
      this.colliderManager.setCollider(0);
    }
    GameObject.Find("Door2_Exit").GetComponent<Door2_Exit>().updateState();
  }

  public override void whatOnClick()
  {
    if (this.usedItem == "towel_1" || this.usedItem == "towel_2")
    {
      if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 1 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 1)
        this.characterAnimationName = "action_stnd_e";
      else
        this.characterAnimationName = "kneel_e";
    }
    else if (this.usedItem == "key2")
    {
      if (GameDataController.gd.getObjective("location01_door2_open"))
        this.characterAnimationName = "action_stnd_e";
      else
        this.characterAnimationName = "action1_e_lock";
    }
    else if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 1 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 1)
      this.characterAnimationName = "kneel_e";
    else if (GameDataController.gd.getObjective("location01_door2_locked"))
      this.characterAnimationName = "action1_e_lock";
    else if (GameDataController.gd.getObjective("location01_door2_open"))
      this.characterAnimationName = "action2_ne";
    else
      this.characterAnimationName = "action1_e";
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
