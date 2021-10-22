// Decompiled with JetBrains decompiler
// Type: SpiderOutsideController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class SpiderOutsideController : ObjectActionController
{
  private float realX = 23f / 1000f;
  private bool peopleShottingAtUs;
  private bool runLikeHell;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "sit_shoot";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "nasty_spider";
    this.teleport = true;
    this.setCollider(0);
    this.updateState();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("rifle_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_6", string.Empty, anim: string.Empty));
    this.gameObject.GetComponent<Animator>().Play("walk");
    this.peopleShottingAtUs = false;
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjective("gasstation_spider_baited") && !GameDataController.gd.getObjective("gasstation_spider_shot") && ItemsManager.im.getItem("rifle_6").dataRef.droppedLocation.ToLower().IndexOf("inventory") != -1)
    {
      PlayerController.pc.allowDrop = false;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.setCollider(0);
    }
    else
    {
      PlayerController.pc.allowDrop = true;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.setCollider(-1);
    }
  }

  private void Update()
  {
    if (!this.GetComponent<SpriteRenderer>().enabled)
      return;
    this.gameObject.transform.position = new Vector3(this.realX, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    this.actionMarker.transform.position = new Vector3(PlayerController.pc.gameObject.transform.position.x, -0.318f, this.actionMarker.transform.position.z);
    if (!this.peopleShottingAtUs)
    {
      this.realX += (float) (0.000500000023748726 * (double) Time.deltaTime * 60.0);
      if ((double) this.realX > 0.379999995231628)
      {
        this.realX = 0.38f;
        this.gameObject.GetComponent<Animator>().Play("tease");
      }
      else if ((double) this.realX > 0.300000011920929)
        this.realX -= (float) (0.000300000014249235 * (double) Time.deltaTime * 60.0);
      else
        this.gameObject.GetComponent<Animator>().Play("walk_slow");
      this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }
    if (!this.runLikeHell)
      return;
    this.realX -= (float) (0.0199999995529652 * (double) Time.deltaTime * 60.0);
    if ((double) this.realX < -1.79999995231628)
      this.realX = -1.8f;
    this.gameObject.GetComponent<Animator>().Play("walk_fast");
    this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
  }

  public override void clickAction()
  {
    if (this.usedItem.IndexOf("rifle_") == -1)
      return;
    this.peopleShottingAtUs = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.dir = WalkController.Direction.W;
    this.gameObject.GetComponent<Animator>().Play("attack");
    GameDataController.gd.setObjective("gasstation_spider_shot", true);
    PlayerController.pc.allowDrop = true;
    ItemsManager.im.rifleShot(this.usedItem, false);
    this.Invoke("showClock", 3f);
  }

  public void showClock() => GameObject.Find("clock").GetComponent<ClockController>().showFinal();

  public override void whatOnClick()
  {
    if (this.usedItem.IndexOf("rifle_") != -1)
    {
      this.characterAnimationName = "sit_shoot";
      this.animationFlip = true;
      this.useCurrentDirection = false;
      PlayerController.wc.speed = 0.0f;
      PlayerController.pc.textField.dissmiss();
      this.setCollider(-1);
    }
    else
    {
      PlayerController.wc.setCurrentAnimClip("sit_strugle");
      PlayerController.wc.fullStop(true);
    }
  }

  public override void whatOnClick0()
  {
    if (this.usedItem.IndexOf("rifle_") == -1)
    {
      this.range = 1f;
      this.teleport = false;
      PlayerController.wc.setCurrentAnimClip("sit_strugle");
      PlayerController.wc.fullStop(true);
    }
    else
    {
      this.range = 1000f;
      this.teleport = true;
      this.characterAnimationName = "sit_shoot";
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjective("gasstation_spider_baited") && !GameDataController.gd.getObjective("gasstation_spider_shot") && ItemsManager.im.getItem("rifle_6").dataRef.droppedLocation.ToLower().IndexOf("inventory") != -1)
      this.setCollider(0);
    else
      this.setCollider(-1);
  }

  public override void clickAction2() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.rifle_shoot);

  public override void clickAction0()
  {
  }

  public void hitAndRun()
  {
    this.runLikeHell = true;
    this.realX -= 0.4f;
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_2a);
  }

  public void hiss()
  {
    this.gameObject.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.hiss);
    this.updateAll();
  }
}
