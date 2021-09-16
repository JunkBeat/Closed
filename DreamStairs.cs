// Decompiled with JetBrains decompiler
// Type: DreamStairs
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class DreamStairs : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "dream_stairs";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.doubleClickCondition = string.Empty;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("dream_tiger_future") || GameDataController.gd.getObjective("dream_maggie_future"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "not_going_back"));
    }
    else
    {
      PlayerController.pc.spawnName = nameof (DreamStairs);
      CurtainController.cc.fadeOut("Dream3B", WalkController.Direction.W);
    }
  }

  public override void updateState()
  {
    if ((GameDataController.gd.getObjective("previous_disc_barry") || GameDataController.gd.getObjective("previous_disc_cody")) && GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc2_joined"))
    {
      this.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
    }
    else
    {
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
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
