using Clever_Dynamics_Repository;
using Clever_Dynamics_Utility;
using Microsoft.AspNetCore.Http;

namespace Clever_Dynamics_Business_layer
{
    public class OperatorsProcess
    {

        private BaseRepository _repository;

        private SessionHalper _sessionHalper;

        public OperatorsProcess(BaseRepository repository,HttpContext HttpContext) {

            _repository = repository;
            _sessionHalper = new SessionHalper();
        }


        public bool VariationSignIn(string username) => _repository.GetOperator(username) != null;

        public void SignIn(HttpContext httpContext) => _sessionHalper.SetString("Login", "Login", httpContext);

    }
}