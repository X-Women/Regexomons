using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegexomonConfig : MonoBehaviour {

    public Sprite image;
    public Text regName;
    public Text question;
    public Text answer;

    public void Initialize(PlayerRegexomon regex) 
    {
        string url = regex.imageUrl;
        WWW www = new WWW(url);
        var img = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
        this.image = img;
        this.regName.text = regex.name;
        this.regName.text = regex.question;
        this.regName.text = regex.answer;
    }
}
