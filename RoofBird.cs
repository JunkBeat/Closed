// Decompiled with JetBrains decompiler
// Type: RoofBird
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class RoofBird : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_s";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "deadbird";
    this.range = 5f;
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
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("deadbird")))
      return;
    GameDataController.gd.setObjective("deadbird_taken", true);
    this.updateAll();
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("chimney_cleaned") && !GameDataController.gd.getObjective("deadbird_taken"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.colliderManager.setCollider(0);
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
