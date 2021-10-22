// Decompiled with JetBrains decompiler
// Type: ObjectZController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class ObjectZController : MonoBehaviour
{
  private GameObject parentObject;
  public float aa;
  public float bb;
  public float cc;
  public Vector3 vec1;
  public Vector3 vec2;
  public Vector3 vec3;

  private void Start()
  {
  }

  private void Update()
  {
    this.parentObject = this.gameObject.transform.parent.gameObject;
    Vector3 vector3 = new Vector3();
    vector3.x = this.parentObject.transform.position.x;
    vector3.y = this.parentObject.transform.position.y;
    Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
    Vector2 game = ScreenControler.screenToGame(new Vector2(screenPoint.x, screenPoint.y));
    vector3.z = (float) (1.0 + -(double) game.y / (double) ScreenControler.sourceHeight);
    vector3.z *= -1f;
    this.aa = screenPoint.y;
    this.bb = game.y;
    this.cc = vector3.z;
    this.vec1 = this.parentObject.transform.position;
    this.vec2 = this.gameObject.transform.position;
    this.vec3 = this.gameObject.transform.position + this.parentObject.transform.position;
    this.parentObject.transform.position = new Vector3(vector3.x, vector3.y, vector3.z);
  }
}
