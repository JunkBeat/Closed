// Decompiled with JetBrains decompiler
// Type: NPCWalkController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class NPCWalkController : MonoBehaviour
{
  private Vector2 targetXY;
  private AudioSource audioSource;
  public float colorGreen = 1f;
  public float colorRed = 1f;
  public float colorBlue = 1f;
  public float colorAlpha = 1f;
  public int range = 1;
  public LayerMask blockingLayer;
  public bool pathRestricted;
  public Vector2 currentXY;
  private Vector3 currentXY_screen_rounded;
  private Vector2 currentSpeed;
  private Vector2 previousXY;
  private Vector2 previous2XY;
  private bool walkedBefore;
  public bool busy;
  public bool spawned;
  private Vector2 actionTargetXY;
  private List<Vector2> path;
  private bool waitOneFrameBeforeWalking;
  public int offsetY;
  public ObjectActionController onFinishWalking0;
  public ObjectActionController onFinishWalking;
  public ObjectActionController onFinishWalking2;
  public bool waitedOneFrameBeforeAction;
  public TextFieldController textfield;
  private float lastIdle;
  public int letOneMoreAnimationBeforeBusy;
  public SpriteShadow shadow;
  public int shadowOffsetY;
  public NPCWalkController.Direction dir;
  private NPCWalkController.Direction previousDir;
  private int dirChangeDelay;
  private BoxCollider2D bc2d;
  private string currentAnimClip = string.Empty;
  public float speed = 2.5f;
  public float MAX_SPEED = 2.5f;
  private GameObject tlo;
  public bool clickable = true;

  private void Start()
  {
    this.path = new List<Vector2>();
    Camera.main.orthographicSize = 0.625f;
    this.targetXY = new Vector2(this.currentXY.x, this.currentXY.y);
    this.actionTargetXY = new Vector2(this.currentXY.x, this.currentXY.y);
    this.currentXY_screen_rounded = new Vector3(0.0f, 0.0f, 0.0f);
    this.currentSpeed = new Vector2(0.0f, 0.0f);
    this.shadow = new SpriteShadow(this.gameObject);
    this.shadow.startAlpha = 0.5f;
    this.shadow.fadeRateV = 0.009f;
    this.shadow.fadeRateH = 0.004f;
    this.shadowOffsetY = 0;
    this.previousXY = new Vector2();
    this.previous2XY = new Vector2();
    this.spawned = false;
  }

  public Vector2 getTargetXY() => this.targetXY;

  public void setFlipped(bool f) => this.gameObject.GetComponent<SpriteRenderer>().flipX = f;

  public bool flipped() => this.gameObject.GetComponent<SpriteRenderer>().flipX;

  public string getCurrentAnimClip() => this.currentAnimClip;

  public void setTargetV3(Vector3 targetPosition)
  {
    LocationManager component = GameObject.Find("Location").GetComponent<LocationManager>();
    List<Vector2> newTarget = component.Search2(component.findNearestClearNode(component.getNodeLocation(this.currentXY)), component.findNearestClearNode(component.getNodeLocation((Vector2) ScreenControler.roundToNearestFullPixel(targetPosition))));
    newTarget.Insert(0, this.currentXY);
    this.setTarget(newTarget);
  }

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

  public void setTextFieldY(int y)
  {
    if ((Object) this.textfield == (Object) null)
      this.textfield = this.gameObject.GetComponent<TextFieldController>();
    this.textfield.shift.y = (float) y;
  }

  public void playSound(AudioClip ac) => this.gameObject.GetComponent<AudioSource>().PlayOneShot(ac);

  public void setSimpleTargetV3(Vector3 newTarget) => this.setSimpleTarget((Vector2) ScreenControler.roundToNearestFullPixel(newTarget));

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
    if (!((Object) this.onFinishWalking != (Object) null))
      return;
    this.onFinishWalking.clickAction0();
  }

  public void animationAction()
  {
    if ((Object) this.onFinishWalking != (Object) null)
      this.onFinishWalking.clickAction();
    this.onFinishWalking = (ObjectActionController) null;
  }

  public void otherAnimationAction()
  {
    if ((Object) this.onFinishWalking2 != (Object) null)
      this.onFinishWalking2.clickAction2();
    this.onFinishWalking2 = (ObjectActionController) null;
  }

  public void setBusy(bool b) => this.busy = b;

  public void animationEnd()
  {
    this.setBusy(false);
    this.shadowOffsetY = 0;
    if (this.currentAnimClip == "action_stnd_n" || this.currentAnimClip == "kneel_n")
    {
      this.dir = NPCWalkController.Direction.N;
      this.gameObject.GetComponent<Animator>().Play("stand_n", 0);
    }
    if (this.currentAnimClip == "action_stnd_ne" || this.currentAnimClip == "kneel_ne")
    {
      this.dir = NPCWalkController.Direction.NE;
      if (this.gameObject.GetComponent<SpriteRenderer>().flipX)
        this.dir = NPCWalkController.Direction.NW;
      this.gameObject.GetComponent<Animator>().Play("stand_ne", 0);
    }
    if (this.currentAnimClip == "action_stnd_e" || this.currentAnimClip == "kneel_e")
    {
      this.dir = NPCWalkController.Direction.E;
      if (this.gameObject.GetComponent<SpriteRenderer>().flipX)
        this.dir = NPCWalkController.Direction.W;
      this.gameObject.GetComponent<Animator>().Play("stand_e", 0);
    }
    if (this.currentAnimClip == "action_stnd_se" || this.currentAnimClip == "kneel_se")
    {
      this.dir = NPCWalkController.Direction.SE;
      if (this.gameObject.GetComponent<SpriteRenderer>().flipX)
        this.dir = NPCWalkController.Direction.SW;
      this.gameObject.GetComponent<Animator>().Play("stand_se", 0);
      if (this.dir == NPCWalkController.Direction.SW)
        this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
      else
        this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }
    if (!(this.currentAnimClip == "action_stnd_s") && !(this.currentAnimClip == "kneel_s"))
      return;
    this.dir = NPCWalkController.Direction.S;
    this.gameObject.GetComponent<Animator>().Play("stand_s", 0);
  }

  public void setShadowOffset(int off) => this.shadowOffsetY = off;

  public void forceAnimationForAnimationEvent(string name) => this.forceAnimation(name, this.gameObject.GetComponent<SpriteRenderer>().flipX);

  public void forceAnimationForAnimationEvent2(string name, bool flip) => this.forceAnimation(name, flip);

  public void forceAnimation(string name, bool flip = false, bool useCurrentDir = false, bool makeBusy = true)
  {
    this.currentAnimClip = "none";
    if (useCurrentDir)
    {
      string empty = string.Empty;
      if (this.dir == NPCWalkController.Direction.N)
      {
        empty += "n";
        flip = false;
      }
      else if (this.dir == NPCWalkController.Direction.NE)
      {
        empty += "ne";
        flip = false;
      }
      else if (this.dir == NPCWalkController.Direction.E)
      {
        empty += "e";
        flip = false;
      }
      else if (this.dir == NPCWalkController.Direction.SE)
      {
        empty += "se";
        flip = false;
      }
      else if (this.dir == NPCWalkController.Direction.S)
      {
        empty += "s";
        flip = false;
      }
      else if (this.dir == NPCWalkController.Direction.SW)
      {
        empty += "se";
        flip = true;
      }
      else if (this.dir == NPCWalkController.Direction.W)
      {
        empty += "e";
        flip = true;
      }
      else if (this.dir == NPCWalkController.Direction.NW)
      {
        empty += "ne";
        flip = true;
      }
      name += empty;
    }
    if (makeBusy)
      this.setBusy(true);
    this.gameObject.GetComponent<Animator>().Play(name, 0);
    this.gameObject.GetComponent<SpriteRenderer>().flipX = flip;
  }

  private void Update()
  {
    PlayerController.pc.aS.volume = (double) this.currentXY.y >= 0.0 ? 1f : (float) (1.0 + (double) this.currentXY.y / 100.0);
    this.currentSpeed.x = 0.0f;
    this.currentSpeed.y = 0.0f;
    if ((double) this.targetXY.x == (double) this.currentXY.x && (double) this.targetXY.y == (double) this.currentXY.y && this.path.Count > 0)
    {
      this.targetXY = this.path[0];
      this.path.RemoveAt(0);
    }
    float num1 = 1f / 1000f;
    float num2 = Time.deltaTime;
    if ((double) num2 > 0.0299999993294477)
      num2 = 0.03f;
    if ((double) Mathf.Abs(this.currentXY.x - this.targetXY.x) > (double) this.speed * (double) num2 * (double) num1 || (double) Mathf.Abs(this.currentXY.y - this.targetXY.y) > (double) this.speed * (double) num2 * (double) num1)
    {
      if ((double) this.currentXY.x - (double) this.speed * (double) num2 * (double) num1 >= (double) this.targetXY.x)
        this.currentSpeed.x = -this.speed;
      if ((double) this.currentXY.x + (double) this.speed * (double) num2 * (double) num1 <= (double) this.targetXY.x)
        this.currentSpeed.x = this.speed;
      if ((double) this.currentXY.y - (double) this.speed * (double) num2 * (double) num1 >= (double) this.targetXY.y)
        this.currentSpeed.y = -this.speed;
      if ((double) this.currentXY.y + (double) this.speed * (double) num2 * (double) num1 <= (double) this.targetXY.y)
        this.currentSpeed.y = this.speed;
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
    if ((Object) this.bc2d == (Object) null)
      this.bc2d = this.gameObject.GetComponent<BoxCollider2D>();
    if (!this.clickable || (double) this.currentSpeed.x != 0.0 || (double) this.currentSpeed.y != 0.0)
      this.bc2d.enabled = false;
    else if (this.spawned)
      this.bc2d.enabled = true;
    if (!this.busy)
    {
      bool flag1 = this.gameObject.GetComponent<SpriteRenderer>().flipX;
      if (this.letOneMoreAnimationBeforeBusy > 0)
        --this.letOneMoreAnimationBeforeBusy;
      if ((double) this.currentSpeed.x == 0.0 && (double) this.currentSpeed.y > 0.0)
        this.dir = NPCWalkController.Direction.N;
      else if ((double) this.currentSpeed.x > 0.0 && (double) this.currentSpeed.y > 0.0)
        this.dir = NPCWalkController.Direction.NE;
      else if ((double) this.currentSpeed.x > 0.0 && (double) this.currentSpeed.y == 0.0)
        this.dir = NPCWalkController.Direction.E;
      else if ((double) this.currentSpeed.x > 0.0 && (double) this.currentSpeed.y < 0.0)
        this.dir = NPCWalkController.Direction.SE;
      else if ((double) this.currentSpeed.x == 0.0 && (double) this.currentSpeed.y < 0.0)
        this.dir = NPCWalkController.Direction.S;
      else if ((double) this.currentSpeed.x < 0.0 && (double) this.currentSpeed.y < 0.0)
        this.dir = NPCWalkController.Direction.SW;
      else if ((double) this.currentSpeed.x < 0.0 && (double) this.currentSpeed.y == 0.0)
        this.dir = NPCWalkController.Direction.W;
      else if ((double) this.currentSpeed.x < 0.0 && (double) this.currentSpeed.y > 0.0)
        this.dir = NPCWalkController.Direction.NW;
      if (this.dir == NPCWalkController.Direction.N && (this.previousDir == NPCWalkController.Direction.NE || this.previousDir == NPCWalkController.Direction.NW) || this.dir == NPCWalkController.Direction.NE && (this.previousDir == NPCWalkController.Direction.N || this.previousDir == NPCWalkController.Direction.E) || this.dir == NPCWalkController.Direction.E && (this.previousDir == NPCWalkController.Direction.NE || this.previousDir == NPCWalkController.Direction.SE) || this.dir == NPCWalkController.Direction.SE && (this.previousDir == NPCWalkController.Direction.E || this.previousDir == NPCWalkController.Direction.S) || this.dir == NPCWalkController.Direction.S && (this.previousDir == NPCWalkController.Direction.SE || this.previousDir == NPCWalkController.Direction.SW) || this.dir == NPCWalkController.Direction.SW && (this.previousDir == NPCWalkController.Direction.W || this.previousDir == NPCWalkController.Direction.S) || this.dir == NPCWalkController.Direction.W && (this.previousDir == NPCWalkController.Direction.NW || this.previousDir == NPCWalkController.Direction.SW) || this.dir == NPCWalkController.Direction.NW && (this.previousDir == NPCWalkController.Direction.N || this.previousDir == NPCWalkController.Direction.W))
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
      string str;
      if (((double) this.currentSpeed.x != 0.0 || (double) this.currentSpeed.y != 0.0) && this.waitOneFrameBeforeWalking)
      {
        str = "walk_";
        this.walkedBefore = true;
      }
      else if (((double) this.currentSpeed.x != 0.0 || (double) this.currentSpeed.y != 0.0) && !this.waitOneFrameBeforeWalking)
      {
        this.waitOneFrameBeforeWalking = true;
        str = "stand_";
        if (this.dir == NPCWalkController.Direction.E)
          this.dir = NPCWalkController.Direction.SE;
        if (this.dir == NPCWalkController.Direction.W)
          this.dir = NPCWalkController.Direction.SW;
      }
      else if (this.walkedBefore)
      {
        this.walkedBefore = false;
        str = "walk_";
        if (this.dir == NPCWalkController.Direction.E)
          this.dir = NPCWalkController.Direction.SE;
        if (this.dir == NPCWalkController.Direction.W)
          this.dir = NPCWalkController.Direction.SW;
      }
      else
      {
        this.waitOneFrameBeforeWalking = false;
        this.walkedBefore = false;
        str = "stand_";
        if (this.dir == NPCWalkController.Direction.E)
          this.dir = NPCWalkController.Direction.SE;
        if (this.dir == NPCWalkController.Direction.W)
          this.dir = NPCWalkController.Direction.SW;
      }
      string empty = string.Empty;
      if (str == "stand_")
        this.dir = this.dir == NPCWalkController.Direction.N || this.dir == NPCWalkController.Direction.W || this.dir == NPCWalkController.Direction.SW || this.dir == NPCWalkController.Direction.NW ? NPCWalkController.Direction.SW : NPCWalkController.Direction.SE;
      if (this.dir == NPCWalkController.Direction.N)
      {
        empty += "n";
        flag1 = false;
      }
      else if (this.dir == NPCWalkController.Direction.NE)
      {
        empty += "ne";
        flag1 = false;
      }
      else if (this.dir == NPCWalkController.Direction.E)
      {
        empty += "e";
        flag1 = false;
      }
      else if (this.dir == NPCWalkController.Direction.SE)
      {
        empty += "se";
        flag1 = false;
      }
      else if (this.dir == NPCWalkController.Direction.S)
      {
        empty += "s";
        flag1 = false;
      }
      else if (this.dir == NPCWalkController.Direction.SW)
      {
        empty += "se";
        flag1 = true;
      }
      else if (this.dir == NPCWalkController.Direction.W)
      {
        empty += "e";
        flag1 = true;
      }
      else if (this.dir == NPCWalkController.Direction.NW)
      {
        empty += "ne";
        flag1 = true;
      }
      string stateName = str + empty;
      if (this.path != null && this.path.Count > 0 && (double) LocationManager.dist(this.currentXY, this.path[this.path.Count - 1]) < (double) this.range)
      {
        this.path = new List<Vector2>();
        this.fullStop();
      }
      if (this.path.Count == 0 && (double) this.currentSpeed.x == 0.0 && (double) this.currentSpeed.y == 0.0 && (double) this.targetXY.x == (double) this.currentXY.x && (double) this.targetXY.y == (double) this.currentXY.y && ((Object) this.onFinishWalking != (Object) null || (Object) this.onFinishWalking0 != (Object) null) && !this.busy)
      {
        if (!this.waitedOneFrameBeforeAction)
          this.waitedOneFrameBeforeAction = true;
        else if ((Object) this.onFinishWalking0 != (Object) null)
        {
          this.onFinishWalking0.clickAction0();
          this.onFinishWalking0 = (ObjectActionController) null;
        }
        else if ((Object) this.onFinishWalking != (Object) null)
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
      }
      if (this.currentAnimClip != stateName && (double) this.speed > 0.00999999977648258 && stateName != this.currentAnimClip && (!this.busy || this.letOneMoreAnimationBeforeBusy > 0))
      {
        this.gameObject.GetComponent<Animator>().enabled = true;
        bool flag2 = false;
        if (this.currentAnimClip.IndexOf("walk") == -1 || this.currentAnimClip.IndexOf("stand") == -1)
          flag2 = true;
        this.currentAnimClip = stateName;
        float normalizedTime = this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (flag2)
          normalizedTime = 0.0f;
        MonoBehaviour.print((object) ("Attempting to play: " + stateName + " from " + (object) normalizedTime));
        this.gameObject.GetComponent<Animator>().Play(stateName, 0, normalizedTime);
      }
      this.gameObject.GetComponent<SpriteRenderer>().flipX = flag1;
    }
    float num3 = num2 * 10f;
    if ((double) num3 > (double) this.speed)
      num3 = this.speed;
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
    this.shadow.update(this.currentXY_screen_rounded, this.currentXY, this.shadowOffsetY);
    if ((double) Mathf.Abs(this.currentXY.x - this.targetXY.x) < 1.0)
      this.currentXY.x = this.targetXY.x;
    if ((double) Mathf.Abs(this.currentXY.y - this.targetXY.y) >= 1.0)
      return;
    this.currentXY.y = this.targetXY.y;
  }

  public void updateStateAfterAnimation() => this.gameObject.GetComponent<NPCActionController>().updateState();

  public void setAnimationTargetXY(string coords)
  {
    string[] strArray = coords.Split(';');
    this.targetXY.x = (float) int.Parse(strArray[0]);
    this.targetXY.y = (float) int.Parse(strArray[1]);
  }

  public void forceDirection(NPCWalkController.Direction d)
  {
    this.dir = d;
    this.previousDir = d;
    this.dirChangeDelay = 9999;
  }

  public void fullStop(bool abortTargetAction = false)
  {
    MonoBehaviour.print((object) "FULL STOP");
    if (abortTargetAction)
    {
      MonoBehaviour.print((object) "ABORTING ACTION");
      this.onFinishWalking = (ObjectActionController) null;
    }
    this.currentSpeed.x = 0.0f;
    this.currentXY.x = Mathf.Floor(this.currentXY.x);
    this.targetXY.x = this.currentXY.x;
    this.currentSpeed.y = 0.0f;
    this.currentXY.y = Mathf.Floor(this.currentXY.y);
    this.targetXY.y = this.currentXY.y;
    this.previousXY.x = 9999f;
    this.previousXY.y = 9999f;
    this.previous2XY.x = 9999f;
    this.previous2XY.y = 9999f;
  }

  public void playIdleAnimation(string animationName)
  {
    float num1 = 0.0f;
    float num2 = 0.0f;
    float num3 = 0.0f;
    if (animationName == "barry_stand_se")
    {
      num1 = 3f;
      num2 = 7f;
      num3 = 11f;
      animationName = "stand_se";
    }
    else if (animationName == "barry_mourn")
    {
      num1 = 1f;
      num2 = 3f;
      num3 = 5f;
      animationName = "npc2_mourn";
    }
    else if (animationName == "cody_stand_se")
    {
      num1 = 2f;
      num2 = 5f;
      num3 = 10f;
      animationName = "stand_se";
    }
    else if (animationName == "ginger_stand_se")
    {
      this.gameObject.GetComponent<GingerActionController>().randomLinesTalkOrNot();
      num1 = 2f;
      num2 = 12f;
      num3 = 0.0f;
      animationName = "stand_se";
    }
    float num4 = Random.Range(0.0f, 1f);
    float num5 = (double) num4 <= 0.75 ? ((double) num4 <= 0.5 ? ((double) num4 <= 0.25 ? 0.0f : num3) : num2) : num1;
    if ((double) this.lastIdle == (double) num5 || PlayerController.pc.dialogue != PlayerController.DialogueState.NONE)
    {
      this.lastIdle = -1f;
      num5 = 0.0f;
    }
    else
      this.lastIdle = num5;
    this.gameObject.GetComponent<Animator>().Play(animationName, 0, num5 / this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
  }

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
