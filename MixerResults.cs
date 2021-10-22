// Decompiled with JetBrains decompiler
// Type: MixerResults
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class MixerResults : ObjectActionController
{
  private SpriteRenderer sr;
  public Sprite sprite_1;
  public Sprite sprite_2;
  public Sprite sprite_3;
  private int liczba;
  public string thisNumber;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "source_good";
    this.range = 8000f;
    this.teleport = false;
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("mixer_glass", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("pill_half", string.Empty, anim: string.Empty));
    this.updateState();
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("sidereal_mixer_mixed"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_mixer_tray_empty"));
    else if (GameDataController.gd.getObjectiveDetail("sidereal_mixer_mixed") == 0)
    {
      PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "sidereal_mixer_tray_junk1"));
      PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "sidereal_mixer_tray_junk2"));
      PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "sidereal_mixer_tray_junk3"));
      Timeline.t.actions[Timeline.t.actions.Count - 1].function = new TimelineFunction(this.resetMixer);
      Timeline.t.actions[Timeline.t.actions.Count - 1].actionWithText = false;
    }
    else if (GameDataController.gd.getObjectiveDetail("sidereal_mixer_mixed") == 1)
    {
      if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 1)
      {
        PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "sidereal_mixer_tray_wrong"));
        PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "sidereal_mixer_tray_junk2"));
        PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "sidereal_mixer_tray_junk3"));
        Timeline.t.actions[Timeline.t.actions.Count - 1].function = new TimelineFunction(this.resetMixer);
        Timeline.t.actions[Timeline.t.actions.Count - 1].actionWithText = false;
      }
      else if (this.usedItem == "pill_half")
      {
        if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("pills")))
          return;
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.sand_pour1);
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_mixer_tray_pills2"));
        GameDataController.gd.setObjectiveDetail("sidereal_mixer_mixed", 3);
        this.updateAll();
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_mixer_tray_pills1"));
    }
    else if (GameDataController.gd.getObjectiveDetail("sidereal_mixer_mixed") == 2)
    {
      if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 0)
      {
        PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "sidereal_mixer_tray_wrong"));
        PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "sidereal_mixer_tray_junk2"));
        PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "sidereal_mixer_tray_junk3"));
        Timeline.t.actions[Timeline.t.actions.Count - 1].function = new TimelineFunction(this.resetMixer);
        Timeline.t.actions[Timeline.t.actions.Count - 1].actionWithText = false;
      }
      else if (this.usedItem == "mixer_glass")
      {
        if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("catalyst")))
          return;
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.liquid_pour_small);
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_mixer_tray_catalyst2"));
        GameDataController.gd.setObjectiveDetail("sidereal_mixer_mixed", 3);
        this.updateAll();
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_mixer_tray_catalyst1"));
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("sidereal_mixer_mixed") != 3)
        return;
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_mixer_button_already_done"));
    }
  }

  public void resetMixer(string param = "")
  {
    GameDataController.gd.setObjective("sidereal_mixer_mixed", false);
    GameDataController.gd.setObjectiveDetail("sidereal_mixer_mixed", 0);
    PlayerController.pc.setBusy(true);
    PlayerController.pc.spawnName = "LocationMixerExit";
    CurtainController.cc.fadeOut("SiderealMixer", WalkController.Direction.N);
  }

  public override void updateState()
  {
    this.setCollider(0);
    if (!GameDataController.gd.getObjective("sidereal_mixer_mixed"))
    {
      this.objectName = "mixer_tray_empty";
      this.sr.enabled = false;
    }
    else
    {
      this.sr.enabled = true;
      if (GameDataController.gd.getObjectiveDetail("sidereal_mixer_mixed") == 0)
      {
        this.sr.sprite = this.sprite_1;
        this.objectName = "mixer_tray_junk";
      }
      else if (GameDataController.gd.getObjectiveDetail("sidereal_mixer_mixed") == 1)
      {
        this.sr.sprite = this.sprite_2;
        this.objectName = "mixer_tray_pills";
      }
      else if (GameDataController.gd.getObjectiveDetail("sidereal_mixer_mixed") == 2)
      {
        this.sr.sprite = this.sprite_3;
        this.objectName = "mixer_tray_catalyst";
      }
      else
      {
        if (GameDataController.gd.getObjectiveDetail("sidereal_mixer_mixed") != 3)
          return;
        this.sr.enabled = false;
        this.objectName = "mixer_tray_empty";
      }
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
