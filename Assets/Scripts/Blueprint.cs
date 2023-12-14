using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueprint
{
public string itemName;

public string Req1;
public string Req2;

public string Req3;

public int Req1amount;
public int Req2amount;
public int Req3amount;

public int numOfRequirements;

public Blueprint(string name, int reqNUM, string R1, int R1num, string R2, int R2num, string R3, int R3num)
{
    itemName = name;

    numOfRequirements = reqNUM;

    Req1 = R1;
    Req2 = R2;
    Req3 = R3;

    Req1amount = R1num;
    Req2amount = R2num;
    Req3amount = R3num;

}

}
