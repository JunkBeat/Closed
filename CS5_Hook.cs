// Decompiled with JetBrains decompiler
// Type: CS5_Hook
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class CS5_Hook : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_buckle";
    this.actionType = ObjectActionController.Type.NormalAction;
    this.doubleClickCondition = string.Empty;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("ropehook", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("hook", GameStrings.getString(GameStrings.actions, "cs_buckle_hook"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rope", GameStrings.getString(GameStrings.actions, "cs_buckle_rope"), anim: string.Empty));
  }

  public override void whatOnClick0()
  {
    if (this.usedItem == "ropehook" || GameDataController.gd.getObjective("cs_rope_used"))
    {
      this.characterAnimationName = "action1_e";
      this.animationFlip = true;
      this.useCurrentDirection = false;
    }
    else
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("cs_rope_used"))
    {
      GameDataController.gd.setObjective("cs_rope_used", false);
      InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("ropehook"));
    }
    if (this.usedItem == "ropehook")
    {
      GameDataController.gd.setObjective("cs_rope_used", true);
      InventoryController.ic.removeItem("ropehook");
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_buckle"));
    this.updateAll();
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("cs_rope_used"))
      this.GetComponent<SpriteRenderer>().enabled = true;
    else
      this.GetComponent<SpriteRenderer>().enabled = false;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
