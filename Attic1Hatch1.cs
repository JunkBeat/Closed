// Decompiled with JetBrains decompiler
// Type: Attic1Hatch1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class Attic1Hatch1 : ObjectActionController
{
  public Sprite klapaFlag;
  public Sprite klapaBlanket;
  public Sprite klapaBlanketb;
  public Sprite klapaThermb;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "attic_hatch1";
    this.actionType = ObjectActionController.Type.Transition;
    this.doubleClickCondition = "visited_baseUpstairs";
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
    this.interactions.Add(new ItemInteraction("rock", GameStrings.getString(GameStrings.actions, "hatch_nails_no_need"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rock2", GameStrings.getString(GameStrings.actions, "hatch_nails_no_need"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("tarpaulin", GameStrings.getString(GameStrings.actions, "hatch_tarp"), anim: string.Empty));
    this.trans_dir = WalkController.Direction.S;
  }

  public override void whatOnClick0()
  {
    if (this.usedItem != string.Empty && (GameDataController.gd.getObjective("base_hatch_flag") || GameDataController.gd.getObjective("base_hatch_blanket") || GameDataController.gd.getObjective("base_hatch_blanketb") || GameDataController.gd.getObjective("base_hatch_therm")))
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
      PlayerController.pc.spawnName = "Ladder";
      CurtainController.cc.fadeOut("LocationBaseUpstairs", WalkController.Direction.E, "ladder_climb_down");
    }
    else if (GameDataController.gd.getObjective("base_hatch_flag") || GameDataController.gd.getObjective("base_hatch_blanket") || GameDataController.gd.getObjective("base_hatch_blanketb") || GameDataController.gd.getObjective("base_hatch_therm"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "hatch_busy"));
    }
    else
    {
      if (this.usedItem == "flag")
        GameDataController.gd.setObjective("base_hatch_flag", true);
      else if (this.usedItem == "blanket")
        GameDataController.gd.setObjective("base_hatch_blanket", true);
      else if (this.usedItem == "blanketb")
        GameDataController.gd.setObjective("base_hatch_blanketb", true);
      else if (this.usedItem == "thermalb")
        GameDataController.gd.setObjective("base_hatch_therm", true);
      InventoryController.ic.removeItem(this.usedItem);
      this.updateAll();
    }
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjective("base_hatch_flag") || GameDataController.gd.getObjective("base_hatch_blanket") || GameDataController.gd.getObjective("base_hatch_blanketb") || GameDataController.gd.getObjective("base_hatch_therm"))
    {
      this.colliderManager.setCollider(1);
      this.GetComponent<SpriteRenderer>().enabled = true;
      if (GameDataController.gd.getObjective("base_hatch_flag"))
        this.GetComponent<SpriteRenderer>().sprite = this.klapaFlag;
      if (GameDataController.gd.getObjective("base_hatch_blanket"))
        this.GetComponent<SpriteRenderer>().sprite = this.klapaBlanket;
      if (GameDataController.gd.getObjective("base_hatch_blanketb"))
        this.GetComponent<SpriteRenderer>().sprite = this.klapaBlanketb;
      if (!GameDataController.gd.getObjective("base_hatch_therm"))
        return;
      this.GetComponent<SpriteRenderer>().sprite = this.klapaThermb;
    }
    else
    {
      this.colliderManager.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = false;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
