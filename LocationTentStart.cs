// Decompiled with JetBrains decompiler
// Type: LocationTentStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationTentStart : MonoBehaviour
{
  private void Start()
  {
    if (!GameDataController.gd.getObjective("tent_distance_checked"))
      GameObject.Find("journal").GetComponent<JournalButtonController>().hide();
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0015f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 8f;
    PlayerController.wc.shadow.startAlpha = 0.25f;
    PlayerController.wc.shadow.source = 200f;
    PlayerController.ssg.setStepType("dirt");
    PlayerController.wc.shadow.scaleFactor = 0.3f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 1f);
    if (!GameDataController.gd.getObjective("tent_awake"))
    {
      PlayerController.wc.speed = 0.0f;
      PlayerController.wc.dir = WalkController.Direction.SE;
      PlayerController.wc.currentXY = new Vector2(-51f, -28f);
      Vector2 screen = ScreenControler.gameToScreen(new Vector2(-999f, -999f));
      Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
      worldPoint.z = -3f;
      InventoryButtonController.ibc.gameObject.transform.position = worldPoint;
      PlayerController.wc.busy = true;
      this.Invoke("exitTent", 2f);
      this.Invoke("exitTent2", 4f);
    }
    else
    {
      if (GameDataController.gd.getObjective("tent_backpack_taken"))
        return;
      PlayerController.wc.speed = 0.0f;
      PlayerController.wc.dir = WalkController.Direction.S;
      PlayerController.wc.forceAnimation("stand_s", makeBusy: false);
      PlayerController.wc.busy = false;
      GameObject.Find("Bagpack").GetComponent<TentBagpack>().updateAll();
    }
  }

  private void exitTent()
  {
    PlayerController.wc.currentXY = new Vector2(51f, 28f);
    PlayerController.wc.forceAnimation("exit_tent");
  }

  private void exitTent3(string v = "")
  {
    PlayerController.pc.setBusy(true);
    Timeline.t.doNotUnlock = true;
    this.Invoke("exitTent4", 1f);
  }

  private void exitTent4()
  {
    string str = "david_ending_med";
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.dialogues, str + "_1_a"),
      blockG = true
    });
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.dialogues, str + "_2_a"),
      blockG = true
    });
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.dialogues, str + "_3_a"),
      blockG = true
    });
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.dialogues, str + "_4_a"),
      blockG = true
    });
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.dialogues, str + "_5_a"),
      blockG = true,
      function = new TimelineFunction(this.keepStraight),
      actionWithText = false
    });
  }

  private void exitTent2()
  {
    PlayerController.wc.dir = WalkController.Direction.S;
    PlayerController.wc.forceAnimation("stand_s", makeBusy: false);
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.actions, "story_intro_day_1_1"),
      blockG = true
    });
    TimelineAction action = new TimelineAction(PlayerController.pc.textField);
    action.text = GameStrings.getString(GameStrings.actions, "story_intro_day_1_2");
    action.blockG = true;
    if (GameDataController.gd.getObjective("previous_disc_barry") || GameDataController.gd.getObjective("previous_disc_cody"))
    {
      action.function = new TimelineFunction(this.exitTent3);
      action.actionWithText = false;
      Timeline.t.doNotUnlock = true;
    }
    else
      action.function = new TimelineFunction(this.keepStraight);
    Timeline.t.addAction(action);
    PlayerController.wc.forceDirection(WalkController.Direction.S);
  }

  private void keepStraight(string val = "")
  {
    GameDataController.gd.setObjective("tent_awake", true);
    GameObject.Find("Bagpack").GetComponent<TentBagpack>().updateAll();
    PlayerController.wc.fullStop(true, forceStandAnimation: true);
    PlayerController.wc.dir = WalkController.Direction.S;
    PlayerController.wc.forceAnimation("stand_s", makeBusy: false);
    PlayerController.wc.forceDirection(WalkController.Direction.S);
  }

  private void Update()
  {
  }
}
