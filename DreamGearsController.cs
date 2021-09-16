// Decompiled with JetBrains decompiler
// Type: DreamGearsController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class DreamGearsController : MonoBehaviour
{
  public Sprite normal;
  public Sprite active;
  private float alpha = 1f;
  private float alphaSpeed = 0.25f;
  private bool visible = true;
  private SpriteRenderer spriteRenderer;
  public string condition;
  private string frame_name_sufix = "0";

  private void Start()
  {
    if (!GameDataController.gd.getObjective(this.condition))
      return;
    this.show();
    this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    this.gameObject.GetComponent<SpriteRenderer>().sprite = this.normal;
  }

  private void show()
  {
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(229f, 125f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -4f;
    this.gameObject.transform.position = worldPoint;
  }

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.Escape) || PlayerController.wc.busy || PlayerController.pc.dialogue != PlayerController.DialogueState.NONE)
      return;
    this.OnMouseDown();
  }

  private void OnMouseOver()
  {
    if (!PlayerController.wc.busy && PlayerController.pc.dialogue == PlayerController.DialogueState.NONE)
    {
      GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>().showCursor(CursorController.PixelCursor.ACTIVE);
      if (!(this.frame_name_sufix != "1"))
        return;
      this.frame_name_sufix = "1";
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.active;
      GameObject gameObject = GameObject.Find("BottomText");
      MonoBehaviour.print((object) "no i co teraz?");
      string text = GameStrings.getString(GameStrings.gui, "gears");
      gameObject.GetComponent<TextFieldController>().viewText(text, quick: true, mwidth: BottomTextController.bottomTextWidth);
    }
    else
      this.OnMouseExit();
  }

  private void OnMouseExit()
  {
    this.frame_name_sufix = "0";
    GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>().showCursor(CursorController.PixelCursor.NORMAL);
    this.gameObject.GetComponent<SpriteRenderer>().sprite = this.normal;
    GameObject.Find("BottomText").GetComponent<TextFieldController>().keepAlive = false;
  }

  private void OnMouseDown()
  {
    if (PlayerController.wc.busy || PlayerController.pc.dialogue != PlayerController.DialogueState.NONE)
      return;
    PlayerController.pc.clickedSomething = true;
    if (InventoryButtonController.ibc.gameObject.GetComponent<BoxCollider2D>().enabled)
      InventoryButtonController.ibc.close();
    CursorController.cc.deselectItem();
    if ((bool) (Object) InventoryController.ic)
      InventoryController.ic.gameObject.SetActive(false);
    PlayerController.wc.fullStop(true);
    if ((double) PlayerController.wc.speed != 0.0)
      PlayerController.wc.forceAnimation("stand_", useCurrentDir: true);
    PlayerController.pc.spawnName = "InfoExit";
    GameDataController.gd.previousLocation = SceneManager.GetActiveScene().name;
    GameDataController.gd.previousX = (int) PlayerController.wc.currentXY.x;
    GameDataController.gd.previousY = (int) PlayerController.wc.currentXY.y;
    ScreenShots.ss.shot();
    CurtainController.cc.fadeOut("PauseMenu", tSpeed: 1f);
    AudioListener.pause = true;
  }
}
