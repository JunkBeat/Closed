// Decompiled with JetBrains decompiler
// Type: Crashsite1Wrench
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Crashsite1Wrench : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      this.objectName = "crashsite_wrench_bugs";
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
    {
      this.objectName = "crashsite_wrench_gas";
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 2)
        return;
      this.objectName = "crashsite_wrench_spiders";
    }
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("crashsite_wrench_taken") || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("wrench")))
      return;
    GameDataController.gd.setObjective("crashsite_wrench_taken", true);
    this.updateAll();
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("crashsite_wrench_taken"))
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

  public override void clickAction2()
  {
  }

  public override void clickAction0() => PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "crashsite_wrench"), true);
}
