// Decompiled with JetBrains decompiler
// Type: AreaEffect
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public abstract class AreaEffect : MonoBehaviour
{
  public ColliderManager colliderManager;
  public LayerMask actionLayer;
  private NPCWalkController[] npcs;
  private Vector2[] lastPos;
  private Vector2 playerPos;

  private void Awake()
  {
  }

  private void Start()
  {
    this.npcs = (NPCWalkController[]) Object.FindObjectsOfType(typeof (NPCWalkController));
    this.lastPos = new Vector2[this.npcs.Length];
    this.playerPos = new Vector2(0.0f, 0.0f);
  }

  public void refresh()
  {
    this.playerPos = new Vector2(0.0f, 0.0f);
    this.lastPos = new Vector2[this.npcs.Length];
  }

  private void Update()
  {
    if ((double) this.playerPos.x != (double) PlayerController.wc.currentXY.x || (double) this.playerPos.y != (double) PlayerController.wc.currentXY.y)
    {
      this.playerPos.x = PlayerController.wc.currentXY.x;
      this.playerPos.y = PlayerController.wc.currentXY.y;
      if ((bool) Physics2D.Linecast((Vector2) Camera.main.ScreenToWorldPoint((Vector3) ScreenControler.gameToScreen(PlayerController.wc.currentXY)), (Vector2) Camera.main.ScreenToWorldPoint((Vector3) ScreenControler.gameToScreen(PlayerController.wc.currentXY)), (int) this.actionLayer))
        this.Action(PlayerController.wc, (NPCWalkController) null, (GroundItemController) null);
      else
        this.Action2(PlayerController.wc, (NPCWalkController) null, (GroundItemController) null);
    }
    for (int index = 0; index < this.npcs.Length; ++index)
    {
      if ((double) this.lastPos[index].x != (double) this.npcs[index].currentXY.x || (double) this.lastPos[index].y != (double) this.npcs[index].currentXY.y)
      {
        this.lastPos[index].x = this.npcs[index].currentXY.x;
        this.lastPos[index].y = this.npcs[index].currentXY.y;
        if ((bool) Physics2D.Linecast((Vector2) Camera.main.ScreenToWorldPoint((Vector3) ScreenControler.gameToScreen(this.npcs[index].currentXY)), (Vector2) Camera.main.ScreenToWorldPoint((Vector3) ScreenControler.gameToScreen(this.npcs[index].currentXY)), (int) this.actionLayer))
          this.Action((WalkController) null, this.npcs[index], (GroundItemController) null);
        else
          this.Action2((WalkController) null, this.npcs[index], (GroundItemController) null);
      }
    }
  }

  public abstract void Action(WalkController wc, NPCWalkController npcwc, GroundItemController gic);

  public abstract void Action2(
    WalkController wc,
    NPCWalkController npcwc,
    GroundItemController gic);
}
