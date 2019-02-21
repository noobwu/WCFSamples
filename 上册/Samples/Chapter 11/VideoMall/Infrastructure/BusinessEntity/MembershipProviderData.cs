using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Runtime.Serialization;
using Artech.VideoMall.Common;

namespace Artech.VideoMall.Infrastructure.BusinessEntity
{
[DataContract(Namespace = Constants.DataContractNamespace)]
public class MembershipProviderData
{
    [DataMember]
    public string ApplicationName { get; set; }
    [DataMember]
    public bool EnablePasswordReset { get; set; }
    [DataMember]
    public bool EnablePasswordRetrieval { get; set; }
    [DataMember]
    public int MaxInvalidPasswordAttempts { get; set; }
    [DataMember]
    public int MinRequiredNonAlphanumericCharacters { get; set; }
    [DataMember]
    public int MinRequiredPasswordLength { get; set; }
    [DataMember]
    public int PasswordAttemptWindow { get; set; }
    [DataMember]
    public MembershipPasswordFormat PasswordFormat { get; set; }
    [DataMember]
    public string PasswordStrengthRegularExpression { get; set; }
    [DataMember]
    public bool RequiresQuestionAndAnswer { get; set; }
    [DataMember]
    public bool RequiresUniqueEmail { get; set; }
}
}