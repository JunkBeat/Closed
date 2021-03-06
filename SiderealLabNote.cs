// Decompiled with JetBrains decompiler
// Type: SiderealLabNote
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class SiderealLabNote : ObjectActionController
{
  public Sprite painting;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_e";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_lab_note";
    this.range = 1f;
  }

  public override void clickAction()
  {
    ExamineSprite.es.textField.shift.x = -45f;
    ExamineSprite.es.textField.shift.y = -5f;
    ExamineSprite.es.readyText(new List<string>()
    {
      GameStrings.getString(GameStrings.world_labels, "sideral_warning_note")
    }, 150, 0.2f, 0.2f, 0.2f, 1f, 1f, 1f, 0.0f);
    ExamineSprite.es.ac = SoundsManagerController.sm.page_turn_02;
    ExamineSprite.es.show(this.painting);
  }

  public override void updateState()
  {
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
