using System;
using System.IO;
using FubuTestingSupport;
using NUnit.Framework;

namespace Heliocentricity.Tests.Running
{
    [TestFixture]
    public class when_running : InteractionContext<Runner>
    {
        [Test]
        public void errors_if_no_options_provided()
        {
            Exception<ArgumentNullException>
                .ShouldBeThrownBy(() => ClassUnderTest.Run(null));
        }

        [Test]
        public void Test()
        {
            
        }
    }
}