// Decompiled with JetBrains decompiler
// Type: UpstairsPapers
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class UpstairsPapers : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "upstairs_papers";
  }

  public override void clickAction()
  {
    GameDataController.gd.setObjective("upstairs_papers_taken", true);
    GameDataController.gd.setObjective("upstairs_paperclip_taken", true);
    PlayerController.wc.forceAnimation("stand_n");
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      actionWithText = false,
      blockG = true,
      text = GameStrings.getString(GameStrings.actions, "base_papers1"),
      function = new TimelineFunction(this.take1),
      param = "paperclip"
    });
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      actionWithText = false,
      blockG = true,
      text = GameStrings.getString(GameStrings.actions, "base_papers2"),
      function = new TimelineFunction(this.take1),
      param = "invoices"
    });
    this.updateAll();
  }

  private void take1(string param = "") => InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem(param));

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("upstairs_papers_taken"))
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

  public override void clickAction0()
  {
  }
}
