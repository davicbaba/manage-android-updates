using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageAndroidUpdates.Abstract
{
    internal interface IUpdateService
    {
        Task<ApkInfo> DownloadApkAsync(string apkUrl);
        bool FileExist(string filePath);
        void InstallApk(string filePath);

        bool IsDeviceOwner();
        void RemoveDeviceOwner();
    }


    public record ApkInfo(string FilePath, string FileName);
}
