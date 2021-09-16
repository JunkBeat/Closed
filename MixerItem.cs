// Decompiled with JetBrains decompiler
// Type: MixerItem
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class MixerItem : ObjectActionController
{
  private SpriteRenderer sr;
  public Sprite sprite_1;
  public Sprite sprite_2;
  private int liczba;
  public string thisNumber;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "pill_half";
    this.range = 8000f;
    this.teleport = false;
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
    this.interactions = new List<ItemInteraction>();
    this.updateState();
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("sidereal_mixer_mixed"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_mixer_item_no_use"));
    else if (GameDataController.gd.getObjectiveDetail("sidereal_mixer_mixed") == 3)
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_mixer_button_already_done"));
    else if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 0)
      CursorController.cc.selectItem(ItemsManager.im.getItem("pill_half"));
    else
      CursorController.cc.selectItem(ItemsManager.im.getItem("mixer_glass"));
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 0)
    {
      this.setCollider(0);
      this.objectName = "pill_half";
      this.sr.sprite = this.sprite_1;
    }
    else
    {
      this.setCollider(1);
      this.sr.sprite = this.sprite_2;
      this.objectName = "mixer_glass";
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
