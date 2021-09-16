// Decompiled with JetBrains decompiler
// Type: CSEndReloadAreaAction
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CSEndReloadAreaAction : AreaEffect
{
  public LocationCS2Start cs2;
  public CSThugSprite thug;

  public override void Action(WalkController wc, NPCWalkController npcwc, GroundItemController gic)
  {
    if ((Object) wc != (Object) null && GameDataController.gd.getObjective("cs_arrive_from_inside") && !GameDataController.gd.getObjective("cs_safe") && !GameDataController.gd.getObjective("cs_thug_shot"))
    {
      GameDataController.gd.setObjective("cs_arrive_from_inside", false);
      this.thug.GetComponent<Animator>().Play("thug_watch");
    }
    if (!((Object) npcwc != (Object) null))
      ;
    if (!((Object) gic != (Object) null))
      ;
  }

  public override void Action2(
    WalkController wc,
    NPCWalkController npcwc,
    GroundItemController gic)
  {
  }
}
