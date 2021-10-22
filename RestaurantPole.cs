// Decompiled with JetBrains decompiler
// Type: RestaurantPole
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class RestaurantPole : ObjectActionController
{
  public Sprite lever1;
  public Sprite lever2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_pole_clamp";
    this.range = 1f;
    this.teleport = false;
    this.updateState();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("pipe", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("crowbar", GameStrings.getString(GameStrings.actions, "restaurant_pole_wrong"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("wrench", GameStrings.getString(GameStrings.actions, "restaurant_pole_wrong"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("screwdriver", GameStrings.getString(GameStrings.actions, "restaurant_pole_wrong"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("knife", GameStrings.getString(GameStrings.actions, "restaurant_pole_wrong"), anim: string.Empty));
  }

  private void Update()
  {
  }

  public override void whatOnClick0()
  {
    if (this.usedItem == "pipe" || GameDataController.gd.getObjective("restaurant_pipe_inserted") && !GameDataController.gd.getObjective("restaurant_pipe_switched"))
    {
      this.range = 1f;
      this.characterAnimationName = "action_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else
    {
      this.range = 10f;
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
  }

  public override void clickAction()
  {
    if (this.usedItem == string.Empty)
    {
      if (GameDataController.gd.getObjective("restaurant_pipe_inserted"))
      {
        if (GameDataController.gd.getObjective("restaurant_pipe_switched"))
        {
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "restaurant_pole_done"), true, mwidth: 150);
        }
        else
        {
          GameDataController.gd.setObjective("restaurant_pipe_switched", true);
          this.updateAll();
        }
      }
      else
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "restaurant_pole"), true, mwidth: 150);
    }
    else
    {
      if (!(this.usedItem == "pipe"))
        return;
      GameDataController.gd.setObjective("restaurant_pipe_inserted", true);
      InventoryController.ic.removeItem("pipe");
      this.updateAll();
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "restaurant_pole_pipe"), true, mwidth: 150);
    }
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (!GameDataController.gd.getObjective("restaurant_pipe_inserted"))
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    else if (GameDataController.gd.getObjective("restaurant_pipe_inserted") && GameDataController.gd.getObjective("restaurant_pipe_switched"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.lever1;
    }
    else
    {
      if (!GameDataController.gd.getObjective("restaurant_pipe_inserted") || GameDataController.gd.getObjective("restaurant_pipe_switched"))
        return;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.lever2;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
