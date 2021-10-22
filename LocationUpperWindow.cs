// Decompiled with JetBrains decompiler
// Type: LocationUpperWindow
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationUpperWindow : ObjectActionController
{
  private SpriteRenderer sr;
  public Sprite foil;
  public Sprite bars;
  public Sprite net;
  public Sprite foil_nailed;
  public Sprite bars_nailed;
  public Sprite net_nailed;
  public Sprite foil_taped;
  public Sprite bars_taped;
  public Sprite net_taped;
  public Sprite foil_taped_nailed;
  public Sprite bars_taped_nailed;
  public Sprite net_taped_nailed;
  public Sprite foil_nailed_broken;
  public Sprite bars_nailed_broken;
  public Sprite net_nailed_broken;
  public Sprite foil_taped_broken;
  public Sprite bars_taped_broken;
  public Sprite net_taped_broken;
  public Sprite foil_taped_nailed_broken;
  public Sprite bars_taped_nailed_broken;
  public Sprite net_taped_nailed_broken;
  public Sprite blanket;
  public Sprite blanket_taped;
  public Sprite blanket_nailed;
  public Sprite blanket_taped_nailed;
  public Sprite blanketb;
  public Sprite blanketb_taped;
  public Sprite blanketb_nailed;
  public Sprite blanketb_taped_nailed;
  public Sprite flag;
  public Sprite flag_taped;
  public Sprite flag_nailed;
  public Sprite flag_taped_nailed;
  public Sprite thermalb;
  public Sprite thermalb_taped;
  public Sprite thermalb_nailed;
  public Sprite thermalb_taped_nailed;
  public Sprite board;
  public Sprite board_taped;
  public Sprite board_nailed;
  public Sprite board_taped_nailed;
  public Sprite destroyed_taped;
  public Sprite destroyed_nailed;
  public Sprite destroyed_taped_nailed;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
    this.characterAnimationName = "stop";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "base_window_2";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("window_foil1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("window_foil2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("window_foil3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("window_bars1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("window_bars2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("window_bars3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("window_net1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("window_net2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("window_net3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ducttape", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("hammer", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("crowbar", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("nails1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("nails2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("nails3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("nails4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("nails5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("planks1", GameStrings.getString(GameStrings.actions, "window_planks"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("planks2", GameStrings.getString(GameStrings.actions, "window_planks"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("planks3", GameStrings.getString(GameStrings.actions, "window_planks"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("planks4", GameStrings.getString(GameStrings.actions, "window_planks"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("planks5", GameStrings.getString(GameStrings.actions, "window_planks"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ac", GameStrings.getString(GameStrings.actions, "ac_wrong_window"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("flag", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanket", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanketb", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("thermalb", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat1", GameStrings.getString(GameStrings.actions, "window_jacket"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat2", GameStrings.getString(GameStrings.actions, "window_jacket"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat3", GameStrings.getString(GameStrings.actions, "window_jacket"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat4", GameStrings.getString(GameStrings.actions, "window_jacket"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("board1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("board2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("board3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("tarpaulin", GameStrings.getString(GameStrings.actions, "window_tarpaulin"), anim: string.Empty));
    this.updateState();
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("base_window_2_net") && !GameDataController.gd.getObjective("base_window_2_bars") && !GameDataController.gd.getObjective("base_window_2_foil") && !GameDataController.gd.getObjective("base_window_2_therm") && !GameDataController.gd.getObjective("base_window_2_blanket") && !GameDataController.gd.getObjective("base_window_2_blanketb") && !GameDataController.gd.getObjective("base_window_2_flag") && !GameDataController.gd.getObjective("base_window_2_board"))
    {
      if (this.usedItem == "ducttape" || this.usedItem == "hammer" || this.usedItem.IndexOf("nails") != -1)
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "window_needs_material"), true);
      else if (this.usedItem == string.Empty)
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "window_empty"));
      else if (this.usedItem == "crowbar")
      {
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "window_crowbar"), true);
      }
      else
      {
        if (this.usedItem.IndexOf("window_bars") != -1)
          GameDataController.gd.setObjective("base_window_2_bars", true);
        else if (this.usedItem.IndexOf("window_net") != -1)
          GameDataController.gd.setObjective("base_window_2_net", true);
        else if (this.usedItem.IndexOf("window_foil") != -1)
          GameDataController.gd.setObjective("base_window_2_foil", true);
        else if (this.usedItem == "blanket")
          GameDataController.gd.setObjective("base_window_2_blanket", true);
        else if (this.usedItem == "blanketb")
          GameDataController.gd.setObjective("base_window_2_blanketb", true);
        else if (this.usedItem == "flag")
          GameDataController.gd.setObjective("base_window_2_flag", true);
        else if (this.usedItem == "thermalb")
          GameDataController.gd.setObjective("base_window_2_therm", true);
        else if (this.usedItem.IndexOf("board") != -1)
          GameDataController.gd.setObjective("base_window_2_board", true);
        InventoryController.ic.removeItem(this.usedItem);
        ItemsManager.im.updateItem(this.usedItem, "window2", 0, 0);
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "window_thing_placed"));
        this.updateState();
      }
    }
    else if (this.usedItem == string.Empty)
    {
      if (GameDataController.gd.getObjective("base_window_2_bars_nailed") || GameDataController.gd.getObjective("base_window_2_bars_taped") || GameDataController.gd.getObjective("base_window_2_net_nailed") || GameDataController.gd.getObjective("base_window_2_net_taped") || GameDataController.gd.getObjective("base_window_2_therm_nailed") || GameDataController.gd.getObjective("base_window_2_therm_taped") || GameDataController.gd.getObjective("base_window_2_flag_taped") || GameDataController.gd.getObjective("base_window_2_flag_nailed") || GameDataController.gd.getObjective("base_window_2_board_taped") || GameDataController.gd.getObjective("base_window_2_board_nailed") || GameDataController.gd.getObjective("base_window_2_blanket_taped") || GameDataController.gd.getObjective("base_window_2_blanketb_taped") || GameDataController.gd.getObjective("base_window_2_blanket_nailed") || GameDataController.gd.getObjective("base_window_2_blanketb_nailed") || GameDataController.gd.getObjective("base_window_2_foil_nailed") || GameDataController.gd.getObjective("base_window_2_foil_taped"))
      {
        if (GameDataController.gd.getObjective("base_window_2_bars_nailed") || GameDataController.gd.getObjective("base_window_2_foil_nailed") || GameDataController.gd.getObjective("base_window_2_therm_nailed") || GameDataController.gd.getObjective("base_window_2_flag_nailed") || GameDataController.gd.getObjective("base_window_2_board_nailed") || GameDataController.gd.getObjective("base_window_2_blanket_nailed") || GameDataController.gd.getObjective("base_window_2_blanketb_nailed") || GameDataController.gd.getObjective("base_window_2_net_nailed"))
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "window_remove_nails"), true);
        else
          QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "window_undo"), yesClick: new Button.Delegate(this.yesUndo), time: 15, timeSaver: 2);
      }
      else
      {
        Item[] objArray = new Item[16]
        {
          ItemsManager.im.getItem("window_net1"),
          ItemsManager.im.getItem("window_net2"),
          ItemsManager.im.getItem("window_net3"),
          ItemsManager.im.getItem("window_bars1"),
          ItemsManager.im.getItem("window_bars2"),
          ItemsManager.im.getItem("window_bars3"),
          ItemsManager.im.getItem("window_foil1"),
          ItemsManager.im.getItem("window_foil2"),
          ItemsManager.im.getItem("window_foil3"),
          ItemsManager.im.getItem("thermalb"),
          ItemsManager.im.getItem("blanket"),
          ItemsManager.im.getItem("blanketb"),
          ItemsManager.im.getItem("flag"),
          ItemsManager.im.getItem("board1"),
          ItemsManager.im.getItem("board2"),
          ItemsManager.im.getItem("board3")
        };
        for (int index = 0; index < objArray.Length; ++index)
        {
          if (objArray[index].dataRef.droppedLocation == "window2" && InventoryController.ic.pickUpItem(objArray[index]))
          {
            GameDataController.gd.setObjective("base_window_2_bars", false);
            GameDataController.gd.setObjective("base_window_2_net", false);
            GameDataController.gd.setObjective("base_window_2_foil", false);
            GameDataController.gd.setObjective("base_window_2_therm", false);
            GameDataController.gd.setObjective("base_window_2_flag", false);
            GameDataController.gd.setObjective("base_window_2_board", false);
            GameDataController.gd.setObjective("base_window_2_blanket", false);
            GameDataController.gd.setObjective("base_window_2_blanketb", false);
            this.updateState();
          }
        }
      }
    }
    else
    {
      if ((GameDataController.gd.getObjective("base_window_2_bars_nailed") || GameDataController.gd.getObjective("base_window_2_foil_nailed") || GameDataController.gd.getObjective("base_window_2_flag_nailed") || GameDataController.gd.getObjective("base_window_2_board_nailed") || GameDataController.gd.getObjective("base_window_2_therm_nailed") || GameDataController.gd.getObjective("base_window_2_blanket_nailed") || GameDataController.gd.getObjective("base_window_2_blanketb_nailed") || GameDataController.gd.getObjective("base_window_2_net_nailed")) && (this.usedItem == "hammer" || this.usedItem == "crowbar"))
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "window_undo"), yesClick: new Button.Delegate(this.yesUndo2), time: 15, timeSaver: 2);
      if (this.usedItem.IndexOf("window_bars") != -1 || this.usedItem.IndexOf("window_net") != -1 || this.usedItem.IndexOf("window_foil") != -1 || this.usedItem == "blanket" || this.usedItem == "blanketb" || this.usedItem == "thermalb" || this.usedItem == "flag" || this.usedItem.IndexOf("board") != -1)
      {
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "window_occupied"), true);
      }
      else
      {
        if (this.usedItem == "hammer" && (GameDataController.gd.getObjective("base_window_2_bars_nailed") || GameDataController.gd.getObjective("base_window_2_net_nailed") || GameDataController.gd.getObjective("base_window_2_flag_nailed") || GameDataController.gd.getObjective("base_window_2_board_nailed") || GameDataController.gd.getObjective("base_window_2_blanket_nailed") || GameDataController.gd.getObjective("base_window_2_blanketb_nailed") || GameDataController.gd.getObjective("base_window_2_therm_nailed") || GameDataController.gd.getObjective("base_window_2_foil_nailed")))
          return;
        if (this.usedItem == "ducttape" && (GameDataController.gd.getObjective("base_window_2_bars_taped") || GameDataController.gd.getObjective("base_window_2_net_taped") || GameDataController.gd.getObjective("base_window_2_foil_taped") || GameDataController.gd.getObjective("base_window_2_board_taped") || GameDataController.gd.getObjective("base_window_2_flag_taped") || GameDataController.gd.getObjective("base_window_2_blanket_taped") || GameDataController.gd.getObjective("base_window_2_blanketb_taped") || GameDataController.gd.getObjective("base_window_2_therm_taped")))
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "window_already_taped"), true);
        else if (this.usedItem == "hammer" && ItemsManager.im.getItem("nails1").dataRef.droppedLocation != "inventory" && ItemsManager.im.getItem("nails2").dataRef.droppedLocation != "inventory" && ItemsManager.im.getItem("nails3").dataRef.droppedLocation != "inventory" && ItemsManager.im.getItem("nails4").dataRef.droppedLocation != "inventory" && ItemsManager.im.getItem("nails5").dataRef.droppedLocation != "inventory")
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "no_nails"), true);
        else if (this.usedItem.IndexOf("nails") != -1 && ItemsManager.im.getItem("hammer").dataRef.droppedLocation != "inventory")
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "nails_fail"), true);
        else if (this.usedItem == "crowbar" && !GameDataController.gd.getObjective("base_window_2_bars_nailed") && !GameDataController.gd.getObjective("base_window_2_foil_nailed") && !GameDataController.gd.getObjective("base_window_2_flag_nailed") && !GameDataController.gd.getObjective("base_window_2_board_nailed") && !GameDataController.gd.getObjective("base_window_2_blanket_nailed") && !GameDataController.gd.getObjective("base_window_2_blanketb_nailed") && !GameDataController.gd.getObjective("base_window_2_therm_nailed") && !GameDataController.gd.getObjective("base_window_2_net_nailed"))
        {
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "window_crowbar"), true);
        }
        else
        {
          if (!(this.usedItem != "crowbar"))
            return;
          string str1 = "window_use";
          string key = this.usedItem.IndexOf("ducttape") == -1 ? str1 + "_hammer" : str1 + "_tape";
          if (GameDataController.gd.getObjective("base_window_2_bars"))
            key += "_bars";
          if (GameDataController.gd.getObjective("base_window_2_net"))
            key += "_net";
          if (GameDataController.gd.getObjective("base_window_2_foil"))
            key += "_foil";
          if (GameDataController.gd.getObjective("base_window_2_flag"))
            key += "_flag";
          if (GameDataController.gd.getObjective("base_window_2_board"))
            key += "_board";
          if (GameDataController.gd.getObjective("base_window_2_therm"))
            key += "_therm";
          if (GameDataController.gd.getObjective("base_window_2_blanket"))
            key += "_blanket";
          if (GameDataController.gd.getObjective("base_window_2_blanketb"))
            key += "_blanket";
          int time = 20;
          string str2 = string.Empty;
          if (GameDataController.gd.getCurrentDay() >= 2)
          {
            time = 35;
            str2 = "^" + GameStrings.getString(GameStrings.warnings, "worn_window");
          }
          QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, key) + str2, time: time, timeSaver: 4);
          if (this.usedItem.IndexOf("ducttape") != -1)
            QuestionController.qc.onYesClick = new Button.Delegate(this.yesTaped);
          else
            QuestionController.qc.onYesClick = new Button.Delegate(this.yesNailed);
        }
      }
    }
  }

  public void yesUndo2()
  {
    GameDataController.gd.setObjective("base_window_2_bars_nailed", false);
    GameDataController.gd.setObjective("base_window_2_bars_taped", false);
    GameDataController.gd.setObjective("base_window_2_net_nailed", false);
    GameDataController.gd.setObjective("base_window_2_net_taped", false);
    GameDataController.gd.setObjective("base_window_2_bars_taped", false);
    GameDataController.gd.setObjective("base_window_2_board_taped", false);
    GameDataController.gd.setObjective("base_window_2_board_nailed", false);
    GameDataController.gd.setObjective("base_window_2_foil_nailed", false);
    GameDataController.gd.setObjective("base_window_2_foil_taped", false);
    GameDataController.gd.setObjective("base_window_2_flag_taped", false);
    GameDataController.gd.setObjective("base_window_2_flag_nailed", false);
    GameDataController.gd.setObjective("base_window_2_blanket_taped", false);
    GameDataController.gd.setObjective("base_window_2_blanketb_taped", false);
    GameDataController.gd.setObjective("base_window_2_blanket_nailed", false);
    GameDataController.gd.setObjective("base_window_2_blanketb_nailed", false);
    GameDataController.gd.setObjective("base_window_2_therm_taped", false);
    GameDataController.gd.setObjective("base_window_2_therm_nailed", false);
    this.removeIfBroken(true);
    PlayerController.wc.dir = WalkController.Direction.N;
    CurtainController.cc.fadeOut();
    Item[] objArray = new Item[5]
    {
      ItemsManager.im.getItem("nails1"),
      ItemsManager.im.getItem("nails2"),
      ItemsManager.im.getItem("nails3"),
      ItemsManager.im.getItem("nails4"),
      ItemsManager.im.getItem("nails5")
    };
    for (int index = 0; index < objArray.Length; ++index)
    {
      if (objArray[index].dataRef.droppedLocation == "window2")
      {
        Item obj = objArray[index];
        obj.dataRef.locX = (int) PlayerController.wc.currentXY.x;
        obj.dataRef.locY = (int) PlayerController.wc.currentXY.y;
        obj.dataRef.droppedLocation = "LocationBaseUpstairs";
        Vector2 screen = ScreenControler.gameToScreen(new Vector2((float) obj.dataRef.locX, (float) (obj.dataRef.locY + GroundItemController.yOffset)));
        Vector3 position = new Vector3(screen.x, screen.y, 0.0f);
        position = Camera.main.ScreenToWorldPoint((Vector3) screen);
        (Object.Instantiate(Resources.Load("Prefabs/GroundItem"), position, new Quaternion()) as GameObject).GetComponent<GroundItemController>().init(obj);
      }
    }
  }

  public void removeIfBroken(bool hadNails = false)
  {
    if (!GameDataController.gd.getObjective("base_window2_broken"))
      return;
    GameDataController.gd.setObjective("base_window_2_bars", false);
    GameDataController.gd.setObjective("base_window_2_net", false);
    GameDataController.gd.setObjective("base_window_2_foil", false);
    if (ItemsManager.im.getItem("window_bars1").dataRef.droppedLocation == "window2")
      ItemsManager.im.getItem("window_bars1").dataRef.droppedLocation = "nowhere";
    if (ItemsManager.im.getItem("window_bars2").dataRef.droppedLocation == "window2")
      ItemsManager.im.getItem("window_bars2").dataRef.droppedLocation = "nowhere";
    if (ItemsManager.im.getItem("window_bars3").dataRef.droppedLocation == "window2")
      ItemsManager.im.getItem("window_bars3").dataRef.droppedLocation = "nowhere";
    if (ItemsManager.im.getItem("window_net1").dataRef.droppedLocation == "window2")
      ItemsManager.im.getItem("window_net1").dataRef.droppedLocation = "nowhere";
    if (ItemsManager.im.getItem("window_net2").dataRef.droppedLocation == "window2")
      ItemsManager.im.getItem("window_net2").dataRef.droppedLocation = "nowhere";
    if (ItemsManager.im.getItem("window_net3").dataRef.droppedLocation == "window2")
      ItemsManager.im.getItem("window_net3").dataRef.droppedLocation = "nowhere";
    if (ItemsManager.im.getItem("window_foil1").dataRef.droppedLocation == "window2")
      ItemsManager.im.getItem("window_foil1").dataRef.droppedLocation = "nowhere";
    if (ItemsManager.im.getItem("window_foil2").dataRef.droppedLocation == "window2")
      ItemsManager.im.getItem("window_foil2").dataRef.droppedLocation = "nowhere";
    if (ItemsManager.im.getItem("window_foil3").dataRef.droppedLocation == "window2")
      ItemsManager.im.getItem("window_foil3").dataRef.droppedLocation = "nowhere";
    if (ItemsManager.im.getItem("board1").dataRef.droppedLocation == "window2")
      ItemsManager.im.getItem("board1").dataRef.droppedLocation = "nowhere";
    if (ItemsManager.im.getItem("board2").dataRef.droppedLocation == "window2")
      ItemsManager.im.getItem("board2").dataRef.droppedLocation = "nowhere";
    if (ItemsManager.im.getItem("board3").dataRef.droppedLocation == "window2")
      ItemsManager.im.getItem("board3").dataRef.droppedLocation = "nowhere";
    string key = "window_it_was_broken";
    if (hadNails)
      key = "window_it_was_broken2";
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, key));
    GameDataController.gd.setObjective("base_window2_broken", false);
  }

  public void yesUndo()
  {
    GameDataController.gd.setObjective("base_window_2_bars_nailed", false);
    GameDataController.gd.setObjective("base_window_2_bars_taped", false);
    GameDataController.gd.setObjective("base_window_2_net_nailed", false);
    GameDataController.gd.setObjective("base_window_2_net_taped", false);
    GameDataController.gd.setObjective("base_window_2_bars_taped", false);
    GameDataController.gd.setObjective("base_window_2_foil_nailed", false);
    GameDataController.gd.setObjective("base_window_2_foil_taped", false);
    GameDataController.gd.setObjective("base_window_2_board_nailed", false);
    GameDataController.gd.setObjective("base_window_2_board_taped", false);
    GameDataController.gd.setObjective("base_window_2_flag_taped", false);
    GameDataController.gd.setObjective("base_window_2_flag_nailed", false);
    GameDataController.gd.setObjective("base_window_2_blanket_taped", false);
    GameDataController.gd.setObjective("base_window_2_blanketb_taped", false);
    GameDataController.gd.setObjective("base_window_2_blanket_nailed", false);
    GameDataController.gd.setObjective("base_window_2_blanketb_nailed", false);
    GameDataController.gd.setObjective("base_window_2_therm_taped", false);
    GameDataController.gd.setObjective("base_window_2_therm_nailed", false);
    this.removeIfBroken();
    PlayerController.wc.dir = WalkController.Direction.N;
    CurtainController.cc.fadeOut();
  }

  public void yesTaped()
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.duct_tape_use);
    if (GameDataController.gd.getObjective("base_window_2_bars"))
      GameDataController.gd.setObjective("base_window_2_bars_taped", true);
    if (GameDataController.gd.getObjective("base_window_2_net"))
      GameDataController.gd.setObjective("base_window_2_net_taped", true);
    if (GameDataController.gd.getObjective("base_window_2_foil"))
      GameDataController.gd.setObjective("base_window_2_foil_taped", true);
    if (GameDataController.gd.getObjective("base_window_2_flag"))
      GameDataController.gd.setObjective("base_window_2_flag_taped", true);
    if (GameDataController.gd.getObjective("base_window_2_blanket"))
      GameDataController.gd.setObjective("base_window_2_blanket_taped", true);
    if (GameDataController.gd.getObjective("base_window_2_board"))
      GameDataController.gd.setObjective("base_window_2_board_taped", true);
    if (GameDataController.gd.getObjective("base_window_2_blanketb"))
      GameDataController.gd.setObjective("base_window_2_blanketb_taped", true);
    if (GameDataController.gd.getObjective("base_window_2_therm"))
      GameDataController.gd.setObjective("base_window_2_therm_taped", true);
    PlayerController.wc.dir = WalkController.Direction.N;
    CurtainController.cc.fadeOut();
  }

  public void yesNailed()
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.nailed);
    if (GameDataController.gd.getObjective("base_window_2_bars"))
      GameDataController.gd.setObjective("base_window_2_bars_nailed", true);
    if (GameDataController.gd.getObjective("base_window_2_net"))
      GameDataController.gd.setObjective("base_window_2_net_nailed", true);
    if (GameDataController.gd.getObjective("base_window_2_foil"))
      GameDataController.gd.setObjective("base_window_2_foil_nailed", true);
    if (GameDataController.gd.getObjective("base_window_2_flag"))
      GameDataController.gd.setObjective("base_window_2_flag_nailed", true);
    if (GameDataController.gd.getObjective("base_window_2_board"))
      GameDataController.gd.setObjective("base_window_2_board_nailed", true);
    if (GameDataController.gd.getObjective("base_window_2_blanket"))
      GameDataController.gd.setObjective("base_window_2_blanket_nailed", true);
    if (GameDataController.gd.getObjective("base_window_2_blanketb"))
      GameDataController.gd.setObjective("base_window_2_blanketb_nailed", true);
    if (GameDataController.gd.getObjective("base_window_2_therm"))
      GameDataController.gd.setObjective("base_window_2_therm_nailed", true);
    Item[] objArray = new Item[5]
    {
      ItemsManager.im.getItem("nails1"),
      ItemsManager.im.getItem("nails2"),
      ItemsManager.im.getItem("nails3"),
      ItemsManager.im.getItem("nails4"),
      ItemsManager.im.getItem("nails5")
    };
    Item obj = (Item) null;
    for (int index = 0; index < objArray.Length; ++index)
    {
      if (objArray[index].dataRef.droppedLocation == "inventory")
      {
        obj = objArray[index];
        break;
      }
    }
    InventoryController.ic.removeItem(obj.id);
    ItemsManager.im.updateItem(obj.id, "window2", 0, 0);
    PlayerController.wc.dir = WalkController.Direction.N;
    CurtainController.cc.fadeOut();
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("base_window_2_net") && !GameDataController.gd.getObjective("base_window_2_bars") && !GameDataController.gd.getObjective("base_window_2_foil") && !GameDataController.gd.getObjective("base_window_2_flag") && !GameDataController.gd.getObjective("base_window_2_board") && !GameDataController.gd.getObjective("base_window_2_blanket") && !GameDataController.gd.getObjective("base_window_2_blanketb") && !GameDataController.gd.getObjective("base_window_2_therm"))
    {
      this.sr.sprite = (Sprite) null;
      this.objectName = "base_window_2";
    }
    else if (GameDataController.gd.getObjective("base_window_2_net"))
    {
      if (GameDataController.gd.getObjective("base_window_2_net_nailed") && GameDataController.gd.getObjective("base_window_2_net_taped"))
      {
        this.sr.sprite = this.net_taped_nailed;
        this.objectName = "base_window_net_taped_nailed";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.net_taped_nailed_broken;
        this.objectName = "base_window_barricade_broken";
      }
      else if (GameDataController.gd.getObjective("base_window_2_net_nailed"))
      {
        this.sr.sprite = this.net_nailed;
        this.objectName = "base_window_net_nailed";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.net_nailed_broken;
        this.objectName = "base_window_barricade_broken";
      }
      else if (GameDataController.gd.getObjective("base_window_2_net_taped"))
      {
        this.sr.sprite = this.net_taped;
        this.objectName = "base_window_net_taped";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.net_taped_broken;
        this.objectName = "base_window_barricade_broken";
      }
      else
      {
        this.sr.sprite = this.net;
        this.objectName = "base_window_net";
      }
    }
    else if (GameDataController.gd.getObjective("base_window_2_bars"))
    {
      if (GameDataController.gd.getObjective("base_window_2_bars_nailed") && GameDataController.gd.getObjective("base_window_2_bars_taped"))
      {
        this.sr.sprite = this.bars_taped_nailed;
        this.objectName = "base_window_bars_taped_nailed";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.bars_taped_nailed_broken;
        this.objectName = "base_window_barricade_broken";
      }
      else if (GameDataController.gd.getObjective("base_window_2_bars_nailed"))
      {
        this.sr.sprite = this.bars_nailed;
        this.objectName = "base_window_bars_nailed";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.bars_nailed_broken;
        this.objectName = "base_window_barricade_broken";
      }
      else if (GameDataController.gd.getObjective("base_window_2_bars_taped"))
      {
        this.sr.sprite = this.bars_taped;
        this.objectName = "base_window_bars_taped";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.bars_taped_broken;
        this.objectName = "base_window_barricade_broken";
      }
      else
      {
        this.sr.sprite = this.bars;
        this.objectName = "base_window_bars";
      }
    }
    else if (GameDataController.gd.getObjective("base_window_2_board"))
    {
      if (GameDataController.gd.getObjective("base_window_2_board_nailed") && GameDataController.gd.getObjective("base_window_2_board_taped"))
      {
        this.sr.sprite = this.board_taped_nailed;
        this.objectName = "base_window_board_taped_nailed";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.destroyed_taped_nailed;
        this.objectName = "base_window_barricade_broken";
      }
      else if (GameDataController.gd.getObjective("base_window_2_board_nailed"))
      {
        this.sr.sprite = this.board_nailed;
        this.objectName = "base_window_board_nailed";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.destroyed_nailed;
        this.objectName = "base_window_barricade_broken";
      }
      else if (GameDataController.gd.getObjective("base_window_2_board_taped"))
      {
        this.sr.sprite = this.board_taped;
        this.objectName = "base_window_board_taped";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.destroyed_taped;
        this.objectName = "base_window_barricade_broken";
      }
      else
      {
        this.sr.sprite = this.board;
        this.objectName = "base_window_board";
      }
    }
    else if (GameDataController.gd.getObjective("base_window_2_foil"))
    {
      if (GameDataController.gd.getObjective("base_window_2_foil_nailed") && GameDataController.gd.getObjective("base_window_2_foil_taped"))
      {
        this.sr.sprite = this.foil_taped_nailed;
        this.objectName = "base_window_foil_taped_nailed";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.foil_taped_nailed_broken;
        this.objectName = "base_window_barricade_broken";
      }
      else if (GameDataController.gd.getObjective("base_window_2_foil_nailed"))
      {
        this.sr.sprite = this.foil_nailed;
        this.objectName = "base_window_foil_nailed";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.foil_nailed_broken;
        this.objectName = "base_window_barricade_broken";
      }
      else if (GameDataController.gd.getObjective("base_window_2_foil_taped"))
      {
        this.sr.sprite = this.foil_taped;
        this.objectName = "base_window_foil_taped";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.foil_taped_broken;
        this.objectName = "base_window_barricade_broken";
      }
      else
      {
        this.sr.sprite = this.foil;
        this.objectName = "base_window_foil";
      }
    }
    else if (GameDataController.gd.getObjective("base_window_2_flag"))
    {
      if (GameDataController.gd.getObjective("base_window_2_flag_nailed") && GameDataController.gd.getObjective("base_window_2_flag_taped"))
      {
        this.sr.sprite = this.flag_taped_nailed;
        this.objectName = "base_window_flag_taped_nailed";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.destroyed_taped_nailed;
        this.objectName = "base_window_barricade_broken";
      }
      else if (GameDataController.gd.getObjective("base_window_2_flag_nailed"))
      {
        this.sr.sprite = this.flag_nailed;
        this.objectName = "base_window_flag_nailed";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.destroyed_nailed;
        this.objectName = "base_window_barricade_broken";
      }
      else if (GameDataController.gd.getObjective("base_window_2_flag_taped"))
      {
        this.sr.sprite = this.flag_taped;
        this.objectName = "base_window_flag_taped";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.destroyed_taped;
        this.objectName = "base_window_barricade_broken";
      }
      else
      {
        this.sr.sprite = this.flag;
        this.objectName = "base_window_flag";
      }
    }
    else if (GameDataController.gd.getObjective("base_window_2_blanket"))
    {
      if (GameDataController.gd.getObjective("base_window_2_blanket_nailed") && GameDataController.gd.getObjective("base_window_2_blanket_taped"))
      {
        this.sr.sprite = this.blanket_taped_nailed;
        this.objectName = "base_window_blanket_taped_nailed";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.destroyed_taped_nailed;
        this.objectName = "base_window_barricade_broken";
      }
      else if (GameDataController.gd.getObjective("base_window_2_blanket_nailed"))
      {
        this.sr.sprite = this.blanket_nailed;
        this.objectName = "base_window_blanket_nailed";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.destroyed_nailed;
        this.objectName = "base_window_barricade_broken";
      }
      else if (GameDataController.gd.getObjective("base_window_2_blanket_taped"))
      {
        this.sr.sprite = this.blanket_taped;
        this.objectName = "base_window_blanket_taped";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.destroyed_taped;
        this.objectName = "base_window_barricade_broken";
      }
      else
      {
        this.sr.sprite = this.blanket;
        this.objectName = "base_window_blanket";
      }
    }
    else if (GameDataController.gd.getObjective("base_window_2_blanketb"))
    {
      if (GameDataController.gd.getObjective("base_window_2_blanketb_nailed") && GameDataController.gd.getObjective("base_window_2_blanketb_taped"))
      {
        this.sr.sprite = this.blanketb_taped_nailed;
        this.objectName = "base_window_blanketb_taped_nailed";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.destroyed_taped_nailed;
        this.objectName = "base_window_barricade_broken";
      }
      else if (GameDataController.gd.getObjective("base_window_2_blanketb_nailed"))
      {
        this.sr.sprite = this.blanketb_nailed;
        this.objectName = "base_window_blanketb_nailed";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.destroyed_nailed;
        this.objectName = "base_window_barricade_broken";
      }
      else if (GameDataController.gd.getObjective("base_window_2_blanketb_taped"))
      {
        this.sr.sprite = this.blanketb_taped;
        this.objectName = "base_window_blanketb_taped";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.destroyed_taped;
        this.objectName = "base_window_barricade_broken";
      }
      else
      {
        this.sr.sprite = this.blanketb;
        this.objectName = "base_window_blanketb";
      }
    }
    else
    {
      if (!GameDataController.gd.getObjective("base_window_2_therm"))
        return;
      if (GameDataController.gd.getObjective("base_window_2_therm_nailed") && GameDataController.gd.getObjective("base_window_2_therm_taped"))
      {
        this.sr.sprite = this.thermalb_taped_nailed;
        this.objectName = "base_window_therm_taped_nailed";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.destroyed_taped_nailed;
        this.objectName = "base_window_barricade_broken";
      }
      else if (GameDataController.gd.getObjective("base_window_2_therm_nailed"))
      {
        this.sr.sprite = this.thermalb_nailed;
        this.objectName = "base_window_therm_nailed";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.destroyed_nailed;
        this.objectName = "base_window_barricade_broken";
      }
      else if (GameDataController.gd.getObjective("base_window_2_therm_taped"))
      {
        this.sr.sprite = this.thermalb_taped;
        this.objectName = "base_window_therm_taped";
        if (!GameDataController.gd.getObjective("base_window2_broken"))
          return;
        this.sr.sprite = this.destroyed_taped;
        this.objectName = "base_window_barricade_broken";
      }
      else
      {
        this.sr.sprite = this.thermalb;
        this.objectName = "base_window_therm";
      }
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick()
  {
    this.doubleClickCondition = string.Empty;
    if (!GameDataController.gd.getObjective("base_window_2_bars") && !GameDataController.gd.getObjective("base_window_2_net") && !GameDataController.gd.getObjective("base_window_2_foil") && (this.usedItem.IndexOf("window_bars") != -1 || this.usedItem.IndexOf("window_foil") != -1 || this.usedItem.IndexOf("window_net") != -1 || this.usedItem.IndexOf("board") != -1 || this.usedItem == "blanket" || this.usedItem == "blanketb" || this.usedItem == "thermalb" || this.usedItem == "flag") || this.usedItem == string.Empty && (GameDataController.gd.getObjective("base_window_2_bars") || GameDataController.gd.getObjective("base_window_2_net") || GameDataController.gd.getObjective("base_window_2_foil") || GameDataController.gd.getObjective("base_window_2_flag") || GameDataController.gd.getObjective("base_window_2_blanket") || GameDataController.gd.getObjective("base_window_2_blanketb") || GameDataController.gd.getObjective("base_window_2_board") || GameDataController.gd.getObjective("base_window_2_therm")))
    {
      if (this.usedItem != string.Empty)
      {
        this.characterAnimationName = "action_stnd_n";
        this.animationFlip = false;
      }
      else if (GameDataController.gd.getObjective("base_window_2_bars_nailed") || GameDataController.gd.getObjective("base_window_2_bars_taped") || GameDataController.gd.getObjective("base_window_2_net_nailed") || GameDataController.gd.getObjective("base_window_2_net_taped") || GameDataController.gd.getObjective("base_window_2_therm_nailed") || GameDataController.gd.getObjective("base_window_2_therm_taped") || GameDataController.gd.getObjective("base_window_2_foil_nailed") || GameDataController.gd.getObjective("base_window_2_foil_taped") || GameDataController.gd.getObjective("base_window_2_board_nailed") || GameDataController.gd.getObjective("base_window_2_board_taped") || GameDataController.gd.getObjective("base_window_2_blanketb_nailed") || GameDataController.gd.getObjective("base_window_2_blanket_nailed") || GameDataController.gd.getObjective("base_window_2_blanketb_taped") || GameDataController.gd.getObjective("base_window_2_blanket_taped") || GameDataController.gd.getObjective("base_window_2_foil_nailed") || GameDataController.gd.getObjective("base_window_2_foil_taped"))
      {
        this.characterAnimationName = "action_stnd_n";
        this.animationFlip = false;
        this.doubleClickCondition = "none";
      }
      else
      {
        this.characterAnimationName = "action_n";
        this.animationFlip = false;
      }
    }
    else
    {
      this.characterAnimationName = "action_stnd_n";
      this.animationFlip = false;
    }
  }
}
