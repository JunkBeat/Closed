// Decompiled with JetBrains decompiler
// Type: LocationCaveACPlug
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationCaveACPlug : ObjectActionController
{
  private CursorController cursorController;
  public Sprite cord1;
  public Sprite cord2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "ac_plug";
    this.range = 1f;
    this.updateState();
    this.cursorController = GameObject.Find("cursor").GetComponent<CursorController>();
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("cave_ac_placed") && !GameDataController.gd.getObjective("cave_ac_cord_plugged"))
    {
      Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
      {
        text = GameStrings.getString(GameStrings.actions, "ext_cord_where_put"),
        function = new TimelineFunction(this.takeCord)
      });
    }
    else
    {
      if (!GameDataController.gd.getObjective("cave_ac_placed") || !GameDataController.gd.getObjective("cave_ac_cord_plugged"))
        return;
      GameDataController.gd.setObjective("cave_ac_cord_plugged", false);
      this.updateAll();
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "ac_unplugged"));
    }
  }

  private void takeCord(string param = "") => this.cursorController.selectItem(ItemsManager.im.getItem("ac_cord"));

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("cave_ac_placed") && !GameDataController.gd.getObjective("cave_ac_cord_plugged"))
    {
      this.colliderManager.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.GetComponent<SpriteRenderer>().sprite = this.cord1;
    }
    else if (GameDataController.gd.getObjective("cave_ac_placed") && GameDataController.gd.getObjective("cave_ac_cord_plugged"))
    {
      this.colliderManager.setCollider(1);
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.GetComponent<SpriteRenderer>().sprite = this.cord2;
    }
    else
    {
      this.colliderManager.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
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
