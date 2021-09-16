// Decompiled with JetBrains decompiler
// Type: ItemsManager
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemsManager : MonoBehaviour
{
  public static ItemsManager im;
  public GameObject inv;
  public List<Item> items;

  private void Awake()
  {
    if ((UnityEngine.Object) ItemsManager.im == (UnityEngine.Object) null)
    {
      UnityEngine.Object.DontDestroyOnLoad((UnityEngine.Object) this.gameObject);
      ItemsManager.im = this;
    }
    else
    {
      if (!((UnityEngine.Object) ItemsManager.im != (UnityEngine.Object) this))
        return;
      UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
    }
  }

  public void reloadAfterLanguageChange()
  {
    this.Start();
    this.initItems();
  }

  private void Start()
  {
    this.items = new List<Item>();
    this.initItem("key1", 0.0f, "keypick01", soundL: string.Empty);
    this.initItem("key2", 0.1f, "keypick01", soundL: string.Empty);
    this.initItem("key4", 0.1f, "keypick01", soundL: string.Empty);
    this.initItem("key3", 0.1f, "keypick01", hasExamineScreen: true, texts: new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "key3_inspect")
    }, wid: 100, xShift: -110, yShift: 40, r1: 1f, g1: 1f, b1: 1f, r2: 0.0f, g2: 0.0f, b2: 0.0f, a2: 0.5f, cycle: true, soundL: string.Empty);
    this.initItem("pipe", 1f, "metalpipe", soundL: string.Empty);
    this.initItem("sonic", 2.5f, "flashlight1", new List<ItemInteraction>()
    {
      new ItemInteraction("sonic_remote", GameStrings.getString(GameStrings.actions, "remote_sonic"), anim: string.Empty)
    }, new List<ItemInteraction>()
    {
      new ItemInteraction("sonic_remote", string.Empty, new Action(this.sonic_remote_use), "action_s", 50)
    }, 1, 15, soundL: string.Empty);
    this.initItem("sonic2", 2.5f, "flashlight1", new List<ItemInteraction>()
    {
      new ItemInteraction("sonic_remote", GameStrings.getString(GameStrings.actions, "remote_sonic2"), anim: string.Empty)
    }, new List<ItemInteraction>()
    {
      new ItemInteraction("sonic_remote", "remote_sonic2", anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("sonic_remote", 1f, "flashlight1", soundL: string.Empty);
    int var1 = 1;
    int var2 = 1;
    int var4 = 1;
    if (GameDataController.gd.getObjectiveDetail("bug_type") == 1)
    {
      var1 = 1;
      var2 = 1;
      var4 = 1;
    }
    if (GameDataController.gd.getObjectiveDetail("bug_type") == 2)
    {
      var1 = 2;
      var2 = 2;
      var4 = 1;
    }
    if (GameDataController.gd.getObjectiveDetail("bug_type") == 3)
    {
      var1 = 2;
      var2 = 2;
      var4 = 2;
    }
    if (GameDataController.gd.getObjectiveDetail("bug_type") == 4)
    {
      var1 = 1;
      var2 = 2;
      var4 = 2;
    }
    if (GameDataController.gd.getObjectiveDetail("bug_type") == 5)
    {
      var1 = 2;
      var2 = 1;
      var4 = 1;
    }
    if (GameDataController.gd.getObjectiveDetail("bug_type") == 6)
    {
      var1 = 1;
      var2 = 1;
      var4 = 2;
    }
    if (GameDataController.gd.getObjectiveDetail("bug_type") == 7)
    {
      var1 = 1;
      var2 = 2;
      var4 = 1;
    }
    if (GameDataController.gd.getObjectiveDetail("bug_type") == 8)
    {
      var1 = 2;
      var2 = 1;
      var4 = 2;
    }
    this.initItem("bug", 0.0f, "meat", hasExamineScreen: true, var1: var1, var2: var2, var3: 1, var4: var4, soundL: string.Empty);
    this.initItem("pest_note", 0.0f, "page_turn_03", hasExamineScreen: true, soundL: string.Empty);
    this.initItem("gas_note", 0.0f, "page_turn_03", hasExamineScreen: true, texts: new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "gas_note")
    }, wid: 160, xShift: -60, yShift: 50, r1: 0.2431373f, g1: 0.227451f, b1: 0.1098039f, a2: 0.0f, soundL: string.Empty);
    this.initItem("spider_note", 0.0f, "page_turn_03", hasExamineScreen: true, texts: new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "spider_note")
    }, wid: 160, xShift: -60, yShift: 50, r1: 0.2431373f, g1: 0.227451f, b1: 0.1098039f, a2: 0.0f, soundL: string.Empty);
    this.initItem("mixer_pills_note", 0.0f, "page_turn_03", hasExamineScreen: true, texts: new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "mixer_pills")
    }, wid: 122, xShift: -115, yShift: -23, r1: 0.2431373f, g1: 0.227451f, b1: 0.1098039f, a2: 0.0f, soundL: string.Empty);
    this.initItem("mixer_catalyst_note", 0.0f, "page_turn_03", hasExamineScreen: true, texts: new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "mixer_catalyst")
    }, wid: 122, xShift: -115, yShift: -23, r1: 0.2431373f, g1: 0.227451f, b1: 0.1098039f, a2: 0.0f, soundL: string.Empty);
    this.initItem("pest1", 2f, "small_can", soundL: string.Empty);
    this.initItem("pest2", 2f, "small_can", soundL: string.Empty);
    this.initItem("paperclip", 0.0f, "keypick01", soundL: string.Empty);
    this.initItem("invoices", 0.5f, "page_turn_04", soundL: string.Empty);
    this.initItem("crowbar", 1.5f, "pickaxe01", soundL: string.Empty);
    this.initItem("hammer", 2f, "wooden", new List<ItemInteraction>()
    {
      new ItemInteraction("nails1", GameStrings.getString(GameStrings.actions, "hammer_nails"), anim: string.Empty),
      new ItemInteraction("nails2", GameStrings.getString(GameStrings.actions, "hammer_nails"), anim: string.Empty),
      new ItemInteraction("nails3", GameStrings.getString(GameStrings.actions, "hammer_nails"), anim: string.Empty),
      new ItemInteraction("nails4", GameStrings.getString(GameStrings.actions, "hammer_nails"), anim: string.Empty),
      new ItemInteraction("nails5", GameStrings.getString(GameStrings.actions, "hammer_nails"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("broken_hammer", 1.8f, "wooden", new List<ItemInteraction>()
    {
      new ItemInteraction("hammer_handle", string.Empty, new Action(this.hammer_fix), string.Empty),
      new ItemInteraction("pipe", GameStrings.getString(GameStrings.actions, "broken_hammer_pipe"), anim: string.Empty),
      new ItemInteraction("ducttape", GameStrings.getString(GameStrings.actions, "broken_hammer_tape"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("hammer_handle", 0.2f, "wooden", new List<ItemInteraction>()
    {
      new ItemInteraction("broken_hammer", string.Empty, new Action(this.hammer_fix), string.Empty)
    }, soundL: string.Empty);
    this.initItem("straw", 0.0f, "keypick01", soundL: string.Empty);
    this.initItem("window_net1", 4f, "net", soundL: string.Empty);
    this.initItem("window_net2", 4f, "net", soundL: string.Empty);
    this.initItem("window_net3", 4f, "net", soundL: string.Empty);
    this.initItem("window_bars1", 9f, "metal_bang", soundL: string.Empty);
    this.initItem("window_bars2", 9f, "metal_bang", soundL: string.Empty);
    this.initItem("window_bars3", 9f, "metal_bang", soundL: string.Empty);
    this.initItem("window_foil1", 4f, "net", soundL: string.Empty);
    this.initItem("window_foil2", 4f, "net", soundL: string.Empty);
    this.initItem("window_foil3", 4f, "net", soundL: string.Empty);
    this.initItem("ducttape", 0.1f, "ducttape", new List<ItemInteraction>()
    {
      new ItemInteraction("chemsuit_dmg_dmg", string.Empty, new Action(this.chemsuit_fix1), string.Empty),
      new ItemInteraction("chemsuit_dmg_rep", string.Empty, new Action(this.chemsuit_fix2), string.Empty),
      new ItemInteraction("broken_hammer", GameStrings.getString(GameStrings.actions, "broken_hammer_tape"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("canister_empty", 1f, "jerrycan_empty", soundL: string.Empty);
    this.initItem("canister_full", 10f, "jerrycan_full", new List<ItemInteraction>()
    {
      new ItemInteraction("lighter", GameStrings.getString(GameStrings.actions, "dont_blow_up"), anim: string.Empty),
      new ItemInteraction("gasheater_empty", GameStrings.getString(GameStrings.actions, "gasheater_fuel"), anim: string.Empty),
      new ItemInteraction("flamethrower_empty", string.Empty, new Action(this.fuel_sprayer_use), string.Empty),
      new ItemInteraction("watersprayer", string.Empty, new Action(this.fuel_sprayer_use), string.Empty)
    }, soundL: string.Empty);
    this.initItem("canister2_empty", 1f, "jerrycan_empty", soundL: string.Empty);
    this.initItem("canister2_full", 10f, "jerrycan_full", new List<ItemInteraction>()
    {
      new ItemInteraction("lighter", GameStrings.getString(GameStrings.actions, "dont_blow_up"), anim: string.Empty),
      new ItemInteraction("gasheater_empty", GameStrings.getString(GameStrings.actions, "gasheater_fuel"), anim: string.Empty),
      new ItemInteraction("flamethrower_empty", string.Empty, new Action(this.fuel_sprayer_use2), string.Empty),
      new ItemInteraction("watersprayer", string.Empty, new Action(this.fuel_sprayer_use2), string.Empty)
    }, soundL: string.Empty);
    this.initItem("charcoal", 10f, "net", soundL: string.Empty);
    this.initItem("charcoal_empty", 0.1f, "net", soundL: string.Empty);
    this.initItem("nails1", 0.1f, "nails", new List<ItemInteraction>()
    {
      new ItemInteraction("hammer", GameStrings.getString(GameStrings.actions, "hammer_nails"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("nails2", 0.1f, "nails", new List<ItemInteraction>()
    {
      new ItemInteraction("hammer", GameStrings.getString(GameStrings.actions, "hammer_nails"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("nails3", 0.1f, "nails", new List<ItemInteraction>()
    {
      new ItemInteraction("hammer", GameStrings.getString(GameStrings.actions, "hammer_nails"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("nails4", 0.1f, "nails", new List<ItemInteraction>()
    {
      new ItemInteraction("hammer", GameStrings.getString(GameStrings.actions, "hammer_nails"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("nails5", 0.1f, "nails", soundL: string.Empty);
    this.initItem("board1", 3.5f, "logs", soundL: string.Empty);
    this.initItem("board2", 3.5f, "logs", soundL: string.Empty);
    this.initItem("board3", 3.5f, "logs", soundL: string.Empty);
    this.initItem("tarpaulin", 4f, "net", soundL: string.Empty);
    this.initItem("planks1", 2.5f, "logs", soundL: string.Empty);
    this.initItem("planks2", 2.5f, "logs", soundL: string.Empty);
    this.initItem("planks3", 2.5f, "logs", soundL: string.Empty);
    this.initItem("planks4", 2.5f, "logs", soundL: string.Empty);
    this.initItem("planks5", 2.5f, "logs", soundL: string.Empty);
    this.initItem("ignitioncoil", 0.2f, "pickaxe01", soundL: string.Empty);
    this.initItem("car_battery", 0.2f, "pickaxe01", soundL: string.Empty);
    this.initItem("wheel", 2.5f, "pickaxe01", soundL: string.Empty);
    this.initItem("chem_glass", 0.1f, "glass", soundL: string.Empty);
    this.initItem("chem_glass_1", 0.5f, "glass", soundL: string.Empty);
    this.initItem("chem_glass_2", 0.5f, "glass", soundL: string.Empty);
    this.initItem("chem_glass_3", 0.5f, "glass", soundL: string.Empty);
    this.initItem("chem_glass_12", 1f, "glass", soundL: string.Empty);
    this.initItem("chem_glass_13", 1f, "glass", soundL: string.Empty);
    this.initItem("chem_glass_23", 1f, "glass", soundL: string.Empty);
    this.initItem("mask_filter", 0.1f, "flashlight1", new List<ItemInteraction>()
    {
      new ItemInteraction("chemsuit_dmg_dmg", string.Empty, new Action(this.chemsuit_filter1), string.Empty),
      new ItemInteraction("chemsuit_rep_dmg", string.Empty, new Action(this.chemsuit_filter2), string.Empty)
    }, soundL: string.Empty);
    string str = ((float) GameDataController.gd.getObjectiveDetail("gas_dens") / 100f).ToString();
    if ((double) GameDataController.gd.getObjectiveDetail("gas_dens") / 100.0 == 1.6)
      str += "0";
    this.initItem("drone", 2f, "metal_bang", new List<ItemInteraction>()
    {
      new ItemInteraction("wrench", GameStrings.getString(GameStrings.actions, "drone_smash_it"), anim: string.Empty),
      new ItemInteraction("crowbar", GameStrings.getString(GameStrings.actions, "drone_smash_it"), anim: string.Empty),
      new ItemInteraction("screwdriver", GameStrings.getString(GameStrings.actions, "drone_smash_it"), anim: string.Empty),
      new ItemInteraction("pipe", GameStrings.getString(GameStrings.actions, "drone_smash_it"), anim: string.Empty),
      new ItemInteraction("hammer", GameStrings.getString(GameStrings.actions, "drone_smash_it"), anim: string.Empty)
    }, hasExamineScreen: true, texts: new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "drone_1") + GameDataController.gd.getObjectiveDetail("gas_ph").ToString() + GameStrings.getString(GameStrings.world_labels, "drone_2") + str + GameStrings.getString(GameStrings.world_labels, "drone_3")
    }, wid: 115, xShift: -18, yShift: 15, r1: 0.2941177f, g1: 0.3176471f, b1: 0.2745098f, r2: 0.0f, g2: 0.0f, b2: 0.0f, a2: 0.0f, soundL: string.Empty);
    this.initItem("towel_1", 0.2f, "net", new List<ItemInteraction>()
    {
      new ItemInteraction("whiskey", GameStrings.getString(GameStrings.actions, "no_molotov"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("towel_2", 0.2f, "net", new List<ItemInteraction>()
    {
      new ItemInteraction("whiskey", GameStrings.getString(GameStrings.actions, "no_molotov"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("lighter", 0.0f, "flashlight1", new List<ItemInteraction>()
    {
      new ItemInteraction("canister_full", GameStrings.getString(GameStrings.actions, "dont_blow_up"), anim: string.Empty),
      new ItemInteraction("canister2_full", GameStrings.getString(GameStrings.actions, "dont_blow_up"), anim: string.Empty),
      new ItemInteraction("watersprayer", string.Empty, new Action(this.lighter_sprayer_use), string.Empty),
      new ItemInteraction("fuelsprayer", string.Empty, new Action(this.lighter_sprayer_use), string.Empty)
    }, soundL: string.Empty);
    this.initItem("wrench", 1f, "pickaxe01", soundL: string.Empty);
    this.initItem("wad_of_cash", 0.1f, "page_turn_04", soundL: string.Empty);
    this.initItem("pestsprayer", 10f, "small_can", soundL: string.Empty);
    this.initItem("watersprayer", 0.5f, "flashlight1", new List<ItemInteraction>()
    {
      new ItemInteraction("canister_full", string.Empty, new Action(this.fuel_sprayer_use), string.Empty),
      new ItemInteraction("canister2_full", string.Empty, new Action(this.fuel_sprayer_use2), string.Empty),
      new ItemInteraction("ducttape", GameStrings.getString(GameStrings.actions, "ducttape_watersprayer"), anim: string.Empty),
      new ItemInteraction("lighter", string.Empty, new Action(this.lighter_sprayer_use), string.Empty),
      new ItemInteraction("pest1", GameStrings.getString(GameStrings.actions, "pest2_flamethrower"), anim: string.Empty),
      new ItemInteraction("pest2", GameStrings.getString(GameStrings.actions, "watersprayer_chem"), anim: string.Empty),
      new ItemInteraction("spiderpest1", GameStrings.getString(GameStrings.actions, "pest2_flamethrower"), anim: string.Empty),
      new ItemInteraction("spiderpest2", GameStrings.getString(GameStrings.actions, "pest2_flamethrower"), anim: string.Empty),
      new ItemInteraction("spiderpest3", GameStrings.getString(GameStrings.actions, "pest2_flamethrower"), anim: string.Empty),
      new ItemInteraction("spiderpest4", GameStrings.getString(GameStrings.actions, "pest2_flamethrower"), anim: string.Empty),
      new ItemInteraction("chem_glass_1", GameStrings.getString(GameStrings.actions, "watersprayer_chem"), anim: string.Empty),
      new ItemInteraction("chem_glass_2", GameStrings.getString(GameStrings.actions, "watersprayer_chem"), anim: string.Empty),
      new ItemInteraction("chem_glass_3", GameStrings.getString(GameStrings.actions, "watersprayer_chem"), anim: string.Empty),
      new ItemInteraction("chem_glass_12", GameStrings.getString(GameStrings.actions, "watersprayer_chem"), anim: string.Empty),
      new ItemInteraction("chem_glass_13", GameStrings.getString(GameStrings.actions, "watersprayer_chem"), anim: string.Empty),
      new ItemInteraction("chem_glass_23", GameStrings.getString(GameStrings.actions, "watersprayer_chem"), anim: string.Empty),
      new ItemInteraction("poision", GameStrings.getString(GameStrings.actions, "poision_watersprayer"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("fuelsprayer", 5f, "jerrycan_full", new List<ItemInteraction>()
    {
      new ItemInteraction("ducttape", GameStrings.getString(GameStrings.actions, "ducttape_watersprayer"), anim: string.Empty),
      new ItemInteraction("lighter", string.Empty, new Action(this.lighter_sprayer_use), string.Empty)
    }, soundL: string.Empty);
    this.initItem("flamethrower_empty", 0.5f, "flashlight1", new List<ItemInteraction>()
    {
      new ItemInteraction("canister_full", string.Empty, new Action(this.fuel_sprayer_use), string.Empty),
      new ItemInteraction("canister2_full", string.Empty, new Action(this.fuel_sprayer_use2), string.Empty),
      new ItemInteraction("pest1", GameStrings.getString(GameStrings.actions, "pest_flamethrower"), anim: string.Empty),
      new ItemInteraction("pest2", GameStrings.getString(GameStrings.actions, "pest_flamethrower"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("flamethrower", 5f, "jerrycan_full", soundL: string.Empty);
    this.initItem("chemsuit_dmg_dmg", 4f, "net", new List<ItemInteraction>()
    {
      new ItemInteraction("ducttape", string.Empty, new Action(this.chemsuit_fix1), string.Empty),
      new ItemInteraction("mask_filter", string.Empty, new Action(this.chemsuit_filter1), string.Empty)
    }, soundL: string.Empty);
    this.initItem("chemsuit_dmg_rep", 4f, "net", new List<ItemInteraction>()
    {
      new ItemInteraction("ducttape", string.Empty, new Action(this.chemsuit_fix2), string.Empty)
    }, soundL: string.Empty);
    this.initItem("chemsuit_rep_dmg", 4f, "net", new List<ItemInteraction>()
    {
      new ItemInteraction("mask_filter", string.Empty, new Action(this.chemsuit_filter2), string.Empty)
    }, soundL: string.Empty);
    this.initItem("chemsuit_rep_rep", 4f, "net", soundL: string.Empty);
    this.initItem("rifle_0", 5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("scope", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("silencer", string.Empty, new Action(this.rifleInstallSilencer), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_1", 5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("scope", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("silencer", string.Empty, new Action(this.rifleInstallSilencer), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_2", 5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("scope", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("silencer", string.Empty, new Action(this.rifleInstallSilencer), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_3", 5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("scope", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("silencer", string.Empty, new Action(this.rifleInstallSilencer), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_4", 5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("scope", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("silencer", string.Empty, new Action(this.rifleInstallSilencer), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_5", 5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("scope", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("silencer", string.Empty, new Action(this.rifleInstallSilencer), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_6", 5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("scope", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("silencer", string.Empty, new Action(this.rifleInstallSilencer), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_o_0", 5.5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("silencer", string.Empty, new Action(this.rifleInstallSilencer), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_o_1", 5.5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("silencer", string.Empty, new Action(this.rifleInstallSilencer), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_o_2", 5.5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("silencer", string.Empty, new Action(this.rifleInstallSilencer), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_o_3", 5.5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("silencer", string.Empty, new Action(this.rifleInstallSilencer), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_o_4", 5.5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("silencer", string.Empty, new Action(this.rifleInstallSilencer), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_o_5", 5.5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("silencer", string.Empty, new Action(this.rifleInstallSilencer), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_o_6", 5.5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("silencer", string.Empty, new Action(this.rifleInstallSilencer), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_s_0", 5.5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("scope", string.Empty, new Action(this.rifleInstallScope), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_s_1", 5.5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("scope", string.Empty, new Action(this.rifleInstallScope), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_s_2", 5.5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("scope", string.Empty, new Action(this.rifleInstallScope), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_s_3", 5.5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("scope", string.Empty, new Action(this.rifleInstallScope), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_s_4", 5.5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("scope", string.Empty, new Action(this.rifleInstallScope), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_s_5", 5.5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("scope", string.Empty, new Action(this.rifleInstallScope), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_s_6", 5.5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("scope", string.Empty, new Action(this.rifleInstallScope), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_so_0", 6f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_so_1", 6f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_so_2", 6f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_so_3", 6f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_so_4", 6f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_so_5", 6f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_so_6", 6f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_ammo", string.Empty, new Action(this.reloadRifle), string.Empty)
    }, soundL: string.Empty);
    this.initItem("spiderpest1", 0.5f, "small_can", soundL: string.Empty);
    this.initItem("spiderpest2", 0.5f, "small_can", soundL: string.Empty);
    this.initItem("spiderpest3", 0.5f, "small_can", soundL: string.Empty);
    this.initItem("spiderpest4", 0.5f, "small_can", soundL: string.Empty);
    this.initItem("bear_trap_1", 5f, "trap", soundL: string.Empty);
    this.initItem("bear_trap_2", 5f, "trap", soundL: string.Empty);
    this.initItem("bear_trap_1b", 50f, "trap", usablesG: new List<ItemInteraction>()
    {
      new ItemInteraction("hammer", string.Empty, new Action(this.resetSpring1), string.Empty),
      new ItemInteraction("crowbar", string.Empty, new Action(this.resetSpring1), string.Empty),
      new ItemInteraction("wrench", string.Empty, new Action(this.resetSpring1), string.Empty)
    }, soundL: string.Empty);
    this.initItem("bear_trap_2b", 50f, "trap", usablesG: new List<ItemInteraction>()
    {
      new ItemInteraction("hammer", string.Empty, new Action(this.resetSpring2), string.Empty),
      new ItemInteraction("crowbar", string.Empty, new Action(this.resetSpring2), string.Empty),
      new ItemInteraction("wrench", string.Empty, new Action(this.resetSpring2), string.Empty)
    }, soundL: string.Empty);
    this.initItem("bear_trap_3", 5f, "trap", soundL: string.Empty);
    this.initItem("bear_trap_4", 5f, "trap", soundL: string.Empty);
    this.initItem("revolver_0", 2f, "revolver", new List<ItemInteraction>()
    {
      new ItemInteraction("gun_ammo", string.Empty, new Action(this.reloadGun), string.Empty)
    }, soundL: string.Empty);
    this.initItem("revolver_1", 2f, "revolver", new List<ItemInteraction>()
    {
      new ItemInteraction("gun_ammo", string.Empty, new Action(this.reloadGun), string.Empty)
    }, soundL: string.Empty);
    this.initItem("revolver_2", 2f, "revolver", new List<ItemInteraction>()
    {
      new ItemInteraction("gun_ammo", string.Empty, new Action(this.reloadGun), string.Empty)
    }, soundL: string.Empty);
    this.initItem("revolver_3", 2f, "revolver", new List<ItemInteraction>()
    {
      new ItemInteraction("gun_ammo", string.Empty, new Action(this.reloadGun), string.Empty)
    }, soundL: string.Empty);
    this.initItem("revolver_4", 2f, "revolver", new List<ItemInteraction>()
    {
      new ItemInteraction("gun_ammo", string.Empty, new Action(this.reloadGun), string.Empty)
    }, soundL: string.Empty);
    this.initItem("revolver_5", 2f, "revolver", new List<ItemInteraction>()
    {
      new ItemInteraction("gun_ammo", string.Empty, new Action(this.reloadGun), string.Empty)
    }, soundL: string.Empty);
    this.initItem("revolver_6", 2f, "revolver", new List<ItemInteraction>()
    {
      new ItemInteraction("gun_ammo", GameStrings.getString(GameStrings.actions, "revolver_full"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("gun_ammo", 1f, "nails", new List<ItemInteraction>()
    {
      new ItemInteraction("revolver_0", string.Empty, new Action(this.reloadGun), string.Empty),
      new ItemInteraction("revolver_1", string.Empty, new Action(this.reloadGun), string.Empty),
      new ItemInteraction("revolver_2", string.Empty, new Action(this.reloadGun), string.Empty),
      new ItemInteraction("revolver_3", string.Empty, new Action(this.reloadGun), string.Empty),
      new ItemInteraction("revolver_4", string.Empty, new Action(this.reloadGun), string.Empty),
      new ItemInteraction("revolver_5", string.Empty, new Action(this.reloadGun), string.Empty),
      new ItemInteraction("revolver_6", string.Empty, new Action(this.reloadGun), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rifle_ammo", 1f, "nails", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_1", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_0", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_1", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_2", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_3", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_4", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_5", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_6", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_s_0", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_s_1", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_s_2", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_s_3", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_s_4", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_s_5", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_s_6", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_o_0", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_o_1", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_o_2", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_o_3", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_o_4", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_o_5", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_o_6", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_so_0", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_so_1", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_so_2", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_so_3", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_so_4", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_so_5", string.Empty, new Action(this.reloadRifle), string.Empty),
      new ItemInteraction("rifle_so_6", string.Empty, new Action(this.reloadRifle), string.Empty)
    }, soundL: string.Empty);
    this.initItem("scope", 0.5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_0", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("rifle_1", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("rifle_2", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("rifle_3", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("rifle_4", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("rifle_5", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("rifle_6", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("rifle_s_0", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("rifle_s_1", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("rifle_s_2", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("rifle_s_3", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("rifle_s_4", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("rifle_s_5", string.Empty, new Action(this.rifleInstallScope), string.Empty),
      new ItemInteraction("rifle_s_6", string.Empty, new Action(this.rifleInstallScope), string.Empty)
    }, soundL: string.Empty);
    this.initItem("silencer", 0.5f, "rifle_1", new List<ItemInteraction>()
    {
      new ItemInteraction("rifle_0", string.Empty, new Action(this.rifleInstallSilencer), string.Empty),
      new ItemInteraction("rifle_1", string.Empty, new Action(this.rifleInstallSilencer), string.Empty),
      new ItemInteraction("rifle_2", string.Empty, new Action(this.rifleInstallSilencer), string.Empty),
      new ItemInteraction("rifle_3", string.Empty, new Action(this.rifleInstallSilencer), string.Empty),
      new ItemInteraction("rifle_4", string.Empty, new Action(this.rifleInstallSilencer), string.Empty),
      new ItemInteraction("rifle_5", string.Empty, new Action(this.rifleInstallSilencer), string.Empty),
      new ItemInteraction("rifle_6", string.Empty, new Action(this.rifleInstallSilencer), string.Empty),
      new ItemInteraction("rifle_o_0", string.Empty, new Action(this.rifleInstallSilencer), string.Empty),
      new ItemInteraction("rifle_o_1", string.Empty, new Action(this.rifleInstallSilencer), string.Empty),
      new ItemInteraction("rifle_o_2", string.Empty, new Action(this.rifleInstallSilencer), string.Empty),
      new ItemInteraction("rifle_o_3", string.Empty, new Action(this.rifleInstallSilencer), string.Empty),
      new ItemInteraction("rifle_o_4", string.Empty, new Action(this.rifleInstallSilencer), string.Empty),
      new ItemInteraction("rifle_o_5", string.Empty, new Action(this.rifleInstallSilencer), string.Empty),
      new ItemInteraction("rifle_o_6", string.Empty, new Action(this.rifleInstallSilencer), string.Empty)
    }, soundL: string.Empty);
    this.initItem("whiskey", 2.5f, "glass", new List<ItemInteraction>()
    {
      new ItemInteraction("bandage", GameStrings.getString(GameStrings.actions, "no_molotov"), anim: string.Empty),
      new ItemInteraction("towel_1", GameStrings.getString(GameStrings.actions, "no_molotov"), anim: string.Empty),
      new ItemInteraction("towel_2", GameStrings.getString(GameStrings.actions, "no_molotov"), anim: string.Empty),
      new ItemInteraction("poision", GameStrings.getString(GameStrings.actions, "poision_whiskey"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("rock", 1f, "rockbutton", soundL: string.Empty);
    this.initItem("rock2", 1f, "rockbutton", soundL: string.Empty);
    this.initItem("shovel", 1f, "pickaxe01", soundL: string.Empty);
    this.initItem("sheet", 0.0f, "net", soundL: string.Empty);
    this.initItem("coat1", 0.3f, "net", soundL: string.Empty);
    this.initItem("coat2", 0.3f, "net", soundL: string.Empty);
    this.initItem("coat3", 0.3f, "net", soundL: string.Empty);
    this.initItem("coat4", 0.3f, "net", soundL: string.Empty);
    this.initItem("hose", 0.1f, "hose", soundL: string.Empty);
    this.initItem("gas_tank", 10f, "jerrycan_full", new List<ItemInteraction>()
    {
      new ItemInteraction("gasheater_empty", string.Empty, new Action(this.put_tank_heater), string.Empty)
    }, soundL: string.Empty);
    this.initItem("foodcan", 0.3f, "small_can", new List<ItemInteraction>()
    {
      new ItemInteraction("knife", string.Empty, new Action(this.can_open_knife), string.Empty),
      new ItemInteraction("screwdriver", string.Empty, new Action(this.can_open_screwdriver), string.Empty),
      new ItemInteraction("canopener", string.Empty, new Action(this.can_open), string.Empty),
      new ItemInteraction("hammer", GameStrings.getString(GameStrings.actions, "foodcan_smash"), anim: string.Empty),
      new ItemInteraction("wrench", GameStrings.getString(GameStrings.actions, "foodcan_smash"), anim: string.Empty),
      new ItemInteraction("crowbar", GameStrings.getString(GameStrings.actions, "foodcan_crowbar"), anim: string.Empty),
      new ItemInteraction("shovel", GameStrings.getString(GameStrings.actions, "foodcan_shovel"), anim: string.Empty),
      new ItemInteraction("key1", GameStrings.getString(GameStrings.actions, "foodcan_key"), anim: string.Empty),
      new ItemInteraction("key2", GameStrings.getString(GameStrings.actions, "foodcan_key"), anim: string.Empty),
      new ItemInteraction("key3", GameStrings.getString(GameStrings.actions, "foodcan_key"), anim: string.Empty),
      new ItemInteraction("key4", GameStrings.getString(GameStrings.actions, "foodcan_key"), anim: string.Empty),
      new ItemInteraction("rock", GameStrings.getString(GameStrings.actions, "foodcan_smash"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("foodcanopen", 0.3f, "meat", soundL: string.Empty);
    this.initItem("knife", 0.1f, "knife", new List<ItemInteraction>()
    {
      new ItemInteraction("blanketb", GameStrings.getString(GameStrings.actions, "knife_dont_cut_it"), anim: string.Empty),
      new ItemInteraction("flag", GameStrings.getString(GameStrings.actions, "knife_dont_cut_it"), anim: string.Empty),
      new ItemInteraction("blanket", GameStrings.getString(GameStrings.actions, "knife_dont_cut_it"), anim: string.Empty),
      new ItemInteraction("thermalb", GameStrings.getString(GameStrings.actions, "knife_dont_cut_it"), anim: string.Empty),
      new ItemInteraction("coat1", GameStrings.getString(GameStrings.actions, "knife_dont_cut_it"), anim: string.Empty),
      new ItemInteraction("coat2", GameStrings.getString(GameStrings.actions, "knife_dont_cut_it"), anim: string.Empty),
      new ItemInteraction("coat3", GameStrings.getString(GameStrings.actions, "knife_dont_cut_it"), anim: string.Empty),
      new ItemInteraction("coat4", GameStrings.getString(GameStrings.actions, "knife_dont_cut_it"), anim: string.Empty),
      new ItemInteraction("foodcan", string.Empty, new Action(this.can_open_knife), string.Empty)
    }, soundL: string.Empty);
    this.initItem("canopener", 0.1f, "pickaxe01", soundL: string.Empty);
    this.initItem("screwdriver", 0.1f, "pickaxe01", new List<ItemInteraction>()
    {
      new ItemInteraction("foodcan", string.Empty, new Action(this.can_open_screwdriver), string.Empty),
      new ItemInteraction("fan_broken", string.Empty, new Action(this.fan_fix1), string.Empty),
      new ItemInteraction("heater_broken", string.Empty, new Action(this.heater_fix1), string.Empty)
    }, soundL: string.Empty);
    this.initItem("rope", 2f, "hose", new List<ItemInteraction>()
    {
      new ItemInteraction("hook", string.Empty, new Action(this.rope_hook_use), string.Empty)
    }, soundL: string.Empty);
    this.initItem("ropehook", 2.5f, "hose", soundL: string.Empty);
    this.initItem("hook", 0.5f, "pickaxe01", new List<ItemInteraction>()
    {
      new ItemInteraction("rope", string.Empty, new Action(this.rope_hook_use), string.Empty)
    }, soundL: string.Empty);
    this.initItem("deadbird", 0.1f, "meat", soundL: string.Empty);
    this.initItem("flag", 0.5f, "net", soundL: string.Empty);
    this.initItem("blanket", 0.5f, "net", soundL: string.Empty);
    this.initItem("blanketb", 0.5f, "net", soundL: string.Empty);
    this.initItem("thermalb", 0.1f, "net", soundL: string.Empty);
    this.initItem("generator", 7f, "metal_bang", new List<ItemInteraction>()
    {
      new ItemInteraction("canister_full", string.Empty, new Action(this.fuel_generator), string.Empty)
    }, soundL: string.Empty);
    this.initItem("generator2", 20f, "metal_bang", soundL: string.Empty);
    this.initItem("locket", 0.0f, "necklace", hasExamineScreen: true, var1: 1, var2: 1, var3: 1, texts: new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "barry_locket_1"),
      GameStrings.getString(GameStrings.world_labels, "barry_locket_2"),
      GameStrings.getString(GameStrings.world_labels, "barry_locket_3")
    }, xShift: -110, yShift: 40, r1: 1f, g1: 1f, b1: 1f, r2: 0.0f, g2: 0.0f, b2: 0.0f, a2: 0.5f, cycle: true, lookAction: new ExamineSprite.Delegate(this.locketRead), soundL: string.Empty);
    this.initItem("gasheater_empty", 10f, "metal_bang", new List<ItemInteraction>()
    {
      new ItemInteraction("canister_full", GameStrings.getString(GameStrings.actions, "gasheater_fuel"), anim: string.Empty),
      new ItemInteraction("canister2_full", GameStrings.getString(GameStrings.actions, "gasheater_fuel"), anim: string.Empty),
      new ItemInteraction("gas_tank", string.Empty, new Action(this.put_tank_heater), string.Empty)
    }, new List<ItemInteraction>()
    {
      new ItemInteraction("gas_tank", string.Empty, new Action(this.put_tank_heater_ground), "kneel_s"),
      new ItemInteraction("canister_full", GameStrings.getString(GameStrings.actions, "gasheater_fuel"), anim: string.Empty),
      new ItemInteraction("canister2_full", GameStrings.getString(GameStrings.actions, "gasheater_fuel"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("gasheater", 20f, "metal_bang", animationFrames: 5, animationDelay: 5, soundL: "heater1");
    this.initItem("ext_cord", 0.3f, "hose", new List<ItemInteraction>()
    {
      new ItemInteraction("ac", GameStrings.getString(GameStrings.actions, "cord_plug_first"), anim: string.Empty),
      new ItemInteraction("fan", GameStrings.getString(GameStrings.actions, "cord_plug_first"), anim: string.Empty),
      new ItemInteraction("heater", GameStrings.getString(GameStrings.actions, "cord_plug_first"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("ext_cord_place", -1f, "hose", soundL: string.Empty);
    this.initItem("heater", 2.5f, "electric_item", new List<ItemInteraction>()
    {
      new ItemInteraction("ext_cord", GameStrings.getString(GameStrings.actions, "cord_plug_first"), anim: string.Empty),
      new ItemInteraction("screwdriver", GameStrings.getString(GameStrings.actions, "not_broken"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("fan", 2.5f, "electric_item", new List<ItemInteraction>()
    {
      new ItemInteraction("ext_cord", GameStrings.getString(GameStrings.actions, "cord_plug_first"), anim: string.Empty),
      new ItemInteraction("screwdriver", GameStrings.getString(GameStrings.actions, "not_broken"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("heater_broken", 2.5f, "electric_item_broken", new List<ItemInteraction>()
    {
      new ItemInteraction("screwdriver", string.Empty, new Action(this.heater_fix1), string.Empty)
    }, soundL: string.Empty);
    this.initItem("fan_broken", 2.5f, "electric_item_broken", new List<ItemInteraction>()
    {
      new ItemInteraction("screwdriver", string.Empty, new Action(this.fan_fix1), string.Empty)
    }, soundL: string.Empty);
    this.initItem("ac_cord", -1f, "hose", soundL: string.Empty);
    this.initItem("ac", 10f, "metal_bang", new List<ItemInteraction>()
    {
      new ItemInteraction("ext_cord", GameStrings.getString(GameStrings.actions, "cord_plug_first"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("heat_absorber1", 0.5f, "rock", new List<ItemInteraction>()
    {
      new ItemInteraction("hammer", string.Empty, new Action(this.activate_absorber_1), string.Empty),
      new ItemInteraction("crowbar", string.Empty, new Action(this.activate_absorber_1), string.Empty),
      new ItemInteraction("pipe", string.Empty, new Action(this.activate_absorber_1), string.Empty),
      new ItemInteraction("wrench", string.Empty, new Action(this.activate_absorber_1), string.Empty),
      new ItemInteraction("rock", string.Empty, new Action(this.activate_absorber_1), string.Empty)
    }, new List<ItemInteraction>()
    {
      new ItemInteraction("hammer", string.Empty, new Action(this.activate_absorber_1_ground), "kneel_s"),
      new ItemInteraction("rock", string.Empty, new Action(this.activate_absorber_1_ground), "kneel_s"),
      new ItemInteraction("pipe", string.Empty, new Action(this.activate_absorber_1_ground), "kneel_s"),
      new ItemInteraction("wrench", string.Empty, new Action(this.activate_absorber_1_ground), "kneel_s"),
      new ItemInteraction("crowbar", string.Empty, new Action(this.activate_absorber_1_ground), "kneel_s")
    }, hasExamineScreen: true, var1: 1, var2: 1, var3: 1, var4: 9, texts: new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "heater_inspect_1"),
      GameStrings.getString(GameStrings.world_labels, "heater_inspect_2"),
      GameStrings.getString(GameStrings.world_labels, "heater_inspect_3")
    }, wid: 130, xShift: -10, yShift: 40, r1: 1f, g1: 1f, b1: 1f, r2: 0.0f, g2: 0.0f, b2: 0.0f, a2: 0.5f, cycle: true, soundL: string.Empty);
    this.initItem("heat_absorber2", 0.5f, "rock", new List<ItemInteraction>()
    {
      new ItemInteraction("hammer", string.Empty, new Action(this.activate_absorber_2), string.Empty),
      new ItemInteraction("crowbar", string.Empty, new Action(this.activate_absorber_2), string.Empty),
      new ItemInteraction("pipe", string.Empty, new Action(this.activate_absorber_2), string.Empty),
      new ItemInteraction("wrench", string.Empty, new Action(this.activate_absorber_2), string.Empty),
      new ItemInteraction("rock", string.Empty, new Action(this.activate_absorber_2), string.Empty)
    }, new List<ItemInteraction>()
    {
      new ItemInteraction("hammer", string.Empty, new Action(this.activate_absorber_2_ground), "kneel_s"),
      new ItemInteraction("rock", string.Empty, new Action(this.activate_absorber_2_ground), "kneel_s"),
      new ItemInteraction("pipe", string.Empty, new Action(this.activate_absorber_2_ground), "kneel_s"),
      new ItemInteraction("wrench", string.Empty, new Action(this.activate_absorber_2_ground), "kneel_s"),
      new ItemInteraction("crowbar", string.Empty, new Action(this.activate_absorber_2_ground), "kneel_s")
    }, hasExamineScreen: true, var1: 1, var2: 1, var3: 1, var4: 9, texts: new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "heater_inspect_1"),
      GameStrings.getString(GameStrings.world_labels, "heater_inspect_2"),
      GameStrings.getString(GameStrings.world_labels, "heater_inspect_3")
    }, wid: 130, xShift: -10, yShift: 40, r1: 1f, g1: 1f, b1: 1f, r2: 0.0f, g2: 0.0f, b2: 0.0f, a2: 0.5f, cycle: true, soundL: string.Empty);
    this.initItem("heat_absorber3", 0.5f, "rock", new List<ItemInteraction>()
    {
      new ItemInteraction("hammer", string.Empty, new Action(this.activate_absorber_3), string.Empty),
      new ItemInteraction("crowbar", string.Empty, new Action(this.activate_absorber_3), string.Empty),
      new ItemInteraction("pipe", string.Empty, new Action(this.activate_absorber_3), string.Empty),
      new ItemInteraction("wrench", string.Empty, new Action(this.activate_absorber_3), string.Empty),
      new ItemInteraction("rock", string.Empty, new Action(this.activate_absorber_3), string.Empty)
    }, new List<ItemInteraction>()
    {
      new ItemInteraction("hammer", string.Empty, new Action(this.activate_absorber_3_ground), "kneel_s"),
      new ItemInteraction("rock", string.Empty, new Action(this.activate_absorber_3_ground), "kneel_s"),
      new ItemInteraction("pipe", string.Empty, new Action(this.activate_absorber_3_ground), "kneel_s"),
      new ItemInteraction("wrench", string.Empty, new Action(this.activate_absorber_3_ground), "kneel_s"),
      new ItemInteraction("crowbar", string.Empty, new Action(this.activate_absorber_3_ground), "kneel_s")
    }, hasExamineScreen: true, var1: 1, var2: 1, var3: 1, var4: 9, texts: new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "heater_inspect_1"),
      GameStrings.getString(GameStrings.world_labels, "heater_inspect_2"),
      GameStrings.getString(GameStrings.world_labels, "heater_inspect_3")
    }, wid: 130, xShift: -10, yShift: 40, r1: 1f, g1: 1f, b1: 1f, r2: 0.0f, g2: 0.0f, b2: 0.0f, a2: 0.5f, cycle: true, soundL: string.Empty);
    this.initItem("heat_absorber1A", 0.5f, "rock", soundL: string.Empty);
    this.initItem("heat_absorber2A", 0.5f, "rock", soundL: string.Empty);
    this.initItem("heat_absorber3A", 0.5f, "rock", soundL: string.Empty);
    this.initItem("water1", 0.5f, "waterbottle", soundL: string.Empty);
    this.initItem("water2", 0.5f, "waterbottle", soundL: string.Empty);
    this.initItem("water3", 0.5f, "waterbottle", soundL: string.Empty);
    this.initItem("water4", 0.5f, "waterbottle", soundL: string.Empty);
    this.initItem("sledgehammer", 16f, "metal_bang", soundL: string.Empty);
    this.initItem("sledge_head", 15f, "metal_bang", new List<ItemInteraction>()
    {
      new ItemInteraction("sledge_handle", string.Empty, new Action(this.sledgehammer_fix2), string.Empty)
    }, soundL: string.Empty);
    this.initItem("sledge_handle", 1f, "wooden", new List<ItemInteraction>()
    {
      new ItemInteraction("sledge_head", string.Empty, new Action(this.sledgehammer_fix1), string.Empty)
    }, soundL: string.Empty);
    this.initItem("maggot", -1f, "meat", soundL: string.Empty);
    this.initItem("oil", 2f, "waterbottle", soundL: string.Empty);
    this.initItem("poison", 1f, "glass", new List<ItemInteraction>()
    {
      new ItemInteraction("food_bag", GameStrings.getString(GameStrings.actions, "poision_food"), anim: string.Empty),
      new ItemInteraction("whiskey", GameStrings.getString(GameStrings.actions, "poision_whiskey"), anim: string.Empty),
      new ItemInteraction("watersprayer", GameStrings.getString(GameStrings.actions, "poision_watersprayer"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("food_bag", 0.7f, "net", new List<ItemInteraction>()
    {
      new ItemInteraction("poison", GameStrings.getString(GameStrings.actions, "poision_food"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("gloves", 0.1f, "net", soundL: string.Empty);
    this.initItem("welder", 1f, "metal_bang", soundL: string.Empty);
    this.initItem("mixer_glass", -1f, "glass", soundL: string.Empty);
    this.initItem("pill_half", -1f, "hose", soundL: string.Empty);
    this.initItem("broom", 1f, "logs", soundL: string.Empty);
    this.initItem("stormcatcher1", 1f, "flashlight1", soundL: string.Empty);
    this.initItem("stormcatcher2", 1f, "flashlight1", soundL: string.Empty);
    this.initItem("stormcatcher3", 1f, "flashlight1", soundL: string.Empty);
    this.initItem("finger", 0.0f, "meat", soundL: string.Empty);
    this.initItem("catalyst", 0.5f, "glass", soundL: string.Empty);
    this.initItem("pills", 0.0f, "hose", soundL: string.Empty);
    this.initItem("puzzle_cable", 0.0f, "hose", soundL: string.Empty);
    this.initItem("fire_hose", -1f, "hose", soundL: string.Empty);
    this.initItem("sidereal_id", 0.0f, "plastic", hasExamineScreen: true, var1: 1, var2: 1, var3: 1, texts: new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "sidereal_id_1")
    }, xShift: -110, yShift: 40, r1: 1f, g1: 1f, b1: 1f, r2: 0.0f, g2: 0.0f, b2: 0.0f, a2: 0.5f, cycle: true, soundL: string.Empty);
    this.initItem("sidereal_secrets", 0.0f, "page_turn_04", hasExamineScreen: true, var1: 1, var2: 1, var3: 1, texts: new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "sidereal_secrets_1"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_secrets_2"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_secrets_3"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_secrets_4"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_secrets_5"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_secrets_6"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_secrets_7"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_secrets_8"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_secrets_9"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_secrets_10")
    }, wid: 150, xShift: -60, yShift: 50, r1: 0.1f, g1: 0.1f, b1: 0.1f, a1: 0.0f, r2: 0.0f, g2: 0.0f, b2: 0.0f, a2: 0.0f, cycle: true, soundL: string.Empty);
    this.initItem("sidereal_docs", 0.0f, "page_turn_03", hasExamineScreen: true, var1: 1, var2: 1, var3: 1, texts: new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "sidereal_docs_1"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_docs_2"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_docs_3"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_docs_4"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_docs_5"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_docs_6"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_docs_7"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_docs_8"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_docs_9"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_docs_10")
    }, xShift: -30, yShift: 50, r1: 0.1f, g1: 0.1f, b1: 0.1f, a1: 0.0f, r2: 0.0f, g2: 0.0f, b2: 0.0f, a2: 0.0f, cycle: true, soundL: string.Empty);
    this.initItem("sidereal_id_key", 0.0f, "plastic", hasExamineScreen: true, var1: 1, var2: 1, var3: 1, texts: new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "sidereal_id_1"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_id_2"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_id_3")
    }, xShift: -110, yShift: 40, r1: 1f, g1: 1f, b1: 1f, r2: 0.0f, g2: 0.0f, b2: 0.0f, a2: 0.5f, cycle: true, lookAction: new ExamineSprite.Delegate(this.siderealIdExamined), soundL: string.Empty, actionOnLook: false);
    this.initItem("sidereal_xero", 0.0f, "page_turn_03", hasExamineScreen: true, var1: 1, var2: 1, var3: 1, var4: 1, texts: new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "sidereal_xero_1"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_xero_2"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_xero_3"),
      GameStrings.getString(GameStrings.world_labels, "sidereal_xero_4") + " ^ ^ "
    }, wid: 150, xShift: -60, yShift: 50, r1: 0.1f, g1: 0.1f, b1: 0.1f, a1: 0.0f, r2: 0.0f, g2: 0.0f, b2: 0.0f, a2: 0.0f, cycle: true, lookAction: new ExamineSprite.Delegate(this.scary), soundL: string.Empty, actionOnLook: false);
    this.initItem("remote", 0.0f, "plastic", new List<ItemInteraction>()
    {
      new ItemInteraction("hammer", string.Empty, new Action(this.break_remote), string.Empty),
      new ItemInteraction("screwdriver", string.Empty, new Action(this.open_remote), string.Empty)
    }, hasExamineScreen: true, var1: 1, var2: 1, texts: new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "remote_1"),
      GameStrings.getString(GameStrings.world_labels, "remote_2")
    }, wid: 100, xShift: -110, yShift: 40, r1: 1f, g1: 1f, b1: 1f, r2: 0.0f, g2: 0.0f, b2: 0.0f, a2: 0.5f, cycle: true, soundL: string.Empty);
    this.initItem("outpost_card", 0.0f, "plastic", hasExamineScreen: true, wid: 100, xShift: -110, yShift: 40, r1: 1f, g1: 1f, b1: 1f, r2: 0.0f, g2: 0.0f, b2: 0.0f, a2: 0.5f, cycle: true, soundL: string.Empty);
    this.initItem("moon_card", 0.0f, "plastic", hasExamineScreen: true, wid: 100, xShift: -110, yShift: 40, r1: 1f, g1: 1f, b1: 1f, r2: 0.0f, g2: 0.0f, b2: 0.0f, a2: 0.5f, cycle: true, soundL: string.Empty);
    this.initItem("batteries", 0.0f, "nails", new List<ItemInteraction>()
    {
      new ItemInteraction("gluegun", string.Empty, new Action(this.power_gluegon), string.Empty)
    }, soundL: string.Empty);
    this.initItem("gluegun", 0.0f, "plastic", new List<ItemInteraction>()
    {
      new ItemInteraction("batteries", string.Empty, new Action(this.power_gluegon), string.Empty)
    }, soundL: string.Empty);
    this.initItem("gluegun_powered", 0.0f, "plastic", soundL: string.Empty);
    this.initItem("fingerprint", 0.0f, "meat", soundL: string.Empty);
    this.initItem("vials1", 0.1f, "tripleglass", soundL: string.Empty);
    this.initItem("vials2", 0.1f, "tripleglass", soundL: string.Empty);
    this.initItem("engine_calibrator", 2.5f, "metal_bang", soundL: string.Empty);
    this.initItem("lioh_filter", 2.5f, "metal_bang", soundL: string.Empty);
    this.initItem("metal_slab", 2f, "metal_bang", soundL: string.Empty);
    this.initItem("nav_chip", 0.1f, "plastic", soundL: string.Empty);
    this.initItem("air_tanks", 8f, "metal_bang", soundL: string.Empty);
    this.initItem("transmission_belt", 0.2f, "hose", soundL: string.Empty);
    this.initItem("duplexer", 0.2f, "plastic", soundL: string.Empty);
    this.initItem("noodles", 0.2f, "plastic", soundL: string.Empty);
    this.initItem("voltmeter", 0.2f, "plastic", soundL: string.Empty);
    this.initItem("gasket", 0.2f, "plastic", soundL: string.Empty);
    this.initItem("nuts_and_bolts", 0.2f, "plastic", soundL: string.Empty);
    this.initItem("wires", 0.2f, "plastic", soundL: string.Empty);
    this.initItem("wire", 2.2f, "plastic", soundL: string.Empty);
    this.initItem("bandage", 0.2f, "net", new List<ItemInteraction>()
    {
      new ItemInteraction("whiskey", GameStrings.getString(GameStrings.actions, "no_molotov"), anim: string.Empty)
    }, soundL: string.Empty);
    this.initItem("disc1", 0.0f, "plastic", soundL: string.Empty);
    this.initItem("disc2", 0.0f, "plastic", soundL: string.Empty);
    this.initItem("manifest", 0.0f, "page_turn_04", hasExamineScreen: true, texts: new List<string>()
    {
      "..."
    }, wid: 160, xShift: -50, yShift: 50, a2: 0.0f, soundL: string.Empty);
    this.initItem("cate_note", 0.0f, "page_turn_03", hasExamineScreen: true, texts: new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "cate_last_words_1"),
      GameStrings.getString(GameStrings.world_labels, "cate_last_words_2"),
      GameStrings.getString(GameStrings.world_labels, "cate_last_words_3"),
      GameStrings.getString(GameStrings.world_labels, "cate_last_words_4"),
      GameStrings.getString(GameStrings.world_labels, "cate_last_words_5"),
      GameStrings.getString(GameStrings.world_labels, "cate_last_words_6"),
      GameStrings.getString(GameStrings.world_labels, "cate_last_words_7"),
      GameStrings.getString(GameStrings.world_labels, "cate_last_words_8"),
      GameStrings.getString(GameStrings.world_labels, "cate_last_words_9"),
      GameStrings.getString(GameStrings.world_labels, "cate_last_words_10")
    }, wid: 133, xShift: -20, yShift: 55, soundL: string.Empty);
  }

  public void scary()
  {
  }

  public void power_gluegon()
  {
    PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "gluegun_powered"));
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.necklace);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.small_powerup);
    this.combineItems("gluegun", "batteries", "gluegun_powered");
  }

  public void combineItems(string item1, string item2, string result)
  {
    string selectedItemName = CursorController.cc.selectedItemName;
    CursorController.cc.deselectItem();
    string name = !(selectedItemName == item1) ? item1 : item2;
    int locX = ItemsManager.im.getItem(name).dataRef.locX;
    int locY = ItemsManager.im.getItem(name).dataRef.locY;
    string droppedLocation = ItemsManager.im.getItem(name).dataRef.droppedLocation;
    InventoryController.ic.removeItem(item1);
    InventoryController.ic.removeItem(item2);
    ItemsManager.im.updateItem(result, droppedLocation, locX, locY);
    InventoryController.ic.loadItem(ItemsManager.im.getItem(result));
    this.putAwayOrDropIfTheResultIsTooHeavy(result);
  }

  public void resetSpring1() => QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "reset_trap"), yesClick: new Button.Delegate(this.resetSpring1b), time: 30, timeSaver: 6);

  public void open_remote()
  {
    PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "remote_open"));
    InventoryController.ic.removeItem("remote");
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.screw);
    InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("batteries"));
  }

  public void break_remote()
  {
    PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "remote_break"));
    InventoryController.ic.removeItem("remote");
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.generic_hit);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.wood_snap);
    InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("batteries"));
  }

  public void resetSpring2() => QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "reset_trap"), yesClick: new Button.Delegate(this.resetSpring2b), time: 30, timeSaver: 6);

  public void resetSpring1b()
  {
    this.getItem("bear_trap_1").dataRef.droppedLocation = this.getItem("bear_trap_1b").dataRef.droppedLocation;
    this.getItem("bear_trap_1").dataRef.locX = this.getItem("bear_trap_1b").dataRef.locX;
    this.getItem("bear_trap_1").dataRef.locY = this.getItem("bear_trap_1b").dataRef.locY;
    this.getItem("bear_trap_1b").dataRef.droppedLocation = "nowhere";
    CurtainController.cc.fadeOut(sound: SoundsManagerController.sm.screw, actionAfterFade: new CurtainController.Delegate(this.resetSpring1c));
  }

  public void resetSpring1c()
  {
    this.removeGroundItem("bear_trap_1b");
    Vector2 screen = ScreenControler.gameToScreen(new Vector2((float) this.getItem("bear_trap_1b").dataRef.locX, (float) (this.getItem("bear_trap_1b").dataRef.locY + GroundItemController.yOffset)));
    Vector3 vector3 = new Vector3(screen.x, screen.y, 0.0f);
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint((Vector3) screen);
    (UnityEngine.Object.Instantiate(Resources.Load("Prefabs/GroundItem"), worldPoint, new Quaternion()) as GameObject).GetComponent<GroundItemController>().init(ItemsManager.im.getItem("bear_trap_1"));
  }

  public void resetSpring2b()
  {
    this.getItem("bear_trap_2").dataRef.droppedLocation = this.getItem("bear_trap_2b").dataRef.droppedLocation;
    this.getItem("bear_trap_2").dataRef.locX = this.getItem("bear_trap_2b").dataRef.locX;
    this.getItem("bear_trap_2").dataRef.locY = this.getItem("bear_trap_2b").dataRef.locY;
    this.getItem("bear_trap_2b").dataRef.droppedLocation = "nowhere";
    CurtainController.cc.fadeOut(sound: SoundsManagerController.sm.screw, actionAfterFade: new CurtainController.Delegate(this.resetSpring2c));
  }

  public void resetSpring2c()
  {
    this.removeGroundItem("bear_trap_2b");
    Vector2 screen = ScreenControler.gameToScreen(new Vector2((float) this.getItem("bear_trap_2b").dataRef.locX, (float) (this.getItem("bear_trap_2b").dataRef.locY + GroundItemController.yOffset)));
    Vector3 vector3 = new Vector3(screen.x, screen.y, 0.0f);
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint((Vector3) screen);
    (UnityEngine.Object.Instantiate(Resources.Load("Prefabs/GroundItem"), worldPoint, new Quaternion()) as GameObject).GetComponent<GroundItemController>().init(ItemsManager.im.getItem("bear_trap_2"));
  }

  public void rifleInstallScope()
  {
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "install_scope"), yesClick: new Button.Delegate(this.rifleInstallScope2), time: 60);
  }

  public void rifleInstallScope2()
  {
    InventoryButtonController.ibc.close();
    CurtainController.cc.fadeOut(sound: SoundsManagerController.sm.repair);
    string str = string.Empty;
    string theThing = string.Empty;
    for (int index1 = 0; index1 <= 1; ++index1)
    {
      if (index1 == 0)
        str = string.Empty;
      if (index1 == 1)
        str = "s_";
      for (int index2 = 0; index2 <= 6; ++index2)
      {
        string name = "rifle_" + str + (object) index2;
        if (InventoryController.ic.isItemInInventoryOrTrunkOrWhatever(name))
        {
          int locX = ItemsManager.im.getItem(name).dataRef.locX;
          int locY = ItemsManager.im.getItem(name).dataRef.locY;
          string droppedLocation = ItemsManager.im.getItem(name).dataRef.droppedLocation;
          InventoryController.ic.removeItem(name);
          if (str == string.Empty)
            str = "o_";
          else if (str == "s_")
            str = "so_";
          ItemsManager.im.updateItem("rifle_" + str + (object) index2, droppedLocation, locX, locY);
          InventoryController.ic.loadItem(ItemsManager.im.getItem("rifle_" + str + (object) index2));
          theThing = "rifle_" + str + (object) index2;
          PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.revolver);
        }
      }
    }
    InventoryController.ic.removeItem("scope");
    this.putAwayOrDropIfTheResultIsTooHeavy(theThing);
  }

  public void putAwayOrDropIfTheResultIsTooHeavy(string theThing)
  {
    if ((double) InventoryController.ic.getCurrentWeight() <= (double) InventoryController.ic.maxCapacity)
      return;
    bool flag = false;
    if (InventoryController.ic.trunk.activeSelf)
      flag = InventoryController.ic.putItemInTrunk(theThing, true);
    if (!flag && InventoryController.ic.chest.activeSelf)
      flag = InventoryController.ic.putItemInChest(theThing, true);
    if (flag)
      return;
    InventoryController.ic.dropItem(ItemsManager.im.getItem(theThing), true);
    if (InventoryController.ic.trunk.activeSelf)
      PlayerController.pc.sayLine(GameStrings.getString(GameStrings.gui, "capacity_full2"));
    else if (InventoryController.ic.chest.activeSelf)
      PlayerController.pc.sayLine(GameStrings.getString(GameStrings.gui, "capacity_full3"));
    else
      PlayerController.pc.sayLine(GameStrings.getString(GameStrings.gui, "capacity_full1"));
  }

  public void rifleInstallSilencer()
  {
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "install_silencer"), yesClick: new Button.Delegate(this.rifleInstallSilencer2), time: 60);
  }

  public void rifleInstallSilencer2()
  {
    InventoryButtonController.ibc.close();
    CurtainController.cc.fadeOut(sound: SoundsManagerController.sm.repair);
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    string str = string.Empty;
    string theThing = string.Empty;
    for (int index1 = 0; index1 <= 1; ++index1)
    {
      if (index1 == 0)
        str = string.Empty;
      if (index1 == 1)
        str = "o_";
      for (int index2 = 0; index2 <= 6; ++index2)
      {
        string name = "rifle_" + str + (object) index2;
        if (InventoryController.ic.isItemInInventoryOrTrunkOrWhatever(name))
        {
          int locX = ItemsManager.im.getItem(name).dataRef.locX;
          int locY = ItemsManager.im.getItem(name).dataRef.locY;
          string droppedLocation = ItemsManager.im.getItem(name).dataRef.droppedLocation;
          InventoryController.ic.removeItem(name);
          if (str == string.Empty)
            str = "s_";
          else if (str == "o_")
            str = "so_";
          ItemsManager.im.updateItem("rifle_" + str + (object) index2, droppedLocation, locX, locY);
          InventoryController.ic.loadItem(ItemsManager.im.getItem("rifle_" + str + (object) index2));
          theThing = "rifle_" + str + (object) index2;
          PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.revolver);
        }
      }
    }
    InventoryController.ic.removeItem("silencer");
    this.putAwayOrDropIfTheResultIsTooHeavy(theThing);
  }

  public void siderealIdExamined()
  {
    InventoryController.ic.removeItem("sidereal_id_key");
    InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("key1"));
    InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("sidereal_id"));
  }

  public void activate_absorber(string subject)
  {
    CursorController.cc.deselectItem();
    int locX = ItemsManager.im.getItem(subject).dataRef.locX;
    int locY = ItemsManager.im.getItem(subject).dataRef.locY;
    string droppedLocation = ItemsManager.im.getItem(subject).dataRef.droppedLocation;
    InventoryController.ic.removeItem(subject);
    ItemsManager.im.updateItem(subject + "A", droppedLocation, locX, locY);
    InventoryController.ic.loadItem(ItemsManager.im.getItem(subject + "A"));
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.heater_hiss);
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "heat_absorber_activated"));
  }

  public void activate_absorber_ground(string subject)
  {
    CursorController.cc.deselectItem();
    ItemsManager.im.updateItem(subject, "nowhere", 0, 0);
    this.removeGroundItem(subject);
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(PlayerController.wc.currentXY.x, PlayerController.wc.currentXY.y + (float) GroundItemController.yOffset));
    Vector3 vector3 = new Vector3(screen.x, screen.y, 0.0f);
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint((Vector3) screen);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.heater_hiss);
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "heat_absorber_activated"));
    (UnityEngine.Object.Instantiate(Resources.Load("Prefabs/GroundItem"), worldPoint, new Quaternion()) as GameObject).GetComponent<GroundItemController>().init(ItemsManager.im.getItem(subject + "A"));
    ItemsManager.im.getItem(subject + "A").dataRef.locX = (int) PlayerController.wc.currentXY.x;
    ItemsManager.im.getItem(subject + "A").dataRef.locY = (int) PlayerController.wc.currentXY.y;
    ItemsManager.im.getItem(subject + "A").dataRef.droppedLocation = SceneManager.GetActiveScene().name;
  }

  public void activate_absorber_1() => this.activate_absorber("heat_absorber1");

  public void activate_absorber_1_ground() => this.activate_absorber_ground("heat_absorber1");

  public void activate_absorber_2() => this.activate_absorber("heat_absorber2");

  public void activate_absorber_2_ground() => this.activate_absorber_ground("heat_absorber2");

  public void activate_absorber_3() => this.activate_absorber("heat_absorber3");

  public void activate_absorber_3_ground() => this.activate_absorber_ground("heat_absorber3");

  public void put_tank_heater()
  {
    string selectedItemName = CursorController.cc.selectedItemName;
    CursorController.cc.deselectItem();
    string name = !(selectedItemName == "gasheater_empty") ? "gasheater_empty" : "gas_tank";
    int locX = ItemsManager.im.getItem(name).dataRef.locX;
    int locY = ItemsManager.im.getItem(name).dataRef.locY;
    string droppedLocation = ItemsManager.im.getItem(name).dataRef.droppedLocation;
    InventoryController.ic.removeItem("gas_tank");
    InventoryController.ic.removeItem("gasheater_empty");
    ItemsManager.im.updateItem("gasheater", droppedLocation, locX, locY);
    InventoryController.ic.loadItem(ItemsManager.im.getItem("gasheater"));
    PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "gasheater"));
    this.putAwayOrDropIfTheResultIsTooHeavy("gasheater");
  }

  public void put_tank_heater_ground()
  {
    string name = "gas_tank";
    CursorController.cc.deselectItem();
    int locX = ItemsManager.im.getItem(name).dataRef.locX;
    int locY = ItemsManager.im.getItem(name).dataRef.locY;
    InventoryController.ic.removeItem("gas_tank");
    ItemsManager.im.updateItem("gasheater_empty", "nowhere", 0, 0);
    this.removeGroundItem("gasheater_empty");
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(PlayerController.wc.currentXY.x, PlayerController.wc.currentXY.y + (float) GroundItemController.yOffset));
    Vector3 vector3 = new Vector3(screen.x, screen.y, 0.0f);
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint((Vector3) screen);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.hose);
    (UnityEngine.Object.Instantiate(Resources.Load("Prefabs/GroundItem"), worldPoint, new Quaternion()) as GameObject).GetComponent<GroundItemController>().init(ItemsManager.im.getItem("gasheater"));
    ItemsManager.im.getItem("gasheater").dataRef.locX = (int) PlayerController.wc.currentXY.x;
    ItemsManager.im.getItem("gasheater").dataRef.locY = (int) PlayerController.wc.currentXY.y;
    ItemsManager.im.getItem("gasheater").dataRef.droppedLocation = SceneManager.GetActiveScene().name;
  }

  public void locketRead() => GameDataController.gd.setObjective("house_b_wife_note_read", true);

  private void rope_hook_use()
  {
    string selectedItemName = CursorController.cc.selectedItemName;
    CursorController.cc.deselectItem();
    string name = !(selectedItemName == "rope") ? "rope" : "hook";
    int locX = ItemsManager.im.getItem(name).dataRef.locX;
    int locY = ItemsManager.im.getItem(name).dataRef.locY;
    string droppedLocation = ItemsManager.im.getItem(name).dataRef.droppedLocation;
    InventoryController.ic.removeItem("rope");
    InventoryController.ic.removeItem("hook");
    ItemsManager.im.updateItem("ropehook", droppedLocation, locX, locY);
    InventoryController.ic.loadItem(ItemsManager.im.getItem("ropehook"));
    PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "ropehook"));
    this.putAwayOrDropIfTheResultIsTooHeavy("ropehook");
  }

  public void sonic_remote_use()
  {
    PlayerController.wc.fullStop(true);
    PlayerController.pc.spawnName = "InfoExit";
    GameDataController.gd.previousLocation = SceneManager.GetActiveScene().name;
    GameDataController.gd.previousX = (int) PlayerController.wc.currentXY.x;
    GameDataController.gd.previousY = (int) PlayerController.wc.currentXY.y;
    CurtainController.cc.fadeOut("SonicRemote", WalkController.Direction.S);
    PlayerController.wc.fullStop();
  }

  public void sledgehammer_fix1() => this.sledgehammer_fix3("sledge_handle");

  public void sledgehammer_fix2() => this.sledgehammer_fix3("sledge_head");

  public void sledgehammer_fix3(string it2)
  {
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    int locX = ItemsManager.im.getItem(it2).dataRef.locX;
    int locY = ItemsManager.im.getItem(it2).dataRef.locY;
    InventoryController.ic.removeItem("sledge_head");
    InventoryController.ic.removeItem("sledge_handle");
    ItemsManager.im.updateItem("sledgehammer", "inventory", locX, locY);
    InventoryController.ic.loadItem(ItemsManager.im.getItem("sledgehammer"));
  }

  public void fan_fix1()
  {
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "fan_fix"), yesClick: new Button.Delegate(this.fan_fix2), time: 90, timeSaver: 10);
  }

  public void fan_fix2()
  {
    int locX = ItemsManager.im.getItem("fan_broken").dataRef.locX;
    int locY = ItemsManager.im.getItem("fan_broken").dataRef.locY;
    string droppedLocation = ItemsManager.im.getItem("fan_broken").dataRef.droppedLocation;
    InventoryController.ic.removeItem("fan_broken");
    ItemsManager.im.updateItem("fan", droppedLocation, locX, locY);
    InventoryController.ic.loadItem(ItemsManager.im.getItem("fan"));
    InventoryButtonController.ibc.close();
    PlayerController.pc.setBusy(true);
    CurtainController.cc.fadeOut();
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.repair);
    this.putAwayOrDropIfTheResultIsTooHeavy("fan");
  }

  public void heater_fix1()
  {
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "heater_fix"), yesClick: new Button.Delegate(this.heater_fix2), time: 90, timeSaver: 10);
  }

  public void heater_fix2()
  {
    int locX = ItemsManager.im.getItem("heater_broken").dataRef.locX;
    int locY = ItemsManager.im.getItem("heater_broken").dataRef.locY;
    string droppedLocation = ItemsManager.im.getItem("heater_broken").dataRef.droppedLocation;
    InventoryController.ic.removeItem("heater_broken");
    ItemsManager.im.updateItem("heater", droppedLocation, locX, locY);
    InventoryController.ic.loadItem(ItemsManager.im.getItem("heater"));
    InventoryButtonController.ibc.close();
    PlayerController.pc.setBusy(true);
    CurtainController.cc.fadeOut();
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.repair);
    this.putAwayOrDropIfTheResultIsTooHeavy("heater");
  }

  public void hammer_fix()
  {
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    int locX = ItemsManager.im.getItem("broken_hammer").dataRef.locX;
    int locY = ItemsManager.im.getItem("broken_hammer").dataRef.locY;
    string droppedLocation = ItemsManager.im.getItem("broken_hammer").dataRef.droppedLocation;
    InventoryController.ic.removeItem("broken_hammer");
    InventoryController.ic.removeItem("hammer_handle");
    ItemsManager.im.updateItem("hammer", droppedLocation, locX, locY);
    InventoryController.ic.loadItem(ItemsManager.im.getItem("hammer"));
    this.putAwayOrDropIfTheResultIsTooHeavy("hammer");
  }

  public void can_open()
  {
    InventoryButtonController.ibc.close();
    int locX = ItemsManager.im.getItem("foodcan").dataRef.locX;
    int locY = ItemsManager.im.getItem("foodcan").dataRef.locY;
    string droppedLocation = ItemsManager.im.getItem("foodcan").dataRef.droppedLocation;
    InventoryController.ic.removeItem("foodcan");
    ItemsManager.im.updateItem("foodcanopen", droppedLocation, locX, locY);
    InventoryController.ic.loadItem(ItemsManager.im.getItem("foodcanopen"));
    string txt = GameStrings.getString(GameStrings.actions, "foodcan_open");
    PlayerController.pc.sayLine(txt);
    this.putAwayOrDropIfTheResultIsTooHeavy("foodcanopen");
  }

  public void reloadGun()
  {
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    for (int index = 0; index < 6; ++index)
    {
      if (InventoryController.ic.isItemInInventoryOrTrunkOrWhatever("revolver_" + (object) index))
      {
        int locX = ItemsManager.im.getItem("revolver_" + (object) index).dataRef.locX;
        int locY = ItemsManager.im.getItem("revolver_" + (object) index).dataRef.locY;
        string droppedLocation = ItemsManager.im.getItem("revolver_" + (object) index).dataRef.droppedLocation;
        InventoryController.ic.removeItem("revolver_" + (object) index);
        ItemsManager.im.updateItem("revolver_6", droppedLocation, locX, locY);
        InventoryController.ic.loadItem(ItemsManager.im.getItem("revolver_6"));
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.revolver);
      }
    }
  }

  public void reloadRifle()
  {
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    string str = string.Empty;
    for (int index1 = 0; index1 <= 3; ++index1)
    {
      if (index1 == 0)
        str = string.Empty;
      if (index1 == 1)
        str = "s_";
      if (index1 == 2)
        str = "o_";
      if (index1 == 3)
        str = "so_";
      for (int index2 = 0; index2 < 6; ++index2)
      {
        string name = "rifle_" + str + (object) index2;
        if (InventoryController.ic.isItemInInventoryOrTrunkOrWhatever(name))
        {
          int locX = ItemsManager.im.getItem(name).dataRef.locX;
          int locY = ItemsManager.im.getItem(name).dataRef.locY;
          string droppedLocation = ItemsManager.im.getItem(name).dataRef.droppedLocation;
          InventoryController.ic.removeItem(name);
          ItemsManager.im.updateItem("rifle_" + str + "6", droppedLocation, locX, locY);
          InventoryController.ic.loadItem(ItemsManager.im.getItem("rifle_" + str + "6"));
          PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.revolver);
        }
      }
    }
  }

  public void can_open_knife()
  {
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, nameof (can_open_knife)), yesClick: new Button.Delegate(this.can_open), time: 5);
  }

  public void can_open_screwdriver()
  {
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, nameof (can_open_screwdriver)), yesClick: new Button.Delegate(this.can_open), time: 10);
  }

  public void chemsuit_fix1()
  {
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    int locX = ItemsManager.im.getItem("chemsuit_dmg_dmg").dataRef.locX;
    int locY = ItemsManager.im.getItem("chemsuit_dmg_dmg").dataRef.locY;
    string droppedLocation = ItemsManager.im.getItem("chemsuit_dmg_dmg").dataRef.droppedLocation;
    InventoryController.ic.removeItem("chemsuit_dmg_dmg");
    ItemsManager.im.updateItem("chemsuit_rep_dmg", droppedLocation, locX, locY);
    InventoryController.ic.loadItem(ItemsManager.im.getItem("chemsuit_rep_dmg"));
    string txt = GameStrings.getString(GameStrings.actions, "chemsuit_ducttape");
    PlayerController.pc.sayLine(txt);
    this.putAwayOrDropIfTheResultIsTooHeavy("chemsuit_rep_dmg");
  }

  public void chemsuit_fix2()
  {
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    int locX = ItemsManager.im.getItem("chemsuit_dmg_rep").dataRef.locX;
    int locY = ItemsManager.im.getItem("chemsuit_dmg_rep").dataRef.locY;
    string droppedLocation = ItemsManager.im.getItem("chemsuit_dmg_rep").dataRef.droppedLocation;
    InventoryController.ic.removeItem("chemsuit_dmg_rep");
    ItemsManager.im.updateItem("chemsuit_rep_rep", droppedLocation, locX, locY);
    InventoryController.ic.loadItem(ItemsManager.im.getItem("chemsuit_rep_rep"));
    string txt = GameStrings.getString(GameStrings.actions, "chemsuit_ducttape");
    PlayerController.pc.sayLine(txt);
    this.putAwayOrDropIfTheResultIsTooHeavy("chemsuit_rep_rep");
  }

  public void chemsuit_filter1()
  {
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    int locX = ItemsManager.im.getItem("chemsuit_dmg_dmg").dataRef.locX;
    int locY = ItemsManager.im.getItem("chemsuit_dmg_dmg").dataRef.locY;
    string droppedLocation = ItemsManager.im.getItem("chemsuit_dmg_dmg").dataRef.droppedLocation;
    InventoryController.ic.removeItem("chemsuit_dmg_dmg");
    InventoryController.ic.removeItem("mask_filter");
    ItemsManager.im.updateItem("chemsuit_dmg_rep", droppedLocation, locX, locY);
    InventoryController.ic.loadItem(ItemsManager.im.getItem("chemsuit_dmg_rep"));
    string txt = GameStrings.getString(GameStrings.actions, "chemsuit_filter");
    PlayerController.pc.sayLine(txt);
    this.putAwayOrDropIfTheResultIsTooHeavy("chemsuit_dmg_rep");
  }

  public void chemsuit_filter2()
  {
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    int locX = ItemsManager.im.getItem("chemsuit_rep_dmg").dataRef.locX;
    int locY = ItemsManager.im.getItem("chemsuit_dmg_dmg").dataRef.locY;
    string droppedLocation = ItemsManager.im.getItem("chemsuit_rep_dmg").dataRef.droppedLocation;
    InventoryController.ic.removeItem("chemsuit_rep_dmg");
    InventoryController.ic.removeItem("mask_filter");
    ItemsManager.im.updateItem("chemsuit_rep_rep", droppedLocation, locX, locY);
    InventoryController.ic.loadItem(ItemsManager.im.getItem("chemsuit_rep_rep"));
    string txt = GameStrings.getString(GameStrings.actions, "chemsuit_filter");
    PlayerController.pc.sayLine(txt);
    this.putAwayOrDropIfTheResultIsTooHeavy("chemsuit_rep_rep");
  }

  public void fuel_generator()
  {
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    string name = "generator";
    int locX1 = ItemsManager.im.getItem(name).dataRef.locX;
    int locY1 = ItemsManager.im.getItem(name).dataRef.locY;
    int locX2 = ItemsManager.im.getItem("canister_full").dataRef.locX;
    int locY2 = ItemsManager.im.getItem("canister_full").dataRef.locY;
    InventoryController.ic.removeItem("canister_full");
    InventoryController.ic.removeItem(name);
    ItemsManager.im.updateItem("canister_empty", "inventory", locX2, locY2);
    InventoryController.ic.loadItem(ItemsManager.im.getItem("canister_empty"));
    string text = GameStrings.getString(GameStrings.actions, nameof (fuel_generator));
    ItemsManager.im.updateItem("generator2", "inventory", locX1, locY1);
    InventoryController.ic.loadItem(ItemsManager.im.getItem("generator2"));
    PlayerController.pc.textField.viewText(text, true);
  }

  public void fuel_sprayer_use()
  {
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    string name = ItemsManager.im.getItem("watersprayer").dataRef.droppedLocation == "inventory" || ItemsManager.im.getItem("watersprayer").dataRef.droppedLocation == "chest" || ItemsManager.im.getItem("watersprayer").dataRef.droppedLocation == "trunk" ? "watersprayer" : "flamethrower_empty";
    int locX1 = ItemsManager.im.getItem(name).dataRef.locX;
    int locY1 = ItemsManager.im.getItem(name).dataRef.locY;
    string droppedLocation1 = ItemsManager.im.getItem(name).dataRef.droppedLocation;
    string droppedLocation2 = ItemsManager.im.getItem("canister_full").dataRef.droppedLocation;
    int locX2 = ItemsManager.im.getItem("canister_full").dataRef.locX;
    int locY2 = ItemsManager.im.getItem("canister_full").dataRef.locY;
    InventoryController.ic.removeItem("canister_full");
    InventoryController.ic.removeItem(name);
    ItemsManager.im.updateItem("canister_empty", droppedLocation2, locX2, locY2);
    InventoryController.ic.loadItem(ItemsManager.im.getItem("canister_empty"));
    string txt1 = GameStrings.getString(GameStrings.actions, "fuel_watersprayer");
    if (name == "watersprayer")
    {
      ItemsManager.im.updateItem("fuelsprayer", droppedLocation1, locX1, locY1);
      InventoryController.ic.loadItem(ItemsManager.im.getItem("fuelsprayer"));
      PlayerController.pc.sayLine(txt1);
      this.putAwayOrDropIfTheResultIsTooHeavy("fuelsprayer");
    }
    else
    {
      string txt2 = txt1 + GameStrings.getString(GameStrings.actions, "flamethrower_ready");
      ItemsManager.im.updateItem("flamethrower", droppedLocation1, locX1, locY1);
      InventoryController.ic.loadItem(ItemsManager.im.getItem("flamethrower"));
      PlayerController.pc.sayLine(txt2);
      GameDataController.Achievement("S_PYRO");
      this.putAwayOrDropIfTheResultIsTooHeavy("flamethrower");
    }
  }

  public void fuel_sprayer_use2()
  {
    PlayerController.wc.fullStop(true);
    CursorController.cc.deselectItem();
    string name = ItemsManager.im.getItem("watersprayer").dataRef.droppedLocation == "inventory" || ItemsManager.im.getItem("watersprayer").dataRef.droppedLocation == "chest" || ItemsManager.im.getItem("watersprayer").dataRef.droppedLocation == "trunk" ? "watersprayer" : "flamethrower_empty";
    int locX1 = ItemsManager.im.getItem(name).dataRef.locX;
    int locY1 = ItemsManager.im.getItem(name).dataRef.locY;
    string droppedLocation1 = ItemsManager.im.getItem(name).dataRef.droppedLocation;
    int locX2 = ItemsManager.im.getItem("canister2_full").dataRef.locX;
    int locY2 = ItemsManager.im.getItem("canister2_full").dataRef.locY;
    string droppedLocation2 = ItemsManager.im.getItem("canister2_full").dataRef.droppedLocation;
    InventoryController.ic.removeItem("canister2_full");
    InventoryController.ic.removeItem(name);
    ItemsManager.im.updateItem("canister2_empty", droppedLocation2, locX2, locY2);
    InventoryController.ic.loadItem(ItemsManager.im.getItem("canister2_empty"));
    string txt1 = GameStrings.getString(GameStrings.actions, "fuel_watersprayer");
    if (name == "watersprayer")
    {
      ItemsManager.im.updateItem("fuelsprayer", droppedLocation1, locX1, locY1);
      InventoryController.ic.loadItem(ItemsManager.im.getItem("fuelsprayer"));
      PlayerController.pc.sayLine(txt1);
      this.putAwayOrDropIfTheResultIsTooHeavy("fuelsprayer");
    }
    else
    {
      string txt2 = txt1 + GameStrings.getString(GameStrings.actions, "flamethrower_ready");
      ItemsManager.im.updateItem("flamethrower", droppedLocation1, locX1, locY1);
      InventoryController.ic.loadItem(ItemsManager.im.getItem("flamethrower"));
      GameDataController.Achievement("S_PYRO");
      PlayerController.pc.sayLine(txt2);
      this.putAwayOrDropIfTheResultIsTooHeavy("flamethrower");
    }
  }

  public void lighter_sprayer_use()
  {
    if (ItemsManager.im.getItem("ducttape").dataRef.droppedLocation != "inventory" && !InventoryController.ic.trunk.activeSelf && !InventoryController.ic.chest.activeSelf || ItemsManager.im.getItem("ducttape").dataRef.droppedLocation != "inventory" && InventoryController.ic.trunk.activeSelf && !InventoryController.ic.chest.activeSelf && ItemsManager.im.getItem("ducttape").dataRef.droppedLocation != "trunk" || ItemsManager.im.getItem("ducttape").dataRef.droppedLocation != "inventory" && !InventoryController.ic.trunk.activeSelf && InventoryController.ic.chest.activeSelf && ItemsManager.im.getItem("ducttape").dataRef.droppedLocation != "chest")
    {
      PlayerController.wc.fullStop(true);
      CursorController.cc.deselectItem();
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "no_ducttape_watersprayer"), true);
    }
    else
    {
      string name = ItemsManager.im.getItem("watersprayer").dataRef.droppedLocation == "inventory" || ItemsManager.im.getItem("watersprayer").dataRef.droppedLocation == "chest" || ItemsManager.im.getItem("watersprayer").dataRef.droppedLocation == "trunk" ? "watersprayer" : "fuelsprayer";
      PlayerController.wc.fullStop(true);
      CursorController.cc.deselectItem();
      int locX = ItemsManager.im.getItem(name).dataRef.locX;
      int locY = ItemsManager.im.getItem(name).dataRef.locY;
      string droppedLocation = ItemsManager.im.getItem(name).dataRef.droppedLocation;
      InventoryController.ic.removeItem(name);
      InventoryController.ic.removeItem("lighter");
      string txt1 = GameStrings.getString(GameStrings.actions, "lighter_watersprayer");
      if (name == "watersprayer")
      {
        ItemsManager.im.updateItem("flamethrower_empty", droppedLocation, locX, locY);
        InventoryController.ic.loadItem(ItemsManager.im.getItem("flamethrower_empty"));
        PlayerController.pc.sayLine(txt1);
        this.putAwayOrDropIfTheResultIsTooHeavy("flamethrower_empty");
      }
      else
      {
        string txt2 = txt1 + GameStrings.getString(GameStrings.actions, "flamethrower_ready");
        ItemsManager.im.updateItem("flamethrower", droppedLocation, locX, locY);
        InventoryController.ic.loadItem(ItemsManager.im.getItem("flamethrower"));
        GameDataController.Achievement("S_PYRO");
        PlayerController.pc.sayLine(txt2);
        this.putAwayOrDropIfTheResultIsTooHeavy("flamethrower");
      }
    }
  }

  public void revolverShot(string gunName)
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.rifle_shoot);
    string str = "revolver_";
    int num = int.Parse(gunName.Substring(str.Length)) - 1;
    int locX = ItemsManager.im.getItem(gunName).dataRef.locX;
    int locY = ItemsManager.im.getItem(gunName).dataRef.locY;
    string droppedLocation = ItemsManager.im.getItem(gunName).dataRef.droppedLocation;
    InventoryController.ic.removeItem(gunName);
    ItemsManager.im.updateItem(str + (object) num, droppedLocation, locX, locY);
    InventoryController.ic.loadItem(ItemsManager.im.getItem(str + (object) num));
  }

  public void rifleShot(string gunName, bool boom = true)
  {
    if (boom)
    {
      if (gunName.IndexOf("rifle_s") != -1)
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.rifle_shoot_silenced);
      else
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.rifle_shoot);
    }
    string str = "rifle_";
    if (gunName.IndexOf("rifle_so_") != -1)
      str = "rifle_so_";
    else if (gunName.IndexOf("rifle_o_") != -1)
      str = "rifle_o_";
    else if (gunName.IndexOf("rifle_s_") != -1)
      str = "rifle_s_";
    else if (gunName.IndexOf("rifle_") != -1)
      str = "rifle_";
    int num = int.Parse(gunName.Substring(str.Length)) - 1;
    int locX = ItemsManager.im.getItem(gunName).dataRef.locX;
    int locY = ItemsManager.im.getItem(gunName).dataRef.locY;
    string droppedLocation = ItemsManager.im.getItem(gunName).dataRef.droppedLocation;
    InventoryController.ic.removeItem(gunName);
    ItemsManager.im.updateItem(str + (object) num, droppedLocation, locX, locY);
    InventoryController.ic.loadItem(ItemsManager.im.getItem(str + (object) num));
  }

  private void OnEnable()
  {
  }

  public void removeGroundItem(string itemName)
  {
    GroundItemController[] objectsOfType = UnityEngine.Object.FindObjectsOfType<GroundItemController>();
    for (int index = 0; index < objectsOfType.Length; ++index)
    {
      if (objectsOfType[index].GetComponent<GroundItemController>().itemRef.id == itemName)
        UnityEngine.Object.Destroy((UnityEngine.Object) objectsOfType[index].gameObject);
    }
  }

  public void initGroundAndInv()
  {
    foreach (Component component in UnityEngine.Object.FindObjectsOfType<GroundItemController>())
      UnityEngine.Object.Destroy((UnityEngine.Object) component.gameObject);
    for (int index = 0; index < this.items.Count; ++index)
    {
      if (this.items[index].dataRef.droppedLocation.Equals(SceneManager.GetActiveScene().name))
      {
        Vector2 screen = ScreenControler.gameToScreen(new Vector2((float) this.items[index].dataRef.locX, (float) (this.items[index].dataRef.locY + GroundItemController.yOffset)));
        Vector3 position = new Vector3(screen.x, screen.y, 0.0f);
        position = Camera.main.ScreenToWorldPoint((Vector3) screen);
        MonoBehaviour.print((object) ("CREATING A GROUND ITEM " + this.items[index].id + " i=" + (object) index));
        (UnityEngine.Object.Instantiate(Resources.Load("Prefabs/GroundItem"), position, new Quaternion()) as GameObject).GetComponent<GroundItemController>().init(this.items[index]);
      }
      else if (this.items[index].dataRef.droppedLocation.Equals("inventory"))
        this.inv.GetComponent<InventoryController>().loadItem(this.items[index]);
      else if (this.items[index].dataRef.droppedLocation.Equals("trunk"))
        this.inv.GetComponent<InventoryController>().loadTrunkItem(this.items[index]);
      else if (this.items[index].dataRef.droppedLocation.Equals("chest"))
        this.inv.GetComponent<InventoryController>().loadChestItem(this.items[index]);
    }
  }

  public void fixGroundItems(Vector2 newLoc, Vector2 shift)
  {
    MonoBehaviour.print((object) "FIXING GROUND ITEMS ");
    for (int index = 0; index < this.items.Count; ++index)
    {
      if (this.items[index].dataRef.droppedLocation.Equals(SceneManager.GetActiveScene().name))
      {
        MonoBehaviour.print((object) "FOUND A GROUND ITEM");
        Vector2 screen = ScreenControler.gameToScreen(new Vector2((float) this.items[index].dataRef.locX, (float) this.items[index].dataRef.locY));
        Vector3 vector3 = new Vector3(screen.x, screen.y, 0.0f);
        vector3 = Camera.main.ScreenToWorldPoint((Vector3) screen);
        Vector2 vector2 = new Vector2(vector3.x, vector3.y);
        RaycastHit2D raycastHit2D = Physics2D.Linecast(vector2, vector2, LayerMask.GetMask("obstacleLayer"));
        MonoBehaviour.print((object) raycastHit2D.collider);
        if ((UnityEngine.Object) raycastHit2D.collider != (UnityEngine.Object) null)
        {
          MonoBehaviour.print((object) "AND WE MOVE IT");
          this.items[index].dataRef.locX = (int) newLoc.x + (int) UnityEngine.Random.Range(-shift.x, shift.x);
          this.items[index].dataRef.locY = (int) newLoc.y + (int) UnityEngine.Random.Range(-shift.y, shift.y);
        }
      }
    }
  }

  public void updateItem(string id, string droppedLocation, int locX, int locY)
  {
    Item obj = (Item) null;
    for (int index = 0; index < this.items.Count; ++index)
    {
      if (this.items[index].id.Equals(id))
      {
        obj = this.items[index];
        break;
      }
    }
    if (obj != null)
    {
      obj.dataRef.droppedLocation = droppedLocation;
      obj.dataRef.locX = locX;
      obj.dataRef.locY = locY;
    }
    JournalTexts.pickTexts(GameDataController.gd.getCurrentDay());
  }

  public void initItem(
    string name,
    float weight,
    string soundName,
    List<ItemInteraction> usablesI = null,
    List<ItemInteraction> usablesG = null,
    int animationFrames = 0,
    int animationDelay = 0,
    bool hasExamineScreen = false,
    int var1 = 0,
    int var2 = 0,
    int var3 = 0,
    int var4 = 0,
    List<string> texts = null,
    int wid = 120,
    int xShift = 0,
    int yShift = 0,
    float r1 = 0.0f,
    float g1 = 0.0f,
    float b1 = 0.0f,
    float a1 = 1f,
    float r2 = 1f,
    float g2 = 1f,
    float b2 = 1f,
    float a2 = 1f,
    bool cycle = false,
    ExamineSprite.Delegate lookAction = null,
    string soundL = "",
    bool actionOnLook = true)
  {
    Item obj = new Item();
    obj.id = name;
    obj.weight = weight;
    obj.examineCycleSprites = cycle;
    obj.usableItemsGround = usablesG;
    obj.usableItemsInventory = usablesI;
    if (texts != null)
    {
      obj.textWidth = wid;
      obj.examineTexts = texts;
      obj.textColor1 = new Color(r1, g1, b1, a1);
      obj.textColor2 = new Color(r2, g2, b2, a2);
      obj.textShiftX = xShift;
      obj.textShiftY = yShift;
    }
    if (soundL != string.Empty)
      obj.soundLoop = Resources.Load<AudioClip>("Sounds/Items/" + soundL);
    obj.sound = Resources.Load<AudioClip>("Sounds/Items/" + soundName);
    obj.groundSprite = Resources.Load<Sprite>("Bitmaps/Items/" + name + "_ground");
    obj.inventorySprite = Resources.Load<Sprite>("Bitmaps/Items/" + name + "_inv");
    if (hasExamineScreen)
    {
      obj.examineSprite = Resources.Load<Sprite>("Bitmaps/Items/" + name + "_examine");
      obj.lookAction = lookAction;
      obj.actionOnLook = actionOnLook;
      if (var1 != 0)
        obj.examineSprite_1 = Resources.Load<Sprite>("Bitmaps/Items/" + name + "_examine_1_" + (object) var1);
      if (var2 != 0)
        obj.examineSprite_2 = Resources.Load<Sprite>("Bitmaps/Items/" + name + "_examine_2_" + (object) var2);
      if (var3 != 0)
        obj.examineSprite_3 = Resources.Load<Sprite>("Bitmaps/Items/" + name + "_examine_3_" + (object) var3);
      if (var4 != 0)
        obj.examineSprite_4 = Resources.Load<Sprite>("Bitmaps/Items/" + name + "_examine_4_" + (object) var4);
    }
    if (animationFrames > 0)
    {
      if (animationFrames >= 1)
        obj.groundSprite_1 = Resources.Load<Sprite>("Bitmaps/Items/" + name + "_ground_1");
      if (animationFrames >= 2)
        obj.groundSprite_2 = Resources.Load<Sprite>("Bitmaps/Items/" + name + "_ground_2");
      if (animationFrames >= 3)
        obj.groundSprite_3 = Resources.Load<Sprite>("Bitmaps/Items/" + name + "_ground_3");
      if (animationFrames >= 4)
        obj.groundSprite_4 = Resources.Load<Sprite>("Bitmaps/Items/" + name + "_ground_4");
      if (animationFrames >= 5)
        obj.groundSprite_5 = Resources.Load<Sprite>("Bitmaps/Items/" + name + "_ground_5");
      obj.animationDelay = animationDelay;
    }
    this.items.Add(obj);
  }

  public void initItems()
  {
    for (int index = 0; index < this.items.Count; ++index)
      this.items[index].dataRef = GameDataController.gd.getItemData(this.items[index].id);
    int num1 = 1;
    int num2 = 1;
    int num3 = 1;
    if (GameDataController.gd.getObjectiveDetail("bug_type") == 1)
    {
      num1 = 1;
      num2 = 1;
      num3 = 1;
    }
    if (GameDataController.gd.getObjectiveDetail("bug_type") == 2)
    {
      num1 = 2;
      num2 = 2;
      num3 = 1;
    }
    if (GameDataController.gd.getObjectiveDetail("bug_type") == 3)
    {
      num1 = 2;
      num2 = 2;
      num3 = 2;
    }
    if (GameDataController.gd.getObjectiveDetail("bug_type") == 4)
    {
      num1 = 1;
      num2 = 2;
      num3 = 2;
    }
    if (GameDataController.gd.getObjectiveDetail("bug_type") == 5)
    {
      num1 = 2;
      num2 = 1;
      num3 = 1;
    }
    if (GameDataController.gd.getObjectiveDetail("bug_type") == 6)
    {
      num1 = 1;
      num2 = 1;
      num3 = 2;
    }
    if (GameDataController.gd.getObjectiveDetail("bug_type") == 7)
    {
      num1 = 1;
      num2 = 2;
      num3 = 1;
    }
    if (GameDataController.gd.getObjectiveDetail("bug_type") == 8)
    {
      num1 = 2;
      num2 = 1;
      num3 = 2;
    }
    ItemsManager.im.getItem("bug").examineSprite_1 = Resources.Load<Sprite>("Bitmaps/Items/bug_examine_1_" + (object) num1);
    ItemsManager.im.getItem("bug").examineSprite_2 = Resources.Load<Sprite>("Bitmaps/Items/bug_examine_2_" + (object) num2);
    ItemsManager.im.getItem("bug").examineSprite_4 = Resources.Load<Sprite>("Bitmaps/Items/bug_examine_4_" + (object) num3);
    string str1 = ((float) GameDataController.gd.getObjectiveDetail("gas_dens") / 100f).ToString();
    if ((double) GameDataController.gd.getObjectiveDetail("gas_dens") / 100.0 == 1.6)
      str1 += "0";
    ItemsManager.im.getItem("drone").examineTexts = new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "drone_1") + GameDataController.gd.getObjectiveDetail("gas_ph").ToString() + GameStrings.getString(GameStrings.world_labels, "drone_2") + str1 + GameStrings.getString(GameStrings.world_labels, "drone_3")
    };
    string str2 = GameStrings.getString(GameStrings.world_labels, "manifest_start") + "^ 1. " + GameStrings.getString(GameStrings.world_labels, "airplane_cargo_" + (object) GameDataController.gd.getObjectiveDetail("plane_crate_1")) + "^ 2. " + GameStrings.getString(GameStrings.world_labels, "airplane_cargo_" + (object) GameDataController.gd.getObjectiveDetail("plane_crate_2")) + "^ 3. " + GameStrings.getString(GameStrings.world_labels, "airplane_cargo_" + (object) GameDataController.gd.getObjectiveDetail("plane_crate_3")) + "^ 4. " + GameStrings.getString(GameStrings.world_labels, "airplane_cargo_" + (object) GameDataController.gd.getObjectiveDetail("plane_crate_4")) + "^ 5. " + GameStrings.getString(GameStrings.world_labels, "airplane_cargo_" + (object) GameDataController.gd.getObjectiveDetail("plane_crate_5")) + "^ 6. " + GameStrings.getString(GameStrings.world_labels, "airplane_cargo_" + (object) GameDataController.gd.getObjectiveDetail("plane_crate_6")) + "^ 7. " + GameStrings.getString(GameStrings.world_labels, "airplane_cargo_" + (object) GameDataController.gd.getObjectiveDetail("plane_crate_7")) + "^ ^" + GameStrings.getString(GameStrings.world_labels, "manifest_end");
    ItemsManager.im.getItem("manifest").examineTexts = new List<string>()
    {
      str2
    };
    string str3 = "SP-";
    string str4 = GameDataController.gd.getObjective("previous_disc_barry") || GameDataController.gd.getObjective("previous_disc_cody") ? str3 + "2" : str3 + "1";
    string str5 = GameDataController.gd.getObjectiveDetail("day_2_threat") != 1 ? str4 + (GameDataController.gd.getObjectiveDetail("day_1_threat") + 1).ToString() : str4 + (GameDataController.gd.getObjectiveDetail("day_1_threat") + 5).ToString();
    string str6 = (GameDataController.gd.getObjectiveDetail("day_4_threat") != 1 ? str5 + (GameDataController.gd.getObjectiveDetail("day_3_threat") + 2).ToString() : str5 + (GameDataController.gd.getObjectiveDetail("day_3_threat") + 7).ToString()) + "8";
    ItemsManager.im.getItem("sidereal_secrets").examineTexts[1] = GameStrings.getString(GameStrings.world_labels, "sidereal_secrets_2");
    ItemsManager.im.getItem("sidereal_secrets").examineTexts[1] = ItemsManager.im.getItem("sidereal_secrets").examineTexts[1].Replace("SP-12119", string.Empty + str6);
  }

  public static void exmineItem(Item itemRef)
  {
    ExamineSprite.es.textField.shift.x = (float) itemRef.textShiftX;
    ExamineSprite.es.textField.shift.y = (float) itemRef.textShiftY;
    List<string> _pages = new List<string>();
    if (itemRef.examineTexts != null)
    {
      for (int index = 0; index < itemRef.examineTexts.Count; ++index)
        _pages.Add(itemRef.examineTexts[index]);
    }
    ExamineSprite.es.readyText(_pages, itemRef.textWidth, itemRef.textColor1.r, itemRef.textColor1.g, itemRef.textColor1.b, itemRef.textColor2.r, itemRef.textColor2.g, itemRef.textColor2.b, itemRef.textColor2.a);
    ExamineSprite.es.cycleSprites = itemRef.examineCycleSprites;
    ExamineSprite.es.show(itemRef.examineSprite, itemRef.examineSprite_1, itemRef.examineSprite_2, itemRef.examineSprite_3, itemRef.examineSprite_4, itemRef.lookAction, itemRef.actionOnLook);
  }

  public Item getItem(string name)
  {
    for (int index = 0; index < this.items.Count; ++index)
    {
      if (this.items[index].dataRef.id.Equals(name))
        return this.items[index];
    }
    return (Item) null;
  }
}
