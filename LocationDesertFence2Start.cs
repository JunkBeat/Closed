// Decompiled with JetBrains decompiler
// Type: LocationDesertFence2Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationDesertFence2Start : MonoBehaviour
{
  public Sprite hammerDown;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.01f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 2;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 2f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 0.0f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.DIRT, AudioReverbPreset.Off);
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_3, 1f);
    ItemsManager.im.getItem("sledgehammer").groundSprite = this.hammerDown;
    if (GameDataController.gd.getObjective("wall_encountered"))
      return;
    PlayerController.wc.forceAnimation("stand_n");
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.actions, "tutorial_wall_encounter1")
    });
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.actions, "tutorial_wall_encounter2")
    });
    TimelineAction action = new TimelineAction(GameObject.Find("BottomText").GetComponent<TextFieldController>())
    {
      textWidth = BottomTextController.bottomTextWidth,
      actionWithText = true,
      function = new TimelineFunction(this.makeItLast),
      text = "[" + GameStrings.getString(GameStrings.gui, "clock_hint1") + "]"
    };
    action.actionWithText = true;
    action.function = new TimelineFunction(GameObject.Find("clock").GetComponent<ClockController>().showClock);
    Timeline.t.addAction(action);
    Timeline.t.addAction(new TimelineAction(GameObject.Find("BottomText").GetComponent<TextFieldController>())
    {
      textWidth = BottomTextController.bottomTextWidth,
      actionWithText = true,
      function = new TimelineFunction(this.makeItLast),
      text = "[" + GameStrings.getString(GameStrings.gui, "clock_hint2") + "]"
    });
    Timeline.t.addAction(new TimelineAction(GameObject.Find("BottomText").GetComponent<TextFieldController>())
    {
      textWidth = BottomTextController.bottomTextWidth,
      actionWithText = true,
      function = new TimelineFunction(this.makeItLast),
      text = "[" + GameStrings.getString(GameStrings.gui, "clock_hint3") + "]"
    });
    GameDataController.gd.setObjective("wall_encountered", true);
  }

  private void makeItLast(string a)
  {
  }

  private void Update()
  {
    if (!(GameDataController.gd.getItemData("sledgehammer").droppedLocation == "LocationDesertFence2") || GameDataController.gd.getObjective("tutorial_tab"))
      return;
    GameDataController.gd.setObjective("tutorial_tab", true);
    Timeline.t.addAction(new TimelineAction(GameObject.Find("BottomText").GetComponent<TextFieldController>())
    {
      text = GameStrings.getString(GameStrings.actions, "tutorial_tab"),
      textWidth = 200
    });
  }
}
