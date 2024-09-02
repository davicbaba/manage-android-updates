using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using Android.Net;
using Android.Content;
using Android.App.Admin;
using Android.App;
using ManageAndroidUpdates.Abstract;
using ManageAndroidUpdates.Helper;

namespace DavisCruz.Services
{
    public class UpdateService : ManageAndroidUpdates.Abstract.IUpdateService
    {
        private readonly HttpClient _httpClient;

        public UpdateService()
        {
            _httpClient = new HttpClient();
        }

    
        public async Task<ApkInfo> DownloadApkAsync(string apkUrl)
        {
            var apkBytes = await _httpClient.GetByteArrayAsync(apkUrl);

            string fileName = FileHelper.GetFileNameFromUrl(apkUrl);

            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("apkUrl doesnt have file name");

            var filePath = FileHelper.GetFilePath(fileName);

            await File.WriteAllBytesAsync(filePath, apkBytes);

            return new ApkInfo(filePath, FileHelper.GetFileNameFromUrl(apkUrl));
        }

        

        public void InstallApk(string filePath)
        {
            InstallApkSilently(filePath);
        }

        private void InstallApkSilently(string apkFilePath)
        {

            var packageInstaller = Android.App.Application.Context.ApplicationContext.PackageManager.PackageInstaller;
            var sessionParams = new Android.Content.PM.PackageInstaller.SessionParams(Android.Content.PM.PackageInstallMode.FullInstall);
            int sessionId = packageInstaller.CreateSession(sessionParams);
            var session = packageInstaller.OpenSession(sessionId);

            using (var inStream = new Java.IO.FileInputStream(apkFilePath))
            using (var outStream = session.OpenWrite("app_package", 0, -1))
            {
                byte[] buffer = new byte[65536];
                int bytesRead;
                while ((bytesRead = inStream.Read(buffer)) != -1)
                {
                    outStream.Write(buffer, 0, bytesRead);
                }
                session.Fsync(outStream);
            }

            session.Commit(Android.App.PendingIntent.GetBroadcast(
                Android.App.Application.Context,
                sessionId,
                new Intent("com.companyname.testsillentupdate.ACTION_INSTALL_COMMIT"),
                PendingIntentFlags.Immutable
            ).IntentSender);
        }

        public bool IsDeviceOwner()
        {
            var dpm = (DevicePolicyManager)Android.App.Application.Context.GetSystemService(Context.DevicePolicyService);
            return dpm.IsDeviceOwnerApp(Android.App.Application.Context.PackageName);
        }

        public bool FileExist(string filePath)
        {
            return File.Exists(filePath);
        }

        public void RemoveDeviceOwner()
        {
            // Obtener el servicio de DevicePolicyManager
            var devicePolicyManager = (DevicePolicyManager)Android.App.Application.Context.GetSystemService(Context.DevicePolicyService);

            // Obtener el nombre del paquete
            string packageName = Android.App.Application.Context.PackageName;

            // Limpiar la aplicación como propietaria del dispositivo
            devicePolicyManager.ClearDeviceOwnerApp(packageName);
        }
    }

  
}
