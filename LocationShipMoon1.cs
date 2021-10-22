// Decompiled with JetBrains decompiler
// Type: LocationShipMoon1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationShipMoon1 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "ship_exit";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.doubleClickCondition = string.Empty;
  }

  public void decompression(string s = "")
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.wind1);
    CurtainController.cc.fadeOut(sound: SoundsManagerController.sm.slidedoor, actionAfterFade: new CurtainController.Delegate(this.doneDecompression));
  }

  public void doneDecompression()
  {
    GameObject.Find("LocationManager").GetComponent<LocationMoonShipStart>().updateThings();
    GameDataController.gd.setObjective("moon_door_open", true);
    TimelineAction timelineAction = new TimelineAction();
    Timeline.t.addAction(new TimelineAction()
    {
      textfield = PlayerController.pc.textField,
      textColor = new Vector3(0.0f, 1f, 0.0f),
      backgroundColor = new Vector3(0.0f, 0.5f, 0.0f),
      text = GameStrings.getString(GameStrings.actions, "ship_exit_2"),
      actionWithText = true
    });
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("moon_door_open"))
    {
      PlayerController.pc.spawnName = "LocationMoon1Ship";
      CurtainController.cc.fadeOut("Moon1", WalkController.Direction.S);
    }
    else if ((!GameDataController.gd.getObjective("npc1_alive") || !GameDataController.gd.getObjective("moon_shocked1")) && (!GameDataController.gd.getObjective("npc2_alive") || !GameDataController.gd.getObjective("moon_shocked2")) && (!GameDataController.gd.getObjective("npc3_alive") || !GameDataController.gd.getObjective("moon_shocked3")))
    {
      if (GameDataController.gd.getObjective("moon_suited_up"))
      {
        GameDataController.gd.setObjective("moon_door_open", true);
        TimelineAction timelineAction = new TimelineAction();
        Timeline.t.addAction(new TimelineAction()
        {
          textfield = PlayerController.pc.textField,
          textColor = new Vector3(0.0f, 1f, 0.0f),
          backgroundColor = new Vector3(0.0f, 0.5f, 0.0f),
          text = GameStrings.getString(GameStrings.actions, "ship_exit_1"),
          actionWithText = false,
          function = new TimelineFunction(this.decompression)
        });
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2);
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "ship_exit_not_yet_suits"));
    }
    else if (GameDataController.gd.getObjective("npc2_alive") || GameDataController.gd.getObjective("npc3_alive"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "ship_exit_not_yet_others"));
    else if (GameDataController.gd.getObjective("npc1_alive"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "ship_exit_not_yet_cate"));
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "ship_exit_not_yet_suits"));
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("moon_door_open"))
    {
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.actionType = ObjectActionController.Type.Transition;
      this.trans_dir = WalkController.Direction.N;
      this.GetComponent<SpriteRenderer>().enabled = true;
    }
    else
    {
      this.characterAnimationName = "action_stnd_";
      if (GameDataController.gd.getObjective("moon_suited_up"))
        this.characterAnimationName = "suit_action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.actionType = ObjectActionController.Type.NormalAction;
      this.trans_dir = WalkController.Direction.N;
      this.GetComponent<SpriteRenderer>().enabled = false;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
