// Decompiled with JetBrains decompiler
// Type: HunterLodgeCable2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class HunterLodgeCable2 : ObjectActionController
{
  public Sprite cord;
  public Sprite cord2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "lodge_cord";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("heater_broken", GameStrings.getString(GameStrings.actions, "heater_broken"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("fan_broken", GameStrings.getString(GameStrings.actions, "fan_broken"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("heater", GameStrings.getString(GameStrings.actions, "plug_not_needed"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ac", GameStrings.getString(GameStrings.actions, "plug_not_needed"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("fan", GameStrings.getString(GameStrings.actions, "plug_not_needed"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("stormcatcher1", GameStrings.getString(GameStrings.actions, "plug_not_needed"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("stormcatcher2", GameStrings.getString(GameStrings.actions, "plug_not_needed"), anim: string.Empty));
    this.updateState();
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

  private void takeCord(string param = "") => CursorController.cc.selectItem(ItemsManager.im.getItem("ext_cord_place"));

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("lodge_cord_climbed"))
    {
      this.colliderManager.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.GetComponent<SpriteRenderer>().sprite = this.cord2;
    }
    else if (GameDataController.gd.getObjective("lodge_cord_dragged"))
    {
      this.colliderManager.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.GetComponent<SpriteRenderer>().sprite = this.cord;
    }
    else
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.setCollider(-1);
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
