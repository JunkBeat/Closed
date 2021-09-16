// Decompiled with JetBrains decompiler
// Type: LocationOutside2Thugs
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationOutside2Thugs : ObjectActionController
{
  public Sprite examine1;
  public Sprite examine2;
  private Sprite examine;
  private string say;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "heap_of_thugs";
    this.range = 100f;
  }

  public override void clickAction() => PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "heap_of_thugs"));

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getCurrentDay() == 4)
    {
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.colliderManager.setCollider(0);
    }
    else
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(-1);
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
