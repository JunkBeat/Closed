// Decompiled with JetBrains decompiler
// Type: MixerButtonMix
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class MixerButtonMix : ObjectActionController
{
  private SpriteRenderer sr;
  public Sprite sprite_1;
  public Sprite sprite_2;
  public Sprite sprite_3;
  public SpriteRenderer comps1;
  public SpriteRenderer comps2;
  private int liczba;
  public string thisNumber;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "mixer_button_big";
    this.range = 8000f;
    this.teleport = false;
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
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
    this.countThem();
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.button_click);
    if (GameDataController.gd.getObjective("sidereal_mixer_mixed") && GameDataController.gd.getObjectiveDetail("sidereal_mixer_mixed") > 0)
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_mixer_button_already_done"));
    else if (GameDataController.gd.getObjective("sidereal_mixer_mixed") && GameDataController.gd.getObjectiveDetail("sidereal_mixer_mixed") == 0)
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_mixer_tray_full"));
    else if (this.liczba < 3)
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_mixer_button_not_complete"));
    else
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "mixer"), yesClick: new Button.Delegate(this.yesMix), time: 15);
  }

  public void yesMix()
  {
    GameDataController.gd.setObjective("sidereal_mixer_mixed", true);
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    if (GameDataController.gd.getObjective("sidereal_mixer_b1"))
    {
      num1 += 2;
      ++num2;
      num3 = num3;
    }
    if (GameDataController.gd.getObjective("sidereal_mixer_b2"))
    {
      ++num1;
      num2 += 2;
      num3 = num3;
    }
    if (GameDataController.gd.getObjective("sidereal_mixer_b3"))
    {
      ++num1;
      num2 = num2;
      num3 += 2;
    }
    if (GameDataController.gd.getObjective("sidereal_mixer_b4"))
    {
      num1 = num1;
      ++num2;
      num3 += 2;
    }
    if (GameDataController.gd.getObjective("sidereal_mixer_b5"))
    {
      num1 = num1;
      num2 += 2;
      ++num3;
    }
    if (GameDataController.gd.getObjective("sidereal_mixer_b6"))
    {
      num1 += 2;
      num2 = num2;
      ++num3;
    }
    if (num1 == 2 && num2 == 4 && num3 == 3)
      GameDataController.gd.setObjectiveDetail("sidereal_mixer_mixed", 1);
    else if (num1 == 4 && num2 == 2 && num3 == 3)
      GameDataController.gd.setObjectiveDetail("sidereal_mixer_mixed", 2);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.mixer);
    PlayerController.pc.setBusy(true);
    PlayerController.pc.spawnName = "LocationMixerExit";
    CurtainController.cc.fadeOut("SiderealMixer", WalkController.Direction.N, actionAfterFade: new CurtainController.Delegate(this.doneMixing));
  }

  public void doneMixing() => PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_mixer_complete"));

  private void countThem()
  {
    this.liczba = 0;
    if (GameDataController.gd.getObjective("sidereal_mixer_b1"))
      ++this.liczba;
    if (GameDataController.gd.getObjective("sidereal_mixer_b2"))
      ++this.liczba;
    if (GameDataController.gd.getObjective("sidereal_mixer_b3"))
      ++this.liczba;
    if (GameDataController.gd.getObjective("sidereal_mixer_b4"))
      ++this.liczba;
    if (GameDataController.gd.getObjective("sidereal_mixer_b5"))
      ++this.liczba;
    if (!GameDataController.gd.getObjective("sidereal_mixer_b6"))
      return;
    ++this.liczba;
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("sidereal_components_1"))
      this.comps1.enabled = true;
    else
      this.comps1.enabled = false;
    if (GameDataController.gd.getObjective("sidereal_components_2"))
      this.comps2.enabled = true;
    else
      this.comps2.enabled = false;
    this.setCollider(0);
    this.countThem();
    if (this.liczba == 0)
    {
      this.sr.enabled = false;
    }
    else
    {
      this.sr.enabled = true;
      if (this.liczba == 1)
        this.sr.sprite = this.sprite_1;
      if (this.liczba == 2)
        this.sr.sprite = this.sprite_2;
      if (this.liczba != 3)
        return;
      this.sr.sprite = this.sprite_3;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
