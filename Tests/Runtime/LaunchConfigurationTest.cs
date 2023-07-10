using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using Ultraio;

public class LaunchConfigurationTest
{
    [Test]
    public void LaunchedFromUltra()
    {
        Assert.AreEqual(LaunchConfiguration.LaunchedFromUltraClient, false);
    }
}
