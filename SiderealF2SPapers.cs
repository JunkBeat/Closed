// Decompiled with JetBrains decompiler
// Type: SiderealF2SPapers
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class SiderealF2SPapers : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.characterAnimationName = "action_n";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_papers";
    this.range = 2f;
    this.updateState();
  }

  public override void clickAction() => this.pickItUp((string) null);

  private void pickItUp(string param)
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("sidereal_docs")))
      return;
    ItemsManager.exmineItem(ItemsManager.im.getItem("sidereal_docs"));
    GameDataController.gd.setObjective("sidereal_papers_taken", true);
    this.updateAll();
  }

  public override void whatOnClick()
  {
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("sidereal_papers_taken"))
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(-1);
    }
    else
    {
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.colliderManager.setCollider(0);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
