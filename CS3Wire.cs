// Decompiled with JetBrains decompiler
// Type: CS3Wire
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class CS3Wire : ObjectActionController
{
  public GameObject marker1;
  public GameObject marker2;
  public Sprite reel1;
  public Sprite reel2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_e";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_wire";
    this.range = 1f;
    this.updateState();
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("cs_rain_enter_left") && !GameDataController.gd.getObjective("cs_pack_lifted"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cant_reach"));
    else if (!GameDataController.gd.getObjective("cs_pack_lifted"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "reel_blocked"));
    }
    else
    {
      if (GameDataController.gd.getObjective("cs_wire_taken") || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("wire")))
        return;
      GameDataController.gd.setObjective("cs_wire_taken", true);
      this.updateAll();
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("cs_pack_lifted"))
      this.GetComponent<SpriteRenderer>().sprite = this.reel1;
    else
      this.GetComponent<SpriteRenderer>().sprite = this.reel2;
    if (GameDataController.gd.getObjective("cs_wire_taken"))
    {
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
    }
    else if (GameDataController.gd.getObjective("cs_rain_enter_left") && !GameDataController.gd.getObjective("cs_pack_lifted"))
    {
      this.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = true;
      this.useCurrentDirection = true;
      this.actionMarker = this.marker2;
      this.range = 100f;
    }
    else
    {
      this.actionMarker = this.marker1;
      this.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
      if (GameDataController.gd.getObjective("cs_pack_lifted"))
      {
        this.characterAnimationName = "kneel_e";
        this.animationFlip = false;
        this.useCurrentDirection = false;
        this.range = 1f;
      }
      else
      {
        this.characterAnimationName = "kneel_e";
        this.animationFlip = true;
        this.useCurrentDirection = false;
        this.range = 1f;
      }
    }
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
      return;
    this.setCollider(-1);
    this.GetComponent<SpriteRenderer>().enabled = false;
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
