﻿// Decompiled with JetBrains decompiler
// Type: LocationOutpost3AreaAction2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationOutpost3AreaAction2 : AreaEffect
{
  public override void Action2(
    WalkController wc,
    NPCWalkController npcwc,
    GroundItemController gic)
  {
    if ((Object) wc != (Object) null)
      wc.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 0.6f);
    if ((Object) npcwc != (Object) null)
    {
      npcwc.colorBlue = 0.6f;
      npcwc.colorRed = 0.6f;
      npcwc.colorGreen = 0.6f;
      npcwc.gameObject.GetComponent<SpriteRenderer>().color = new Color(npcwc.colorRed, npcwc.colorGreen, npcwc.colorBlue, npcwc.colorAlpha);
    }
    if (!((Object) gic != (Object) null))
      return;
    gic.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 0.6f);
  }

  public override void Action(WalkController wc, NPCWalkController npcwc, GroundItemController gic)
  {
    if ((Object) wc != (Object) null)
      wc.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f);
    if ((Object) npcwc != (Object) null)
    {
      npcwc.colorBlue = 0.4f;
      npcwc.colorRed = 0.4f;
      npcwc.colorGreen = 0.4f;
      npcwc.gameObject.GetComponent<SpriteRenderer>().color = new Color(npcwc.colorRed, npcwc.colorGreen, npcwc.colorBlue, npcwc.colorAlpha);
    }
    if (!((Object) gic != (Object) null))
      return;
    gic.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f);
  }
}