// Decompiled with JetBrains decompiler
// Type: KitchenDoor
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class KitchenDoor : ObjectActionController
{
  private AudioClip soundOpen;
  private AudioClip soundClose;
  private SpriteRenderer darkness;
  private SpriteRenderer darkness2;
  private SpriteRenderer lightt;
  private SpriteRenderer rainbow;
  public Sprite rainbow_0;
  public Sprite rainbow_1;
  public Sprite rainbow_2;
  public Sprite rainbow_3;
  public Sprite rainbow_4;
  private KitchenAreaEffect kae;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "action1_e";
    this.actionMarker = this.gameObject.transform.Find("Action_Open").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "kitchen_door";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("key2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("towel_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("towel_2", string.Empty, anim: string.Empty));
    this.darkness = GameObject.Find("Location").transform.Find("darkness").GetComponent<SpriteRenderer>();
    this.darkness2 = GameObject.Find("Location").transform.Find("darkness2").GetComponent<SpriteRenderer>();
    this.lightt = GameObject.Find("Location").transform.Find("light").GetComponent<SpriteRenderer>();
    this.rainbow = GameObject.Find("Location").transform.Find("rainbow").GetComponent<SpriteRenderer>();
    this.kae = GameObject.Find("Location").GetComponent<KitchenAreaEffect>();
  }

  public override void clickAction()
  {
    if (this.usedItem == "key2")
    {
      if (GameDataController.gd.getObjective("location02_door_open"))
      {
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "generic_close_first"), true);
      }
      else
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_lock_unlock);
        GameDataController.gd.setObjective("location02_door_locked", !GameDataController.gd.getObjective("location02_door_locked"));
      }
    }
    else if (this.usedItem == "towel_1" || this.usedItem == "towel_2")
    {
      if (GameDataController.gd.getObjective("location02_door_open"))
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "generic_close_first"), true);
      else if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 2 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 2)
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
          GameDataController.gd.setObjectiveDetail("towel_1_at_door", 2);
        }
        else if (this.usedItem == "towel_2")
        {
          InventoryController.ic.removeItem("towel_2");
          ItemsManager.im.updateItem("towel_2", "nowhere", 0, 0);
          PlayerController.pc.aS.PlayOneShot(ItemsManager.im.getItem("towel_1").sound);
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "towel_placed"), true);
          GameDataController.gd.setObjectiveDetail("towel_2_at_door", 2);
        }
        this.updateState();
      }
    }
    else if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 2 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 2)
    {
      if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 2 && InventoryController.ic.pickUpItem(ItemsManager.im.getItem("towel_1")))
      {
        GameDataController.gd.setObjectiveDetail("towel_1_at_door", 0);
        GameObject.Find("towels").transform.Find("towel_1_r1").GetComponent<SpriteRenderer>().enabled = false;
      }
      if (GameDataController.gd.getObjectiveDetail("towel_2_at_door") != 2 || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("towel_2")))
        return;
      GameDataController.gd.setObjectiveDetail("towel_2_at_door", 0);
      GameObject.Find("towels").transform.Find("towel_2_r1").GetComponent<SpriteRenderer>().enabled = false;
    }
    else if (GameDataController.gd.getObjective("location02_door_locked"))
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_locked);
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "generic_locked"), true);
    }
    else
    {
      if (GameDataController.gd.getObjective("location02_door_open"))
      {
        this.gameObject.GetComponent<Animator>().Play("KitchenDoorClose", 0);
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_close_01);
      }
      else
      {
        this.gameObject.GetComponent<Animator>().Play("KitchenDoorOpen", 0);
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_open_01);
      }
      GameDataController.gd.setObjective("location02_door_open", !GameDataController.gd.getObjective("location02_door_open"));
      GameObject.Find("KitchenExitWay").GetComponent<KitchenExit>().updateState();
    }
  }

  public override void updateState()
  {
    MonoBehaviour.print((object) "UPDATING DOOR STATE");
    if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 2)
    {
      GameObject.Find("towels").transform.Find("towel_1_r1").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("towels").transform.Find("towel_2_r1").GetComponent<SpriteRenderer>().enabled = false;
    }
    else if (GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 2)
    {
      GameObject.Find("towels").transform.Find("towel_2_r1").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("towels").transform.Find("towel_1_r1").GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      GameObject.Find("towels").transform.Find("towel_2_r1").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("towels").transform.Find("towel_1_r1").GetComponent<SpriteRenderer>().enabled = false;
    }
    if (GameDataController.gd.getObjective("location02_door_open"))
    {
      this.characterAnimationName = "open_door2";
      this.actionMarker = this.gameObject.transform.Find("Action_Close").gameObject;
      this.gameObject.GetComponent<Animator>().Play("KitchenDoorOpened", 0);
      this.colliderManager.setCollider(1);
      this.gameObject.transform.Find("Z_Marker2").GetComponent<ObjectZController>().enabled = true;
      this.gameObject.transform.Find("Z_Marker").GetComponent<ObjectZController>().enabled = false;
      this.darkness.color = new Color(1f, 1f, 1f, 0.0f);
      this.darkness2.color = new Color(1f, 1f, 1f, 0.0f);
      this.lightt.color = new Color(1f, 1f, 1f, 1f);
      this.rainbow.sprite = this.rainbow_4;
      this.rainbow.color = new Color(1f, 1f, 1f, 0.0f);
    }
    else
    {
      this.darkness.color = new Color(1f, 1f, 1f, 1f);
      this.darkness2.color = new Color(1f, 1f, 1f, 1f);
      this.lightt.color = new Color(1f, 1f, 1f, 0.0f);
      this.rainbow.sprite = this.rainbow_0;
      this.rainbow.color = new Color(1f, 1f, 1f, 1f);
      this.characterAnimationName = "action1_e";
      this.actionMarker = this.gameObject.transform.Find("Action_Open").gameObject;
      this.gameObject.GetComponent<Animator>().Play("KitchenDoorClosed", 0);
      this.colliderManager.setCollider(0);
      this.gameObject.transform.Find("Z_Marker2").GetComponent<ObjectZController>().enabled = false;
      this.gameObject.transform.Find("Z_Marker").GetComponent<ObjectZController>().enabled = true;
    }
    GameObject.Find("KitchenExitWay").GetComponent<KitchenExit>().updateState();
  }

  public override void whatOnClick()
  {
    if (this.usedItem == "towel_1" || this.usedItem == "towel_2")
    {
      if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 2 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 2)
        this.characterAnimationName = "action_stnd_e";
      else
        this.characterAnimationName = "kneel_e";
    }
    else if (this.usedItem == "key2")
    {
      if (GameDataController.gd.getObjective("location02_door_open"))
        this.characterAnimationName = "action_stnd_e";
      else
        this.characterAnimationName = "action1_e_lock";
    }
    else if (GameDataController.gd.getObjectiveDetail("towel_1_at_door") == 2 || GameDataController.gd.getObjectiveDetail("towel_2_at_door") == 2)
      this.characterAnimationName = "kneel_e";
    else if (GameDataController.gd.getObjective("location02_door_locked"))
      this.characterAnimationName = "action1_e_lock";
    else if (GameDataController.gd.getObjective("location02_door_open"))
      this.characterAnimationName = "open_door2";
    else
      this.characterAnimationName = "action1_e";
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public void shadowy(float shadowAmount)
  {
    this.darkness.color = new Color(1f, 1f, 1f, shadowAmount);
    this.darkness2.color = new Color(1f, 1f, 1f, shadowAmount);
    this.lightt.color = new Color(1f, 1f, 1f, 1f - shadowAmount);
    this.rainbow.color = new Color(1f, 1f, 1f, shadowAmount);
    this.rainbow.sprite = (double) shadowAmount < 0.800000011920929 ? ((double) shadowAmount < 0.600000023841858 ? ((double) shadowAmount < 0.400000005960464 ? ((double) shadowAmount < 0.200000002980232 ? this.rainbow_4 : this.rainbow_3) : this.rainbow_2) : this.rainbow_1) : this.rainbow_0;
    this.kae.refresh();
  }
}
