// Decompiled with JetBrains decompiler
// Type: BridgeSpade
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BridgeSpade : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "pull_w";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "bridge_spade";
    this.range = 1f;
  }

  public override void clickAction()
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.wood_snap);
    GameDataController.gd.setObjective("bridge_handle_taken", true);
    InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("hammer_handle"), true);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("bridge_handle_taken"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(-1);
    }
    else
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.colliderManager.setCollider(0);
    }
  }

  public override void clickAction2() => this.updateAll();

  public override void clickAction0()
  {
  }
}
