using Clever_Dynamics_Business_layer;
using Clever_Dynamics_Repository;

namespace Clever_Dynamics_Unit_test
{
    public class OperatorsProcessUnitTest
    {
        private OperatorsProcess? _OperatorsProcess = null;

        [SetUp]
        public void Setup()
        {
            _OperatorsProcess = new OperatorsProcess(new MockRepository());
        }

        [Test]
        public void SignIn()
        {
           

            Assert.Pass();
        }
    }
}