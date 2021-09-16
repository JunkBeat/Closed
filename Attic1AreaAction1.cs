// Decompiled with JetBrains decompiler
// Type: Attic1AreaAction1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Attic1AreaAction1 : AreaEffect
{
  public override void Action(WalkController wc, NPCWalkController npcwc, GroundItemController gic)
  {
    Color color = new Color(0.8f, 0.8f, 0.8f);
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
      color = new Color(1f, 1f, 1f);
    if ((Object) wc != (Object) null)
      wc.gameObject.GetComponent<SpriteRenderer>().color = color;
    if ((Object) gic != (Object) null)
      gic.gameObject.GetComponent<SpriteRenderer>().color = color;
    if (!((Object) npcwc != (Object) null))
      return;
    npcwc.colorBlue = color.b;
    npcwc.colorRed = color.r;
    npcwc.colorGreen = color.g;
    npcwc.gameObject.GetComponent<SpriteRenderer>().color = new Color(npcwc.colorRed, npcwc.colorGreen, npcwc.colorBlue, npcwc.colorAlpha);
  }

  public override void Action2(
    WalkController wc,
    NPCWalkController npcwc,
    GroundItemController gic)
  {
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && (!GameDataController.gd.getObjective("lighting_rod_installed") || GameDataController.gd.getObjectiveDetail("day3_complete") < 1))
      return;
    if ((Object) gic != (Object) null)
    {
      if (!GameDataController.gd.getObjective("attic_hatch_open"))
        gic.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f);
      else
        gic.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 0.6f);
    }
    if ((Object) wc != (Object) null)
    {
      if (!GameDataController.gd.getObjective("attic_hatch_open"))
        PlayerController.pc.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f);
      else
        PlayerController.pc.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 0.6f);
    }
    if (!((Object) npcwc != (Object) null))
      return;
    if (!GameDataController.gd.getObjective("attic_hatch_open"))
    {
      if (!((Object) npcwc != (Object) null))
        return;
      npcwc.colorBlue = 0.3f;
      npcwc.colorRed = 0.3f;
      npcwc.colorGreen = 0.3f;
      npcwc.gameObject.GetComponent<SpriteRenderer>().color = new Color(npcwc.colorRed, npcwc.colorGreen, npcwc.colorBlue, npcwc.colorAlpha);
    }
    else
    {
      if (!((Object) npcwc != (Object) null))
        return;
      npcwc.colorBlue = 0.6f;
      npcwc.colorRed = 0.6f;
      npcwc.colorGreen = 0.6f;
      npcwc.gameObject.GetComponent<SpriteRenderer>().color = new Color(npcwc.colorRed, npcwc.colorGreen, npcwc.colorBlue, npcwc.colorAlpha);
    }
  }
}
