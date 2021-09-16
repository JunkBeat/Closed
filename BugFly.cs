// Decompiled with JetBrains decompiler
// Type: BugFly
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BugFly : MonoBehaviour
{
  public float speedModX;
  public float speedModY;
  public float targetSpeedModX;
  public float targetSpeedModY;
  public Vector2 speed;
  public Vector4 bounds;
  private bool started;
  private Vector3 pos;

  private void Start()
  {
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    this.started = false;
    this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    this.speedModY = 0.0f;
    this.speedModX = 0.0f;
    this.targetSpeedModX = 0.0f;
    this.targetSpeedModY = 0.0f;
    this.speed.x = 1f;
    this.speed.y = 1f;
    if ((double) Random.value > 0.5)
      this.speed.x = -1f;
    if ((double) Random.value > 0.5)
      this.speed.y = -1f;
    this.bounds.x -= Random.Range(0.0f, 0.2f);
    this.bounds.y -= Random.Range(0.0f, 0.2f);
    this.bounds.z += Random.Range(0.0f, 0.2f);
    this.bounds.w += Random.Range(0.0f, 0.2f);
  }

  public void startFly(int i)
  {
    this.pos = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    this.Invoke("startFly2", (float) i * 0.03f);
  }

  public void startFly2()
  {
    this.speed.x = 1f;
    this.speed.y = 1f;
    if ((double) Random.value > 0.5)
      this.speed.x = -1f;
    if ((double) Random.value > 0.5)
      this.speed.y = -1f;
    this.started = true;
    this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
  }

  private void Update()
  {
    if (!this.started)
      return;
    if ((double) this.pos.x < (double) this.bounds.x && (double) this.speed.x < 0.0)
      this.speed.x *= -1f;
    if ((double) this.pos.x > (double) this.bounds.z && (double) this.speed.x > 0.0)
      this.speed.x *= -1f;
    if ((double) this.pos.y < (double) this.bounds.y && (double) this.speed.y < 0.0)
      this.speed.y *= -1f;
    if ((double) this.pos.y > (double) this.bounds.w && (double) this.speed.y > 0.0)
      this.speed.y *= -1f;
    if ((double) this.speed.x < 0.0)
      this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
    else
      this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
    this.pos.x += (float) ((double) this.speed.x * (double) this.speedModX * (double) Time.deltaTime * 120.0);
    this.pos.y += (float) ((double) this.speed.y * (double) this.speedModY * (double) Time.deltaTime * 120.0);
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.pos);
    if ((double) Mathf.Abs(this.speedModX - this.targetSpeedModX) < 1.0 / 1000.0 * (double) Time.deltaTime * 60.0)
      this.targetSpeedModX = Random.Range(3f / 1000f, 0.02f);
    else if ((double) this.speedModX > (double) this.targetSpeedModX)
      this.speedModX -= (float) (1.0 / 1000.0 * (double) Time.deltaTime * 60.0);
    else if ((double) this.speedModX < (double) this.targetSpeedModX)
      this.speedModX += (float) (1.0 / 1000.0 * (double) Time.deltaTime * 60.0);
    if ((double) Mathf.Abs(this.speedModY - this.targetSpeedModY) < 1.0 / 1000.0 * (double) Time.deltaTime * 60.0)
      this.targetSpeedModY = Random.Range(3f / 1000f, 0.02f);
    else if ((double) this.speedModY > (double) this.targetSpeedModY)
    {
      this.speedModY -= (float) (1.0 / 1000.0 * (double) Time.deltaTime * 60.0);
    }
    else
    {
      if ((double) this.speedModY >= (double) this.targetSpeedModY)
        return;
      this.speedModY += (float) (1.0 / 1000.0 * (double) Time.deltaTime * 60.0);
    }
  }
}
