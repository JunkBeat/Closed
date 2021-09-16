// Decompiled with JetBrains decompiler
// Type: Scissor
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class Scissor : MonoBehaviour
{
  public Rect scissorRect = new Rect(0.0f, 0.0f, 1f, 1f);

  public static void SetScissorRect(Camera cam, Rect r)
  {
    if ((double) r.x < 0.0)
    {
      r.width += r.x;
      r.x = 0.0f;
    }
    if ((double) r.y < 0.0)
    {
      r.height += r.y;
      r.y = 0.0f;
    }
    r.width = Mathf.Min(1f - r.x, r.width);
    r.height = Mathf.Min(1f - r.y, r.height);
    cam.rect = new Rect(0.0f, 0.0f, 1f, 1f);
    cam.ResetProjectionMatrix();
    Matrix4x4 projectionMatrix = cam.projectionMatrix;
    cam.rect = r;
    Matrix4x4.TRS(new Vector3(r.x, r.y, 0.0f), Quaternion.identity, new Vector3(r.width, r.height, 1f));
    Matrix4x4 matrix4x4_1 = Matrix4x4.TRS(new Vector3((float) (1.0 / (double) r.width - 1.0), (float) (1.0 / (double) r.height - 1.0), 0.0f), Quaternion.identity, new Vector3(1f / r.width, 1f / r.height, 1f));
    Matrix4x4 matrix4x4_2 = Matrix4x4.TRS(new Vector3((float) (-(double) r.x * 2.0) / r.width, (float) (-(double) r.y * 2.0) / r.height, 0.0f), Quaternion.identity, Vector3.one);
    cam.projectionMatrix = matrix4x4_2 * matrix4x4_1 * projectionMatrix;
  }

  private void OnPreRender() => Scissor.SetScissorRect(this.GetComponent<Camera>(), this.scissorRect);
}
