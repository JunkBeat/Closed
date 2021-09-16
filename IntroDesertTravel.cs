// Decompiled with JetBrains decompiler
// Type: IntroDesertTravel
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class IntroDesertTravel : ObjectActionController
{
  private Vector2 realPosition;
  public Sprite standSprite;
  public int skipit;
  public float timer;

  private void Start()
  {
    this.realPosition = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = true;
    this.characterAnimationName = "action_stnd_e";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "intro_desert";
    this.teleport = true;
    this.range = 10000f;
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.E;
    Button component = GameObject.Find("ContinueBtn").GetComponent<Button>();
    component.buttonEnabled = false;
    component.onClick = (Button.Delegate) null;
    component.workIfBusy = false;
    component.enabled = false;
    component.GetComponent<BoxCollider2D>().enabled = false;
    component.GetComponent<Button>().enabled = false;
  }

  private void Update()
  {
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

  public override void clickAction()
  {
  }

  public void gogo()
  {
    GameDataController.gd.setObjective("intro_desert_walked", true);
    GameObject.Find("FakePlayer").GetComponent<Animator>().Play("FakePlayerWalk");
    this.updateState();
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_main, false);
    this.Invoke("showIntro1", 5f);
    this.Invoke("showIntro1b", 10f);
    this.Invoke("showIntro2", 14f);
    this.Invoke("showIntro1b", 20f);
    this.Invoke("allowSkip", 6f);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("intro_desert_walked"))
      this.setCollider(-1);
    else
      this.setCollider(0);
  }

  private void allowSkip() => this.skipit = 1;

  public override void whatOnClick() => QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "intro_travel"), yesClick: new Button.Delegate(this.gogo), time: 50);

  private void showSkip()
  {
    Button component = GameObject.Find("ContinueBtn").GetComponent<Button>();
    component.GetComponent<BoxCollider2D>().enabled = true;
    component.GetComponent<Button>().enabled = true;
    component.initButton("[" + GameStrings.getString(GameStrings.gui, "skip") + "]");
    component.onClick = new Button.Delegate(this.skipIt);
    component.GetComponent<BoxCollider2D>().enabled = false;
    component.buttonText.OPTIONAL_MARGIN = 6;
    component.workIfBusy = false;
  }

  private void skipIt()
  {
    GameDataController.gd.setObjective("intro_skipped", true);
    GameObject.Find("LocationManager").GetComponent<LocationSkyStart>().transition = true;
    PlayerController.pc.spawnName = "Waypoint_Crossroad_Base";
    CurtainController.cc.fadeOut("LocationCrossroad", WalkController.Direction.N, tSpeed: 0.1f);
  }

  public void showButton()
  {
    Button component = GameObject.Find("ContinueBtn").GetComponent<Button>();
    component.initButton("[" + GameStrings.getString(GameStrings.gui, "skip") + "]");
    component.workIfBusy = false;
    component.onClick = new Button.Delegate(this.skipIt);
    component.GetComponent<BoxCollider2D>().enabled = false;
    component.buttonText.OPTIONAL_MARGIN = 6;
    component.enabled = true;
    component.buttonEnabled = true;
  }

  private void showIntro1() => GameObject.Find("TitleText").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "intro_1"), quick: true, instant: true, mwidth: 180, r: 0.43f, g: 0.43f, b: 0.43f, ba: 0.0f);

  private void showIntro1b() => GameObject.Find("TitleText").GetComponent<TextFieldController>().viewText(" ", quick: true, instant: true, mwidth: 180, r: 0.0f, g: 0.0f, b: 0.0f, ba: 0.0f);

  private void showIntro2() => GameObject.Find("TitleText").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "intro_2"), quick: true, instant: true, mwidth: 200, r: 0.43f, g: 0.43f, b: 0.43f, ba: 0.0f);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
