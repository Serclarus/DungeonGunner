using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameManager : SingletonMonbehaviour<TestGameManager>
{
    public void TestMethod()
    {
        Debug.Log("Test Method Called");
    }
}