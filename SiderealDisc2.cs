// Decompiled with JetBrains decompiler
// Type: SiderealDisc2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class SiderealDisc2 : ObjectActionController
{
  public SpriteRenderer blik;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action1_e";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "disc2";
    this.range = 1f;
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
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("disc2")))
      return;
    if (GameDataController.KART)
    {
      GameDataController.persistentData.kong_disk = true;
      GameDataController.gd.PersistentSave();
    }
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "pick_disc2"));
    GameDataController.gd.setObjective("sidereal_disc2_taken", true);
    this.updateAll();
  }

  public override void updateState()
  {
    this.GetComponent<SpriteRenderer>().enabled = true;
    this.blik.enabled = true;
    if (GameDataController.gd.getObjective("sidereal_disc2_taken"))
    {
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.blik.enabled = false;
    }
    else
      this.setCollider(0);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
