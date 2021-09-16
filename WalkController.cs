// Decompiled with JetBrains decompiler
// Type: WalkController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System;
using System.Collections.Generic;
using UnityEngine;

public class WalkController : MonoBehaviour
{
  public Vector2 targetXY;
  private List<Vector2> path;
  public int range = 1;
  public Vector2 currentXY;
  private Vector3 currentXY_screen_rounded;
  public Vector2 currentSpeed;
  private bool walkedBefore;
  public bool busy;
  private bool waitOneFrameBeforeWalking;
  public int offsetY;
  public ObjectActionController onFinishWalking0;
  public ObjectActionController onFinishWalking;
  public ObjectActionController onFinishWalking2;
  public bool waitedOneFrameBeforeAction;
  public WalkController.Delegate autoAction;
  private float lastIdle;
  public int letOneMoreAnimationBeforeBusy;
  public SpriteShadow shadow;
  public int shadowOffsetY;
  public WalkController.Direction dir;
  private WalkController.Direction previousDir;
  private int dirChangeDelay;
  [SerializeField]
  private string currentAnimClip = string.Empty;
  public float speed = 2.5f;
  public float speedMultip = 1f;
  public float MAX_SPEED = 2.5f;
  public SpriteRenderer sr;
  public ParticleGenerator dustPart;
  public Animator animator;
  private GameObject tlo;
  public bool suit;

  public Vector2 getFinalTarget() => this.path != null && this.path.Count > 0 ? this.path[this.path.Count - 1] : new Vector2();

  private void Start()
  {
    Camera.main.orthographicSize = 0.625f;
    this.path = new List<Vector2>();
    this.targetXY = new Vector2(this.currentXY.x, this.currentXY.y);
    this.currentXY_screen_rounded = new Vector3(0.0f, 0.0f, 0.0f);
    this.currentSpeed = new Vector2(0.0f, 0.0f);
    this.shadow = new SpriteShadow(this.gameObject);
    this.shadow.startAlpha = 0.5f;
    this.shadow.fadeRateV = 0.009f;
    this.shadow.fadeRateH = 0.004f;
    this.shadowOffsetY = 0;
    this.animator = this.gameObject.GetComponent<Animator>();
    this.dustPart = this.gameObject.GetComponent<ParticleGenerator>();
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
  }

  public void setTextFieldY(int y) => PlayerController.pc.textField.shift.y = (float) y;

  public string getCurrentAnimClip() => this.currentAnimClip;

  public void setCurrentAnimClip(string anim) => this.currentAnimClip = anim;

  public void setTarget(List<Vector2> newTarget)
  {
    this.path = new List<Vector2>();
    if (newTarget != null)
    {
      while (newTarget.Count > 0)
      {
        this.path.Add(newTarget[0]);
        newTarget.RemoveAt(0);
      }
    }
    if (this.path.Count > 1)
      this.path.RemoveAt(0);
    this.currentXY.x = Mathf.Round(this.currentXY.x);
    this.currentXY.y = Mathf.Round(this.currentXY.y);
    this.range = 1;
    this.waitedOneFrameBeforeAction = false;
  }

  public void setSimpleTargetV3(Vector3 targetPosition) => this.setSimpleTarget((Vector2) ScreenControler.roundToNearestFullPixel(targetPosition));

  public void setSimpleTarget(Vector2 newTarget)
  {
    this.path = new List<Vector2>();
    this.targetXY = new Vector2();
    this.targetXY.x = newTarget.x;
    this.targetXY.y = newTarget.y;
    this.currentXY.x = Mathf.Round(this.currentXY.x);
    this.currentXY.y = Mathf.Round(this.currentXY.y);
    this.range = 1;
    this.waitedOneFrameBeforeAction = false;
  }

  public void clearTarget()
  {
    this.path = new List<Vector2>();
    this.currentXY.x = Mathf.Round(this.currentXY.x);
    this.currentXY.y = Mathf.Round(this.currentXY.y);
    this.targetXY.x = this.currentXY.x;
    this.targetXY.y = this.currentXY.y;
    this.range = 1;
    this.waitedOneFrameBeforeAction = false;
  }

