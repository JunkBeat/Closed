// Decompiled with JetBrains decompiler
// Type: CS3Bars
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class CS3Bars : ObjectActionController
{
  public Sprite ammobox1;
  public Sprite ammobox2;
  private CursorController cursorController;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_bars";
    this.range = 1f;
    this.updateState();
    this.cursorController = GameObject.Find("cursor").GetComponent<CursorController>();
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    if (InventoryController.ic.pickUpItem(ItemsManager.im.getItem("window_bars1")))
      GameDataController.gd.setObjective("cs_bars_taken", true);
    this.updateState();
  }

  public override void updateState()
  {
    this.setCollider(-1);
    this.GetComponent<SpriteRenderer>().enabled = false;
    if (GameDataController.gd.getObjective("cs_bars_taken") || !GameDataController.gd.getObjective("gasstation_bars1_taken") || !GameDataController.gd.getObjective("gasstation_bars2_taken") || !GameDataController.gd.getObjective("gasstation_bars3_taken"))
      return;
    int num = 3;
    if (ItemsManager.im.getItem("window_bars1").dataRef.droppedLocation == "nowhere")
      --num;
    if (ItemsManager.im.getItem("window_bars2").dataRef.droppedLocation == "nowhere")
      --num;
    if (ItemsManager.im.getItem("window_bars3").dataRef.droppedLocation == "nowhere")
      --num;
    if (GameDataController.gd.getObjective("base_window_1_bars") && GameDataController.gd.getObjective("base_window1_broken"))
      --num;
    if (GameDataController.gd.getObjective("base_window_2_bars") && GameDataController.gd.getObjective("base_window2_broken"))
      --num;
    if (GameDataController.gd.getObjective("base_window_3_bars") && GameDataController.gd.getObjective("base_window3_broken"))
      --num;
    if (num > 0)
      return;
    this.setCollider(0);
    this.GetComponent<SpriteRenderer>().enabled = true;
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
