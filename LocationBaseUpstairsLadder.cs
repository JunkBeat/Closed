// Decompiled with JetBrains decompiler
// Type: LocationBaseUpstairsLadder
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class LocationBaseUpstairsLadder : ObjectActionController
{
  public Sprite klapa;
  public Sprite klapaFlag;
  public Sprite klapaBlanket;
  public Sprite klapaBlanketb;
  public Sprite klapaThermb;
  public Sprite klapa2;
  public Sprite klapaFlag2;
  public Sprite klapaBlanket2;
  public Sprite klapaBlanketb2;
  public Sprite klapaThermb2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "climb_up_locked";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "upstairs_ladder";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("flag", GameStrings.getString(GameStrings.actions, "hatch_wrong_side"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanket", GameStrings.getString(GameStrings.actions, "hatch_wrong_side"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanketb", GameStrings.getString(GameStrings.actions, "hatch_wrong_side"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("thermalb", GameStrings.getString(GameStrings.actions, "hatch_wrong_side"), anim: string.Empty));
    this.updateState();
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjective("thug_to_kill_bathroom"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "day4_start_stairs_no"));
    }
    else
    {
      if (GameDataController.gd.getObjective("day1_complete"))
        return;
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "base_hatch_locked"), true);
    }
  }

  public override void whatOnClick()
  {
    if (GameDataController.gd.getCurrentDay() != 4 || !GameDataController.gd.getObjective("thug_to_kill_bathroom"))
      return;
    this.actionType = ObjectActionController.Type.Transition;
    this.doubleClickCondition = string.Empty;
    this.trans_dir = WalkController.Direction.N;
    this.GetComponent<SpriteRenderer>().enabled = true;
    this.objectName = "upstairs_ladder2";
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
  }

  public override void updateState()
  {
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjective("thug_to_kill_bathroom"))
    {
      this.actionType = ObjectActionController.Type.Transition;
      this.doubleClickCondition = string.Empty;
      this.trans_dir = WalkController.Direction.N;
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.objectName = "upstairs_ladder2";
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
    else if (GameDataController.gd.getObjective("day1_complete") && GameDataController.gd.getObjective("day_2_hatch_fallen"))
    {
      this.actionType = ObjectActionController.Type.Transition;
      this.doubleClickCondition = "visited_attic1";
      this.trans_dir = WalkController.Direction.N;
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.objectName = "upstairs_ladder2";
      this.interactions = new List<ItemInteraction>();
      this.interactions.Add(new ItemInteraction("flag", GameStrings.getString(GameStrings.actions, "hatch_wrong_side"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("blanket", GameStrings.getString(GameStrings.actions, "hatch_wrong_side"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("blanketb", GameStrings.getString(GameStrings.actions, "hatch_wrong_side"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("thermalb", GameStrings.getString(GameStrings.actions, "hatch_wrong_side"), anim: string.Empty));
    }
    else
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.actionType = ObjectActionController.Type.NormalAction;
      this.doubleClickCondition = "false";
      this.objectName = "upstairs_ladder";
      this.interactions = new List<ItemInteraction>();
      this.interactions.Add(new ItemInteraction("flag", GameStrings.getString(GameStrings.actions, "hatch_wrong_side"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("blanket", GameStrings.getString(GameStrings.actions, "hatch_wrong_side"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("blanketb", GameStrings.getString(GameStrings.actions, "hatch_wrong_side"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("thermalb", GameStrings.getString(GameStrings.actions, "hatch_wrong_side"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("crowbar", GameStrings.getString(GameStrings.actions, "crowbar_hatch"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("key2", GameStrings.getString(GameStrings.actions, "key_hatch"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("paperclip", GameStrings.getString(GameStrings.actions, "paperclip_hatch"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("wrench", GameStrings.getString(GameStrings.actions, "wrench_hatch"), anim: string.Empty));
    }
    if (!GameDataController.gd.getObjective("day1_complete") || !GameDataController.gd.getObjective("day_2_hatch_fallen"))
      return;
    if (GameDataController.gd.getObjective("base_hatch_flag"))
    {
      this.GetComponent<SpriteRenderer>().sprite = this.klapaFlag;
      if (GameDataController.gd.getCurrentDay() != 4 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 1 || GameDataController.gd.getObjective("lighting_rod_installed") && GameDataController.gd.getObjectiveDetail("day3_complete") >= 1)
        return;
      this.GetComponent<SpriteRenderer>().sprite = this.klapaFlag2;
    }
    else if (GameDataController.gd.getObjective("base_hatch_blanket"))
    {
      this.GetComponent<SpriteRenderer>().sprite = this.klapaBlanket;
      if (GameDataController.gd.getCurrentDay() != 4 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 1 || GameDataController.gd.getObjective("lighting_rod_installed") && GameDataController.gd.getObjectiveDetail("day3_complete") >= 1)
        return;
      this.GetComponent<SpriteRenderer>().sprite = this.klapaBlanket2;
    }
    else if (GameDataController.gd.getObjective("base_hatch_blanketb"))
    {
      this.GetComponent<SpriteRenderer>().sprite = this.klapaBlanketb;
      if (GameDataController.gd.getCurrentDay() != 4 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 1 || GameDataController.gd.getObjective("lighting_rod_installed") && GameDataController.gd.getObjectiveDetail("day3_complete") >= 1)
        return;
      this.GetComponent<SpriteRenderer>().sprite = this.klapaBlanketb2;
    }
    else if (GameDataController.gd.getObjective("base_hatch_therm"))
    {
      this.GetComponent<SpriteRenderer>().sprite = this.klapaThermb;
      if (GameDataController.gd.getCurrentDay() != 4 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 1 || GameDataController.gd.getObjective("lighting_rod_installed") && GameDataController.gd.getObjectiveDetail("day3_complete") >= 1)
        return;
      this.GetComponent<SpriteRenderer>().sprite = this.klapaThermb2;
    }
    else
    {
      this.GetComponent<SpriteRenderer>().sprite = this.klapa;
      if (GameDataController.gd.getCurrentDay() != 4 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 1 || GameDataController.gd.getObjective("lighting_rod_installed") && GameDataController.gd.getObjectiveDetail("day3_complete") >= 1)
        return;
      this.GetComponent<SpriteRenderer>().sprite = this.klapa2;
    }
  }

  public override void clickAction2()
  {
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjective("thug_to_kill_bathroom") || !GameDataController.gd.getObjective("day1_complete"))
      return;
    PlayerController.pc.spawnName = "Attic1Hatch1";
    CurtainController.cc.fadeOut("LocationAttic1", WalkController.Direction.SW, "kneel_out_se", flipX: true);
  }

  public override void clickAction0()
  {
  }
}
