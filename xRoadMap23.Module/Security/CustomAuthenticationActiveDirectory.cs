using System;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base.Security;

namespace DevExpress.ExpressApp.Security
{
    public class AuthenticationActiveDirectoryCI : AuthenticationActiveDirectory
    {
        public override object Authenticate(IObjectSpace objectSpace)
        {
            string userName = GetUserName();
            CriteriaOperator criteria = CriteriaOperator.Parse("Lower(UserName)=Lower(?)", userName);
            object obj = objectSpace.FindObject(UserType, criteria);
            if (obj == null && CreateUserAutomatically)
            {
                CustomCreateUserEventArgs customCreateUserEventArgs = new CustomCreateUserEventArgs(objectSpace, userName);
                if (this.CustomCreateUser != null)
                {
                    this.CustomCreateUser(this, customCreateUserEventArgs);
                    obj = (IAuthenticationActiveDirectoryUser)customCreateUserEventArgs.User;
                }
                if (!customCreateUserEventArgs.Handled)
                {
                    obj = objectSpace.CreateObject(UserType);
                    ((IAuthenticationActiveDirectoryUser)obj).UserName = userName;
                    //assign a default role...  
                }
                objectSpace.CommitChanges();
            }
            if (obj == null)
            {
                throw new AuthenticationException(userName);
            }
            return obj;
        }
        public new event EventHandler<CustomCreateUserEventArgs> CustomCreateUser;
    }
}