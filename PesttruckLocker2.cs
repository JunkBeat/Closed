// Decompiled with JetBrains decompiler
// Type: PesttruckLocker2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class PesttruckLocker2 : ObjectActionController
{
  private AudioClip soundOpen;
  private AudioClip soundClose;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "open_n";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "pesttruck_locker";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("paperclip", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("crowbar", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("key2", GameStrings.getString(GameStrings.actions, "key_lockers"), anim: string.Empty));
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("pesttruck_locker2_unlocked"))
    {
      if (!(this.usedItem == string.Empty))
        return;
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.locker_01);
    }
    else if (this.usedItem == "paperclip")
    {
      QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "pesttruck_locker"), yesClick: new Button.Delegate(this.yesClicked), time: 15);
    }
    else
    {
      if (!(this.usedItem != "crowbar"))
        return;
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.locker_locked);
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "pest_truck_locker_locked"), true);
      this.updateAll();
    }
  }

  private void yesClicked()
  {
    GameDataController.gd.setObjective("pesttruck_locker2_unlocked", true);
    this.updateState();
    PlayerController.wc.dir = WalkController.Direction.N;
    CurtainController.cc.fadeOut();
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("pesttruck_locker2_open"))
    {
      this.characterAnimationName = "open_n";
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.colliderManager.setCollider(-1);
    }
    else
    {
      this.characterAnimationName = "open_n";
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(0);
    }
  }

  public override void clickAction2()
  {
    if (GameDataController.gd.getObjective("pesttruck_locker2_unlocked"))
    {
      GameDataController.gd.setObjective("pesttruck_locker2_open", !GameDataController.gd.getObjective("pesttruck_locker2_open"));
      this.updateState();
      this.updateAll();
    }
    else
    {
      if (!(this.usedItem == "crowbar"))
        return;
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.locker_01);
      GameDataController.gd.setObjective("pesttruck_locker2_unlocked", true);
      GameDataController.gd.setObjective("pesttruck_locker2_open", true);
      this.updateAll();
    }
  }

  public override void whatOnClick0()
  {
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    if (this.usedItem == "paperclip")
    {
      if (GameDataController.gd.getObjective("pesttruck_locker2_unlocked"))
        this.characterAnimationName = "action_stnd_n";
      else
        this.characterAnimationName = "action_stnd_n";
    }
    else if (GameDataController.gd.getObjective("pesttruck_locker2_unlocked"))
      this.characterAnimationName = "open_n";
    else if (this.usedItem == "crowbar")
    {
      this.characterAnimationName = "crowbar_e";
      this.actionMarker = this.gameObject.transform.Find("Action_Marker2").gameObject;
    }
    else
      this.characterAnimationName = "locked_n";
  }

  public override void clickAction0()
  {
  }
}
