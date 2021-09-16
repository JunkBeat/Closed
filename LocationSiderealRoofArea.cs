// Decompiled with JetBrains decompiler
// Type: LocationSiderealRoofArea
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationSiderealRoofArea : AreaEffect
{
  public LetterFall lf;

  public override void Action(WalkController wc, NPCWalkController npcwc, GroundItemController gic)
  {
    if (!((Object) wc != (Object) null) || GameDataController.gd.getObjectiveDetail("sidereal_roof_collapsed") != 0)
      return;
    this.lf.prepare();
    GameDataController.gd.setObjectiveDetail("sidereal_roof_collapsed", 1);
  }

  public override void Action2(
    WalkController wc,
    NPCWalkController npcwc,
    GroundItemController gic)
  {
  }
}
