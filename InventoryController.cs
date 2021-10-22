// Decompiled with JetBrains decompiler
// Type: InventoryController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryController : MonoBehaviour
{
  private GameObject inventoryButton;
  private TextFieldController inventoryCloseButtonTextfield;
  private TextFieldController inventoryCloseButtonTextfield2;
  private InventoryItemController[,] invItems;
  private InventoryItemController[,] trunkItems;
  private InventoryItemController[,] chestItems;
  public GameObject trunk;
  public GameObject chest;
  public static InventoryController ic;
  public AudioSource aS;
  public InventoryCapMeterController capMeter;
  public PolygonCollider2D blocker;
  public int maxCapacity = 30;
  public Button InvTrunkClose;
  public Button InvChestClose;

  private void Awake()
  {
    if ((Object) InventoryController.ic == (Object) null)
    {
      Object.DontDestroyOnLoad((Object) this.gameObject);
      InventoryController.ic = this;
      MonoBehaviour.print((object) "Inventory controler initialized");
    }
    else
    {
      if (!((Object) InventoryController.ic != (Object) this))
        return;
      Object.Destroy((Object) this.gameObject);
    }
  }

  private void Start()
  {
    this.maxCapacity = 30;
    if (GameDataController.gd.getObjectiveDetail("day1_complete") == 1)
      this.maxCapacity += 5;
    if (GameDataController.gd.getObjectiveDetail("day2_complete") == 1)
      this.maxCapacity += 5;
    if (GameDataController.gd.getObjectiveDetail("day3_complete") == 1)
      this.maxCapacity += 5;
    this.inventoryButton = GameObject.Find("inventory_button");
    this.invItems = new InventoryItemController[4, 5];
    this.trunkItems = new InventoryItemController[4, 3];
    this.chestItems = new InventoryItemController[5, 7];
    this.aS = InventoryButtonController.ibc.gameObject.GetComponent<AudioSource>();
    for (int index1 = 1; index1 <= 4; ++index1)
    {
      for (int index2 = 1; index2 <= 5; ++index2)
        this.invItems[index1 - 1, index2 - 1] = this.gameObject.transform.Find("inventory_item_" + index1.ToString() + index2.ToString()).gameObject.GetComponent<InventoryItemController>();
    }
    this.trunk = this.gameObject.transform.Find("TrunkInventory").gameObject;
    for (int index3 = 1; index3 <= 4; ++index3)
    {
      for (int index4 = 1; index4 <= 3; ++index4)
        this.trunkItems[index3 - 1, index4 - 1] = this.trunk.transform.Find("inventory_trunk_item_" + (index3 + 4).ToString() + index4.ToString()).gameObject.GetComponent<InventoryItemController>();
    }
    this.chest = this.gameObject.transform.Find("ChestInventory").gameObject;
    for (int index5 = 1; index5 <= 5; ++index5)
    {
      for (int index6 = 1; index6 <= 7; ++index6)
        this.chestItems[index5 - 1, index6 - 1] = this.chest.transform.Find("inventory_chest_item_" + index5.ToString() + index6.ToString()).gameObject.GetComponent<InventoryItemController>();
    }
    this.blocker = this.gameObject.GetComponent<PolygonCollider2D>();
    this.InvTrunkClose = GameObject.Find("InvTrunkClose").GetComponent<Button>();
    this.InvTrunkClose.initButton(" ");
    this.InvTrunkClose.onClick = new Button.Delegate(this.CloseTrunkButtonClicked);
    this.InvTrunkClose.workIfBusy = false;
    this.InvChestClose = GameObject.Find("InvChestClose").GetComponent<Button>();
    this.InvChestClose.initButton(" ");
    this.InvChestClose.onClick = new Button.Delegate(this.CloseChestButtonClicked);
    this.InvChestClose.workIfBusy = false;
    this.inventoryCloseButtonTextfield = this.InvTrunkClose.GetComponent<TextFieldController>();
    this.inventoryCloseButtonTextfield.transform.parent = this.gameObject.transform;
    this.inventoryCloseButtonTextfield.container.transform.parent = this.gameObject.transform;
    this.inventoryCloseButtonTextfield2 = this.InvChestClose.GetComponent<TextFieldController>();
    this.inventoryCloseButtonTextfield2.transform.parent = this.gameObject.transform;
    this.inventoryCloseButtonTextfield2.container.transform.parent = this.gameObject.transform;
  }

  public void cleanUp()
  {
    for (int index1 = 4; index1 >= 1; --index1)
    {
      for (int index2 = 1; index2 <= 5; ++index2)
        this.invItems[index1 - 1, index2 - 1].znik();
    }
    for (int index3 = 4; index3 >= 1; --index3)
    {
      for (int index4 = 1; index4 <= 3; ++index4)
        this.trunkItems[index3 - 1, index4 - 1].znik();
    }
    for (int index5 = 5; index5 >= 1; --index5)
    {
      for (int index6 = 1; index6 <= 7; ++index6)
        this.chestItems[index5 - 1, index6 - 1].znik();
    }
    CursorController.cc.showCursor(CursorController.PixelCursor.NORMAL);
    GameObject.Find("BottomText").GetComponent<TextFieldController>().keepAlive = false;
  }

  private void CloseTrunkButtonClicked()
  {
    PlayerController.pc.clickedSomething = true;
    InventoryButtonController.ibc.close();
  }

  private void CloseChestButtonClicked()
  {
    PlayerController.pc.clickedSomething = true;
    InventoryButtonController.ibc.close();
  }

  private void Update()
  {
  }

  private void OnMouseEnter()
  {
    if (ExamineSprite.es.Active || this.inventoryButton.GetComponent<InventoryButtonController>().spaceWasPressed)
      return;
    this.inventoryButton.GetComponent<InventoryButtonController>().close();
  }

  private void OnMouseExit() => this.inventoryButton.GetComponent<InventoryButtonController>().spaceWasPressed = false;

  public void loadItem(Item item)
  {
    MonoBehaviour.print((object) ("LOADING ITEM: " + item.id));
    Transform transform = this.gameObject.transform.Find("inventory_item_" + item.dataRef.locX.ToString() + item.dataRef.locY.ToString());
    if (item.dataRef.droppedLocation == "chest")
      this.loadChestItem(item);
    else if ((Object) transform != (Object) null)
      transform.gameObject.GetComponent<InventoryItemController>().loadItem(item);
    else
      this.loadTrunkItem(item);
  }

  public void loadChestItem(Item item) => this.chest.transform.Find("inventory_chest_item_" + item.dataRef.locX.ToString() + item.dataRef.locY.ToString()).gameObject.GetComponent<InventoryItemController>().loadItem(item);

  public void loadTrunkItem(Item item) => this.trunk.transform.Find("inventory_trunk_item_" + item.dataRef.locX.ToString() + item.dataRef.locY.ToString()).gameObject.GetComponent<InventoryItemController>().loadItem(item);

  public InventoryItemController findFreeSpot()
  {
    InventoryItemController inventoryItemController = (InventoryItemController) null;
    for (int index1 = 4; index1 >= 1; --index1)
    {
      for (int index2 = 1; index2 <= 5; ++index2)
      {
        if (this.invItems[index1 - 1, index2 - 1].getName().Length == 0)
        {
          inventoryItemController = this.invItems[index1 - 1, index2 - 1];
          break;
        }
      }
    }
    return inventoryItemController;
  }

  public InventoryItemController findFreeSpotInTrunk()
  {
    InventoryItemController inventoryItemController = (InventoryItemController) null;
    for (int index1 = 4; index1 >= 1; --index1)
    {
      for (int index2 = 1; index2 <= 3; ++index2)
      {
        if (this.trunkItems[index1 - 1, index2 - 1].getName().Length == 0)
        {
          inventoryItemController = this.trunkItems[index1 - 1, index2 - 1];
          break;
        }
      }
    }
    return inventoryItemController;
  }

  public InventoryItemController findFreeSpotInChest()
  {
    InventoryItemController inventoryItemController = (InventoryItemController) null;
    for (int index1 = 5; index1 >= 1; --index1)
    {
      for (int index2 = 1; index2 <= 7; ++index2)
      {
        if (this.chestItems[index1 - 1, index2 - 1].getName().Length == 0)
        {
          inventoryItemController = this.chestItems[index1 - 1, index2 - 1];
          break;
        }
      }
    }
    return inventoryItemController;
  }

  public bool putItemInTrunk(string itemName, bool quiet = false)
  {
    InventoryItemController freeSpotInTrunk = this.findFreeSpotInTrunk();
    if ((Object) freeSpotInTrunk == (Object) null)
    {
      if (!quiet)
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.gui, "trunk_full"), true);
      return false;
    }
    InventoryController.ic.removeItem(itemName);
    Item obj = ItemsManager.im.getItem(itemName);
    ItemsManager.im.updateItem(obj.id, "trunk", freeSpotInTrunk.lx, freeSpotInTrunk.ly);
    this.loadTrunkItem(obj);
    PlayerController.pc.aS.PlayOneShot(obj.sound);
    return true;
  }

  public bool putItemInChest(string itemName, bool quiet = false)
  {
    InventoryItemController freeSpotInChest = this.findFreeSpotInChest();
    if ((Object) freeSpotInChest == (Object) null)
    {
      if (!quiet)
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.gui, "chest_full"), true);
      return false;
    }
    InventoryController.ic.removeItem(itemName);
    Item obj = ItemsManager.im.getItem(itemName);
    ItemsManager.im.updateItem(obj.id, "chest", freeSpotInChest.lx, freeSpotInChest.ly);
    this.loadChestItem(obj);
    PlayerController.pc.aS.PlayOneShot(obj.sound);
    return true;
  }

  public float getCurrentWeight()
  {
    float num = 0.0f;
    for (int index1 = 4; index1 >= 1; --index1)
    {
      for (int index2 = 1; index2 <= 5; ++index2)
      {
        if (this.invItems[index1 - 1, index2 - 1].getName().Length > 0)
          num += this.invItems[index1 - 1, index2 - 1].getWeight();
      }
    }
    return num;
  }

  public void removeItem(string name)
  {
    for (int index1 = 1; index1 <= 4; ++index1)
    {
      for (int index2 = 1; index2 <= 5; ++index2)
      {
        if (this.invItems[index1 - 1, index2 - 1].getName().Equals(name))
        {
          this.invItems[index1 - 1, index2 - 1].removeItem();
          break;
        }
      }
    }
    for (int index3 = 1; index3 <= 4; ++index3)
    {
      for (int index4 = 1; index4 <= 3; ++index4)
      {
        if (this.trunkItems[index3 - 1, index4 - 1].getName().Equals(name))
        {
          this.trunkItems[index3 - 1, index4 - 1].removeItem();
          break;
        }
      }
    }
    for (int index5 = 1; index5 <= 5; ++index5)
    {
      for (int index6 = 1; index6 <= 7; ++index6)
      {
        if (this.chestItems[index5 - 1, index6 - 1].getName().Equals(name))
        {
          this.chestItems[index5 - 1, index6 - 1].removeItem();
          break;
        }
      }
    }
  }

  public void clearInventory()
  {
    for (int index1 = 1; index1 <= 4; ++index1)
    {
      for (int index2 = 1; index2 <= 5; ++index2)
        this.invItems[index1 - 1, index2 - 1].removeItem();
    }
    for (int index3 = 1; index3 <= 4; ++index3)
    {
      for (int index4 = 1; index4 <= 3; ++index4)
        this.trunkItems[index3 - 1, index4 - 1].removeItem();
    }
    for (int index5 = 1; index5 <= 5; ++index5)
    {
      for (int index6 = 1; index6 <= 7; ++index6)
        this.chestItems[index5 - 1, index6 - 1].removeItem();
    }
  }

  public static string getRoundedWeightLeft() => (Mathf.Round((float) ((double) InventoryController.ic.maxCapacity * 10.0 - 10.0 * (double) InventoryController.ic.getCurrentWeight())) / 10f).ToString() + string.Empty;

  public bool pickUpItem(Item itemRef, bool silent = false)
  {
    InventoryItemController freeSpot = InventoryController.ic.findFreeSpot();
    if ((Object) freeSpot == (Object) null)
    {
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.gui, "inventory_full"), true);
      return false;
    }
    if ((double) InventoryController.ic.getCurrentWeight() + (double) itemRef.weight > (double) InventoryController.ic.maxCapacity)
    {
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.gui, "capacity_full"), true);
      GameObject.Find("BottomText").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "capacity_1") + " " + (object) itemRef.weight + " " + GameStrings.getString(GameStrings.gui, "kg") + " " + GameStrings.getString(GameStrings.gui, "capacity_2") + " " + InventoryController.getRoundedWeightLeft() + " " + GameStrings.getString(GameStrings.gui, "kg") + " " + GameStrings.getString(GameStrings.gui, "capacity_3"), quick: true, mwidth: BottomTextController.bottomTextWidth, b: 0.0f);
      return false;
    }
    MonoBehaviour.print((object) "im.updateItem");
    ItemsManager.im.updateItem(itemRef.id, "inventory", freeSpot.lx, freeSpot.ly);
    MonoBehaviour.print((object) "ic.loadItem");
    InventoryController.ic.loadItem(itemRef);
    if (!silent)
      PlayerController.pc.aS.PlayOneShot(itemRef.sound);
    return true;
  }

  public void dropItem(Item itemRef, bool remov = false, bool bow = false)
  {
    if (bow)
      PlayerController.wc.forceAnimation("kneel_s");
    if (remov)
      InventoryController.ic.removeItem(itemRef.dataRef.id);
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(PlayerController.wc.currentXY.x, PlayerController.wc.currentXY.y + (float) GroundItemController.yOffset));
    Vector3 vector3 = new Vector3(screen.x, screen.y, 0.0f);
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint((Vector3) screen);
    (Object.Instantiate(Resources.Load("Prefabs/GroundItem"), worldPoint, new Quaternion()) as GameObject).GetComponent<GroundItemController>().init(ItemsManager.im.getItem(itemRef.id));
    ItemsManager.im.updateItem(itemRef.id, SceneManager.GetActiveScene().name, (int) PlayerController.wc.currentXY.x, (int) PlayerController.wc.currentXY.y);
  }

  public bool pickOrDropItem(Item itemRef, bool silent = false)
  {
    if (this.pickUpItem(itemRef, silent))
      return true;
    this.dropItem(itemRef);
    return false;
  }

  public bool isItemEquipped(string item) => ItemsManager.im.getItem(item).dataRef.droppedLocation.ToLower().IndexOf("inventory") != -1 && GameDataController.gd.equipped == item;

  public bool isUnequipped(string item) => this.isItemInInventory(item) && !this.isItemEquipped(item);

  public bool isItemInInventory(string item) => ItemsManager.im.getItem(item).dataRef.droppedLocation.ToLower().IndexOf("inventory") != -1;

  public bool isItemInInventoryOrTrunkOrWhatever(string item) => ItemsManager.im.getItem(item).dataRef.droppedLocation.ToLower().IndexOf("inventory") != -1 || ItemsManager.im.getItem(item).dataRef.droppedLocation.ToLower().IndexOf("trunk") != -1 || ItemsManager.im.getItem(item).dataRef.droppedLocation.ToLower().IndexOf("chest") != -1;
}
