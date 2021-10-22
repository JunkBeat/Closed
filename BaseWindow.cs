// Decompiled with JetBrains decompiler
// Type: BaseWindow
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class BaseWindow : ObjectActionController
{
  public Sprite glass;
  public Sprite bars;
  public Sprite net;
  public Sprite foil;
  public Sprite blanket;
  public Sprite blanketb;
  public Sprite flag;
  public Sprite therm;
  public Sprite board;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "break_window2";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "base_window";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("pipe", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("watersprayer", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("flag", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanket", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanketb", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("thermalb", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("window_foil1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("window_foil2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("window_foil3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("window_bars1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("window_bars2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("window_bars3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("window_net1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("window_net2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("window_net3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("board1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("board2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("board3", string.Empty, anim: string.Empty));
  }

  public override void clickAction2() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.break_window);

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("outside0_window_broken"))
    {
      if (this.usedItem == string.Empty)
      {
        if (GameDataController.gd.getObjective("base_window_1_foil") || GameDataController.gd.getObjective("base_window_1_net") || GameDataController.gd.getObjective("base_window_1_bars") || GameDataController.gd.getObjective("base_window_1_foil") || GameDataController.gd.getObjective("base_window_1_blanket") || GameDataController.gd.getObjective("base_window_1_blanketb") || GameDataController.gd.getObjective("base_window_1_therm") || GameDataController.gd.getObjective("base_window_1_board") || GameDataController.gd.getObjective("base_window_1_flag"))
        {
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "window_blocked"), true);
        }
        else
        {
          PlayerController.pc.spawnName = "Window";
          CurtainController.cc.fadeOut("Location1", WalkController.Direction.S, "window_jump");
        }
      }
      else if (this.usedItem == "pipe" || !(this.usedItem == "watersprayer"))
        ;
    }
    else if (this.usedItem == "pipe")
    {
      GameDataController.gd.setObjective("outside0_window_broken", !GameDataController.gd.getObjective("outside0_window_broken"));
      this.updateState();
      PlayerController.wc.dir = WalkController.Direction.NW;
    }
    else if (this.usedItem == "watersprayer")
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "window_watersprayer"));
    else if (this.usedItem != string.Empty)
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "window_wrong_side"));
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "window_glass"), true);
  }

  public override void updateState()
  {
    this.doubleClickCondition = string.Empty;
    if (GameDataController.gd.getObjective("outside0_window_broken"))
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.actionType = ObjectActionController.Type.NormalAction;
      if (GameDataController.gd.getObjective("base_window_1_foil"))
      {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.foil;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      }
      else if (GameDataController.gd.getObjective("base_window_1_net"))
      {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.net;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      }
      else if (GameDataController.gd.getObjective("base_window_1_bars"))
      {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.bars;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      }
      else if (GameDataController.gd.getObjective("base_window_1_board"))
      {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.board;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      }
      else if (GameDataController.gd.getObjective("base_window_1_therm"))
      {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.therm;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      }
      else if (GameDataController.gd.getObjective("base_window_1_flag"))
      {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.flag;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      }
      else if (GameDataController.gd.getObjective("base_window_1_blanket"))
      {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.blanket;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      }
      else if (GameDataController.gd.getObjective("base_window_1_blanketb"))
      {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.blanketb;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      }
      else
      {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.doubleClickCondition = "visited_location1";
        this.actionType = ObjectActionController.Type.Transition;
        this.trans_dir = WalkController.Direction.E;
      }
      this.objectName = "base_window_broken";
    }
    else
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.glass;
      this.objectName = "base_window";
    }
  }

  public override void whatOnClick()
  {
    if (this.usedItem == "pipe")
    {
      if (GameDataController.gd.getObjective("outside0_window_broken"))
      {
        this.characterAnimationName = "action_stnd_n";
        this.animationFlip = false;
      }
      else
      {
        this.characterAnimationName = "break_window2";
        this.animationFlip = true;
      }
    }
    else
    {
      this.animationFlip = false;
      this.characterAnimationName = "action_stnd_n";
    }
  }

  public override void clickAction0()
  {
  }
}
