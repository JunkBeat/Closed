// Decompiled with JetBrains decompiler
// Type: GroundItemController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class GroundItemController : ObjectActionController
{
  public Item itemRef;
  private SpriteRenderer spriteRenderer;
  private int delay;
  private int frame;
  public SpriteRenderer frontView;
  public static int xOffset;
  public static int yOffset = -1;
  public bool canPickUp = true;
  private GameObject inventory;

  private void Awake()
  {
    this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    this.interactions = new List<ItemInteraction>();
  }

  public void init(Item item)
  {
    this.itemRef = item;
    this.spriteRenderer.sprite = this.itemRef.groundSprite;
    this.frontView = this.gameObject.transform.Find("FrontView").GetComponent<SpriteRenderer>();
    this.frontView.sprite = this.itemRef.groundSprite;
    this.frontView.color = new Color(0.0f, 1f, 0.0f, 1f);
    this.frontView.enabled = false;
    this.dkvs = GameStrings.items;
    this.objectName = item.id;
    this.delay = 0;
    this.frame = 0;
    this.allowAllItems = false;
    if (item.usableItemsGround != null)
      this.interactions = item.usableItemsGround;
    if (item.usableItemsGround == null && item.usableItemsInventory != null)
      this.allowAllItems = true;
    Sprite sprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
    BoxCollider2D component = this.gameObject.GetComponent<BoxCollider2D>();
    Vector2 size = (Vector2) this.gameObject.GetComponent<SpriteRenderer>().bounds.size;
    component.size = size;
    MonoBehaviour.print((object) this.itemRef);
    component.offset = new Vector2((float) (-(double) size.x * (0.5 - (double) sprite.pivot.x / (double) sprite.rect.width)), (float) ((double) size.y / 2.0 - (double) size.y * ((double) sprite.pivot.y / (double) sprite.rect.height)));
    if ((Object) this.itemRef.soundLoop != (Object) null)
    {
      if ((Object) this.gameObject.GetComponent<AudioSource>() == (Object) null)
        this.gameObject.AddComponent<AudioSource>();
      this.gameObject.GetComponent<AudioSource>().clip = this.itemRef.soundLoop;
      this.gameObject.GetComponent<AudioSource>().loop = true;
      this.gameObject.GetComponent<AudioSource>().Play();
    }
    Vector3 vector3 = new Vector3(0.0f, -0.0092592f * (float) GroundItemController.yOffset, 0.0f);
    this.transform.Find("Action_Marker").transform.localPosition = vector3;
    if (this.canPickUp)
      return;
    this.disablePickup();
  }

  private void Update()
  {
    if (this.itemRef.animationDelay <= 0)
      return;
    ++this.delay;
    if (this.delay < this.itemRef.animationDelay)
      return;
    this.delay = 0;
    ++this.frame;
    if ((Object) this.itemRef.groundSprite_1 != (Object) null && this.frame == 1)
      this.spriteRenderer.sprite = this.itemRef.groundSprite_1;
    else if ((Object) this.itemRef.groundSprite_2 != (Object) null && this.frame == 2)
      this.spriteRenderer.sprite = this.itemRef.groundSprite_2;
    else if ((Object) this.itemRef.groundSprite_3 != (Object) null && this.frame == 3)
      this.spriteRenderer.sprite = this.itemRef.groundSprite_3;
    else if ((Object) this.itemRef.groundSprite_4 != (Object) null && this.frame == 4)
      this.spriteRenderer.sprite = this.itemRef.groundSprite_4;
    else if ((Object) this.itemRef.groundSprite_5 != (Object) null && this.frame == 5)
    {
      this.spriteRenderer.sprite = this.itemRef.groundSprite_5;
    }
    else
    {
      this.spriteRenderer.sprite = this.itemRef.groundSprite;
      this.frame = 0;
    }
  }

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "kneel_";
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
  }

  public void disablePickup()
  {
    this.canPickUp = false;
    BoxCollider2D component1 = this.gameObject.GetComponent<BoxCollider2D>();
    if ((bool) (Object) component1)
      component1.enabled = false;
    PolygonCollider2D component2 = this.gameObject.GetComponent<PolygonCollider2D>();
    if (!(bool) (Object) component2)
      return;
    component2.enabled = false;
  }

  public void enablePickup()
  {
    this.canPickUp = true;
    BoxCollider2D component1 = this.gameObject.GetComponent<BoxCollider2D>();
    if ((bool) (Object) component1)
      component1.enabled = true;
    PolygonCollider2D component2 = this.gameObject.GetComponent<PolygonCollider2D>();
    if (!(bool) (Object) component2)
      return;
    component2.enabled = true;
  }

  public override void whatOnClick()
  {
    if (this.usedItem == string.Empty)
    {
      this.animationFlip = false;
      this.characterAnimationName = "kneel_";
      this.useCurrentDirection = true;
      this.range = 2f;
    }
    else if (this.allowAllItems)
    {
      this.range = 200f;
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
    else
    {
      this.range = (float) this.usedItemInteraction.range;
      if ((double) this.range < 2.0)
        this.range = 2f;
      this.animationFlip = false;
      this.characterAnimationName = this.usedItemInteraction.animation;
      this.useCurrentDirection = false;
    }
    PlayerController.wc.range = (int) this.range;
  }

  public override void clickAction()
  {
    if (this.usedItem != string.Empty)
    {
      if (this.allowAllItems)
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "generic_pick_it_up"));
      }
      else
      {
        if (this.interactions[0].action == null)
          return;
        this.interactions[0].action();
      }
    }
    else if (this.itemRef.id == "bear_trap_1b" || this.itemRef.id == "bear_trap_2b")
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "bear_trap_b"));
    }
    else
    {
      InventoryItemController freeSpot = InventoryController.ic.findFreeSpot();
      if ((Object) freeSpot == (Object) null)
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.gui, "inventory_full"), true);
      else if ((double) InventoryController.ic.getCurrentWeight() + (double) this.itemRef.weight > (double) InventoryController.ic.maxCapacity)
      {
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.gui, "capacity_full"), true);
        GameObject.Find("BottomText").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "capacity_1") + " " + (object) this.itemRef.weight + " " + GameStrings.getString(GameStrings.gui, "kg") + ", " + GameStrings.getString(GameStrings.gui, "capacity_2") + " " + InventoryController.getRoundedWeightLeft() + " " + GameStrings.getString(GameStrings.gui, "kg") + GameStrings.getString(GameStrings.gui, "capacity_3"), quick: true, mwidth: BottomTextController.bottomTextWidth, b: 0.0f);
      }
      else
      {
        MonoBehaviour.print((object) "im.updateItem");
        ItemsManager.im.updateItem(this.itemRef.id, "inventory", freeSpot.lx, freeSpot.ly);
        MonoBehaviour.print((object) "ic.loadItem");
        InventoryController.ic.loadItem(this.itemRef);
        MonoBehaviour.print((object) ("Destroy " + (object) this.gameObject));
        Object.Destroy((Object) this.gameObject);
        PlayerController.pc.aS.PlayOneShot(this.itemRef.sound);
      }
    }
  }

  public override void clickAction2()
  {
  }

  public override void updateState()
  {
  }

  public override void clickAction0()
  {
  }
}
