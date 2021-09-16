// Decompiled with JetBrains decompiler
// Type: PlayerController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public LayerMask blockingLayer;
  public bool clickedSomething;
  public bool clickedAlreadyForSomething;
  private BoxCollider2D boxCollider;
  private Rigidbody2D rb2D;
  public float SKEWFY;
  public PlayerController.DialogueState dialogue;
  private GameObject currentDialogue;
  public string spawnName;
  public bool antiSoftLock = true;
  public TextFieldController textField;
  public AudioSource aS;
  public static PlayerController pc;
  public static WalkController wc;
  public static StepSoundGenerator ssg;
  public bool npcShouldAppearRightOnSpot;
  public LocationManager currentLocationManager;
  public bool allowDrop = true;
  private Vector2 prevTargetClick;
  private float runTimeout;
  private SpriteRenderer sr;
  private int softlockProbe;
  private float softlockTimer;

  private void Awake()
  {
    if ((Object) PlayerController.pc == (Object) null)
    {
      Object.DontDestroyOnLoad((Object) this.gameObject);
      PlayerController.pc = this;
      PlayerController.wc = this.gameObject.GetComponent<WalkController>();
      PlayerController.ssg = this.gameObject.GetComponent<StepSoundGenerator>();
      MonoBehaviour.print((object) "INITIALIZING PLAYER ");
    }
    else
    {
      if (!((Object) PlayerController.pc != (Object) this))
        return;
      Object.Destroy((Object) this.gameObject);
    }
  }

  private void Start()
  {
    GameStrings.readStrings(PlayerPrefs.GetString("lang", GameStrings.Language.EN.ToString()));
    this.npcShouldAppearRightOnSpot = false;
    this.textField = this.gameObject.GetComponent<TextFieldController>();
    this.textField.transform.parent = this.gameObject.transform;
    this.textField.container.transform.parent = PlayerController.pc.gameObject.transform;
    this.aS = this.gameObject.GetComponent<AudioSource>();
    this.currentLocationManager = (LocationManager) null;
    this.sr = this.GetComponent<SpriteRenderer>();
  }

  public void say(string txt) => this.textField.viewText(txt, true, mwidth: 150);

  public void sayLine(string txt) => Timeline.t.addAction(new TimelineAction()
  {
    textfield = PlayerController.pc.textField,
    text = txt,
    actionWithText = false
  });

  public void copySettingsToNPCs()
  {
    NPCWalkController[] objectsOfType = (NPCWalkController[]) Object.FindObjectsOfType(typeof (NPCWalkController));
    for (int index = 0; index < objectsOfType.Length; ++index)
    {
      objectsOfType[index].shadow.fadeRateV = PlayerController.wc.shadow.fadeRateV;
      objectsOfType[index].shadow.fadeRateH = PlayerController.wc.shadow.fadeRateH;
      objectsOfType[index].shadow.skewFactor = PlayerController.wc.shadow.skewFactor;
      objectsOfType[index].shadow.skewFactor2 = PlayerController.wc.shadow.skewFactor2;
      objectsOfType[index].shadow.startAlpha = PlayerController.wc.shadow.startAlpha;
      objectsOfType[index].shadow.source = PlayerController.wc.shadow.source;
      objectsOfType[index].shadow.scaleFactor = PlayerController.wc.shadow.scaleFactor;
      objectsOfType[index].shadowOffsetY = PlayerController.wc.shadowOffsetY;
      objectsOfType[index].shadow.downwards = PlayerController.wc.shadow.downwards;
      objectsOfType[index].gameObject.GetComponent<StepSoundGenerator>().setStepType2(PlayerController.ssg.selectedStepsType, PlayerController.pc.GetComponent<AudioReverbFilter>().reverbPreset);
    }
  }

  public void setDialogue(GameObject target)
  {
    this.currentDialogue = target;
    this.dialogue = PlayerController.DialogueState.WAIT_TO_SPEED;
    this.setBusy(true);
  }

  public void setBusy(bool busy)
  {
    if (!busy && QuestionController.qc.gameObject.activeSelf || (busy || !Timeline.t.isSafeToChangeBusy() || ExamineSprite.es.Active) && !busy)
      return;
    if (!busy)
      GameDataController.gd.saveIfOK(string.Empty);
    this.gameObject.GetComponent<WalkController>().busy = busy;
  }

  public void forceAnimation(string name)
  {
    PlayerController.pc.setBusy(false);
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.forceAnimation(name);
  }

  public void haltSoftLockProbe() => this.antiSoftLock = false;

  public void resumeSoftLockProbe() => this.antiSoftLock = true;

  private void Update()
  {
    if (this.antiSoftLock)
    {
      this.softlockTimer += Time.deltaTime;
      if ((double) this.softlockTimer > 2.0)
      {
        this.softlockTimer = 0.0f;
        if (PlayerController.wc.busy)
        {
          if ((double) PlayerController.wc.currentXY.x >= 0.0 && (double) PlayerController.wc.currentXY.x <= 240.0 && (double) PlayerController.wc.currentXY.y >= 0.0 && (double) PlayerController.wc.currentXY.y <= 135.0 && (PlayerController.wc.animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.IndexOf("stand") != -1 || this.sr.sprite.name.IndexOf("stand") != -1) && this.dialogue == PlayerController.DialogueState.NONE && (Timeline.t.actions == null || Timeline.t.actions != null && Timeline.t.actions.Count == 0) && (double) CurtainController.cc.targetAlpha == (double) CurtainController.cc.getAlpha() && DialogueController.dc.hidden && !ExamineSprite.es.Active && ((Object) GameObject.Find("Ginger") == (Object) null || (double) GameObject.Find("Ginger").GetComponent<NPCWalkController>().currentXY.x == (double) GameObject.Find("Ginger").GetComponent<NPCWalkController>().getTargetXY().x && (double) GameObject.Find("Ginger").GetComponent<NPCWalkController>().currentXY.y == (double) GameObject.Find("Ginger").GetComponent<NPCWalkController>().getTargetXY().y) && ((Object) GameObject.Find("Npc2") == (Object) null || (double) GameObject.Find("Npc2").GetComponent<NPCWalkController>().currentXY.x == (double) GameObject.Find("Npc2").GetComponent<NPCWalkController>().getTargetXY().x && (double) GameObject.Find("Npc2").GetComponent<NPCWalkController>().currentXY.y == (double) GameObject.Find("Npc2").GetComponent<NPCWalkController>().getTargetXY().y) && ((Object) GameObject.Find("Npc3") == (Object) null || (double) GameObject.Find("Npc3").GetComponent<NPCWalkController>().currentXY.x == (double) GameObject.Find("Npc3").GetComponent<NPCWalkController>().getTargetXY().x && (double) GameObject.Find("Npc3").GetComponent<NPCWalkController>().currentXY.y == (double) GameObject.Find("Npc3").GetComponent<NPCWalkController>().getTargetXY().y))
          {
            if (this.softlockProbe == 0)
            {
              MonoBehaviour.print((object) "Softlock| softlockProbe = 1");
              this.softlockProbe = 1;
            }
            else
            {
              Debug.LogWarning((object) "Softlock| PROBABLE SOFTLOCK DETECTED - SETTING BUSY TO FALSE");
              this.softlockProbe = 0;
              this.setBusy(false);
            }
          }
        }
        else
          this.softlockProbe = 0;
      }
    }
    Vector2 mousePosition = (Vector2) Input.mousePosition;
    this.clickedAlreadyForSomething = false;
    if (!DialogueController.dc.hidden)
      return;
    if (Input.GetMouseButtonDown(0))
    {
      if ((Object) this.currentLocationManager == (Object) null)
      {
        this.currentLocationManager = GameObject.Find("Location").GetComponent<LocationManager>();
        MonoBehaviour.print((object) ("LOADED LOCATION MANAGER: " + (object) this.currentLocationManager));
      }
      this.clickedAlreadyForSomething = true;
      if (this.dialogue == PlayerController.DialogueState.WAIT_TO_SPEED && !this.clickedSomething && CurtainController.cc.okToGo())
      {
        this.dialogue = PlayerController.DialogueState.WAIT_TO_DISMISS;
        this.currentDialogue.GetComponent<TextFieldController>().speedUp();
        this.setBusy(true);
      }
      else if (this.dialogue == PlayerController.DialogueState.WAIT_TO_DISMISS && !this.clickedSomething && CurtainController.cc.okToGo())
      {
        this.dialogue = PlayerController.DialogueState.NONE;
        this.currentDialogue.GetComponent<TextFieldController>().terminate();
        this.setBusy(false);
        GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>().clearOverride();
      }
      else if (!this.clickedSomething && ExamineSprite.es.Active && CurtainController.cc.okToGo())
      {
        ExamineSprite.es.hide();
        this.clickedSomething = true;
      }
      else if (!this.clickedSomething && !this.gameObject.GetComponent<WalkController>().busy && CurtainController.cc.okToGo())
      {
        GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>().deselectItem();
        InventoryButtonController.ibc.close();
        Vector2 nearestFullPixelOld = (Vector2) ScreenControler.roundToNearestFullPixelOld((Vector3) ScreenControler.screenToGame(mousePosition));
        PlayerController.wc.setTarget(this.currentLocationManager.Search2(this.currentLocationManager.getNodeLocation(PlayerController.wc.currentXY), this.currentLocationManager.findNearestClearNode(this.currentLocationManager.getNodeLocation(nearestFullPixelOld))));
        this.gameObject.GetComponent<WalkController>().onFinishWalking = (ObjectActionController) null;
        this.gameObject.GetComponent<WalkController>().onFinishWalking0 = (ObjectActionController) null;
        this.gameObject.GetComponent<WalkController>().onFinishWalking2 = (ObjectActionController) null;
        PlayerController.wc.speedMultip = (double) PlayerController.wc.speedMultip > 1.0 || ((double) PlayerController.wc.currentSpeed.x != 0.0 || (double) PlayerController.wc.currentSpeed.y != 0.0) && (double) ScreenControler.distance(nearestFullPixelOld, this.prevTargetClick) < 10.0 ? 2f : 1f;
        this.prevTargetClick = nearestFullPixelOld;
        this.runTimeout = 1f;
      }
      this.clickedSomething = false;
    }
    else if ((double) this.runTimeout > 0.0)
    {
      this.runTimeout -= Time.deltaTime;
      if ((double) this.runTimeout <= 0.0)
        this.prevTargetClick = new Vector2();
    }
    if (!Input.GetMouseButtonDown(1))
      return;
    GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>().deselectItem();
  }

  public void interruptDialogueProbablyToKillPlayer()
  {
    PlayerController.pc.textField.dissmiss(true);
    PlayerController.pc.dialogue = PlayerController.DialogueState.NONE;
    GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>().deselectItem();
    GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>().clearOverride();
    InventoryButtonController.ibc.close();
  }

  public enum DialogueState
  {
    NONE,
    WAIT_TO_SPEED,
    WAIT_TO_DISMISS,
  }
}
