// Decompiled with JetBrains decompiler
// Type: OutpostBarsButtonAdd
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class OutpostBarsButtonAdd : ObjectActionController
{
  public string plus_1;
  public string minus_1;
  public string minus_2;
  public string minus_3;
  public string minus_4;
  public OutpostBarsButtonAdd minus1Obj;
  public OutpostBarsButtonAdd minus2Obj;
  public OutpostBarsButtonAdd minus3Obj;
  public OutpostBarsButtonAdd minus4Obj;
  public Sprite sprite_on;
  public Sprite sprite_off;
  public Sprite sprite_disabled;
  public GameObject bar;
  public Sprite bar_red;
  public Sprite bar_yellow;
  public Sprite bar_green;
  public SpriteRenderer sr;
  public int xShift;
  public int yShift;
  public int targetValue;
  public int currentValue;
  private float delay;
  private int bigPlus = 8;
  private int smallPlus;
  private int bigMinus = 2;
  private int smallMinus = 2;
  public int good_start;
  public int good_end;
  public int perfect_start;
  public int perfect_end;
  public AudioSource aS;
  [SerializeField]
  private bool allowed;
  public OutpostBarsPuzzleCaption_Eff caption_eff;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = string.Empty;
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_bars_button";
    this.teleport = true;
    this.range = 1000f;
    this.aS = this.GetComponent<AudioSource>();
    this.allowed = true;
    this.currentValue = GameDataController.gd.getObjectiveDetail("outpost_bars_" + this.plus_1);
    this.targetValue = this.currentValue;
    this.updateState();
  }

  private void Update()
  {
    if ((double) this.delay <= 0.0)
    {
      if (this.currentValue < this.targetValue)
        ++this.currentValue;
      else if (this.currentValue > this.targetValue)
        --this.currentValue;
      this.delay = 0.05f;
      this.updateState();
    }
    else
      this.delay -= Time.deltaTime;
  }

  public override void clickAction()
  {
    if (!this.allowed)
      return;
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.mouse_click, 0.5f);
    this.currentValue = GameDataController.gd.getObjectiveDetail("outpost_bars_" + this.plus_1);
    this.targetValue = this.currentValue + this.bigPlus;
    GameDataController.gd.setObjectiveDetail("outpost_bars_" + this.plus_1, this.targetValue);
    this.zrobCos(this.minus1Obj, this.minus_1, this.smallMinus);
    this.zrobCos(this.minus2Obj, this.minus_2, this.smallMinus);
    this.zrobCos(this.minus3Obj, this.minus_3, this.bigMinus);
    this.zrobCos(this.minus4Obj, this.minus_4, this.bigMinus);
    this.updateAll();
    this.aS.PlayOneShot(SoundsManagerController.sm.power_up_small, 0.5f);
    this.aS.pitch = (float) (0.800000011920929 + (double) Random.Range(0.0f, 0.1f) + (double) this.caption_eff.score * 0.100000001490116);
    this.sr.sprite = this.sprite_on;
    PlayerController.pc.setBusy(true);
    this.Invoke("unlock", 0.5f);
  }

  public void zrobCos(OutpostBarsButtonAdd obiekt, string nazwa, int minus)
  {
    int detail = GameDataController.gd.getObjectiveDetail("outpost_bars_" + nazwa) - minus;
    obiekt.currentValue = obiekt.targetValue;
    GameDataController.gd.setObjectiveDetail("outpost_bars_" + nazwa, detail);
    obiekt.targetValue = detail;
  }

  public void unlock()
  {
    PlayerController.pc.setBusy(false);
    this.updateAll();
    if (this.caption_eff.score != 10)
      return;
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "outpost_bars_perfect"));
  }

  public override void updateState()
  {
    this.coords(new Vector2((float) this.xShift, (float) (this.yShift + this.currentValue)));
    if (!PlayerController.wc.busy)
    {
      this.allowed = true;
      this.setCollider(0);
      this.sr.sprite = this.sprite_off;
      if (this.targetValue + this.bigPlus > 100)
        this.allowed = false;
      if (this.minus1Obj.targetValue - this.smallMinus < 0)
        this.allowed = false;
      if (this.minus2Obj.targetValue - this.smallMinus < 0)
        this.allowed = false;
      if (this.minus3Obj.targetValue - this.bigMinus < 0)
        this.allowed = false;
      if (this.minus4Obj.targetValue - this.bigMinus < 0)
        this.allowed = false;
      if (!this.allowed)
      {
        this.sr.sprite = this.sprite_disabled;
        this.setCollider(-1);
      }
    }
    if (this.currentValue > this.perfect_start && this.currentValue <= this.perfect_end)
      this.bar.GetComponent<SpriteRenderer>().sprite = this.bar_green;
    else if (this.currentValue > this.good_start && this.currentValue <= this.good_end)
      this.bar.GetComponent<SpriteRenderer>().sprite = this.bar_yellow;
    else
      this.bar.GetComponent<SpriteRenderer>().sprite = this.bar_red;
    if (this.targetValue > this.perfect_start && this.targetValue <= this.perfect_end)
      GameDataController.gd.setObjectiveDetail("outpost_score_" + this.plus_1, 2);
    else if (this.targetValue > this.good_start && this.targetValue <= this.good_end)
      GameDataController.gd.setObjectiveDetail("outpost_score_" + this.plus_1, 1);
    else
      GameDataController.gd.setObjectiveDetail("outpost_score_" + this.plus_1, 0);
    this.caption_eff.aktualizuj();
  }

  private Vector3 coords(Vector2 source)
  {
    Vector2 vectorToChange = new Vector2();
    float z = this.gameObject.transform.position.z;
    vectorToChange.x = source.x + 120f;
    vectorToChange.y = source.y + 72f;
    Vector2 screen = ScreenControler.gameToScreen(vectorToChange);
    Vector3 position = new Vector3(screen.x, screen.y, this.gameObject.transform.position.z);
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(position);
    worldPoint.z = -0.256f;
    this.bar.transform.position = worldPoint;
    return position;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
