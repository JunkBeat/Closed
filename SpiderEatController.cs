// Decompiled with JetBrains decompiler
// Type: SpiderEatController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class SpiderEatController : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "action_stnd_";
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "nasty_spider";
    this.updateState();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("hammer", GameStrings.getString(GameStrings.actions, "dont_attack_spider"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rock", GameStrings.getString(GameStrings.actions, "dont_attack_spider"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("wrench", GameStrings.getString(GameStrings.actions, "dont_attack_spider"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("pipe", GameStrings.getString(GameStrings.actions, "dont_attack_spider"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("pest", GameStrings.getString(GameStrings.actions, "dont_attack_spider"), anim: string.Empty));
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    this.gameObject.GetComponent<Animator>().Play("eat");
    this.setCollider(0);
    this.updateState();
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
  }

  public override void whatOnClick0()
  {
    if (GameDataController.gd.getCurrentDay() != 1 || GameDataController.gd.getObjectiveDetail("day_1_threat") != 2 || GameDataController.gd.getObjective("gasstation_spider_baited"))
      return;
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "nasty_spider_eating"), true);
    PlayerController.wc.fullStop(true);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited"))
    {
      this.setCollider(0);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      GameDataController.gd.setObjective("gasstation_spider_discovered", true);
    }
    else
    {
      this.setCollider(-1);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
