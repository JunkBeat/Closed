// Decompiled with JetBrains decompiler
// Type: GasstationNewspaper
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class GasstationNewspaper : ObjectActionController
{
  public Sprite newspaper;
  public AudioClip pageSound1;
  public AudioClip pageSound2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_newspaper";
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited"))
      return;
    ExamineSprite.es.textField.shift.x = -4f;
    ExamineSprite.es.textField.shift.y = 58f;
    ExamineSprite.es.readyText(new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "gasstation_newspaper1"),
      GameStrings.getString(GameStrings.world_labels, "gasstation_newspaper2"),
      GameStrings.getString(GameStrings.world_labels, "gasstation_newspaper3"),
      GameStrings.getString(GameStrings.world_labels, "gasstation_newspaper4"),
      GameStrings.getString(GameStrings.world_labels, "gasstation_newspaper5"),
      GameStrings.getString(GameStrings.world_labels, "gasstation_newspaper6"),
      GameStrings.getString(GameStrings.world_labels, "gasstation_newspaper7"),
      GameStrings.getString(GameStrings.world_labels, "gasstation_newspaper8"),
      GameStrings.getString(GameStrings.world_labels, "gasstation_newspaper9"),
      GameStrings.getString(GameStrings.world_labels, "gasstation_newspaper10")
    }, 120, 0.0f, 0.0f, 0.0f, 1f, 1f, 1f, 1f);
    ExamineSprite.es.show(this.newspaper);
  }

  public override void updateState() => this.colliderManager.setCollider(0);

  public override void clickAction2()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited"))
      return;
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "gasstation_newspaper_start"), true);
  }

  public override void clickAction0()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited"))
      return;
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "gasstation_newspaper_start"), true);
  }

  public override void whatOnClick0()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited"))
    {
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "nasty_spider_blocking"), true);
      PlayerController.wc.fullStop(true);
      PlayerController.pc.setBusy(false);
      this.characterAnimationName = "stand_";
      this.animationFlip = true;
    }
    else
    {
      this.characterAnimationName = "stop";
      this.animationFlip = false;
    }
  }

  public override void whatOnClick()
  {
    if (GameDataController.gd.getCurrentDay() != 1 || GameDataController.gd.getObjectiveDetail("day_1_threat") != 2 || GameDataController.gd.getObjective("gasstation_spider_baited"))
      return;
    PlayerController.wc.fullStop(true);
    PlayerController.pc.setBusy(false);
  }
}
