// Decompiled with JetBrains decompiler
// Type: CrashsiteCarClicker
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class CrashsiteCarClicker : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "action_stnd_";
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "crashsite_car_unexamined";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("wrench", string.Empty, anim: string.Empty));
    this.updateState();
    MonoBehaviour.print((object) this.dkvs);
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("crashsite_car_examined"))
      Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
      {
        text = GameStrings.getString(GameStrings.actions, "crashsite_car_examine"),
        function = new TimelineFunction(this.examineCar),
        actionWithText = false
      });
    else if (!GameDataController.gd.getObjective("crashsite_car_harvested"))
    {
      if (this.usedItem == string.Empty)
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "crashsite_car_could_harvest"), true);
      else
        Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
        {
          text = GameStrings.getString(GameStrings.actions, "crashsite_car_harvest"),
          function = new TimelineFunction(this.harvestCar),
          actionWithText = false
        });
    }
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "crashsite_car_empty"), true);
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("crashsite_car_examined"))
      this.objectName = "crashsite_car_unexamined";
    else if (!GameDataController.gd.getObjective("crashsite_car_harvested"))
      this.objectName = "crashsite_car_examined";
    else
      this.objectName = "crashsite_car_harvested";
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  private void examineCar(string str) => QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "crashsite_car_examine"), yesClick: new Button.Delegate(this.doExamineCar), time: 15, timeSaver: 2);

  private void harvestCar(string str) => QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "crashsite_car_harvest"), yesClick: new Button.Delegate(this.doHarvestCar), time: 45, timeSaver: 10);

  private void doHarvestCar() => CurtainController.cc.fadeOut(targetDir: WalkController.Direction.N, animation: "action1_e", flipX: true, actionAfterFade: new CurtainController.Delegate(this.sayAboutCarHarvest));

  private void doExamineCar()
  {
    GameDataController.gd.setObjective("crashsite_car_examined", true);
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.N, animation: "action1_e", flipX: true, actionAfterFade: new CurtainController.Delegate(this.sayAboutCarExplore));
  }

  public void sayAboutCarHarvest()
  {
    GameDataController.gd.setObjective("crashsite_car_harvested", true);
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "crashsite_car_harvested"), true);
    InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("ignitioncoil"));
    this.updateAll();
  }

  public void sayAboutCarExplore()
  {
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "crashsite_car_examined"), true);
    this.updateAll();
  }
}
