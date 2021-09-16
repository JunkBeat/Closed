// Decompiled with JetBrains decompiler
// Type: TutorialWall
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class TutorialWall : ObjectActionController
{
  public ParticleGenerator smash1;
  public ParticleGenerator smash2;
  public ParticleGenerator smash3;
  public SpriteRenderer sr;
  public Sprite s1;
  public Sprite s2;
  public Sprite s3;
  public AudioSource aS;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "break_wall";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.actionType = ObjectActionController.Type.NormalAction;
    this.objectName = "tutorial_wall1";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("sledgehammer", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("sledge_handle", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("sledge_head", GameStrings.getString(GameStrings.actions, "tutorial_wall_head"), anim: string.Empty));
  }

  public void creak1() => this.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.door_creak_1);

  public void creak2() => this.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.door_creak_2);

  public void creak3() => this.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.door_creak_3);

  public override void clickAction()
  {
    if (this.usedItem == "sledgehammer")
    {
      if (!GameDataController.gd.getObjective("tutorial_wall_smashed"))
      {
        this.smash1.started = true;
        this.Invoke("stopSmash1", 0.3f);
        this.Invoke("ssmash2", 2f);
        this.Invoke("ssmash3", 4f);
        this.aS.PlayOneShot(SoundsManagerController.sm.rock_hit_1);
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.rock_rumble_1);
        GameDataController.gd.setObjective("tutorial_wall_smashed", true);
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "tutorial_wall_already_smashed"));
    }
    else if (this.usedItem == "sledge_handle")
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "tutorial_wall_fail"));
    else if (!GameDataController.gd.getObjective("tutorial_wall_smashed"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "tutorial_wall"));
    }
    else
    {
      PlayerController.pc.spawnName = "Fence3Waypoint1";
      CurtainController.cc.fadeOut("LocationDesertFence3", WalkController.Direction.E, "window_jump");
    }
  }

  public void ssmash2()
  {
    this.smash2.started = true;
    this.Invoke("stopSmash2", 0.3f);
    this.aS.PlayOneShot(SoundsManagerController.sm.rock_hit_2);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.rock_rumble_2);
  }

  public void ssmash3()
  {
    this.smash3.started = true;
    this.Invoke("stopSmash3", 0.4f);
    this.aS.PlayOneShot(SoundsManagerController.sm.rock_hit_3);
    this.objectName = "tutorial_wall2";
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.rock_rumble_3);
  }

  public void stopSmash1()
  {
    this.smash1.started = false;
    this.sr.enabled = true;
    this.sr.sprite = this.s1;
  }

  public void stopSmash2()
  {
    this.smash2.started = false;
    this.sr.enabled = true;
    this.sr.sprite = this.s2;
  }

  public void stopSmash3()
  {
    this.smash3.started = false;
    this.sr.enabled = true;
    this.sr.sprite = this.s3;
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("tutorial_wall_smashed"))
    {
      this.sr.enabled = true;
      this.sr.sprite = this.s3;
      this.objectName = "tutorial_wall2";
      this.actionType = ObjectActionController.Type.Transition;
      this.trans_dir = WalkController.Direction.N;
    }
    else
    {
      this.objectName = "tutorial_wall1";
      this.actionType = ObjectActionController.Type.NormalAction;
      this.trans_dir = WalkController.Direction.N;
      this.sr.enabled = false;
    }
  }

  public override void clickAction2() => PlayerController.pc.GetComponent<Animator>().speed = 1f;

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
    if (this.usedItem == "sledgehammer" && !GameDataController.gd.getObjective("tutorial_wall_smashed"))
    {
      this.characterAnimationName = "break_wall";
      this.animationFlip = true;
      this.useCurrentDirection = false;
      this.range = 1f;
    }
    else if (this.usedItem == "sledge_handle" && !GameDataController.gd.getObjective("tutorial_wall_smashed"))
    {
      this.characterAnimationName = "break_wall_fail";
      this.animationFlip = true;
      this.useCurrentDirection = false;
      this.range = 1f;
    }
    else if (GameDataController.gd.getObjective("tutorial_wall_smashed"))
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 2f;
    }
    else
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 50f;
    }
  }

  public override void whatOnClick()
  {
  }
}
