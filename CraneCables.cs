// Decompiled with JetBrains decompiler
// Type: CraneCables
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class CraneCables : ObjectActionController
{
  public Sprite cord;
  public Sprite stormcatcher_on;
  public Sprite stormcatcher_off;
  public SpriteRenderer glow;
  public GameObject sparks;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action1_e";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_cables_box";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("stormcatcher1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("stormcatcher2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("stormcatcher3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("screwdriver", GameStrings.getString(GameStrings.actions, "cable_box_screwdriver"), anim: string.Empty));
    this.updateState();
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    if (this.usedItem == string.Empty)
    {
      if (GameDataController.gd.getObjective("cs_stormcatcher_installed"))
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_stormcatcher_installed"));
      else if (!GameDataController.gd.getObjective("cs_cables_open"))
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.cabinet_open);
        GameDataController.gd.setObjective("cs_cables_open", true);
        this.updateState();
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_cable_box_open"));
    }
    else if (GameDataController.gd.getObjective("cs_stormcatcher_installed"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "stormcatcher_already"));
    else if (!GameDataController.gd.getObjective("cs_cables_open"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_cables_open"));
    else if (GameDataController.gd.getObjective("cs_engine_started"))
    {
      this.sparks.GetComponent<ParticleGenerator>().started = true;
      this.Invoke("stopSparks", 1f);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.electric);
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_cables_sparks"));
    }
    else
    {
      InventoryController.ic.removeItem(this.usedItem);
      GameDataController.gd.setObjective("cs_stormcatcher_installed", true);
      this.updateState();
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_stormcatcher_placed"));
    }
  }

  public void stopSparks()
  {
    this.sparks.GetComponent<ParticleGenerator>().started = false;
    this.sparks.GetComponent<ParticleGenerator>().removeParticles();
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    this.GetComponent<SpriteRenderer>().enabled = true;
    this.glow.enabled = false;
    if (GameDataController.gd.getObjective("cs_stormcatcher_installed") && GameDataController.gd.getObjective("cs_engine_started"))
    {
      this.GetComponent<SpriteRenderer>().sprite = this.stormcatcher_on;
      this.glow.enabled = true;
    }
    else if (GameDataController.gd.getObjective("cs_stormcatcher_installed"))
      this.GetComponent<SpriteRenderer>().sprite = this.stormcatcher_off;
    else if (GameDataController.gd.getObjective("cs_cables_open"))
      this.GetComponent<SpriteRenderer>().sprite = this.cord;
    else
      this.GetComponent<SpriteRenderer>().enabled = false;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
    this.characterAnimationName = "action1_e";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    if (this.usedItem != string.Empty && !GameDataController.gd.getObjective("cs_cables_open"))
    {
      this.characterAnimationName = "action_stnd_e";
      this.animationFlip = true;
      this.useCurrentDirection = false;
    }
    if (!(this.usedItem == string.Empty) || !GameDataController.gd.getObjective("cs_cables_open"))
      return;
    this.characterAnimationName = "action_stnd_e";
    this.animationFlip = true;
    this.useCurrentDirection = false;
  }

  public override void whatOnClick()
  {
  }
}
