// Decompiled with JetBrains decompiler
// Type: ShipToolbox
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class ShipToolbox : ObjectActionController
{
  public Sprite closed;
  public Sprite open;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "ship_toolbox";
    this.range = 1f;
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("ship_toolbox_open"))
    {
      GameDataController.gd.setObjective("ship_toolbox_open", true);
      this.updateAll();
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.toolbox1);
    }
    else if (!GameDataController.gd.getObjective("ship_toolbox_searched"))
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.toolbox2);
      if (InventoryController.ic.pickUpItem(ItemsManager.im.getItem("gluegun")))
        GameDataController.gd.setObjective("ship_toolbox_searched", true);
    }
    this.updateAll();
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjective("ship_toolbox_open"))
      this.GetComponent<SpriteRenderer>().enabled = true;
    else
      this.GetComponent<SpriteRenderer>().enabled = false;
    if (GameDataController.gd.getObjective("ship_toolbox_searched"))
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
    else
    {
      this.characterAnimationName = "kneel_se";
      this.animationFlip = true;
      this.useCurrentDirection = false;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
    if (GameDataController.gd.getObjective("ship_toolbox_open") && GameDataController.gd.getObjective("ship_toolbox_searched"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "ship_toolbox_searched2"));
    if (!GameDataController.gd.getObjective("ship_toolbox_open") || GameDataController.gd.getObjective("ship_toolbox_searched"))
      return;
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "ship_toolbox_searched1"));
  }

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}
