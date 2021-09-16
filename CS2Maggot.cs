// Decompiled with JetBrains decompiler
// Type: CS2Maggot
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class CS2Maggot : ObjectActionController
{
  private CursorController cursorController;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_maggot";
    this.range = 1f;
    this.updateState();
    this.cursorController = GameObject.Find("cursor").GetComponent<CursorController>();
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    PlayerController.pc.aS.PlayOneShot(ItemsManager.im.getItem("maggot").sound);
    this.cursorController.selectItem(ItemsManager.im.getItem("maggot"));
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("cs_thug_shot") || GameDataController.gd.getObjective("cs_safe"))
      this.setCollider(-1);
    else
      this.setCollider(0);
  }

  public override void clickAction2()
  {
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
