// Decompiled with JetBrains decompiler
// Type: SiderealF1B_Xero
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class SiderealF1B_Xero : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.characterAnimationName = "action_n";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_xero";
    this.range = 2f;
    this.updateState();
  }

  public override void clickAction() => this.pickItUp((string) null);

  private void pickItUp(string param)
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("sidereal_xero")))
      return;
    ItemsManager.exmineItem(ItemsManager.im.getItem("sidereal_xero"));
    GameDataController.gd.setObjective("sidereal_xero_taken", true);
    this.updateAll();
  }

  public override void whatOnClick()
  {
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("sidereal_xero_taken"))
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.setCollider(-1);
    }
    else
    {
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.range = 2f;
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.characterAnimationName = "action1_e";
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
