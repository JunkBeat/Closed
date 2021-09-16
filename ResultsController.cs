// Decompiled with JetBrains decompiler
// Type: ResultsController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class ResultsController : MonoBehaviour
{
  public int winQuality;
  public int danger;
  public int surviavbleDanger;
  public int removeDanger;
  public ProgressBarController pbc;
  public ResultsFrame rf;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void init()
  {
    this.pbc = GameObject.Find("ProgressBar").GetComponent<ProgressBarController>();
    this.rf = GameObject.Find("c_frame").GetComponent<ResultsFrame>();
    this.rf.move(-0.63f, 0.0f);
    this.chapterResult();
  }

  public void skipFast(string val = "")
  {
    this.changeDanger(val);
    Timeline.t.killText();
    Timeline.t.proceedWithPurpose();
  }

  public int check(int danger = 0, string label = "", string pic = "", bool trackWasShortened = true)
  {
    TimelineAction action = new TimelineAction(Timeline.t.textField);
    action.function = new TimelineFunction(this.changeDanger);
    action.actionWithText = false;
    this.removeDanger += danger;
    action.param = "-" + (object) danger;
    if (pic == "hide")
    {
      action.param += "|hide";
      action.actionWithText = true;
    }
    else if (pic != string.Empty)
    {
      TimelineAction timelineAction = action;
      timelineAction.param = timelineAction.param + "|Bitmaps/Locations/LocationResults/" + pic;
      action.actionWithText = true;
    }
    else
      action.actionWithText = false;
    action.text = !trackWasShortened ? label : GameStrings.getString(GameStrings.results, label);
    Timeline.t.addAction(action);
    return danger;
  }

  public void liveOrDie2(string val = "")
  {
    GameDataController.gd.finishingLocation = GameDataController.gd.previousLocation;
    if (this.danger > this.surviavbleDanger)
    {
      PlayerController.pc.spawnName = "InfoExit";
      if (GameDataController.gd.getCurrentDay() == 1)
      {
        GameDataController.gd.setObjective("day1_complete", false);
        GameDataController.gd.setObjectiveDetail("day1_complete", -this.danger);
        CurtainController.cc.fadeOut("LocationBugDeath", WalkController.Direction.S);
      }
      else if (GameDataController.gd.getCurrentDay() == 2)
      {
        GameDataController.gd.setObjective("day2_complete", false);
        GameDataController.gd.setObjectiveDetail("day2_complete", -this.danger);
        CurtainController.cc.fadeOut("LocationCh2Death", WalkController.Direction.S);
      }
      else if (GameDataController.gd.getCurrentDay() == 3)
      {
        GameDataController.gd.setObjective("day3_complete", false);
        GameDataController.gd.setObjectiveDetail("day3_complete", -this.danger);
        CurtainController.cc.fadeOut("LocationCh3Death", WalkController.Direction.S);
      }
      else
      {
        GameDataController.gd.setObjective("day4_complete", false);
        GameDataController.gd.setObjectiveDetail("day4_complete", -this.danger);
        CurtainController.cc.fadeOut("LocationCh4Death", WalkController.Direction.S);
      }
    }
    else
    {
      PlayerController.pc.spawnName = "InfoExit";
      GameDataController.gd.gameTime = 480;
      int detail;
      if (this.winQuality == 3)
        detail = 1;
      else if (this.winQuality == 2)
      {
        detail = 0;
      }
      else
      {
        detail = -this.danger;
        if (this.danger == 0)
          detail = -1;
      }
      if (GameDataController.gd.getCurrentDay() == 1)
      {
        GameDataController.gd.setObjective("day1_complete", true);
        GameDataController.gd.setObjectiveDetail("day1_complete", detail);
        CurtainController.cc.fadeOut("LocationDay1Win", WalkController.Direction.S);
      }
      else if (GameDataController.gd.getCurrentDay() == 2)
      {
        GameDataController.gd.setObjective("day2_complete", true);
        GameDataController.gd.setObjectiveDetail("day2_complete", detail);
        CurtainController.cc.fadeOut("LocationDay2Win", WalkController.Direction.S);
      }
      else if (GameDataController.gd.getCurrentDay() == 3)
      {
        GameDataController.gd.setObjective("day3_complete", true);
        GameDataController.gd.setObjectiveDetail("day3_complete", detail);
        CurtainController.cc.fadeOut("LocationDay3Win", WalkController.Direction.S);
      }
      else
      {
        if (GameDataController.gd.getCurrentDay() != 4)
          return;
        GameDataController.gd.setObjective("day4_complete", true);
        GameDataController.gd.setObjectiveDetail("day4_complete", detail);
        CurtainController.cc.fadeOut("LocationDay4Win", WalkController.Direction.S);
      }
    }
  }

  public void liveOrDie(string val = "") => Timeline.t.addAction(new TimelineAction(Timeline.t.textField)
  {
    function = new TimelineFunction(this.liveOrDie2),
    actionWithText = false,
    param = "0",
    text = "[" + GameStrings.getString(GameStrings.results, "results_end") + "]"
  });

  public void changeDanger(string val = "")
  {
    GameObject.Find("ProgressBar").GetComponent<ProgressBarController>().surv = (float) this.surviavbleDanger;
    string[] strArray = val.Split('|');
    this.danger += strArray.Length <= 0 || !(strArray[0] != string.Empty) ? 0 : int.Parse(strArray[0]);
    if (this.danger <= 0)
      this.danger = 0;
    MonoBehaviour.print((object) this.danger);
    this.pbc.setValue(this.danger);
    if (strArray.Length > 1)
    {
      if (strArray[1] == "hide")
        this.rf.hide();
      else
        this.rf.show(Resources.Load<Sprite>(strArray[1]));
    }
    if (this.danger != 0 || Timeline.t.actions.Count <= 1)
      return;
    MonoBehaviour.print((object) "OK THE DANGER IS NONE AND ACTIONS ARE MORE THAN ONE...");
    while (Timeline.t.actions.Count > 1)
      Timeline.t.actions.RemoveAt(1);
    this.liveOrDie(string.Empty);
  }

  public virtual void chapterResult()
  {
  }
}
