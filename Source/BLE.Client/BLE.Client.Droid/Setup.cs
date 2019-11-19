using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Acr.UserDialogs;
using MvvmCross.IoC;
using MvvmCross.Forms.Platforms.Android.Core;
using Plugin.Permissions;
using Plugin.Settings;

namespace BLE.Client.Droid
{
    public class Setup : MvxFormsAndroidSetup<BleMvxApplication, BleMvxFormsApp>
    {
        public override IEnumerable<Assembly> GetViewAssemblies()
        {
            return new List<Assembly>(base.GetViewAssemblies().Union(new[] { typeof(BleMvxFormsApp).GetTypeInfo().Assembly }));
        }

        protected override IMvxIoCProvider InitializeIoC()
        {
            var ioc = base.InitializeIoC();
            ioc.RegisterSingleton(() => UserDialogs.Instance);
            ioc.RegisterSingleton(() => CrossSettings.Current);
            ioc.RegisterSingleton(() => CrossPermissions.Current);

            return ioc;
        }
    }
}
