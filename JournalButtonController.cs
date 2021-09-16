// Decompiled with JetBrains decompiler
// Type: JournalButtonController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;
using UnityEngine.SceneManagement;

public class JournalButtonController : MonoBehaviour
{
  private InventoryController inventory;
  [SerializeField]
  private string frame_name_sufix = "0";
  [SerializeField]
  private string frame_name_prefix = "journal_";
  private Animator exc;
  private Vector2 pozycja;
  private SpriteRenderer excSprite;

  private void Start()
  {
    this.pozycja = new Vector2(30f, 124f);
    Vector2 screen = ScreenControler.gameToScreen(this.pozycja);
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -1.5f;
    this.gameObject.transform.position = worldPoint;
    this.exc = this.gameObject.transform.Find("exc").GetComponent<Animator>();
    this.exc.Play("journalW_0", 0);
    this.excSprite = this.gameObject.transform.Find("exc").GetComponent<SpriteRenderer>();
    this.excSprite.enabled = false;
    if (GameDataController.gd.getCurrentDay() <= 4)
      return;
    this.hide();
  }

  internal void showJournal(string param)
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

  public void setWarning(bool yesno)
  {
    if ((Object) this.excSprite == (Object) null)
      this.excSprite = this.gameObject.transform.Find("exc").GetComponent<SpriteRenderer>();
    if (yesno)
      this.excSprite.enabled = true;
    else
      this.excSprite.enabled = false;
  }

  public void showFinal()
  {
    if (GameDataController.gd.getCurrentDay() > 4)
    {
      this.hide();
    }
    else
    {
      this.show();
      this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
  }

  public void show()
  {
    Vector2 screen = ScreenControler.gameToScreen(this.pozycja);
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -4f;
    this.gameObject.transform.position = worldPoint;
    this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    this.frame_name_prefix = "journal_";
    if ((Object) this.excSprite == (Object) null)
      this.excSprite = this.gameObject.transform.Find("exc").GetComponent<SpriteRenderer>();
    if (!((Object) this.excSprite == (Object) null))
      return;
    this.excSprite.color = new Color(1f, 1f, 1f, 1f);
  }

  public void hide()
  {
    this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    if ((Object) this.excSprite == (Object) null)
      this.excSprite = this.gameObject.transform.Find("exc").GetComponent<SpriteRenderer>();
    if (!((Object) this.excSprite != (Object) null))
      return;
    this.excSprite.color = new Color(1f, 1f, 1f, 0.0f);
  }

  private void Update()
  {
  }

  private void OnMouseOver()
  {
    if (!PlayerController.wc.busy && PlayerController.pc.dialogue == PlayerController.DialogueState.NONE)
    {
      GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>().showCursor(CursorController.PixelCursor.ACTIVE);
      if (!(this.frame_name_sufix != "1"))
        return;
      this.frame_name_sufix = "1";
      this.gameObject.GetComponent<Animator>().Play(this.frame_name_prefix + this.frame_name_sufix, 0);
      GameObject.Find("BottomText").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "journal"), quick: true, mwidth: ObjectActionController.BOTTOM_TEXT_WIDTH);
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
    this.gameObject.GetComponent<Animator>().Play(this.frame_name_prefix + this.frame_name_sufix, 0);
  }

  public void fakeClick() => this.OnMouseDown();

  private void OnMouseDown()
  {
    if (PlayerController.wc.busy || PlayerController.pc.dialogue != PlayerController.DialogueState.NONE)
      return;
    PlayerController.pc.clickedSomething = true;
    AudioClip clip;
    switch (Random.Range(1, 5))
    {
      case 1:
        clip = SoundsManagerController.sm.page_turn_01;
        break;
      case 2:
        clip = SoundsManagerController.sm.page_turn_02;
        break;
      case 3:
        clip = SoundsManagerController.sm.page_turn_03;
        break;
      default:
        clip = SoundsManagerController.sm.page_turn_04;
        break;
    }
    if (InventoryButtonController.ibc.gameObject.GetComponent<BoxCollider2D>().enabled)
      InventoryButtonController.ibc.close();
    CursorController.cc.deselectItem();
    this.inventory = InventoryController.ic;
    if ((bool) (Object) this.inventory)
      this.inventory.gameObject.SetActive(false);
    PlayerController.pc.aS.PlayOneShot(clip, 0.5f);
    PlayerController.wc.fullStop(true);
    if ((double) PlayerController.wc.speed != 0.0)
      PlayerController.wc.forceAnimation("stand_", useCurrentDir: true);
    PlayerController.pc.spawnName = "InfoExit";
    GameDataController.gd.previousLocation = SceneManager.GetActiveScene().name;
    GameDataController.gd.previousX = (int) PlayerController.wc.currentXY.x;
    GameDataController.gd.previousY = (int) PlayerController.wc.currentXY.y;
    CurtainController.cc.fadeOut("InfoLocation");
  }
}
