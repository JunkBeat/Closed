// Decompiled with JetBrains decompiler
// Type: KitchenSocket
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class KitchenSocket : ObjectActionController
{
  public Sprite cord;
  public Sprite cord2;
  public Sprite heater;
  public SpriteRenderer fan1;
  public SpriteRenderer fan2;
  public AudioSource fanas;
  public SpriteRenderer heaterLight;
  public float lightAlfa;
  public float lightAlfa2;
  public bool isPowerThere;
  public bool isheaterThere;
  public bool isfanThere;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "kitchen_socket";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("heater", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("fan", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ext_cord", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("heater_broken", GameStrings.getString(GameStrings.actions, "heater_broken"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("fan_broken", GameStrings.getString(GameStrings.actions, "fan_broken"), anim: string.Empty));
    this.isPowerThere = GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 1;
    this.isheaterThere = GameDataController.gd.getObjective("kitchen_heater_plugged");
    this.updateState();
  }

  private void Update()
  {
    if (this.isheaterThere && this.isPowerThere && (double) this.lightAlfa < 1.0)
      this.lightAlfa += Time.deltaTime * 0.1f;
    if ((double) this.lightAlfa > 0.0 && (!this.isPowerThere || !this.isheaterThere))
      this.lightAlfa -= Time.deltaTime * 0.1f;
    if ((double) this.lightAlfa < 0.0)
      this.lightAlfa = 0.0f;
    if ((double) this.lightAlfa > 1.0)
      this.lightAlfa = 1f;
    this.lightAlfa2 += Random.Range(-0.1f, 0.1f);
    if ((double) this.lightAlfa2 < 0.0)
      this.lightAlfa2 = 0.0f;
    if ((double) this.lightAlfa2 > 1.0)
      this.lightAlfa2 = 1f;
    this.heaterLight.color = new Color(1f, 1f, 1f, (float) ((double) this.lightAlfa * 0.75 + (double) this.lightAlfa * (double) this.lightAlfa2 * 0.25));
  }

  public override void clickAction()
  {
    if (this.usedItem == "ext_cord")
    {
      if (GameDataController.gd.getObjective("kitchen_heater_plugged") || GameDataController.gd.getObjective("kitchen_fan_plugged"))
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "socket_busy"));
      }
      else
      {
        InventoryController.ic.removeItem("ext_cord");
        GameDataController.gd.setObjective("kitchen_cord_plugged", true);
        this.updateAll();
      }
    }
    else if (this.usedItem == "heater")
    {
      if (GameDataController.gd.getObjective("kitchen_cord_plugged"))
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "heater_cant_plug_here"));
      }
      else
      {
        InventoryController.ic.removeItem("heater");
        GameDataController.gd.setObjective("kitchen_heater_plugged", true);
        this.isheaterThere = GameDataController.gd.getObjective("kitchen_heater_plugged");
        this.updateAll();
      }
    }
    else if (this.usedItem == "fan")
    {
      if (GameDataController.gd.getObjective("kitchen_cord_plugged"))
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "fan_cant_plug_here"));
      }
      else
      {
        InventoryController.ic.removeItem("fan");
        GameDataController.gd.setObjective("kitchen_fan_plugged", true);
        this.updateAll();
      }
    }
    else if (GameDataController.gd.getObjective("kitchen_cord_plugged") && GameDataController.gd.getObjective("kitchen_cord_dragged"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cord_dragged"));
    else if (GameDataController.gd.getObjective("kitchen_cord_plugged"))
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("ext_cord")))
        return;
      GameDataController.gd.setObjective("kitchen_cord_plugged", false);
      this.updateAll();
    }
    else if (GameDataController.gd.getObjective("kitchen_heater_plugged"))
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("heater")))
        return;
      GameDataController.gd.setObjective("kitchen_heater_plugged", false);
      this.isheaterThere = GameDataController.gd.getObjective("kitchen_heater_plugged");
      this.updateAll();
    }
    else if (GameDataController.gd.getObjective("kitchen_fan_plugged"))
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("fan")))
        return;
      GameDataController.gd.setObjective("kitchen_fan_plugged", false);
      this.updateAll();
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "socket_empty"));
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    this.fan1.enabled = false;
    this.fan2.enabled = false;
    this.fanas.Stop();
    if (GameDataController.gd.getObjective("kitchen_cord_plugged"))
    {
      this.GetComponent<SpriteRenderer>().enabled = true;
      if (!GameDataController.gd.getObjective("kitchen_cord_dragged"))
        this.GetComponent<SpriteRenderer>().sprite = this.cord;
      else
        this.GetComponent<SpriteRenderer>().sprite = this.cord2;
      this.heaterLight.enabled = false;
      this.setCollider(1);
      this.objectName = "plugged_cord";
    }
    else if (GameDataController.gd.getObjective("kitchen_heater_plugged"))
    {
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.GetComponent<SpriteRenderer>().sprite = this.heater;
      this.heaterLight.enabled = true;
      this.setCollider(2);
      if (GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 1)
      {
        this.fanas.clip = SoundsManagerController.sm.heater2;
        this.fanas.Play();
        this.fanas.loop = true;
        this.objectName = "plugged_heater_on";
      }
      else
        this.objectName = "plugged_heater_off";
    }
    else if (GameDataController.gd.getObjective("kitchen_fan_plugged"))
    {
      this.setCollider(2);
      this.GetComponent<SpriteRenderer>().enabled = false;
      if (GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 1)
      {
        this.objectName = "plugged_fan_on";
        this.fan1.enabled = false;
        this.fan2.enabled = true;
        this.fanas.clip = SoundsManagerController.sm.fan;
        this.fanas.Play();
        this.fanas.loop = true;
      }
      else
      {
        this.fan1.enabled = true;
        this.fan2.enabled = false;
        this.objectName = "plugged_fan_off";
      }
    }
    else
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.heaterLight.enabled = false;
      this.setCollider(0);
      this.objectName = "kitchen_socket";
    }
  }

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