  public void animationStartAction()
  {
    if (!((UnityEngine.Object) this.onFinishWalking != (UnityEngine.Object) null))
      return;
    Timeline.t.stopChitChat();
    this.speedMultip = 1f;
    this.onFinishWalking.clickAction0();
  }

  public void animationAction()
  {
    if ((UnityEngine.Object) this.onFinishWalking != (UnityEngine.Object) null)
    {
      Timeline.t.stopChitChat();
      this.speedMultip = 1f;
      GameObject gameObject = GameObject.Find("BottomText");
      if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
        gameObject.GetComponent<TextFieldController>().dissmiss(true);
      this.onFinishWalking.clickAction();
    }
    this.onFinishWalking = (ObjectActionController) null;
  }

  public void otherAnimationAction()
  {
    if ((UnityEngine.Object) this.onFinishWalking2 != (UnityEngine.Object) null)
    {
      Timeline.t.stopChitChat();
      this.speedMultip = 1f;
      this.onFinishWalking2.clickAction2();
    }
    this.onFinishWalking2 = (ObjectActionController) null;
  }

  public void animationEnd()
  {
    PlayerController.pc.setBusy(false);
    this.shadowOffsetY = 0;
    this.shadowOffsetY = (double) this.shadow.scaleFactor < 0.75 ? ((double) this.shadow.scaleFactor < 0.649999976158142 ? ((double) this.shadow.scaleFactor < 0.550000011920929 ? ((double) this.shadow.scaleFactor < 0.449999988079071 ? ((double) this.shadow.scaleFactor < 0.349999994039536 ? ((double) this.shadow.scaleFactor < 0.25 ? ((double) this.shadow.scaleFactor < 0.150000005960464 ? -7 : -6) : -5) : -4) : -3) : -2) : -1) : 0;
    if (this.currentAnimClip == "suit_action_stnd_n" || this.currentAnimClip == "action_stnd_n" || this.currentAnimClip == "kneel_n")
    {
      this.dir = WalkController.Direction.N;
      MonoBehaviour.print((object) "stand_n");
      if (!this.suit)
        this.gameObject.GetComponent<Animator>().Play("stand_n", 0);
      else
        this.gameObject.GetComponent<Animator>().Play("suit_stand_n", 0);
    }
    if (this.currentAnimClip == "suit_action_stnd_ne" || this.currentAnimClip == "action_stnd_ne" || this.currentAnimClip == "kneel_ne")
    {
      this.dir = WalkController.Direction.NE;
      MonoBehaviour.print((object) "stand_ne");
      if (this.sr.flipX)
        this.dir = WalkController.Direction.NW;
      if (!this.suit)
        this.gameObject.GetComponent<Animator>().Play("stand_ne", 0);
      else
        this.gameObject.GetComponent<Animator>().Play("suit_stand_ne", 0);
    }
    if (this.currentAnimClip == "suit_action_stnd_e" || this.currentAnimClip == "action_stnd_e" || this.currentAnimClip == "kneel_e")
    {
      this.dir = WalkController.Direction.E;
      MonoBehaviour.print((object) "stand_e");
      if (this.sr.flipX)
        this.dir = WalkController.Direction.W;
      if (!this.suit)
        this.gameObject.GetComponent<Animator>().Play("stand_e", 0);
      else
        this.gameObject.GetComponent<Animator>().Play("suit_stand_e", 0);
    }
    if (this.currentAnimClip == "suit_action_stnd_se" || this.currentAnimClip == "action_stnd_se" || this.currentAnimClip == "kneel_se")
    {
      this.dir = WalkController.Direction.SE;
      MonoBehaviour.print((object) "stand_se");
      if (this.sr.flipX)
        this.dir = WalkController.Direction.SW;
      if (!this.suit)
        this.gameObject.GetComponent<Animator>().Play("stand_se", 0);
      else
        this.gameObject.GetComponent<Animator>().Play("suit_stand_se", 0);
      this.sr.flipX = this.dir == WalkController.Direction.SW;
    }
    if (!(this.currentAnimClip == "suit_action_stnd_s") && !(this.currentAnimClip == "action_stnd_s") && !(this.currentAnimClip == "kneel_s"))
      return;
    this.dir = WalkController.Direction.S;
    MonoBehaviour.print((object) "stand_s");
    if (!this.suit)
      this.animator.Play("stand_s", 0);
    else
      this.animator.Play("suit_stand_s", 0);
  }

