// Decompiled with JetBrains decompiler
// Type: BarnSprinkles
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BarnSprinkles : ObjectActionController
{
  private AudioClip soundOpen;
  private AudioClip soundClose;
  private GameObject lights;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "kick_ne";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "barn_sprinklers_disabled";
    this.setCollider(0);
    this.lights = this.gameObject.transform.Find("SprinklesLights").gameObject;
  }

  public override void updateState()
  {
    if (GameDataController.gd.getCurrentDay() > 1 || GameDataController.gd.getObjectiveDetail("barn_pump_started") != 2 || !GameDataController.gd.getObjective("barn_pump_started"))
    {
      this.lights.GetComponent<Animator>().Play("sprinkles_off", 0);
      this.objectName = "barn_sprinklers_disabled";
    }
    else if (!GameDataController.gd.getObjective("barn_sprinklers_enabled"))
    {
      this.lights.GetComponent<Animator>().Play("sprinkles_lights", 0);
      this.objectName = "barn_sprinklers_enabled";
    }
    else
    {
      this.lights.GetComponent<Animator>().Play("sprinkles_on", 0);
      this.objectName = "barn_sprinklers_set";
    }
  }

  public override void whatOnClick()
  {
    if (!GameDataController.gd.getObjective("base_discovered"))
      this.characterAnimationName = "action_stnd_n";
    else if (GameDataController.gd.getObjectiveDetail("barn_pump_started") == 2 && GameDataController.gd.getObjective("barn_pump_started") || this.usedItem != string.Empty)
      this.characterAnimationName = "action_n";
    else
      this.characterAnimationName = "kick_ne";
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("base_discovered"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_pipe_first"));
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("barn_pump_started") != 2 || !GameDataController.gd.getObjective("barn_pump_started"))
      {
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "barn_sprinklers_no_power"), true);
      }
      else
      {
        if (GameDataController.gd.getCurrentDay() > 1)
        {
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "barn_sprinklers_broken"));
          return;
        }
        PlayerController.pc.spawnName = "BarnConsoleExit";
        CurtainController.cc.fadeOut("BarnConsole", WalkController.Direction.W);
      }
      this.updateState();
      PlayerController.wc.forceDirection(WalkController.Direction.NE);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
