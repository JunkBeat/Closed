// Decompiled with JetBrains decompiler
// Type: OutpostAreaDoormat
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class OutpostAreaDoormat : AreaEffect
{
  public SpriteRenderer mataEl;
  public LocationOutpostOutside2Start loc;

  public override void Action(WalkController wc, NPCWalkController npcwc, GroundItemController gic)
  {
    if ((Object) wc != (Object) null)
    {
      PlayerController.ssg.setStepType2(StepSoundGenerator.METAL, AudioReverbPreset.Mountains);
      if (GameDataController.gd.getObjective("outpost_door_powered") && !GameDataController.gd.getObjective("outpost_door_open") && !GameDataController.gd.getObjective("outpost_doormat_triggered"))
      {
        GameDataController.gd.setObjective("outpost_doormat_triggered", true);
        this.mataEl.enabled = true;
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.small_powerup);
        PlayerController.pc.allowDrop = false;
        this.loc.doormatGo(string.Empty);
      }
    }
    if (!((Object) npcwc != (Object) null))
      return;
    npcwc.gameObject.GetComponent<StepSoundGenerator>().setStepType2(StepSoundGenerator.METAL, AudioReverbPreset.Mountains);
  }

  public override void Action2(
    WalkController wc,
    NPCWalkController npcwc,
    GroundItemController gic)
  {
    if ((Object) wc != (Object) null && GameDataController.gd.getObjective("outpost_door_powered"))
    {
      if (GameDataController.gd.getObjective("outpost_doormat_triggered"))
      {
        GameDataController.gd.setObjective("outpost_doormat_triggered", false);
        GameDataController.gd.setObjectiveDetail("outpost_doormat_triggered", 0);
        this.mataEl.enabled = false;
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.small_powerdown);
        this.loc.letItGo();
        PlayerController.pc.allowDrop = true;
      }
      if (GameDataController.gd.getObjective("outpost_door_open"))
      {
        GameDataController.gd.setObjective("outpost_door_open", false);
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_slide);
        GameObject.Find("Waypoint_Outpost2_3").GetComponent<Waypoint_Outpost2_3>().closedo();
      }
    }
    if (!((Object) npcwc != (Object) null))
      ;
  }
}
