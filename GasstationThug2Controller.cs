// Decompiled with JetBrains decompiler
// Type: GasstationThug2Controller
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class GasstationThug2Controller : MonoBehaviour
{
  public string nameId;
  public bool riding;
  public AudioSource aS;
  public float truex;
  public float truey;
  public float speed;

  private void Start()
  {
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    this.truex = this.gameObject.transform.position.x;
    this.truey = this.gameObject.transform.position.y;
    this.speed = 0.25f;
  }

  private void Update()
  {
    if (!this.riding)
      return;
    this.speed += Time.deltaTime;
    if ((double) this.speed < 2.0)
      this.speed += Time.deltaTime;
    if ((double) this.speed < 1.5)
      this.speed += Time.deltaTime;
    if ((double) this.speed < 1.0)
      this.speed += Time.deltaTime;
    if ((double) this.speed > 3.0)
      this.speed = 3f;
    this.truex -= (float) ((double) this.speed * (double) Time.deltaTime * 0.75);
    this.truey -= Time.deltaTime * 0.1f * this.speed;
    this.gameObject.transform.position = new Vector3(this.truex, this.truey, this.gameObject.transform.position.z);
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    if ((double) this.gameObject.transform.position.x >= -2.0)
      return;
    this.riding = false;
  }

  public void ride() => this.gameObject.GetComponent<Animator>().Play(this.nameId + "_ride");

  public void startMoving() => this.riding = true;

  public void brrrr() => this.aS.PlayOneShot(SoundsManagerController.sm.motorbikes);
}
