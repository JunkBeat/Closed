// Decompiled with JetBrains decompiler
// Type: LocationRVAid
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationRVAid : ObjectActionController
{
  public Sprite closed;
  public Sprite open;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "rv_aid";
    this.range = 1f;
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("rv_aid_open"))
    {
      GameDataController.gd.setObjective("rv_aid_open", true);
      this.updateAll();
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.cabinet_open);
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "rv_aid_1"));
    }
    else if (!GameDataController.gd.getObjective("rv_bandage_taken"))
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("bandage")))
        return;
      GameDataController.gd.setObjective("rv_bandage_taken", true);
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "rv_aid_2"));
    }
    else if (!GameDataController.gd.getObjective("rv_silver_taken"))
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("thermalb")))
        return;
      GameDataController.gd.setObjective("rv_silver_taken", true);
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "rv_aid_3"));
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "rv_aid_4"));
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjective("rv_aid_open"))
      this.GetComponent<SpriteRenderer>().sprite = this.open;
    else
      this.GetComponent<SpriteRenderer>().sprite = this.closed;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}
