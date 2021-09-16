// Decompiled with JetBrains decompiler
// Type: InventoryBlockerController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class InventoryBlockerController : MonoBehaviour
{
  private void Start()
  {
  }

  private void Update()
  {
  }

  private void OnMouseEnter() => InventoryButtonController.ibc.GetComponent<InventoryButtonController>().spaceWasPressed = false;

  private void OnMouseDown()
  {
    if (PlayerController.pc.gameObject.GetComponent<WalkController>().busy)
      return;
    PlayerController.pc.clickedSomething = true;
  }
}
