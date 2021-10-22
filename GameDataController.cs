// Decompiled with JetBrains decompiler
// Type: GameDataController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using Steamworks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataController : MonoBehaviour
{
  public static GameDataController gd;
  [SerializeField]
  public static PersistentData persistentData;
  public PersistentData persistentDataView;
  public static string VERSION = "v1.2.1";
  public static bool STEAM = true;
  public static bool GOG;
  public static bool KART;
  public static string AUTOSAVE = "autosave0";
  public static string CONTINUE = "autosave_continue";
  public static string CHAPTER_1_COMPLETE_AUTOSAVE = "chapter_1_autosave";
  public static string CHAPTER_2_COMPLETE_AUTOSAVE = "chapter_2_autosave";
  public static string CHAPTER_3_COMPLETE_AUTOSAVE = "chapter_3_autosave";
  public static string CHAPTER_4_COMPLETE_AUTOSAVE = "chapter_4_autosave";
  public string equipped = string.Empty;
  public List<ItemData> items;
  public List<Objective> objectives;
  public List<Objective> journals;
  public List<Objective> visited;
  public int gameTime;
  public int timeLimit;
  public int traveledTime;
  public int workedTime;
  public string location;
  public string usedSpawner;
  public int currentX;
  public int currentY;
  public int previousX;
  public int previousY;
  public string previousLocation;
  public string finishingLocation;
  public static bool wantSave;
  public string journalEntries = string.Empty;
  public string newJournalEntries = string.Empty;
  public static int MAX_FUEL = 350;

  private void Awake()
  {
    if ((UnityEngine.Object) GameDataController.gd == (UnityEngine.Object) null)
    {
      UnityEngine.Object.DontDestroyOnLoad((UnityEngine.Object) this.gameObject);
      GameDataController.gd = this;
    }
    else
    {
      if (!((UnityEngine.Object) GameDataController.gd != (UnityEngine.Object) this))
        return;
      UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
    }
  }

  public static void Achievement(string id)
  {
    if (GameDataController.persistentData.achievements.Find((Predicate<Objective>) (x => x.id == id)) != null)
    {
      GameDataController.persistentData.achievements.Find((Predicate<Objective>) (x => x.id == id)).state = true;
      GameDataController.gd.PersistentSave();
    }
    else
      Debug.LogWarning((object) "ACHIEVEMENT ID NOT FOUND IN PERSISTENT DATA");
    if (GameDataController.STEAM)
    {
      try
      {
        SteamUserStats.SetAchievement(id);
        SteamUserStats.StoreStats();
      }
      catch (InvalidOperationException ex)
      {
        Debug.LogError((object) ex.ToString());
      }
    }
    if (!GameDataController.GOG || !(bool) (UnityEngine.Object) GogGalaxyManager.Instance || !(bool) (UnityEngine.Object) GogGalaxyManager.Instance.StatsAndAchievements)
      return;
    GogGalaxyManager.Instance.StatsAndAchievements.SetAchievement(id);
  }

  private void Start()
  {
    if (GameDataController.GOG)
      GameDataController.VERSION += "-G";
    if (GameDataController.KART)
      GameDataController.VERSION += "-K";
    if (!PlayerPrefs.HasKey("stati"))
    {
      PlayerPrefs.SetInt("stati", 80);
      PlayerPrefs.SetInt("music", 80);
      PlayerPrefs.SetInt("sound", 100);
      PlayerPrefs.SetFloat("textSpeed", 0.0425f);
      PlayerPrefs.SetString("lang", GameStrings.Language.EN.ToString());
      PlayerPrefs.Save();
    }
    GameDataController.persistentData = new PersistentData();
    this.initPersistantAchieves();
    this.persistentDataView = new PersistentData();
    this.newGame();
    if (!GameDataController.GOG)
      return;
    this.InvokeRepeating("updateAchievements", 1f, 5f);
  }

  private void updateAchievements()
  {
    if (!(bool) (UnityEngine.Object) GogGalaxyManager.Instance || !GogGalaxyManager.Instance.IsSignedIn() || !(bool) (UnityEngine.Object) GogGalaxyManager.Instance.StatsAndAchievements)
      return;
    for (int index = 0; index < GameDataController.persistentData.achievements.Count; ++index)
    {
      if (GameDataController.persistentData.achievements[index].state && !GogGalaxyManager.Instance.StatsAndAchievements.GetAchievement(GameDataController.persistentData.achievements[index].id))
        GameDataController.Achievement(GameDataController.persistentData.achievements[index].id);
    }
  }

  private void Update() => this.persistentDataView = GameDataController.persistentData;

  private int getRandomHash(int len = 9)
  {
    List<string> stringList = new List<string>();
    for (int index = 1; index <= len; ++index)
      stringList.Add(index.ToString());
    for (int index1 = 0; index1 < 20; ++index1)
    {
      int index2 = UnityEngine.Random.Range(0, stringList.Count);
      stringList.Add(stringList[index2]);
      stringList.RemoveAt(index2);
    }
    string empty = string.Empty;
    for (int index = 0; index < stringList.Count; ++index)
      empty += stringList[index];
    return int.Parse(empty);
  }

  public void newGame()
  {
    this.PersistentLoad();
    if ((UnityEngine.Object) InventoryController.ic != (UnityEngine.Object) null && this.items != null)
      InventoryController.ic.clearInventory();
    this.items = new List<ItemData>();
    this.objectives = new List<Objective>();
    this.journals = new List<Objective>();
    this.visited = new List<Objective>();
    this.gameTime = 420;
    this.timeLimit = 1200;
    this.journalEntries = string.Empty;
    this.newJournalEntries = "1";
    this.traveledTime = 0;
    this.workedTime = 0;
    this.items.Add(new ItemData("key1", "nowhere", 1, 1));
    this.items.Add(new ItemData("key2", "nowhere", 1, 2));
    this.items.Add(new ItemData("key3", "nowhere", 1, 3));
    this.items.Add(new ItemData("key4", "nowhere", 1, 3));
    this.items.Add(new ItemData("pipe", "nowhere", 1, 4));
    this.items.Add(new ItemData("sonic", "nowhere", 1, 2));
    this.items.Add(new ItemData("sonic2", "nowhere", 1, 2));
    this.items.Add(new ItemData("sonic_remote", "nowhere", 1, 2));
    this.items.Add(new ItemData("pest_note", "nowhere", 3, 1));
    this.items.Add(new ItemData("gas_note", "nowhere", 1, 2));
    this.items.Add(new ItemData("spider_note", "nowhere", 1, 2));
    this.items.Add(new ItemData("pest1", "nowhere", 1, 2));
    this.items.Add(new ItemData("pest2", "nowhere", 1, 2));
    this.items.Add(new ItemData("paperclip", "nowhere", 2, 1));
    this.items.Add(new ItemData("invoices", "nowhere", 2, 2));
    this.items.Add(new ItemData("crowbar", "nowhere", 2, 4));
    this.items.Add(new ItemData("straw", "nowhere", 0, 0));
    this.items.Add(new ItemData("window_foil1", "nowhere", 3, 1));
    this.items.Add(new ItemData("window_foil2", "nowhere", 0, 0));
    this.items.Add(new ItemData("window_foil3", "nowhere", 0, 0));
    this.items.Add(new ItemData("window_bars1", "nowhere", 4, 2));
    this.items.Add(new ItemData("window_bars2", "nowhere", 4, 3));
    this.items.Add(new ItemData("window_bars3", "nowhere", 4, 4));
    this.items.Add(new ItemData("window_net1", "nowhere", 3, 3));
    this.items.Add(new ItemData("window_net2", "nowhere", 0, 0));
    this.items.Add(new ItemData("window_net3", "nowhere", 0, 0));
    this.items.Add(new ItemData("planks1", "nowhere", 4, 1));
    this.items.Add(new ItemData("planks2", "nowhere", 4, 2));
    this.items.Add(new ItemData("planks3", "nowhere", 4, 3));
    this.items.Add(new ItemData("planks4", "nowhere", 4, 4));
    this.items.Add(new ItemData("planks5", "nowhere", 0, 0));
    this.items.Add(new ItemData("nails1", "nowhere", 4, 1));
    this.items.Add(new ItemData("nails2", "nowhere", 4, 2));
    this.items.Add(new ItemData("nails3", "nowhere", 4, 3));
    this.items.Add(new ItemData("nails4", "nowhere", 4, 4));
    this.items.Add(new ItemData("nails5", "nowhere", 0, 0));
    this.items.Add(new ItemData("ducttape", "nowhere", 3, 3));
    this.items.Add(new ItemData("canister_full", "nowhere", 2, 1));
    this.items.Add(new ItemData("canister2_full", "nowhere", 2, 1));
    this.items.Add(new ItemData("bug", "nowhere", 4, 1));
    this.items.Add(new ItemData("hammer", "nowhere", 1, 2));
    this.items.Add(new ItemData("hammer_handle", "nowhere", 4, 2));
    this.items.Add(new ItemData("broken_hammer", "chest", 1, 1));
    this.items.Add(new ItemData("canister2_empty", "nowhere", 3, 4));
    this.items.Add(new ItemData("canister_empty", "nowhere", 2, 4));
    this.items.Add(new ItemData("lighter", "nowhere", 4, 3));
    this.items.Add(new ItemData("watersprayer", "nowhere", 4, 4));
    this.items.Add(new ItemData("pestsprayer", "nowhere", 4, 4));
    this.items.Add(new ItemData("fuelsprayer", "nowhere", 4, 4));
    this.items.Add(new ItemData("flamethrower", "nowhere", 4, 4));
    this.items.Add(new ItemData("flamethrower_empty", "nowhere", 3, 4));
    this.items.Add(new ItemData("wrench", "nowhere", 4, 5));
    this.items.Add(new ItemData("wad_of_cash", "nowhere", 1, 1));
    this.items.Add(new ItemData("chem_glass", "nowhere", 0, 0));
    this.items.Add(new ItemData("chem_glass_1", "nowhere", 0, 0));
    this.items.Add(new ItemData("chem_glass_2", "nowhere", 0, 0));
    this.items.Add(new ItemData("chem_glass_3", "nowhere", 0, 0));
    this.items.Add(new ItemData("chem_glass_12", "nowhere", 0, 0));
    this.items.Add(new ItemData("chem_glass_13", "nowhere", 0, 0));
    this.items.Add(new ItemData("chem_glass_23", "nowhere", 0, 0));
    this.items.Add(new ItemData("drone", "nowhere", 0, 0));
    this.items.Add(new ItemData("towel_1", "nowhere", 0, 0));
    this.items.Add(new ItemData("towel_2", "nowhere", 0, 0));
    this.items.Add(new ItemData("chemsuit_dmg_dmg", "nowhere", 0, 0));
    this.items.Add(new ItemData("chemsuit_rep_dmg", "nowhere", 0, 0));
    this.items.Add(new ItemData("chemsuit_dmg_rep", "nowhere", 0, 0));
    this.items.Add(new ItemData("chemsuit_rep_rep", "nowhere", 0, 0));
    this.items.Add(new ItemData("mask_filter", "nowhere", 0, 0));
    this.items.Add(new ItemData("rifle_0", "nowhere", 0, 0));
    this.items.Add(new ItemData("rifle_1", "nowhere", 1, 1));
    this.items.Add(new ItemData("rifle_2", "nowhere", 4, 3));
    this.items.Add(new ItemData("rifle_3", "nowhere", 0, 0));
    this.items.Add(new ItemData("rifle_4", "nowhere", 1, 1));
    this.items.Add(new ItemData("rifle_5", "nowhere", 0, 0));
    this.items.Add(new ItemData("rifle_6", "nowhere", 0, 0));
    this.items.Add(new ItemData("rifle_s_0", "nowhere", 0, 0));
    this.items.Add(new ItemData("rifle_s_1", "nowhere", 1, 1));
    this.items.Add(new ItemData("rifle_s_2", "nowhere", 0, 0));
    this.items.Add(new ItemData("rifle_s_3", "nowhere", 0, 0));
    this.items.Add(new ItemData("rifle_s_4", "nowhere", 4, 3));
    this.items.Add(new ItemData("rifle_s_5", "nowhere", 0, 0));
    this.items.Add(new ItemData("rifle_s_6", "nowhere", 0, 0));
    this.items.Add(new ItemData("rifle_o_0", "nowhere", 0, 0));
    this.items.Add(new ItemData("rifle_o_1", "nowhere", 1, 1));
    this.items.Add(new ItemData("rifle_o_2", "nowhere", 0, 0));
    this.items.Add(new ItemData("rifle_o_3", "nowhere", 0, 0));
    this.items.Add(new ItemData("rifle_o_4", "nowhere", 4, 3));
    this.items.Add(new ItemData("rifle_o_5", "nowhere", 2, 3));
    this.items.Add(new ItemData("rifle_o_6", "nowhere", 0, 0));
    this.items.Add(new ItemData("rifle_so_0", "nowhere", 0, 0));
    this.items.Add(new ItemData("rifle_so_1", "nowhere", 1, 1));
    this.items.Add(new ItemData("rifle_so_2", "nowhere", 0, 0));
    this.items.Add(new ItemData("rifle_so_3", "nowhere", 0, 0));
    this.items.Add(new ItemData("rifle_so_4", "nowhere", 1, 1));
    this.items.Add(new ItemData("rifle_so_5", "nowhere", 0, 0));
    this.items.Add(new ItemData("rifle_so_6", "nowhere", 3, 3));
    this.items.Add(new ItemData("bear_trap_1b", "nowhere", 1, 3));
    this.items.Add(new ItemData("bear_trap_2b", "nowhere", 2, 3));
    this.items.Add(new ItemData("bear_trap_1", "nowhere", 1, 3));
    this.items.Add(new ItemData("bear_trap_2", "nowhere", 2, 3));
    this.items.Add(new ItemData("bear_trap_3", "nowhere", 2, 3));
    this.items.Add(new ItemData("bear_trap_4", "nowhere", 2, 3));
    this.items.Add(new ItemData("rock", "LocationGasstation2", 175, 47));
    this.items.Add(new ItemData("rock2", "SiderealF3C", 97, 50));
    this.items.Add(new ItemData("ignitioncoil", "nowhere", 4, 2));
    this.items.Add(new ItemData("wheel", "nowhere", 4, 3));
    this.items.Add(new ItemData("car_battery", "nowhere", 4, 4));
    this.items.Add(new ItemData("spiderpest1", "nowhere", 0, 0));
    this.items.Add(new ItemData("spiderpest2", "nowhere", 0, 0));
    this.items.Add(new ItemData("spiderpest3", "nowhere", 0, 0));
    this.items.Add(new ItemData("spiderpest4", "nowhere", 0, 0));
    this.items.Add(new ItemData("coat1", "nowhere", 1, 2));
    this.items.Add(new ItemData("coat2", "nowhere", 2, 4));
    this.items.Add(new ItemData("coat3", "nowhere", 3, 4));
    this.items.Add(new ItemData("coat4", "nowhere", 4, 4));
    this.items.Add(new ItemData("sheet", "nowhere", 4, 3));
    this.items.Add(new ItemData("shovel", "nowhere", 3, 3));
    this.items.Add(new ItemData("hose", "nowhere", 0, 0));
    this.items.Add(new ItemData("gas_tank", "nowhere", 2, 4));
    this.items.Add(new ItemData("locket", "nowhere", 4, 4));
    this.items.Add(new ItemData("foodcan", "nowhere", 4, 4));
    this.items.Add(new ItemData("foodcanopen", "nowhere", 4, 4));
    this.items.Add(new ItemData("screwdriver", "nowhere", 1, 5));
    this.items.Add(new ItemData("canopener", "nowhere", 2, 5));
    this.items.Add(new ItemData("knife", "nowhere", 3, 5));
    this.items.Add(new ItemData("hook", "nowhere", 1, 5));
    this.items.Add(new ItemData("rope", "nowhere", 3, 2));
    this.items.Add(new ItemData("flag", "nowhere", 2, 3));
    this.items.Add(new ItemData("ropehook", "nowhere", 3, 4));
    this.items.Add(new ItemData("deadbird", "nowhere", 3, 2));
    this.items.Add(new ItemData("charcoal", "nowhere", 2, 3));
    this.items.Add(new ItemData("charcoal_empty", "nowhere", 4, 2));
    this.items.Add(new ItemData("generator", "nowhere", 0, 0));
    this.items.Add(new ItemData("generator2", "nowhere", 0, 0));
    this.items.Add(new ItemData("blanket", "nowhere", 3, 3));
    this.items.Add(new ItemData("blanketb", "nowhere", 3, 1));
    this.items.Add(new ItemData("thermalb", "nowhere", 4, 3));
    this.items.Add(new ItemData("gasheater", "nowhere", 4, 3));
    this.items.Add(new ItemData("gasheater_empty", "LocationRestaurant4", 56, 27));
    this.items.Add(new ItemData("heater", "nowhere", 55, 45));
    this.items.Add(new ItemData("heater_broken", "nowhere", 55, 45));
    this.items.Add(new ItemData("ac", "nowhere", 3, 2));
    this.items.Add(new ItemData("ext_cord", "nowhere", 2, 3));
    this.items.Add(new ItemData("ext_cord_place", "nowhere", 1, 2));
    this.items.Add(new ItemData("ac_cord", "nowhere", 0, 0));
    this.items.Add(new ItemData("fan", "nowhere", 2, 2));
    this.items.Add(new ItemData("fan_broken", "nowhere", 3, 2));
    this.items.Add(new ItemData("heat_absorber1", "nowhere", 0, 0));
    this.items.Add(new ItemData("heat_absorber2", "nowhere", 0, 0));
    this.items.Add(new ItemData("heat_absorber3", "nowhere", 0, 0));
    this.items.Add(new ItemData("heat_absorber1A", "nowhere", 1, 1));
    this.items.Add(new ItemData("heat_absorber2A", "nowhere", 1, 2));
    this.items.Add(new ItemData("heat_absorber3A", "nowhere", 1, 3));
    this.items.Add(new ItemData("water1", "nowhere", 1, 1));
    this.items.Add(new ItemData("water2", "nowhere", 0, 0));
    this.items.Add(new ItemData("water3", "nowhere", 0, 0));
    this.items.Add(new ItemData("water4", "nowhere", 0, 0));
    this.items.Add(new ItemData("sledgehammer", "nowhere", 1, 1));
    this.items.Add(new ItemData("sledge_head", "nowhere", 1, 1));
    this.items.Add(new ItemData("sledge_handle", "nowhere", 1, 1));
    this.items.Add(new ItemData("puzzle_cable", "nowhere", 1, 1));
    this.items.Add(new ItemData("fire_hose", "nowhere", 1, 1));
    this.items.Add(new ItemData("sidereal_id", "nowhere", 4, 4));
    this.items.Add(new ItemData("sidereal_id_key", "nowhere", 1, 1));
    this.items.Add(new ItemData("sidereal_docs", "nowhere", 1, 1));
    this.items.Add(new ItemData("sidereal_xero", "nowhere", 1, 1));
    this.items.Add(new ItemData("sidereal_secrets", "nowhere", 1, 1));
    this.items.Add(new ItemData("revolver_0", "nowhere", 1, 1));
    this.items.Add(new ItemData("revolver_1", "nowhere", 1, 1));
    this.items.Add(new ItemData("revolver_2", "nowhere", 1, 1));
    this.items.Add(new ItemData("revolver_3", "nowhere", 1, 1));
    this.items.Add(new ItemData("revolver_4", "nowhere", 1, 5));
    this.items.Add(new ItemData("revolver_5", "nowhere", 1, 1));
    this.items.Add(new ItemData("revolver_6", "nowhere", 1, 1));
    this.items.Add(new ItemData("gun_ammo", "nowhere", 1, 1));
    this.items.Add(new ItemData("rifle_ammo", "nowhere", 3, 4));
    this.items.Add(new ItemData("scope", "nowhere", 1, 1));
    this.items.Add(new ItemData("silencer", "nowhere", 105, 40));
    this.items.Add(new ItemData("whiskey", "nowhere", 1, 3));
    this.items.Add(new ItemData("maggot", "nowhere", 1, 1));
    this.items.Add(new ItemData("oil", "nowhere", 1, 1));
    this.items.Add(new ItemData("poison", "nowhere", 1, 2));
    this.items.Add(new ItemData("food_bag", "nowhere", 0, 0));
    this.items.Add(new ItemData("gloves", "nowhere", 1, 1));
    this.items.Add(new ItemData("welder", "nowhere", 1, 1));
    this.items.Add(new ItemData("mixer_glass", "nowhere", 0, 0));
    this.items.Add(new ItemData("pill_half", "nowhere", 0, 0));
    this.items.Add(new ItemData("pills", "nowhere", 1, 1));
    this.items.Add(new ItemData("catalyst", "nowhere", 2, 1));
    this.items.Add(new ItemData("mixer_pills_note", "nowhere", 2, 4));
    this.items.Add(new ItemData("mixer_catalyst_note", "nowhere", 2, 3));
    this.items.Add(new ItemData("outpost_card", "nowhere", 4, 3));
    this.items.Add(new ItemData("moon_card", "nowhere", 4, 3));
    this.items.Add(new ItemData("remote", "nowhere", 3, 2));
    this.items.Add(new ItemData("batteries", "nowhere", 2, 3));
    this.items.Add(new ItemData("gluegun", "nowhere", 2, 3));
    this.items.Add(new ItemData("gluegun_powered", "nowhere", 2, 3));
    this.items.Add(new ItemData("fingerprint", "nowhere", 3, 3));
    this.items.Add(new ItemData("vials1", "nowhere", 3, 3));
    this.items.Add(new ItemData("vials2", "nowhere", 3, 3));
    this.items.Add(new ItemData("engine_calibrator", "nowhere", 4, 1));
    this.items.Add(new ItemData("lioh_filter", "nowhere", 4, 2));
    this.items.Add(new ItemData("metal_slab", "nowhere", 3, 4));
    this.items.Add(new ItemData("nav_chip", "nowhere", 1, 4));
    this.items.Add(new ItemData("air_tanks", "nowhere", 2, 4));
    this.items.Add(new ItemData("transmission_belt", "nowhere", 2, 4));
    this.items.Add(new ItemData("duplexer", "nowhere", 2, 4));
    this.items.Add(new ItemData("noodles", "nowhere", 2, 4));
    this.items.Add(new ItemData("voltmeter", "nowhere", 2, 4));
    this.items.Add(new ItemData("gasket", "nowhere", 2, 4));
    this.items.Add(new ItemData("nuts_and_bolts", "nowhere", 2, 4));
    this.items.Add(new ItemData("wires", "nowhere", 2, 4));
    this.items.Add(new ItemData("wire", "nowhere", 4, 4));
    this.items.Add(new ItemData("manifest", "nowhere", 2, 4));
    this.items.Add(new ItemData("broom", "nowhere", 2, 4));
    this.items.Add(new ItemData("stormcatcher1", "nowhere", 1, 4));
    this.items.Add(new ItemData("stormcatcher2", "nowhere", 2, 4));
    this.items.Add(new ItemData("stormcatcher3", "nowhere", 2, 4));
    this.items.Add(new ItemData("disc1", "nowhere", 2, 4));
    this.items.Add(new ItemData("disc2", "nowhere", 2, 5));
    this.items.Add(new ItemData("bandage", "nowhere", 2, 4));
    this.items.Add(new ItemData("finger", "nowhere", 2, 3));
    this.items.Add(new ItemData("cate_note", "nowhere", 2, 3));
    this.items.Add(new ItemData("tarpaulin", "nowhere", 2, 3));
    this.items.Add(new ItemData("board1", "nowhere", 1, 1));
    this.items.Add(new ItemData("board2", "nowhere", 2, 1));
    this.items.Add(new ItemData("board3", "nowhere", 3, 1));
    this.objectives.Add(new Objective("cody_warned", false));
    this.objectives.Add(new Objective("barry_warned", false));
    this.objectives.Add(new Objective("previous_disc_barry", GameDataController.persistentData.disc_barry));
    this.objectives.Add(new Objective("previous_disc_cody", GameDataController.persistentData.disc_cody));
    this.objectives.Add(new Objective("moonfall_progress_1", false));
    this.objectives.Add(new Objective("moonfall_progress_2", false));
    this.objectives.Add(new Objective("moonfall_progress_3", false));
    this.objectives.Add(new Objective("moonfall_progress_4", false));
    this.objectives.Add(new Objective("day_1_threat", false, 1));
    this.objectives.Add(new Objective("day_2_threat", false));
    this.objectives.Add(new Objective("day_3_threat", false));
    this.objectives.Add(new Objective("day_4_threat", false));
    this.objectives.Add(new Objective("gas_ph", false, UnityEngine.Random.Range(0, 8)));
    this.objectives.Add(new Objective("spiders_type", false, UnityEngine.Random.Range(0, 4)));
    this.objectives.Add(new Objective("journal_page", false));
    this.objectives.Add(new Objective("car_travel", false));
    int _detail;
    do
    {
      _detail = UnityEngine.Random.Range(159, 164);
    }
    while (_detail == 161);
    this.objectives.Add(new Objective("chitchat", false, -20));
    this.objectives.Add(new Objective("chitchat_cate", false, this.getRandomHash()));
    this.objectives.Add(new Objective("chitchat_cate_cody", false, int.Parse(this.getRandomHash(7).ToString().Insert(2, "8").Insert(3, "9"))));
    this.objectives.Add(new Objective("chitchat_cate_barry", false, this.getRandomHash()));
    this.objectives.Add(new Objective("chitchat_cate_cody_barry", false, this.getRandomHash()));
    this.objectives.Add(new Objective("chitchat_cate_cody_deadbarry", false, this.getRandomHash()));
    this.objectives.Add(new Objective("chitchat_cate_barry_deadcody", false, this.getRandomHash()));
    this.objectives.Add(new Objective("gas_dens", false, _detail));
    this.objectives.Add(new Objective("drone_taken", false));
    this.objectives.Add(new Objective("towel_1_taken", false));
    this.objectives.Add(new Objective("towel_2_taken", false));
    this.objectives.Add(new Objective("towel_1_at_door", false));
    this.objectives.Add(new Objective("towel_2_at_door", false));
    this.objectives.Add(new Objective("dream_day_1_started", false));
    this.objectives.Add(new Objective("dream_day_1_window_broken", false));
    this.objectives.Add(new Objective("dream_day_2_started", false));
    this.objectives.Add(new Objective("dream_day_2_window_broken", false));
    this.objectives.Add(new Objective("dream_day_2_awake", false));
    this.objectives.Add(new Objective("dream_day_3_started", false));
    this.objectives.Add(new Objective("dream_day_3b_started", false));
    this.objectives.Add(new Objective("dream_day_3_window_broken", false));
    this.objectives.Add(new Objective("dream_day_3_awake", false));
    this.objectives.Add(new Objective("dream_day_4_started", false));
    this.objectives.Add(new Objective("dream_day_4_door_open", false));
    this.objectives.Add(new Objective("dream_day_4_awake", false));
    this.objectives.Add(new Objective("day_2_hatch_fallen", false));
    this.objectives.Add(new Objective("tent_awake", false));
    this.objectives.Add(new Objective("tent_backpack_taken", false));
    this.objectives.Add(new Objective("tent_distance_triggered", false));
    this.objectives.Add(new Objective("tent_distance_checked", false));
    this.objectives.Add(new Objective("intro_desert_walked", false));
    this.objectives.Add(new Objective("tutorial_door_opened", false));
    this.objectives.Add(new Objective("tutorial_hammer_taken", false));
    this.objectives.Add(new Objective("tutorial_handle_taken", false));
    this.objectives.Add(new Objective("tutorial_wall_smashed", false));
    this.objectives.Add(new Objective("wall_encountered", false));
    this.objectives.Add(new Objective("run_hint", false));
    this.objectives.Add(new Objective("location01_door2_locked", true));
    this.objectives.Add(new Objective("location01_door2_open", false));
    this.objectives.Add(new Objective("location02_door_open", false));
    this.objectives.Add(new Objective("location02_door_locked", true));
    this.objectives.Add(new Objective("kitchen_oven_open", false));
    this.objectives.Add(new Objective("kitchen_heater_plugged", false));
    this.objectives.Add(new Objective("kitchen_fan_plugged", false));
    this.objectives.Add(new Objective("kitchen_cord_plugged", false));
    this.objectives.Add(new Objective("kitchen_cord_dragged", false));
    this.objectives.Add(new Objective("base_upstairs_cord_dragged", false));
    this.objectives.Add(new Objective("base_heater_cord_plugged", false));
    this.objectives.Add(new Objective("base_fan_cord_plugged", false));
    this.objectives.Add(new Objective("window1_ac_placed", false));
    this.objectives.Add(new Objective("base_ac_cord_plugged", false));
    this.objectives.Add(new Objective("base_window_1_net", false));
    this.objectives.Add(new Objective("base_window_1_net_nailed", false));
    this.objectives.Add(new Objective("base_window_1_net_taped", false));
    this.objectives.Add(new Objective("base_window_1_foil", false));
    this.objectives.Add(new Objective("base_window_1_foil_nailed", false));
    this.objectives.Add(new Objective("base_window_1_foil_taped", false));
    this.objectives.Add(new Objective("base_window_1_bars", false));
    this.objectives.Add(new Objective("base_window_1_bars_nailed", false));
    this.objectives.Add(new Objective("base_window_1_bars_taped", false));
    this.objectives.Add(new Objective("base_window_1_blanketb", false));
    this.objectives.Add(new Objective("base_window_1_blanketb_nailed", false));
    this.objectives.Add(new Objective("base_window_1_blanketb_taped", false));
    this.objectives.Add(new Objective("base_window_1_blanket", false));
    this.objectives.Add(new Objective("base_window_1_blanket_nailed", false));
    this.objectives.Add(new Objective("base_window_1_blanket_taped", false));
    this.objectives.Add(new Objective("base_window_1_flag", false));
    this.objectives.Add(new Objective("base_window_1_flag_nailed", false));
    this.objectives.Add(new Objective("base_window_1_flag_taped", false));
    this.objectives.Add(new Objective("base_window_1_therm", false));
    this.objectives.Add(new Objective("base_window_1_therm_nailed", false));
    this.objectives.Add(new Objective("base_window_1_therm_taped", false));
    this.objectives.Add(new Objective("base_window_1_board", false));
    this.objectives.Add(new Objective("base_window_1_board_nailed", false));
    this.objectives.Add(new Objective("base_window_1_board_taped", false));
    this.objectives.Add(new Objective("base_window1_broken", false));
    this.objectives.Add(new Objective("base_window_2_net", false));
    this.objectives.Add(new Objective("base_window_2_net_nailed", false));
    this.objectives.Add(new Objective("base_window_2_net_taped", false));
    this.objectives.Add(new Objective("base_window_2_foil", false));
    this.objectives.Add(new Objective("base_window_2_foil_nailed", false));
    this.objectives.Add(new Objective("base_window_2_foil_taped", false));
    this.objectives.Add(new Objective("base_window_2_bars", false));
    this.objectives.Add(new Objective("base_window_2_bars_nailed", false));
    this.objectives.Add(new Objective("base_window_2_bars_taped", false));
    this.objectives.Add(new Objective("base_window2_broken", false));
    this.objectives.Add(new Objective("base_window_2_blanketb", false));
    this.objectives.Add(new Objective("base_window_2_blanketb_nailed", false));
    this.objectives.Add(new Objective("base_window_2_blanketb_taped", false));
    this.objectives.Add(new Objective("base_window_2_blanket", false));
    this.objectives.Add(new Objective("base_window_2_blanket_nailed", false));
    this.objectives.Add(new Objective("base_window_2_blanket_taped", false));
    this.objectives.Add(new Objective("base_window_2_flag", false));
    this.objectives.Add(new Objective("base_window_2_flag_nailed", false));
    this.objectives.Add(new Objective("base_window_2_flag_taped", false));
    this.objectives.Add(new Objective("base_window_2_therm", false));
    this.objectives.Add(new Objective("base_window_2_therm_nailed", false));
    this.objectives.Add(new Objective("base_window_2_therm_taped", false));
    this.objectives.Add(new Objective("base_window_2_board", false));
    this.objectives.Add(new Objective("base_window_2_board_nailed", false));
    this.objectives.Add(new Objective("base_window_2_board_taped", false));
    this.objectives.Add(new Objective("base_window_3_net", false));
    this.objectives.Add(new Objective("base_window_3_net_nailed", false));
    this.objectives.Add(new Objective("base_window_3_net_taped", false));
    this.objectives.Add(new Objective("base_window_3_foil", false));
    this.objectives.Add(new Objective("base_window_3_foil_nailed", false));
    this.objectives.Add(new Objective("base_window_3_foil_taped", false));
    this.objectives.Add(new Objective("base_window_3_bars", false));
    this.objectives.Add(new Objective("base_window_3_bars_nailed", false));
    this.objectives.Add(new Objective("base_window_3_bars_taped", false));
    this.objectives.Add(new Objective("base_window3_broken", false));
    this.objectives.Add(new Objective("base_window_3_blanket", false));
    this.objectives.Add(new Objective("base_window_3_blanket_nailed", false));
    this.objectives.Add(new Objective("base_window_3_blanket_taped", false));
    this.objectives.Add(new Objective("base_window_3_blanketb", false));
    this.objectives.Add(new Objective("base_window_3_blanketb_nailed", false));
    this.objectives.Add(new Objective("base_window_3_blanketb_taped", false));
    this.objectives.Add(new Objective("base_window_3_flag", false));
    this.objectives.Add(new Objective("base_window_3_flag_nailed", false));
    this.objectives.Add(new Objective("base_window_3_flag_taped", false));
    this.objectives.Add(new Objective("base_window_3_therm", false));
    this.objectives.Add(new Objective("base_window_3_therm_nailed", false));
    this.objectives.Add(new Objective("base_window_3_therm_taped", false));
    this.objectives.Add(new Objective("base_window_3_board", false));
    this.objectives.Add(new Objective("base_window_3_board_nailed", false));
    this.objectives.Add(new Objective("base_window_3_board_taped", false));
    this.objectives.Add(new Objective("base_hatch_therm", false));
    this.objectives.Add(new Objective("base_hatch_blanketb", false));
    this.objectives.Add(new Objective("base_hatch_blanket", false));
    this.objectives.Add(new Objective("base_hatch_flag", false));
    this.objectives.Add(new Objective("base_fireplace_lit", false));
    this.objectives.Add(new Objective("attic_hatch_open", false));
    this.objectives.Add(new Objective("ginger_from_attic", false));
    this.objectives.Add(new Objective("deadbird_taken", false));
    this.objectives.Add(new Objective("chimney_cleaned", false));
    this.objectives.Add(new Objective("chimney_wood", false));
    this.objectives.Add(new Objective("chimney_note", false));
    this.objectives.Add(new Objective("chimney_papers", false));
    this.objectives.Add(new Objective("chimney_cash", false));
    this.objectives.Add(new Objective("chimney_charcoal", false));
    this.objectives.Add(new Objective("chimney_bag", false));
    this.objectives.Add(new Objective("basket_wood", false));
    this.objectives.Add(new Objective("basket_note", false));
    this.objectives.Add(new Objective("basket_papers", false));
    this.objectives.Add(new Objective("basket_cash", false));
    this.objectives.Add(new Objective("basket_charcoal", false));
    this.objectives.Add(new Objective("basket_bag", false));
    this.objectives.Add(new Objective("house_oven", false));
    this.objectives.Add(new Objective("house_heater", false));
    this.objectives.Add(new Objective("house_gasheater", false));
    this.objectives.Add(new Objective("upstairs_paperclip_taken", false));
    this.objectives.Add(new Objective("upstairs_papers_taken", false));
    this.objectives.Add(new Objective("screwdriver_taken", false));
    this.objectives.Add(new Objective("ext_cord_taken", false));
    this.objectives.Add(new Objective("outside0_window_broken", false));
    this.objectives.Add(new Objective("base_discovered", false));
    this.objectives.Add(new Objective("bridge_discovered", false));
    this.objectives.Add(new Objective("gasstation_discovered", false));
    this.objectives.Add(new Objective("pesttruck_locker1_open", false));
    this.objectives.Add(new Objective("pesttruck_locker2_open", false));
    this.objectives.Add(new Objective("pesttruck_locker2_unlocked", false));
    this.objectives.Add(new Objective("pesttruck_locker3_open", false));
    this.objectives.Add(new Objective("pesttruck_locker4_open", false));
    this.objectives.Add(new Objective("pesttruck_sonic_taken", false));
    this.objectives.Add(new Objective("pesttruck_note_taken", false));
    this.objectives.Add(new Objective("pesttruck_pest1_taken", false));
    this.objectives.Add(new Objective("pesttruck_pest2_taken", false));
    this.objectives.Add(new Objective("pesttruck_unlocked", false));
    this.objectives.Add(new Objective("pesttruck_ducttape_taken", false));
    this.objectives.Add(new Objective("pesttruck_chem_glass_taken", false));
    this.objectives.Add(new Objective("pesttruck_chemsuit_dmg_taken", false));
    this.objectives.Add(new Objective("pesttruck_spiderpest1_taken", false));
    this.objectives.Add(new Objective("pesttruck_spiderpest2_taken", false));
    this.objectives.Add(new Objective("pesttruck_spiderpest3_taken", false));
    this.objectives.Add(new Objective("pesttruck_spiderpest4_taken", false));
    this.objectives.Add(new Objective("pesttruck_bear_traps_taken", false));
    this.objectives.Add(new Objective("mask_filter_taken", false));
    this.objectives.Add(new Objective("barn_pipe_taken", false));
    this.objectives.Add(new Objective("barn_haystack_3", false));
    this.objectives.Add(new Objective("barn_haystack_2", false));
    this.objectives.Add(new Objective("barn_haystack_1", false));
    this.objectives.Add(new Objective("barn_pipe_fixed", false));
    this.objectives.Add(new Objective("car_location", false));
    this.objectives.Add(new Objective("barn_car_inspected", false));
    this.objectives.Add(new Objective("barn_car_wheel_repaired", false));
    this.objectives.Add(new Objective("barn_car_coil_repaired", false));
    this.objectives.Add(new Objective("barn_car_battery_repaired", true));
    this.objectives.Add(new Objective("barn_car_refueled", false));
    this.objectives.Add(new Objective("barn_pump_fueled", false));
    this.objectives.Add(new Objective("barn_pump_started", false, 1));
    this.objectives.Add(new Objective("barn_pump_start_try", false));
    this.objectives.Add(new Objective("barn_sprinklers_enabled", false));
    this.objectives.Add(new Objective("barn_sprinklers_b1", false));
    this.objectives.Add(new Objective("barn_sprinklers_b2", false));
    this.objectives.Add(new Objective("barn_sprinklers_b3", false));
    this.objectives.Add(new Objective("barn_sprinklers_b4", false));
    this.objectives.Add(new Objective("barn_sprinklers_b5", false));
    this.objectives.Add(new Objective("barn_sprinklers_b6", false));
    this.objectives.Add(new Objective("barn_sprinklers_b7", false));
    this.objectives.Add(new Objective("barn_sprinklers_b8", false));
    this.objectives.Add(new Objective("barn_sprinklers_fed1", false));
    this.objectives.Add(new Objective("barn_sprinklers_fed2", false));
    this.objectives.Add(new Objective("bridge_crowbar_taken", false));
    this.objectives.Add(new Objective("bridge_handle_taken", false));
    this.objectives.Add(new Objective("bridge_wheel_taken", false));
    this.objectives.Add(new Objective("bridge_westside", false));
    this.objectives.Add(new Objective("bridge_planks_used_1", false));
    this.objectives.Add(new Objective("bridge_planks_used_2", false));
    this.objectives.Add(new Objective("crashsite_discovered_bugs", false));
    this.objectives.Add(new Objective("crashsite_truck_open", false));
    this.objectives.Add(new Objective("crashsite_sonic_remote_taken", false));
    this.objectives.Add(new Objective("crashsite_wrench_taken", false));
    this.objectives.Add(new Objective("crashsite_bug_taken", false));
    this.objectives.Add(new Objective("crashsite_gas_note_read", false));
    this.objectives.Add(new Objective("crashsite_car_examined", false));
    this.objectives.Add(new Objective("crashsite_car_harvested", false));
    this.objectives.Add(new Objective("sonic_frequency", false, 123));
    this.objectives.Add(new Objective("bug_type", false, UnityEngine.Random.Range(1, 9)));
    this.objectives.Add(new Objective("greenhouse_nails", true, 4));
    this.objectives.Add(new Objective("greenhouse_sprayer_taken", false));
    this.objectives.Add(new Objective("bugs_bath", false));
    this.objectives.Add(new Objective("gasstation_lighter_taken", false));
    this.objectives.Add(new Objective("gasstation_canister_taken", false));
    this.objectives.Add(new Objective("gasstation_charcoal_taken", false));
    this.objectives.Add(new Objective("gasstation_foil1_taken", false));
    this.objectives.Add(new Objective("gasstation_foil2_taken", false));
    this.objectives.Add(new Objective("gasstation_foil3_taken", false));
    this.objectives.Add(new Objective("gasstation_net1_taken", false));
    this.objectives.Add(new Objective("gasstation_net2_taken", false));
    this.objectives.Add(new Objective("gasstation_net3_taken", false));
    this.objectives.Add(new Objective("gasstation_bars1_taken", false));
    this.objectives.Add(new Objective("gasstation_bars2_taken", false));
    this.objectives.Add(new Objective("gasstation_bars3_taken", false));
    this.objectives.Add(new Objective("gasstation_straw_taken", false));
    this.objectives.Add(new Objective("gasstation_plastic_cup_taken", false));
    this.objectives.Add(new Objective("gasstation_cash_taken", false));
    this.objectives.Add(new Objective("gasstation_crowbar_free", false));
    this.objectives.Add(new Objective("gasstation_canister_placed_under_tank", false));
    this.objectives.Add(new Objective("gasstation_canister2_placed_under_tank", false));
    this.objectives.Add(new Objective("gasstation_canister_filled", false));
    this.objectives.Add(new Objective("gasstation_canister2_filled", false));
    this.objectives.Add(new Objective("gasstation_sarge_canister_filled", false));
    this.objectives.Add(new Objective("gasstation_sarge_canister_taken", false));
    this.objectives.Add(new Objective("gasstation_sarge_intro", false));
    this.objectives.Add(new Objective("gasstation_sarge_shot", false));
    this.objectives.Add(new Objective("gasstation_sarge_reason", false));
    this.objectives.Add(new Objective("gasstation_sarge_rank", false));
    this.objectives.Add(new Objective("gasstation_sarge_army", false));
    this.objectives.Add(new Objective("gasstation_sarge_razor", false));
    this.objectives.Add(new Objective("gasstation_sarge_razor_army", false));
    this.objectives.Add(new Objective("gasstation_sarge_ship", false));
    this.objectives.Add(new Objective("gasstation_sarge_moon", false));
    this.objectives.Add(new Objective("gasstation_sarge_convinced", false));
    this.objectives.Add(new Objective("gasstation_sarge_convincing1", false));
    this.objectives.Add(new Objective("gasstation_sarge_convincing2", false));
    this.objectives.Add(new Objective("gasstation_sarge_convincing3", false));
    this.objectives.Add(new Objective("gasstation_sarge_convincing4", false));
    this.objectives.Add(new Objective("gasstation_sarge_convincing5", false));
    this.objectives.Add(new Objective("gasstation_sarge_first_bye", false));
    this.objectives.Add(new Objective("gasstation_thugs_safe", false));
    this.objectives.Add(new Objective("gasstation_map_warned", false));
    this.objectives.Add(new Objective("gasstation_spy_mode", false));
    this.objectives.Add(new Objective("thugs_gasstation_talk", false));
    this.objectives.Add(new Objective("thugs_gasstation_spotted", false));
    this.objectives.Add(new Objective("gasstation_rifle_taken", false));
    this.objectives.Add(new Objective("gasstation_spider_discovered", false));
    this.objectives.Add(new Objective("gasstation_spider_baited", false));
    this.objectives.Add(new Objective("gasstation_spider_player_fallen", false));
    this.objectives.Add(new Objective("gasstation_spider_shot", false));
    this.objectives.Add(new Objective("restaurant_pipe_inserted", false));
    this.objectives.Add(new Objective("restaurant_pipe_switched", false));
    this.objectives.Add(new Objective("restaurant_flag_lowered", false));
    this.objectives.Add(new Objective("restaurant_trash_tried", false));
    this.objectives.Add(new Objective("restaurant_trash_moved", false));
    this.objectives.Add(new Objective("restaurant_can_taken", false));
    this.objectives.Add(new Objective("restaurant_door_opened", false));
    this.objectives.Add(new Objective("restaurant_door_opened2", false));
    this.objectives.Add(new Objective("restaurant_knife_taken", false));
    this.objectives.Add(new Objective("restaurant_cupboard1_open", false));
    this.objectives.Add(new Objective("restaurant_cupboard2_open", false));
    this.objectives.Add(new Objective("restaurant_cupboard3_open", false));
    this.objectives.Add(new Objective("restaurant_ac_taken", false));
    this.objectives.Add(new Objective("restaurant_fridge_open", false));
    this.objectives.Add(new Objective("restaurant_fridge_broken", false));
    this.objectives.Add(new Objective("restaurant_water_taken1", false));
    this.objectives.Add(new Objective("restaurant_water_taken2", false));
    this.objectives.Add(new Objective("restaurant_freezer_open", false));
    this.objectives.Add(new Objective("restaurant_absorbers_taken", false));
    this.objectives.Add(new Objective("restaurant_dead_cody_commented", false));
    this.objectives.Add(new Objective("restaurant_poision_taken", false));
    this.objectives.Add(new Objective("restaurant_chem_door_open", false));
    this.objectives.Add(new Objective("restaurant_chem_walked", false));
    this.objectives.Add(new Objective("restaurant_oil_taken", false));
    this.objectives.Add(new Objective("restaurant_door_opened_teamed", false));
    this.objectives.Add(new Objective("restaurant_soliders_encountered", false));
    this.objectives.Add(new Objective("restaurant_sarge_encountered", false));
    this.objectives.Add(new Objective("restaurant_sarge_awaits", false));
    this.objectives.Add(new Objective("map_base_revealed", true, TravelAgency.LOCATION_STATUS_REACHABLE));
    this.objectives.Add(new Objective("map_bridge_revealed", false, TravelAgency.LOCATION_STATUS_REACHABLE));
    this.objectives.Add(new Objective("map_gasstation_revealed", false, TravelAgency.LOCATION_STATUS_UNDISCOVERED));
    this.objectives.Add(new Objective("map_houseb_revealed", false, TravelAgency.LOCATION_STATUS_UNDISCOVERED));
    this.objectives.Add(new Objective("map_restaurant_revealed", false, TravelAgency.LOCATION_STATUS_UNDISCOVERED));
    this.objectives.Add(new Objective("map_cars_revealed", false, TravelAgency.LOCATION_STATUS_REACHABLE));
    this.objectives.Add(new Objective("map_rv_revealed", false, TravelAgency.LOCATION_STATUS_UNDISCOVERED));
    this.objectives.Add(new Objective("map_hunters_revealed", false, TravelAgency.LOCATION_STATUS_UNDISCOVERED));
    this.objectives.Add(new Objective("map_sidereal_revealed", false, TravelAgency.LOCATION_STATUS_UNDISCOVERED));
    this.objectives.Add(new Objective("map_construction_revealed", false, TravelAgency.LOCATION_STATUS_UNDISCOVERED));
    this.objectives.Add(new Objective("map_outpost_revealed", false, TravelAgency.LOCATION_STATUS_UNDISCOVERED));
    this.objectives.Add(new Objective("map_airplane_revealed", false, TravelAgency.LOCATION_STATUS_UNDISCOVERED));
    this.objectives.Add(new Objective("map_bus_revealed", false, TravelAgency.LOCATION_STATUS_UNDISCOVERED));
    this.objectives.Add(new Objective("house_b_sheet_taken", false));
    this.objectives.Add(new Objective("house_b_blanket_taken", false));
    this.objectives.Add(new Objective("house_b_coat1_taken", false));
    this.objectives.Add(new Objective("house_b_coat2_taken", false));
    this.objectives.Add(new Objective("house_b_wife_note_taken", false));
    this.objectives.Add(new Objective("house_b_wife_note_read", false));
    this.objectives.Add(new Objective("house_b_wife_covered", false));
    this.objectives.Add(new Objective("house_b_wife_moved", false));
    this.objectives.Add(new Objective("house_b_wife_barry_moved", false));
    this.objectives.Add(new Objective("house_b_closet_open", false));
    this.objectives.Add(new Objective("house_b_grave_dug", false));
    this.objectives.Add(new Objective("house_b_body_in_grave", false));
    this.objectives.Add(new Objective("house_b_grave_filled", false));
    this.objectives.Add(new Objective("house_b_shovel_taken", false));
    this.objectives.Add(new Objective("house_b_garage_open", false));
    this.objectives.Add(new Objective("house_b_hose_disconnected", false));
    this.objectives.Add(new Objective("house_b_hose_taken", false));
    this.objectives.Add(new Objective("house_b_tank_taken", false));
    this.objectives.Add(new Objective("house_b_heater_taken", false));
    this.objectives.Add(new Objective("house_b_fan_taken", false));
    this.objectives.Add(new Objective("house_b_dead_barry_commented", false));
    this.objectives.Add(new Objective("rv_hook_taken", false));
    this.objectives.Add(new Objective("rv_hook_installed", false));
    this.objectives.Add(new Objective("rv_cave_therm", false));
    this.objectives.Add(new Objective("rv_cave_blanketb", false));
    this.objectives.Add(new Objective("rv_cave_blanket", false));
    this.objectives.Add(new Objective("rv_cave_flag", false));
    this.objectives.Add(new Objective("rv_cord_plugged", false));
    this.objectives.Add(new Objective("rv_cord_caved", false));
    this.objectives.Add(new Objective("rv_power", true));
    this.objectives.Add(new Objective("cave_heater_cord_plugged", false));
    this.objectives.Add(new Objective("cave_fan_cord_plugged", false));
    this.objectives.Add(new Objective("cave_ac_cord_plugged", false));
    this.objectives.Add(new Objective("cave_ac_placed", false));
    this.objectives.Add(new Objective("rv_coat1_taken", false));
    this.objectives.Add(new Objective("rv_coat2_taken", false));
    this.objectives.Add(new Objective("rv_shelf1_open", false));
    this.objectives.Add(new Objective("rv_shelf2_open", false));
    this.objectives.Add(new Objective("rv_aid_open", false));
    this.objectives.Add(new Objective("rv_silver_taken", false));
    this.objectives.Add(new Objective("rv_bandage_taken", false));
    this.objectives.Add(new Objective("rv_generator_taken", false));
    this.objectives.Add(new Objective("rv_blanket_taken", false));
    this.objectives.Add(new Objective("rv_door_open", false));
    this.objectives.Add(new Objective("rv_inspected", false));
    this.objectives.Add(new Objective("rv_fueled", false));
    this.objectives.Add(new Objective("rv_started", false));
    this.objectives.Add(new Objective("rv_water3_taken", false));
    this.objectives.Add(new Objective("rv_water4_taken", false));
    this.objectives.Add(new Objective("sidereal_roof_collapsed", false));
    this.objectives.Add(new Objective("sidereal_roof_wait_for_rescue", false));
    this.objectives.Add(new Objective("sidereal_roof_npc_shocked", false));
    this.objectives.Add(new Objective("sidereal_roof_afterfall_talk", false));
    this.objectives.Add(new Objective("sidereal_npc_found", false));
    this.objectives.Add(new Objective("sidereal_npc_died", false));
    this.objectives.Add(new Objective("sidereal_npc_buried", false));
    this.objectives.Add(new Objective("sidereal_base_located", false));
    this.objectives.Add(new Objective("sidereal_lucid_dreaming_discovered", false));
    this.objectives.Add(new Objective("sidereal_vent_open", false));
    this.objectives.Add(new Objective("sidereal_barry_pipe_moved", false));
    this.objectives.Add(new Objective("sidereal_barry_door_open", false));
    this.objectives.Add(new Objective("sidereal_cody_disk_taken", false));
    this.objectives.Add(new Objective("sidereal_barry_disk_taken", false));
    this.objectives.Add(new Objective("sidereal_exit_unlocked", false));
    this.objectives.Add(new Objective("sidereal_elevator_f1_hosed", false));
    this.objectives.Add(new Objective("sidereal_elevator_f1_open", false));
    this.objectives.Add(new Objective("sidereal_elevator_f2_open", false));
    this.objectives.Add(new Objective("sidereal_elevator_f3_open", false));
    this.objectives.Add(new Objective("sidereal_electric_pin_a", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_b", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_c", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_d", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_e", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_s_a", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_s_b", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_s_c", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_s_d", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_s_e", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_a1", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_a2", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_b1", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_b2", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_b3", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_c1", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_c2", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_d1", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_d2", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_d3", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_d4", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_e1", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_e2", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_e3", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_A", true));
    this.objectives.Add(new Objective("sidereal_electric_pin_B", true));
    this.objectives.Add(new Objective("sidereal_email_displayed", false));
    this.objectives.Add(new Objective("sidereal_email_page", false));
    this.objectives.Add(new Objective("sidereal_internet_displayed", false));
    this.objectives.Add(new Objective("sidereal_papers_taken", false));
    this.objectives.Add(new Objective("sidereal_xero_taken", false));
    this.objectives.Add(new Objective("sidereal_secrets_taken", false));
    this.objectives.Add(new Objective("sidereal_keys_taken", false));
    this.objectives.Add(new Objective("sidereal_pipe_tried", false));
    this.objectives.Add(new Objective("sidereal_f1c_s_open", false));
    this.objectives.Add(new Objective("sidereal_f1c_b_open", false));
    this.objectives.Add(new Objective("sidereal_f2c_b_open", false));
    this.objectives.Add(new Objective("sidereal_f2c_b_unlocked", false));
    this.objectives.Add(new Objective("sidereal_read_last_mail", false));
    this.objectives.Add(new Objective("sidereal_read_cate_mail", false));
    this.objectives.Add(new Objective("sidereal_mixer_b1", false));
    this.objectives.Add(new Objective("sidereal_mixer_b2", false));
    this.objectives.Add(new Objective("sidereal_mixer_b3", false));
    this.objectives.Add(new Objective("sidereal_mixer_b4", false));
    this.objectives.Add(new Objective("sidereal_mixer_b5", false));
    this.objectives.Add(new Objective("sidereal_mixer_b6", false));
    this.objectives.Add(new Objective("sidereal_mixer_mixed", false));
    this.objectives.Add(new Objective("sidereal_components_1", false));
    this.objectives.Add(new Objective("sidereal_components_2", false));
    this.objectives.Add(new Objective("sidereal_vials1_taken", false));
    this.objectives.Add(new Objective("sidereal_vials2_taken", false));
    this.objectives.Add(new Objective("sidereal_disc1_taken", false));
    this.objectives.Add(new Objective("sidereal_disc2_taken", false));
    this.objectives.Add(new Objective("sidereal_lab_open", false));
    this.objectives.Add(new Objective("sidereal_finger_cut", false));
    this.objectives.Add(new Objective("sidereal_silencer", false));
    this.objectives.Add(new Objective("sidereal_lab_locked", true));
    this.objectives.Add(new Objective("hunters_lodge_trap_cleared", false));
    this.objectives.Add(new Objective("hunters_lodge_trap_picked", false));
    this.objectives.Add(new Objective("hunters_lodge_scratches_found", false));
    this.objectives.Add(new Objective("hunters_lodge_couch_moved", false));
    this.objectives.Add(new Objective("hunters_lodge_horn_pulled", false));
    this.objectives.Add(new Objective("hunters_lodge_chest_opened", false));
    this.objectives.Add(new Objective("hunters_lodge_hatch_gun_taken", false));
    this.objectives.Add(new Objective("hunters_lodge_hatch_ammo1_taken", false));
    this.objectives.Add(new Objective("hunters_lodge_hatch_ammo2_taken", false));
    this.objectives.Add(new Objective("hunters_lodge_trap1_taken", false));
    this.objectives.Add(new Objective("hunters_lodge_trap2_taken", false));
    this.objectives.Add(new Objective("hunters_lodge_trap4_taken", false));
    this.objectives.Add(new Objective("hunters_lodge_scope_taken", false));
    this.objectives.Add(new Objective("hunters_lodge_whiskey_taken", false));
    this.objectives.Add(new Objective("lodge_board_taken", false));
    this.objectives.Add(new Objective("gloves_taken", false));
    this.objectives.Add(new Objective("cs_park_nogo", false));
    this.objectives.Add(new Objective("cs_guard_distracted", false));
    this.objectives.Add(new Objective("cs_crow_away", false));
    this.objectives.Add(new Objective("cs_ammo_oiled", false));
    this.objectives.Add(new Objective("cs_ammo_watered", false));
    this.objectives.Add(new Objective("cs_food_poisioned", false));
    this.objectives.Add(new Objective("cs_food_taken", false));
    this.objectives.Add(new Objective("cs_thug_shot", false));
    this.objectives.Add(new Objective("cs_bars_taken", false));
    this.objectives.Add(new Objective("cs_arrive_from_inside", false));
    this.objectives.Add(new Objective("constructionsite_from_above", false));
    this.objectives.Add(new Objective("cs_rope_used", false));
    this.objectives.Add(new Objective("cs_welder_taken", false));
    this.objectives.Add(new Objective("cs_rain_enter_left", false));
    this.objectives.Add(new Objective("cs_pack_lifted", false));
    this.objectives.Add(new Objective("cs_wire_taken", false));
    this.objectives.Add(new Objective("cs_engine_fueled", false));
    this.objectives.Add(new Objective("cs_engine_started", false));
    this.objectives.Add(new Objective("cs_crane_left", false));
    this.objectives.Add(new Objective("cs_crane_down", true));
    this.objectives.Add(new Objective("cs_crane_closed", true));
    this.objectives.Add(new Objective("cs_cables_open", false));
    this.objectives.Add(new Objective("cs_stormcatcher_installed", false));
    this.objectives.Add(new Objective("cs_tarpaulin_taken", false));
    this.objectives.Add(new Objective("cs_safe", false));
    this.objectives.Add(new Objective("outpost_doormat_triggered", false));
    this.objectives.Add(new Objective("outpost_doormat_first_time", false));
    this.objectives.Add(new Objective("outpost_door_open", false));
    this.objectives.Add(new Objective("outpost_fuse_11", true));
    this.objectives.Add(new Objective("outpost_fuse_12", true));
    this.objectives.Add(new Objective("outpost_fuse_13", true));
    this.objectives.Add(new Objective("outpost_fuse_14", true));
    this.objectives.Add(new Objective("outpost_fuse_15", true));
    this.objectives.Add(new Objective("outpost_fuse_21", true));
    this.objectives.Add(new Objective("outpost_fuse_22", true));
    this.objectives.Add(new Objective("outpost_fuse_23", true));
    this.objectives.Add(new Objective("outpost_fuse_24", true));
    this.objectives.Add(new Objective("outpost_fuse_25", true));
    this.objectives.Add(new Objective("outpost_fuse_31", true));
    this.objectives.Add(new Objective("outpost_fuse_32", true));
    this.objectives.Add(new Objective("outpost_fuse_33", true));
    this.objectives.Add(new Objective("outpost_fuse_34", true));
    this.objectives.Add(new Objective("outpost_fuse_35", true));
    this.objectives.Add(new Objective("outpost_fuse_41", true));
    this.objectives.Add(new Objective("outpost_fuse_42", true));
    this.objectives.Add(new Objective("outpost_fuse_43", true));
    this.objectives.Add(new Objective("outpost_fuse_44", true));
    this.objectives.Add(new Objective("outpost_fuse_45", true));
    this.objectives.Add(new Objective("outpost_fuse_51", true));
    this.objectives.Add(new Objective("outpost_fuse_52", true));
    this.objectives.Add(new Objective("outpost_fuse_53", true));
    this.objectives.Add(new Objective("outpost_fuse_54", true));
    this.objectives.Add(new Objective("outpost_fuse_55", true));
    this.objectives.Add(new Objective("outpost_radar_open", false));
    this.objectives.Add(new Objective("outpost_radar_repaired", false));
    this.objectives.Add(new Objective("outpost_doormat_just_disabled", false));
    this.objectives.Add(new Objective("outpost_doormat_they_enter", false));
    this.objectives.Add(new Objective("outpost_door_powered", true));
    this.objectives.Add(new Objective("outpost_fusebox_open", false));
    this.objectives.Add(new Objective("outpost_elevator_powered", false));
    this.objectives.Add(new Objective("outpost_elevator_open", false));
    this.objectives.Add(new Objective("outpost_elevator_up", false));
    this.objectives.Add(new Objective("outpost_fuse_short_circuit", false));
    this.objectives.Add(new Objective("outpost_elevator_travel", false));
    this.objectives.Add(new Objective("outpost_underground_light", false));
    this.objectives.Add(new Objective("outpost_fingerprint_unlocked", false));
    this.objectives.Add(new Objective("outpost_storage_open", false));
    this.objectives.Add(new Objective("outpost_switch_pressed", false));
    this.objectives.Add(new Objective("outpost_remote_taken", false));
    this.objectives.Add(new Objective("outpost_card_taken", false));
    this.objectives.Add(new Objective("outpost_calibrator_taken", false));
    this.objectives.Add(new Objective("outpost_filter_taken", false));
    this.objectives.Add(new Objective("outpost_spaceship_discovered", false));
    this.objectives.Add(new Objective("outpost_hall_unlocked", false));
    this.objectives.Add(new Objective("outpost_hall_open", false));
    this.objectives.Add(new Objective("outpost_control_room_open", false));
    this.objectives.Add(new Objective("outpost_bars_a", false, 50));
    this.objectives.Add(new Objective("outpost_bars_b", false, 50));
    this.objectives.Add(new Objective("outpost_bars_c", false, 50));
    this.objectives.Add(new Objective("outpost_bars_d", false, 50));
    this.objectives.Add(new Objective("outpost_bars_e", false, 50));
    this.objectives.Add(new Objective("outpost_score_a", false));
    this.objectives.Add(new Objective("outpost_score_b", false));
    this.objectives.Add(new Objective("outpost_score_c", false));
    this.objectives.Add(new Objective("outpost_score_d", false));
    this.objectives.Add(new Objective("outpost_score_e", false));
    this.objectives.Add(new Objective("ship_toolbox_open", false));
    this.objectives.Add(new Objective("ship_toolbox_searched", false));
    this.objectives.Add(new Objective("ship_launched", false));
    this.objectives.Add(new Objective("bus_fingerprint_molded", false));
    this.objectives.Add(new Objective("bus_key_taken", false));
    this.objectives.Add(new Objective("plane_undig", false));
    this.objectives.Add(new Objective("moon_shocked1", false));
    this.objectives.Add(new Objective("moon_shocked2", false));
    this.objectives.Add(new Objective("moon_shocked3", false));
    this.objectives.Add(new Objective("moon_suited_up", false));
    this.objectives.Add(new Objective("moon_door_open", false));
    this.objectives.Add(new Objective("moon_closet_open", false));
    this.objectives.Add(new Objective("moon_talk_base_enter", false));
    this.objectives.Add(new Objective("moon_allow_fast_travel_now", false));
    this.objectives.Add(new Objective("moon_talk_pods", false));
    this.objectives.Add(new Objective("moon_cody_sleeps", false));
    this.objectives.Add(new Objective("moon_barry_sleeps", false));
    this.objectives.Add(new Objective("moon_cate_sleeps", false));
    this.objectives.Add(new Objective("moon_disc1_used", false));
    this.objectives.Add(new Objective("moon_disc2_used", false));
    this.objectives.Add(new Objective("moon_card_taken", false));
    this.objectives.Add(new Objective("moon_card_used", false));
    this.objectives.Add(new Objective("moon_console_unlocked", false));
    this.objectives.Add(new Objective("pods_cosnole_inspected", false));
    this.objectives.Add(new Objective("moon_pods_unlocked", false));
    this.objectives.Add(new Objective("moon_light_failed", false));
    this.objectives.Add(new Objective("moon_light_restored", false));
    this.objectives.Add(new Objective("moon_ship_collapsed", false));
    this.objectives.Add(new Objective("moon_window_cracked", false));
    this.objectives.Add(new Objective("moon_door_closed", false));
    this.objectives.Add(new Objective("moon_david_sleeps", false));
    this.objectives.Add(new Objective("airlock_ring_1", false, UnityEngine.Random.Range(1, 6)));
    this.objectives.Add(new Objective("airlock_ring_2", false, UnityEngine.Random.Range(2, 5)));
    this.objectives.Add(new Objective("airlock_ring_3", false, UnityEngine.Random.Range(2, 5)));
    this.objectives.Add(new Objective("airlock_ring_4", false, UnityEngine.Random.Range(3, 4)));
    this.objectives.Add(new Objective("airlock_ring_5", false, UnityEngine.Random.Range(3, 4)));
    List<int> intList = new List<int>();
    intList.Add(1);
    intList.Add(2);
    intList.Add(3);
    intList.Add(4);
    intList.Add(5);
    intList.Add(6);
    intList.Add(7);
    for (int index1 = 0; index1 < 20; ++index1)
    {
      int index2 = UnityEngine.Random.Range(0, 7);
      intList.Add(intList[index2]);
      intList.RemoveAt(index2);
    }
    this.objectives.Add(new Objective("plane_crate_1", false, intList[0]));
    this.objectives.Add(new Objective("plane_crate_2", false, intList[1]));
    this.objectives.Add(new Objective("plane_crate_3", false, intList[2]));
    this.objectives.Add(new Objective("plane_crate_4", false, intList[3]));
    this.objectives.Add(new Objective("plane_crate_5", false, intList[4]));
    this.objectives.Add(new Objective("plane_crate_6", false, intList[5]));
    this.objectives.Add(new Objective("plane_crate_7", false, intList[6]));
    this.objectives.Add(new Objective("plane_crate_1_taken", false));
    this.objectives.Add(new Objective("plane_crate_2_taken", false));
    this.objectives.Add(new Objective("plane_crate_3_taken", false));
    this.objectives.Add(new Objective("plane_crate_4_taken", false));
    this.objectives.Add(new Objective("plane_crate_5_taken", false));
    this.objectives.Add(new Objective("plane_crate_6_taken", false));
    this.objectives.Add(new Objective("plane_crate_7_taken", false));
    this.objectives.Add(new Objective("plane_transponder_disabled", false));
    this.objectives.Add(new Objective("plane_pilot_searched", false));
    this.objectives.Add(new Objective("outpost_computer_part_taken", false));
    this.objectives.Add(new Objective("outpost_hatch_open", false));
    this.objectives.Add(new Objective("outpost_belt_hatch", true));
    this.objectives.Add(new Objective("outpost_belt_elevator", false));
    this.objectives.Add(new Objective("outpost_navigation_chip_inserted", false));
    this.objectives.Add(new Objective("outpost_lioh_filters_inserted", false));
    this.objectives.Add(new Objective("outpost_air_tanks_inserted", false));
    this.objectives.Add(new Objective("outpost_calibrator_inserted", false));
    this.objectives.Add(new Objective("outpost_cabinet_open", false));
    this.objectives.Add(new Objective("outpost_catalyst_used", false));
    this.objectives.Add(new Objective("outpost_hull_repaired_outside", false));
    this.objectives.Add(new Objective("outpost_hull_repaired_inside", false));
    this.objectives.Add(new Objective("mixer_note_taken", false));
    this.objectives.Add(new Objective("plane_undig", false));
    this.objectives.Add(new Objective("barry_pills_taken", false));
    this.objectives.Add(new Objective("cody_pills_taken", false));
    this.objectives.Add(new Objective("cate_pills_taken", false));
    this.objectives.Add(new Objective("thug_to_kill_bathroom", false));
    this.objectives.Add(new Objective("thug_killed_bathroom", false));
    this.objectives.Add(new Objective("day4_started", false));
    this.objectives.Add(new Objective("d4_intro", false));
    this.objectives.Add(new Objective("lodge_cord_plugged", false));
    this.objectives.Add(new Objective("lodge_cord_dragged", false));
    this.objectives.Add(new Objective("lodge_cord_climbed", false));
    this.objectives.Add(new Objective("lodge_tree_stormcatcher", false));
    this.objectives.Add(new Objective("lodge_roof_cleaned", false));
    this.objectives.Add(new Objective("lodge_broom_taken", false));
    this.visited.Add(new Objective("visited_location1", false));
    this.visited.Add(new Objective("visited_location2", false));
    this.visited.Add(new Objective("visited_baseBathroom", false));
    this.visited.Add(new Objective("visited_baseUpstairs", false));
    this.visited.Add(new Objective("visited_baseOutside0", false));
    this.visited.Add(new Objective("visited_baseOutside1", false));
    this.visited.Add(new Objective("visited_baseOutside2", false));
    this.visited.Add(new Objective("visited_baseOutside3", false));
    this.visited.Add(new Objective("visited_barn", false));
    this.visited.Add(new Objective("visited_crossroad", false));
    this.visited.Add(new Objective("visited_bridge", false));
    this.visited.Add(new Objective("visited_gasstation1", false));
    this.visited.Add(new Objective("visited_gasstation2", false));
    this.visited.Add(new Objective("visited_gasstationRoom1", false));
    this.visited.Add(new Objective("visited_gasstationRoom2", false));
    this.visited.Add(new Objective("visited_crashsite1", false));
    this.visited.Add(new Objective("visited_crashsite2", false));
    this.visited.Add(new Objective("visited_pestTruck", false));
    this.visited.Add(new Objective("visited_attic1", false));
    this.visited.Add(new Objective("visited_attic2", false));
    this.visited.Add(new Objective("visited_roof1", false));
    this.visited.Add(new Objective("visited_roof2", false));
    this.visited.Add(new Objective("visited_house_b", false));
    this.visited.Add(new Objective("visited_house_b_inside", false));
    this.visited.Add(new Objective("visited_house_b_back", false));
    this.visited.Add(new Objective("visited_restaurant_back", false));
    this.visited.Add(new Objective("visited_restaurant_front", false));
    this.visited.Add(new Objective("visited_restaurant_inside", false));
    this.visited.Add(new Objective("visited_restaurant_kitchen", false));
    this.visited.Add(new Objective("visited_restaurant_wc", false));
    this.visited.Add(new Objective("visited_cave", false));
    this.visited.Add(new Objective("visited_rv", false));
    this.visited.Add(new Objective("visited_rv_inside", false));
    this.visited.Add(new Objective("visited_hunters_lodge_1", false));
    this.visited.Add(new Objective("visited_hunters_lodge_2", false));
    this.visited.Add(new Objective("visited_hunters_lodge_outside_1", false));
    this.visited.Add(new Objective("visited_hunters_lodge_outside_2", false));
    this.visited.Add(new Objective("visited_sidereal_outside_1", false));
    this.visited.Add(new Objective("visited_sidereal_outside_2", false));
    this.visited.Add(new Objective("visited_sidereal_outside_3", false));
    this.visited.Add(new Objective("visited_sidereal_roof", false));
    this.visited.Add(new Objective("visited_sidereal_f3c", false));
    this.visited.Add(new Objective("visited_sidereal_f3s", false));
    this.visited.Add(new Objective("visited_sidereal_f2s", false));
    this.visited.Add(new Objective("visited_sidereal_f2c", false));
    this.visited.Add(new Objective("visited_sidereal_f2b", false));
    this.visited.Add(new Objective("visited_sidereal_f1b", false));
    this.visited.Add(new Objective("visited_sidereal_f1s", false));
    this.visited.Add(new Objective("visited_sidereal_f1c", false));
    this.visited.Add(new Objective("visited_sidereal_f0c", false));
    this.visited.Add(new Objective("visited_sidereal_f0c0a", false));
    this.visited.Add(new Objective("visited_sidereal_f0s", false));
    this.visited.Add(new Objective("visited_sidereal_f0c1", false));
    this.visited.Add(new Objective("visited_sidereal_f0c2", false));
    this.visited.Add(new Objective("visited_sidereal_f0c3", false));
    this.visited.Add(new Objective("visited_sidereal_lab", false));
    this.visited.Add(new Objective("visited_cs_1", false));
    this.visited.Add(new Objective("visited_cs_2", false));
    this.visited.Add(new Objective("visited_cs_3", false));
    this.visited.Add(new Objective("visited_cs_4", false));
    this.visited.Add(new Objective("visited_airplane1", false));
    this.visited.Add(new Objective("visited_airplane2", false));
    this.visited.Add(new Objective("visited_airplane3", false));
    this.visited.Add(new Objective("visited_bus1", false));
    this.visited.Add(new Objective("visited_bus2", false));
    this.visited.Add(new Objective("visited_fusebox", false));
    this.visited.Add(new Objective("visited_mixer", false));
    this.visited.Add(new Objective("visited_outpost1", false));
    this.visited.Add(new Objective("visited_outpost2", false));
    this.visited.Add(new Objective("visited_outpost3", false));
    this.visited.Add(new Objective("visited_outpost4", false));
    this.visited.Add(new Objective("visited_outpost5", false));
    this.visited.Add(new Objective("visited_outpost6", false));
    this.visited.Add(new Objective("visited_outpost7", false));
    this.visited.Add(new Objective("visited_outpost8", false));
    this.visited.Add(new Objective("visited_outpost9", false));
    this.visited.Add(new Objective("visited_outpost10", false));
    this.visited.Add(new Objective("visited_outpost11", false));
    this.visited.Add(new Objective("visited_ship1", false));
    this.visited.Add(new Objective("visited_ship2", false));
    this.visited.Add(new Objective("visited_moonbase1", false));
    this.visited.Add(new Objective("visited_moonbase2", false));
    this.visited.Add(new Objective("visited_moonbase3", false));
    this.objectives.Add(new Objective("house_key_taken", false));
    this.objectives.Add(new Objective("day1_complete", false));
    this.objectives.Add(new Objective("day2_complete", false));
    this.objectives.Add(new Objective("day3_complete", false));
    this.objectives.Add(new Objective("day4_complete", false));
    this.journals.Add(new Objective("journal_changed", false));
    this.journals.Add(new Objective("day2_ginger", false));
    this.journals.Add(new Objective("day2_barry", false));
    this.journals.Add(new Objective("day2_cody", false));
    this.journals.Add(new Objective("windows_blankets_1_d2", false));
    this.journals.Add(new Objective("windows_blankets_2_d2", false));
    this.journals.Add(new Objective("windows_blankets_3_d2", false));
    this.journals.Add(new Objective("windows_foil_1_d2", false));
    this.journals.Add(new Objective("windows_foil_2_d2", false));
    this.journals.Add(new Objective("windows_foil_3_d2", false));
    this.journals.Add(new Objective("hatch_blanket_d2", false));
    this.journals.Add(new Objective("heat_absorber_base_1", false));
    this.journals.Add(new Objective("heat_absorber_base_2", false));
    this.journals.Add(new Objective("heat_absorber_base_3", false));
    this.journals.Add(new Objective("house_ac", false));
    this.journals.Add(new Objective("house_fan", false));
    this.journals.Add(new Objective("cave_blanket_d2", false));
    this.journals.Add(new Objective("cave_ac", false));
    this.journals.Add(new Objective("cave_fan", false));
    this.journals.Add(new Objective("rv_started", false));
    this.journals.Add(new Objective("heat_absorber_cave_1", false));
    this.journals.Add(new Objective("heat_absorber_cave_2", false));
    this.journals.Add(new Objective("heat_absorber_cave_3", false));
    this.journals.Add(new Objective("ginger_water", false));
    this.journals.Add(new Objective("barry_water", false));
    this.journals.Add(new Objective("cody_water", false));
    this.journals.Add(new Objective("david_water", false));
    this.journals.Add(new Objective("ginger_coat", false));
    this.journals.Add(new Objective("barry_coat", false));
    this.journals.Add(new Objective("cody_coat", false));
    this.journals.Add(new Objective("david_coat", false));
    this.journals.Add(new Objective("house_gasheater", false));
    this.journals.Add(new Objective("house_oven", false));
    this.journals.Add(new Objective("house_heater", false));
    this.journals.Add(new Objective("day1_base", false));
    this.journals.Add(new Objective("day1_sonic", false));
    this.journals.Add(new Objective("day1_spider_trap11", false));
    this.journals.Add(new Objective("day1_spider_trap22", false));
    this.journals.Add(new Objective("day1_spider_trap1", false));
    this.journals.Add(new Objective("day1_spider_trap2", false));
    this.journals.Add(new Objective("day1_spray_pest", false));
    this.journals.Add(new Objective("day1_spray_water_bugs", false));
    this.journals.Add(new Objective("day1_spray_chem_gas", false));
    this.journals.Add(new Objective("day1_spray_water_gas", false));
    this.journals.Add(new Objective("day1_spray_water_spiders", false));
    this.journals.Add(new Objective("day1_spray_pest_spiders", false));
    this.journals.Add(new Objective("windows_net_1", false));
    this.journals.Add(new Objective("windows_net_2", false));
    this.journals.Add(new Objective("windows_net_3", false));
    this.journals.Add(new Objective("windows_bars_1", false));
    this.journals.Add(new Objective("windows_bars_2", false));
    this.journals.Add(new Objective("windows_bars_3", false));
    this.journals.Add(new Objective("windows_foil_1", false));
    this.journals.Add(new Objective("windows_foil_2", false));
    this.journals.Add(new Objective("windows_foil_3", false));
    this.journals.Add(new Objective("day1_flamethrower", false));
    this.journals.Add(new Objective("day1_pestspray", false));
    this.journals.Add(new Objective("day1_rifle", false));
    this.journals.Add(new Objective("day1_hazmat", false));
    this.journals.Add(new Objective("day1_gas_density", false));
    this.journals.Add(new Objective("day1_doors_towels", false));
    this.journals.Add(new Objective("day1_doors", false));
    this.journals.Add(new Objective("day3_funeral", false));
    this.journals.Add(new Objective("day3_sidereal_arrive", false));
    this.journals.Add(new Objective("day3_sidereal_lodge_location", false));
    this.journals.Add(new Objective("day3_sidereal_outpost_location", false));
    this.journals.Add(new Objective("day3_sidereal_barry_dead", false));
    this.journals.Add(new Objective("day3_sidereal_cody_dead", false));
    this.journals.Add(new Objective("day3_silencer_constructed", false));
    this.journals.Add(new Objective("day3_sniper_constructed", false));
    this.journals.Add(new Objective("day3_thugs_heard", false));
    this.journals.Add(new Objective("day3_sarge_shot", false));
    this.journals.Add(new Objective("day3_sarge_convinced", false));
    this.journals.Add(new Objective("day3_guard_killed", false));
    this.journals.Add(new Objective("day3_whiskey_left", false));
    this.journals.Add(new Objective("day3_food_poisoned", false));
    this.journals.Add(new Objective("day3_ammo_spoiled", false));
    this.journals.Add(new Objective("day3_window_bars", false));
    this.journals.Add(new Objective("day3_window_block", false));
    this.journals.Add(new Objective("day3_traps", false));
    this.journals.Add(new Objective("day3_rifle_rounds", false));
    this.journals.Add(new Objective("day3_revolver_barry", false));
    this.journals.Add(new Objective("day3_revolver_cody", false));
    this.journals.Add(new Objective("day4_outpost_hulloutside", false));
    this.journals.Add(new Objective("day4_outpost_catlyst", false));
    this.journals.Add(new Objective("day4_outpost_calibrator", false));
    this.journals.Add(new Objective("day4_outpost_navchip", false));
    this.journals.Add(new Objective("day4_outpost_fuel_mixture", false));
    this.journals.Add(new Objective("day4_outpost_catepills", false));
    this.journals.Add(new Objective("day4_outpost_codypills", false));
    this.journals.Add(new Objective("day4_outpost_barrypills", false));
    this.journals.Add(new Objective("day4_outpost_hullinside", false));
    this.journals.Add(new Objective("day4_outpost_airtanks", false));
    this.journals.Add(new Objective("day4_outpost_lioh", false));
    this.journals.Add(new Objective("day4_outpost_air_mixture", false));
    this.journals.Add(new Objective("day4_hatch_open", false));
    this.journals.Add(new Objective("day4_outpost_spaceship", false));
    this.journals.Add(new Objective("day4_outpost_arrive", false));
    this.journals.Add(new Objective("day4_razor_spared", false));
    this.journals.Add(new Objective("day4_razor_killed", false));
    this.journals.Add(new Objective("windows_boards_1", false));
    this.journals.Add(new Objective("windows_boards_2", false));
    this.journals.Add(new Objective("windows_boards_3", false));
    this.objectives.Add(new Objective("npc1_alive", true));
    this.objectives.Add(new Objective("dialogue_ginger_intro", false));
    this.objectives.Add(new Objective("dialogue_ginger_dreams", false));
    this.objectives.Add(new Objective("dialogue_ginger_dreams2", false));
    this.objectives.Add(new Objective("dialogue_ginger_outpost", false));
    this.objectives.Add(new Objective("dialogue_ginger_first_exit", false));
    this.objectives.Add(new Objective("dialogue_ginger_base_comment", false));
    this.objectives.Add(new Objective("dialogue_ginger_weather_comment", false));
    this.objectives.Add(new Objective("dialogue_ginger_moon", false));
    this.objectives.Add(new Objective("dialogue_ginger_car", false));
    this.objectives.Add(new Objective("dialogue_ginger_ship", false));
    this.objectives.Add(new Objective("dialogue_ginger_map", false));
    this.objectives.Add(new Objective("dialogue_ginger_about", false));
    this.objectives.Add(new Objective("dialogue_ginger_barry_distracted", false));
    this.objectives.Add(new Objective("dialogue_ginger_reunited", false));
    this.objectives.Add(new Objective("dialogue_ginger_dead_mourned", false));
    this.objectives.Add(new Objective("dialogue_ginger_sidereal_arrival_outpost", false));
    this.objectives.Add(new Objective("dialogue_ginger_sidereal_arrival_docs", false));
    this.objectives.Add(new Objective("dialogue_ginger_sidereal_arrival_connections1", false));
    this.objectives.Add(new Objective("dialogue_ginger_sidereal_arrival_connections2", false));
    this.objectives.Add(new Objective("dialogue_ginger_thug_kill_waste", false));
    this.objectives.Add(new Objective("dialogue_ginger_thug_kill_lesson", false));
    this.objectives.Add(new Objective("dialogue_ginger_thug_kill_better", false));
    this.objectives.Add(new Objective("dialogue_ginger_thug_kill_end_anyway", false));
    this.objectives.Add(new Objective("dialogue_ginger_thug_kill_yes", false));
    this.objectives.Add(new Objective("dialogue_ginger_thug_kill_no", false));
    this.objectives.Add(new Objective("dialogue_ginger_fingerprint", false));
    this.objectives.Add(new Objective("dialogue_ginger_moon_radio1", false));
    this.objectives.Add(new Objective("dialogue_ginger_moon_radio2", false));
    this.objectives.Add(new Objective("dialogue_moonbase2_sleeper_pods", false));
    this.objectives.Add(new Objective("dialogue_moonbase2_body_dies", false));
    this.objectives.Add(new Objective("dialogue_moonbase2_realm_of_dreams", false));
    this.objectives.Add(new Objective("dialogue_moonbase2_intro", false));
    this.objectives.Add(new Objective("dialogue_pods_intro", false));
    this.objectives.Add(new Objective("dialogue_pods_phase_controller", false));
    this.objectives.Add(new Objective("dialogue_pods_merge_mode", false));
    this.objectives.Add(new Objective("dialogue_pods_loop1", false));
    this.objectives.Add(new Objective("dialogue_pods_loop2", false));
    this.objectives.Add(new Objective("dialogue_pods_paradox", false));
    this.objectives.Add(new Objective("dialogue_pods_where", false));
    this.objectives.Add(new Objective("dialogue_pods_lockdown", false));
    this.objectives.Add(new Objective("dialogue_pods_emergency_mode", false));
    this.objectives.Add(new Objective("dialogue_ginger_pills", false));
    this.objectives.Add(new Objective("ginger_sidereal_reveal", false));
    this.objectives.Add(new Objective("ginger_sidereal_why", false));
    this.objectives.Add(new Objective("ginger_sidereal_else", false));
    this.objectives.Add(new Objective("ginger_sidereal_ship", false));
    this.objectives.Add(new Objective("ginger_sidereal_dreams", false));
    this.objectives.Add(new Objective("ginger_moon_disk", false));
    this.objectives.Add(new Objective("ginger_moon_disks", false));
    this.objectives.Add(new Objective("npc2_joined", false));
    this.objectives.Add(new Objective("npc2_alive", true));
    this.objectives.Add(new Objective("dialogue_npc2_house_blocked", false));
    this.objectives.Add(new Objective("dialogue_npc2_intro", false));
    this.objectives.Add(new Objective("dialogue_npc2_come", false));
    this.objectives.Add(new Objective("dialogue_npc2_come2", false));
    this.objectives.Add(new Objective("dialogue_npc2_moon", false));
    this.objectives.Add(new Objective("dialogue_npc2_wife", false));
    this.objectives.Add(new Objective("dialogue_npc2_burial", false));
    this.objectives.Add(new Objective("dialogue_npc2_burial2", false));
    this.objectives.Add(new Objective("dialogue_npc2_ship", false));
    this.objectives.Add(new Objective("dialogue_npc2_ginger1", false));
    this.objectives.Add(new Objective("dialogue_npc2_ginger2", false));
    this.objectives.Add(new Objective("dialogue_npc2_ginger3", false));
    this.objectives.Add(new Objective("dialogue_npc2_cody1", false));
    this.objectives.Add(new Objective("dialogue_npc2_cody2", false));
    this.objectives.Add(new Objective("dialogue_npc2_cody3", false));
    this.objectives.Add(new Objective("dialogue_npc2_cody_dead", false));
    this.objectives.Add(new Objective("dialogue_ginger_cody_dead", false));
    this.objectives.Add(new Objective("dialogue_ginger_cody1", false));
    this.objectives.Add(new Objective("dialogue_ginger_cody2", false));
    this.objectives.Add(new Objective("dialogue_ginger_cody3", false));
    this.objectives.Add(new Objective("dialogue_ginger_barry1", false));
    this.objectives.Add(new Objective("dialogue_ginger_barry2", false));
    this.objectives.Add(new Objective("dialogue_ginger_barry3", false));
    this.objectives.Add(new Objective("dialogue_ginger_barry_dead", false));
    this.objectives.Add(new Objective("dialogue_barry_wife", false));
    this.objectives.Add(new Objective("dialogue_barry_car0", false));
    this.objectives.Add(new Objective("dialogue_barry_car1", false));
    this.objectives.Add(new Objective("dialogue_barry_car2", false));
    this.objectives.Add(new Objective("dialogue_sarge_thugs1_cody", false));
    this.objectives.Add(new Objective("dialogue_sarge_thugs2_cody", false));
    this.objectives.Add(new Objective("dialogue_sarge_thugs3_cody", false));
    this.objectives.Add(new Objective("dialogue_sarge_thugs4_cody", false));
    this.objectives.Add(new Objective("dialogue_sarge_storm1_cody", false));
    this.objectives.Add(new Objective("dialogue_sarge_thugs1_barry", false));
    this.objectives.Add(new Objective("dialogue_sarge_thugs2_barry", false));
    this.objectives.Add(new Objective("dialogue_sarge_thugs3_barry", false));
    this.objectives.Add(new Objective("dialogue_sarge_thugs4_barry", false));
    this.objectives.Add(new Objective("dialogue_sarge_storm1_barry", false));
    this.objectives.Add(new Objective("dialogue_sarge_thugs1_cate", false));
    this.objectives.Add(new Objective("dialogue_sarge_thugs2_cate", false));
    this.objectives.Add(new Objective("dialogue_sarge_thugs3_cate", false));
    this.objectives.Add(new Objective("dialogue_sarge_thugs4_cate", false));
    this.objectives.Add(new Objective("dialogue_sarge_storm1_cate", false));
    this.objectives.Add(new Objective("d4_kill_razor_cody", false));
    this.objectives.Add(new Objective("d4_kill_razor_barry", false));
    this.objectives.Add(new Objective("d4_kill_razor_cate", false));
    this.objectives.Add(new Objective("d4_spare_razor_cody", false));
    this.objectives.Add(new Objective("d4_spare_razor_barry", false));
    this.objectives.Add(new Objective("d4_spare_razor_cate", false));
    this.objectives.Add(new Objective("npc2_wife_note_given", false));
    this.objectives.Add(new Objective("npc2_wife_burried", false));
    this.objectives.Add(new Objective("npc2_hole_digged", false));
    this.objectives.Add(new Objective("npc2_wife_dragged", false));
    this.objectives.Add(new Objective("place_base_cate", false));
    this.objectives.Add(new Objective("place_base_barry", false));
    this.objectives.Add(new Objective("place_base_cody", false));
    this.objectives.Add(new Objective("place_road_cate", false));
    this.objectives.Add(new Objective("place_road_barry", false));
    this.objectives.Add(new Objective("place_road_cody", false));
    this.objectives.Add(new Objective("place_gas_station_cate", false));
    this.objectives.Add(new Objective("place_gas_station_barry", false));
    this.objectives.Add(new Objective("place_gas_station_cody", false));
    this.objectives.Add(new Objective("place_restaurant_cate", false));
    this.objectives.Add(new Objective("place_restaurant_barry", false));
    this.objectives.Add(new Objective("place_restaurant_cody", false));
    this.objectives.Add(new Objective("place_bhome_cate", false));
    this.objectives.Add(new Objective("place_bhome_barry", false));
    this.objectives.Add(new Objective("place_bhome_cody", false));
    this.objectives.Add(new Objective("place_bhome2_cody", false));
    this.objectives.Add(new Objective("place_rv_cate", false));
    this.objectives.Add(new Objective("place_rv_barry", false));
    this.objectives.Add(new Objective("place_rv_cody", false));
    this.objectives.Add(new Objective("place_rv2_cate", false));
    this.objectives.Add(new Objective("place_rv2_barry", false));
    this.objectives.Add(new Objective("place_rv2_cody", false));
    this.objectives.Add(new Objective("place_cave_cate", false));
    this.objectives.Add(new Objective("place_cave_barry", false));
    this.objectives.Add(new Objective("place_cave_cody", false));
    this.objectives.Add(new Objective("place_sp_outside_cate", false));
    this.objectives.Add(new Objective("place_sp_outside_barry", false));
    this.objectives.Add(new Objective("place_sp_outside_cody", false));
    this.objectives.Add(new Objective("place_sp_inside_cate", false));
    this.objectives.Add(new Objective("place_sp_inside_barry", false));
    this.objectives.Add(new Objective("place_sp_inside_cody", false));
    this.objectives.Add(new Objective("place_construction1_cate", false));
    this.objectives.Add(new Objective("place_construction1_barry", false));
    this.objectives.Add(new Objective("place_construction1_cody", false));
    this.objectives.Add(new Objective("place_construction2_cate", false));
    this.objectives.Add(new Objective("place_construction2_barry", false));
    this.objectives.Add(new Objective("place_construction2_cody", false));
    this.objectives.Add(new Objective("place_hunters_cate", false));
    this.objectives.Add(new Objective("place_hunters_barry", false));
    this.objectives.Add(new Objective("place_hunters_cody", false));
    this.objectives.Add(new Objective("place_hunters2_cody", false));
    this.objectives.Add(new Objective("place_airplane_cate", false));
    this.objectives.Add(new Objective("place_airplane_barry", false));
    this.objectives.Add(new Objective("place_airplane_cody", false));
    this.objectives.Add(new Objective("place_bus_cate", false));
    this.objectives.Add(new Objective("place_bus_barry", false));
    this.objectives.Add(new Objective("place_bus_cody", false));
    this.objectives.Add(new Objective("place_outpost1_cate", false));
    this.objectives.Add(new Objective("place_outpost1_barry", false));
    this.objectives.Add(new Objective("place_outpost1_cody", false));
    this.objectives.Add(new Objective("place_outpost2_cate", false));
    this.objectives.Add(new Objective("place_outpost2_barry", false));
    this.objectives.Add(new Objective("place_outpost2_cody", false));
    this.objectives.Add(new Objective("place_moon0_cate", false));
    this.objectives.Add(new Objective("place_moon0_barry", false));
    this.objectives.Add(new Objective("place_moon0_cody", false));
    this.objectives.Add(new Objective("place_moon1_cate", false));
    this.objectives.Add(new Objective("place_moon1_barry", false));
    this.objectives.Add(new Objective("place_moon1_cody", false));
    this.objectives.Add(new Objective("place_moon2_cate", false));
    this.objectives.Add(new Objective("place_moon2_barry", false));
    this.objectives.Add(new Objective("place_moon2_cody", false));
    this.objectives.Add(new Objective("place_bridge0_cate", false));
    this.objectives.Add(new Objective("place_bridge0_barry", false));
    this.objectives.Add(new Objective("place_bridge0_cody", false));
    this.objectives.Add(new Objective("place_bridge1_cate", false));
    this.objectives.Add(new Objective("place_bridge1_barry", false));
    this.objectives.Add(new Objective("place_bridge1_cody", false));
    this.objectives.Add(new Objective("place_bridge2_cate", false));
    this.objectives.Add(new Objective("place_bridge2_barry", false));
    this.objectives.Add(new Objective("place_bridge2_cody", false));
    this.objectives.Add(new Objective("place_bridge3_cate", false));
    this.objectives.Add(new Objective("place_bridge3_barry", false));
    this.objectives.Add(new Objective("place_bridge3_cody", false));
    this.objectives.Add(new Objective("d2_cold_cate", false));
    this.objectives.Add(new Objective("d2_cold_barry", false));
    this.objectives.Add(new Objective("d2_cold_cody", false));
    this.objectives.Add(new Objective("d2_hot_cate", false));
    this.objectives.Add(new Objective("d2_hot_barry", false));
    this.objectives.Add(new Objective("d2_hot_cody", false));
    this.objectives.Add(new Objective("d3_sidereal_cate", false));
    this.objectives.Add(new Objective("d3_sidereal_barry", false));
    this.objectives.Add(new Objective("d3_sidereal_cody", false));
    this.objectives.Add(new Objective("d3_thugs_cate", false));
    this.objectives.Add(new Objective("d3_thugs_barry", false));
    this.objectives.Add(new Objective("d3_thugs_cody", false));
    this.objectives.Add(new Objective("d3_storm_cate", false));
    this.objectives.Add(new Objective("d3_storm_barry", false));
    this.objectives.Add(new Objective("d3_storm_cody", false));
    this.objectives.Add(new Objective("d4_ship_cate", false));
    this.objectives.Add(new Objective("d4_ship_barry", false));
    this.objectives.Add(new Objective("d4_ship_cody", false));
    this.objectives.Add(new Objective("barry_base_welcome", false));
    this.objectives.Add(new Objective("cody_base_welcome", false));
    this.objectives.Add(new Objective("barry_base_family", false));
    this.objectives.Add(new Objective("barry_cody_first_meet", false));
    this.objectives.Add(new Objective("tutorial_tab", false));
    this.objectives.Add(new Objective("place_sidereal_auto_barry", false));
    this.objectives.Add(new Objective("place_sidereal_auto2_barry", false));
    this.objectives.Add(new Objective("place_sidereal_auto_cody", false));
    this.objectives.Add(new Objective("place_sidereal_auto2_cody", false));
    this.objectives.Add(new Objective("helicopter_cody", false));
    this.objectives.Add(new Objective("helicopter_barry", false));
    this.objectives.Add(new Objective("cody_killed_someone", false));
    this.objectives.Add(new Objective("dialogue_cody_killed_bandit", false));
    this.objectives.Add(new Objective("npc3_joined", false));
    this.objectives.Add(new Objective("npc3_alive", true));
    this.objectives.Add(new Objective("dialogue_cody_intro", false));
    this.objectives.Add(new Objective("dialogue_cody_parents", false));
    this.objectives.Add(new Objective("dialogue_cody_door_closed", false));
    this.objectives.Add(new Objective("dialogue_cody_come", false));
    this.objectives.Add(new Objective("dialogue_cody_age", false));
    this.objectives.Add(new Objective("dialogue_cody_door_opened", false));
    this.objectives.Add(new Objective("dialogue_cody_food_closed_given", false));
    this.objectives.Add(new Objective("dialogue_cody_food", false));
    this.objectives.Add(new Objective("dialogue_cody_moon", false));
    this.objectives.Add(new Objective("dialogue_cody_barry1", false));
    this.objectives.Add(new Objective("dialogue_cody_barry2", false));
    this.objectives.Add(new Objective("dialogue_cody_barry3", false));
    this.objectives.Add(new Objective("dialogue_cody_barry_dead", false));
    this.objectives.Add(new Objective("dialogue_npc3_ginger1", false));
    this.objectives.Add(new Objective("dialogue_npc3_ginger2", false));
    this.objectives.Add(new Objective("dialogue_npc3_ginger3", false));
    this.objectives.Add(new Objective("dialogue_npc3_ginger_dead", false));
    this.objectives.Add(new Objective("dialogue_npc2_ginger_dead", false));
    this.objectives.Add(new Objective("dialogue_cody_orwhat", false));
    this.objectives.Add(new Objective("dialogue_cody_tiger", false));
    this.objectives.Add(new Objective("r_sarge_plans1", false));
    this.objectives.Add(new Objective("r_sarge_plans2", false));
    this.objectives.Add(new Objective("r_sarge_plans3", false));
    this.objectives.Add(new Objective("r_sarge_wounded1", false));
    this.objectives.Add(new Objective("r_sarge_wounded_bandage", false));
    this.objectives.Add(new Objective("r_sarge_wounded_alcohol", false));
    this.objectives.Add(new Objective("r_sarge_wounded2", false));
    this.objectives.Add(new Objective("r_sarge_wounded3", false));
    this.objectives.Add(new Objective("r_sarge_first_bye", false));
    this.objectives.Add(new Objective("r_sarge_survive1", false));
    this.objectives.Add(new Objective("r_sarge_gun", false));
    this.objectives.Add(new Objective("r_sarge_ammo", false));
    this.objectives.Add(new Objective("r_sarge_catcher", false));
    this.objectives.Add(new Objective("r_sarge_catchers1", false));
    this.objectives.Add(new Objective("r_sarge_catchers2", false));
    this.objectives.Add(new Objective("r_sarge_catchers3", false));
    this.objectives.Add(new Objective("r_paul_mount1", false));
    this.objectives.Add(new Objective("r_paul_mount2", false));
    this.objectives.Add(new Objective("r_paul_intro1", false));
    this.objectives.Add(new Objective("r_paul_catchers1", false));
    this.objectives.Add(new Objective("r_paul_catchers2", false));
    this.objectives.Add(new Objective("r_paul_catchers4", false));
    this.objectives.Add(new Objective("r_paul_catchers7", false));
    this.objectives.Add(new Objective("r_paul_catchers_given", false));
    this.objectives.Add(new Objective("r_paul_come1", false));
    this.objectives.Add(new Objective("r_sarge_places1", false));
    this.objectives.Add(new Objective("r_steve_you1", false));
    this.objectives.Add(new Objective("r_steve_you5", false));
    this.objectives.Add(new Objective("r_steve_come1", false));
    this.objectives.Add(new Objective("r_steve_intro1", false));
    this.objectives.Add(new Objective("r_mark_sarge1", false));
    this.objectives.Add(new Objective("r_josh_sarge1", false));
    this.objectives.Add(new Objective("r_mark_come1", false));
    this.objectives.Add(new Objective("r_josh_come1", false));
    this.objectives.Add(new Objective("chest_tutorial", false));
    this.objectives.Add(new Objective("dream_tiger_intro", false));
    this.objectives.Add(new Objective("dream_tiger_remember", false));
    this.objectives.Add(new Objective("dream_tiger_who", false));
    this.objectives.Add(new Objective("dream_tiger_cody", false));
    this.objectives.Add(new Objective("dream_tiger_future", false));
    this.objectives.Add(new Objective("dream_maggie_intro", false));
    this.objectives.Add(new Objective("dream_maggie_remember", false));
    this.objectives.Add(new Objective("dream_maggie_who", false));
    this.objectives.Add(new Objective("dream_maggie_barry", false));
    this.objectives.Add(new Objective("dream_maggie_future", false));
    this.objectives.Add(new Objective("base_outside_dug", false));
    this.objectives.Add(new Objective("lighting_rod_installed", false));
    this.objectives.Add(new Objective("helicopter_covered", false));
    this.objectives.Add(new Objective("helicopter_covered_taped", false));
    this.objectives.Add(new Objective("barry_improved_car", false));
    this.objectives.Add(new Objective("crossroads_left", false));
    this.objectives.Add(new Objective("car_driven", false));
    this.objectives.Add(new Objective("intro_skipped", false));
    ItemsManager.im.initItems();
  }

  public bool getObjective(string id)
  {
    if (id.IndexOf("visited_") != -1)
    {
      for (int index = 0; index < this.visited.Count; ++index)
      {
        if (this.visited[index].id.Equals(id))
          return this.visited[index].state;
      }
    }
    else
    {
      for (int index = 0; index < this.objectives.Count; ++index)
      {
        if (this.objectives[index].id.Equals(id))
          return this.objectives[index].state;
      }
    }
    return false;
  }

  public int getObjectiveDetail(string id)
  {
    if (id.IndexOf("visited_") != -1)
    {
      for (int index = 0; index < this.visited.Count; ++index)
      {
        if (this.visited[index].id.Equals(id))
          return this.visited[index].detail;
      }
    }
    else
    {
      for (int index = 0; index < this.objectives.Count; ++index)
      {
        if (this.objectives[index].id.Equals(id))
          return this.objectives[index].detail;
      }
    }
    return -1;
  }

  public bool getJournal(string id)
  {
    for (int index = 0; index < this.journals.Count; ++index)
    {
      if (this.journals[index].id.Equals(id))
        return this.journals[index].state;
    }
    return false;
  }

  public int getJournalDetail(string id)
  {
    for (int index = 0; index < this.journals.Count; ++index)
    {
      if (this.journals[index].id.Equals(id))
        return this.journals[index].detail;
    }
    return -100;
  }

  public void setJournal(string id, bool state)
  {
    for (int index = 0; index < this.journals.Count; ++index)
    {
      if (this.journals[index].id.Equals(id))
        this.journals[index].state = state;
    }
  }

  public void setJournalDetail(string id, int detail)
  {
    for (int index = 0; index < this.journals.Count; ++index)
    {
      if (this.journals[index].id.Equals(id))
        this.journals[index].detail = detail;
    }
  }

  public int getObjectiveIndex(string id)
  {
    if (id.IndexOf("visited_") != -1)
    {
      for (int index = 0; index < this.visited.Count; ++index)
      {
        if (this.visited[index].id.Equals(id))
          return index;
      }
    }
    else
    {
      for (int index = 0; index < this.objectives.Count; ++index)
      {
        if (this.objectives[index].id.Equals(id))
          return index;
      }
    }
    return -1;
  }

  public void setObjective(string id, bool state)
  {
    if (id.IndexOf("visited_") != -1)
    {
      for (int index = 0; index < this.visited.Count; ++index)
      {
        if (this.visited[index].id.Equals(id))
          this.visited[index].state = state;
      }
    }
    else
    {
      for (int index = 0; index < this.objectives.Count; ++index)
      {
        if (this.objectives[index].id.Equals(id))
          this.objectives[index].state = state;
      }
    }
    JournalTexts.pickTexts(GameDataController.gd.getCurrentDay());
  }

  public bool saveIfOK(string sciezka = "")
  {
    if (sciezka == string.Empty)
      sciezka = GameDataController.CONTINUE;
    if (!this.isOKtoSave(sciezka))
      return false;
    if (sciezka != GameDataController.CONTINUE)
      ScreenShots.ss.shotAndSave(sciezka);
    this.Save(sciezka);
    return true;
  }

  public bool isOKtoSave(string sciezka)
  {
    bool flag = true;
    if (SceneManager.GetActiveScene().name == "PauseMenu" || SceneManager.GetActiveScene().name == "ChapterResults" || SceneManager.GetActiveScene().name == "LocationBugDeath" || SceneManager.GetActiveScene().name == "LocationCh2Death" || SceneManager.GetActiveScene().name == "PauseMenu" || SceneManager.GetActiveScene().name == "InfoLocation" || SceneManager.GetActiveScene().name == "sky_paralax" || SceneManager.GetActiveScene().name == "LocationDesertTitle" || SceneManager.GetActiveScene().name == "DEMO_START" || SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "LocationTent2" || SceneManager.GetActiveScene().name == "Ending1" || SceneManager.GetActiveScene().name == "Ending2" || SceneManager.GetActiveScene().name == "Ending3" || SceneManager.GetActiveScene().name == "Ending4" || SceneManager.GetActiveScene().name == "Ending5" || SceneManager.GetActiveScene().name == "Credits" || SceneManager.GetActiveScene().name == "SonicRemote" || SceneManager.GetActiveScene().name == "Dream3B" || SceneManager.GetActiveScene().name == "FontSelector" || SceneManager.GetActiveScene().name == "LocationMap")
      flag = false;
    if (GameDataController.gd.getObjective("moon_david_sleeps"))
      flag = false;
    if (!DialogueController.dc.hidden && sciezka == GameDataController.CONTINUE)
      flag = false;
    if (DialogueController.dc.talking && sciezka == GameDataController.CONTINUE)
      flag = false;
    if (sciezka == GameDataController.CONTINUE && (PlayerController.pc.dialogue != PlayerController.DialogueState.NONE || Timeline.t.actions != null && Timeline.t.actions.Count > 0))
      flag = false;
    if (SceneManager.GetActiveScene().name == "SaveMenu" && sciezka.IndexOf("autosave") != -1)
      flag = false;
    return flag;
  }

  public void setObjectiveDetail(string id, int detail)
  {
    if (id.IndexOf("visited_") != -1)
    {
      for (int index = 0; index < this.visited.Count; ++index)
      {
        if (this.visited[index].id.Equals(id))
          this.visited[index].detail = detail;
      }
    }
    else
    {
      for (int index = 0; index < this.objectives.Count; ++index)
      {
        if (this.objectives[index].id.Equals(id))
          this.objectives[index].detail = detail;
      }
    }
    if (id.IndexOf("chitchat") != -1)
      return;
    JournalTexts.pickTexts(GameDataController.gd.getCurrentDay());
  }

  public ItemData getItemData(string id)
  {
    for (int index = 0; index < this.items.Count; ++index)
    {
      if (this.items[index].id.Equals(id))
        return this.items[index];
    }
    return (ItemData) null;
  }

  public void autoSave() => this.saveIfOK(GameDataController.AUTOSAVE);

  public void PersistentSave()
  {
    string str = "core_save";
    BinaryFormatter binaryFormatter = new BinaryFormatter();
    FileStream fileStream = File.Open(Application.persistentDataPath + "/" + str, FileMode.OpenOrCreate);
    PersistentData persistentData = new PersistentData();
    persistentData.chapter1_locust = GameDataController.persistentData.chapter1_locust;
    persistentData.chapter1_gas = GameDataController.persistentData.chapter1_gas;
    persistentData.chapter1_spiders = GameDataController.persistentData.chapter1_spiders;
    persistentData.chapter2_cold = GameDataController.persistentData.chapter2_cold;
    persistentData.chapter2_hot = GameDataController.persistentData.chapter2_hot;
    persistentData.chapter3_bandits = GameDataController.persistentData.chapter3_bandits;
    persistentData.chapter3_thunderstorm = GameDataController.persistentData.chapter3_thunderstorm;
    persistentData.chapter4_air = GameDataController.persistentData.chapter4_air;
    persistentData.chapter4_fuel = GameDataController.persistentData.chapter4_fuel;
    persistentData.disc_barry = GameDataController.persistentData.disc_barry;
    persistentData.disc_cody = GameDataController.persistentData.disc_cody;
    persistentData.kong_car = GameDataController.persistentData.kong_car;
    persistentData.kong_disk = GameDataController.persistentData.kong_disk;
    persistentData.kong_game = GameDataController.persistentData.kong_game;
    persistentData.custom_unlocked = GameDataController.persistentData.custom_unlocked;
    persistentData.achievements = new List<Objective>();
    for (int index = 0; index < GameDataController.persistentData.achievements.Count; ++index)
      persistentData.achievements.Add(new Objective(GameDataController.persistentData.achievements[index].id, GameDataController.persistentData.achievements[index].state));
    binaryFormatter.Serialize((Stream) fileStream, (object) persistentData);
    fileStream.Close();
  }

  public void PersistentLoad()
  {
    string str = "core_save";
    if (File.Exists(Application.persistentDataPath + "/" + str))
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      FileStream fileStream1 = File.Open(Application.persistentDataPath + "/" + str, FileMode.OpenOrCreate);
      FileStream fileStream2 = fileStream1;
      PersistentData persistentData = (PersistentData) binaryFormatter.Deserialize((Stream) fileStream2);
      GameDataController.persistentData.chapter1_locust = persistentData.chapter1_locust;
      GameDataController.persistentData.chapter1_gas = persistentData.chapter1_gas;
      GameDataController.persistentData.chapter1_spiders = persistentData.chapter1_spiders;
      GameDataController.persistentData.chapter2_cold = persistentData.chapter2_cold;
      GameDataController.persistentData.chapter2_hot = persistentData.chapter2_hot;
      GameDataController.persistentData.chapter3_bandits = persistentData.chapter3_bandits;
      GameDataController.persistentData.chapter3_thunderstorm = persistentData.chapter3_thunderstorm;
      GameDataController.persistentData.chapter4_air = persistentData.chapter4_air;
      GameDataController.persistentData.chapter4_fuel = persistentData.chapter4_fuel;
      GameDataController.persistentData.disc_barry = persistentData.disc_barry;
      GameDataController.persistentData.disc_cody = persistentData.disc_cody;
      GameDataController.persistentData.kong_car = persistentData.kong_car;
      GameDataController.persistentData.kong_disk = persistentData.kong_disk;
      GameDataController.persistentData.kong_game = persistentData.kong_game;
      GameDataController.persistentData.custom_unlocked = persistentData.custom_unlocked;
      GameDataController.persistentData.achievements = new List<Objective>();
      if (persistentData.achievements == null)
      {
        this.initPersistantAchieves();
      }
      else
      {
        for (int index = 0; index < persistentData.achievements.Count; ++index)
          GameDataController.persistentData.achievements.Add(new Objective(persistentData.achievements[index].id, persistentData.achievements[index].state));
      }
      fileStream1.Close();
    }
    else
    {
      GameDataController.persistentData = new PersistentData();
      GameDataController.persistentData.chapter1_locust = false;
      GameDataController.persistentData.chapter1_gas = false;
      GameDataController.persistentData.chapter1_spiders = false;
      GameDataController.persistentData.chapter2_cold = false;
      GameDataController.persistentData.chapter2_hot = false;
      GameDataController.persistentData.chapter3_bandits = false;
      GameDataController.persistentData.chapter3_thunderstorm = false;
      GameDataController.persistentData.chapter4_air = false;
      GameDataController.persistentData.chapter4_fuel = false;
      GameDataController.persistentData.disc_barry = false;
      GameDataController.persistentData.disc_cody = false;
      GameDataController.persistentData.kong_car = false;
      GameDataController.persistentData.kong_disk = false;
      GameDataController.persistentData.kong_game = false;
      GameDataController.persistentData.custom_unlocked = false;
      this.initPersistantAchieves();
      this.PersistentSave();
    }
  }

  public void initPersistantAchieves()
  {
    GameDataController.persistentData.achievements = new List<Objective>();
    GameDataController.persistentData.achievements.Add(new Objective("DAY_1", false));
    GameDataController.persistentData.achievements.Add(new Objective("DAY_2", false));
    GameDataController.persistentData.achievements.Add(new Objective("DAY_3", false));
    GameDataController.persistentData.achievements.Add(new Objective("DAY_4", false));
    GameDataController.persistentData.achievements.Add(new Objective("ENDING_1", false));
    GameDataController.persistentData.achievements.Add(new Objective("ENDING_2", false));
    GameDataController.persistentData.achievements.Add(new Objective("ENDING_3", false));
    GameDataController.persistentData.achievements.Add(new Objective("P_LOCUST", false));
    GameDataController.persistentData.achievements.Add(new Objective("P_GAS", false));
    GameDataController.persistentData.achievements.Add(new Objective("P_SPIDERS", false));
    GameDataController.persistentData.achievements.Add(new Objective("P_COLD", false));
    GameDataController.persistentData.achievements.Add(new Objective("P_HEAT", false));
    GameDataController.persistentData.achievements.Add(new Objective("P_BANDITS", false));
    GameDataController.persistentData.achievements.Add(new Objective("P_STORM", false));
    GameDataController.persistentData.achievements.Add(new Objective("P_AIR", false));
    GameDataController.persistentData.achievements.Add(new Objective("P_FUEL", false));
    GameDataController.persistentData.achievements.Add(new Objective("S_GRAVE", false));
    GameDataController.persistentData.achievements.Add(new Objective("S_BIRD", false));
    GameDataController.persistentData.achievements.Add(new Objective("S_TREASURE", false));
    GameDataController.persistentData.achievements.Add(new Objective("S_SNOWMAN", false));
    GameDataController.persistentData.achievements.Add(new Objective("S_TOUR", false));
    GameDataController.persistentData.achievements.Add(new Objective("S_FAMILY", false));
    GameDataController.persistentData.achievements.Add(new Objective("S_WOLF", false));
    GameDataController.persistentData.achievements.Add(new Objective("S_WALKING", false));
    GameDataController.persistentData.achievements.Add(new Objective("S_PYRO", false));
  }

  public void Save(string path)
  {
    BinaryFormatter binaryFormatter = new BinaryFormatter();
    FileStream fileStream1 = File.Open(Application.persistentDataPath + "/" + path, FileMode.OpenOrCreate);
    MonoBehaviour.print((object) ("SAVING GAME...... " + path + " " + SceneManager.GetActiveScene().name));
    SaveData saveData1 = new SaveData();
    saveData1.objectives = GameDataController.gd.objectives;
    saveData1.journals = GameDataController.gd.journals;
    saveData1.visited = GameDataController.gd.visited;
    saveData1.items = GameDataController.gd.items;
    saveData1.gameTime = GameDataController.gd.gameTime;
    saveData1.timeLimit = GameDataController.gd.timeLimit;
    saveData1.gameDay = GameDataController.gd.getCurrentDay();
    saveData1.dateTime = DateTime.Now;
    saveData1.traveledTime = GameDataController.gd.traveledTime;
    saveData1.workedTime = GameDataController.gd.workedTime;
    saveData1.journalEntries = this.journalEntries;
    GameDataController.gd.location = SceneManager.GetActiveScene().name;
    if (GameDataController.gd.location != "SaveMenu")
    {
      saveData1.location = GameDataController.gd.location;
      saveData1.usedSpawner = GameDataController.gd.usedSpawner;
      GameDataController.gd.currentX = (int) PlayerController.wc.currentXY.x;
      GameDataController.gd.currentY = (int) PlayerController.wc.currentXY.y;
    }
    else
    {
      saveData1.location = GameDataController.gd.previousLocation;
      saveData1.usedSpawner = GameDataController.gd.usedSpawner;
      GameDataController.gd.currentX = GameDataController.gd.previousX;
      GameDataController.gd.currentY = GameDataController.gd.previousY;
    }
    saveData1.currentX = GameDataController.gd.currentX;
    saveData1.currentY = GameDataController.gd.currentY;
    saveData1.previousX = GameDataController.gd.previousX;
    saveData1.previousY = GameDataController.gd.previousY;
    saveData1.previousLocation = GameDataController.gd.previousLocation;
    saveData1.finishingLocation = GameDataController.gd.finishingLocation;
    FileStream fileStream2 = fileStream1;
    SaveData saveData2 = saveData1;
    binaryFormatter.Serialize((Stream) fileStream2, (object) saveData2);
    fileStream1.Close();
    MonoBehaviour.print((object) "FILE SAVED");
  }

  public void politeLoad(string path) => CurtainController.cc.fadeOut("LOAD", animation: path);

  public void tryLoad(string path, bool autosaveInstead = false)
  {
    GameDataController.gd.newGame();
    if (GameDataController.gd.Load(path))
      return;
    if (autosaveInstead)
    {
      GameDataController.gd.Load("autosave0");
    }
    else
    {
      GameDataController.gd.Load(path);
      PlayerController.pc.spawnName = "InfoExit";
      CurtainController.cc.fadeOut("LocationDreamBugs", WalkController.Direction.N);
    }
  }

  public bool checkSave(string path) => File.Exists(Application.persistentDataPath + "/" + path);

  public SaveData getSavePreview(string path)
  {
    if (!File.Exists(Application.persistentDataPath + "/" + path))
      return (SaveData) null;
    BinaryFormatter binaryFormatter = new BinaryFormatter();
    FileStream fileStream1 = File.Open(Application.persistentDataPath + "/" + path, FileMode.Open);
    FileStream fileStream2 = fileStream1;
    SaveData saveData = (SaveData) binaryFormatter.Deserialize((Stream) fileStream2);
    fileStream1.Close();
    return saveData;
  }

  public bool Load(string path)
  {
    MonoBehaviour.print((object) ("Loading file " + Application.persistentDataPath + "/" + path));
    if (!File.Exists(Application.persistentDataPath + "/" + path))
    {
      MonoBehaviour.print((object) "FILE NOT FOUND - NO FILE LOADED");
      return false;
    }
    if ((UnityEngine.Object) InventoryController.ic != (UnityEngine.Object) null && this.items != null)
      InventoryController.ic.clearInventory();
    BinaryFormatter binaryFormatter = new BinaryFormatter();
    FileStream fileStream1 = File.Open(Application.persistentDataPath + "/" + path, FileMode.Open);
    FileStream fileStream2 = fileStream1;
    SaveData saveData = (SaveData) binaryFormatter.Deserialize((Stream) fileStream2);
    GameDataController.gd.currentX = saveData.currentX;
    GameDataController.gd.currentY = saveData.currentY;
    GameDataController.gd.previousX = saveData.currentX;
    GameDataController.gd.previousY = saveData.currentY;
    GameDataController.gd.location = saveData.location;
    GameDataController.gd.usedSpawner = saveData.usedSpawner;
    GameDataController.gd.journalEntries = saveData.journalEntries;
    PlayerController.pc.spawnName = "previous";
    for (int index = 0; index < saveData.visited.Count; ++index)
    {
      GameDataController.gd.setObjective(saveData.visited[index].id, saveData.visited[index].state);
      GameDataController.gd.setObjectiveDetail(saveData.visited[index].id, saveData.visited[index].detail);
    }
    for (int index = 0; index < saveData.objectives.Count; ++index)
    {
      GameDataController.gd.setObjective(saveData.objectives[index].id, saveData.objectives[index].state);
      GameDataController.gd.setObjectiveDetail(saveData.objectives[index].id, saveData.objectives[index].detail);
    }
    for (int index = 0; index < saveData.journals.Count; ++index)
    {
      GameDataController.gd.setJournal(saveData.journals[index].id, saveData.journals[index].state);
      GameDataController.gd.setJournalDetail(saveData.journals[index].id, saveData.journals[index].detail);
    }
    for (int index = 0; index < saveData.items.Count; ++index)
    {
      GameDataController.gd.getItemData(saveData.items[index].id).droppedLocation = saveData.items[index].droppedLocation;
      GameDataController.gd.getItemData(saveData.items[index].id).locX = saveData.items[index].locX;
      GameDataController.gd.getItemData(saveData.items[index].id).locY = saveData.items[index].locY;
    }
    GameDataController.gd.gameTime = saveData.gameTime;
    GameDataController.gd.timeLimit = saveData.timeLimit;
    GameDataController.gd.traveledTime = saveData.traveledTime;
    GameDataController.gd.workedTime = saveData.workedTime;
    GameDataController.gd.finishingLocation = saveData.finishingLocation;
    ItemsManager.im.initItems();
    if (GameDataController.gd.currentX != 0 && GameDataController.gd.currentY != 0)
    {
      PlayerController.wc.currentXY.x = (float) GameDataController.gd.currentX;
      PlayerController.wc.currentXY.y = (float) GameDataController.gd.currentY;
    }
    MonoBehaviour.print((object) ("SAVED SCENE : " + GameDataController.gd.location));
    fileStream1.Close();
    GameDataController.gd.previousLocation = string.Empty;
    MonoBehaviour.print((object) "FILE LOADED");
    ItemsManager.im.initItems();
    InventoryController.ic.maxCapacity = 30;
    if (GameDataController.gd.getObjectiveDetail("day1_complete") == 1)
      InventoryController.ic.maxCapacity += 5;
    if (GameDataController.gd.getObjectiveDetail("day2_complete") == 1)
      InventoryController.ic.maxCapacity += 5;
    if (GameDataController.gd.getObjectiveDetail("day3_complete") == 1)
      InventoryController.ic.maxCapacity += 5;
    JournalTexts.pickTexts(GameDataController.gd.getCurrentDay());
    if (GameDataController.gd.location == null || GameDataController.gd.location.Length <= 0 || SceneManager.GetActiveScene().name.Equals(GameDataController.gd.location))
      return false;
    MonoBehaviour.print((object) ("LOADING SCENE : " + GameDataController.gd.location));
    CurtainController.cc.loadScene(GameDataController.gd.location);
    return true;
  }

  public int getCurrentDay()
  {
    if (!GameDataController.gd.getObjective("day1_complete"))
      return 1;
    if (!GameDataController.gd.getObjective("day2_complete"))
      return 2;
    if (!GameDataController.gd.getObjective("day3_complete"))
      return 3;
    return !GameDataController.gd.getObjective("day4_complete") ? 4 : 5;
  }
}
