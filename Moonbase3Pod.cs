// Decompiled with JetBrains decompiler
// Type: Moonbase3Pod
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class Moonbase3Pod : ObjectActionController
{
  public string whose;
  public string numerek;
  public GameObject person;
  public AudioSource audioSouruce2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "moonbase_pod_empty";
    this.range = 10f;
  }

  public bool waitForOthers()
  {
    bool flag1 = true;
    bool flag2 = true;
    bool flag3 = true;
    if (!GameDataController.gd.getObjective("npc1_alive") || GameDataController.gd.getObjective("moon_cate_sleeps"))
      flag1 = false;
    if (!GameDataController.gd.getObjective("npc2_alive") || GameDataController.gd.getObjective("moon_barry_sleeps"))
      flag3 = false;
    if (!GameDataController.gd.getObjective("npc3_alive") || GameDataController.gd.getObjective("moon_cody_sleeps"))
      flag2 = false;
    if (flag1 && (flag2 || flag3))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moonbase_pod_wait_others"));
      return true;
    }
    if (flag1)
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moonbase_pod_wait_cate"));
      return true;
    }
    if (flag2 && flag3)
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moonbase_pod_wait_others"));
      return true;
    }
    if (flag2)
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moonbase_pod_wait_cody"));
      return true;
    }
    if (!flag3)
      return false;
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moonbase_pod_wait_barry"));
    return true;
  }

  public void makeSound() => this.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.pods);

  public void failsound(string s = "") => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.fail1);

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("moon_pods_unlocked"))
    {
      if (this.whose == "david")
      {
        if (GameDataController.gd.getObjective("moon_david_sleeps") || this.waitForOthers())
          return;
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "moon_use_pod"), yesClick: new Button.Delegate(this.enterPod));
      }
      else if (this.whose == "cate")
      {
        if (GameDataController.gd.getObjective("npc1_alive"))
        {
          if (GameDataController.gd.getObjective("moon_cate_sleeps"))
            PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moonbase_pod_cate"));
          else
            this.waitForOthers();
        }
        else
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moonbase_pod_closed"));
      }
      else if (this.whose == "barry")
      {
        if (GameDataController.gd.getObjective("npc2_alive"))
        {
          if (GameDataController.gd.getObjective("moon_barry_sleeps"))
            PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moonbase_pod_barry"));
          else
            this.waitForOthers();
        }
        else
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moonbase_pod_closed"));
      }
      else
      {
        if (!(this.whose == "cody"))
          return;
        if (GameDataController.gd.getObjective("npc3_alive"))
        {
          if (GameDataController.gd.getObjective("moon_cody_sleeps"))
            PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moonbase_pod_cody"));
          else
            this.waitForOthers();
        }
        else
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moonbase_pod_closed"));
      }
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moonbase_pod_closed"));
  }

  public void enterPod()
  {
    if (!GameDataController.gd.getObjective("moon_light_restored"))
    {
      if (!GameDataController.gd.getObjective("moon_light_failed"))
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.power_down_big, 0.75f);
        GameDataController.gd.setObjective("moon_light_failed", true);
        GameObject.Find("LocationManager").GetComponent<LocationMoonbase3Start>().updateMLF();
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moon_power_failure_1"));
        this.audioSouruce2.clip = SoundsManagerController.sm.ambient_ship_crashed;
        this.audioSouruce2.gameObject.GetComponent<AudioReverbFilter>().reverbPreset = AudioReverbPreset.PaddedCell;
        this.audioSouruce2.volume = 0.75f;
        this.audioSouruce2.loop = true;
        this.audioSouruce2.pitch = 0.25f;
        this.audioSouruce2.Play();
      }
      else
      {
        this.gameObject.transform.Find("TextField").transform.position = ScreenControler.roundToNearestFullPixel3(this.gameObject.transform.Find("TextField").transform.position);
        TimelineAction timelineAction = new TimelineAction();
        Timeline.t.addAction(new TimelineAction()
        {
          textfield = this.gameObject.transform.Find("TextField").GetComponent<TextFieldController>(),
          textColor = new Vector3(1f, 0.0f, 0.0f),
          backgroundColor = new Vector3(0.5f, 0.0f, 0.0f),
          text = GameStrings.getString(GameStrings.actions, "moon_power_failure_2"),
          actionWithText = true,
          function = new TimelineFunction(this.failsound)
        });
      }
    }
    else
    {
      PlayerController.pc.forceAnimation("stop");
      PlayerController.pc.setBusy(true);
      PlayerController.pc.spawnName = "david_pod";
      Timeline.t.doNotUnlock = true;
      GameDataController.gd.setObjective("moon_david_sleeps", true);
      CurtainController.cc.fadeOut("LocationMoonbase3", WalkController.Direction.NW, "stand_ne", flipX: true);
    }
  }

  public void openIfNeeded(bool close = false)
  {
    string str = "open";
    if (close)
      str = nameof (close);
    if (this.whose == "david")
      this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_" + str);
    else if (this.whose == "cate")
    {
      if (!GameDataController.gd.getObjective("npc1_alive"))
        return;
      this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_" + str);
    }
    else if (this.whose == "barry")
    {
      if (!GameDataController.gd.getObjective("npc2_alive"))
        return;
      this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_" + str);
    }
    else
    {
      if (!(this.whose == "cody") || !GameDataController.gd.getObjective("npc3_alive"))
        return;
      this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_" + str);
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("moon_pods_unlocked"))
    {
      this.objectName = "moonbase_pod_empty";
      if (this.whose == "david")
      {
        if (GameDataController.gd.getObjective("moon_david_sleeps"))
        {
          this.objectName = "moonbase_pod_david";
          if (GameDataController.gd.getObjectiveDetail("moon_david_sleeps") == 1)
            this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_closed");
          else
            this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_opened");
          this.person.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
          this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_opened");
          this.person.GetComponent<SpriteRenderer>().enabled = false;
        }
      }
      else if (this.whose == "cate")
      {
        if (GameDataController.gd.getObjective("npc1_alive"))
        {
          if (GameDataController.gd.getObjective("moon_cate_sleeps"))
          {
            this.objectName = "moonbase_pod_cate";
            if (GameDataController.gd.getObjectiveDetail("moon_cate_sleeps") == 1)
              this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_closed");
            else
              this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_opened");
            this.person.GetComponent<SpriteRenderer>().enabled = true;
          }
          else
          {
            this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_opened");
            this.person.GetComponent<SpriteRenderer>().enabled = false;
          }
        }
        else
        {
          this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_closed");
          this.person.GetComponent<SpriteRenderer>().enabled = false;
        }
      }
      else if (this.whose == "barry")
      {
        if (GameDataController.gd.getObjective("npc2_alive"))
        {
          if (GameDataController.gd.getObjective("moon_barry_sleeps"))
          {
            this.objectName = "moonbase_pod_barry";
            if (GameDataController.gd.getObjectiveDetail("moon_barry_sleeps") == 1)
              this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_closed");
            else
              this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_opened");
            this.person.GetComponent<SpriteRenderer>().enabled = true;
          }
          else
          {
            this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_opened");
            this.person.GetComponent<SpriteRenderer>().enabled = false;
          }
        }
        else
        {
          this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_closed");
          this.person.GetComponent<SpriteRenderer>().enabled = false;
        }
      }
      else
      {
        if (!(this.whose == "cody"))
          return;
        if (GameDataController.gd.getObjective("npc3_alive"))
        {
          if (GameDataController.gd.getObjective("moon_cody_sleeps"))
          {
            this.objectName = "moonbase_pod_cody";
            if (GameDataController.gd.getObjectiveDetail("moon_cody_sleeps") == 1)
              this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_closed");
            else
              this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_opened");
            this.person.GetComponent<SpriteRenderer>().enabled = true;
          }
          else
          {
            this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_opened");
            this.person.GetComponent<SpriteRenderer>().enabled = false;
          }
        }
        else
        {
          this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_closed");
          this.person.GetComponent<SpriteRenderer>().enabled = false;
        }
      }
    }
    else
    {
      this.objectName = "moonbase_pod_empty";
      this.GetComponent<Animator>().Play("moon_pod" + this.numerek + "_closed");
      this.person.GetComponent<SpriteRenderer>().enabled = false;
    }
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
