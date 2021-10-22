// Decompiled with JetBrains decompiler
// Type: HuntersLodgeHatch
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class HuntersLodgeHatch : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_in_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "lodge_hatch";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("crowbar", string.Empty, anim: string.Empty));
  }

  private void yesClearIt()
  {
    PlayerController.pc.setBusy(true);
    GameDataController.gd.setObjective("hunters_lodge_chest_opened", true);
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.N, animation: "action1_e", flipX: true, actionAfterFade: new CurtainController.Delegate(this.doneClearing));
  }

  private void noCliear() => this.standup(string.Empty);

  private void doneClearing() => this.standup(string.Empty);

  private void standup(string param = "") => PlayerController.pc.setBusy(false);

  private void pickItUp(string param)
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("bear_trap_3")))
      return;
    GameDataController.gd.setObjective("hunters_lodge_trap_picked", true);
    this.updateAll();
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("hunters_lodge_chest_opened"))
    {
      if (this.usedItem == string.Empty)
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "hunters_hatch_locked"));
      else
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "lodge_back_hatch_force"), yesClick: new Button.Delegate(this.yesClearIt), time: 30, timeSaver: 5, noClick: new Button.Delegate(this.noCliear));
    }
    else if (!GameDataController.gd.getObjective("hunters_lodge_hatch_gun_taken"))
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("revolver_0")))
        return;
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "hunters_take_revolver"));
      GameDataController.gd.setObjective("hunters_lodge_hatch_gun_taken", true);
      this.updateAll();
    }
    else if (!GameDataController.gd.getObjective("hunters_lodge_hatch_ammo1_taken"))
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("rifle_ammo")))
        return;
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "hunters_take_ammo1"));
      GameDataController.gd.setObjective("hunters_lodge_hatch_ammo1_taken", true);
      this.updateAll();
    }
    else if (!GameDataController.gd.getObjective("hunters_lodge_hatch_ammo2_taken"))
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("gun_ammo")))
        return;
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "hunters_take_ammo2"));
      GameDataController.gd.setObjective("hunters_lodge_hatch_ammo2_taken", true);
      this.updateAll();
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "hunters_hatch_empty"));
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (!GameDataController.gd.getObjective("hunters_lodge_couch_moved"))
      this.colliderManager.setCollider(-1);
    if (!GameDataController.gd.getObjective("hunters_lodge_chest_opened"))
    {
      this.characterAnimationName = "action_stnd_n";
      this.GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      this.characterAnimationName = "kneel_n";
      this.GetComponent<SpriteRenderer>().enabled = true;
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
  }

  public override void whatOnClick()
  {
  }
}
