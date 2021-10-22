// Decompiled with JetBrains decompiler
// Type: TutorialClimbLowerSpeed
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class TutorialClimbLowerSpeed : AreaEffect
{
  public override void Action(WalkController wc, NPCWalkController npcwc, GroundItemController gic)
  {
    if (!((Object) wc != (Object) null))
      return;
    wc.speed = 0.7f * wc.MAX_SPEED;
  }

  public override void Action2(
    WalkController wc,
    NPCWalkController npcwc,
    GroundItemController gic)
  {
  }
}
