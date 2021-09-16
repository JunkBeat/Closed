﻿// Decompiled with JetBrains decompiler
// Type: SiderealLabVials1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class SiderealLabVials1 : ObjectActionController
{
  public Sprite va;
  public Sprite vb;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_up_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "lab_vials";
    this.range = 1f;
    this.teleport = false;
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
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("vials1")))
      return;
    GameDataController.gd.setObjective("sidereal_vials1_taken", true);
    this.updateAll();
  }

  public override void updateState()
  {
    this.GetComponent<SpriteRenderer>().enabled = true;
    if (GameDataController.gd.getObjective("sidereal_vials1_taken"))
    {
      this.setCollider(-1);
      if (GameDataController.gd.getObjective("sidereal_components_1"))
      {
        this.GetComponent<SpriteRenderer>().sprite = this.vb;
        this.setCollider(-1);
      }
      else
        this.GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      this.GetComponent<SpriteRenderer>().sprite = this.va;
      this.setCollider(0);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
