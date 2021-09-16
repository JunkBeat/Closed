// Decompiled with JetBrains decompiler
// Type: RVRocks
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class RVRocks : ObjectActionController
{
  public Sprite painting;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action1_e_lock";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "rv_rocks";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("rope", GameStrings.getString(GameStrings.actions, "rope_rocks_fail"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ropehook", string.Empty, anim: string.Empty));
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("rv_hook_installed"))
    {
      if (this.usedItem == "ropehook")
      {
        InventoryController.ic.removeItem("ropehook");
        GameDataController.gd.setObjective("rv_hook_installed", true);
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "rv_rock_rope_in"));
        this.updateAll();
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "rv_rocks"));
    }
    else
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("ropehook")))
        return;
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "rv_rock_rope_out"));
      GameDataController.gd.setObjective("rv_hook_installed", false);
      this.updateAll();
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("rv_hook_installed"))
    {
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.colliderManager.setCollider(1);
      this.objectName = "rv_rocks_rope";
    }
    else
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(0);
      this.objectName = "rv_rocks";
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
    if (!GameDataController.gd.getObjective("rv_hook_installed") && this.usedItem == "ropehook" || GameDataController.gd.getObjective("rv_hook_installed"))
    {
      this.characterAnimationName = "action1_e_lock";
      this.range = 1f;
    }
    else
    {
      this.range = 60f;
      this.characterAnimationName = "action_stnd_e";
    }
  }

  public override void whatOnClick()
  {
  }
}
