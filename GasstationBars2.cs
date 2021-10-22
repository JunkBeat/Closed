// Decompiled with JetBrains decompiler
// Type: GasstationBars2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class GasstationBars2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_e";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_bars";
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("gasstation_bars2_taken") || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("window_bars2")))
      return;
    GameDataController.gd.setObjective("gasstation_bars2_taken", true);
    this.updateState();
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (!GameDataController.gd.getObjective("gasstation_bars2_taken"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.characterAnimationName = "kneel_e";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(-1);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
