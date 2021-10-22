// Decompiled with JetBrains decompiler
// Type: Location1Painting
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Location1Painting : ObjectActionController
{
  public Sprite painting;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "base_painting";
    this.range = 15f;
  }

  public override void clickAction()
  {
    ExamineSprite.es.textField.shift.x = -110f;
    ExamineSprite.es.readyText(new List<string>()
    {
      GameStrings.getString(GameStrings.actions, "base_painting")
    }, 100, 1f, 1f, 1f, 0.0f, 0.0f, 0.0f, 0.75f);
    ExamineSprite.es.show(this.painting);
  }

  public override void updateState() => this.colliderManager.setCollider(0);

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
