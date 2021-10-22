// Decompiled with JetBrains decompiler
// Type: LocationOutpostCard
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationOutpostCard : ObjectActionController
{
  private SpriteRenderer sr;
  public SpriteRenderer light1;
  private bool fastcheck;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_card";
    this.range = 0.0f;
    this.teleport = false;
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
    this.updateState();
    this.actionType = ObjectActionController.Type.NormalAction;
  }

  private void Update()
  {
    if (this.fastcheck || (double) PlayerController.wc.currentXY.x >= 158.0 && (double) PlayerController.wc.currentXY.x <= 170.0 && (double) PlayerController.wc.currentXY.y < 18.0)
      this.light1.enabled = false;
    else
      this.light1.enabled = true;
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("outpost_card")))
      return;
    GameDataController.gd.setObjective("outpost_card_taken", true);
    this.updateState();
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("outpost_card_taken") && GameDataController.gd.getObjective("outpost_switch_pressed"))
    {
      this.characterAnimationName = "action_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.range = 1f;
      this.setCollider(0);
      this.sr.enabled = true;
    }
    else
    {
      this.setCollider(-1);
      this.sr.enabled = false;
    }
    this.fastcheck = GameDataController.gd.getObjective("outpost_card_taken") || !GameDataController.gd.getObjective("outpost_switch_pressed");
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
