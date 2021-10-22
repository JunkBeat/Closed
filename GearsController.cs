// Decompiled with JetBrains decompiler
// Type: GearsController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class GearsController : MonoBehaviour
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
    if (this.condition == "auto")
      this.condition = "dream_day_" + (object) GameDataController.gd.getCurrentDay() + "_started";
    if (this.condition != null && !(this.condition == string.Empty) && !GameDataController.gd.getObjective(this.condition))
      return;
    this.showGears();
  }

  public void show()
  {
    if (this.condition != null && !(this.condition == string.Empty) && !GameDataController.gd.getObjective(this.condition))
      return;
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(229f, 125f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -2.5f;
    this.gameObject.transform.position = worldPoint;
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel3(this.gameObject.transform.position);
    this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    this.gameObject.GetComponent<SpriteRenderer>().sprite = this.normal;
    this.spriteRenderer.enabled = true;
  }

  public void showFinal()
  {
    this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    this.show();
  }

  public void hide() => this.spriteRenderer.enabled = false;

  public void showGears(bool fast = true)
  {
    if (!fast)
    {
      this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
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
    else
      this.show();
  }

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.Escape) || PlayerController.wc.busy || PlayerController.pc.dialogue != PlayerController.DialogueState.NONE || this.condition != null && !(this.condition == string.Empty) && !GameDataController.gd.getObjective(this.condition))
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
      string text = GameStrings.getString(GameStrings.gui, "gears");
      gameObject.GetComponent<TextFieldController>().viewText(text, quick: true, mwidth: BottomTextController.bottomTextWidth);
    }
    else
      this.OnMouseExit();
  }

  private void OnMouseExit()
  {
    if (PlayerController.wc.busy)
      return;
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
    PlayerController.pc.textField.dissmiss(true);
    GameDataController.gd.previousLocation = SceneManager.GetActiveScene().name;
    GameDataController.gd.previousX = (int) PlayerController.wc.currentXY.x;
    GameDataController.gd.previousY = (int) PlayerController.wc.currentXY.y;
    ScreenShots.ss.shot();
    CurtainController.cc.fadeOut("PauseMenu", tSpeed: 1f);
    AudioListener.pause = true;
  }
}
