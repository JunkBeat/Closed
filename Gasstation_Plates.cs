// Decompiled with JetBrains decompiler
// Type: Gasstation_Plates
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gasstation_Plates : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_s";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.range = 1f;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_plates";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("rock", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("hammer", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("pipe", GameStrings.getString(GameStrings.actions, "plates_throw"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("wrench", GameStrings.getString(GameStrings.actions, "plates_throw"), anim: string.Empty));
    this.updateState();
  }

  public override void clickAction()
  {
    if (this.usedItem != string.Empty)
    {
      if (GameDataController.gd.getObjective("gasstation_spider_discovered") && GameDataController.gd.getCurrentDay() == 1)
      {
        GameObject.Find("fly_object").GetComponent<GasstationFlyObjectController>().fly(ItemsManager.im.getItem(this.usedItem));
        InventoryController.ic.removeItem(this.usedItem);
        this.Invoke("play_animation", 0.3f);
        this.Invoke("hiss", 0.5f);
        this.Invoke("run_like_hell", 1.5f);
      }
      else
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "gasstation_plates_no_need"), true);
    }
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "gasstation_plates_noise"), true);
  }

  public void stopAnimation()
  {
    this.GetComponent<Animator>().Play("plates_still");
    this.setCollider(-1);
    this.GetComponent<SpriteRenderer>().enabled = false;
  }

  private void hiss() => GameObject.Find("Spider").GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.hiss);

  private void play_animation()
  {
    this.GetComponent<Animator>().Play("plates_crash");
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.plates_break);
    GameDataController.gd.setObjective("gasstation_spider_baited", true);
    Vector3 position = new Vector3(-0.277f, -0.3843064f, 0.0f);
    (Object.Instantiate(Resources.Load("Prefabs/GroundItem"), position, new Quaternion()) as GameObject).GetComponent<GroundItemController>().init(ItemsManager.im.getItem(this.usedItem));
    ItemsManager.im.getItem(this.usedItem).dataRef.locX = 90;
    ItemsManager.im.getItem(this.usedItem).dataRef.locY = 26;
    ItemsManager.im.getItem(this.usedItem).dataRef.droppedLocation = SceneManager.GetActiveScene().name;
  }

  private void run_like_hell()
  {
    PlayerController.wc.forceAnimation("stand_ne");
    PlayerController.pc.spawnName = "Waypoint_Gasstation1_GasstationRoom2";
    CurtainController.cc.fadeOut("LocationGasstation1", WalkController.Direction.S);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
    {
      this.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
      if (!GameDataController.gd.getObjective("gasstation_spider_baited"))
        this.GetComponent<Animator>().Play("plates_still");
      else
        this.GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
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
    if (this.usedItem != string.Empty && GameDataController.gd.getObjective("gasstation_spider_discovered") && GameDataController.gd.getCurrentDay() == 1)
    {
      this.characterAnimationName = "throw_s";
      this.range = 1f;
    }
    else
    {
      this.characterAnimationName = "action_stnd_s";
      this.range = 100f;
    }
  }
}
