// Decompiled with JetBrains decompiler
// Type: CS2FenceShelf
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class CS2FenceShelf : ObjectActionController
{
  public Animator crow;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.characterAnimationName = "action_stnd_";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_shelf";
    this.range = 200f;
    this.updateState();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("maggot", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ropehook", GameStrings.getString(GameStrings.actions, "shelf_ropehook"), anim: string.Empty));
  }

  public override void clickAction()
  {
    if (this.usedItem == "maggot")
    {
      if (GameDataController.gd.getObjective("cs_thug_shot"))
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "default2"));
        this.updateState();
      }
      else if (this.crow.gameObject.GetComponent<CSCrowSprite>().free && !GameDataController.gd.getObjective("cs_guard_distracted"))
      {
        this.crow.gameObject.GetComponent<CSCrowSprite>().free = false;
        this.crow.Play("crow_attack");
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_already_distracted"));
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_parapet"));
  }

  public override void whatOnClick0()
  {
  }

  public override void updateState()
  {
    this.interactions = new List<ItemInteraction>();
    if (!GameDataController.gd.getObjective("cs_thug_shot"))
      this.interactions.Add(new ItemInteraction("maggot", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ropehook", GameStrings.getString(GameStrings.actions, "shelf_ropehook"), anim: string.Empty));
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getCurrentDay() == 3)
      this.setCollider(0);
    else
      this.setCollider(-1);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
