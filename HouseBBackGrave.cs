// Decompiled with JetBrains decompiler
// Type: HouseBBackGrave
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class HouseBBackGrave : ObjectActionController
{
  public Sprite sprite1;
  public Sprite sprite2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "house_b_back_ground";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("shovel", string.Empty, anim: string.Empty));
    this.updateState();
  }

  private void Update()
  {
    if (!GameDataController.gd.getObjective("house_b_grave_dug"))
    {
      if (CursorController.cc.selectedItemName == "shovel" && GameDataController.gd.getCurrentDay() == 2)
        this.setCollider(1);
      else
        this.setCollider(-1);
    }
    else
    {
      if (!GameDataController.gd.getObjective("house_b_grave_dug"))
        return;
      if (CursorController.cc.selectedItemName == "shovel")
        this.setCollider(0);
      else
        this.setCollider(0);
    }
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("house_b_grave_dug"))
    {
      if (!(this.usedItem == "shovel"))
        return;
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "barrys_wife_grave"), yesClick: new Button.Delegate(this.digGrave), time: 90, timeSaver: 30);
    }
    else if (GameDataController.gd.getObjective("house_b_grave_filled"))
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "house_b_grave"), true);
    else
      PlayerController.pc.say("...");
  }

  public void digGrave()
  {
    GameDataController.gd.setObjective("house_b_grave_dug", true);
    this.Invoke("digging_end", 3f);
    PlayerController.wc.forceAnimation("dig_start", true);
  }

  public void digging_end() => CurtainController.cc.fadeOut(targetDir: WalkController.Direction.S, animation: "dig_end", flipX: true, actionAfterFade: new CurtainController.Delegate(this.digGrave2));

  public void digGrave2()
  {
    Vector3 nearestFullPixel = ScreenControler.roundToNearestFullPixel(GameObject.Find("digged_grave_marker").transform.position);
    GameObject.Find("Location").transform.Find("plane00a (2)").GetComponent<SpriteRenderer>().enabled = true;
    PlayerController.wc.currentXY = new Vector2(nearestFullPixel.x, nearestFullPixel.y);
    PlayerController.wc.setSimpleTarget(new Vector2(nearestFullPixel.x, nearestFullPixel.y));
    this.Invoke("exitGrave", 3f);
  }

  public void exitGrave()
  {
    PlayerController.wc.forceAnimation("climb_se");
    this.Invoke("exitGrave2", 1.3f);
  }

  public void exitGrave2()
  {
    Vector3 nearestFullPixel = ScreenControler.roundToNearestFullPixel(GameObject.Find("digged_grave_marker_exit").transform.position);
    PlayerController.wc.currentXY = new Vector2(nearestFullPixel.x, nearestFullPixel.y);
    PlayerController.wc.setSimpleTarget(new Vector2(nearestFullPixel.x, nearestFullPixel.y));
    this.Invoke("exitGrave2a", 0.1f);
  }

  public void exitGrave2a()
  {
    Vector3 nearestFullPixel = ScreenControler.roundToNearestFullPixel(GameObject.Find("digged_grave_marker_exit2").transform.position);
    PlayerController.wc.currentXY = new Vector2(nearestFullPixel.x, nearestFullPixel.y);
    PlayerController.wc.setSimpleTarget(new Vector2(nearestFullPixel.x, nearestFullPixel.y));
    this.Invoke("exitGrave2b", 0.2f);
  }

  public void exitGrave2b()
  {
    Vector3 nearestFullPixel = ScreenControler.roundToNearestFullPixel(GameObject.Find("digged_grave_marker_exit2").transform.position);
    PlayerController.wc.currentXY = new Vector2(nearestFullPixel.x, nearestFullPixel.y);
    PlayerController.wc.setSimpleTarget(new Vector2(nearestFullPixel.x, nearestFullPixel.y));
    this.Invoke("exitGrave2c", 0.2f);
  }

  public void exitGrave2c()
  {
    Vector3 nearestFullPixel = ScreenControler.roundToNearestFullPixel(GameObject.Find("digged_grave_marker_exit3").transform.position);
    PlayerController.wc.currentXY = new Vector2(nearestFullPixel.x, nearestFullPixel.y);
    PlayerController.wc.setSimpleTarget(new Vector2(nearestFullPixel.x, nearestFullPixel.y));
    this.Invoke("exitGrave2d", 0.2f);
  }

  public void exitGrave2d()
  {
    Vector3 nearestFullPixel = ScreenControler.roundToNearestFullPixel(GameObject.Find("digged_grave_marker_exit4").transform.position);
    PlayerController.wc.currentXY = new Vector2(nearestFullPixel.x, nearestFullPixel.y);
    PlayerController.wc.setSimpleTarget(new Vector2(nearestFullPixel.x, nearestFullPixel.y));
    this.Invoke("exitGrave3", 0.2f);
  }

  public void exitGrave3()
  {
    Vector3 nearestFullPixel = ScreenControler.roundToNearestFullPixel(GameObject.Find("Grave").transform.Find("Action_Marker").transform.position);
    GameObject.Find("Location").transform.Find("plane00a (2)").GetComponent<SpriteRenderer>().enabled = false;
    PlayerController.wc.setSimpleTarget(new Vector2(nearestFullPixel.x, nearestFullPixel.y));
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("house_b_grave_dug"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.sprite1;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.objectName = "house_b_back_ground";
    }
    else if (GameDataController.gd.getObjective("house_b_grave_filled"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.sprite2;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.objectName = "house_b_back_grave";
    }
    else
    {
      this.objectName = "house_b_back_hole";
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.sprite1;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
  }

  public override void clickAction2() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.digger);

  public override void clickAction0()
  {
  }
}
