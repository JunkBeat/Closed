// Decompiled with JetBrains decompiler
// Type: LocationBaseOutside2Greenhouse
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationBaseOutside2Greenhouse : ObjectActionController
{
  public Sprite sprite1;
  public Sprite sprite2;
  public Sprite sprite3;
  public Sprite sprite4;
  public Sprite sprite5;
  private SpriteRenderer sr;

  private void Start()
  {
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = true;
    this.characterAnimationName = "action_stnd_";
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "greenhouse_nails";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("crowbar", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("hammer", string.Empty, anim: string.Empty));
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("greenhouse_nails") == 4)
    {
      this.sr.sprite = this.sprite1;
      this.objectName = "greenhouse_nails";
      this.setCollider(0);
    }
    else if (GameDataController.gd.getObjectiveDetail("greenhouse_nails") == 3)
    {
      this.sr.sprite = this.sprite2;
      this.objectName = "greenhouse_nails";
      this.setCollider(1);
    }
    else if (GameDataController.gd.getObjectiveDetail("greenhouse_nails") == 2)
    {
      this.sr.sprite = this.sprite3;
      this.objectName = "greenhouse_nails";
      this.setCollider(2);
    }
    else if (GameDataController.gd.getObjectiveDetail("greenhouse_nails") == 1)
    {
      this.sr.sprite = this.sprite4;
      this.objectName = "greenhouse_nails";
      this.setCollider(3);
    }
    else if (GameDataController.gd.getObjectiveDetail("greenhouse_nails") == 0)
    {
      this.sr.sprite = this.sprite5;
      this.objectName = "greenhouse_no_nails";
      this.setCollider(4);
    }
    this.characterAnimationName = "action_stnd_";
    this.useCurrentDirection = true;
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    if (this.usedItem == "crowbar")
    {
      if (GameDataController.gd.getObjectiveDetail("greenhouse_nails") > 0)
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "greenhouse_nails"), yesClick: new Button.Delegate(this.yesClicked), time: 10, timeSaver: 1);
      else
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "greenhouse_no_nails"), true);
    }
    else if (this.usedItem == "hammer")
    {
      if (GameDataController.gd.getObjectiveDetail("greenhouse_nails") > 0)
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "greenhouse_hammer"), yesClick: new Button.Delegate(this.yesClicked2), time: 20, timeSaver: 2);
      else
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "greenhouse_no_nails"), true);
    }
    else if (GameDataController.gd.getObjectiveDetail("greenhouse_nails") > 0)
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "greenhouse_nails"), true);
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "greenhouse_no_nails"), true);
  }

  public void yesClicked2() => this.nailsremove("action_n_long");

  public void yesClicked() => this.nailsremove("crowbar_e");

  public void nailsremove(string s)
  {
    Item obj1 = ItemsManager.im.getItem("nails" + (object) GameDataController.gd.getObjectiveDetail("greenhouse_nails"));
    Item obj2 = ItemsManager.im.getItem("planks" + (object) GameDataController.gd.getObjectiveDetail("greenhouse_nails"));
    int objectiveDetail = GameDataController.gd.getObjectiveDetail("greenhouse_nails");
    if (GameDataController.gd.getObjectiveDetail("greenhouse_nails") == 4)
      GameDataController.gd.setObjectiveDetail("greenhouse_nails", 3);
    else if (GameDataController.gd.getObjectiveDetail("greenhouse_nails") == 3)
      GameDataController.gd.setObjectiveDetail("greenhouse_nails", 2);
    else if (GameDataController.gd.getObjectiveDetail("greenhouse_nails") == 2)
      GameDataController.gd.setObjectiveDetail("greenhouse_nails", 1);
    else if (GameDataController.gd.getObjectiveDetail("greenhouse_nails") == 1)
      GameDataController.gd.setObjectiveDetail("greenhouse_nails", 0);
    this.Invoke("drop", 1f);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.wood_crack_3);
    obj1.dataRef.locX = (int) PlayerController.wc.currentXY.x + (objectiveDetail - 3) * 25 + 20;
    obj1.dataRef.locY = (int) PlayerController.wc.currentXY.y - 2;
    obj1.dataRef.droppedLocation = SceneManager.GetActiveScene().name;
    obj2.dataRef.locX = (int) PlayerController.wc.currentXY.x + (objectiveDetail - 3) * 25 - 15 + 20;
    obj2.dataRef.locY = (int) PlayerController.wc.currentXY.y + 3;
    obj2.dataRef.droppedLocation = SceneManager.GetActiveScene().name;
    PlayerController.wc.forceAnimation(s);
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.E, animation: s);
  }

  public void drop()
  {
    Item obj1 = ItemsManager.im.getItem("nails" + (object) (GameDataController.gd.getObjectiveDetail("greenhouse_nails") + 1));
    Vector2 screen1 = ScreenControler.gameToScreen(new Vector2((float) obj1.dataRef.locX, (float) (obj1.dataRef.locY + GroundItemController.yOffset)));
    Vector3 vector3 = new Vector3(screen1.x, screen1.y, 0.0f);
    Vector3 position = Camera.main.ScreenToWorldPoint((Vector3) screen1);
    (Object.Instantiate(Resources.Load("Prefabs/GroundItem"), position, new Quaternion()) as GameObject).GetComponent<GroundItemController>().init(obj1);
    Item obj2 = ItemsManager.im.getItem("planks" + (object) (GameDataController.gd.getObjectiveDetail("greenhouse_nails") + 1));
    Vector2 screen2 = ScreenControler.gameToScreen(new Vector2((float) obj2.dataRef.locX, (float) (obj2.dataRef.locY + GroundItemController.yOffset)));
    position = new Vector3(screen2.x, screen2.y, 0.0f);
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint((Vector3) screen2);
    (Object.Instantiate(Resources.Load("Prefabs/GroundItem"), worldPoint, new Quaternion()) as GameObject).GetComponent<GroundItemController>().init(obj2);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
