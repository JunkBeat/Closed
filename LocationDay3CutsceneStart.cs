// Decompiled with JetBrains decompiler
// Type: LocationDay3CutsceneStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationDay3CutsceneStart : MonoBehaviour
{
  public float aalfa = -1f;
  public SpriteRenderer hazy;
  public SpriteRenderer clear;

  private void Start()
  {
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_main, false);
    JukeboxAmbient.jb.changeAmbient((AudioClip) null, 0.0f);
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    GameObject.Find("BottomText").GetComponent<TextFieldController>().maxWidth = 180;
    DialogueController.dc.initDialogue(dialogueLines, "day3_intro_cutscene", GameObject.Find("BottomText").GetComponent<TextFieldController>(), new Vector3(1f, 1f, 1f));
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    Timeline.t.actions[Timeline.t.actions.Count - 2].function = new TimelineFunction(this.fadeOut);
    Timeline.t.actions[Timeline.t.actions.Count - 1].function = new TimelineFunction(this.transportToSidereal);
    this.hazy.color = new Color(1f, 1f, 1f, 1f);
    this.clear.color = new Color(1f, 1f, 1f, 0.0f);
  }

  private void fadeOut(string s = "") => this.aalfa = 0.0f;

  private void transportToSidereal(string s = "")
  {
    PlayerController.pc.spawnName = "SiderealOutside1_Waypoint_Map";
    if (GameDataController.gd.getObjectiveDetail("car_location") == 8)
      PlayerController.pc.spawnName = "car";
    CurtainController.cc.fadeOut("SiderealOutside1", WalkController.Direction.N, flipX: true, tSpeed: 0.1f);
  }

  private void Update()
  {
    if ((double) this.aalfa < 0.0 || (double) this.aalfa > 1.0)
      return;
    this.aalfa += Time.deltaTime * 0.25f;
    if ((double) this.aalfa >= 1.0)
      this.aalfa = 1f;
    this.clear.color = new Color(1f, 1f, 1f, this.aalfa);
  }
}
