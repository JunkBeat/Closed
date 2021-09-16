// Decompiled with JetBrains decompiler
// Type: KitchenDoor2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

public class KitchenDoor2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "kitchen_door2";
    this.range = 10f;
    this.doubleClickCondition = "visited_location1";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.W;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("ext_cord_place", string.Empty, anim: string.Empty));
  }

  public override void whatOnClick0()
  {
    this.range = 10f;
    if (!(this.usedItem == "ext_cord_place"))
      return;
    this.range = 1000f;
  }

  public override void clickAction()
  {
    if (this.usedItem == "ext_cord_place")
    {
      GameDataController.gd.setObjective("kitchen_cord_dragged", true);
      PlayerController.pc.spawnName = "location1_ext_cord";
      CurtainController.cc.fadeOut("Location1", WalkController.Direction.W);
    }
    else
    {
      PlayerController.pc.spawnName = "Door1";
      CurtainController.cc.fadeOut("Location1", WalkController.Direction.W);
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
