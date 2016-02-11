using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PAD_04v1;

namespace Datawarehouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyWCF" in both code and config file together.
    [ServiceContract]
    public interface IMyWCF
    {
        [OperationContract]
        [WebInvoke(Method = "PUT",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        ResponseFormat = WebMessageFormat.Json)]
        void addEmployeeRepository(EmployeeRepository rep);

        [OperationContract]
        [WebInvoke(Method = "GET",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        ResponseFormat = WebMessageFormat.Xml)]
        EmployeeRepository getEmployeeRepository();

        [OperationContract]
        [WebInvoke(Method = "GET",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        ResponseFormat = WebMessageFormat.Xml)]
        EmployeeRepository filterBy();

        [OperationContract]
        [WebInvoke(Method = "GET",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        ResponseFormat = WebMessageFormat.Xml)]
        List<EmployeeRepository> groupBy();

        [OperationContract]
        [WebInvoke(Method = "GET",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        ResponseFormat = WebMessageFormat.Xml)]
        EmployeeRepository sortBy();
    }
}
