// Decompiled with JetBrains decompiler
// Type: DreamDoor
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class DreamDoor : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action1_e_lock";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "basedoor";
    this.range = 1f;
    this.teleport = false;
    this.updateState();
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() == 4 && !GameDataController.gd.getObjective("dream_day_4_door_open"))
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_open_01);
      this.GetComponent<Animator>().Play("dream_door_open");
      GameDataController.gd.setObjective("dream_day_4_door_open", true);
      this.characterAnimationName = "stop";
      this.animationFlip = true;
      this.useCurrentDirection = false;
      this.actionType = ObjectActionController.Type.Transition;
      this.trans_dir = WalkController.Direction.W;
    }
    else if (GameDataController.gd.getCurrentDay() == 4)
    {
      GameObject.Find("BottomText").GetComponent<TextFieldController>().dissmiss(true);
      GameObject.Find("LocationManager").GetComponent<LocationDream4Start>().fallMoon();
      GameObject.Find("gears").GetComponent<GearsController>().hide();
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "generic_locked"));
  }

  public override void updateState()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjective("dream_day_1_started") || GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjective("dream_day_2_started") || GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjective("dream_day_3_started") || GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjective("dream_day_4_started"))
    {
      this.colliderManager.setCollider(0);
      if (GameDataController.gd.getCurrentDay() != 4)
        return;
      if (GameDataController.gd.getObjective("dream_day_4_door_open"))
      {
        this.characterAnimationName = "stop";
        this.animationFlip = true;
        this.useCurrentDirection = false;
        this.actionType = ObjectActionController.Type.Transition;
        this.trans_dir = WalkController.Direction.W;
        this.GetComponent<Animator>().Play("dream_door_opened");
      }
      else
      {
        this.characterAnimationName = "action1_e";
        this.animationFlip = true;
        this.useCurrentDirection = false;
        this.GetComponent<Animator>().Play("dream_door_closed");
        this.actionType = ObjectActionController.Type.NormalAction;
      }
    }
    else
      this.colliderManager.setCollider(-1);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
