// Decompiled with JetBrains decompiler
// Type: InventoryButtonController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class InventoryButtonController : MonoBehaviour
{
  private string frame_name;
  private string frame_name_sufix;
  private bool isOpen;
  private InventoryController inventory;
  private InventoryCapMeterController invCapCont;
  private Vector2 pozycja;
  public static InventoryButtonController ibc;
  public bool spaceWasPressed;
  public bool justClosed;

  private void Awake()
  {
    if ((Object) InventoryButtonController.ibc == (Object) null)
    {
      Object.DontDestroyOnLoad((Object) this.gameObject);
      InventoryButtonController.ibc = this;
    }
    else
    {
      if (!((Object) InventoryButtonController.ibc != (Object) this))
        return;
      Object.Destroy((Object) this.gameObject);
    }
  }

  public bool isItOpen() => this.isOpen;

  private void Start()
  {
    this.spaceWasPressed = false;
    this.frame_name = "inventory_button_closed_";
    this.frame_name_sufix = "0";
    this.inventory = InventoryController.ic;
    this.invCapCont = InventoryCapMeterController.cm;
    this.isOpen = true;
    this.close();
    this.justClosed = false;
    this.pozycja = new Vector2(14f, (float) sbyte.MaxValue);
    Vector2 screen = ScreenControler.gameToScreen(this.pozycja);
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -1.5f;
    this.gameObject.transform.position = worldPoint;
  }

  private void Update()
  {
  }

  public void open(int invno = 0)
  {
    Timeline.t.stopChitChat();
    Vector3 position = this.gameObject.transform.position;
    position.z = -3f;
    this.gameObject.transform.position = position;
    PlayerController.wc.fullStop(true);
    this.invCapCont.updateText();
    GameDataController.gd.saveIfOK(string.Empty);
    if (CursorController.cc.selectedItemRef != null && (double) CursorController.cc.selectedItemRef.weight < 0.0)
      CursorController.cc.deselectItem();
    this.frame_name = "inventory_button_open_";
    this.isOpen = true;
    this.inventory.gameObject.SetActive(true);
    if (invno == 1)
    {
      this.inventory.InvTrunkClose.initButton("  " + GameStrings.getString(GameStrings.gui, "close") + "  ");
      InventoryController.ic.trunk.SetActive(true);
    }
    if (invno == 2)
    {
      this.inventory.InvChestClose.initButton("  " + GameStrings.getString(GameStrings.gui, "close") + "  ");
      InventoryController.ic.chest.SetActive(true);
    }
    this.gameObject.GetComponent<Animator>().Play(this.frame_name + this.frame_name_sufix, 0);
  }

  public void unstuckTrunk() => GameObject.Find("Trunk").GetComponent<CarTrunk>().setCollider(0);

  public void close()
  {
    if (!this.isOpen)
      return;
    this.frame_name = "inventory_button_closed_";
    this.isOpen = false;
    GameObject.Find("bag_drop").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.0f);
    Vector3 position = this.gameObject.transform.position;
    position.z = -1.5f;
    this.gameObject.transform.position = position;
    this.spaceWasPressed = false;
    if (!InventoryController.ic.blocker.enabled)
    {
      InventoryButtonController.ibc.justClosed = true;
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.trunk_close);
    }
    this.inventory.cleanUp();
    InventoryController.ic.blocker.enabled = true;
    this.inventory.InvTrunkClose.buttonText.dissmiss(true);
    this.inventory.InvChestClose.buttonText.dissmiss(true);
    this.inventory.gameObject.SetActive(false);
    this.gameObject.GetComponent<Animator>().Play(this.frame_name + this.frame_name_sufix, 0);
    InventoryController.ic.trunk.SetActive(false);
    InventoryController.ic.chest.SetActive(false);
  }

  internal void showInventory(string param)
  {
    this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    this.Invoke("show", 0.25f);
    this.Invoke("hide", 0.5f);
    this.Invoke("show", 0.75f);
    this.Invoke("hide", 1f);
    this.Invoke("show", 1.25f);
    this.Invoke("hide", 1.5f);
    this.Invoke("show", 1.75f);
    this.Invoke("hide", 2f);
    this.Invoke("showFinal", 2.25f);
  }

  public void showFinal()
  {
    this.show();
    this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
  }

  private void show()
  {
    Vector2 screen = ScreenControler.gameToScreen(this.pozycja);
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -4f;
    this.gameObject.transform.position = worldPoint;
  }

  public void hide()
  {
    this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(-9999f, -9999f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -4f;
    this.gameObject.transform.position = worldPoint;
  }

  public void openTrunk()
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.trunk_open);
    InventoryController.ic.blocker.enabled = false;
    this.open(1);
  }

  public void openChest()
  {
    InventoryController.ic.blocker.enabled = false;
    this.open(2);
  }

  private void OnMouseOver()
  {
    if (!PlayerController.wc.busy && PlayerController.pc.dialogue == PlayerController.DialogueState.NONE)
    {
      CursorController.cc.showCursor(CursorController.PixelCursor.ACTIVE);
      if (!(this.frame_name_sufix != "1"))
        return;
      if (!this.isOpen)
        ;
      this.frame_name_sufix = "1";
      this.gameObject.GetComponent<Animator>().Play(this.frame_name + this.frame_name_sufix, 0);
      GameObject.Find("BottomText").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "inventory"), quick: true, mwidth: 200);
    }
    else
      this.OnMouseExit();
  }

  private void OnMouseExit()
  {
    if (PlayerController.wc.busy)
      return;
    GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>().showCursor(CursorController.PixelCursor.NORMAL);
    GameObject.Find("BottomText").GetComponent<TextFieldController>().keepAlive = false;
    this.frame_name_sufix = "0";
    this.gameObject.GetComponent<Animator>().Play(this.frame_name + this.frame_name_sufix, 0);
  }

  public void fakeMouseClick(bool spacja = false)
  {
    this.spaceWasPressed = spacja;
    this.OnMouseDown();
    PlayerController.pc.clickedSomething = false;
  }

  private void OnMouseDown()
  {
    if (PlayerController.wc.busy || PlayerController.pc.dialogue != PlayerController.DialogueState.NONE)
      return;
    PlayerController.pc.clickedSomething = true;
    if (this.isOpen)
      this.close();
    else
      this.open();
  }
}
