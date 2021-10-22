// Decompiled with JetBrains decompiler
// Type: AirplaneGround2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class AirplaneGround2 : ObjectActionController
{
  public SpriteRenderer ground;
  public SpriteRenderer plane;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "airplane_nose";
    this.range = 100f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("shovel", GameStrings.getString(GameStrings.actions, "plane_ground2"), anim: string.Empty));
  }

  public override void clickAction() => PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "plane_ground"));

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
