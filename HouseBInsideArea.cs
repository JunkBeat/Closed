// Decompiled with JetBrains decompiler
// Type: HouseBInsideArea
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class HouseBInsideArea : AreaEffect
{
  public override void Action(WalkController wc, NPCWalkController npcwc, GroundItemController gic)
  {
    if ((Object) wc != (Object) null)
      wc.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
    if ((Object) npcwc != (Object) null)
    {
      npcwc.colorBlue = 1f;
      npcwc.colorRed = 1f;
      npcwc.colorGreen = 1f;
      npcwc.gameObject.GetComponent<SpriteRenderer>().color = new Color(npcwc.colorRed, npcwc.colorGreen, npcwc.colorBlue, npcwc.colorAlpha);
    }
    if (!((Object) gic != (Object) null))
      return;
    gic.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
  }

  public override void Action2(
    WalkController wc,
    NPCWalkController npcwc,
    GroundItemController gic)
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
