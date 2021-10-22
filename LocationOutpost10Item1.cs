// Decompiled with JetBrains decompiler
// Type: LocationOutpost10Item1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationOutpost10Item1 : ObjectActionController
{
  private SpriteRenderer sr;
  public SpriteRenderer light1;
  private bool fastcheck;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_item1";
    this.range = 1f;
    this.teleport = false;
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
    this.updateState();
    this.actionType = ObjectActionController.Type.NormalAction;
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("engine_calibrator")))
      return;
    GameDataController.gd.setObjective("outpost_calibrator_taken", true);
    this.updateState();
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("outpost_calibrator_taken"))
    {
      this.characterAnimationName = "action1_e";
      this.animationFlip = true;
      this.useCurrentDirection = false;
      this.range = 1f;
      this.setCollider(0);
      this.sr.enabled = true;
    }
    else
    {
      this.setCollider(-1);
      this.sr.enabled = false;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
