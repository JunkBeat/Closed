// Decompiled with JetBrains decompiler
// Type: AirplaneGround
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class AirplaneGround : ObjectActionController
{
  public SpriteRenderer ground;
  public SpriteRenderer plane;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "airplane_ground";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("shovel", string.Empty, anim: string.Empty));
  }

  public override void clickAction()
  {
    if (this.usedItem == "shovel")
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "plane_undig_shovel"), yesClick: new Button.Delegate(this.yesDig), time: 80, timeSaver: 20);
    else
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "plane_undig_no_shovel"), yesClick: new Button.Delegate(this.yesDig), time: 120, timeSaver: 20);
  }

  public void yesDig()
  {
    GameDataController.gd.setObjective("plane_undig", true);
    CurtainController.cc.fadeOut(sound: SoundsManagerController.sm.digger);
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (!GameDataController.gd.getObjective("plane_undig"))
    {
      this.ground.enabled = true;
      this.plane.enabled = false;
    }
    else
    {
      this.ground.enabled = false;
      this.plane.enabled = true;
      this.colliderManager.setCollider(-1);
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
