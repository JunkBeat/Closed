﻿// Decompiled with JetBrains decompiler
// Type: FallenNPCArea
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class FallenNPCArea : AreaEffect
{
  public ObjectActionController npc;

  public override void Action(WalkController wc, NPCWalkController npcwc, GroundItemController gic)
  {
    if (!((Object) wc != (Object) null))
      ;
  }

  public override void Action2(
    WalkController wc,
    NPCWalkController npcwc,
    GroundItemController gic)
  {
  }
}
