// Decompiled with JetBrains decompiler
// Type: Node
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Node
{
  public Node ParentNode;
  public GameObject gameObject;

  public Node(Vector2 pos, Vector2 pos2, bool clear)
  {
    this.Location = pos;
    this.GameLocation = pos2;
    this.IsWalkable = clear;
    this.gameObject = new GameObject();
    this.gameObject.AddComponent<SpriteRenderer>();
    this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
    this.State = NodeState.Untested;
  }

  public Vector2 Location { get; private set; }

  public Vector2 GameLocation { get; private set; }

  public bool IsWalkable { get; set; }

  public float G { get; set; }

  public float H { get; set; }

  public float F => this.G + this.H;

  public NodeState State { get; set; }

  public static float GetTraversalCost(Vector2 p1, Vector2 p2) => LocationManager.dist(p1, p2);
}
