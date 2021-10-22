// Decompiled with JetBrains decompiler
// Type: GasstationTrinkets
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class GasstationTrinkets : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_trinkets";
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited") || GameDataController.gd.getObjective("gasstation_lighter_taken") || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("lighter")))
      return;
    GameDataController.gd.setObjective("gasstation_lighter_taken", true);
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (!GameDataController.gd.getObjective("gasstation_lighter_taken"))
    {
      this.characterAnimationName = "action1_e";
      this.animationFlip = true;
      this.useCurrentDirection = false;
    }
    else
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited"))
      return;
    if (!GameDataController.gd.getObjective("gasstation_lighter_taken"))
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "gasstation_trinkets_lighter"), true);
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "gasstation_trinkets_empty"), true);
  }

  public override void whatOnClick()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited"))
    {
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "nasty_spider_blocking"), true);
      PlayerController.wc.fullStop(true);
    }
    if (!GameDataController.gd.getObjective("gasstation_lighter_taken"))
    {
      this.characterAnimationName = "action1_e";
      this.animationFlip = true;
      this.useCurrentDirection = false;
    }
    else
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
  }

  public override void whatOnClick0()
  {
  }
}
