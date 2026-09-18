using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.ApplicationBuilder;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.XtraEditors;
using System.Configuration;
using xRoadMap.Module.BusinessObjects;

namespace xRoadMap.Win
{
    public class ApplicationBuilder : IDesignTimeApplicationFactory
    {
        public static WinApplication BuildApplication(string connectionString)
        {
            var builder = WinApplication.CreateBuilder();
            // Register custom services for Dependency Injection. For more information, refer to the following topic: https://docs.devexpress.com/eXpressAppFramework/404430/
            // builder.Services.AddScoped<CustomService>();
            // Register 3rd-party IoC containers (like Autofac, Dryloc, etc.)
            // builder.UseServiceProviderFactory(new DryIocServiceProviderFactory());
            // builder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.UseApplication<xRoadMapWindowsFormsApplication>();
            builder.Modules
                //.AddAuditTrailXpo()
                .AddCloning()
                .AddConditionalAppearance()
                .AddFileAttachments()
                .AddViewVariants()
                .AddReports(options =>
                {
                    options.EnableInplaceReports = true;
                    options.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.ReportDataV2);
                    options.ReportStoreMode = DevExpress.ExpressApp.ReportsV2.ReportStoreModes.XML;
                })
                .AddValidation(options =>
                {
                    options.AllowValidationDetailsAccess = false;
                })
                .Add<xRoadMap.Module.xRoadMapModule>()
                .Add<xRoadMapWinModule>();
            builder.ObjectSpaceProviders
                .AddSecuredXpo((application, options) =>
                {
                    options.ConnectionString = connectionString;
                    options.AllowICommandChannelDoWithSecurityContext = true;
                })
                .AddNonPersistent();
            builder.Security
                .UseIntegratedMode(options =>
                {
                    options.Lockout.Enabled = true;

                    options.RoleType = typeof(PermissionPolicyRole);
                    options.UserType = typeof(xRoadMap.Module.BusinessObjects.ApplicationUser);
                    options.UserLoginInfoType = typeof(xRoadMap.Module.BusinessObjects.ApplicationUserLoginInfo);
                    options.UseXpoPermissionsCaching();
                    options.Events.OnSecurityStrategyCreated += securityStrategy =>
                    {
                        // Use the 'PermissionsReloadMode.NoCache' option to load the most recent permissions from the database once
                        // for every Session instance when secured data is accessed through this instance for the first time.
                        // Use the 'PermissionsReloadMode.CacheOnFirstAccess' option to reduce the number of database queries.
                        // In this case, permission requests are loaded and cached when secured data is accessed for the first time
                        // and used until the current user logs out.
                        // See the following article for more details: https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Security.SecurityStrategy.PermissionsReloadMode.
                        ((SecurityStrategy)securityStrategy).PermissionsReloadMode = PermissionsReloadMode.NoCache;
                    };
                })
                .AddPasswordAuthentication(options =>
                {
                    options.Events.OnFindUser += (context)=> {
                        string userName = context.LogonParameters.UserName;

                        context.User =
                            context.ObjectSpace.FirstOrDefault<ApplicationUser>(
                                u => u.UserName.ToUpper() == userName.ToUpper()
                            );
                    };

                    options.IsSupportChangePassword = true;
                })
                .AddWindowsAuthentication(options =>
                {
                    options.Events.CustomCreateUser += (e) =>
                    {
                        var login = e.UserName.Trim();

                        // Ricerca case-insensitive
                        var existingUser = e.ObjectSpace
                            .GetObjectsQuery<ApplicationUser>()
                            .FirstOrDefault(u =>
                                u.UserName.ToUpper() == login.ToUpper());

                        if (existingUser != null)
                        {
                            e.User = existingUser;
                            e.Handled = true;
                            return;
                        }

                        // Creazione nuovo utente
                        var user = e.ObjectSpace.CreateObject<ApplicationUser>();
                        user.UserName = login;
                        e.User = user;
                        e.Handled = true;
                    };
                    options.CreateUserAutomatically();
                });
            builder.AddBuildStep(application =>
            {
                application.ConnectionString = connectionString;
#if DEBUG
                //if(System.Diagnostics.Debugger.IsAttached && application.CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema) {
                //    application.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
                //}
#endif
            });
            var winApplication = builder.Build();
            return winApplication;
        }

        XafApplication IDesignTimeApplicationFactory.Create()
            => BuildApplication(XafApplication.DesignTimeConnectionString);
    }
}
