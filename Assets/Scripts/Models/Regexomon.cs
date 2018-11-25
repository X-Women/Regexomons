using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regexomon
{
    public string Name;

    public Regexomon(string Name)
    {
        this.Name = Name;
    }

    public Regexomon(IDictionary<string, object> dictionary)
    {
        this.Name = dictionary["Name"].ToString();
    }

}
