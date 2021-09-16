// Decompiled with JetBrains decompiler
// Type: MixerPaper
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class MixerPaper : ObjectActionController
{
  private SpriteRenderer sr;
  public Sprite sprite_1;
  public Sprite sprite_2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "mixer_note";
    this.range = 8000f;
    this.teleport = false;
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("mixer_glass", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("pill_half", string.Empty, anim: string.Empty));
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
    ExamineSprite.es.textField.shift.x = -115f;
    ExamineSprite.es.textField.shift.y = -23f;
    if (InventoryController.ic.isItemInInventory("mixer_pills_note"))
    {
      ExamineSprite.es.readyText(new List<string>()
      {
        GameStrings.getString(GameStrings.world_labels, "mixer_pills")
      }, 122, 0.2431373f, 0.227451f, 0.1098039f, 0.0f, 0.0f, 0.0f, 0.0f);
      ExamineSprite.es.show(this.sprite_1);
    }
    else if (InventoryController.ic.isItemInInventory("mixer_catalyst_note"))
    {
      ExamineSprite.es.readyText(new List<string>()
      {
        GameStrings.getString(GameStrings.world_labels, "mixer_catalyst")
      }, 122, 0.2431373f, 0.227451f, 0.1098039f, 0.0f, 0.0f, 0.0f, 0.0f);
      ExamineSprite.es.show(this.sprite_2);
    }
    ExamineSprite.es.textField.shift.y = -23f;
  }

  public override void updateState()
  {
    if (InventoryController.ic.isItemInInventory("mixer_pills_note") || InventoryController.ic.isItemInInventory("mixer_catalyst_note"))
    {
      this.sr.enabled = true;
      this.setCollider(0);
    }
    else
    {
      this.setCollider(-1);
      this.sr.enabled = false;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
