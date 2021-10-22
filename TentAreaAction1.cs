// Decompiled with JetBrains decompiler
// Type: TentAreaAction1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class TentAreaAction1 : AreaEffect
{
  public override void Action(WalkController wc, NPCWalkController npcwc, GroundItemController gic)
  {
    if (GameDataController.gd.getObjective("tent_distance_checked") || !((Object) wc != (Object) null))
      return;
    PlayerController.wc.fullStop(true);
    PlayerController.wc.forceAnimation("action_stnd_ne", makeBusy: false);
    PlayerController.wc.fullStop(true);
    GameObject.Find("distance").GetComponent<TentDistanceThings>().clickAction();
  }

  public override void Action2(
    WalkController wc,
    NPCWalkController npcwc,
    GroundItemController gic)
  {
  }
}
