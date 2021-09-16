// Decompiled with JetBrains decompiler
// Type: Roof2Chimney
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class Roof2Chimney : ObjectActionController
{
  public SpriteRenderer piorunochron;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "roof_chimney";
    this.range = 1f;
    this.teleport = false;
    this.updateState();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("ropehook", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("wire", string.Empty, anim: string.Empty));
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
    if (this.usedItem == "ropehook" && !GameDataController.gd.getObjective("chimney_cleaned"))
    {
      this.characterAnimationName = "unclog";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else
    {
      this.characterAnimationName = "action_stnd_s";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
  }

  public override void clickAction()
  {
    if (this.usedItem == string.Empty)
    {
      if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
      {
        if (GameDataController.gd.getObjective("lighting_rod_installed"))
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "lighting_rod_installed_already"));
        else
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "good_spot_for_a_lighting_rod"));
      }
      else if (GameDataController.gd.getObjective("chimney_cleaned"))
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "roof_chimney_unclogged"), true, mwidth: 150);
      else
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "roof_chimney_clogged"), true, mwidth: 150);
    }
    else
    {
      if (this.usedItem == "ropehook")
      {
        if (GameDataController.gd.getObjective("chimney_cleaned"))
        {
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "roof_chimney_unclogged"), true, mwidth: 150);
        }
        else
        {
          GameDataController.gd.setObjective("chimney_cleaned", true);
          this.updateAll();
        }
      }
      if (!(this.usedItem == "wire"))
        return;
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "install_lighting_rod"), yesClick: new Button.Delegate(this.yesClick), time: 40, timeSaver: 6);
    }
  }

  private void yesClick()
  {
    CurtainController.cc.fadeOut();
    GameDataController.gd.setObjective("lighting_rod_installed", true);
    InventoryController.ic.removeItem("wire");
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "lighting_rod_installed"));
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjective("lighting_rod_installed"))
      this.piorunochron.enabled = true;
    else
      this.piorunochron.enabled = false;
    if (GameDataController.gd.getObjective("chimney_cleaned"))
      return;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("ropehook", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("wire", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("sonic", GameStrings.getString(GameStrings.actions, "chimney_longer"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("sonic2", GameStrings.getString(GameStrings.actions, "chimney_longer"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("shovel", GameStrings.getString(GameStrings.actions, "chimney_longer"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("pipe", GameStrings.getString(GameStrings.actions, "chimney_longer"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("hammer", GameStrings.getString(GameStrings.actions, "chimney_longer"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("crowbar", GameStrings.getString(GameStrings.actions, "chimney_longer"), anim: string.Empty));
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
