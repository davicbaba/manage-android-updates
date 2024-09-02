using Android.App.Admin;
using Android.App;
using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageAndroidUpdates.Platforms.Android
{
    [BroadcastReceiver(Name = "com.companyname.manageandroidupdates.MyDeviceAdminReceiver")]
    [IntentFilter(new[] { "android.app.action.DEVICE_ADMIN_ENABLED" })]
    [MetaData("android.app.device_admin", Resource = "@xml/device_admin_receiver")]
    public class MyDeviceAdminReceiver : DeviceAdminReceiver
    {
        public override void OnEnabled(Context context, Intent intent)
        {
            base.OnEnabled(context, intent);
        }

        public override void OnDisabled(Context context, Intent intent)
        {
            base.OnDisabled(context, intent);
        }
    }
}
