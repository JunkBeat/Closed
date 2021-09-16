// Decompiled with JetBrains decompiler
// Type: SiderealF1sFax
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SiderealF1sFax : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.characterAnimationName = "action_n";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_secrets";
    this.range = 2f;
    this.updateState();
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("sidereal_secrets_taken"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_fax"));
    else
      this.pickItUp((string) null);
  }

  private void pickItUp(string param)
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("sidereal_secrets")))
      return;
    ItemsManager.exmineItem(ItemsManager.im.getItem("sidereal_secrets"));
    GameDataController.gd.setObjective("sidereal_secrets_taken", true);
    this.updateAll();
  }

  public override void whatOnClick()
  {
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("sidereal_secrets_taken"))
    {
      this.range = 50f;
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.characterAnimationName = "action_stnd_";
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.objectName = "sidereal_fax";
    }
    else
    {
      this.range = 2f;
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.characterAnimationName = "action_n";
      this.objectName = "sidereal_secrets";
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
