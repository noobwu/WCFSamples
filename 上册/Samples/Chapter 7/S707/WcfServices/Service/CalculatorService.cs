using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Activation;
using System.Web;
namespace Artech.WcfServices.Service
{
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class CalculatorService : ICalculator
{
    public void Add(double x)
    {
        HttpContext.Current.Session["result"] = GetResult() + x;
    }
    public void Subtract(double x)
    {
        HttpContext.Current.Session["result"] = GetResult() - x;
    }
    public void Multiply(double x)
    {
        HttpContext.Current.Session["result"] = GetResult() * x;
    }
    public void Divide(double x)
    {
        HttpContext.Current.Session["result"] = GetResult() / x;
    }
    public double GetResult()
    {
        if (HttpContext.Current.Session["result"] == null)
        {
            HttpContext.Current.Session["result"] = 0.0;
        }
        return (double)HttpContext.Current.Session["result"];
    }
}
}
