// Decompiled with JetBrains decompiler
// Type: BarnGeneratorPull
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BarnGeneratorPull : ObjectActionController
{
  public BarnButtonGenOff bbgo;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = string.Empty;
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "barn_generator_starting_cord";
    this.teleport = true;
    this.bbgo = GameObject.Find("ButtonOff").GetComponent<BarnButtonGenOff>();
    this.transform.position = ScreenControler.roundToNearestFullPixel2(this.transform.position);
  }

  public void unlockIt()
  {
    this.setCollider(0);
    PlayerController.pc.setBusy(false);
    if (GameDataController.gd.getObjectiveDetail("barn_pump_started") != 0 && GameDataController.gd.getObjective("barn_pump_started"))
    {
      this.bbgo.aS.clip = this.bbgo.engineRun;
      this.bbgo.aS.loop = true;
      this.bbgo.aS.PlayDelayed(0.0f);
    }
    if (!GameDataController.gd.getObjective("barn_pump_fueled"))
      return;
    if (GameDataController.gd.getObjectiveDetail("barn_pump_start_try") == 1)
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_generator_try1"));
    if (GameDataController.gd.getObjectiveDetail("barn_pump_start_try") == 2)
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_generator_try2"));
    if (GameDataController.gd.getObjectiveDetail("barn_pump_start_try") == 3)
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_generator_try3"));
    if (GameDataController.gd.getObjectiveDetail("barn_pump_start_try") != 4 || !GameDataController.gd.getObjective("barn_pump_started"))
      return;
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_generator_try4"));
  }

  public void no_pull_pull()
  {
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("barn_pump_started"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_pump_running"));
    else if (GameDataController.gd.getObjectiveDetail("barn_pump_started") == 0)
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_pump_no_output"));
    }
    else
    {
      this.gameObject.GetComponent<Animator>().Play("b_pull_pull", 0);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.pull_recoil);
      if (GameDataController.gd.getObjectiveDetail("barn_pump_started") != 0 && GameDataController.gd.getObjective("barn_pump_fueled"))
      {
        if (GameDataController.gd.getObjectiveDetail("barn_pump_start_try") == 0)
        {
          this.bbgo.aS.Stop();
          this.bbgo.aS.loop = false;
          this.bbgo.aS.volume = 0.25f;
          this.bbgo.aS.PlayOneShot(SoundsManagerController.sm.engine_fail);
          PlayerController.pc.setBusy(true);
          GameDataController.gd.setObjectiveDetail("barn_pump_start_try", 1);
        }
        else if (GameDataController.gd.getObjectiveDetail("barn_pump_start_try") == 1)
        {
          this.bbgo.aS.Stop();
          this.bbgo.aS.volume = 0.25f;
          this.bbgo.aS.loop = false;
          this.bbgo.aS.PlayOneShot(SoundsManagerController.sm.engine_fail);
          PlayerController.pc.setBusy(true);
          GameDataController.gd.setObjectiveDetail("barn_pump_start_try", 2);
        }
        else
        {
          this.bbgo.aS.Stop();
          this.bbgo.aS.volume = 0.25f;
          this.bbgo.aS.loop = false;
          this.bbgo.aS.PlayOneShot(SoundsManagerController.sm.engine_start);
          PlayerController.pc.setBusy(true);
          if (GameDataController.gd.getObjectiveDetail("barn_pump_start_try") == 2)
            GameDataController.gd.setObjectiveDetail("barn_pump_start_try", 3);
          else
            GameDataController.gd.setObjectiveDetail("barn_pump_start_try", 4);
          GameDataController.gd.setObjective("barn_pump_started", true);
        }
      }
      else if (!GameDataController.gd.getObjective("barn_pump_fueled"))
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_pump_no_fuel"));
      else if (GameDataController.gd.getObjectiveDetail("barn_pump_started") == 0)
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_pump_no_output"));
      this.setCollider(-1);
      this.Invoke("unlockIt", 1.5f);
      this.updateAll();
    }
  }

  public void updateAfterAnimation() => this.updateState();

  public override void updateState()
  {
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
