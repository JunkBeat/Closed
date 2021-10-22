// Decompiled with JetBrains decompiler
// Type: Restaurant2Rope
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restaurant2Rope : ObjectActionController
{
  public Sprite lever1;
  public Sprite lever2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_rope";
    this.range = 1f;
    this.teleport = false;
    this.updateState();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("pipe", GameStrings.getString(GameStrings.actions, "restaurant_rope_pipe"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("knife", GameStrings.getString(GameStrings.actions, "restaurant_rope_knife"), anim: string.Empty));
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("restaurant_pipe_switched"))
    {
      GameDataController.gd.setObjective("restaurant_flag_lowered", true);
      ItemsManager.im.updateItem("rope", "LocationRestaurant2", 160, 30);
      ItemsManager.im.updateItem("flag", "LocationRestaurant2", 180, 30);
      CurtainController.cc.fadeOut(targetDir: WalkController.Direction.S, actionAfterFade: new CurtainController.Delegate(this.lowerFlag));
    }
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "restaurant_rope"), true, mwidth: 150);
  }

  public void lowerFlag()
  {
  }

  public void drop(string name)
  {
    Item obj = ItemsManager.im.getItem(name);
    Vector2 screen = ScreenControler.gameToScreen(new Vector2((float) obj.dataRef.locX, (float) (obj.dataRef.locY + GroundItemController.yOffset)));
    Vector3 vector3 = new Vector3(screen.x, screen.y, 0.0f);
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint((Vector3) screen);
    obj.dataRef.droppedLocation = SceneManager.GetActiveScene().name;
    (Object.Instantiate(Resources.Load("Prefabs/GroundItem"), worldPoint, new Quaternion()) as GameObject).GetComponent<GroundItemController>().init(obj);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("restaurant_flag_lowered"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(-1);
    }
    else
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.colliderManager.setCollider(0);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
