// Decompiled with JetBrains decompiler
// Type: WaypointCave
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

public class WaypointCave : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "rv_cave_exit";
    this.actionType = ObjectActionController.Type.Transition;
    this.doubleClickCondition = "visited_rv";
    this.trans_dir = WalkController.Direction.N;
    this.range = 2f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("ac", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ext_cord_place", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("flag", GameStrings.getString(GameStrings.actions, "cave_do_it_outside"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanket", GameStrings.getString(GameStrings.actions, "cave_do_it_outside"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanketb", GameStrings.getString(GameStrings.actions, "cave_do_it_outside"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("thermalb", GameStrings.getString(GameStrings.actions, "cave_do_it_outside"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("thermalb", GameStrings.getString(GameStrings.actions, "cave_do_it_outside"), anim: string.Empty));
  }

  public override void whatOnClick0()
  {
    if (this.usedItem == "ac")
    {
      this.characterAnimationName = "kneel_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
    else
    {
      if (!(this.usedItem != string.Empty))
        return;
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
  }

  public override void clickAction()
  {
    if (this.usedItem == "ac")
    {
      GameDataController.gd.setObjective("cave_ac_placed", true);
      InventoryController.ic.removeItem("ac");
      this.updateAll();
    }
    else if (this.usedItem == "ext_cord_place")
    {
      GameDataController.gd.setObjective("rv_cord_caved", false);
      PlayerController.pc.spawnName = "WaypointRVCave";
      CurtainController.cc.fadeOut("LocationRV", WalkController.Direction.W);
    }
    else
    {
      PlayerController.pc.spawnName = "WaypointRVCave";
      CurtainController.cc.fadeOut("LocationRV", WalkController.Direction.W);
    }
  }

  public override void updateState() => this.colliderManager.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
