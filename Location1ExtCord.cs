// Decompiled with JetBrains decompiler
// Type: Location1ExtCord
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Location1ExtCord : ObjectActionController
{
  private CursorController cursorController;
  public Sprite cord;
  public Sprite heater;
  public SpriteRenderer heaterLight;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "ext_cord_placed";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("heater", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("fan", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("heater_broken", GameStrings.getString(GameStrings.actions, "heater_broken"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("fan_broken", GameStrings.getString(GameStrings.actions, "fan_broken"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ac", GameStrings.getString(GameStrings.actions, "ext_cord_ac_machine1"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ac_cord", string.Empty, anim: string.Empty));
    this.updateState();
    this.cursorController = GameObject.Find("cursor").GetComponent<CursorController>();
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    if (this.usedItem == "heater")
    {
      InventoryController.ic.removeItem("heater");
      GameDataController.gd.setObjective("base_heater_cord_plugged", true);
      this.updateAll();
    }
    else if (this.usedItem == "fan")
    {
      InventoryController.ic.removeItem("fan");
      GameDataController.gd.setObjective("base_fan_cord_plugged", true);
      this.updateAll();
    }
    else if (this.usedItem == "ac_cord")
    {
      GameDataController.gd.setObjective("base_ac_cord_plugged", true);
      this.updateAll();
    }
    else if (GameDataController.gd.getObjective("base_heater_cord_plugged") || GameDataController.gd.getObjective("base_fan_cord_plugged") || GameDataController.gd.getObjective("base_ac_cord_plugged"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "ext_cord_plugged"));
    else
      Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
      {
        text = GameStrings.getString(GameStrings.actions, "ext_cord_where_put"),
        function = new TimelineFunction(this.takeCord)
      });
  }

  private void takeCord(string param = "") => this.cursorController.selectItem(ItemsManager.im.getItem("ext_cord_place"));

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("kitchen_cord_dragged"))
    {
      this.colliderManager.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.GetComponent<SpriteRenderer>().sprite = this.cord;
    }
    else
    {
      this.colliderManager.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
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
