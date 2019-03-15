using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Tests
{
//    private Component jellyController;
//
//    [SetUp]
//    public void SetUp()
//    {
//        var jelly = new GameObject();
//        jelly.AddComponent<StatsController>();
//        jellyController = jelly.GetComponent<StatsController>();
//    }
//
//    [Test]
//    public void DecreaseStatTest()
//    {
//    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator TestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}