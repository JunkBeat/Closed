// Decompiled with JetBrains decompiler
// Type: Location1Stairs
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;

public class Location1Stairs : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "base_stairs_up";
    this.doubleClickCondition = "visited_baseUpstairs";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("ac_cord", GameStrings.getString(GameStrings.actions, "cord_upfloor"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ext_cord_place", GameStrings.getString(GameStrings.actions, "cord_upfloor"), anim: string.Empty));
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "Stairs_Exit";
    CurtainController.cc.fadeOut("LocationBaseUpstairs", WalkController.Direction.W);
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
