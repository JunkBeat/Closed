// Decompiled with JetBrains decompiler
// Type: Waypoint_CS4_CS5_2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class Waypoint_CS4_CS5_2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_rope";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.doubleClickCondition = string.Empty;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("constructionsite_from_above"))
    {
      GameDataController.gd.setObjective("constructionsite_from_above", true);
      PlayerController.pc.spawnName = "Waypoint_CS5_CS4_2";
      CurtainController.cc.fadeOut("CS5", WalkController.Direction.N);
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cant_reach"));
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("cs_rope_used"))
    {
      this.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
    }
    else
    {
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
    }
    if (GameDataController.gd.getObjective("constructionsite_from_above"))
    {
      this.range = 1f;
      this.characterAnimationName = "stop";
    }
    else
    {
      this.range = 100f;
      this.characterAnimationName = "action_stnd_";
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
