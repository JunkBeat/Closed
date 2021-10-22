// Decompiled with JetBrains decompiler
// Type: WalkerNoBackpack
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class WalkerNoBackpack : ObjectActionController
{
  private int counter;
  public Sprite pointer;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = string.Empty;
    this.range = 8000f;
    this.teleport = false;
    this.updateState();
    this.actionType = ObjectActionController.Type.Secret;
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    if (this.counter == 0)
    {
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "pick_up_backpack"), true, mwidth: 150);
      ++this.counter;
    }
    else
    {
      ExamineSprite.es.textField.shift.x = -10f;
      ExamineSprite.es.textField.shift.y = -40f;
      ExamineSprite.es.readyText(new List<string>()
      {
        GameStrings.getString(GameStrings.gui, "pick_up_backpack")
      }, 100, 1f, 1f, 1f, 0.0f, 0.0f, 0.0f, 0.25f);
      ExamineSprite.es.show(this.pointer);
    }
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("tent_awake"))
      this.colliderManager.setCollider(-1);
    else if (!GameDataController.gd.getObjective("tent_backpack_taken"))
      this.colliderManager.setCollider(0);
    else
      this.colliderManager.setCollider(-1);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
