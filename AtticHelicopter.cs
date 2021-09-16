// Decompiled with JetBrains decompiler
// Type: AtticHelicopter
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class AtticHelicopter : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.characterAnimationName = "action_stnd_";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "helicopter";
    this.range = 50f;
    this.updateState();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("tarpaulin", GameStrings.getString(GameStrings.actions, "heli_wrong_side"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ducttape", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("flag", GameStrings.getString(GameStrings.actions, "cover_too_small"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanket", GameStrings.getString(GameStrings.actions, "cover_too_small"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanketb", GameStrings.getString(GameStrings.actions, "cover_too_small"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("therm", GameStrings.getString(GameStrings.actions, "cover_too_small"), anim: string.Empty));
  }

  public override void clickAction()
  {
    if (this.usedItem == "ducttape")
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "heli_cant_fix_tape"));
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "helicopter"), true);
  }

  public override void whatOnClick()
  {
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("helicopter_covered"))
      this.GetComponent<SpriteRenderer>().enabled = true;
    else
      this.GetComponent<SpriteRenderer>().enabled = false;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
