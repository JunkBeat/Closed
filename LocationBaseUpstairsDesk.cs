// Decompiled with JetBrains decompiler
// Type: LocationBaseUpstairsDesk
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class LocationBaseUpstairsDesk : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "action_open_ne";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "base_upstairs_desk";
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("upstairs_paperclip_taken") && InventoryController.ic.pickUpItem(ItemsManager.im.getItem("paperclip")))
    {
      GameDataController.gd.setObjective("upstairs_paperclip_taken", true);
      this.updateState();
      PlayerController.pc.textField.viewText("I picked a paperclip that was on the desk.", true);
    }
    else
      PlayerController.pc.textField.viewText("Nothing interesting here.", true);
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("upstairs_paperclip_taken"))
    {
      this.objectName = "base_upstairs_desk";
      this.characterAnimationName = "action_open_ne";
    }
    else
    {
      this.objectName = "base_upstairs_desk_cleared";
      this.characterAnimationName = "stand_n";
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
