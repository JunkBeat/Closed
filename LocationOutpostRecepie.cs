// Decompiled with JetBrains decompiler
// Type: LocationOutpostRecepie
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationOutpostRecepie : ObjectActionController
{
  public SpriteRenderer sr;
  public Sprite present;
  public Sprite gone;
  private bool fastcheck;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_recepie";
    this.range = 0.0f;
    this.teleport = false;
    this.updateState();
    this.actionType = ObjectActionController.Type.NormalAction;
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 1)
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("mixer_catalyst_note")))
        return;
      GameDataController.gd.setObjective("mixer_note_taken", true);
      this.updateState();
    }
    else
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("mixer_pills_note")))
        return;
      GameDataController.gd.setObjective("mixer_note_taken", true);
      this.updateState();
    }
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("mixer_note_taken"))
    {
      this.characterAnimationName = "action_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.range = 1f;
      this.setCollider(0);
      this.sr.sprite = this.present;
    }
    else
    {
      this.setCollider(-1);
      this.sr.sprite = this.gone;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
