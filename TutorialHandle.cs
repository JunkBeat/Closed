// Decompiled with JetBrains decompiler
// Type: TutorialHandle
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class TutorialHandle : ObjectActionController
{
  public Sprite painting;
  public PolygonCollider2D blocker;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "tutorial_pole";
    this.range = 1f;
  }

  public override void clickAction() => QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "tutorial_time_question"), yesClick: new Button.Delegate(this.pullit), time: 3);

  public void pullit() => PlayerController.wc.forceAnimation("action_n");

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjective("tutorial_handle_taken"))
    {
      this.colliderManager.setCollider(-1);
      this.blocker.enabled = false;
      this.GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      this.colliderManager.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.blocker.enabled = true;
    }
    GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
  }

  public override void clickAction2()
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("sledge_handle")))
      return;
    GameDataController.gd.setObjective("tutorial_handle_taken", true);
    this.updateAll();
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
