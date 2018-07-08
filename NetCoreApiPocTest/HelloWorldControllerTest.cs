using System;
using Xunit;
using NetCoreApiPoc.Controllers;
namespace NetCoreApiPocTest
{
    public class HelloWorldControllerTest
    {
        [Fact]
        public void TestController()
        {
            var controller = new HelloWorldController();
            var response = controller.Get("hola, amigo");
            Assert.Equal(response, "Set message: hola, amigo");
        }
    }
}
