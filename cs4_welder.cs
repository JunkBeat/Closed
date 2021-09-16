// Decompiled with JetBrains decompiler
// Type: cs4_welder
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class cs4_welder : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_welder";
    this.actionType = ObjectActionController.Type.NormalAction;
    this.doubleClickCondition = string.Empty;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("constructionsite_from_above"))
    {
      if (GameDataController.gd.getObjective("cs_welder_taken") || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("welder")))
        return;
      GameDataController.gd.setObjective("cs_welder_taken", true);
      this.updateAll();
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cant_reach"));
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("cs_welder_taken"))
    {
      this.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
    }
    else
    {
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
    }
    if (GameDataController.gd.getObjective("constructionsite_from_above"))
    {
      this.range = 1f;
      this.characterAnimationName = "kneel_";
      this.interactions = new List<ItemInteraction>();
    }
    else
    {
      this.range = 100f;
      this.characterAnimationName = "action_stnd_";
      this.interactions = new List<ItemInteraction>();
      this.interactions.Add(new ItemInteraction("broom", GameStrings.getString(GameStrings.actions, "welder_poke"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("wrench", GameStrings.getString(GameStrings.actions, "welder_poke"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("crowbar", GameStrings.getString(GameStrings.actions, "welder_poke"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("shovel", GameStrings.getString(GameStrings.actions, "welder_poke"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("ropehook", GameStrings.getString(GameStrings.actions, "welder_pull"), anim: string.Empty));
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
