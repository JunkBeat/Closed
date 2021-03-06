// Decompiled with JetBrains decompiler
// Type: SiderealF2sFax
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class SiderealF2sFax : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.characterAnimationName = "action_n";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_fax";
    this.range = 2f;
    this.updateState();
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("sidereal_papers_taken"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_fax"));
    else
      this.pickItUp((string) null);
  }

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
      this.range = 50f;
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.characterAnimationName = "action_stnd_";
    }
    else
    {
      this.range = 2f;
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.characterAnimationName = "action_n";
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
