// Decompiled with JetBrains decompiler
// Type: KitchenExtCordPlace
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class KitchenExtCordPlace : ObjectActionController
{
  private CursorController cursorController;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "ext_cord_placed";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("heater_broken", GameStrings.getString(GameStrings.actions, "heater_broken"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("fan_broken", GameStrings.getString(GameStrings.actions, "fan_broken"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("heater", GameStrings.getString(GameStrings.actions, "ext_cord_wrong"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("fan", GameStrings.getString(GameStrings.actions, "ext_cord_wrong"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ac_plug", GameStrings.getString(GameStrings.actions, "ext_cord_wrong"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ac_machine", GameStrings.getString(GameStrings.actions, "ext_cord_wrong"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ac", GameStrings.getString(GameStrings.actions, "ext_cord_wrong"), anim: string.Empty));
    this.updateState();
    this.cursorController = GameObject.Find("cursor").GetComponent<CursorController>();
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    if (!(this.usedItem == string.Empty))
      return;
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.actions, "ext_cord_where_put"),
      function = new TimelineFunction(this.takeCord)
    });
  }

  private void takeCord(string param = "") => this.cursorController.selectItem(ItemsManager.im.getItem("ext_cord_place"));

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("kitchen_cord_plugged") && !GameDataController.gd.getObjective("kitchen_cord_dragged"))
      this.setCollider(0);
    else
      this.setCollider(-1);
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
