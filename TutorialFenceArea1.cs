// Decompiled with JetBrains decompiler
// Type: TutorialFenceArea1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class TutorialFenceArea1 : AreaEffect
{
  public override void Action(WalkController wc, NPCWalkController npcwc, GroundItemController gic)
  {
    if ((Object) wc != (Object) null)
      wc.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.7f);
    if ((Object) npcwc != (Object) null)
    {
      npcwc.colorBlue = 0.7f;
      npcwc.colorRed = 0.7f;
      npcwc.colorGreen = 0.7f;
      npcwc.gameObject.GetComponent<SpriteRenderer>().color = new Color(npcwc.colorRed, npcwc.colorGreen, npcwc.colorBlue, npcwc.colorAlpha);
    }
    if (!((Object) gic != (Object) null))
      return;
    gic.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.7f);
  }

  public override void Action2(
    WalkController wc,
    NPCWalkController npcwc,
    GroundItemController gic)
  {
  }
}
