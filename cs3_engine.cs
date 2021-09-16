// Decompiled with JetBrains decompiler
// Type: cs3_engine
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class cs3_engine : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_s";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_engine";
    this.range = 1f;
    this.updateState();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("canister_full", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister_empty", GameStrings.getString(GameStrings.actions, "canister_is_empty"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister2_full", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("canister2_empty", GameStrings.getString(GameStrings.actions, "canister_is_empty"), anim: string.Empty));
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("cs_rain_enter_left") && !GameDataController.gd.getObjective("cs_pack_lifted"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cant_reach"));
    else if (this.usedItem != string.Empty)
    {
      if (GameDataController.gd.getObjective("cs_engine_fueled"))
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_pump_already_fueled"));
      }
      else
      {
        if (this.usedItem == "canister_full")
        {
          InventoryController.ic.removeItem("canister_full");
          ItemsManager.im.updateItem("canister_full", "nowhere", 0, 0);
          InventoryController.ic.pickUpItem(ItemsManager.im.getItem("canister_empty"));
        }
        else if (this.usedItem == "canister2_full")
        {
          InventoryController.ic.removeItem("canister2_full");
          ItemsManager.im.updateItem("canister2_full", "nowhere", 0, 0);
          InventoryController.ic.pickUpItem(ItemsManager.im.getItem("canister2_empty"));
        }
        GameDataController.gd.setObjective("cs_engine_fueled", true);
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.liquid_pour_med);
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_pump_fuel"));
      }
    }
    else if (GameDataController.gd.getObjective("cs_engine_started"))
    {
      GameDataController.gd.setObjective("cs_engine_started", false);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.engine_die, 0.25f);
      this.updateState();
    }
    else if (GameDataController.gd.getObjective("cs_engine_fueled"))
    {
      GameDataController.gd.setObjective("cs_engine_started", true);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.rv_engine_start);
      this.Invoke("startSoundANdSmoke", 1f);
    }
    else
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_pump_no_fuel"));
      PlayerController.pc.aS.Stop();
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.rv_engine_fail);
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("cs_engine_started"))
    {
      this.GetComponent<AudioSource>().clip = SoundsManagerController.sm.rv_engine_loop;
      this.GetComponent<AudioSource>().loop = true;
      this.GetComponent<AudioSource>().Play();
      this.GetComponent<Animator>().Play("cs_engine");
      this.GetComponent<Animator>().enabled = true;
      this.GetComponent<ParticleGenerator>().started = true;
      this.characterAnimationName = "action_s";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.range = 1f;
    }
    else
    {
      this.characterAnimationName = "action_s";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.range = 1f;
      this.GetComponent<Animator>().enabled = false;
      this.GetComponent<ParticleGenerator>().started = false;
      this.GetComponent<AudioSource>().Stop();
    }
    if (!GameDataController.gd.getObjective("cs_rain_enter_left") && !GameDataController.gd.getObjective("cs_pack_lifted"))
    {
      this.range = 100f;
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
    this.setCollider(0);
    this.GetComponent<SpriteRenderer>().enabled = true;
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
      return;
    this.setCollider(-1);
    this.GetComponent<SpriteRenderer>().enabled = false;
  }

  public void startSoundANdSmoke() => this.updateAll();

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}
