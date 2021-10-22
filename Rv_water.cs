// Decompiled with JetBrains decompiler
// Type: Rv_water
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class Rv_water : ObjectActionController
{
  public Sprite ww1;
  public Sprite ww2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "rv_water2";
    this.range = 1f;
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("rv_water3_taken"))
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("water3")))
        return;
      GameDataController.gd.setObjective("rv_water3_taken", true);
      this.updateAll();
    }
    else
    {
      if (GameDataController.gd.getObjective("rv_water4_taken") || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("water4")))
        return;
      GameDataController.gd.setObjective("rv_water4_taken", true);
      this.updateAll();
    }
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("rv_water3_taken"))
    {
      this.setCollider(0);
      this.GetComponent<SpriteRenderer>().sprite = this.ww2;
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.characterAnimationName = "action_n";
      this.objectName = "rv_water1";
    }
    else if (!GameDataController.gd.getObjective("rv_water4_taken"))
    {
      this.setCollider(0);
      this.GetComponent<SpriteRenderer>().sprite = this.ww1;
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.characterAnimationName = "action_n";
      this.objectName = "rv_water2";
    }
    else
    {
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().sprite = this.ww2;
      this.GetComponent<SpriteRenderer>().enabled = false;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
