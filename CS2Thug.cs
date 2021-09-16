// Decompiled with JetBrains decompiler
// Type: CS2Thug
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;

public class CS2Thug : ObjectActionController
{
  public CSThugSprite ts;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.characterAnimationName = "action_stnd_";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_thug";
    this.range = 5f;
    this.updateState();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("rifle_so_6", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_so_0", GameStrings.getString(GameStrings.actions, "rifle_no_ammo"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_6", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_s_0", GameStrings.getString(GameStrings.actions, "rifle_no_ammo"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_6", GameStrings.getString(GameStrings.actions, "rifle_too_loud"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_5", GameStrings.getString(GameStrings.actions, "rifle_too_loud"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_4", GameStrings.getString(GameStrings.actions, "rifle_too_loud"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_3", GameStrings.getString(GameStrings.actions, "rifle_too_loud"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_2", GameStrings.getString(GameStrings.actions, "rifle_too_loud"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_1", GameStrings.getString(GameStrings.actions, "rifle_too_loud"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_o_0", GameStrings.getString(GameStrings.actions, "rifle_no_ammo"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_6", GameStrings.getString(GameStrings.actions, "rifle_too_loud"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_5", GameStrings.getString(GameStrings.actions, "rifle_too_loud"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_4", GameStrings.getString(GameStrings.actions, "rifle_too_loud"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_3", GameStrings.getString(GameStrings.actions, "rifle_too_loud"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_2", GameStrings.getString(GameStrings.actions, "rifle_too_loud"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_1", GameStrings.getString(GameStrings.actions, "rifle_too_loud"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle_0", GameStrings.getString(GameStrings.actions, "rifle_no_ammo"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_6", GameStrings.getString(GameStrings.actions, "rifle_too_loud"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_5", GameStrings.getString(GameStrings.actions, "rifle_too_loud"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_4", GameStrings.getString(GameStrings.actions, "rifle_too_loud"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_3", GameStrings.getString(GameStrings.actions, "rifle_too_loud"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_2", GameStrings.getString(GameStrings.actions, "rifle_too_loud"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_1", GameStrings.getString(GameStrings.actions, "rifle_too_loud"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rock", GameStrings.getString(GameStrings.actions, "thug_rock"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rock2", GameStrings.getString(GameStrings.actions, "thug_rock"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("maggot", GameStrings.getString(GameStrings.actions, "thug_maggot"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("knife", GameStrings.getString(GameStrings.actions, "thug_knife"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("revolver_0", GameStrings.getString(GameStrings.actions, "rifle_no_ammo"), anim: string.Empty));
  }

  public override void clickAction()
  {
    if (!(this.usedItem != string.Empty))
      return;
    this.ts.getShot();
    this.setCollider(-1);
    ItemsManager.im.rifleShot(this.usedItem);
    this.Invoke("thud", 0.5f);
  }

  public void thud() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_thud2);

  public override void whatOnClick0()
  {
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.characterAnimationName = "action_stnd_";
    this.range = 200f;
    if (!(this.usedItem != string.Empty))
      return;
    this.range = 10f;
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.characterAnimationName = "shoot_n";
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("cs_thug_shot") || GameDataController.gd.getObjective("cs_safe"))
    {
      this.ts.hide();
      this.setCollider(-1);
    }
    else
    {
      this.ts.show();
      this.setCollider(0);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
