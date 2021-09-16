// Decompiled with JetBrains decompiler
// Type: CSFlyAwayAreaAction
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CSFlyAwayAreaAction : AreaEffect
{
  public Animator crow;
  public ObjectActionController exitcs1;
  public ObjectActionController exitcs3;

  public override void Action(WalkController wc, NPCWalkController npcwc, GroundItemController gic)
  {
    if ((Object) wc != (Object) null)
    {
      if (!GameDataController.gd.getObjective("cs_crow_away"))
      {
        this.crow.Play("crow_fly_away");
        GameDataController.gd.setObjective("cs_crow_away", true);
      }
      if (GameDataController.gd.getObjective("cs_thug_shot") || GameDataController.gd.getCurrentDay() != 3 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 0)
      {
        this.exitcs1.doubleClickCondition = "visited_cs_1";
        this.exitcs3.doubleClickCondition = "visited_cs_3";
      }
      else if ((double) PlayerController.wc.currentXY.x > 120.0)
      {
        this.exitcs1.doubleClickCondition = string.Empty;
        this.exitcs3.doubleClickCondition = "visited_cs_3";
      }
      else
      {
        this.exitcs1.doubleClickCondition = "visited_cs_1";
        this.exitcs3.doubleClickCondition = string.Empty;
      }
    }
    if (!((Object) npcwc != (Object) null))
      ;
    if (!((Object) gic != (Object) null))
      ;
  }

  public override void Action2(
    WalkController wc,
    NPCWalkController npcwc,
    GroundItemController gic)
  {
  }
}
