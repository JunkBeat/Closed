// Decompiled with JetBrains decompiler
// Type: BridgeAreaAction1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class BridgeAreaAction1 : AreaEffect
{
  public int mode;

  public override void Action(WalkController wc, NPCWalkController npcwc, GroundItemController gic)
  {
    if ((Object) wc != (Object) null)
    {
      if (this.mode == 1 && GameDataController.gd.getObjective("bridge_planks_used_1"))
        PlayerController.ssg.setStepType("normal");
      else if (this.mode == 2)
        PlayerController.ssg.setStepType("dirt");
      else
        PlayerController.ssg.setStepType("road");
    }
    if (!((Object) npcwc != (Object) null))
      return;
    if (this.mode == 1 && GameDataController.gd.getObjective("bridge_planks_used_1"))
      npcwc.gameObject.GetComponent<StepSoundGenerator>().setStepType("normal");
    else if (this.mode == 2)
      npcwc.gameObject.GetComponent<StepSoundGenerator>().setStepType("dirt");
    else
      npcwc.gameObject.GetComponent<StepSoundGenerator>().setStepType("road");
  }

  public override void Action2(
    WalkController wc,
    NPCWalkController npcwc,
    GroundItemController gic)
  {
  }
}
