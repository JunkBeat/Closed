// Decompiled with JetBrains decompiler
// Type: rv_body1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class rv_body1 : ObjectActionController
{
  public Sprite gas;
  public Sprite bugs;
  public Sprite ice;
  public Sprite heat;
  public Sprite spiders;
  public Sprite gone;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "rv_body1_gas";
    this.range = 1f;
  }

  public override void clickAction() => PlayerController.pc.say(GameStrings.getString(GameStrings.actions, nameof (rv_body1)));

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getCurrentDay() < 3)
    {
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      {
        this.objectName = "rv_body1_bugs";
        this.GetComponent<SpriteRenderer>().sprite = this.bugs;
      }
      else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
      {
        this.objectName = "rv_body1_gas";
        this.GetComponent<SpriteRenderer>().sprite = this.gas;
      }
      else
      {
        if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 2)
          return;
        this.objectName = "rv_body1_spiders";
        this.GetComponent<SpriteRenderer>().sprite = this.spiders;
      }
    }
    else if (GameDataController.gd.getCurrentDay() == 3)
    {
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
      {
        this.objectName = "rv_body1_hot";
        this.GetComponent<SpriteRenderer>().sprite = this.heat;
      }
      else
      {
        if (GameDataController.gd.getObjectiveDetail("day_2_threat") != 1)
          return;
        this.objectName = "rv_body1_cold";
        this.GetComponent<SpriteRenderer>().sprite = this.ice;
      }
    }
    else
    {
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().sprite = this.gone;
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
