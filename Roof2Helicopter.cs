// Decompiled with JetBrains decompiler
// Type: Roof2Helicopter
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Roof2Helicopter : ObjectActionController
{
  public Sprite tarpaulin;
  public Sprite taped;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "roof_heli";
    this.range = 100f;
    this.teleport = false;
    this.updateState();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("tarpaulin", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ducttape", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("flag", GameStrings.getString(GameStrings.actions, "cover_too_small"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanket", GameStrings.getString(GameStrings.actions, "cover_too_small"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanketb", GameStrings.getString(GameStrings.actions, "cover_too_small"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("therm", GameStrings.getString(GameStrings.actions, "cover_too_small"), anim: string.Empty));
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    if (this.usedItem == string.Empty)
    {
      if (GameDataController.gd.getObjective("helicopter_covered"))
      {
        if (GameDataController.gd.getObjective("helicopter_covered_taped"))
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "helicopter_covered_taped_already"));
        else
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "helicopter_covered_already"));
      }
      else
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "roof_heli"), true, mwidth: 150);
    }
    else if (this.usedItem == "tarpaulin")
    {
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "helicopter_cover"), yesClick: new Button.Delegate(this.yesClick), time: 40, timeSaver: 8);
    }
    else
    {
      if (!(this.usedItem == "ducttape"))
        return;
      if (GameDataController.gd.getObjective("helicopter_covered_taped"))
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "helicopter_covered_taped_already"));
      else if (GameDataController.gd.getObjective("helicopter_covered"))
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "helicopter_cover_tape"), yesClick: new Button.Delegate(this.yesClick2), time: 30, timeSaver: 6);
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "helicopter_duct_tape"));
    }
  }

  private void yesClick()
  {
    CurtainController.cc.fadeOut();
    GameDataController.gd.setObjective("helicopter_covered", true);
    InventoryController.ic.removeItem("tarpaulin");
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "helicopter_covered"));
  }

  private void yesClick2()
  {
    CurtainController.cc.fadeOut();
    GameDataController.gd.setObjective("helicopter_covered_taped", true);
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "helicopter_covered_taped"));
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjective("helicopter_covered_taped"))
    {
      this.GetComponent<SpriteRenderer>().sprite = this.taped;
      this.GetComponent<SpriteRenderer>().enabled = true;
    }
    else if (GameDataController.gd.getObjective("helicopter_covered"))
    {
      this.GetComponent<SpriteRenderer>().sprite = this.tarpaulin;
      this.GetComponent<SpriteRenderer>().enabled = true;
    }
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
