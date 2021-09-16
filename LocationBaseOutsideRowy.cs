// Decompiled with JetBrains decompiler
// Type: LocationBaseOutsideRowy
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationBaseOutsideRowy : ObjectActionController
{
  public Sprite sign;
  public Sprite chestexamine;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "base_ground";
    this.range = 100f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("shovel", string.Empty, anim: string.Empty));
  }

  public void yesDig()
  {
    GameDataController.gd.setObjective("base_outside_dug", true);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.digger);
    CurtainController.cc.fadeOut();
    this.updateAll();
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("base_outside_dug"))
    {
      if (this.usedItem == string.Empty)
      {
        if (GameDataController.gd.getCurrentDay() == 3)
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "base_outside_ditches"));
        else
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "after_rain_thing"));
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "base_outside_already_dug"));
    }
    else if (this.usedItem == string.Empty)
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "base_outside_could_dig"));
    }
    else
    {
      if (!(this.usedItem == "shovel"))
        return;
      if (!GameDataController.gd.getObjective("sidereal_base_located"))
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "find_base_first"));
      else
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "base_dig"), yesClick: new Button.Delegate(this.yesDig), time: 120, timeSaver: 10);
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getCurrentDay() >= 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
      this.colliderManager.setCollider(0);
    else
      this.colliderManager.setCollider(-1);
    if (GameDataController.gd.getObjective("base_outside_dug"))
    {
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.objectName = "base_ditches";
    }
    else
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.objectName = "base_ground";
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
