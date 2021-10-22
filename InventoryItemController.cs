// Decompiled with JetBrains decompiler
// Type: InventoryItemController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
  private GameObject itemIcon;
  private float weight;
  private string itemName = string.Empty;
  private GameObject cursor;
  private CursorController cursorController;
  private SpriteRenderer spriteRenderer;
  private SpriteRenderer iconSpriteRenderer;
  private TextFieldController textfield;
  private WalkController walkController;
  private PlayerController playerController;
  private InventoryController invetoryController;
  public int lx;
  public int ly;
  public int shiftX;
  public int shiftY;
  private ItemsManager itemsManager;
  private Item itemRef;
  private float hover;
  private float displayHover;
  private string item;

  private void Start()
  {
    Vector2 screen = ScreenControler.gameToScreen(new Vector2()
    {
      x = (float) (this.ly * 18 - 5 + this.shiftX),
      y = (float) (111 - this.lx * 18 - this.shiftY)
    });
    this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, -0.01f));
    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, GameObject.Find("inventory").transform.position.z - 0.01f);
  }

  private void Awake()
  {
    this.cursor = GameObject.Find("cursor");
    this.cursorController = this.cursor.GetComponent<CursorController>();
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    this.itemIcon = this.gameObject.transform.Find("item_icon").gameObject;
    this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    this.iconSpriteRenderer = this.itemIcon.GetComponent<SpriteRenderer>();
    this.iconSpriteRenderer.color = new Color(1f, 1f, 1f, 0.0f);
    this.spriteRenderer.color = new Color(1f, 1f, 1f, 0.0f);
    this.playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    this.walkController = GameObject.FindGameObjectWithTag("Player").GetComponent<WalkController>();
    this.hover = 0.0f;
    this.displayHover = 0.0f;
    this.invetoryController = GameObject.Find("inventory").GetComponent<InventoryController>();
    this.itemsManager = GameObject.Find("ItemsManager").GetComponent<ItemsManager>();
    this.textfield = GameObject.Find("BottomText").GetComponent<TextFieldController>();
  }

  private void Update()
  {
    string selectedItemName = this.cursorController.selectedItemName;
    this.spriteRenderer.color = selectedItemName.Length <= 0 || !selectedItemName.Equals(this.itemName) ? new Color(1f, 1f, 1f, this.displayHover) : new Color(1f, 1f, 1f, 1f);
    float num = 2f;
    if ((double) this.hover > (double) this.displayHover)
      this.displayHover += num * Time.deltaTime;
    if ((double) this.hover < (double) this.displayHover)
      this.displayHover -= num * Time.deltaTime;
    if ((double) this.displayHover < 0.0)
      this.displayHover = 0.0f;
    if ((double) this.displayHover > 1.0)
      this.displayHover = 1f;
    if (((double) Input.mouseScrollDelta.y > 0.0 | (double) Input.mouseScrollDelta.y < 0.0) & GameObject.Find("BottomText").GetComponent<TextFieldController>().keepAlive & this.item.Length > 0)
    {
      if (CursorController.cc.selectedItemName != "")
        return;
      string str = this.item;
      if (InventoryController.ic.trunk.activeSelf)
      {
        if (ItemsManager.im.getItem(str).dataRef.droppedLocation == "inventory")
        {
          if ((double) Input.mouseScrollDelta.y > 0.0)
            InventoryController.ic.putItemInTrunk(str);
          else if ((double) Input.mouseScrollDelta.y < 0.0)
            InventoryController.ic.putItemInChest(str);
          this.MakeCellInactive();
        }
        else if (ItemsManager.im.getItem(str).dataRef.droppedLocation == "trunk")
        {
          if ((double) Input.mouseScrollDelta.y > 0.0)
            this.putItemInInventory(str);
          else if ((double) Input.mouseScrollDelta.y < 0.0)
          {
            InventoryController.ic.putItemInChest(str);
            this.MakeCellInactive();
          }
        }
      }
      else if (InventoryController.ic.chest.activeSelf)
      {
        if (ItemsManager.im.getItem(str).dataRef.droppedLocation == "inventory")
        {
          if ((double) Input.mouseScrollDelta.y > 0.0)
            InventoryController.ic.putItemInChest(str);
          else if ((double) Input.mouseScrollDelta.y < 0.0)
            InventoryController.ic.putItemInTrunk(str);
          this.MakeCellInactive();
        }
        else if (ItemsManager.im.getItem(str).dataRef.droppedLocation == "chest")
        {
          if ((double) Input.mouseScrollDelta.y > 0.0)
            this.putItemInInventory(str);
          else if ((double) Input.mouseScrollDelta.y < 0.0)
          {
            InventoryController.ic.putItemInTrunk(str);
            this.MakeCellInactive();
          }
        }
      }
      else
      {
        if ((double) Input.mouseScrollDelta.y > 0.0)
          InventoryController.ic.putItemInChest(str);
        else if ((double) Input.mouseScrollDelta.y < 0.0)
          InventoryController.ic.putItemInTrunk(str);
        this.MakeCellInactive();
      }
    }
    if (!(Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Semicolon)) || !(this.cursorController.selectedItemName.Equals(string.Empty) & this.item.Length > 0 & GameObject.Find("BottomText").GetComponent<TextFieldController>().keepAlive))
      return;
    string name = this.item;
    if (!(ItemsManager.im.getItem(name).dataRef.droppedLocation == "inventory") && !(ItemsManager.im.getItem(name).dataRef.droppedLocation == "chest") && !(ItemsManager.im.getItem(name).dataRef.droppedLocation == "trunk"))
      return;
    InventoryController.ic.dropItemExtended(ItemsManager.im.getItem(name), ItemsManager.im.getItem(name).dataRef.droppedLocation);
    this.MakeCellInactive();
  }

  private void OnEnable()
  {
  }

  private void OnMouseEnter()
  {
    if ((Object) this.textfield == (Object) null)
      this.textfield = GameObject.Find("BottomText").GetComponent<TextFieldController>();
    if (this.itemName.Length <= 0 || PlayerController.wc.busy || !((Object) this.textfield != (Object) null))
      return;
    string empty = string.Empty;
    string text;
    if (this.cursorController.selectedItemName.Equals(string.Empty) || this.itemName.Equals(this.cursorController.selectedItemName))
    {
      this.item = this.itemName;
      text = GameStrings.getPrefixedShort(GameStrings.items, this.itemName, true) + " (" + (object) this.weight + " " + GameStrings.getString(GameStrings.gui, "kg") + ")";
      if (this.itemRef != null && (Object) this.itemRef.examineSprite != (Object) null)
        text = text + " ^[" + GameStrings.getString(GameStrings.gui, "right_click_to_view") + "]";
      if (this.itemName == "bear_trap_1" || this.itemName == "bear_trap_2" || this.itemName == "sonic" || this.itemName == "bear_trap_3" || this.itemName == "bear_trap_4" || this.itemName == "gasheater" || this.itemName == "heat_absorber1A" || this.itemName == "heat_absorber2A" || this.itemName == "heat_absorber3A")
        text = text + " ^[" + GameStrings.getString(GameStrings.gui, "drop_to_setup") + "]";
    }
    else
      text = GameStrings.getString(GameStrings.gui, "use1") + " " + GameStrings.getString(GameStrings.items, this.cursorController.selectedItemName + "_short") + " " + GameStrings.getString(GameStrings.gui, "use2") + " " + GameStrings.getPrefixedShort(GameStrings.items, this.itemName) + ".";
    this.textfield.viewText(text, quick: true, mwidth: ObjectActionController.BOTTOM_TEXT_WIDTH);
  }

  private void OnMouseExit()
  {
    this.cursorController.showCursor(CursorController.PixelCursor.NORMAL);
    this.textfield.keepAlive = false;
    this.hover = 0.0f;
    this.item = "";
  }

  public void loadItem(Item item)
  {
    this.itemRef = item;
    this.itemName = item.id;
    this.weight = item.weight;
    if ((Object) this.itemIcon == (Object) null)
      this.itemIcon = this.gameObject.transform.Find("item_icon").gameObject;
    if ((Object) this.iconSpriteRenderer == (Object) null)
      this.iconSpriteRenderer = this.itemIcon.GetComponent<SpriteRenderer>();
    this.iconSpriteRenderer.sprite = item.inventorySprite;
    this.iconSpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
  }

  public void removeItem()
  {
    if (this.itemRef != null && this.itemRef.dataRef != null)
      this.itemRef.dataRef.droppedLocation = "nowhere";
    this.itemName = string.Empty;
    this.weight = 0.0f;
    this.itemRef = (Item) null;
    this.itemIcon.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.0f);
  }

  private void OnMouseDown()
  {
    if (this.walkController.busy)
      return;
    this.playerController.clickedSomething = true;
    if (this.cursorController.selectedItemName.Length > 0)
    {
      if (this.itemRef != null && !this.itemName.Equals(this.cursorController.selectedItemName))
      {
        bool flag = false;
        if (this.itemRef.usableItemsInventory != null && this.itemRef.usableItemsInventory.Count > 0)
        {
          for (int index = 0; index < this.itemRef.usableItemsInventory.Count; ++index)
          {
            if (this.itemRef.usableItemsInventory[index].name == this.cursorController.selectedItemName)
            {
              flag = true;
              if (this.itemRef.usableItemsInventory[index].failText != string.Empty)
                PlayerController.pc.textField.viewText(this.itemRef.usableItemsInventory[index].failText, true);
              else if (this.itemRef.usableItemsInventory[index].action != null)
              {
                this.itemRef.usableItemsInventory[index].action();
                InventoryCapMeterController.cm.updateText();
                if (this.itemRef != null)
                  this.OnMouseEnter();
                else
                  break;
              }
            }
            if (this.itemRef == null || this.itemRef != null && this.itemRef.usableItemsInventory == null)
              break;
          }
        }
        if (flag)
          return;
        PlayerController.pc.textField.viewText(GameStrings.getWrongInteractionText(), true);
      }
      else if (this.itemName.Equals(this.cursorController.selectedItemName))
      {
        this.cursorController.deselectItem();
      }
      else
      {
        bool flag = true;
        if (this.lx < 5 && this.cursorController.selectedItemRef.dataRef.droppedLocation == "trunk" && (double) InventoryController.ic.getCurrentWeight() + (double) this.cursorController.selectedItemRef.weight > (double) InventoryController.ic.maxCapacity)
        {
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.gui, "capacity_full"), true);
          GameObject.Find("BottomText").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "capacity_1") + " " + (object) this.cursorController.selectedItemRef.weight + " " + GameStrings.getString(GameStrings.gui, "kg") + " " + GameStrings.getString(GameStrings.gui, "capacity_2") + " " + InventoryController.getRoundedWeightLeft() + " " + GameStrings.getString(GameStrings.gui, "kg") + " " + GameStrings.getString(GameStrings.gui, "capacity_3"), quick: true, mwidth: BottomTextController.bottomTextWidth, b: 0.0f);
          flag = false;
        }
        if (this.gameObject.name.ToLower().IndexOf("chest") == -1 && this.cursorController.selectedItemRef.dataRef.droppedLocation == "chest" && (double) InventoryController.ic.getCurrentWeight() + (double) this.cursorController.selectedItemRef.weight > (double) InventoryController.ic.maxCapacity)
        {
          PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.gui, "capacity_full"), true);
          GameObject.Find("BottomText").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "capacity_1") + " " + (object) this.cursorController.selectedItemRef.weight + " " + GameStrings.getString(GameStrings.gui, "kg") + " " + GameStrings.getString(GameStrings.gui, "capacity_2") + " " + InventoryController.getRoundedWeightLeft() + " " + GameStrings.getString(GameStrings.gui, "kg") + " " + GameStrings.getString(GameStrings.gui, "capacity_3"), quick: true, mwidth: BottomTextController.bottomTextWidth, b: 0.0f);
          flag = false;
        }
        if (!flag)
          return;
        this.invetoryController.removeItem(this.cursorController.selectedItemName);
        this.loadItem(this.cursorController.selectedItemRef);
        if (this.gameObject.name.ToLower().IndexOf("chest") != -1)
          this.itemsManager.updateItem(this.cursorController.selectedItemName, "chest", this.lx, this.ly);
        else if (this.lx >= 5)
          this.itemsManager.updateItem(this.cursorController.selectedItemName, "trunk", this.lx, this.ly);
        else
          this.itemsManager.updateItem(this.cursorController.selectedItemName, "inventory", this.lx, this.ly);
        this.cursorController.deselectItem();
        this.OnMouseEnter();
        InventoryCapMeterController.cm.updateText();
      }
    }
    else
    {
      if (this.itemName.Length <= 0)
        return;
      InventoryController.ic.aS.PlayOneShot(this.itemRef.sound);
      if (this.cursorController.selectedItemName.Equals(this.itemName))
        this.cursorController.deselectItem();
      else
        this.cursorController.selectItem(this.itemRef);
    }
  }

  public void examineItem() => ItemsManager.exmineItem(this.itemRef);

  private void OnMouseOver()
  {
    if (this.itemRef != null && !PlayerController.wc.busy)
    {
      if (Input.GetMouseButtonDown(1))
      {
        if ((Object) this.textfield == (Object) null)
          this.textfield = GameObject.Find("BottomText").GetComponent<TextFieldController>();
        if ((Object) this.itemRef.examineSprite != (Object) null)
          this.examineItem();
        else
          this.textfield.viewText(GameStrings.getString(GameStrings.items, this.itemName + "_long"), quick: true, mwidth: ObjectActionController.BOTTOM_TEXT_WIDTH);
      }
      if (this.itemName.Length <= 0)
        return;
      this.cursorController.showCursor(CursorController.PixelCursor.INSPECT);
      this.hover = 0.5f;
    }
    else
    {
      if (CursorController.cc.selectedItemRef == null)
        return;
      this.hover = 0.25f;
    }
  }

  public string getName() => this.itemName;

  public float getWeight() => this.weight;

  public void znik()
  {
    this.hover = 0.0f;
    this.displayHover = 0.0f;
  }

  private void MakeCellInactive()
  {
    this.znik();
    GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>().showCursor(CursorController.PixelCursor.NORMAL);
    GameObject.Find("BottomText").GetComponent<TextFieldController>().keepAlive = false;
  }

  private void putItemInInventory(string text)
  {
    if ((Object) InventoryController.ic.findFreeSpot() != (Object) null & (double) InventoryController.ic.getCurrentWeight() + (double) this.itemRef.weight < (double) InventoryController.ic.maxCapacity)
    {
      InventoryController.ic.removeItem(this.itemName);
      InventoryController.ic.pickUpItem(ItemsManager.im.getItem(text));
      this.MakeCellInactive();
    }
    else
      PlayerController.pc.textField.viewText("Sorry but the backpack is either full or too heavy.", true);
  }
}
