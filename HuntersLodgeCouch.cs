// Decompiled with JetBrains decompiler
// Type: HuntersLodgeCouch
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HuntersLodgeCouch : ObjectActionController
{
  public Sprite gas;
  public Sprite bugs;
  public Sprite spiders;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "lodge_couch";
    this.range = 1f;
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("hunters_lodge_scratches_found"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "hunters_lodge_couch1"));
    }
    else
    {
      if (GameDataController.gd.getObjective("hunters_lodge_couch_moved") || GameDataController.gd.getObjective("hunters_lodge_couch_moved") || !GameDataController.gd.getObjective("hunters_lodge_scratches_found"))
        return;
      PlayerController.wc.speed = PlayerController.wc.MAX_SPEED * 0.75f;
      PlayerController.wc.setSimpleTarget(new Vector2(98f, 35f));
      this.gameObject.GetComponent<Animator>().Play("couch_push");
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.push);
      GameDataController.gd.setObjective("hunters_lodge_couch_moved", true);
    }
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (!GameDataController.gd.getObjective("hunters_lodge_scratches_found"))
    {
      this.characterAnimationName = "action_stnd_";
      this.useCurrentDirection = true;
      this.animationFlip = false;
      this.range = 100f;
      this.gameObject.GetComponent<Animator>().Play("right");
    }
    else if (!GameDataController.gd.getObjective("hunters_lodge_couch_moved"))
    {
      this.gameObject.GetComponent<Animator>().Play("right");
      this.characterAnimationName = "push_e";
      this.useCurrentDirection = false;
      this.animationFlip = true;
      this.range = 1f;
    }
    else
    {
      this.colliderManager.setCollider(-1);
      this.gameObject.GetComponent<Animator>().Play("left");
    }
  }

  public override void clickAction2()
  {
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    this.updateAll();
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
