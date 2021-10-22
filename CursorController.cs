// Decompiled with JetBrains decompiler
// Type: CursorController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class CursorController : MonoBehaviour
{
  public static CursorController cc;
  private SpriteRenderer spriteRenderer;
  private CursorController.PixelCursor currentState;
  private CursorController.PixelCursor overrideState;
  private int decay;
  private GameObject selectedItem;
  public string selectedItemName;
  public Item selectedItemRef;
  public WalkController.Direction trans_dir = WalkController.Direction.S;

  private void Awake()
  {
    if ((Object) CursorController.cc == (Object) null)
    {
      Object.DontDestroyOnLoad((Object) this.gameObject);
      CursorController.cc = this;
    }
    else
    {
      if (!((Object) CursorController.cc != (Object) this))
        return;
      Object.Destroy((Object) this.gameObject);
    }
  }

  private void Start()
  {
    this.selectedItem = this.gameObject.transform.Find("item_icon").gameObject;
    this.gameObject.transform.position = new Vector3(0.0f, 0.0f, -9f);
    this.spriteRenderer = this.selectedItem.GetComponent<SpriteRenderer>();
    Vector2 screen1 = ScreenControler.gameToScreen(new Vector2(8f, -8f));
    Vector3 worldPoint1 = Camera.main.ScreenToWorldPoint(new Vector3(screen1.x, screen1.y, 0.0f));
    Vector2 screen2 = ScreenControler.gameToScreen(new Vector2(0.0f, 0.0f));
    Vector3 worldPoint2 = Camera.main.ScreenToWorldPoint(new Vector3(screen2.x, screen2.y, 0.0f));
    worldPoint1.x -= worldPoint2.x;
    worldPoint1.y -= worldPoint2.y;
    worldPoint1.z = this.selectedItem.transform.position.z;
    this.selectedItem.transform.position = worldPoint1;
    this.deselectItem();
    this.showCursor(CursorController.PixelCursor.NORMAL);
  }

  private void Update()
  {
    Vector2 screen = ScreenControler.gameToScreen(ScreenControler.screenToGame((Vector2) Input.mousePosition));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, -0.0f));
    this.gameObject.transform.position = new Vector3(worldPoint.x, worldPoint.y, -9f);
    Cursor.visible = false;
    string stateName = string.Empty;
    if (this.currentState == CursorController.PixelCursor.NORMAL)
      stateName = "cursor_normal";
    if (this.currentState == CursorController.PixelCursor.ACTIVE)
      stateName = "cursor_special1";
    if (this.currentState == CursorController.PixelCursor.TALK)
      stateName = "cursor_talk";
    if (this.currentState == CursorController.PixelCursor.INSPECT)
      stateName = !Input.GetMouseButton(1) ? "cursor_special1" : "cursor_inspect";
    if (this.currentState == CursorController.PixelCursor.TRANSITION)
      stateName = "cursor_transition_" + this.trans_dir.ToString().ToLower();
    if (this.overrideState == CursorController.PixelCursor.BUSY)
      stateName = "cursor_special2";
    if (PlayerController.wc.busy && !QuestionController.questionAsked && DialogueController.dc.hidden)
      stateName = "cursor_wait";
    if (this.overrideState == CursorController.PixelCursor.OK)
      stateName = "cursor_ok";
    this.gameObject.GetComponent<Animator>().Play(stateName, 0);
  }

  public void selectItem(Item it)
  {
    this.selectedItemRef = it;
    this.spriteRenderer.sprite = it.inventorySprite;
    this.spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    this.selectedItemName = it.id;
  }

  public void deselectItem()
  {
    if ((Object) this.spriteRenderer != (Object) null)
      this.spriteRenderer.color = new Color(1f, 1f, 1f, 0.0f);
    this.selectedItemRef = (Item) null;
    this.selectedItemName = string.Empty;
  }

  public void showCursor(CursorController.PixelCursor a, WalkController.Direction newDir = WalkController.Direction.S)
  {
    this.trans_dir = newDir;
    switch (a)
    {
      case CursorController.PixelCursor.NORMAL:
        this.currentState = CursorController.PixelCursor.NORMAL;
        break;
      case CursorController.PixelCursor.ACTIVE:
        this.currentState = CursorController.PixelCursor.ACTIVE;
        break;
      case CursorController.PixelCursor.BUSY:
        this.overrideState = CursorController.PixelCursor.BUSY;
        break;
      case CursorController.PixelCursor.TALK:
        this.currentState = CursorController.PixelCursor.TALK;
        break;
      case CursorController.PixelCursor.INSPECT:
        this.currentState = CursorController.PixelCursor.INSPECT;
        break;
      case CursorController.PixelCursor.OK:
        this.overrideState = CursorController.PixelCursor.OK;
        break;
      case CursorController.PixelCursor.TRANSITION:
        this.currentState = CursorController.PixelCursor.TRANSITION;
        break;
    }
  }

  public CursorController.PixelCursor getCurrentState() => this.overrideState;

  public void clearOverride() => this.overrideState = CursorController.PixelCursor.NORMAL;

  public enum PixelCursor
  {
    NORMAL,
    ACTIVE,
    BUSY,
    TALK,
    INSPECT,
    OK,
    TRANSITION,
  }
}
