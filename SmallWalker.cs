// Decompiled with JetBrains decompiler
// Type: SmallWalker
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class SmallWalker : ObjectActionController
{
  private Vector2 realPosition;
  public Sprite standSprite;
  public SpriteRenderer title;
  public SpriteRenderer title2;
  public float titleAlpha;
  public float titleAlpha2;
  public int skipit = 1;
  public float timer;

  private void Start()
  {
    this.skipit = 1;
    this.realPosition = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = true;
    this.characterAnimationName = "action_stnd_e";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "intro_desert";
    this.range = 10000f;
    this.title.color = new Color(1f, 1f, 1f, 0.0f);
    this.title2.color = new Color(1f, 1f, 1f, 0.0f);
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.E;
    Button component = GameObject.Find("ContinueBtn").GetComponent<Button>();
    component.buttonEnabled = false;
    component.onClick = (Button.Delegate) null;
    component.workIfBusy = false;
    component.enabled = false;
    component.GetComponent<BoxCollider2D>().enabled = false;
    component.enabled = false;
    component.buttonEnabled = false;
  }

  private void skipIt()
  {
    GameDataController.gd.setObjective("intro_skipped", true);
    this.titleAlpha = -200f;
    PlayerController.pc.spawnName = "Waypoint_Crossroad_Base";
    CurtainController.cc.fadeOut("LocationCrossroad", WalkController.Direction.N, tSpeed: 0.1f);
  }

  private void Update()
  {
    if (GameDataController.gd.getObjective("intro_desert_walked"))
    {
      this.realPosition.x += 0.08f * Time.deltaTime;
      if ((double) this.realPosition.x > 0.5 && (double) this.titleAlpha < -100.0)
      {
        this.title.color = new Color(1f, 1f, 1f, 0.0f);
        this.title2.color = new Color(1f, 1f, 1f, 0.0f);
      }
      else if ((double) this.realPosition.x > 0.5 && (double) this.titleAlpha > -100.0)
      {
        this.titleAlpha = -200f;
        PlayerController.pc.spawnName = "Waypoint_Crossroad_Base";
        CurtainController.cc.fadeOut("LocationCrossroad", WalkController.Direction.N, tSpeed: 0.005f);
      }
      else if ((double) this.realPosition.x > 0.200000002980232 && (double) this.titleAlpha > 0.0 && (double) this.titleAlpha2 > 0.0)
      {
        this.titleAlpha -= 0.01f;
        this.titleAlpha2 -= 0.01f;
        this.title.color = new Color(1f, 1f, 1f, this.titleAlpha);
        this.title2.color = new Color(1f, 1f, 1f, this.titleAlpha2);
      }
      else
      {
        if ((double) this.realPosition.x > -0.600000023841858 && (double) this.titleAlpha < 1.0)
        {
          this.titleAlpha += 0.01f;
          this.title.color = new Color(1f, 1f, 1f, this.titleAlpha);
        }
        if ((double) this.realPosition.x > -0.200000002980232 && (double) this.titleAlpha2 < 1.0)
        {
          this.titleAlpha2 += 0.01f;
          this.title2.color = new Color(1f, 1f, 1f, this.titleAlpha2);
        }
      }
    }
    else
      this.gameObject.GetComponent<Animator>().Play("small_stop");
    this.gameObject.transform.position = new Vector3(this.realPosition.x, this.realPosition.y, this.gameObject.transform.position.z);
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    if (this.skipit == 2)
    {
      this.timer += Time.deltaTime;
      if ((double) this.timer > 3.0)
      {
        this.timer = 0.0f;
        this.skipit = 1;
        Button component = GameObject.Find("ContinueBtn").GetComponent<Button>();
        component.initButton(" ");
        component.workIfBusy = false;
        component.onClick = (Button.Delegate) null;
        component.GetComponent<BoxCollider2D>().enabled = false;
        component.enabled = false;
        component.buttonEnabled = false;
      }
    }
    if (!Input.GetMouseButtonDown(0) && !Input.GetKeyDown(KeyCode.Escape) || this.skipit != 1)
      return;
    this.skipit = 2;
    this.showButton();
  }

  public void showButton()
  {
    Button component = GameObject.Find("ContinueBtn").GetComponent<Button>();
    component.initButton("[" + GameStrings.getString(GameStrings.gui, "skip") + "]");
    component.workIfBusy = false;
    component.onClick = new Button.Delegate(this.skipIt);
    component.GetComponent<BoxCollider2D>().enabled = true;
    component.buttonText.OPTIONAL_MARGIN = 6;
    component.enabled = true;
    component.buttonEnabled = true;
  }

  public override void clickAction()
  {
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("intro_desert_walked"))
      this.setCollider(-1);
    else
      this.setCollider(0);
  }

  public override void whatOnClick()
  {
    GameDataController.gd.setObjective("intro_desert_walked", true);
    this.gameObject.GetComponent<Animator>().Play("small_walk");
    this.updateState();
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
