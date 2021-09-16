// Decompiled with JetBrains decompiler
// Type: CS3Pack
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class CS3Pack : ObjectActionController
{
  public Sprite pack;
  public SpriteRenderer pack_hang;
  public GameObject marker1;
  public GameObject marker2;
  public GameObject zmarker1;
  public GameObject zmarker2;
  public Sprite hook1a;
  public Sprite hook1b;
  public Sprite hook2a;
  public Sprite hook2b;
  public SpriteRenderer hook;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_pack";
    this.range = 30f;
    this.updateState();
  }

  private void Update()
  {
  }

  public override void clickAction() => PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cs_pack"));

  public override void updateState()
  {
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.objectName = "cs_pack";
    this.range = 30f;
    if (GameDataController.gd.getObjective("cs_rain_enter_left"))
    {
      this.actionMarker = this.marker1;
      this.zmarker1.GetComponent<ObjectZController>().enabled = true;
      this.zmarker2.GetComponent<ObjectZController>().enabled = false;
    }
    else
    {
      this.actionMarker = this.marker2;
      this.zmarker1.GetComponent<ObjectZController>().enabled = false;
      this.zmarker2.GetComponent<ObjectZController>().enabled = true;
    }
    this.setCollider(0);
    this.GetComponent<SpriteRenderer>().enabled = true;
    this.pack_hang.enabled = false;
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") != 1)
    {
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.hook.enabled = false;
    }
    else if (GameDataController.gd.getObjective("cs_pack_lifted"))
    {
      this.setCollider(-1);
      this.pack_hang.enabled = true;
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.hook.enabled = false;
    }
    else
    {
      this.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.GetComponent<SpriteRenderer>().sprite = this.pack;
      if (GameDataController.gd.getObjective("cs_crane_down"))
      {
        this.hook.enabled = true;
        if (!GameDataController.gd.getObjective("cs_crane_left") && GameDataController.gd.getObjective("cs_crane_closed"))
          this.hook.sprite = this.hook1b;
        else if (!GameDataController.gd.getObjective("cs_crane_left") && !GameDataController.gd.getObjective("cs_crane_closed"))
          this.hook.sprite = this.hook1a;
        else if (GameDataController.gd.getObjective("cs_crane_left") && !GameDataController.gd.getObjective("cs_crane_closed"))
        {
          this.hook.sprite = this.hook2a;
        }
        else
        {
          if (!GameDataController.gd.getObjective("cs_crane_left") || !GameDataController.gd.getObjective("cs_crane_closed"))
            return;
          this.hook.sprite = this.hook2b;
        }
      }
      else
        this.hook.enabled = false;
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
