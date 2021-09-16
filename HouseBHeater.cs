// Decompiled with JetBrains decompiler
// Type: HouseBHeater
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HouseBHeater : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "house_b_heater";
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("house_b_heater_taken") || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("heater_broken")))
      return;
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "heater_broken_pick"));
    GameDataController.gd.setObjective("house_b_heater_taken", true);
    this.updateState();
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1 && !GameDataController.gd.getObjective("house_b_heater_taken"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
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
