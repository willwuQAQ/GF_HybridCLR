# GF_HybridCLR
GameFramework+HybridCLR
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

