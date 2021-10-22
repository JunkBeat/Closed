// Decompiled with JetBrains decompiler
// Type: OutpostOutsideHatch
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class OutpostOutsideHatch : ObjectActionController
{
  public SpriteRenderer sr1;
  public SpriteRenderer sr2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = true;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_hatch_open";
    this.range = 111f;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("outpost_hatch_open"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "outpost_hatch_open"));
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "outpost_hatch_closed"));
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("outpost_hatch_open"))
    {
      this.objectName = "outpost_hatch_open";
      this.sr1.enabled = true;
      this.sr2.enabled = true;
      this.interactions = new List<ItemInteraction>();
    }
    else
    {
      this.sr1.enabled = false;
      this.sr2.enabled = false;
      this.objectName = "outpost_hatch_closed";
      this.interactions = new List<ItemInteraction>();
      this.interactions.Add(new ItemInteraction("shovel", GameStrings.getString(GameStrings.actions, "outpost_hatch_shovel"), anim: string.Empty));
    }
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
