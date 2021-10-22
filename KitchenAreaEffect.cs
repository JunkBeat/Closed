// Decompiled with JetBrains decompiler
// Type: KitchenAreaEffect
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class KitchenAreaEffect : AreaEffect
{
  public override void Action(WalkController wc, NPCWalkController npcwc, GroundItemController gic)
  {
    float num = 0.5f;
    if (GameDataController.gd.getObjective("location02_door_open"))
      num = 1f;
    if ((Object) wc != (Object) null)
      wc.gameObject.GetComponent<SpriteRenderer>().color = new Color(num, num, num);
    if ((Object) npcwc != (Object) null)
    {
      npcwc.colorBlue = num;
      npcwc.colorRed = num;
      npcwc.colorGreen = num;
      npcwc.gameObject.GetComponent<SpriteRenderer>().color = new Color(npcwc.colorRed, npcwc.colorGreen, npcwc.colorBlue, npcwc.colorAlpha);
    }
    if (!((Object) gic != (Object) null))
      return;
    gic.gameObject.GetComponent<SpriteRenderer>().color = new Color(num, num, num);
  }

  public override void Action2(
    WalkController wc,
    NPCWalkController npcwc,
    GroundItemController gic)
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
}
