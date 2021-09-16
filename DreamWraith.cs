// Decompiled with JetBrains decompiler
// Type: DreamWraith
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class DreamWraith : ObjectActionController
{
  public GameObject sarge;
  public LocationDream3BStart ld3bs;
  protected DialogueOptionController doc;
  public TextFieldController textField;
  private static Vector3 colorTiger = new Vector3(0.6f, 0.4156863f, 0.4f);
  private static Vector3 colorMaggie = new Vector3(0.6f, 0.4156863f, 0.4f);
  public Vector3 position;
  public Vector2 position2;
  public bool gogogo;
  public bool gogogo2;
  [SerializeField]
  public SpriteShadow shadow;
  public ParticleGenerator playeremiter;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = true;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.actionType = ObjectActionController.Type.Talk;
    this.dkvs = GameStrings.objects;
    this.objectName = "???";
    this.range = 30f;
    this.position = ScreenControler.roundToNearestFullPixel3(this.sarge.transform.position);
    this.sarge.transform.position = this.position;
    this.position2 = new Vector2(-1f, 40f);
    this.setCollider(-1);
    this.playeremiter.started = false;
    this.updateState();
  }

  public override void whatOnClick0()
  {
  }

  public override void clickAction()
  {
  }

  public void shadowpep(string val = "")
  {
  }

  public void reset()
  {
    this.playeremiter.started = false;
    this.position2 = new Vector2(-1f, 40f);
    this.ld3bs.reset();
  }

  public void reset1()
  {
    PlayerController.wc.forceAnimation("sit_strugle", true);
    PlayerController.pc.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
    this.playeremiter.started = true;
  }

  public void reset2() => PlayerController.pc.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.25f);

  public void reset3() => PlayerController.pc.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1f);

  public void reset4()
  {
    PlayerController.pc.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.0f);
    this.playeremiter.started = false;
  }

  public void reset0()
  {
    GameDataController.gd.setObjective("dream_day_3b_started", false);
    PlayerController.pc.spawnName = "DreamStairs";
    CurtainController.cc.fadeOut("Dream3B");
    this.Invoke("reset", 1f);
  }

  private void Update()
  {
    if (this.gogogo || this.gogogo2)
    {
      this.position2.x += Time.deltaTime * 12f;
      this.position2.y = PlayerController.wc.currentXY.y + 17f;
      if ((double) this.position2.x > 20.0)
        this.gogogo = false;
      if ((double) this.position2.x >= (double) PlayerController.wc.currentXY.x - 15.0)
      {
        this.position2.x = PlayerController.wc.currentXY.x - 15f;
        this.gogogo2 = false;
        PlayerController.pc.setBusy(true);
        PlayerController.wc.forceAnimation("sit_fall", true);
        GameObject.Find("DreamStairs").GetComponent<DreamStairsUpper>().setCollider(-1);
        GameObject.Find("tiger").GetComponent<DreamTiger>().setCollider(-1);
        this.Invoke("reset1", 1f);
        this.Invoke("reset2", 5f);
        this.Invoke("reset3", 7f);
        this.Invoke("reset4", 9f);
        this.Invoke("reset0", 12f);
      }
    }
    Vector2 vectorToChange = new Vector2();
    float z = this.sarge.transform.position.z;
    vectorToChange.x = this.position2.x;
    vectorToChange.y = this.position2.y;
    vectorToChange = ScreenControler.gameToScreen(vectorToChange);
    this.position = new Vector3(vectorToChange.x, vectorToChange.y, this.sarge.transform.position.z);
    this.position.z = Camera.main.WorldToScreenPoint(this.sarge.transform.position).z;
    this.sarge.transform.position = Camera.main.ScreenToWorldPoint(this.position);
    this.sarge.transform.position = new Vector3(this.sarge.transform.position.x, this.sarge.transform.position.y, z);
  }

  public override void updateState()
  {
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
