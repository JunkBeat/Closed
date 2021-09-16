// Decompiled with JetBrains decompiler
// Type: RestaurantCupboard3
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class RestaurantCupboard3 : ObjectActionController
{
  public Sprite s1;
  public Sprite s2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_cupboard";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("crowbar", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("paperclip", GameStrings.getString(GameStrings.actions, "cupboard_clip"), anim: string.Empty));
  }

  public override void clickAction()
  {
    if (this.usedItem == "crowbar")
    {
      if (GameDataController.gd.getObjective("restaurant_cupboard3_open"))
        return;
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.wood_crack_2);
      GameDataController.gd.setObjective("restaurant_cupboard3_open", true);
      this.updateAll();
    }
    else
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.wood_crack_1);
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "restaurant_kitchen_cupboard_locked"), true);
    }
  }

  public override void whatOnClick()
  {
    if (this.usedItem == "crowbar")
      this.characterAnimationName = "crowbar_e_low";
    else
      this.characterAnimationName = "kneel_n";
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("restaurant_cupboard3_open"))
    {
      this.setCollider(-1);
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.s2;
    }
    else
    {
      this.setCollider(0);
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.s1;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
