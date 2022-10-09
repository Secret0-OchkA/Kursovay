using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;

namespace DockerTestBD.Api
{
    static class ApiRoute//пока ничего лучше не придумал хотел fluent builder
    {
        public const string baseRoute = "api/";

        public const string Company = "Company/";
        public const string FromCompany = "{companyId}/";

        public const string Deparment = "Deparment/";
        public const string FromDepartment = "{deparmtnetId}/";

        public const string Employee = "Employee/";
        public const string FromEmployee = "{employeeId}/";

        public const string controller = "[controller]";
    }
}
