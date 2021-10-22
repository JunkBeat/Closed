// Decompiled with JetBrains decompiler
// Type: CSShootAreaAction
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class CSShootAreaAction : AreaEffect
{
  public LocationCS2Start cs2;
  public ObjectActionController exitcs1;
  public ObjectActionController exitcs3;

  public override void Action(WalkController wc, NPCWalkController npcwc, GroundItemController gic)
  {
    if ((Object) wc != (Object) null)
    {
      this.exitcs1.doubleClickCondition = string.Empty;
      this.exitcs3.doubleClickCondition = string.Empty;
      this.cs2.shootArea = true;
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
    if (!((Object) wc != (Object) null))
      return;
    this.cs2.shootArea = false;
  }
}
