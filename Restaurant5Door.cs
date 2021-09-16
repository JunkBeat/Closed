// Decompiled with JetBrains decompiler
// Type: Restaurant5Door
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class Restaurant5Door : ObjectActionController
{
  public PolygonCollider2D block;
  public PolygonCollider2D block2;
  public SpriteRenderer shadow;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "open_door2";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_chem_door";
    this.actionType = ObjectActionController.Type.NormalAction;
    this.range = 1f;
  }

  public override void clickAction()
  {
    this.GetComponent<Animator>().Play("door_open");
    this.block.enabled = false;
    GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
    this.setCollider(-1);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_open_01);
    GameDataController.gd.setObjective("restaurant_chem_door_open", true);
  }

  public void shadowpop()
  {
    this.shadow.enabled = true;
    this.updateAll();
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    this.GetComponent<SpriteRenderer>().enabled = true;
    this.shadow.enabled = false;
    if (GameDataController.gd.getCurrentDay() > 2)
    {
      if (GameDataController.gd.getObjective("restaurant_chem_door_open"))
      {
        this.shadow.enabled = true;
        this.colliderManager.setCollider(-1);
        this.GetComponent<Animator>().Play("door_opened");
        this.shadow.enabled = true;
      }
      else
      {
        this.colliderManager.setCollider(0);
        this.GetComponent<Animator>().Play("door_closed");
      }
    }
    else
    {
      this.colliderManager.setCollider(-1);
      this.GetComponent<Animator>().Play("door_closed");
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
