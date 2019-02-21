using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Linq;
namespace Artech.WcfServices.Service
{
    public class SimpleAuthorizationPolicy : IAuthorizationPolicy
    {
        private const string ActionOfAdd        = "http://www.artech.com/calculator/add";
        private const string ActionOfSubtract   = "http://www.artech.com/calculator/subtract";
        private const string ActionOfMultiply   = "http://www.artech.com/calculator/multiply";
        private const string ActionOfDivide     = "http://www.artech.com/calculator/divide";

        internal const string ClaimType4AllowedOperation = "http://www.artech.com/allowed";

        public SimpleAuthorizationPolicy()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            if (null == state)
            {
                state = false;
            }
            bool hasAddedClaims = (bool)state;
            if (hasAddedClaims)
            {
                return true; ;
            }
            IList<Claim> claims = new List<Claim>();
            foreach (ClaimSet claimSet in evaluationContext.ClaimSets)
            {
                foreach (Claim claim in claimSet.FindClaims(ClaimTypes.Name, Rights.PossessProperty))
                {
                    string userName = (string)claim.Resource;
                    if (userName.Contains('\\'))
                    {
                        userName = userName.Split('\\')[1];
                        if (string.Compare("Foo", userName, true) == 0)
                        {
                            claims.Add(new Claim(ClaimType4AllowedOperation, ActionOfAdd, Rights.PossessProperty));
                            claims.Add(new Claim(ClaimType4AllowedOperation, ActionOfSubtract, Rights.PossessProperty));
                        }
                        if (string.Compare("Bar", userName, true) == 0)
                        {
                            claims.Add(new Claim(ClaimType4AllowedOperation, ActionOfMultiply, Rights.PossessProperty));
                            claims.Add(new Claim(ClaimType4AllowedOperation, ActionOfDivide, Rights.PossessProperty));
                        }
                    }
                }
            }
            evaluationContext.AddClaimSet(this, new DefaultClaimSet(this.Issuer, claims));
            state = true;
            return true;
        }
        public ClaimSet Issuer
        {
            get { return ClaimSet.System; }
        }
        public string Id { get; private set; }
    }
}