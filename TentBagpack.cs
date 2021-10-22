// Decompiled with JetBrains decompiler
// Type: TentBagpack
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class TentBagpack : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_s";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "tent_backpack";
    this.range = 100f;
    this.teleport = false;
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    this.colliderManager.setCollider(-1);
    GameDataController.gd.setObjective("tent_backpack_taken", true);
    this.updateAll();
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.gameObject.GetComponent<Animator>().speed = 1f;
    this.Invoke("fixShadow", 1f);
    Timeline.t.addAction(new TimelineAction(GameObject.Find("BottomText").GetComponent<TextFieldController>())
    {
      text = "[" + GameStrings.getString(GameStrings.gui, "inventory_hint") + "]",
      function = new TimelineFunction(GameObject.Find("inventory_button").GetComponent<InventoryButtonController>().showInventory),
      actionWithText = true,
      textWidth = 170
    });
  }

  public void fixShadow() => PlayerController.wc.shadowOffsetY = -5;

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("tent_awake"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.colliderManager.setCollider(-1);
    }
    else if (GameDataController.gd.getObjective("tent_backpack_taken"))
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
