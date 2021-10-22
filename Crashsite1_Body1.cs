// Decompiled with JetBrains decompiler
// Type: Crashsite1_Body1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class Crashsite1_Body1 : ObjectActionController
{
  public Sprite biteBackground;
  public Sprite bite1;
  public Sprite bite2;
  public Sprite bite3;
  public Sprite bite4;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      this.objectName = "crashsite_body1_bugs_a";
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
      this.objectName = "crashsite_body1_gas_a";
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
      this.objectName = "crashsite_body1_spiders_a";
    this.updateState();
  }

  public void showIt() => this.colliderManager.setCollider(0);

  public void hideIt() => this.colliderManager.setCollider(-1);

  public override void clickAction2()
  {
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
    {
      if (!GameDataController.gd.getObjective("crashsite_sonic_remote_taken"))
      {
        this.characterAnimationName = "kneel_n";
        this.useCurrentDirection = false;
        this.objectName = "crashsite_body1_bugs_a";
      }
      else
      {
        this.characterAnimationName = "action_stnd_";
        this.useCurrentDirection = true;
        this.objectName = "crashsite_body1_bugs_b";
      }
    }
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
    {
      if (!GameDataController.gd.getObjective("mask_filter_taken"))
      {
        this.characterAnimationName = "kneel_n";
        this.objectName = "crashsite_body1_gas_a";
        this.useCurrentDirection = false;
      }
      else
      {
        this.characterAnimationName = "action_stnd_";
        this.objectName = "crashsite_body1_gas_b";
        this.useCurrentDirection = true;
      }
    }
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
    {
      this.characterAnimationName = "kneel_in_n";
      this.objectName = "crashsite_body1_spiders_a";
      this.useCurrentDirection = false;
    }
    if (GameDataController.gd.getCurrentDay() > 1)
      this.hideIt();
    else
      this.showIt();
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
    {
      if (GameDataController.gd.getObjective("crashsite_sonic_remote_taken") || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("sonic_remote")))
        return;
      GameDataController.gd.setObjective("crashsite_sonic_remote_taken", true);
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "crashsite_body1_bugs_remote2"), true);
      this.updateState();
    }
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
    {
      if (GameDataController.gd.getObjective("mask_filter_taken") || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("mask_filter")))
        return;
      GameDataController.gd.setObjective("mask_filter_taken", true);
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "crashsite_body1_gas_filter2"), true);
      this.updateState();
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 2)
        return;
      Sprite sprite1 = (Sprite) null;
      if (GameDataController.gd.getObjectiveDetail("spiders_type") == 0)
        sprite1 = this.bite1;
      if (GameDataController.gd.getObjectiveDetail("spiders_type") == 1)
        sprite1 = this.bite2;
      if (GameDataController.gd.getObjectiveDetail("spiders_type") == 2)
        sprite1 = this.bite3;
      if (GameDataController.gd.getObjectiveDetail("spiders_type") == 3)
        sprite1 = this.bite4;
      ExamineSprite.es.closingAnimation = "kneel_out_n";
      ExamineSprite.es.show(this.biteBackground, sprite1);
    }
  }

  public override void clickAction0()
  {
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
    {
      if (!GameDataController.gd.getObjective("crashsite_sonic_remote_taken"))
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "crashsite_body1_bugs_remote1"), true);
      else
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "crashsite_body1_bugs_remote3"), true);
    }
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
    {
      if (!GameDataController.gd.getObjective("mask_filter_taken"))
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "crashsite_body1_gas_filter1"), true);
      else
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "crashsite_body1_gas_filter3"), true);
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 2)
        return;
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "crashsite_spider_body_start"), true);
    }
  }
}
