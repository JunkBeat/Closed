// Decompiled with JetBrains decompiler
// Type: CS1_Waypoint_4
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class CS1_Waypoint_4 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "construction_site_entrance";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.range = 10f;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getCurrentDay() == 3)
    {
      DialogueController.dc.quickDialogue(GingerActionController.getColor(), (NPCActionController) GameObject.Find("Ginger").GetComponent<GingerActionController>(), "cs_park_gate");
    }
    else
    {
      PlayerController.pc.spawnName = "Waypoint_CS4_CS1";
      CurtainController.cc.fadeOut("CS4", WalkController.Direction.E);
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getCurrentDay() == 3)
    {
      if (!GameDataController.gd.getObjective("cs_thug_shot"))
      {
        this.interactions = new List<ItemInteraction>();
        this.interactions.Add(new ItemInteraction("rifle_so_6", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_so_5", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_so_4", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_so_3", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_so_2", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_so_1", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_so_0", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_s_6", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_s_5", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_s_4", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_s_3", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_s_2", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_s_1", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_s_0", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_o_6", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_o_5", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_o_4", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_o_3", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_o_2", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_o_1", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_o_0", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_6", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_5", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_4", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_3", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_2", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_1", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("revolver_0", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("revolver_1", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("revolver_2", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("revolver_3", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("revolver_4", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("revolver_5", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("revolver_6", GameStrings.getString(GameStrings.actions, "cs_sharpshooter"), anim: string.Empty));
      }
      else
      {
        this.interactions = new List<ItemInteraction>();
        this.interactions.Add(new ItemInteraction("rifle_so_6", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_so_5", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_so_4", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_so_3", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_so_2", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_so_1", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_so_0", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_s_6", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_s_5", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_s_4", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_s_3", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_s_2", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_s_1", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_s_0", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_o_6", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_o_5", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_o_4", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_o_3", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_o_2", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_o_1", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_o_0", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_6", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_5", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_4", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_3", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_2", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("rifle_1", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("revolver_0", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("revolver_1", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("revolver_2", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("revolver_3", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("revolver_4", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("revolver_5", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("revolver_6", GameStrings.getString(GameStrings.actions, "cs_nomore"), anim: string.Empty));
      }
    }
    else
      this.interactions = new List<ItemInteraction>();
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
