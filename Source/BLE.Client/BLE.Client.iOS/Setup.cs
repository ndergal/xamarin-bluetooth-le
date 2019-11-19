using Acr.UserDialogs;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Plugin.Permissions;
using Plugin.Settings;

namespace BLE.Client.iOS
{
    public class Setup : MvxFormsIosSetup
    {
        protected override IMvxApplication CreateApp()
        {
            return new BleMvxApplication();
        }

        protected override IMvxIoCProvider InitializeIoC()
        {
            var ioc = base.InitializeIoC();

            ioc.RegisterSingleton(() => UserDialogs.Instance);
            ioc.RegisterSingleton(() => CrossSettings.Current);
            ioc.RegisterSingleton(() => CrossPermissions.Current);

            return ioc;
        }

        protected override Xamarin.Forms.Application CreateFormsApplication()
        {
            return new BleMvxFormsApp();
        }
    }
}
