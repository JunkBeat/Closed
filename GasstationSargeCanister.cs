// Decompiled with JetBrains decompiler
// Type: GasstationSargeCanister
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class GasstationSargeCanister : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_canister";
    this.range = 10f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("wrench", string.Empty, anim: string.Empty));
  }

  public override void whatOnClick()
  {
    if (this.usedItem == "wrench")
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 30f;
    }
    else if (GameDataController.gd.getObjective("gasstation_sarge_shot"))
    {
      this.characterAnimationName = "kneel_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 1f;
    }
    else
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 300f;
    }
  }

  public override void clickAction()
  {
    if (this.usedItem == "wrench")
    {
      if (GameDataController.gd.getObjective("gasstation_sarge_shot"))
      {
        if (GameDataController.gd.getObjective("gasstation_sarge_canister_filled"))
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "tank_canister_full"), true);
        else
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "tank_canister_take_first"), true);
      }
      else
        GameObject.Find("sargeObject").GetComponent<GasstationSargeObject>().talkWrench();
    }
    else if (GameDataController.gd.getObjective("gasstation_sarge_shot"))
    {
      if (GameDataController.gd.getObjective("gasstation_sarge_canister_filled"))
      {
        if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("canister2_full")))
          return;
        GameDataController.gd.setObjective("gasstation_sarge_canister_taken", true);
        this.updateAll();
      }
      else
      {
        if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("canister2_empty")))
          return;
        GameDataController.gd.setObjective("gasstation_sarge_canister_taken", true);
        this.updateAll();
      }
    }
    else
      GameObject.Find("sargeObject").GetComponent<GasstationSargeObject>().dontTouchThat();
  }

  public override void updateState()
  {
    this.setCollider(0);
    this.GetComponent<SpriteRenderer>().enabled = true;
    if (GameDataController.gd.getObjective("gasstation_spy_mode"))
      this.setCollider(-1);
    if (GameDataController.gd.getCurrentDay() == 3 && !GameDataController.gd.getObjective("gasstation_sarge_canister_filled") && !GameDataController.gd.getObjective("gasstation_sarge_shot"))
      this.setCollider(-1);
    if (GameDataController.gd.getObjective("gasstation_sarge_convinced"))
    {
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
    }
    if (!GameDataController.gd.getObjective("gasstation_sarge_canister_taken") && !GameDataController.gd.getObjective("gasstation_sarge_convinced") && GameDataController.gd.getCurrentDay() >= 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getObjective("sidereal_base_located") && (GameDataController.gd.getCurrentDay() <= 3 || GameDataController.gd.getObjective("gasstation_sarge_shot")))
      return;
    this.setCollider(-1);
    this.GetComponent<SpriteRenderer>().enabled = false;
  }

  public override void clickAction0()
  {
  }

  public override void clickAction2()
  {
  }
}
