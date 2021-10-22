// Decompiled with JetBrains decompiler
// Type: SiderealF1CHose
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class SiderealF1CHose : ObjectActionController
{
  private CursorController cursorController;
  public SpriteRenderer sr;
  public Sprite glass;
  public Sprite ready;
  public Sprite done;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_hose";
    this.range = 1f;
    this.updateState();
    this.cursorController = GameObject.Find("cursor").GetComponent<CursorController>();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("rock", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rock2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("pipe", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("wrench", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("crowbar", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("hammer", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_6", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_0", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_6", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_0", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_6", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_0", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_6", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_0", string.Empty, anim: string.Empty));
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjectiveDetail("sidereal_elevator_f1_hosed") == 0)
    {
      if (this.usedItem != string.Empty)
      {
        GameDataController.gd.setObjectiveDetail("sidereal_elevator_f1_hosed", 1);
        CurtainController.cc.fadeOut(sound: SoundsManagerController.sm.break_window);
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_hose_glass"));
    }
    else if (this.usedItem != string.Empty)
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_hose_glass2"));
    }
    else
    {
      this.cursorController.selectItem(ItemsManager.im.getItem("fire_hose"));
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.rope);
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("sidereal_elevator_f1_hosed") == 0)
    {
      this.sr.sprite = this.glass;
      this.setCollider(0);
    }
    else if (!GameDataController.gd.getObjective("sidereal_elevator_f1_hosed"))
    {
      this.sr.sprite = this.ready;
      this.setCollider(0);
    }
    else
    {
      this.sr.sprite = this.done;
      this.setCollider(-1);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
    if (GameDataController.gd.getObjectiveDetail("sidereal_elevator_f1_hosed") == 0 && this.usedItem == string.Empty)
    {
      this.range = 30f;
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
    else
    {
      this.range = 1f;
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.characterAnimationName = "action_n";
    }
  }

  public override void whatOnClick()
  {
  }
}
