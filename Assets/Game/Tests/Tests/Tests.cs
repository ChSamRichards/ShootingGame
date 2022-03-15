using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using KiksAr.ShootingGame.Controller;
using KiksAr.ShootingGame.Views;

public class Tests
{
    private GameObject bullet;
     
      
    [UnitySetUp]
    public void TestSetUp()
    {
      
       bullet.AddComponent<BulletMovement>();
        
    }

    
    
    // [UnityTest]
    // public IEnumerator IsBulletReleased()
    // {
        
    //     // var unityservie = Substitute.For<IPlayerInput>();
    //     // unityservie.Input.GetMouseButtonDown(0).Returns(1);
    //     // bullet.UnityService = unityservie;
       
    //     // Assert.AreEqual(1, 1);

    // }
      
    // [UnityTest]
    // public IEnumerator BulletEnquedAgainAfterHitting()
    // {
        
    // }
      
    // [UnityTest]
    // public IEnumerator ScoreUpdated()
    // {
        
    // }
      
    // [UnityTest]
    // public IEnumerator IsBulletReleased()
    // {
        
    // }
      
    // [UnityTest]
    // public IEnumerator AllBulletsReleased()
    // {
        
    // }





}
