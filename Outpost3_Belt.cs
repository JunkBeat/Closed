// Decompiled with JetBrains decompiler
// Type: Outpost3_Belt
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Outpost3_Belt : ObjectActionController
{
  public Sprite crack;
  public Sprite spaw;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = true;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_engine_belted";
    this.range = 2f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("screwdriver", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("wrench", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("transmission_belt", string.Empty, anim: string.Empty));
  }

  public void yesTake()
  {
    InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("transmission_belt"));
    GameDataController.gd.setObjective("outpost_belt_hatch", false);
    CurtainController.cc.fadeOut();
  }

  public void yesGive()
  {
    InventoryController.ic.removeItem("transmission_belt");
    GameDataController.gd.setObjective("outpost_belt_hatch", true);
    CurtainController.cc.fadeOut();
  }

  public override void clickAction()
  {
    if (this.usedItem == "transmission_belt")
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "belt_give_engine"), yesClick: new Button.Delegate(this.yesGive), time: 10);
    else if (GameDataController.gd.getObjective("outpost_belt_hatch"))
    {
      if (this.usedItem == string.Empty)
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "belt_engine_with_tool"));
      else
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "belt_take_engine"), yesClick: new Button.Delegate(this.yesTake), time: 10);
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "elevator_no_belt"));
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("outpost_belt_hatch"))
    {
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.objectName = "outpost_engine_belted";
    }
    else
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.objectName = "outpost_engine_unbelted";
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
