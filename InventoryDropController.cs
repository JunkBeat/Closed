// Decompiled with JetBrains decompiler
// Type: InventoryDropController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryDropController : ObjectActionController
{
  private GameObject inventoryButton;
  private CursorController cursorController;
  private InventoryController invetoryController;
  private ItemsManager itemsManager;
  private WalkController walkControllerr;

  private void Start()
  {
    this.inventoryButton = GameObject.Find("inventory_button");
    this.animationFlip = false;
    this.characterAnimationName = "kneel_";
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.cursorController = GameObject.Find("cursor").GetComponent<CursorController>();
    this.invetoryController = GameObject.Find("inventory").GetComponent<InventoryController>();
    this.itemsManager = GameObject.Find("ItemsManager").GetComponent<ItemsManager>();
    this.walkControllerr = PlayerController.wc;
    this.dkvs = GameStrings.gui;
    this.objectName = "drop";
  }

  public override void whatOnClick0()
  {
    if (PlayerController.wc.dir == WalkController.Direction.N)
    {
      if ((double) Random.Range(0.0f, 1f) >= 0.5)
        PlayerController.wc.forceDirection(WalkController.Direction.E);
      else
        PlayerController.wc.forceDirection(WalkController.Direction.W);
    }
    else if (PlayerController.wc.dir == WalkController.Direction.NE)
    {
      PlayerController.wc.forceDirection(WalkController.Direction.E);
    }
    else
    {
      if (PlayerController.wc.dir != WalkController.Direction.NW)
        return;
      PlayerController.wc.forceDirection(WalkController.Direction.W);
    }
  }

  public override void clickAction()
  {
    PlayerController.pc.clickedSomething = false;
    if (!PlayerController.pc.allowDrop || !(CursorController.cc.selectedItemName != string.Empty))
      return;
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(this.walkControllerr.currentXY.x, this.walkControllerr.currentXY.y + (float) GroundItemController.yOffset));
    Vector3 vector3 = new Vector3(screen.x, screen.y, 0.0f);
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint((Vector3) screen);
    PlayerController.pc.aS.PlayOneShot(this.cursorController.selectedItemRef.sound);
    (Object.Instantiate(Resources.Load("Prefabs/GroundItem"), worldPoint, new Quaternion()) as GameObject).GetComponent<GroundItemController>().init(this.cursorController.selectedItemRef);
    this.invetoryController.removeItem(this.cursorController.selectedItemName);
    this.cursorController.selectedItemRef.dataRef.locX = (int) this.walkControllerr.currentXY.x;
    this.cursorController.selectedItemRef.dataRef.locY = (int) this.walkControllerr.currentXY.y;
    this.cursorController.selectedItemRef.dataRef.droppedLocation = SceneManager.GetActiveScene().name;
    JournalTexts.pickTexts(GameDataController.gd.getCurrentDay());
    this.cursorController.deselectItem();
  }

  public override void updateState()
  {
  }

  public override void clickAction2()
  {
  }

  private void OnMouseEnter()
  {
    CursorController.cc.showCursor(CursorController.PixelCursor.ACTIVE);
    if (PlayerController.wc.busy)
      return;
    this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    GameObject gameObject = GameObject.Find("BottomText");
    if (!PlayerController.pc.allowDrop)
      gameObject.GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "no_drop"), quick: true, mwidth: 200);
    else if (CursorController.cc.selectedItemName.Equals(string.Empty))
      gameObject.GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "drop_a") + "^" + GameStrings.getString(GameStrings.gui, "drop_b"), quick: true, mwidth: 240);
    else
      gameObject.GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "drop1") + " " + GameStrings.getString(GameStrings.items, CursorController.cc.selectedItemName + "_short") + " " + GameStrings.getString(GameStrings.gui, "drop2"), quick: true, mwidth: 240);
  }

  private void OnMouseExit()
  {
    CursorController.cc.showCursor(CursorController.PixelCursor.NORMAL);
    GameObject gameObject = GameObject.Find("BottomText");
    if (!PlayerController.wc.busy)
      this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.0f);
    gameObject.GetComponent<TextFieldController>().keepAlive = false;
  }

  private void OnMouseDown()
  {
    PlayerController.pc.clickedSomething = true;
    if (PlayerController.wc.busy || !(CursorController.cc.selectedItemName != string.Empty) || !PlayerController.pc.allowDrop)
      return;
    PlayerController.wc.setSimpleTarget(PlayerController.wc.currentXY);
    PlayerController.wc.onFinishWalking = (ObjectActionController) this;
    this.inventoryButton.GetComponent<InventoryButtonController>().close();
    GameObject.Find("BottomText").GetComponent<TextFieldController>().keepAlive = false;
    this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.0f);
    CursorController.cc.showCursor(CursorController.PixelCursor.NORMAL);
    if (PlayerController.wc.dir == WalkController.Direction.N)
    {
      if ((double) Random.Range(0.0f, 1f) >= 0.5)
        PlayerController.wc.forceDirection(WalkController.Direction.E);
      else
        PlayerController.wc.forceDirection(WalkController.Direction.W);
    }
    else if (PlayerController.wc.dir == WalkController.Direction.NE)
    {
      PlayerController.wc.forceDirection(WalkController.Direction.E);
    }
    else
    {
      if (PlayerController.wc.dir != WalkController.Direction.NW)
        return;
      PlayerController.wc.forceDirection(WalkController.Direction.W);
    }
  }

  public override void clickAction0()
  {
  }
}
