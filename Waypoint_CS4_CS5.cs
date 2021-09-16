// Decompiled with JetBrains decompiler
// Type: Waypoint_CS4_CS5
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;

public class Waypoint_CS4_CS5 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_scaffolding";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.doubleClickCondition = string.Empty;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("gloves", string.Empty, anim: string.Empty));
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("constructionsite_from_above"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cant_reach"));
    else if (this.usedItem == "gloves")
    {
      GameDataController.gd.setObjective("constructionsite_from_above", false);
      PlayerController.pc.spawnName = "Waypoint_CS5_CS4";
      CurtainController.cc.fadeOut("CS5", WalkController.Direction.N);
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "scffolding"));
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("constructionsite_from_above"))
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
