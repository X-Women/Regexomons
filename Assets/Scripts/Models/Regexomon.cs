using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regexomon
{
    public string name;
    public string imageUrl;

    public Regexomon(string name, string imageUrl)
    {
        this.name = name;
        this.imageUrl = imageUrl;

    }

    public Regexomon(IDictionary<string, object> dictionary)
    {
        this.name = dictionary["name"].ToString();
        this.imageUrl = dictionary["imageUrl"].ToString();
    }

}
