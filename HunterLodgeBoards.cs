// Decompiled with JetBrains decompiler
// Type: HunterLodgeBoards
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HunterLodgeBoards : ObjectActionController
{
  public SpriteRenderer board2;
  public SpriteRenderer board3;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "action_n";
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "boards3";
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjectiveDetail("lodge_board_taken") == 0)
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("board1")))
        return;
      GameDataController.gd.setObjectiveDetail("lodge_board_taken", 1);
      this.updateAll();
    }
    else if (GameDataController.gd.getObjectiveDetail("lodge_board_taken") == 1)
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("board2")))
        return;
      GameDataController.gd.setObjectiveDetail("lodge_board_taken", 2);
      this.updateAll();
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("lodge_board_taken") != 2 || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("board3")))
        return;
      GameDataController.gd.setObjectiveDetail("lodge_board_taken", 3);
      this.updateAll();
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("lodge_board_taken") < 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
    {
      if (GameDataController.gd.getObjectiveDetail("lodge_board_taken") == 0)
      {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        this.board2.enabled = true;
        this.board3.enabled = true;
        this.colliderManager.setCollider(0);
        this.objectName = "boards3";
      }
      else if (GameDataController.gd.getObjectiveDetail("lodge_board_taken") == 1)
      {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.board2.enabled = true;
        this.board3.enabled = true;
        this.colliderManager.setCollider(1);
        this.objectName = "boards2";
      }
      else if (GameDataController.gd.getObjectiveDetail("lodge_board_taken") == 2)
      {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.board2.enabled = false;
        this.board3.enabled = true;
        this.colliderManager.setCollider(2);
        this.objectName = "boards1";
      }
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    }
    else
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.board2.enabled = false;
      this.board3.enabled = false;
      this.colliderManager.setCollider(-1);
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
