// Decompiled with JetBrains decompiler
// Type: Outpost7_BigComputerPart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Outpost7_BigComputerPart : ObjectActionController
{
  public Sprite painting;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_big_computer_part";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("duplexer", string.Empty, anim: string.Empty));
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("outpost_computer_part_taken"))
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("duplexer")))
        return;
      GameDataController.gd.setObjective("outpost_computer_part_taken", true);
      this.updateState();
    }
    else if (this.usedItem != string.Empty)
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "outpost_big_computer_nah"));
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "outpost_big_computer_empty"));
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    if (GameDataController.gd.getObjective("outpost_computer_part_taken"))
      return;
    this.characterAnimationName = "kneel_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
    if (GameDataController.gd.getObjective("outpost_computer_part_taken"))
      return;
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "outpost_big_computer_part"));
  }

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}
