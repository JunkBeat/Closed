// Decompiled with JetBrains decompiler
// Type: RVCaveCovered
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class RVCaveCovered : ObjectActionController
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
    this.objectName = " ";
    this.actionType = ObjectActionController.Type.NormalAction;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("flag", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanket", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanketb", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("thermalb", string.Empty, anim: string.Empty));
    this.trans_dir = WalkController.Direction.S;
  }

  public override void whatOnClick0()
  {
    if (this.usedItem != string.Empty && (GameDataController.gd.getObjective("rv_cave_flag") || GameDataController.gd.getObjective("rv_cave_blanket") || GameDataController.gd.getObjective("rv_cave_blanketb") || GameDataController.gd.getObjective("rv_cave_therm")))
    {
      this.characterAnimationName = "action_stnd_";
      this.range = 100f;
    }
    else
    {
      if (!(this.usedItem == string.Empty))
        return;
      this.characterAnimationName = "action_stnd_";
      this.range = 1f;
    }
  }

  public override void clickAction()
  {
    if (this.usedItem == string.Empty)
    {
      string empty = string.Empty;
      if (GameDataController.gd.getObjective("rv_cave_flag"))
        empty = GameStrings.getString(GameStrings.items, "flag_short");
      if (GameDataController.gd.getObjective("rv_cave_blanket"))
        empty = GameStrings.getString(GameStrings.items, "blanket_short");
      if (GameDataController.gd.getObjective("rv_cave_blanketb"))
        empty = GameStrings.getString(GameStrings.items, "blanketb_short");
      if (GameDataController.gd.getObjective("rv_cave_therm"))
        empty = GameStrings.getString(GameStrings.items, "thermalb_short");
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "cave_remove_blanket1") + " " + empty + " " + GameStrings.getString(GameStrings.warnings, "cave_remove_blanket2"), yesClick: new Button.Delegate(this.doRemove), time: 10, timeSaver: 2);
    }
    else
    {
      if (!GameDataController.gd.getObjective("rv_cave_flag") && !GameDataController.gd.getObjective("rv_cave_blanket") && !GameDataController.gd.getObjective("rv_cave_blanketb") && !GameDataController.gd.getObjective("rv_cave_therm"))
        return;
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "hatch_busy"));
    }
  }

  public void doRemove()
  {
    if (GameDataController.gd.getObjective("rv_cave_flag"))
      InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("flag"));
    if (GameDataController.gd.getObjective("rv_cave_blanket"))
      InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("blanket"));
    if (GameDataController.gd.getObjective("rv_cave_blanketb"))
      InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("blanketb"));
    if (GameDataController.gd.getObjective("rv_cave_therm"))
      InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("thermalb"));
    GameDataController.gd.setObjective("rv_cave_flag", false);
    GameDataController.gd.setObjective("rv_cave_blanket", false);
    GameDataController.gd.setObjective("rv_cave_blanketb", false);
    GameDataController.gd.setObjective("rv_cave_therm", false);
    CurtainController.cc.fadeOut();
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjective("rv_cave_flag") || GameDataController.gd.getObjective("rv_cave_blanket") || GameDataController.gd.getObjective("rv_cave_blanketb") || GameDataController.gd.getObjective("rv_cave_therm"))
      this.colliderManager.setCollider(0);
    else
      this.colliderManager.setCollider(-1);
    if (GameDataController.gd.getObjective("rv_cave_flag"))
      this.objectName = "rv_cave_thing_flag";
    if (GameDataController.gd.getObjective("rv_cave_blanket"))
      this.objectName = "rv_cave_thing_blanket";
    if (GameDataController.gd.getObjective("rv_cave_blanketb"))
      this.objectName = "rv_cave_thing_blanket";
    if (!GameDataController.gd.getObjective("rv_cave_therm"))
      return;
    this.objectName = "rv_cave_thing_thermalb";
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
