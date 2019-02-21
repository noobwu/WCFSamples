using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.ServiceModel;
using Artech.VideoMall.Common;
using Artech.VideoMall.Infrastructure.BusinessEntity;

namespace Artech.VideoMall.Infrastructure.Service.Interface
{
[ServiceContract(Namespace=Constants.ServiceContractNamespace)]
public interface IMembershipService
{
    [OperationContract]
    MembershipProviderData GetProviderData();
    [OperationContract]
    bool ChangePassword(string username, string oldPassword, string newPassword);
    [OperationContract]
    bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer);
    [OperationContract]
    MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status);
    [OperationContract]
    bool DeleteUser(string username, bool deleteAllRelatedData);
    [OperationContract]
    MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords);
    [OperationContract]
    MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords);
    [OperationContract]
    MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords);
    [OperationContract]
    int GetNumberOfUsersOnline();
    [OperationContract]
    string GetPassword(string username, string answer);
    [OperationContract(Name = "GetUser1")]
    MembershipUser GetUser(string username, bool userIsOnline);
    [OperationContract(Name="GetUser2")]
    MembershipUser GetUser(object providerUserKey, bool userIsOnline);
    [OperationContract]
    string GetUserNameByEmail(string email);
    [OperationContract]
    string ResetPassword(string username, string answer);
    [OperationContract]
    bool UnlockUser(string userName);
    [OperationContract]
    void UpdateUser(MembershipUser user);
    [OperationContract]
    bool ValidateUser(string username, string password);
}
}
