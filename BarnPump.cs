// Decompiled with JetBrains decompiler
// Type: BarnPump
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class BarnPump : ObjectActionController
{
  private AudioClip engineStart;
  private AudioClip engineDie;
  private AudioClip engineRun;
  private AudioSource aS;
  private GameObject lights;
  public GameObject am1;
  public GameObject am2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "action_n_long";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "barn_generator_disabled";
    this.setCollider(0);
    this.engineStart = SoundsManagerController.sm.engine_start;
    this.engineRun = SoundsManagerController.sm.engine_run;
    this.engineDie = SoundsManagerController.sm.engine_die;
    this.aS = this.gameObject.AddComponent<AudioSource>();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("canister_full", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister_empty", GameStrings.getString(GameStrings.actions, "canister_is_empty"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister2_full", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister2_empty", GameStrings.getString(GameStrings.actions, "canister_is_empty"), anim: string.Empty));
    if (GameDataController.gd.getObjectiveDetail("barn_pump_started") <= 0 || !GameDataController.gd.getObjective("barn_pump_started"))
      return;
    this.aS.clip = this.engineRun;
    this.aS.loop = true;
    this.aS.volume = 0.3f;
    this.aS.Play();
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("barn_pump_started"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.objectName = "barn_generator_disabled";
    }
    else
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.objectName = "barn_generator_enabled";
    }
  }

  public override void whatOnClick0()
  {
    if (!GameDataController.gd.getObjective("base_discovered"))
      this.characterAnimationName = "action_stnd_n";
    else if (this.usedItem != string.Empty)
    {
      this.characterAnimationName = "action_n_long";
      this.actionMarker = this.am2;
    }
    else
    {
      this.actionMarker = this.am1;
      this.characterAnimationName = "action_n";
    }
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("base_discovered"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_pipe_first"));
    }
    else
    {
      if (this.usedItem != "canister_full" && this.usedItem != "canister_empty" && this.usedItem != "canister2_full" && this.usedItem != "canister2_empty")
      {
        PlayerController.pc.spawnName = "BarnConsoleExit";
        CurtainController.cc.fadeOut("BarnGenerator", WalkController.Direction.W);
      }
      else if (this.usedItem == "canister_full")
      {
        if (!GameDataController.gd.getObjective("barn_pump_fueled"))
        {
          InventoryController.ic.removeItem("canister_full");
          ItemsManager.im.updateItem("canister_full", "nowhere", 0, 0);
          InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("canister_empty"));
          GameDataController.gd.setObjective("barn_pump_fueled", true);
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "barn_pump_fuel"), true);
        }
        else
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "barn_pump_already_fueled"), true);
      }
      else if (this.usedItem == "canister2_full")
      {
        if (!GameDataController.gd.getObjective("barn_pump_fueled"))
        {
          InventoryController.ic.removeItem("canister2_full");
          ItemsManager.im.updateItem("canister2_full", "nowhere", 0, 0);
          InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("canister2_empty"));
          GameDataController.gd.setObjective("barn_pump_fueled", true);
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "barn_pump_fuel"), true);
        }
        else
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "barn_pump_already_fueled"), true);
      }
      PlayerController.wc.forceDirection(WalkController.Direction.NE);
    }
  }

  public void restore() => this.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
