// Decompiled with JetBrains decompiler
// Type: RestaurantFreezer
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class RestaurantFreezer : ObjectActionController
{
  public Sprite closed;
  public Sprite open_0;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_freezer";
    this.range = 1f;
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("restaurant_freezer_open"))
    {
      GameDataController.gd.setObjective("restaurant_freezer_open", true);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.fridge);
      this.updateAll();
    }
    else if (!GameDataController.gd.getObjective("restaurant_absorbers_taken"))
    {
      Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
      {
        text = GameStrings.getString(GameStrings.actions, "restaurant_freezer"),
        function = new TimelineFunction(this.getHeaters),
        actionWithText = false
      });
      Timeline.t.doNotUnlock = true;
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "restaurant_freezer_empty"));
  }

  public void getHeaters(string param = "")
  {
    InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("heat_absorber1"));
    InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("heat_absorber2"));
    InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("heat_absorber3"));
    PlayerController.pc.forceAnimation("action_n");
    GameDataController.gd.setObjective("restaurant_absorbers_taken", true);
    this.updateAll();
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("restaurant_freezer_open"))
    {
      this.setCollider(0);
      this.GetComponent<SpriteRenderer>().sprite = this.closed;
      this.characterAnimationName = "action_n";
      this.range = 1f;
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else if (!GameDataController.gd.getObjective("restaurant_absorbers_taken"))
    {
      this.setCollider(0);
      this.GetComponent<SpriteRenderer>().sprite = this.open_0;
      this.characterAnimationName = "action_stnd_n";
      this.range = 1f;
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else
    {
      this.setCollider(0);
      this.GetComponent<SpriteRenderer>().sprite = this.open_0;
      this.characterAnimationName = "action_stnd_";
      this.range = 30f;
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
  }

  public override void clickAction2()
  {
    if (GameDataController.gd.getObjective("restaurant_absorbers_taken"))
      ;
  }

  public override void clickAction0()
  {
  }
}