  public void setShadowOffset(int off) => this.shadowOffsetY = off;

  public void forceAnimationForAnimationEvent(string name) => this.forceAnimation(name);

  public void forceAnimationForAnimationEventFlipped(string name) => this.forceAnimation(name, true);

  public void forceAnimation(string name, bool flip = false, bool useCurrentDir = false, bool makeBusy = true)
  {
    this.currentAnimClip = "none";
    if (useCurrentDir)
    {
      string empty = string.Empty;
      if (this.dir == WalkController.Direction.N)
      {
        empty += "n";
        flip = false;
      }
      else if (this.dir == WalkController.Direction.NE)
      {
        empty += "ne";
        flip = false;
      }
      else if (this.dir == WalkController.Direction.E)
      {
        empty += "e";
        flip = false;
      }
      else if (this.dir == WalkController.Direction.SE)
      {
        empty += "se";
        flip = false;
      }
      else if (this.dir == WalkController.Direction.S)
      {
        empty += "s";
        flip = false;
      }
      else if (this.dir == WalkController.Direction.SW)
      {
        empty += "se";
        flip = true;
      }
      else if (this.dir == WalkController.Direction.W)
      {
        empty += "e";
        flip = true;
      }
      else if (this.dir == WalkController.Direction.NW)
      {
        empty += "ne";
        flip = true;
      }
      name += empty;
    }
    if (this.suit)
      name = "suit_" + name;
    MonoBehaviour.print((object) ("FORCING ANIMATION " + name));
    if (makeBusy)
      PlayerController.pc.setBusy(true);
    this.animator.Play(name, 0);
    this.sr.flipX = flip;
  }

