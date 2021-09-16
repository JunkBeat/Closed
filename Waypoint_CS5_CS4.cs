// Decompiled with JetBrains decompiler
// Type: Waypoint_CS5_CS4
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

public class Waypoint_CS5_CS4 : ObjectActionController
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
    this.trans_dir = WalkController.Direction.S;
    this.doubleClickCondition = string.Empty;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("gloves", string.Empty, anim: string.Empty));
  }

  public override void clickAction()
  {
    if (this.usedItem == "gloves")
    {
      GameDataController.gd.setObjective("constructionsite_from_above", false);
      PlayerController.pc.spawnName = "Waypoint_CS4_CS5";
      CurtainController.cc.fadeOut("CS4", WalkController.Direction.S, "window_jump");
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "scffolding"));
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
}
