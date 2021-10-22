// Decompiled with JetBrains decompiler
// Type: LocationAirplane1Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationAirplane1Start : MonoBehaviour
{
  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = -2;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 15f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.source = 10f;
    PlayerController.ssg.setStepType("dirt");
    PlayerController.wc.shadow.scaleFactor = 0.25f;
    PlayerController.wc.shadow.downwards = false;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    if (!GameDataController.gd.getObjective("visited_airplane1"))
    {
      Vector3 color1 = GingerActionController.getColor();
      TextFieldController component1 = GameObject.Find("Ginger").GetComponent<TextFieldController>();
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "airplane_welcome", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1);
      if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive"))
      {
        Vector3 color2 = GingerActionController.getColor();
        Vector3 color3 = Npc2Controller.getColor();
        component1 = GameObject.Find("Ginger").GetComponent<TextFieldController>();
        TextFieldController component2 = GameObject.Find("Npc2").GetComponent<TextFieldController>();
        DialogueController.dc.initDialogue(dialogueLines, "airplane_welcome_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color2, component2, color3);
      }
      if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
      {
        Vector3 color4 = Npc3Controller.getColor();
        TextFieldController component3 = GameObject.Find("Npc3").GetComponent<TextFieldController>();
        DialogueController.dc.initDialogue(dialogueLines, "airplane_welcome_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color4, component3, color4);
      }
      for (int index = 0; index < dialogueLines.Count - 1; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
      Timeline.t.addDialogue(dialogueLines[dialogueLines.Count - 1]);
    }
    GameDataController.gd.setObjective("visited_airplane1", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_4a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_metal, 0.9f);
  }

  private void Update()
  {
  }
}