  public void playSound(AudioClip ac) => PlayerController.pc.aS.PlayOneShot(ac);

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Plus))
    {
      if ((double) this.MAX_SPEED + 2.5 <= 37.5)
      {
        this.MAX_SPEED += 2.5f;
        float num = this.MAX_SPEED / 2.5f;
        PlayerController.pc.textField.viewText("Текущая скорость: x" + Convert.ToString(num) + ".0", true);
      }
      else
        PlayerController.pc.textField.viewText("Достигнута максимальная скорость.", true);
    }
    else if (Input.GetKeyDown(KeyCode.Minus))
    {
      if ((double) this.MAX_SPEED - 2.5 > 2.0)
      {
        this.MAX_SPEED -= 2.5f;
        float num = this.MAX_SPEED / 2.5f;
        PlayerController.pc.textField.viewText("Текущая скорость: x" + Convert.ToString(num) + ".0", true);
      }
      else
        PlayerController.pc.textField.viewText("Достигнута минимальная скорость.", true);
    }
    this.dustPart.started = false;
    float num1 = Time.deltaTime;
    if ((double) num1 > 0.0299999993294477)
      num1 = 0.03f;
    if ((double) CurtainController.cc.targetAlpha == 1.0)
      this.busy = true;
    PlayerController.pc.aS.volume = (double) this.currentXY.y >= 0.0 ? 1f : (float) (1.0 + (double) this.currentXY.y / 100.0);
    if ((double) this.currentXY.x < -5.0)
    {
      PlayerController.pc.aS.panStereo = 0.0f;
      SoundsManagerController.sm.auxASPlayer.panStereo = 0.0f;
    }
    else
    {
      PlayerController.pc.aS.panStereo = (float) (-(120.0 - (double) this.currentXY.x) / 120.0);
      SoundsManagerController.sm.auxASPlayer.panStereo = (float) (-(120.0 - (double) this.currentXY.x) / 120.0);
    }
    this.currentSpeed.x = 0.0f;
    this.currentSpeed.y = 0.0f;
    if ((double) this.targetXY.x == (double) this.currentXY.x && (double) this.targetXY.y == (double) this.currentXY.y && this.path.Count > 0)
    {
      this.targetXY = this.path[0];
      this.path.RemoveAt(0);
    }
    float num2 = 1f / 1000f;
    if ((double) Mathf.Abs(this.currentXY.x - this.targetXY.x) > (double) this.speed * (double) num1 * (double) num2 * (double) this.speedMultip || (double) Mathf.Abs(this.currentXY.y - this.targetXY.y) > (double) this.speed * (double) num1 * (double) num2 * (double) this.speedMultip)
    {
      if ((double) this.currentXY.x - (double) this.speed * (double) num1 * (double) num2 * (double) this.speedMultip >= (double) this.targetXY.x)
        this.currentSpeed.x = -this.speed * this.speedMultip;
      if ((double) this.currentXY.x + (double) this.speed * (double) num1 * (double) num2 * (double) this.speedMultip <= (double) this.targetXY.x)
        this.currentSpeed.x = this.speed * this.speedMultip;
      if ((double) this.currentXY.y - (double) this.speed * (double) num1 * (double) num2 * (double) this.speedMultip >= (double) this.targetXY.y)
        this.currentSpeed.y = -this.speed * this.speedMultip;
      if ((double) this.currentXY.y + (double) this.speed * (double) num1 * (double) num2 * (double) this.speedMultip <= (double) this.targetXY.y)
        this.currentSpeed.y = this.speed * this.speedMultip;
      if ((double) this.currentSpeed.x != 0.0 && (double) this.currentSpeed.y != 0.0)
      {
        this.currentSpeed.x /= 1.2f;
        this.currentSpeed.y /= 1.2f;
      }
    }
    if ((double) this.currentSpeed.x == 0.0)
    {
      this.currentXY.x = Mathf.Floor(this.currentXY.x);
      this.targetXY.x = this.currentXY.x;
    }
    if ((double) this.currentSpeed.y == 0.0)
    {
      this.currentXY.y = Mathf.Floor(this.currentXY.y);
      this.targetXY.y = this.currentXY.y;
    }
    if ((double) this.currentSpeed.x == 0.0 && (double) this.currentSpeed.y == 0.0)
      PlayerController.wc.speedMultip = 1f;
    if (this.autoAction != null || !this.busy || this.letOneMoreAnimationBeforeBusy > 0 && this.currentAnimClip.IndexOf("stand") != -1)
    {
      string str1 = "stand_s";
      if (this.suit)
      {
        string str2 = "suit_" + str1;
      }
      bool flag1 = this.sr.flipX;
      if (this.letOneMoreAnimationBeforeBusy > 0)
        --this.letOneMoreAnimationBeforeBusy;
      if ((double) this.currentSpeed.x == 0.0 && (double) this.currentSpeed.y > 0.0)
        this.dir = WalkController.Direction.N;
      else if ((double) this.currentSpeed.x > 0.0 && (double) this.currentSpeed.y > 0.0)
        this.dir = WalkController.Direction.NE;
      else if ((double) this.currentSpeed.x > 0.0 && (double) this.currentSpeed.y == 0.0)
        this.dir = WalkController.Direction.E;
      else if ((double) this.currentSpeed.x > 0.0 && (double) this.currentSpeed.y < 0.0)
        this.dir = WalkController.Direction.SE;
      else if ((double) this.currentSpeed.x == 0.0 && (double) this.currentSpeed.y < 0.0)
        this.dir = WalkController.Direction.S;
      else if ((double) this.currentSpeed.x < 0.0 && (double) this.currentSpeed.y < 0.0)
        this.dir = WalkController.Direction.SW;
      else if ((double) this.currentSpeed.x < 0.0 && (double) this.currentSpeed.y == 0.0)
        this.dir = WalkController.Direction.W;
      else if ((double) this.currentSpeed.x < 0.0 && (double) this.currentSpeed.y > 0.0)
        this.dir = WalkController.Direction.NW;
      if (this.dir == WalkController.Direction.N && (this.previousDir == WalkController.Direction.NE || this.previousDir == WalkController.Direction.NW) || this.dir == WalkController.Direction.NE && (this.previousDir == WalkController.Direction.N || this.previousDir == WalkController.Direction.E) || this.dir == WalkController.Direction.E && (this.previousDir == WalkController.Direction.NE || this.previousDir == WalkController.Direction.SE) || this.dir == WalkController.Direction.SE && (this.previousDir == WalkController.Direction.E || this.previousDir == WalkController.Direction.S) || this.dir == WalkController.Direction.S && (this.previousDir == WalkController.Direction.SE || this.previousDir == WalkController.Direction.SW) || this.dir == WalkController.Direction.SW && (this.previousDir == WalkController.Direction.W || this.previousDir == WalkController.Direction.S) || this.dir == WalkController.Direction.W && (this.previousDir == WalkController.Direction.NW || this.previousDir == WalkController.Direction.SW) || this.dir == WalkController.Direction.NW && (this.previousDir == WalkController.Direction.N || this.previousDir == WalkController.Direction.W))
      {
        if (this.dirChangeDelay >= 10)
          this.dirChangeDelay = 0;
        else
          this.dir = this.previousDir;
      }
      if (this.dirChangeDelay < 15)
        ++this.dirChangeDelay;
      if (this.dir != this.previousDir)
        this.dirChangeDelay = 0;
      this.previousDir = this.dir;
      this.dustPart.started = false;
      string str3;
      if (((double) this.currentSpeed.x != 0.0 || (double) this.currentSpeed.y != 0.0) && this.waitOneFrameBeforeWalking)
      {
        str3 = "walk_";
        if (this.suit)
          str3 = "suit_" + str3;
        this.walkedBefore = true;
        if ((double) this.speed != (double) this.MAX_SPEED)
          this.speedMultip = 1f;
        if ((double) this.speedMultip > 1.0 && (double) this.speed == (double) this.MAX_SPEED)
        {
          str3 = "run_";
          this.dustPart.started = true;
        }
      }
      else if (((double) this.currentSpeed.x != 0.0 || (double) this.currentSpeed.y != 0.0) && !this.waitOneFrameBeforeWalking)
      {
        this.waitOneFrameBeforeWalking = true;
        str3 = "stand_";
        if (this.suit)
          str3 = "suit_" + str3;
        if (this.dir == WalkController.Direction.E)
          this.dir = WalkController.Direction.SE;
        if (this.dir == WalkController.Direction.W)
          this.dir = WalkController.Direction.SW;
      }
      else if (this.walkedBefore)
      {
        this.walkedBefore = false;
        str3 = "stand_";
        if (this.suit)
          str3 = "suit_" + str3;
        if (this.dir == WalkController.Direction.E)
          this.dir = WalkController.Direction.SE;
        if (this.dir == WalkController.Direction.W)
          this.dir = WalkController.Direction.SW;
      }
      else
      {
        this.waitOneFrameBeforeWalking = false;
        this.walkedBefore = false;
        str3 = "stand_";
        if (this.suit)
          str3 = "suit_" + str3;
        if (this.dir == WalkController.Direction.E)
          this.dir = WalkController.Direction.SE;
        if (this.dir == WalkController.Direction.W)
          this.dir = WalkController.Direction.SW;
      }
      string empty = string.Empty;
      if (this.dir == WalkController.Direction.N)
      {
        empty += "n";
        flag1 = false;
      }
      else if (this.dir == WalkController.Direction.NE)
      {
        empty += "ne";
        flag1 = false;
      }
      else if (this.dir == WalkController.Direction.E)
      {
        empty += "e";
        flag1 = false;
      }
      else if (this.dir == WalkController.Direction.SE)
      {
        empty += "se";
        flag1 = false;
      }
      else if (this.dir == WalkController.Direction.S)
      {
        empty += "s";
        flag1 = false;
      }
      else if (this.dir == WalkController.Direction.SW)
      {
        empty += "se";
        flag1 = true;
      }
      else if (this.dir == WalkController.Direction.W)
      {
        empty += "e";
        flag1 = true;
      }
      else if (this.dir == WalkController.Direction.NW)
      {
        empty += "ne";
        flag1 = true;
      }
      string stateName = str3 + empty;
      if (this.path != null && (this.path.Count > 0 && (double) LocationManager.dist(this.currentXY, this.path[this.path.Count - 1]) < (double) this.range || this.path.Count == 0 && (double) LocationManager.dist(this.currentXY, this.targetXY) < (double) this.range))
      {
        this.path = new List<Vector2>();
        this.fullStop();
        stateName = "stand_" + empty;
        if (this.suit)
          stateName = "suit_" + stateName;
      }
      if (this.path.Count == 0 && (double) this.currentSpeed.x == 0.0 && (double) this.currentSpeed.y == 0.0 && (double) this.targetXY.x == (double) this.currentXY.x && (double) this.targetXY.y == (double) this.currentXY.y && (((UnityEngine.Object) this.onFinishWalking != (UnityEngine.Object) null || (UnityEngine.Object) this.onFinishWalking0 != (UnityEngine.Object) null) && !this.busy || this.autoAction != null))
      {
        if (!this.waitedOneFrameBeforeAction)
        {
          this.letOneMoreAnimationBeforeBusy = 1;
          this.waitedOneFrameBeforeAction = true;
        }
        else if ((UnityEngine.Object) this.onFinishWalking0 != (UnityEngine.Object) null)
        {
          this.onFinishWalking0.clickAction0();
          this.onFinishWalking0 = (ObjectActionController) null;
        }
        else if ((UnityEngine.Object) this.onFinishWalking != (UnityEngine.Object) null)
        {
          MonoBehaviour.print((object) "COMMENCING ACTION!");
          this.busy = true;
          if (!this.onFinishWalking.characterAnimationName.Equals(string.Empty) && !this.onFinishWalking.characterAnimationName.Equals("stop"))
          {
            string characterAnimationName = this.onFinishWalking.characterAnimationName;
            if (this.onFinishWalking.useCurrentDirection)
              characterAnimationName += empty;
            this.currentAnimClip = characterAnimationName;
            MonoBehaviour.print((object) ("!Attempting to play: " + characterAnimationName));
            this.gameObject.GetComponent<Animator>().Play(characterAnimationName, 0);
            if (!this.onFinishWalking.useCurrentDirection)
              flag1 = this.onFinishWalking.animationFlip;
          }
          else
          {
            if (!this.onFinishWalking.characterAnimationName.Equals("stop"))
              this.animationEnd();
            if (!this.onFinishWalking.useCurrentDirection)
              flag1 = this.onFinishWalking.animationFlip;
            this.gameObject.GetComponent<Animator>().enabled = false;
            this.currentAnimClip = "none";
            this.onFinishWalking.clickAction();
            this.onFinishWalking = (ObjectActionController) null;
          }
        }
        else if (this.autoAction != null)
        {
          this.fullStop();
          this.autoAction();
          this.autoAction = (WalkController.Delegate) null;
        }
      }
      if (this.currentAnimClip != stateName && (double) this.speed * (double) this.speedMultip > 0.00999999977648258 && stateName != this.currentAnimClip && (!this.busy || this.letOneMoreAnimationBeforeBusy > 0))
      {
        this.gameObject.GetComponent<Animator>().enabled = true;
        bool flag2 = false;
        if (this.currentAnimClip.IndexOf("walk") == -1 || this.currentAnimClip.IndexOf("stand") == -1)
          flag2 = true;
        this.currentAnimClip = stateName;
        float normalizedTime = this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (flag2)
          normalizedTime = 0.0f;
        this.gameObject.GetComponent<Animator>().Play(stateName, 0, normalizedTime);
      }
      this.sr.flipX = flag1;
    }
    float num3 = num1 * 10f;
    this.currentXY.x += this.currentSpeed.x * num3;
    this.currentXY.y += this.currentSpeed.y * num3;
    Vector2 vectorToChange = new Vector2();
    float z = this.gameObject.transform.position.z;
    vectorToChange.x = this.currentXY.x;
    vectorToChange.y = this.currentXY.y + (float) this.offsetY;
    vectorToChange = ScreenControler.gameToScreen(vectorToChange);
    this.currentXY_screen_rounded = new Vector3(vectorToChange.x, vectorToChange.y, this.gameObject.transform.position.z);
    this.currentXY_screen_rounded.z = Camera.main.WorldToScreenPoint(this.gameObject.transform.position).z;
    this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(this.currentXY_screen_rounded);
    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, z);
    if ((double) Mathf.Abs(this.currentXY.x - this.targetXY.x) < 1.0)
      this.currentXY.x = this.targetXY.x;
    if ((double) Mathf.Abs(this.currentXY.y - this.targetXY.y) < 1.0)
      this.currentXY.y = this.targetXY.y;
    this.shadow.update(this.currentXY_screen_rounded, this.currentXY, this.shadowOffsetY);
  }

  public void forceDirection(WalkController.Direction d)
  {
    this.dir = d;
    this.previousDir = d;
    this.dirChangeDelay = 9999;
  }

  public void fullStop(bool abortTargetAction = false, bool playStandAnimation = true, bool forceStandAnimation = false)
  {
    if (abortTargetAction)
    {
      MonoBehaviour.print((object) "ABORTING ACTION");
      this.onFinishWalking = (ObjectActionController) null;
      this.onFinishWalking0 = (ObjectActionController) null;
      this.onFinishWalking2 = (ObjectActionController) null;
    }
    this.currentSpeed.x = 0.0f;
    this.currentXY.x = Mathf.Floor(this.currentXY.x);
    this.targetXY.x = this.currentXY.x;
    this.currentSpeed.y = 0.0f;
    this.currentXY.y = Mathf.Floor(this.currentXY.y);
    this.targetXY.y = this.currentXY.y;
    if (forceStandAnimation || (this.currentAnimClip.IndexOf("walk_") != -1 || this.currentAnimClip.IndexOf("run_") != -1) && playStandAnimation)
      this.forceAnimation("stand_", useCurrentDir: true, makeBusy: false);
    this.path = new List<Vector2>();
  }

  public void playIdleAnimation(string animationName)
  {
    float num1 = 0.0f;
    float num2 = 0.0f;
    float num3 = 0.0f;
    if (animationName == "stand_se")
    {
      num1 = 3f;
      num2 = 8f;
      num3 = 14f;
    }
    float num4 = UnityEngine.Random.Range(0.0f, 1f);
    float num5 = (double) num4 <= 0.819999992847443 ? ((double) num4 <= 0.660000026226044 ? ((double) num4 <= 0.5 ? 0.0f : num3) : num2) : num1;
    if ((double) this.lastIdle == (double) num5 || this.busy || PlayerController.pc.dialogue != PlayerController.DialogueState.NONE)
    {
      this.lastIdle = -1f;
      num5 = 0.0f;
    }
    else
      this.lastIdle = num5;
    if (!this.busy && !this.suit)
    {
      this.gameObject.GetComponent<Animator>().Play(animationName, 0, num5 / this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
    else
    {
      if (!this.suit)
        return;
      this.gameObject.GetComponent<Animator>().Play("suit_stand_se");
    }
  }

  public delegate void Delegate();

  public enum Direction
  {
    N,
    NE,
    E,
    SE,
    S,
    SW,
    W,
    NW,
    NULL,
  }
}
