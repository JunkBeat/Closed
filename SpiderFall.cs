// Decompiled with JetBrains decompiler
// Type: SpiderFall
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SpiderFall : MonoBehaviour
{
  public float speedX;
  public float speedY;
  public float targetY = -0.35f;
  public float targetX = 0.487f;
  private bool started;
  public int iii;
  private int delay;
  private Vector3 pos;

  private void Start()
  {
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    this.pos = this.gameObject.transform.position;
    this.gameObject.GetComponent<Animator>().Play("fall");
    this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    this.speedY = 0.7f;
    this.speedX = 0.4f;
    if (this.iii >= 3)
      this.speedX = 1f;
    this.started = false;
    this.delay = (this.iii - 1) * 5;
    this.pos = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
  }

  public void startFall()
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.hiss, 0.25f);
    if (this.iii >= 4)
      this.Invoke("startFall2", Random.Range(0.25f, 1f));
    else
      this.startFall2();
  }

  public void startFall2()
  {
    this.started = true;
    this.gameObject.GetComponent<Animator>().Play("fall");
  }

  private void Update()
  {
    if (!this.started)
      return;
    if (this.delay > 0)
    {
      --this.delay;
    }
    else
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      if ((double) this.speedY > -0.600000023841858)
        this.speedY -= (float) (0.100000001490116 * (double) Time.deltaTime * 60.0);
      if ((double) this.pos.y < (double) this.targetY)
        this.speedY = 0.0f;
      if ((double) Mathf.Abs(this.pos.x - this.targetX) < 0.100000001490116)
        this.speedX = 0.0f;
      if ((double) this.pos.x < (double) this.targetX)
        this.pos.x += (float) ((double) this.speedX * (double) Time.deltaTime * 2.0);
      if ((double) this.pos.x > (double) this.targetX)
        this.pos.x -= (float) ((double) this.speedX * (double) Time.deltaTime * 2.0);
      if ((double) this.speedX == 0.0 && (double) this.speedY == 0.0 && this.started && (double) this.pos.y < (double) this.targetY)
      {
        this.started = false;
        if (this.iii == 3)
          this.gameObject.GetComponent<Animator>().Play("hit_fast");
        else
          this.gameObject.GetComponent<Animator>().Play("eat_fast");
      }
      this.pos.y += (float) ((double) this.speedY * (double) Time.deltaTime * 2.0);
      this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.pos);
    }
  }
}
