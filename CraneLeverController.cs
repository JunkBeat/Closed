// Decompiled with JetBrains decompiler
// Type: CraneLeverController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class CraneLeverController : ObjectActionController
{
  public Sprite position1;
  public Sprite position2;
  public int leverNumber;
  public CraneThing craneThing;
  private string varname = string.Empty;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action1_e_busy";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_crane_lever_" + (object) this.leverNumber;
    this.range = 1f;
    this.varname = this.leverNumber != 0 ? (this.leverNumber != 1 ? "cs_crane_closed" : "cs_crane_down") : "cs_crane_left";
    this.updateState();
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("cs_pack_lifted"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "crane_lifted"));
    }
    else
    {
      if (this.varname == "cs_crane_down" && GameDataController.gd.getObjective("cs_crane_left") && GameDataController.gd.getObjective("cs_crane_down") && GameDataController.gd.getObjective("cs_crane_closed") && GameDataController.gd.getObjective("cs_engine_started"))
      {
        GameDataController.gd.setObjective("cs_pack_lifted", true);
        this.updateAll();
      }
      GameDataController.gd.setObjective(this.varname, !GameDataController.gd.getObjective(this.varname));
      if (GameDataController.gd.getObjective(this.varname))
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.lever1);
      else
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.lever2);
      this.updateState();
      if (GameDataController.gd.getObjective("cs_engine_started"))
      {
        if (GameDataController.gd.getObjective("cs_pack_lifted"))
        {
          this.craneThing.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.hydra2);
          this.Invoke("unlockPlayer", 3f);
        }
        else if (this.varname != "cs_crane_closed")
        {
          PlayerController.pc.haltSoftLockProbe();
          if (!GameDataController.gd.getObjective("cs_crane_left") && GameDataController.gd.getObjective("cs_crane_closed") && GameDataController.gd.getObjective("cs_crane_down") && this.varname == "cs_crane_left")
          {
            GameDataController.gd.setObjective("cs_crane_left", true);
            GameDataController.gd.setObjective("cs_crane_down", true);
            GameDataController.gd.setObjective("cs_crane_closed", true);
            this.craneThing.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.hydra1);
            this.Invoke("okokok", 0.2f);
          }
          else
          {
            this.craneThing.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.hydra2);
            this.Invoke("unlockPlayer", 3.2f);
          }
        }
        else
        {
          PlayerController.pc.haltSoftLockProbe();
          this.craneThing.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.hydra1);
          this.Invoke("unlockPlayer", 1f);
        }
      }
      else
        this.Invoke("noFuel", 1f);
    }
  }

  public void noFuel()
  {
    GameDataController.gd.setObjective(this.varname, !GameDataController.gd.getObjective(this.varname));
    this.updateState();
    PlayerController.pc.setBusy(false);
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_leaver_no_power"));
    if (GameDataController.gd.getObjective(this.varname))
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.lever1);
    else
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.lever2);
  }

  public void okokok()
  {
    this.updateState();
    this.craneThing.updateState();
    this.Invoke("unlockPlayer2", 1f);
  }

  public void unlockPlayer2()
  {
    PlayerController.pc.resumeSoftLockProbe();
    PlayerController.pc.setBusy(false);
  }

  public void unlockPlayer()
  {
    if (GameDataController.gd.getObjective("cs_crane_left") && GameDataController.gd.getObjective("cs_crane_closed") && GameDataController.gd.getObjective("cs_crane_down") && (this.varname == "cs_crane_down" || this.varname == "cs_crane_left") || GameDataController.gd.getObjective("cs_crane_left") && !GameDataController.gd.getObjective("cs_crane_closed") && GameDataController.gd.getObjective("cs_crane_down") && this.varname == "cs_crane_left")
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_bang1, 1f);
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "crane_collision"));
      GameDataController.gd.setObjective(this.varname, false);
      if (GameDataController.gd.getObjective("cs_pack_lifted"))
        this.craneThing.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.hydra1);
      else
        this.craneThing.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.hydra2);
      PlayerController.pc.setBusy(true);
      this.updateState();
      if (this.varname == "cs_crane_closed")
        this.Invoke(nameof (unlockPlayer), 1f);
      else
        this.Invoke(nameof (unlockPlayer), 3f);
    }
    else
    {
      PlayerController.pc.resumeSoftLockProbe();
      PlayerController.pc.textField.dissmiss(true);
      PlayerController.pc.setBusy(false);
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("cs_pack_lifted"))
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
    else
    {
      this.characterAnimationName = "action1_e_busy";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    if (GameDataController.gd.getObjective(this.varname))
      this.GetComponent<SpriteRenderer>().sprite = this.position2;
    else
      this.GetComponent<SpriteRenderer>().sprite = this.position1;
    if (!GameDataController.gd.getObjective("cs_engine_started"))
      return;
    this.craneThing.updateState();
  }

  public void hideLever()
  {
    this.setCollider(-1);
    this.GetComponent<SpriteRenderer>().enabled = false;
  }

  public void showLever()
  {
    this.setCollider(0);
    this.GetComponent<SpriteRenderer>().enabled = true;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}
