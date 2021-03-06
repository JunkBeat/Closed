// Decompiled with JetBrains decompiler
// Type: GasstationCorpse
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class GasstationCorpse : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_s";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.range = 100f;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_corpse";
    this.updateState();
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited"))
      return;
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "gasstation_corpse"), true);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
      this.setCollider(0);
    else
      this.setCollider(-1);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
    if (GameDataController.gd.getCurrentDay() != 1 || GameDataController.gd.getObjectiveDetail("day_1_threat") != 2 || GameDataController.gd.getObjective("gasstation_spider_baited"))
      return;
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "nasty_spider_blocking"), true);
  }

  public override void whatOnClick()
  {
    if (GameDataController.gd.getCurrentDay() != 1 || GameDataController.gd.getObjectiveDetail("day_1_threat") != 2 || GameDataController.gd.getObjective("gasstation_spider_baited"))
      return;
    PlayerController.wc.fullStop(true);
  }
}
