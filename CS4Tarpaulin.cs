// Decompiled with JetBrains decompiler
// Type: CS4Tarpaulin
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class CS4Tarpaulin : ObjectActionController
{
  public Sprite painting;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "tarpaulin";
    this.range = 1f;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("constructionsite_from_above"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cant_reach"));
    }
    else
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("tarpaulin")))
        return;
      GameDataController.gd.setObjective("cs_tarpaulin_taken", true);
      this.updateState();
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("cs_tarpaulin_taken") || GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
    {
      this.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      this.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
      if (!GameDataController.gd.getObjective("constructionsite_from_above"))
      {
        this.range = 1f;
        this.characterAnimationName = "kneel_n";
        this.animationFlip = false;
        this.useCurrentDirection = false;
      }
      else
      {
        this.range = 100f;
        this.characterAnimationName = "action_stnd_se";
        this.animationFlip = true;
        this.useCurrentDirection = false;
      }
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
