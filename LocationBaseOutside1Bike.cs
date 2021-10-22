// Decompiled with JetBrains decompiler
// Type: LocationBaseOutside1Bike
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationBaseOutside1Bike : ObjectActionController
{
  public float alpha;
  public float dir;
  public bool stopped;
  public SpriteRenderer sr;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_e_in";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "crashed_bike";
    this.range = 1f;
    this.dir = 1f;
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("gloves_taken"))
    {
      Timeline.t.addAction(new TimelineAction()
      {
        blockG = true,
        textfield = PlayerController.pc.textField,
        text = GameStrings.getString(GameStrings.actions, "gloves_taken"),
        function = new TimelineFunction(this.standup)
      });
      Timeline.t.doNotUnlock = true;
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "gloves_taken2"));
  }

  public void standup(string s = "") => PlayerController.wc.forceAnimation("kneel_e_out");

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getCurrentDay() == 4)
    {
      this.setCollider(0);
      this.sr.enabled = true;
      if (GameDataController.gd.getObjective("gloves_taken"))
        this.characterAnimationName = "kneel_e";
      else
        this.characterAnimationName = "kneel_e_in";
    }
    else
    {
      this.setCollider(-1);
      this.sr.enabled = false;
    }
  }

  public override void clickAction2()
  {
    if (GameDataController.gd.getObjective("gloves_taken"))
      return;
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.hose);
    if (InventoryController.ic.pickUpItem(ItemsManager.im.getItem("gloves")))
      GameDataController.gd.setObjective("gloves_taken", true);
    this.updateState();
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
