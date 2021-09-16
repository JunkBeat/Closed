// Decompiled with JetBrains decompiler
// Type: Attic1Hatch1b
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class Attic1Hatch1b : ObjectActionController
{
  public Sprite light1;
  public Sprite light2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "attic_hatch1";
    this.actionType = ObjectActionController.Type.NormalAction;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("flag", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanket", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanketb", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("thermalb", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("hammer", GameStrings.getString(GameStrings.actions, "hatch_nails_no_need"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ducttape", GameStrings.getString(GameStrings.actions, "hatch_nails_no_need"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("nails1", GameStrings.getString(GameStrings.actions, "hatch_nails_no_need"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("nails2", GameStrings.getString(GameStrings.actions, "hatch_nails_no_need"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("nails3", GameStrings.getString(GameStrings.actions, "hatch_nails_no_need"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("nails4", GameStrings.getString(GameStrings.actions, "hatch_nails_no_need"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("nails5", GameStrings.getString(GameStrings.actions, "hatch_nails_no_need"), anim: string.Empty));
    this.trans_dir = WalkController.Direction.S;
  }

  public override void whatOnClick0()
  {
    if (this.usedItem != string.Empty && (GameDataController.gd.getObjective("rv_cave_flag") || GameDataController.gd.getObjective("rv_cave_blanket") || GameDataController.gd.getObjective("rv_cave_blanketb") || GameDataController.gd.getObjective("rv_cave_therm")))
    {
      this.characterAnimationName = "action_stnd_";
      this.range = 100f;
    }
    else if (this.usedItem != string.Empty || GameDataController.gd.getObjective("base_hatch_flag") || GameDataController.gd.getObjective("base_hatch_blanket") || GameDataController.gd.getObjective("base_hatch_blanketb") || GameDataController.gd.getObjective("base_hatch_therm"))
    {
      this.characterAnimationName = "kneel_";
      this.range = 1f;
    }
    else
    {
      this.range = 1f;
      this.characterAnimationName = "stop";
    }
  }

  public override void clickAction()
  {
    if (this.usedItem == string.Empty)
    {
      if (GameDataController.gd.getObjective("base_hatch_flag") && InventoryController.ic.pickUpItem(ItemsManager.im.getItem("flag")))
        GameDataController.gd.setObjective("base_hatch_flag", false);
      if (GameDataController.gd.getObjective("base_hatch_blanket") && InventoryController.ic.pickUpItem(ItemsManager.im.getItem("blanket")))
        GameDataController.gd.setObjective("base_hatch_blanket", false);
      if (GameDataController.gd.getObjective("base_hatch_blanketb") && InventoryController.ic.pickUpItem(ItemsManager.im.getItem("blanketb")))
        GameDataController.gd.setObjective("base_hatch_blanketb", false);
      if (GameDataController.gd.getObjective("base_hatch_therm") && InventoryController.ic.pickUpItem(ItemsManager.im.getItem("thermalb")))
        GameDataController.gd.setObjective("base_hatch_therm", false);
      this.updateAll();
    }
    else
    {
      if (!GameDataController.gd.getObjective("base_hatch_flag") && !GameDataController.gd.getObjective("base_hatch_blanket") && !GameDataController.gd.getObjective("base_hatch_blanketb") && !GameDataController.gd.getObjective("base_hatch_therm"))
        return;
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "hatch_busy"));
    }
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjective("base_hatch_flag") || GameDataController.gd.getObjective("base_hatch_blanket") || GameDataController.gd.getObjective("base_hatch_blanketb") || GameDataController.gd.getObjective("base_hatch_therm"))
    {
      this.colliderManager.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
      if (GameDataController.gd.getObjective("attic_hatch_open"))
        this.GetComponent<SpriteRenderer>().sprite = this.light2;
      else
        this.GetComponent<SpriteRenderer>().sprite = this.light1;
    }
    else
    {
      this.colliderManager.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
    }
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && (!GameDataController.gd.getObjective("lighting_rod_installed") || GameDataController.gd.getObjectiveDetail("day3_complete") < 1))
      this.GetComponent<SpriteRenderer>().enabled = false;
    if (GameDataController.gd.getObjective("base_hatch_flag"))
      this.objectName = "attic_hatch_thing_flag";
    if (GameDataController.gd.getObjective("base_hatch_blanket"))
      this.objectName = "attic_hatch_thing_blanket";
    if (GameDataController.gd.getObjective("base_hatch_blanketb"))
      this.objectName = "attic_hatch_thing_blanket";
    if (!GameDataController.gd.getObjective("base_hatch_therm"))
      return;
    this.objectName = "attic_hatch_thing_thermalb";
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
