// Decompiled with JetBrains decompiler
// Type: HunterLodgeWindow
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class HunterLodgeWindow : ObjectActionController
{
  public Sprite cord;
  public Sprite cord2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "lodge_window";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("ext_cord_place", string.Empty, anim: string.Empty));
    this.updateState();
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    if (this.usedItem == string.Empty)
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "lodge_window"));
    }
    else
    {
      GameDataController.gd.setObjective("lodge_cord_dragged", true);
      this.updateAll();
    }
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
    if (this.usedItem != string.Empty)
    {
      this.range = 1f;
      this.characterAnimationName = "action_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else
    {
      this.range = 20f;
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
  }

  public override void whatOnClick()
  {
  }
}
