using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using UnityEditor;
using UnityEngine;

public class CopyFilesToStreamingAssets : Editor
{
    static string sourcePackagedDirectory = Application.dataPath+"/../"+"ABs/Package/";
    static string sourcePackedDirectory = Application.dataPath+"/../"+"ABs/Packed/";
    static string  destinationDirectory = Application.streamingAssetsPath;
    static string maxVersionFolderName = "0_0_0_0";
    
    [MenuItem("Tools/Delete StreamingAssets")]
    public static void DeleteStreamingAseetsFiles()
    {
        if (Directory.Exists(destinationDirectory))
        {
            DirectoryInfo dirInfo = new DirectoryInfo(destinationDirectory);
            FileInfo[] files = dirInfo.GetFiles();

            foreach (FileInfo file in files)
            {
                if (!file.Name.EndsWith(".meta"))
                {
                    file.Delete();
                }
            }
            AssetDatabase.Refresh();

            Debug.Log("Deleted all files in StreamingAssets directory.");
        }
        else
        {
            Debug.Log(destinationDirectory+"文件夹不存在");
        }
    }
    public static void CalculateFiles(string platFormName,string sourcePath,string desPath)
    {
        Debug.Log("当前平台是==="+platFormName);
        if (Directory.Exists(desPath))
        {
            DirectoryInfo di = new DirectoryInfo(desPath);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }
        else
        {
            Directory.CreateDirectory(desPath);
        }
        // 删除StreamingAssets下的所有文件
        // string streamingAssetsPath = Application.streamingAssetsPath;
        DirectoryInfo dirInfo = new DirectoryInfo(desPath);
        foreach (FileInfo file in dirInfo.GetFiles())
        {
            file.Delete();
        }
        foreach (DirectoryInfo dir in dirInfo.GetDirectories())
        {
            dir.Delete(true);
        }

        // 找到最大版本号的文件夹
        DirectoryInfo sourceFolder = new DirectoryInfo(sourcePath);
        DirectoryInfo[] dirs = sourceFolder.GetDirectories();
        foreach (DirectoryInfo dir in dirs)
        {
            string[] dirNameParts = dir.Name.Split('_');
            string[] maxVersionParts = maxVersionFolderName.Split('_');
            if (dirNameParts.Length == 4 && maxVersionParts.Length == 4)
            {
                int dirVersion = 0;
                int maxVersion = 0;
                for (int i = 0; i < 4; i++)
                {
                    int.TryParse(dirNameParts[i], out dirVersion);
                    int.TryParse(maxVersionParts[i], out maxVersion);
                    if (dirVersion > maxVersion)
                    {
                        Debug.Log("当前的dir---"+dir);
                        if(Directory.Exists(dir+"/"+platFormName))
                        {
                            maxVersionFolderName = dir.Name;
                            break;   
                        }
                    }
                }
            }
        }
        Debug.Log("当前最大的版本号是----"+maxVersionFolderName);
    }

    public static string GetPlatFormNameByType(int type)
    {
        string name = "";
        switch (type)
        {
            case 1:
                name = "Windows";
                break;
            case 2:
                name = "Windows64";
                break;
            case 3:
                name = "IOS";
                break;
            case 4:
                name = "Android";
                break;
            default:
                break;
        }

        return name;
    }

    private static void CopyFileFromSourceToDes(int type, string from, string des)
    {
        CalculateFiles(GetPlatFormNameByType(type),from,des);
        from = from+maxVersionFolderName+"/"+GetPlatFormNameByType(type);
        Debug.Log("当前拷贝的路径是---"+from);
        // Copy files from source directory to destination directory
        foreach (string file in Directory.GetFiles(from))
        {
            string fileName = Path.GetFileName(file);
            string dest = Path.Combine(des, fileName);
            File.Copy(file, dest, true);
        }

        // Refresh asset database to reflect the changes
        AssetDatabase.Refresh();
    }

    #region Copy Packed Files To StreamingAssets

        [MenuItem("Tools/Copy Files To StreamingAssets/Packed/Win")]
        public static void CopyPCPackedWinFiles()
        {
            CopyFileFromSourceToDes(1, sourcePackedDirectory, destinationDirectory);
        }

        [MenuItem("Tools/Copy Files To StreamingAssets/Packed/Win64")]
        public static void CopyPCPackedWin64Files()
        {
            CopyFileFromSourceToDes(2, sourcePackedDirectory, destinationDirectory);
        }
        
        [MenuItem("Tools/Copy Files To StreamingAssets/Packed/IOS")]
        public static void CopyIOSPackedFiles()
        {
            CopyFileFromSourceToDes(3, sourcePackedDirectory, destinationDirectory);
        }

        [MenuItem("Tools/Copy Files To StreamingAssets/Packed/Android")]
        public static void CopyAndroidPackedFiles()
        {
            CopyFileFromSourceToDes(4, sourcePackedDirectory, destinationDirectory);
        }

    #endregion

    #region Copy Package File To StreamingAssets
        [MenuItem("Tools/Copy Files To StreamingAssets/Package/Win")]
        public static void CopyPCPackageWinFiles()
        {
            CopyFileFromSourceToDes(1, sourcePackagedDirectory, destinationDirectory);
        }

        [MenuItem("Tools/Copy Files To StreamingAssets/Package/Win64")]
        public static void CopyPCPackageWin64Files()
        {
            CopyFileFromSourceToDes(2, sourcePackagedDirectory, destinationDirectory);
        }
        
        [MenuItem("Tools/Copy Files To StreamingAssets/Package/IOS")]
        public static void CopyIOSPackageFiles()
        {
            CopyFileFromSourceToDes(3, sourcePackagedDirectory, destinationDirectory);
        }

        [MenuItem("Tools/Copy Files To StreamingAssets/Package/Android")]
        public static void CopyAndroidPackageFiles()
        {
            CopyFileFromSourceToDes(4, sourcePackagedDirectory, destinationDirectory);
        }
    #endregion
}
