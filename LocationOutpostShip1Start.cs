// Decompiled with JetBrains decompiler
// Type: LocationOutpostShip1Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class LocationOutpostShip1Start : MonoBehaviour
{
  public SpriteRenderer playerShadow;
  public float modX;
  public float modY;
  public bool clambino;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 1f / 500f;
    PlayerController.wc.shadowOffsetY = -1;
    PlayerController.wc.shadow.skewFactor = 40f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.0f;
    PlayerController.wc.shadow.source = 60f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.METAL, AudioReverbPreset.Hangar);
    PlayerController.wc.shadow.scaleFactor = 0.6f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    this.clambino = false;
    PlayerController.pc.allowDrop = false;
    if (!GameDataController.gd.getObjective("visited_ship1"))
    {
      Vector3 color = GingerActionController.getColor();
      TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "ship_enter_intro", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
      for (int index = 0; index < dialogueLines.Count - 1; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
      Timeline.t.addDialogue(dialogueLines[dialogueLines.Count - 1]);
    }
    GameDataController.gd.setObjective("visited_ship1", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_6a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.pc_noise, 1f);
  }

  private void Update()
  {
    float num = this.modX + (float) ((120.0 - (double) PlayerController.wc.currentXY.x) * 0.00499999988824129);
    if (this.clambino)
    {
      num = -0.01f;
      this.modY = 0.0f;
    }
    this.playerShadow.transform.position = PlayerController.pc.transform.position;
    this.playerShadow.transform.position = new Vector3(PlayerController.pc.transform.position.x + num, PlayerController.pc.transform.position.y + this.modY, -0.8f);
    this.playerShadow.transform.position = ScreenControler.roundToNearestFullPixel2(this.playerShadow.transform.position);
    this.playerShadow.sprite = PlayerController.wc.sr.sprite;
    this.playerShadow.flipX = PlayerController.wc.sr.flipX;
  }
}
