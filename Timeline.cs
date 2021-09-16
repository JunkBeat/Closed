// Decompiled with JetBrains decompiler
// Type: Timeline
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour
{
  public static Timeline t;
  public TextFieldController textField;
  public List<TimelineAction> actions;
  public static int defaultTwidth = 100;
  public bool doNotUnlock;

  private void Awake()
  {
    if ((Object) Timeline.t == (Object) null)
    {
      Object.DontDestroyOnLoad((Object) this.gameObject);
      Timeline.t = this;
    }
    else
    {
      if (!((Object) Timeline.t != (Object) this))
        return;
      Object.Destroy((Object) this.gameObject);
    }
  }

  public void stopChitChat()
  {
    MonoBehaviour.print((object) "STOP CHIT CHAT!");
    if ((bool) (Object) GameObject.Find("Ginger"))
      GameObject.Find("Ginger").GetComponent<GingerActionController>().busyTalkingRandomly = false;
    if (this.actions == null || this.actions.Count <= 0)
      return;
    for (int index = 0; index < this.actions.Count; ++index)
    {
      if (!this.actions[0].blockG)
      {
        this.actions[0].textfield.keepAlive = false;
        this.actions[0].textTime = 0.0f;
        this.actions[0].time = 0.0f;
        this.actions.RemoveAt(0);
        --index;
      }
    }
  }

  public bool isSafeToChangeBusy()
  {
    if (this.actions != null && this.actions.Count > 0)
    {
      bool flag = true;
      for (int index = 0; index < this.actions.Count; ++index)
      {
        if (this.actions[0].blockG)
          flag = false;
      }
      return flag;
    }
    return Timeline.t.actions == null || Timeline.t.actions.Count == 0;
  }

  public void addAction(TimelineAction action)
  {
    if (this.actions == null)
      this.actions = new List<TimelineAction>();
    this.actions.Add(action);
  }

  public void addDialogueLines(List<DialogueLine> dl)
  {
    for (int index = 0; index < dl.Count; ++index)
      this.addDialogue(dl[index]);
  }

  public void addDialogue(DialogueLine dl, float tTime = 0.0f)
  {
    Timeline.defaultTwidth = !(PlayerPrefs.GetString("lang") == GameStrings.Language.DE.ToString()) ? 100 : 130;
    TimelineAction action = new TimelineAction(dl.source);
    action.textColor = dl.textColor;
    action.text = dl.text;
    action.fast = false;
    action.blockG = true;
    if ((double) tTime > 0.0)
    {
      action.fast = true;
      action.instant = true;
      action.blockG = false;
      action.textTime = tTime;
    }
    else
      Timeline.t.stopChitChat();
    action.time = dl.time;
    action.function = dl.action;
    action.actionWithText = dl.actionWithText;
    action.param = dl.actionParam;
    action.backgroundAlpha = 0.75f;
    this.addAction(action);
  }

  private void initTextfield()
  {
    if (!((Object) this.textField == (Object) null))
      return;
    this.textField = this.gameObject.AddComponent<TextFieldController>();
    this.textField = this.gameObject.GetComponent<TextFieldController>();
    this.textField.transform.parent = this.gameObject.transform;
    this.textField.container.transform.parent = this.gameObject.transform;
    this.textField.transform.position = ScreenControler.roundToNearestFullPixel2(this.textField.transform.position);
  }

  private void Start() => this.initTextfield();

  private void Update()
  {
    if (this.actions == null || this.actions.Count <= 0 || (double) this.actions[0].time < 0.0)
      return;
    this.actions[0].time -= Time.deltaTime;
    if ((double) this.actions[0].time > 0.0)
      return;
    this.actions[0].time = 0.0f;
    if ((Object) this.actions[0].textfield != (Object) null && !this.actions[0].textDisplayed)
    {
      if (this.actions[0].textWidth == -1)
        this.actions[0].textWidth = Timeline.defaultTwidth;
      PlayerController.pc.clickedSomething = false;
      this.actions[0].textDisplayed = true;
      if (this.actions[0] != null && this.actions[0].text != null && this.actions[0].text.Length > 0)
      {
        this.actions[0].textfield.viewText(this.actions[0].text, this.actions[0].blockG, this.actions[0].fast, this.actions[0].instant, this.actions[0].textWidth, this.actions[0].textColor.x, this.actions[0].textColor.y, this.actions[0].textColor.z, this.actions[0].backgroundColor.x, this.actions[0].backgroundColor.y, this.actions[0].backgroundColor.z, this.actions[0].backgroundAlpha);
        if (this.actions[0].blockG || (double) this.actions[0].textTime > 0.0)
          this.actions[0].textfield.keepAlive = true;
      }
    }
    if (!this.actions[0].blockG && (double) this.actions[0].textTime > 0.0)
      this.actions[0].textTime -= Time.deltaTime;
    else if (!this.actions[0].blockG && (double) this.actions[0].textTime <= 0.0)
      this.actions[0].textfield.keepAlive = false;
    if (this.actions[0].actionWithText)
      this.functionLaunch();
    if (!((Object) this.actions[0].textfield == (Object) null) && (!((Object) this.actions[0].textfield != (Object) null) || this.actions[0].textfield.keepAlive))
      return;
    this.proceedWithPurpose();
  }

  private void functionLaunch()
  {
    if (this.actions[0].function == null)
      return;
    this.actions[0].function(this.actions[0].param);
    this.actions[0].function = (TimelineFunction) null;
  }

  public void proceedWithPurpose()
  {
    this.functionLaunch();
    this.actions.RemoveAt(0);
    int detail = GameDataController.gd.getObjectiveDetail("chitchat");
    if (detail > -5)
      detail = -5;
    GameDataController.gd.setObjectiveDetail("chitchat", detail);
    if (!this.doNotUnlock)
      PlayerController.pc.setBusy(false);
    this.doNotUnlock = false;
  }

  public void killText() => this.actions[0].textfield.terminate();

  public void skipDialogue()
  {
    if (this.actions == null || this.actions.Count <= 0)
      return;
    for (int index = 0; index < this.actions.Count; ++index)
    {
      if (this.actions[index].function != null)
      {
        this.actions[index].text = "";
        this.actions[index].textfield.keepAlive = false;
        this.actions[index].textDisplayed = false;
      }
      else
      {
        this.actions[index].text = "";
        this.actions[index].textfield.keepAlive = false;
        this.actions[index].textDisplayed = false;
        this.actions.RemoveAt(index);
        --index;
      }
    }
  }
}
