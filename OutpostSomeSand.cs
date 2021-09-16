// Decompiled with JetBrains decompiler
// Type: OutpostSomeSand
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class OutpostSomeSand : AreaEffect
{
  public override void Action(WalkController wc, NPCWalkController npcwc, GroundItemController gic)
  {
    if (!GameDataController.gd.getObjective("outpost_hatch_open"))
      return;
    if ((Object) wc != (Object) null)
      PlayerController.ssg.setStepType2(StepSoundGenerator.DIRT, AudioReverbPreset.Hangar);
    if (!((Object) npcwc != (Object) null))
      return;
    npcwc.gameObject.GetComponent<StepSoundGenerator>().setStepType2(StepSoundGenerator.DIRT, AudioReverbPreset.Hangar);
  }

  public override void Action2(
    WalkController wc,
    NPCWalkController npcwc,
    GroundItemController gic)
  {
    if ((Object) wc != (Object) null)
      PlayerController.ssg.setStepType2(StepSoundGenerator.METAL, AudioReverbPreset.Hangar);
    if (!((Object) npcwc != (Object) null))
      return;
    npcwc.gameObject.GetComponent<StepSoundGenerator>().setStepType2(StepSoundGenerator.METAL, AudioReverbPreset.Hangar);
  }
}
