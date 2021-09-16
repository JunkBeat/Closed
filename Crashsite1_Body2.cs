// Decompiled with JetBrains decompiler
// Type: Crashsite1_Body2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Crashsite1_Body2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_e_in";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      this.objectName = "crashsite_body2_bugs";
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
    {
      this.objectName = "crashsite_body2_gas";
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 2)
        return;
      this.objectName = "crashsite_body2_spiders";
    }
  }

  public override void clickAction()
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.page_turn_03);
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.world_labels, "crashsite_body2_bugs_note"), true, true, true, 200, 0.0f, 0.0f, 0.0f, 0.9294118f, 0.8705882f, 0.6039216f, 1f, mute: true);
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
    {
      ExamineSprite.es.textField.shift.y = 50f;
      ExamineSprite.es.readyText(new List<string>()
      {
        GameStrings.getString(GameStrings.world_labels, "crashsite_body2_gas_note")
      }, 200, 0.0f, 0.0f, 0.0f, 0.9294118f, 0.8705882f, 0.6039216f, 1f);
      ExamineSprite.es.closingAnimation = "kneel_e_out";
      ExamineSprite.es.show((Sprite) null, act: new ExamineSprite.Delegate(this.aaa), actionOnOpen: false);
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 2)
        return;
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.world_labels, "crashsite_body2_spiders_note"), true, true, true, 200, 0.0f, 0.0f, 0.0f, 0.9294118f, 0.8705882f, 0.6039216f, 1f, mute: true);
    }
  }

  public void showIt() => this.colliderManager.setCollider(0);

  public void hideIt() => this.colliderManager.setCollider(-1);

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getCurrentDay() > 1)
      this.hideIt();
    else
      this.showIt();
  }

  private void aaa()
  {
    MonoBehaviour.print((object) "THIS ACTION 2 ================================================ +++++++++++++++++++++++++++++++ &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 1)
      return;
    GameDataController.gd.setObjective("crashsite_gas_note_read", true);
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "crashsite_body2_gas_long2"), true);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.objects, "crashsite_body2_bugs_long"), true);
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
    {
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.objects, "crashsite_body2_gas_long"), true);
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 2)
        return;
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.objects, "crashsite_body2_spiders_long"), true);
    }
  }
}
