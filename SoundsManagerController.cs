﻿// Decompiled with JetBrains decompiler
// Type: SoundsManagerController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class SoundsManagerController : MonoBehaviour
{
  public static SoundsManagerController sm;
  public AudioClip door_open_01;
  public AudioClip door_open_02;
  public AudioClip door_close_01;
  public AudioClip door_close_02;
  public AudioClip break_window;
  public AudioClip page_turn_01;
  public AudioClip page_turn_02;
  public AudioClip page_turn_03;
  public AudioClip page_turn_04;
  public AudioClip book_close;
  public AudioClip locker_01;
  public AudioClip locker_locked;
  public AudioClip crowbar_pry_open;
  public AudioClip hay_rustle;
  public AudioClip duct_tape_use;
  public AudioClip button_click;
  public AudioClip button_click2;
  public AudioClip lever1;
  public AudioClip lever2;
  public AudioClip hydra1;
  public AudioClip hydra2;
  public AudioClip metal_bang1;
  public AudioClip engine_run;
  public AudioClip engine_start;
  public AudioClip engine_die;
  public AudioClip engine_fail;
  public AudioClip liquid_spill;
  public AudioClip liquid_pour;
  public AudioClip liquid_pour_med;
  public AudioClip liquid_pour_small;
  public AudioClip valve;
  public AudioClip wood_snap;
  public AudioClip door_lock_unlock;
  public AudioClip door_locked;
  public AudioClip flies;
  public AudioClip flies2;
  public AudioClip gas;
  public AudioClip rifle_shoot;
  public AudioClip rifle_shoot_silenced;
  public AudioClip metal_thud;
  public AudioClip metal_thud2;
  public AudioClip body_thud;
  public AudioClip body_slam;
  public AudioClip generic_hit;
  public AudioClip bird_fly;
  public AudioClip crow1;
  public AudioClip crow2;
  public AudioClip crow3;
  public AudioClip hiss;
  public AudioClip plates_break;
  public AudioClip heli_fly;
  public AudioClip heli_crash;
  public AudioClip metal_creak1;
  public AudioClip hose;
  public AudioClip screw;
  public AudioClip digger;
  public AudioClip metal_locked_1;
  public AudioClip metal_locked_2;
  public AudioClip metal_locked_3;
  public AudioClip cabinet_1;
  public AudioClip wood_crack_1;
  public AudioClip wood_crack_2;
  public AudioClip wood_crack_3;
  public AudioClip fire_start;
  public AudioClip rockbutton;
  public AudioClip necklace;
  public AudioClip knife;
  public AudioClip fridge;
  public AudioClip trunk_open;
  public AudioClip trunk_close;
  public AudioClip car_start;
  public AudioClip car_drive;
  public AudioClip car_drive2;
  public AudioClip car_stop;
  public AudioClip car_open;
  public AudioClip car_close;
  public AudioClip car_close2;
  public AudioClip car_close3;
  public AudioClip cabinet_open;
  public AudioClip pull_recoil;
  public AudioClip heater2;
  public AudioClip fan;
  public AudioClip ac;
  public AudioClip heater_hiss;
  public AudioClip pyk;
  public AudioClip pyk2;
  public AudioClip blizzard;
  public AudioClip double_bang;
  public AudioClip rv_engine_loop;
  public AudioClip rv_engine_start;
  public AudioClip rv_engine_fail;
  public AudioClip door_creak_1;
  public AudioClip door_creak_2;
  public AudioClip door_creak_3;
  public AudioClip door_creak_open;
  public AudioClip rock_hit_1;
  public AudioClip rock_hit_2;
  public AudioClip rock_hit_3;
  public AudioClip rock_rumble_1;
  public AudioClip rock_rumble_2;
  public AudioClip rock_rumble_3;
  public AudioClip nailed;
  public AudioClip sand_pour1;
  public AudioClip sand_pour2;
  public AudioClip sand_pour3;
  public AudioClip sand_pour4;
  public AudioClip sand_big;
  public AudioClip push;
  public AudioClip motorbikes;
  public AudioClip motor_incoming;
  public AudioClip vomit;
  public AudioClip break_glass_big;
  public AudioClip metal_moan;
  public AudioClip metal_moan2;
  public AudioClip metal_door_open;
  public AudioClip metal_door_closed;
  public AudioClip revolver;
  public AudioClip repair;
  public AudioClip buzz;
  public AudioClip neon_on;
  public AudioClip neon_off;
  public AudioClip rope;
  public AudioClip electric;
  public AudioClip mixer;
  public AudioClip elevator_away;
  public AudioClip elevator_come;
  public AudioClip elevator_ding;
  public AudioClip elevator_door;
  public AudioClip small_powerup;
  public AudioClip small_powerdown;
  public AudioClip computer_click1;
  public AudioClip computer_click2;
  public AudioClip fail1;
  public AudioClip fingerscan;
  public AudioClip auto_unlock;
  public AudioClip metal_door_locked;
  public AudioClip spotlight;
  public AudioClip hdd1;
  public AudioClip hdd2;
  public AudioClip hdd3;
  public AudioClip hdd4;
  public AudioClip hdd5;
  public AudioClip hdd6;
  public AudioClip hdd7;
  public AudioClip hdd8;
  public AudioClip hdd9;
  public AudioClip hdd10;
  public AudioClip hdd11;
  public AudioClip wind1;
  public AudioClip slidedoor;
  public AudioClip rumble_2s;
  public AudioClip rumble_4s;
  public AudioClip rumble_8s;
  public AudioClip comp_beeps1;
  public AudioClip comp_beeps2;
  public AudioClip comp_beeps3;
  public AudioClip comp_beeps4;
  public AudioClip comp_beeps5;
  public AudioClip comp_beeps6;
  public AudioClip radarbeep;
  public AudioClip toolbox1;
  public AudioClip toolbox2;
  public AudioClip ship_drag;
  public AudioClip ship_drag2;
  public AudioClip pisk;
  public AudioClip jet_mono;
  public AudioClip jet2_mono;
  public AudioClip door_slide;
  public AudioClip power_up_small;
  public AudioClip mouse_click;
  public AudioClip denied;
  public AudioClip power_down_small;
  public AudioClip lamp_on;
  public AudioClip engine_wrong;
  public AudioClip big_door_open;
  public AudioClip chorus1;
  public AudioClip chorus2;
  public AudioClip low_rumble;
  public AudioClip low_rumble2;
  public AudioClip rrusty_creak_1;
  public AudioClip rrusty_creak_2;
  public AudioClip rrusty_creak_3;
  public AudioClip rrusty_creak_4;
  public AudioClip fast_creak_1;
  public AudioClip fast_creak_2;
  public AudioClip fast_creak_3;
  public AudioClip slide_1;
  public AudioClip slide_2;
  public AudioClip slide_3;
  public AudioClip unlock;
  public AudioClip keyboard;
  public AudioClip pods;
  public AudioClip power_up_big;
  public AudioClip power_down_big;
  public AudioClip glass_crack_1;
  public AudioClip glass_crack_2;
  public AudioClip dumdumdum;
  public AudioClip disk;
  public AudioClip thunder1;
  public AudioClip thunder2;
  public AudioClip thunder3;
  public AudioClip thunder4;
  public AudioClip thunder5;
  public AudioClip rain_short;
  public AudioClip flashlight;
  public AudioClip ui_hover;
  public AudioClip ui_click;
  public AudioClip pc_noise;
  public AudioClip underground_1;
  public AudioClip ambient_fire_1;
  public AudioClip ambient_wind_1;
  public AudioClip ambient_wind_metal;
  public AudioClip ambient_wind_3;
  public AudioClip ambient_wind_flag;
  public AudioClip ambient_wind_metal_inside;
  public AudioClip ambient_wind_forest;
  public AudioClip ambient_wind_wood;
  public AudioClip ambient_ship_crashed;
  public AudioClip ambient_sparks;
  public AudioClip suit_breathing;
  public AudioClip moon;
  public AudioClip alert1;
  public AudioClip alert2;
  public AudioClip music_explore_1a;
  public AudioClip music_explore_2a;
  public AudioClip music_explore_3a;
  public AudioClip music_explore_4a;
  public AudioClip music_explore_5a;
  public AudioClip music_explore_6a;
  public AudioClip music_attack;
  public AudioClip music_attack2;
  public AudioClip music_success;
  public AudioClip music_sorrow;
  public AudioClip music_game_over;
  public AudioClip music_scare_loop;
  public AudioClip music_action_loop;
  public AudioClip music_scare;
  public AudioClip music_emotional;
  public AudioClip music_main;
  public AudioClip music_mystery;
  public int loadPerFrame = 1;
  public int loadedThisFrame;
  public bool secondLoop;
  public int elementsToLoad;
  public int loadedElements;
  public TextFieldController counter;
  public bool ALL_LOADED;
  public AudioSource auxASPlayer;

  private void Awake()
  {
    if ((Object) SoundsManagerController.sm == (Object) null)
    {
      Object.DontDestroyOnLoad((Object) this.gameObject);
      SoundsManagerController.sm = this;
    }
    else
    {
      if (!((Object) SoundsManagerController.sm != (Object) this))
        return;
      Object.Destroy((Object) this.gameObject);
    }
  }

  private void Start()
  {
    this.auxASPlayer = this.gameObject.AddComponent<AudioSource>();
    this.gameObject.AddComponent<AudioReverbFilter>();
    this.secondLoop = false;
    this.elementsToLoad = 0;
    this.loadedElements = 0;
    if (!(bool) (Object) this.counter)
      return;
    this.counter.maxWidth = 300;
  }

  private void Update()
  {
    if (this.ALL_LOADED)
      return;
    this.loadedElements = 0;
    if (this.elementsToLoad > 0)
      this.secondLoop = true;
    this.loadedThisFrame = 0;
    this.loadSounds();
    if (!(bool) (Object) this.counter || this.elementsToLoad <= 0)
      return;
    string text = string.Empty;
    for (int index = 0; index < 50; ++index)
    {
      int num = (int) Mathf.Round((float) (50.0 * ((double) this.loadedElements / (double) this.elementsToLoad)));
      text = index > num ? text + "·" : text + "|";
    }
    this.counter.viewText(text, quick: true, instant: true, mwidth: 200, r: 0.25f, g: 0.25f, b: 0.25f);
  }

  private void loadSounds()
  {
    this.door_open_01 = this.loadSound(this.door_open_01, "Sounds/Env/door_open_01");
    this.door_open_02 = this.loadSound(this.door_open_02, "Sounds/Env/door_open_02");
    this.door_close_01 = this.loadSound(this.door_close_01, "Sounds/Env/door_close_01");
    this.door_close_02 = this.loadSound(this.door_close_02, "Sounds/Env/door_close_02");
    this.break_window = this.loadSound(this.break_window, "Sounds/Env/break_window");
    this.music_action_loop = this.loadSound(this.music_action_loop, "Sounds/Music/SW_Cue13_NightmareSeqLoop1");
    this.music_scare_loop = this.loadSound(this.music_scare_loop, "Sounds/Music/SW_Cue13_NightmareSeqLoop3");
    this.page_turn_01 = this.loadSound(this.page_turn_01, "Sounds/Env/page_turn_01");
    this.page_turn_02 = this.loadSound(this.page_turn_02, "Sounds/Env/page_turn_02");
    this.page_turn_03 = this.loadSound(this.page_turn_03, "Sounds/Env/page_turn_03");
    this.page_turn_04 = this.loadSound(this.page_turn_04, "Sounds/Env/page_turn_04");
    this.book_close = this.loadSound(this.book_close, "Sounds/Env/book_close");
    this.locker_01 = this.loadSound(this.locker_01, "Sounds/Env/locker_01");
    this.locker_locked = this.loadSound(this.locker_locked, "Sounds/Env/locker_locked");
    this.crowbar_pry_open = this.loadSound(this.crowbar_pry_open, "Sounds/Env/crowbar_pry_open");
    this.music_explore_5a = this.loadSound(this.music_explore_5a, "Sounds/Music/SW_Cue5_Inside_mixed");
    this.music_explore_6a = this.loadSound(this.music_explore_6a, "Sounds/Music/SW_Cue6_Alone_10_17");
    this.hay_rustle = this.loadSound(this.hay_rustle, "Sounds/Env/hay_rustle");
    this.duct_tape_use = this.loadSound(this.duct_tape_use, "Sounds/Env/duct_tape_use");
    this.button_click = this.loadSound(this.button_click, "Sounds/Env/button_click");
    this.button_click2 = this.loadSound(this.button_click2, "Sounds/Env/button_click2");
    this.engine_die = this.loadSound(this.engine_die, "Sounds/Env/generator_end");
    this.engine_run = this.loadSound(this.engine_run, "Sounds/Env/generator");
    this.engine_fail = this.loadSound(this.engine_fail, "Sounds/Env/generator_fail");
    this.engine_start = this.loadSound(this.engine_start, "Sounds/Env/generator_start");
    this.liquid_pour = this.loadSound(this.liquid_pour, "Sounds/Env/liquid_pour_container");
    this.liquid_pour_med = this.loadSound(this.liquid_pour_med, "Sounds/Env/liquid_pour_med");
    this.lever1 = this.loadSound(this.lever1, "Sounds/Env/lever1");
    this.lever2 = this.loadSound(this.lever2, "Sounds/Env/lever2");
    this.hydra1 = this.loadSound(this.hydra1, "Sounds/Env/hydra1");
    this.hydra2 = this.loadSound(this.hydra2, "Sounds/Env/hydra2");
    this.metal_bang1 = this.loadSound(this.metal_bang1, "Sounds/Env/metal_bang1");
    this.liquid_pour_small = this.loadSound(this.liquid_pour_small, "Sounds/Env/pour_small");
    this.liquid_spill = this.loadSound(this.liquid_spill, "Sounds/Env/liquid_spill");
    this.valve = this.loadSound(this.valve, "Sounds/Env/valve");
    this.wood_snap = this.loadSound(this.wood_snap, "Sounds/Env/wood_snap");
    this.door_lock_unlock = this.loadSound(this.door_lock_unlock, "Sounds/Env/door_lock_unlock");
    this.door_locked = this.loadSound(this.door_locked, "Sounds/Env/door_locked");
    this.door_lock_unlock = this.loadSound(this.door_lock_unlock, "Sounds/Env/door_open_01");
    this.music_explore_1a = this.loadSound(this.music_explore_1a, "Sounds/Music/SW_Cue1_Wasteland_mixed");
    this.music_explore_2a = this.loadSound(this.music_explore_2a, "Sounds/Music/SW_Cue2_Investigation_mixed10_17");
    this.flies = this.loadSound(this.flies, "Sounds/Env/flies");
    this.flies2 = this.loadSound(this.flies2, "Sounds/Env/flies2");
    this.gas = this.loadSound(this.gas, "Sounds/Env/gas");
    this.rifle_shoot = this.loadSound(this.rifle_shoot, "Sounds/Env/rifle_shoot");
    this.rifle_shoot_silenced = this.loadSound(this.rifle_shoot_silenced, "Sounds/Env/rifle_shoot_silenced");
    this.metal_thud = this.loadSound(this.metal_thud, "Sounds/Env/metal_thud");
    this.metal_thud2 = this.loadSound(this.metal_thud2, "Sounds/Env/metal_thud2");
    this.body_thud = this.loadSound(this.body_thud, "Sounds/Env/body_thud");
    this.body_slam = this.loadSound(this.body_slam, "Sounds/Env/body_slam");
    this.generic_hit = this.loadSound(this.generic_hit, "Sounds/Env/generic_hit");
    this.bird_fly = this.loadSound(this.bird_fly, "Sounds/Env/bird_fly");
    this.crow1 = this.loadSound(this.crow1, "Sounds/Env/crow1");
    this.crow2 = this.loadSound(this.crow2, "Sounds/Env/crow2");
    this.crow3 = this.loadSound(this.crow3, "Sounds/Env/crow3");
    this.hiss = this.loadSound(this.hiss, "Sounds/Env/hiss");
    this.plates_break = this.loadSound(this.plates_break, "Sounds/Env/plates_break");
    this.heli_fly = this.loadSound(this.heli_fly, "Sounds/Env/heli_fly");
    this.heli_crash = this.loadSound(this.heli_crash, "Sounds/Env/heli_crash");
    this.metal_creak1 = this.loadSound(this.metal_creak1, "Sounds/Env/metal_creak1");
    this.metal_moan = this.loadSound(this.metal_moan, "Sounds/Env/metal_moan");
    this.metal_moan2 = this.loadSound(this.metal_moan2, "Sounds/Env/metal_moan2");
    this.metal_door_open = this.loadSound(this.metal_door_open, "Sounds/Env/metal_door_open");
    this.metal_door_closed = this.loadSound(this.metal_door_closed, "Sounds/Env/metal_door_closed");
    this.music_explore_3a = this.loadSound(this.music_explore_3a, "Sounds/Music/SW_Cue3_Exploration_mixed");
    this.music_explore_4a = this.loadSound(this.music_explore_4a, "Sounds/Music/SW_Cue4_CoveringGround_mixed");
    this.hose = this.loadSound(this.hose, "Sounds/Items/hose");
    this.screw = this.loadSound(this.screw, "Sounds/Env/screw");
    this.repair = this.loadSound(this.repair, "Sounds/Env/repair");
    this.buzz = this.loadSound(this.buzz, "Sounds/Env/buzz");
    this.revolver = this.loadSound(this.revolver, "Sounds/Items/revolver");
    this.rope = this.loadSound(this.rope, "Sounds/Items/net");
    this.neon_off = this.loadSound(this.neon_off, "Sounds/Env/neon_off");
    this.neon_on = this.loadSound(this.neon_on, "Sounds/Env/neon_on");
    this.electric = this.loadSound(this.electric, "Sounds/Env/electric");
    this.mixer = this.loadSound(this.mixer, "Sounds/Env/mixer");
    this.elevator_away = this.loadSound(this.elevator_away, "Sounds/Env/elevator_away");
    this.elevator_come = this.loadSound(this.elevator_come, "Sounds/Env/elevator_come");
    this.elevator_ding = this.loadSound(this.elevator_ding, "Sounds/Env/elevator_ding");
    this.elevator_door = this.loadSound(this.elevator_door, "Sounds/Env/elevator_door");
    this.small_powerup = this.loadSound(this.small_powerup, "Sounds/Env/small_powerup");
    this.small_powerdown = this.loadSound(this.small_powerdown, "Sounds/Env/small_powerdown");
    this.computer_click1 = this.loadSound(this.computer_click1, "Sounds/Env/computer_click1");
    this.computer_click2 = this.loadSound(this.computer_click2, "Sounds/Env/computer_click2");
    this.fail1 = this.loadSound(this.fail1, "Sounds/Env/fail1");
    this.fingerscan = this.loadSound(this.fingerscan, "Sounds/Env/fingerscan");
    this.metal_door_locked = this.loadSound(this.metal_door_locked, "Sounds/Env/metal_door_locked");
    this.spotlight = this.loadSound(this.spotlight, "Sounds/Env/spotlight");
    this.auto_unlock = this.loadSound(this.auto_unlock, "Sounds/Env/auto_unlock");
    this.hdd1 = this.loadSound(this.hdd1, "Sounds/Env/hdd1");
    this.hdd2 = this.loadSound(this.hdd2, "Sounds/Env/hdd2");
    this.hdd3 = this.loadSound(this.hdd3, "Sounds/Env/hdd3");
    this.hdd4 = this.loadSound(this.hdd4, "Sounds/Env/hdd4");
    this.hdd5 = this.loadSound(this.hdd5, "Sounds/Env/hdd5");
    this.hdd6 = this.loadSound(this.hdd6, "Sounds/Env/hdd6");
    this.hdd7 = this.loadSound(this.hdd7, "Sounds/Env/hdd7");
    this.hdd8 = this.loadSound(this.hdd8, "Sounds/Env/hdd8");
    this.hdd9 = this.loadSound(this.hdd9, "Sounds/Env/hdd9");
    this.hdd10 = this.loadSound(this.hdd10, "Sounds/Env/hdd10");
    this.hdd11 = this.loadSound(this.hdd11, "Sounds/Env/hdd11");
    this.wind1 = this.loadSound(this.wind1, "Sounds/Env/wind1");
    this.slidedoor = this.loadSound(this.slidedoor, "Sounds/Env/slidedoor");
    this.rumble_2s = this.loadSound(this.rumble_2s, "Sounds/Env/rumble_2s");
    this.rumble_4s = this.loadSound(this.rumble_4s, "Sounds/Env/rumble_4s");
    this.rumble_8s = this.loadSound(this.rumble_8s, "Sounds/Env/rumble_8s");
    this.music_explore_5a = this.loadSound(this.music_explore_5a, "Sounds/Music/SW_Cue5_Inside_mixed");
    this.music_explore_6a = this.loadSound(this.music_explore_6a, "Sounds/Music/SW_Cue6_Alone_10_17");
    this.comp_beeps1 = this.loadSound(this.comp_beeps1, "Sounds/Env/comp_beeps1");
    this.comp_beeps2 = this.loadSound(this.comp_beeps2, "Sounds/Env/comp_beeps2");
    this.comp_beeps3 = this.loadSound(this.comp_beeps3, "Sounds/Env/comp_beeps3");
    this.comp_beeps4 = this.loadSound(this.comp_beeps4, "Sounds/Env/comp_beeps4");
    this.comp_beeps5 = this.loadSound(this.comp_beeps5, "Sounds/Env/comp_beeps5");
    this.comp_beeps6 = this.loadSound(this.comp_beeps6, "Sounds/Env/comp_beeps6");
    this.radarbeep = this.loadSound(this.radarbeep, "Sounds/Env/radarbeep");
    this.toolbox1 = this.loadSound(this.toolbox1, "Sounds/Env/toolbox1");
    this.toolbox2 = this.loadSound(this.toolbox2, "Sounds/Env/toolbox2");
    this.ship_drag = this.loadSound(this.ship_drag, "Sounds/Env/ship_drag");
    this.ship_drag2 = this.loadSound(this.ship_drag2, "Sounds/Env/ship_drag2");
    this.pisk = this.loadSound(this.pisk, "Sounds/Env/pisk");
    this.jet_mono = this.loadSound(this.jet_mono, "Sounds/Env/jet_mono");
    this.jet2_mono = this.loadSound(this.jet2_mono, "Sounds/Env/jet2_mono");
    this.door_slide = this.loadSound(this.door_slide, "Sounds/Env/door_slide");
    this.power_up_small = this.loadSound(this.power_up_small, "Sounds/Env/power_up_small");
    this.power_down_small = this.loadSound(this.power_down_small, "Sounds/Env/power_down_small");
    this.denied = this.loadSound(this.denied, "Sounds/Env/denied");
    this.mouse_click = this.loadSound(this.mouse_click, "Sounds/Env/mouse_click");
    this.lamp_on = this.loadSound(this.lamp_on, "Sounds/Env/lamp_on");
    this.engine_wrong = this.loadSound(this.engine_wrong, "Sounds/Env/engine_wrong");
    this.big_door_open = this.loadSound(this.big_door_open, "Sounds/Env/big_door_open");
    this.chorus1 = this.loadSound(this.chorus1, "Sounds/Env/chorus1");
    this.chorus2 = this.loadSound(this.chorus2, "Sounds/Env/chorus2");
    this.low_rumble = this.loadSound(this.low_rumble, "Sounds/Env/low_rumble");
    this.low_rumble2 = this.loadSound(this.low_rumble2, "Sounds/Env/low_rumble2");
    this.rrusty_creak_1 = this.loadSound(this.rrusty_creak_1, "Sounds/Env/rrusty_creak_1");
    this.rrusty_creak_2 = this.loadSound(this.rrusty_creak_2, "Sounds/Env/rrusty_creak_2");
    this.rrusty_creak_3 = this.loadSound(this.rrusty_creak_3, "Sounds/Env/rrusty_creak_3");
    this.rrusty_creak_4 = this.loadSound(this.rrusty_creak_4, "Sounds/Env/rrusty_creak_4");
    this.fast_creak_1 = this.loadSound(this.fast_creak_1, "Sounds/Env/fast_creak_1");
    this.fast_creak_2 = this.loadSound(this.fast_creak_2, "Sounds/Env/fast_creak_2");
    this.fast_creak_3 = this.loadSound(this.fast_creak_3, "Sounds/Env/fast_creak_3");
    this.slide_1 = this.loadSound(this.slide_1, "Sounds/Env/slide_1");
    this.slide_2 = this.loadSound(this.slide_2, "Sounds/Env/slide_2");
    this.slide_3 = this.loadSound(this.slide_3, "Sounds/Env/slide_3");
    this.unlock = this.loadSound(this.unlock, "Sounds/Env/unlock");
    this.keyboard = this.loadSound(this.keyboard, "Sounds/Env/keyboard");
    this.pods = this.loadSound(this.pods, "Sounds/Env/pods");
    this.power_down_big = this.loadSound(this.power_down_big, "Sounds/Env/power_down_big");
    this.power_up_big = this.loadSound(this.power_up_big, "Sounds/Env/power_up_big");
    this.glass_crack_1 = this.loadSound(this.glass_crack_1, "Sounds/Env/glass_crack_1");
    this.glass_crack_2 = this.loadSound(this.glass_crack_2, "Sounds/Env/glass_crack_2");
    this.dumdumdum = this.loadSound(this.dumdumdum, "Sounds/Env/dumdumdum");
    this.disk = this.loadSound(this.disk, "Sounds/Env/disk");
    this.thunder1 = this.loadSound(this.thunder1, "Sounds/Env/thunder1");
    this.thunder2 = this.loadSound(this.thunder2, "Sounds/Env/thunder2");
    this.thunder3 = this.loadSound(this.thunder3, "Sounds/Env/thunder3");
    this.thunder4 = this.loadSound(this.thunder4, "Sounds/Env/thunder4");
    this.thunder5 = this.loadSound(this.thunder5, "Sounds/Env/thunder5");
    this.rain_short = this.loadSound(this.rain_short, "Sounds/Env/rain_short");
    this.flashlight = this.loadSound(this.flashlight, "Sounds/Items/flashlight1");
    this.ui_hover = this.loadSound(this.ui_hover, "Sounds/Env/ui_hover");
    this.ui_click = this.loadSound(this.ui_click, "Sounds/Env/ui_click");
    this.music_attack = this.loadSound(this.music_attack, "Sounds/Music/SW_Cue7_NightAttack1_3");
    this.music_attack2 = this.loadSound(this.music_attack2, "Sounds/Music/SW_Cue8_NickAttack4_2");
    this.music_success = this.loadSound(this.music_success, "Sounds/Music/SW_Cue9_Success");
    this.digger = this.loadSound(this.digger, "Sounds/Env/digger");
    this.metal_locked_1 = this.loadSound(this.metal_locked_1, "Sounds/Env/metal_locked_1");
    this.metal_locked_2 = this.loadSound(this.metal_locked_2, "Sounds/Env/metal_locked_2");
    this.metal_locked_3 = this.loadSound(this.metal_locked_3, "Sounds/Env/metal_locked_3");
    this.cabinet_1 = this.loadSound(this.cabinet_1, "Sounds/Env/cabinet01");
    this.wood_crack_1 = this.loadSound(this.wood_crack_1, "Sounds/Env/wood_crack1");
    this.wood_crack_2 = this.loadSound(this.wood_crack_2, "Sounds/Env/wood_crack2");
    this.wood_crack_3 = this.loadSound(this.wood_crack_3, "Sounds/Env/wood_crack3");
    this.fire_start = this.loadSound(this.fire_start, "Sounds/Env/lit");
    this.rockbutton = this.loadSound(this.rockbutton, "Sounds/Items/rockbutton");
    this.necklace = this.loadSound(this.necklace, "Sounds/Items/necklace");
    this.knife = this.loadSound(this.knife, "Sounds/Items/knife");
    this.fridge = this.loadSound(this.fridge, "Sounds/Env/fridge");
    this.trunk_open = this.loadSound(this.trunk_open, "Sounds/Env/trunk_open");
    this.trunk_close = this.loadSound(this.trunk_close, "Sounds/Env/trunk_close");
    this.car_start = this.loadSound(this.car_start, "Sounds/Env/car_start");
    this.car_drive = this.loadSound(this.car_drive, "Sounds/Env/car_drive");
    this.car_drive2 = this.loadSound(this.car_drive2, "Sounds/Env/car_drive2");
    this.car_stop = this.loadSound(this.car_stop, "Sounds/Env/car_stop");
    this.car_open = this.loadSound(this.car_open, "Sounds/Env/car_open");
    this.car_close = this.loadSound(this.car_close, "Sounds/Env/car_close");
    this.car_close2 = this.loadSound(this.car_close2, "Sounds/Env/car_close2");
    this.car_close3 = this.loadSound(this.car_close3, "Sounds/Env/car_close3");
    this.cabinet_open = this.loadSound(this.cabinet_open, "Sounds/Env/cabinet_open");
    this.pull_recoil = this.loadSound(this.pull_recoil, "Sounds/Env/pull_recoil");
    this.ac = this.loadSound(this.ac, "Sounds/Env/ac");
    this.music_game_over = this.loadSound(this.music_game_over, "Sounds/Music/SW_Cue10_sorrowv2");
    this.music_sorrow = this.loadSound(this.music_sorrow, "Sounds/Music/SW_Cue11_GameOver");
    this.fan = this.loadSound(this.fan, "Sounds/Env/fan");
    this.heater2 = this.loadSound(this.heater2, "Sounds/Env/heater2");
    this.heater_hiss = this.loadSound(this.heater_hiss, "Sounds/Env/heater_hiss");
    this.pyk = this.loadSound(this.pyk, "Sounds/Env/pyk");
    this.pyk2 = this.loadSound(this.pyk2, "Sounds/Env/pyk2");
    this.blizzard = this.loadSound(this.blizzard, "Sounds/Env/blizzard");
    this.double_bang = this.loadSound(this.double_bang, "Sounds/Env/double_bang");
    this.rv_engine_loop = this.loadSound(this.rv_engine_loop, "Sounds/Env/rv_engine_idle");
    this.rv_engine_start = this.loadSound(this.rv_engine_start, "Sounds/Env/rv_engine_start");
    this.rv_engine_fail = this.loadSound(this.rv_engine_fail, "Sounds/Env/rv_engine_fail");
    this.door_creak_1 = this.loadSound(this.door_creak_1, "Sounds/Env/door_creak1");
    this.door_creak_2 = this.loadSound(this.door_creak_2, "Sounds/Env/door_creak2");
    this.door_creak_3 = this.loadSound(this.door_creak_3, "Sounds/Env/door_creak3");
    this.door_creak_open = this.loadSound(this.door_creak_open, "Sounds/Env/door_creak_open");
    this.rock_hit_1 = this.loadSound(this.rock_hit_1, "Sounds/Env/rock_hit1");
    this.rock_hit_2 = this.loadSound(this.rock_hit_2, "Sounds/Env/rock_hit2");
    this.rock_hit_3 = this.loadSound(this.rock_hit_3, "Sounds/Env/rock_hit3");
    this.rock_rumble_1 = this.loadSound(this.rock_rumble_1, "Sounds/Env/rumble1");
    this.rock_rumble_2 = this.loadSound(this.rock_rumble_2, "Sounds/Env/rumble2");
    this.rock_rumble_3 = this.loadSound(this.rock_rumble_3, "Sounds/Env/rumble3");
    this.nailed = this.loadSound(this.nailed, "Sounds/Env/nailed");
    this.sand_pour1 = this.loadSound(this.sand_pour1, "Sounds/Env/sand_pour1");
    this.sand_pour2 = this.loadSound(this.sand_pour2, "Sounds/Env/sand_pour2");
    this.sand_pour3 = this.loadSound(this.sand_pour3, "Sounds/Env/sand_pour3");
    this.sand_pour4 = this.loadSound(this.sand_pour4, "Sounds/Env/sand_pour4");
    this.sand_big = this.loadSound(this.sand_big, "Sounds/Env/sand_big");
    this.push = this.loadSound(this.push, "Sounds/Env/push");
    this.motorbikes = this.loadSound(this.motorbikes, "Sounds/Env/motorbikes");
    this.motor_incoming = this.loadSound(this.motor_incoming, "Sounds/Env/motor_incoming");
    this.vomit = this.loadSound(this.vomit, "Sounds/Env/vomit");
    this.break_glass_big = this.loadSound(this.break_glass_big, "Sounds/Env/break_glass_big");
    this.music_main = this.loadSound(this.music_main, "Sounds/Music/SW_CueX_MainMenu_Redo1");
    this.music_mystery = this.loadSound(this.music_mystery, "Sounds/Music/SW_Cue15_MysteryTheme_v1");
    this.pc_noise = this.loadSound(this.pc_noise, "Sounds/Ambient/pc_sound");
    this.underground_1 = this.loadSound(this.underground_1, "Sounds/Ambient/underground_1");
    this.ambient_fire_1 = this.loadSound(this.ambient_fire_1, "Sounds/Ambient/fire");
    this.ambient_wind_1 = this.loadSound(this.ambient_wind_1, "Sounds/Ambient/ambient_wind_1");
    this.ambient_wind_metal = this.loadSound(this.ambient_wind_metal, "Sounds/Ambient/ambient_wind_2");
    this.ambient_wind_metal_inside = this.loadSound(this.ambient_wind_metal_inside, "Sounds/Ambient/ambient_wind_metal_inside");
    this.ambient_wind_3 = this.loadSound(this.ambient_wind_3, "Sounds/Ambient/ambient_wind_3");
    this.ambient_wind_flag = this.loadSound(this.ambient_wind_flag, "Sounds/Ambient/ambient_wind_flag");
    this.ambient_wind_forest = this.loadSound(this.ambient_wind_forest, "Sounds/Ambient/forest_wind");
    this.ambient_wind_wood = this.loadSound(this.ambient_wind_wood, "Sounds/Ambient/ambient_wind_wood");
    this.ambient_ship_crashed = this.loadSound(this.ambient_ship_crashed, "Sounds/Ambient/ambient_ship_crashed");
    this.ambient_sparks = this.loadSound(this.ambient_sparks, "Sounds/Ambient/ambient_sparks");
    this.suit_breathing = this.loadSound(this.suit_breathing, "Sounds/Ambient/suit_breathing");
    this.moon = this.loadSound(this.moon, "Sounds/Ambient/moon");
    this.alert1 = this.loadSound(this.alert1, "Sounds/Ambient/alert1");
    this.alert2 = this.loadSound(this.alert2, "Sounds/Ambient/alert2");
    this.music_emotional = this.loadSound(this.music_emotional, "Sounds/Music/SW_Cue14_emotional");
    this.music_scare = this.loadSound(this.music_scare, "Sounds/Music/SW_Cue16_NightmareScare");
    if (this.loadedThisFrame != 0 || this.ALL_LOADED)
      return;
    this.ALL_LOADED = true;
  }

  private AudioClip loadSound(AudioClip audioClip, string path)
  {
    if (!this.secondLoop)
      ++this.elementsToLoad;
    if ((Object) audioClip != (Object) null)
    {
      ++this.loadedElements;
      return audioClip;
    }
    if (this.loadedThisFrame < this.loadPerFrame)
    {
      audioClip = Resources.Load<AudioClip>(path);
      ++this.loadedThisFrame;
    }
    return audioClip;
  }
}
