// Decompiled with JetBrains decompiler
// Type: ObjectActionController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectActionController : MonoBehaviour
{
  public ObjectActionController.Type actionType;
  public ColliderManager colliderManager;
  public string characterAnimationName;
  public bool useCurrentDirection;
  public bool animationFlip;
  public GameObject actionMarker;
  private WalkController walkControllerOAC;
  protected bool teleport;
  public float range = 1f;
  protected TextFieldController textfield;
  private CursorController cursorCont;
  public KeyValueString[] dkvs;
  public string objectName;
  private AudioSource thisAudioSource;
  public List<ItemInteraction> interactions;
  public bool allowAllItems;
  public static int BOTTOM_TEXT_WIDTH = 224;
  public Item usedItemRef;
  public ItemInteraction usedItemInteraction;
  public string usedItem;
  protected bool needUpdate;
  private bool alreadyMouseEntered;
  private int clicks;
  public string doubleClickCondition = string.Empty;
  public WalkController.Direction trans_dir = WalkController.Direction.S;
  public LocationManager currentLocationManager;
  public float runTimeout;
  public int run;

  private void Awake()
  {
    this.interactions = new List<ItemInteraction>();
    this.walkControllerOAC = PlayerController.wc;
    this.initCursor();
    this.initTextField();
    this.needUpdate = true;
  }

  public void initTextField() => this.textfield = GameObject.Find("BottomText").GetComponent<TextFieldController>();

  public void setCollider(int n) => this.colliderManager.setCollider(n);

  private void initCursor() => this.cursorCont = GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>();

  private void OnMouseOver()
  {
    if (!((Object) PlayerController.pc != (Object) null) || PlayerController.pc.dialogue != PlayerController.DialogueState.NONE || PlayerController.wc.busy || InventoryButtonController.ibc.isItOpen() && !InventoryController.ic.blocker.enabled)
      return;
    if ((Object) this.cursorCont == (Object) null)
      this.initCursor();
    if (!PlayerController.wc.busy)
    {
      if (this.actionType == ObjectActionController.Type.Transition && CursorController.cc.selectedItemName == string.Empty)
        this.cursorCont.showCursor(CursorController.PixelCursor.TRANSITION, this.trans_dir);
      else if (this.actionType == ObjectActionController.Type.Talk && CursorController.cc.selectedItemName == string.Empty)
        this.cursorCont.showCursor(CursorController.PixelCursor.TALK, this.trans_dir);
      else if (this.actionType == ObjectActionController.Type.Secret)
        this.cursorCont.showCursor(CursorController.PixelCursor.NORMAL);
      else
        this.cursorCont.showCursor(CursorController.PixelCursor.ACTIVE);
    }
    if ((Object) this.gameObject.GetComponent<GroundItemController>() == (Object) null)
    {
      Vector2 vector2 = new Vector2(CursorController.cc.gameObject.transform.position.x, CursorController.cc.gameObject.transform.position.y);
      RaycastHit2D[] raycastHit2DArray = Physics2D.LinecastAll(vector2, vector2);
      if (raycastHit2DArray != null)
      {
        for (int index = 0; index < raycastHit2DArray.Length; ++index)
        {
          if ((Object) raycastHit2DArray[index].collider.gameObject.GetComponent<GroundItemController>() != (Object) null)
          {
            raycastHit2DArray[index].collider.gameObject.GetComponent<GroundItemController>().fakeMouseOver();
            return;
          }
        }
      }
    }
    if (Input.GetMouseButtonDown(1) && (Object) this.textfield != (Object) null && this.dkvs != GameStrings.gui && this.objectName != string.Empty)
      this.textfield.viewText(GameStrings.getString(this.dkvs, this.objectName + "_long"), quick: true, mwidth: ObjectActionController.BOTTOM_TEXT_WIDTH);
    if (!this.alreadyMouseEntered)
      this.OnMouseEnter();
    this.alreadyMouseEntered = true;
  }

  public void fakeMouseOver() => this.OnMouseOver();

  public void fakeMouseDown() => this.OnMouseDown();

  private void OnMouseEnter()
  {
    if (PlayerController.pc.dialogue == PlayerController.DialogueState.NONE && !PlayerController.wc.busy && (!InventoryButtonController.ibc.isItOpen() || InventoryController.ic.blocker.enabled))
    {
      if ((Object) this.cursorCont == (Object) null)
        this.initCursor();
      if ((Object) this.textfield == (Object) null)
        this.initTextField();
      if ((Object) this.textfield != (Object) null && !PlayerController.wc.busy && this.actionType != ObjectActionController.Type.Secret)
      {
        if (this.cursorCont.selectedItemName.Equals(string.Empty) || this.dkvs == GameStrings.gui)
        {
          if (this.dkvs != GameStrings.map && this.dkvs != GameStrings.gui && this.objectName != string.Empty)
            this.textfield.viewText(GameStrings.getPrefixedShort(this.dkvs, this.objectName, true), quick: true, mwidth: ObjectActionController.BOTTOM_TEXT_WIDTH);
        }
        else
        {
          string str1 = GameStrings.getString(GameStrings.gui, "use1");
          string str2 = GameStrings.getString(GameStrings.gui, "use2");
          bool flag = true;
          if ((this.objectName == "npc_boy" || this.objectName == "npc_cody") && !GameDataController.gd.getObjective("npc3_joined") && (this.cursorCont.selectedItemName.IndexOf("rifle") != -1 || this.cursorCont.selectedItemName == "wrench" || this.cursorCont.selectedItemName == "crowbar" || this.cursorCont.selectedItemName == "hammer" || this.cursorCont.selectedItemName == "pipe"))
            flag = false;
          if ((this.objectName == "npc_mourning" || this.objectName == "npc_barry") && !GameDataController.gd.getObjective("npc2_joined") && (this.cursorCont.selectedItemName.IndexOf("rifle") != -1 || this.cursorCont.selectedItemName == "wrench" || this.cursorCont.selectedItemName == "crowbar" || this.cursorCont.selectedItemName == "hammer" || this.cursorCont.selectedItemName == "pipe"))
            flag = false;
          if (this.actionType == ObjectActionController.Type.Talk & flag)
          {
            str1 = GameStrings.getString(GameStrings.gui, "give1");
            str2 = GameStrings.getString(GameStrings.gui, "give2");
          }
          if (str2 != ":")
            str2 = " " + str2;
          this.textfield.viewText(str1 + " " + GameStrings.getString(GameStrings.items, this.cursorCont.selectedItemName + "_short") + str2 + " " + GameStrings.getPrefixedShort(this.dkvs, this.objectName) + ".", quick: true, mwidth: ObjectActionController.BOTTOM_TEXT_WIDTH);
        }
      }
    }
    this.mouseOver();
  }

  private void OnMouseExit()
  {
    this.clicks = 0;
    if ((Object) this.cursorCont == (Object) null)
      this.initCursor();
    this.cursorCont.showCursor(CursorController.PixelCursor.NORMAL);
    if ((Object) this.textfield != (Object) null && !PlayerController.wc.busy)
    {
      this.textfield.keepAlive = false;
      this.textfield.dissmiss(true);
    }
    this.alreadyMouseEntered = false;
    this.mouseOut();
  }

  private void OnMouseDown()
  {
    ++this.clicks;
    if (PlayerController.pc.dialogue != PlayerController.DialogueState.NONE || PlayerController.pc.clickedAlreadyForSomething)
      return;
    if (!PlayerController.wc.busy)
    {
      if ((Object) this.gameObject.GetComponent<GroundItemController>() == (Object) null)
      {
        Vector2 vector2 = new Vector2(CursorController.cc.gameObject.transform.position.x, CursorController.cc.gameObject.transform.position.y);
        RaycastHit2D[] raycastHit2DArray = Physics2D.LinecastAll(vector2, vector2);
        if (raycastHit2DArray != null)
        {
          for (int index = 0; index < raycastHit2DArray.Length; ++index)
          {
            if ((Object) raycastHit2DArray[index].collider.gameObject.GetComponent<GroundItemController>() != (Object) null)
            {
              raycastHit2DArray[index].collider.gameObject.GetComponent<GroundItemController>().fakeMouseDown();
              return;
            }
          }
        }
      }
      this.usedItemInteraction = (ItemInteraction) null;
      this.usedItem = string.Empty;
      bool flag1 = true;
      InventoryButtonController.ibc.close();
      if (CursorController.cc.selectedItemRef != null)
      {
        flag1 = false;
        bool flag2 = false;
        for (int index = 0; index < this.interactions.Count; ++index)
        {
          if (CursorController.cc.selectedItemName.Equals(this.interactions[index].name))
          {
            flag2 = true;
            if (!this.interactions[index].failText.Equals(string.Empty))
            {
              PlayerController.pc.textField.viewText(this.interactions[index].failText, true);
              flag1 = false;
              break;
            }
            this.usedItemInteraction = this.interactions[index];
            this.usedItem = this.interactions[index].name;
            flag1 = true;
            break;
          }
        }
        if (this.allowAllItems)
        {
          this.usedItem = CursorController.cc.selectedItemName;
          flag2 = true;
          flag1 = true;
        }
        if (!flag2)
          PlayerController.pc.textField.viewText(GameStrings.getWrongInteractionText(), true);
        CursorController.cc.deselectItem();
      }
      this.whatOnClick0();
      PlayerController.pc.clickedSomething = true;
      if (flag1)
      {
        if ((double) this.range == 1.0)
          this.range = 1.5f;
        MonoBehaviour.print((object) ("THE RANGE FOR THIS ACTION IS " + (object) this.range));
        if ((Object) this.currentLocationManager == (Object) null)
          this.currentLocationManager = GameObject.Find("Location").GetComponent<LocationManager>();
        PlayerController.wc.onFinishWalking0 = this;
        PlayerController.wc.onFinishWalking = this;
        PlayerController.wc.onFinishWalking2 = this;
        Vector2 nearestClearNode = this.currentLocationManager.findNearestClearNode(this.currentLocationManager.getNodeLocation((Vector2) ScreenControler.roundToNearestFullPixel(this.actionMarker.transform.position)));
        List<Vector2> newTarget = this.currentLocationManager.Search2(this.currentLocationManager.getNodeLocation(PlayerController.wc.currentXY), nearestClearNode);
        MonoBehaviour.print((object) ("TRASA: " + (object) newTarget));
        Vector2 game = ScreenControler.screenToGame((Vector2) Camera.main.WorldToScreenPoint(this.actionMarker.transform.position));
        if (newTarget != null)
        {
          MonoBehaviour.print((object) ("DLUGOSC: " + (object) newTarget.Count));
          Vector2 a = newTarget.Count <= 0 ? this.currentLocationManager.getNodeLocation(PlayerController.wc.currentXY) : this.currentLocationManager.getNodeLocation(newTarget[newTarget.Count - 1]);
          MonoBehaviour.print((object) ("DISTANCE TO ACTION: " + (object) LocationManager.dist(a, this.currentLocationManager.getNodeLocation(game))));
          if ((double) LocationManager.dist(a, this.currentLocationManager.getNodeLocation(game)) <= (double) this.range)
          {
            if (newTarget.Count > 0)
              newTarget.RemoveAt(newTarget.Count - 1);
            newTarget.Add(game);
          }
          else
          {
            PlayerController.wc.onFinishWalking0 = (ObjectActionController) null;
            PlayerController.wc.onFinishWalking = (ObjectActionController) null;
            PlayerController.wc.onFinishWalking2 = (ObjectActionController) null;
          }
          PlayerController.wc.speedMultip = this.clicks >= 2 || (double) PlayerController.wc.speedMultip > 1.0 ? 2f : 1f;
          this.runTimeout = 1f;
          PlayerController.wc.setTarget(newTarget);
        }
        PlayerController.wc.range = (int) Mathf.Floor(this.range);
        if (this.teleport)
        {
          PlayerController.wc.currentXY.x = ScreenControler.screenToGame((Vector2) Camera.main.WorldToScreenPoint(this.actionMarker.transform.position)).x;
          PlayerController.wc.currentXY.y = ScreenControler.screenToGame((Vector2) Camera.main.WorldToScreenPoint(this.actionMarker.transform.position)).y;
        }
      }
      else
      {
        PlayerController.pc.setBusy(false);
        PlayerController.wc.fullStop();
      }
    }
    if (!PlayerController.wc.busy)
      this.whatOnClick();
    if (this.clicks <= 1 || !GameDataController.gd.getObjective(this.doubleClickCondition) || PlayerController.wc.busy || !((Object) PlayerController.wc.onFinishWalking != (Object) null))
      return;
    PlayerController.wc.onFinishWalking.clickAction();
    PlayerController.wc.letOneMoreAnimationBeforeBusy = 20;
  }

  public void fakeClick() => this.OnMouseDown();

  private void Update()
  {
    if (this.needUpdate)
    {
      this.needUpdate = false;
      this.updateState();
    }
    if ((double) this.runTimeout <= 0.0)
      return;
    this.runTimeout -= Time.deltaTime;
    if ((double) this.runTimeout > 0.0)
      return;
    this.clicks = 0;
  }

  private void OnEnable() => this.needUpdate = true;

  public void animationComplete() => this.updateState();

  public void updateAll()
  {
    foreach (ObjectActionController actionController in Object.FindObjectsOfType(typeof (ObjectActionController)))
      actionController.updateState();
  }

  public virtual void whatOnClick()
  {
  }

  public virtual void whatOnClick0()
  {
  }

  public abstract void updateState();

  public abstract void clickAction0();

  public abstract void clickAction();

  public abstract void clickAction2();

  public virtual void mouseOver()
  {
  }

  public virtual void mouseOut()
  {
  }

  public enum Type
  {
    NormalAction,
    Transition,
    Talk,
    Secret,
  }
}
