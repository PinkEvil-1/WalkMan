using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class list_move : MonoBehaviour {

	public float moveSpeed = 3.0f;

	private Vector2 _hidePos;
	private Vector2 _showPos;
	private RectTransform _rectTransform;
	private bool _isShow;
	// Use this for initialization
	void Start () {
		_rectTransform = this.gameObject.GetComponent<RectTransform> ();
		_hidePos = _rectTransform.anchoredPosition;
		_showPos = new Vector2 (_hidePos.x + _rectTransform.rect.width, _hidePos.y);
		_isShow = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (_isShow) {
				HideMenu ();
			} else {
				showMenu ();
			}
		}
	}
	public void showUI(){
		if (_isShow) {
			HideMenu ();
		} else {
            showMenu();
		}
	}
	public void showMenu(){
	    
	}
    public void HideMenu()
    {

    }
    IEnumerator Disappear()
    {

        yield return new WaitForEndOfFrame();
    }
    IEnumerator Appear()
    {
        yield return new WaitForEndOfFrame();
    }
}
