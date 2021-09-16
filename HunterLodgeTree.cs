// Decompiled with JetBrains decompiler
// Type: HunterLodgeTree
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class HunterLodgeTree : ObjectActionController
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
    this.trans_dir = WalkController.Direction.N;
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
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "climb_tree"), yesClick: new Button.Delegate(this.climbTree), time: 5);
    else
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "climb_tree_cord"), yesClick: new Button.Delegate(this.climbTree2), time: 10);
  }

  private void climbTree()
  {
    PlayerController.wc.forceAnimation("climb_se");
    this.Invoke("climbTree3", 0.5f);
  }

  private void climbTree3()
  {
    PlayerController.pc.spawnName = "HunterLodgeTree_Outside";
    CurtainController.cc.fadeOut("HuntersLodgeTree", WalkController.Direction.S, "kneel_out_n");
  }

  private void climbTree2()
  {
    GameDataController.gd.setObjective("lodge_cord_climbed", true);
    this.climbTree();
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") != 1)
    {
      this.colliderManager.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.blocker.enabled = false;
      GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
    }
    else
    {
      this.colliderManager.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.blocker.enabled = true;
      GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
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
