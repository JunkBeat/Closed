// Decompiled with JetBrains decompiler
// Type: LocationSiderealLabStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationSiderealLabStart : MonoBehaviour
{
  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.03f;
    PlayerController.wc.shadow.fadeRateH = 0.01f;
    PlayerController.wc.shadowOffsetY = 2;
    PlayerController.wc.shadow.skewFactor = 40f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.7f;
    PlayerController.wc.shadow.scaleFactor = 0.4f;
    PlayerController.wc.shadow.downwards = false;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 120f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.NORMAL, AudioReverbPreset.Cave);
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.underground_1, 1f);
    GameDataController.gd.setObjective("visited_sidereal_lab13", true);
    if (!(GameDataController.gd.getItemData("pills").droppedLocation == "inventory") || GameDataController.gd.getObjective("dialogue_ginger_pills"))
      return;
    GameDataController.gd.setObjective("dialogue_ginger_pills", true);
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "ginger_pills_here", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, GingerActionController.getColor());
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  private void Update()
  {
  }
}
