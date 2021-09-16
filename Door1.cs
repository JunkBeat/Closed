// Decompiled with JetBrains decompiler
// Type: Door1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

public class Door1 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "kitchen_door1";
    this.doubleClickCondition = "visited_location2";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.E;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("ext_cord_place", string.Empty, anim: string.Empty));
  }

  public override void whatOnClick0()
  {
    this.range = 1f;
    if (!(this.usedItem == "ext_cord_place"))
      return;
    this.range = 1000f;
  }

  public override void clickAction()
  {
    if (this.usedItem == "ext_cord_place")
    {
      GameDataController.gd.setObjective("kitchen_cord_dragged", false);
      PlayerController.pc.spawnName = "ExtCordPlace";
      CurtainController.cc.fadeOut("Location2", WalkController.Direction.E);
    }
    else
    {
      PlayerController.pc.spawnName = "KitchenDoor2";
      CurtainController.cc.fadeOut("Location2", WalkController.Direction.E);
    }
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
