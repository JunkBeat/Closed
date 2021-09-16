// Decompiled with JetBrains decompiler
// Type: HunterLodgeTree_Outside
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class HunterLodgeTree_Outside : ObjectActionController
{
  public PolygonCollider2D blocker;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "lodge_tree";
    this.range = 1f;
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.S;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("ext_cord_place", string.Empty, anim: string.Empty));
    this.updateState();
  }

  private void Update()
  {
  }

  public override void clickAction() => QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "climb_tree_down"), yesClick: new Button.Delegate(this.climbTree));

  private void climbTree()
  {
    PlayerController.wc.forceAnimation("kneel_in_n");
    this.Invoke("climbTree3", 0.5f);
  }

  public void climbTree3()
  {
    PlayerController.pc.spawnName = "HunterLodgeTree";
    CurtainController.cc.fadeOut("HuntersLodgeOutside2", WalkController.Direction.S, "window_jump");
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
  }

  public override void whatOnClick()
  {
  }
}
