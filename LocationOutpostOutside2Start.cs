// Decompiled with JetBrains decompiler
// Type: LocationOutpostOutside2Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class LocationOutpostOutside2Start : MonoBehaviour
{
  public SpriteRenderer playerShadow;
  public GameObject electro;
  public ParticleGenerator smoke;
  public ParticleGenerator sparks;
  public float modX;
  public float modY;
  public TextFieldController scannerTxt;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = -2;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 2f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.source = 10f;
    PlayerController.ssg.setStepType("dirt");
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = false;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    GameDataController.gd.setObjective("visited_outpost2", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_1a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_3, 0.9f);
    if (!GameDataController.gd.getObjective("outpost_doormat_triggered"))
      return;
    this.doormat();
  }

  private void Update()
  {
    this.playerShadow.transform.position = PlayerController.pc.transform.position;
    this.playerShadow.transform.position = new Vector3(PlayerController.pc.transform.position.x + this.modX, PlayerController.pc.transform.position.y + this.modY, -0.2f);
    this.playerShadow.transform.position = ScreenControler.roundToNearestFullPixel2(this.playerShadow.transform.position);
    this.playerShadow.sprite = PlayerController.wc.sr.sprite;
    this.playerShadow.flipX = PlayerController.wc.sr.flipX;
  }

  public void doormat()
  {
    if ((Object) this.gameObject == (Object) null || GameDataController.gd.location != "LocationOutpostOutside2" || CurtainController.cc.targetLocaiton != string.Empty)
      return;
    if (GameDataController.gd.getObjective("outpost_doormat_triggered"))
    {
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.buzz, 0.2f);
      if (GameDataController.gd.getObjectiveDetail("outpost_doormat_triggered") == 0)
      {
        PlayerController.wc.fullStop(true);
        GameDataController.gd.setObjectiveDetail("outpost_doormat_triggered", 6);
        PlayerController.wc.forceAnimation("stand_", useCurrentDir: true);
        List<DialogueLine> dialogueLines = new List<DialogueLine>();
        DialogueController.dc.initDialogue(dialogueLines, "outpost_doormat", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.scannerTxt, new Vector3(1f, 0.5f, 0.0f));
        if (!GameDataController.gd.getObjective("outpost_doormat_first_time"))
        {
          dialogueLines.Add(new DialogueLine(GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), GameStrings.getString(GameStrings.dialogues, "outpost_doormat_cate"), (TimelineFunction) null));
          GameDataController.gd.setObjective("outpost_doormat_first_time", true);
        }
        dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.doormatGo);
        dialogueLines[dialogueLines.Count - 1].actionWithText = false;
        for (int index = 0; index < dialogueLines.Count; ++index)
          Timeline.t.addDialogue(dialogueLines[index]);
      }
      else if (GameDataController.gd.getObjectiveDetail("outpost_doormat_triggered") == 1)
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2, 0.25f);
        this.scannerTxt.viewText(GameStrings.getString(GameStrings.actions, "outpost_doormat_10"), mwidth: 100, g: 0.5f, b: 0.0f);
        GameDataController.gd.setObjectiveDetail("outpost_doormat_triggered", 2);
        this.Invoke(nameof (doormat), 1f);
        this.scannerTxt.setTime(2f);
      }
      else if (GameDataController.gd.getObjectiveDetail("outpost_doormat_triggered") == 2)
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2, 0.25f);
        this.scannerTxt.viewText(GameStrings.getString(GameStrings.actions, "outpost_doormat_9"), mwidth: 100, g: 0.5f, b: 0.0f);
        GameDataController.gd.setObjectiveDetail("outpost_doormat_triggered", 3);
        this.Invoke(nameof (doormat), 1f);
        this.scannerTxt.setTime(2f);
      }
      else if (GameDataController.gd.getObjectiveDetail("outpost_doormat_triggered") == 3)
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2, 0.25f);
        this.scannerTxt.viewText(GameStrings.getString(GameStrings.actions, "outpost_doormat_8"), mwidth: 100, g: 0.5f, b: 0.0f);
        GameDataController.gd.setObjectiveDetail("outpost_doormat_triggered", 4);
        this.Invoke(nameof (doormat), 1f);
        this.scannerTxt.setTime(2f);
      }
      else if (GameDataController.gd.getObjectiveDetail("outpost_doormat_triggered") == 4)
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2, 0.25f);
        this.scannerTxt.viewText(GameStrings.getString(GameStrings.actions, "outpost_doormat_7"), mwidth: 100, g: 0.5f, b: 0.0f);
        GameDataController.gd.setObjectiveDetail("outpost_doormat_triggered", 5);
        this.Invoke(nameof (doormat), 1f);
        this.scannerTxt.setTime(2f);
      }
      else if (GameDataController.gd.getObjectiveDetail("outpost_doormat_triggered") == 5)
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2, 0.25f);
        this.scannerTxt.viewText(GameStrings.getString(GameStrings.actions, "outpost_doormat_6"), mwidth: 100, g: 0.5f, b: 0.0f);
        GameDataController.gd.setObjectiveDetail("outpost_doormat_triggered", 6);
        this.Invoke(nameof (doormat), 1f);
        this.scannerTxt.setTime(2f);
      }
      else if (GameDataController.gd.getObjectiveDetail("outpost_doormat_triggered") == 6)
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2, 0.25f);
        this.scannerTxt.viewText(GameStrings.getString(GameStrings.actions, "outpost_doormat_5"), mwidth: 100, g: 0.5f, b: 0.0f);
        GameDataController.gd.setObjectiveDetail("outpost_doormat_triggered", 7);
        this.Invoke(nameof (doormat), 1f);
        this.scannerTxt.setTime(2f);
      }
      else if (GameDataController.gd.getObjectiveDetail("outpost_doormat_triggered") == 7)
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2, 0.3f);
        this.scannerTxt.viewText(GameStrings.getString(GameStrings.actions, "outpost_doormat_4"), mwidth: 100, g: 0.5f, b: 0.0f);
        GameDataController.gd.setObjectiveDetail("outpost_doormat_triggered", 8);
        this.Invoke(nameof (doormat), 1f);
        this.scannerTxt.setTime(2f);
      }
      else if (GameDataController.gd.getObjectiveDetail("outpost_doormat_triggered") == 8)
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2, 0.35f);
        this.scannerTxt.viewText(GameStrings.getString(GameStrings.actions, "outpost_doormat_3"), mwidth: 100, g: 0.5f, b: 0.0f);
        GameDataController.gd.setObjectiveDetail("outpost_doormat_triggered", 9);
        this.Invoke(nameof (doormat), 1f);
        this.scannerTxt.setTime(2f);
        if (!GameDataController.gd.getObjective("npc2_joined") || !GameDataController.gd.getObjective("npc2_alive"))
          return;
        Vector3 color = Npc2Controller.getColor();
        TextFieldController component = GameObject.Find("Npc2").GetComponent<TextFieldController>();
        component.viewText(GameStrings.getString(GameStrings.dialogues, "outpost_doormat_barry"), mwidth: 100, r: color.x, g: color.y, b: color.z);
        component.setTime(2f);
      }
      else if (GameDataController.gd.getObjectiveDetail("outpost_doormat_triggered") == 9)
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2, 0.4f);
        this.scannerTxt.viewText(GameStrings.getString(GameStrings.actions, "outpost_doormat_2"), mwidth: 100, g: 0.5f, b: 0.0f);
        GameDataController.gd.setObjectiveDetail("outpost_doormat_triggered", 10);
        this.Invoke(nameof (doormat), 1f);
        this.scannerTxt.setTime(2f);
      }
      else if (GameDataController.gd.getObjectiveDetail("outpost_doormat_triggered") == 10)
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2, 0.45f);
        this.scannerTxt.viewText(GameStrings.getString(GameStrings.actions, "outpost_doormat_1"), mwidth: 100, g: 0.5f, b: 0.0f);
        GameDataController.gd.setObjectiveDetail("outpost_doormat_triggered", 11);
        this.Invoke(nameof (doormat), 1f);
        this.scannerTxt.setTime(2f);
      }
      else if (GameDataController.gd.getObjectiveDetail("outpost_doormat_triggered") == 11)
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2, 0.5f);
        this.scannerTxt.viewText(GameStrings.getString(GameStrings.actions, "outpost_doormat_0"), mwidth: 100, g: 0.5f, b: 0.0f);
        GameDataController.gd.setObjectiveDetail("outpost_doormat_triggered", 12);
        this.Invoke(nameof (doormat), 1f);
        this.scannerTxt.setTime(2f);
      }
      else
      {
        PlayerController.pc.interruptDialogueProbablyToKillPlayer();
        PlayerController.wc.fullStop(true);
        PlayerController.pc.setBusy(true);
        PlayerController.wc.forceAnimation("electrocute", PlayerController.wc.sr.flipX);
        this.electro.transform.position = PlayerController.pc.gameObject.transform.position;
        this.electro.transform.position = new Vector3(this.electro.transform.position.x, this.electro.transform.position.y, -3f);
        this.electro.GetComponent<SpriteRenderer>().flipX = PlayerController.wc.sr.flipX;
        this.electro.GetComponent<Animator>().Play("electrocute");
        GameObject.Find("Ginger").GetComponent<NPCWalkController>().forceAnimation("surprised_se");
        if (GameDataController.gd.getObjective("npc2_alive"))
          GameObject.Find("Npc2").GetComponent<NPCWalkController>().forceAnimation("surprised_se");
        if (GameDataController.gd.getObjective("npc3_alive"))
          GameObject.Find("Npc3").GetComponent<NPCWalkController>().forceAnimation("surprised2");
        if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
        {
          Vector3 color = Npc3Controller.getColor();
          GameObject.Find("Npc3").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.dialogues, "outpost_doormat_cody"), quick: true, mwidth: 100, r: color.x, g: color.y, b: color.z);
        }
        this.smoke.started = true;
        this.sparks.started = true;
        this.Invoke("disableSparks", 4f);
        this.Invoke("resetStage", 5f);
      }
    }
    else
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_3, 0.9f);
  }

  public void disableSparks()
  {
    for (int index = 0; index < this.sparks.particles.Count; ++index)
      this.sparks.particles[index].GetComponent<ParticleController>().currentXY.x = 1000f;
    this.sparks.started = false;
  }

  public void resetStage()
  {
    GameDataController.gd.setObjectiveDetail("outpost_doormat_triggered", 0);
    GameDataController.gd.setObjective("outpost_doormat_triggered", false);
    this.smoke.started = false;
    PlayerController.pc.spawnName = "Dieded";
    CurtainController.cc.fadeOut("LocationOutpostOutside2", WalkController.Direction.E);
  }

  public void doormatGo(string t = "") => this.Invoke("doormat", 0.25f);

  public void letItGo()
  {
    this.CancelInvoke();
    this.doormat();
    this.scannerTxt.setTime(1f);
  }
}
