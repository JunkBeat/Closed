// Decompiled with JetBrains decompiler
// Type: WaypointRVCave
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class WaypointRVCave : ObjectActionController
{
  public Sprite klapaFlag;
  public Sprite klapaBlanket;
  public Sprite klapaBlanketb;
  public Sprite klapaThermb;
  public string whatYouGet = string.Empty;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "rv_cave";
    this.actionType = ObjectActionController.Type.Transition;
    this.doubleClickCondition = "visited_cave";
    this.trans_dir = WalkController.Direction.S;
    this.range = 2f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("ropehook", GameStrings.getString(GameStrings.actions, "rv_cave_hook_missclick"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ac", GameStrings.getString(GameStrings.actions, "ac_cave_down"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("flag", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanket", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanketb", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("thermalb", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ext_cord_place", string.Empty, anim: string.Empty));
  }

  public override void whatOnClick0()
  {
    if (this.usedItem != string.Empty && (GameDataController.gd.getObjective("rv_cave_flag") || GameDataController.gd.getObjective("rv_cave_blanket") || GameDataController.gd.getObjective("rv_cave_blanketb") || GameDataController.gd.getObjective("rv_cave_therm")))
    {
      this.characterAnimationName = "action_stnd_";
      this.range = 100f;
    }
    else if (this.usedItem != string.Empty && this.usedItem != "ext_cord_place")
    {
      this.characterAnimationName = "kneel_";
      this.range = 1f;
    }
    else
    {
      this.range = 1f;
      this.characterAnimationName = "stop";
    }
    if (!(this.usedItem == "ext_cord_place"))
      return;
    this.range = 1000f;
  }

  public override void clickAction()
  {
    if (this.usedItem == string.Empty || this.usedItem == "ext_cord_place")
    {
      if (GameDataController.gd.getObjective("rv_hook_installed"))
      {
        if (this.usedItem == "ext_cord_place")
        {
          GameDataController.gd.setObjective("rv_cord_caved", true);
          PlayerController.pc.spawnName = "WaypointCave";
          CurtainController.cc.fadeOut("LocationCave", WalkController.Direction.S);
        }
        else
        {
          PlayerController.pc.spawnName = "WaypointCave";
          CurtainController.cc.fadeOut("LocationCave", WalkController.Direction.S);
        }
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "rv_cave_cant"));
    }
    else if (GameDataController.gd.getObjective("rv_cave_flag") || GameDataController.gd.getObjective("rv_cave_blanket") || GameDataController.gd.getObjective("rv_cave_blanketb") || GameDataController.gd.getObjective("rv_cave_therm"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "hatch_busy"));
    }
    else
    {
      this.whatYouGet = this.usedItem;
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "cave_put_blanket1") + " " + GameStrings.getString(GameStrings.items, this.usedItem + "_short") + " " + GameStrings.getString(GameStrings.warnings, "cave_put_blanket2"), yesClick: new Button.Delegate(this.doPut), time: 40, timeSaver: 6);
    }
  }

  private void doPut()
  {
    if (this.whatYouGet == "flag")
      GameDataController.gd.setObjective("rv_cave_flag", true);
    else if (this.whatYouGet == "blanket")
      GameDataController.gd.setObjective("rv_cave_blanket", true);
    else if (this.whatYouGet == "blanketb")
      GameDataController.gd.setObjective("rv_cave_blanketb", true);
    else if (this.whatYouGet == "thermalb")
      GameDataController.gd.setObjective("rv_cave_therm", true);
    InventoryController.ic.removeItem(this.whatYouGet);
    CurtainController.cc.fadeOut();
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjective("rv_hook_installed"))
    {
      this.actionType = ObjectActionController.Type.Transition;
      this.doubleClickCondition = "visited_cave";
    }
    else
    {
      this.doubleClickCondition = "none";
      this.actionType = ObjectActionController.Type.NormalAction;
    }
    if (GameDataController.gd.getObjective("rv_cave_flag") || GameDataController.gd.getObjective("rv_cave_blanket") || GameDataController.gd.getObjective("rv_cave_blanketb") || GameDataController.gd.getObjective("rv_cave_therm"))
    {
      this.colliderManager.setCollider(1);
      this.GetComponent<SpriteRenderer>().enabled = true;
      if (GameDataController.gd.getObjective("rv_cave_flag"))
        this.GetComponent<SpriteRenderer>().sprite = this.klapaFlag;
      if (GameDataController.gd.getObjective("rv_cave_blanket"))
        this.GetComponent<SpriteRenderer>().sprite = this.klapaBlanket;
      if (GameDataController.gd.getObjective("rv_cave_blanketb"))
        this.GetComponent<SpriteRenderer>().sprite = this.klapaBlanketb;
      if (!GameDataController.gd.getObjective("rv_cave_therm"))
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
