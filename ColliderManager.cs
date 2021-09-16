// Decompiled with JetBrains decompiler
// Type: ColliderManager
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ColliderManager
{
  public List<PolygonCollider2D> colliders = new List<PolygonCollider2D>();
  private GameObject gameObject;
  [SerializeField]
  public PolygonCollider2D currentColider;

  public void setTarget(GameObject target, bool addNew = true)
  {
    this.gameObject = target;
    if (addNew)
      this.gameObject.AddComponent<PolygonCollider2D>();
    this.currentColider = this.gameObject.GetComponent<PolygonCollider2D>();
    this.currentColider.isTrigger = true;
    this.setCollider(0);
  }

  public void setCollider(int number)
  {
    if ((UnityEngine.Object) this.currentColider != (UnityEngine.Object) null)
      this.currentColider.pathCount = 0;
    for (int index = 0; index < this.colliders.Count; ++index)
    {
      if ((UnityEngine.Object) this.colliders[index] != (UnityEngine.Object) null)
        this.colliders[index].enabled = false;
    }
    if (number < 0 || !((UnityEngine.Object) this.colliders[number] != (UnityEngine.Object) null))
      return;
    this.colliders[number].enabled = true;
    if (!((UnityEngine.Object) this.currentColider != (UnityEngine.Object) null))
      return;
    this.currentColider.SetPath(0, this.colliders[number].GetPath(0));
  }
}
