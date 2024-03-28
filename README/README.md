# GF_HybridCLR
GameFramework+HybridCLR

## 工程结构
![ProjectSturcture](E:\Demo\GF_HybridCLR\README\ProjectSturcture.png)
Editor:	项目外工具包
-ResourceRuleEditor	AB包体配置工具
-BuildScript	打包对应平台工具
-CopyFilesToStreamingAssets	拷贝ab包资源到StreamAssets
-MsvcStdextWorkaround	
-PlayMainSceneFirst	启动场景列表中第一个场景
Game
-Configs	工程相关配置文件夹
-DataTables	项目内数据配表文件夹
-Entities	Entities预制体文件夹
-Fonts	字体文件夹	
-HybridCLR	热更新程序集文件夹
-Libraries	项目相关插件文件夹
-Localization	多语言配置文件夹
-Materials	材质文件夹
-Meshes	网格文件夹
-Music	音频文件夹
-Other	其他
-Scenes	场景文件夹
-Scripts	脚本文件夹
--Base	项目基础代码
--Editor	项目相关工具
--Hotfix	可热更代码文件夹
-Sounds	音效文件夹
-Textures 纹理文件夹
-UI	UI相关预制体文件夹
GameFramework	框架相关文件夹
Resources	包体内资源文件

## GameFramework 流程状态梳理
**ProcedureLaunch(入口流程):**
1.构建BuildInfo数据(游戏版本,远端资源目录).
2.语言配置.
3.根据语言配置资源变体.
4.声音配置
5.多语言文本字段加载.

判断当前资源加载模式(ResourceMode)
编辑器模式 => 切换流程到 **ProcedureCodeInit(热更DLL初始化流程)**
单机模式 => 切换流程到 **ProcedureResourcesInit(加载资源流程)**
可更新模式 => 切换流程到 **ProcedureVersionCheck(版本检测流程)**

**ProcedureResourcesInit(加载资源流程)**
1.根据<u>GameFrameworkVersion.dat</u>初始化资源信息到内存中.
2.在所有资源信息初始化完成后,切换流程 => **ProcedureCodeInit**

**ProcedureCodeInit(热更DLL初始化流程)**
1.去资源路径下加载Game.Hotfix.dll.bytes程序集.
2.加载成功后,通过反射执行**GameHotfixEntry.Start**函数.

**GameHotfixEntry(热更程序集入口类)**
1.AOT程序集补充元数据.
2.重置流程状态机.
3.初始化新流程状态机,添加可热更流程状态.
4.切换流程 => **ProcedurePreload(预加载流程)**

**ProcedureVersionCheck(版本检测流程)**
1.根据<u>BuildInfo.txt</u>中<u>CheckVersionUrl</u> 参数,向服务器请求版本信息.
2.请求成功.解析版本信息"{Platform}Version.txt".
3.检测是否需要强更m_VersionInfo.ForceUpdateGame.
4.设置资源更新地址GameEntry.Resource.UpdatePrefixUri.
5.检测资源列表是否需要更新GameEntry.Resource.CheckVersionList.

(1) 需要更新资源
传入状态机内部参数VersionListLength(资源版本列表长度),VersionListHashCode(资源版本列表哈希值),VersionListCompressedLength(资源版本列表压缩后长度),VersionListCompressedHashCode(资源版本列表压缩后哈希值)供**ProcedureVersionUpdate(版本资源列表更新流程)**使用
(2) 无需更新资源
切换流程 => **ProcedureResourcesVerify(资源列表校验流程)**
(3) 需要强更
弹出强更提示窗口 => 跳转更新页面

**ProcedureVersionUpdate(版本资源列表更新流程)**
1.更新从服务器请求到的对应版本信息.
2.下载对应版本资源列表信息(.dat文件).
3.更新成功 切换流程 => **ProcedureResourcesVerify(资源列表校验流程)**

**ProcedureResourcesVerify(资源列表校验流程)**
1.根据资源列表信息,去请求下载对应资源.
2.下载完成后,切换流程到**ProcedureResourcesCheck(资源检测流程)**,检测当前本地所有资源是否需要更新.
3.无需更新资源 切换流程 => **ProcedureCodeInit(热更DLL初始化流程)**

**ProcedureResourcesCheck(资源检测流程)**
1.配置需要更新资源数量,需要更新资源压缩后大小.
2.判断当前网络状态(运营商网络 or WIFI).
3.更新目标队列资源.
4.更新完成 切换流程 =>  **ProcedureCodeInit(热更DLL初始化流程)**

## 资源加载
1.下载{Platform}Version.txt文件,和本地GameFrameworkVersion中InternalResourceVersion参数.如果不相同则改变检查版本资源列表结果

### 资源加载流程



### 资源打包步骤

![Build](E:\Demo\GF_HybridCLR\README\Build.png)



![ResourceRuleEditorEntry](E:\Demo\GF_HybridCLR\README\ResourceRuleEditorEntry.png)



![ResourceRuleEditor](E:\Demo\GF_HybridCLR\README\ResourceRuleEditor.png)

**ResourceSyncTools**
![ResourceSyncTools](E:\Demo\GF_HybridCLR\README\ResourceSyncTools.png)
1.移除项目中所有的AB name.
2.通过 ResourceCollection.xml 文件将 AB Name 设置给对应的资源
3.通过项目中AB name 生成 ResourceCollection.xml

**ResourceAnalyzer**
Asset Dependency Viewer 按钮展示 Resource 中所有 Asset，点击选择 Asset 右侧展示它依赖的 Resource、依赖的 Asset、依赖的散资源 (未被 ab 管理的)。

Scattered Asset Viewer 按钮展示被依赖的散资源被哪些 Asset 依赖，只有被依赖的数目大于 1 的散资源才展示。

Circular Dependency Viewer 按钮 展示项目中资源循环依赖的 ，2017 及以上版本的 Unity 已经不能资源循环依赖，5.6.7 版本的 Unity 可以。

