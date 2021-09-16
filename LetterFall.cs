// Decompiled with JetBrains decompiler
// Type: LetterFall
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LetterFall : MonoBehaviour
{
  public ParticleGenerator sandMove1;
  public ParticleGenerator sandMove2;
  public ParticleGenerator sandMove3;
  public ParticleGenerator sandMove4;
  public ParticleGenerator sandFall1;
  public ParticleGenerator sandFall2;
  public ParticleGenerator sandFall3;
  public ParticleGenerator sandFall4;
  public ParticleGenerator sandLauch;
  public Npc2Controller barry;
  public NPCWalkController barryW;
  public NPCWalkController codyW;
  public GameObject barryJumpTarget;
  public GameObject barryJumpSource;
  public GameObject playerJumpTarget;
  public GameObject playerJumpSource;
  public AudioSource aS;
  public GameObject codyRunSource;
  public GameObject codyRunTarget;
  public GameObject codyJumpTarget;
  public NPCWalkController gingerW;
  public GameObject gingerJumpSource;
  public GameObject gingerJumpTarget;
  public SpriteRenderer barLow;

  private void Start()
  {
  }

  public void startTalkAfterfall()
  {
    Vector3 color = GingerActionController.getColor();
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    GameObject.Find("Ginger").GetComponent<NPCWalkController>().forceAnimation("stand_ne");
    DialogueController.dc.initDialogue(dialogueLines, "sidereal_afterfall", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
    if (!GameDataController.gd.getObjective("ncp2_alive") && GameDataController.gd.getObjectiveDetail("npc2_alive") == 1)
    {
      dialogueLines[1].text = GameStrings.getString(GameStrings.dialogues, "sidereal_afterfallb_2_a");
      dialogueLines[2].text = GameStrings.getString(GameStrings.dialogues, "sidereal_afterfallb_3_a");
      dialogueLines[9].text = GameStrings.getString(GameStrings.dialogues, "sidereal_afterfallb_10_a");
    }
    dialogueLines[1].action = new TimelineFunction(this.kneel);
    dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.kneelEnd);
    Timeline.t.doNotUnlock = true;
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    Timeline.t.doNotUnlock = true;
  }

  private void kneel(string a = "")
  {
    if (!GameDataController.gd.getObjective("ncp2_alive") && GameDataController.gd.getObjectiveDetail("npc2_alive") == 1)
      PlayerController.wc.forceAnimation("kneel_e_in", true);
    else
      PlayerController.wc.forceAnimation("kneel_se_in", true);
  }

  private void kneelEnd(string a = "")
  {
    MonoBehaviour.print((object) "WSTAJEMY");
    Timeline.t.doNotUnlock = true;
    PlayerController.pc.setBusy(true);
    if (!GameDataController.gd.getObjective("ncp2_alive") && GameDataController.gd.getObjectiveDetail("npc2_alive") == 1)
      PlayerController.wc.forceAnimation("kneel_e_out", true);
    else
      PlayerController.wc.forceAnimation("kneel_se_out", true);
  }

  private void Update()
  {
    if (!GameDataController.gd.getObjective("sidereal_roof_collapsed") || !GameDataController.gd.getObjective("sidereal_roof_wait_for_rescue"))
      return;
    GameObject.Find("Ginger").GetComponent<GingerActionController>().randomLinesTalkOrNot(true);
  }

  public void quickFall()
  {
    this.showBelka();
    this.showBelka2();
    this.gameObject.GetComponent<Animator>().Play("letter_fallen");
  }

  public void hideAndWait() => this.gameObject.GetComponent<Animator>().Play("letter_wait_fall");

  public void showBelka() => this.barLow.enabled = true;

  public void showBelka2() => this.barLow.transform.position = new Vector3(this.barLow.transform.position.x, this.barLow.transform.position.y, -1.9f);

  public void startAnim(string a = "")
  {
    GameDataController.gd.setObjectiveDetail("letter_fallen", 2);
    this.gameObject.GetComponent<Animator>().Play("letter_fall");
    this.barLow.enabled = false;
    this.barLow.transform.position = new Vector3(this.barLow.transform.position.x, this.barLow.transform.position.y, -0.8f);
    this.aS.pitch = 1f;
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_moan2, 0.5f);
    if (GameDataController.gd.getObjective("npc2_joined"))
      this.barryW.forceAnimation("surprised_n");
    if (GameDataController.gd.getObjective("npc3_joined"))
      this.codyW.forceAnimation("surprised_n");
    this.gingerW.forceAnimation("surprised_ne");
    PlayerController.wc.fullStop(true);
    PlayerController.pc.setBusy(true);
    this.playerJumpSource.transform.position = PlayerController.pc.gameObject.transform.position;
    PlayerController.wc.forceAnimation("surprised_ne", true);
  }

  public void gingerWindUp()
  {
    this.gingerW.speed = 4f;
    this.gingerW.forceAnimation("jump_back");
  }

  public void gingerJump() => this.gingerW.setSimpleTargetV3(this.gingerJumpTarget.transform.position);

  public void playerJump()
  {
    PlayerController.pc.setBusy(true);
    PlayerController.wc.setSimpleTarget(new Vector2((float) (157.0 - 30.0 * ((double) PlayerController.wc.currentXY.y / 75.0)), PlayerController.wc.currentXY.y));
    PlayerController.wc.forceAnimation("jump_side");
    PlayerController.wc.forceDirection(WalkController.Direction.SW);
  }

  public void swingLoop()
  {
    this.aS.pitch = Random.Range(0.9f, 1.1f);
    this.aS.PlayOneShot(SoundsManagerController.sm.metal_moan);
  }

  public void prepare()
  {
    GameDataController.gd.setObjective("sidereal_roof_collapsed", true);
    this.gameObject.GetComponent<Animator>().Play("letter_swing");
    PlayerController.wc.fullStop();
    PlayerController.wc.forceAnimation("surprised_ne", true);
    GameObject.Find("Ginger").GetComponent<NPCWalkController>().forceAnimation("surprised_ne");
    if (GameDataController.gd.getObjective("npc2_joined"))
      GameObject.Find("Npc2").GetComponent<NPCWalkController>().forceAnimation("surprised_n");
    if (GameDataController.gd.getObjective("npc3_joined"))
      GameObject.Find("Npc3").GetComponent<NPCWalkController>().forceAnimation("surprised_n");
    GameObject.Find("Npc2").GetComponent<Npc2Controller>().actionType = ObjectActionController.Type.NormalAction;
    GameObject.Find("Npc3").GetComponent<Npc3Controller>().actionType = ObjectActionController.Type.NormalAction;
    GameObject.Find("LocationSiderealRoof_Waypoint_Climb").GetComponent<LocationSiderealRoof_Waypoint_Climb>().updateState();
    int num = 0;
    if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive"))
      ++num;
    if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
      ++num;
    if (num > 0)
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_action_loop, minTime: 0.0f, maxTime: 0.0f);
    Vector3 color = GingerActionController.getColor();
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "sidereal_watchout", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    Timeline.t.actions[0].actionWithText = false;
    Timeline.t.actions[0].function = new TimelineFunction(this.startAnim);
    Timeline.t.doNotUnlock = true;
  }

  public void codyRun()
  {
    if (!GameDataController.gd.getObjective("npc3_joined"))
      return;
    this.codyW.speed = 4f;
    this.codyW.setSimpleTargetV3(this.codyRunTarget.transform.position);
    this.codyW.forceAnimation("run");
  }

  public void codyJump()
  {
    if (!GameDataController.gd.getObjective("npc3_joined"))
      return;
    this.codyW.speed = 4f;
    this.codyW.setSimpleTargetV3(this.codyJumpTarget.transform.position);
  }

  public void piachSyp()
  {
  }

  public void barryWindUp()
  {
    if (!GameDataController.gd.getObjective("npc2_joined"))
      return;
    this.barryW.speed = 4f;
    this.barryW.forceAnimation("jump2");
  }

  public void barryJump()
  {
    if (!GameDataController.gd.getObjective("npc2_joined"))
      return;
    this.barryW.setSimpleTargetV3(this.barryJumpTarget.transform.position);
  }

  public void startLaunch() => this.sandLauch.started = true;

  public void endLaunch() => this.sandLauch.started = false;

  public void startSandMove()
  {
    this.sandMove1.started = true;
    this.sandMove2.started = true;
    this.sandMove3.started = true;
    this.sandMove4.started = true;
  }

  public void stopSandMove()
  {
    this.sandMove1.started = false;
    this.sandMove2.started = false;
    this.sandMove3.started = false;
    this.sandMove4.started = false;
    GameDataController.gd.setObjectiveDetail("sidereal_roof_collapsed", 4);
  }

  public void startSandFall()
  {
    this.sandFall1.started = true;
    this.sandFall2.started = true;
    this.sandFall3.started = true;
    this.sandFall4.started = true;
    this.aS.pitch = 1f;
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.break_glass_big);
    GameObject.Find("Location").GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.sand_big);
  }

  public void stopSandFall()
  {
    this.sandFall1.started = false;
    this.sandFall2.started = false;
    this.sandFall3.started = false;
    this.sandFall4.started = false;
  }

  public void endAnim()
  {
    GameObject.Find("LocationManager").GetComponent<LocationSiderealRoofStart>().setWalkablePath();
    if (GameDataController.gd.getObjective("npc2_joined") || GameDataController.gd.getObjective("npc3_joined"))
    {
      PlayerController.pc.setBusy(false);
      GameDataController.gd.setObjective("sidereal_roof_wait_for_rescue", true);
    }
    else
      GameObject.Find("Ginger").GetComponent<GingerActionController>().roofAfterFall();
  }
}
