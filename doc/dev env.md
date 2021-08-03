# 开发环境配置



## OpenCVSharp在VS中的环境配置

### 方法一：NuGet方式

首先打开VS，在【工具】选项中是否有【NeGet包管理器】，若无则先在VS中安装【NuGet包】；若有打开【管理解决方案的NuGet程序包】，在其中搜索OpenCVSharp，选择合适的点击【安装】，一直等待完成。 

### 方法二：手动下载方式

使用lib文件夹下的OpenCVSharp文件，或者在[github](https://github.com/shimat/opencvsharp/releases)下载OpenCVSharp文件，之后解压到一个文件夹，然后在【解决方案】中右键【引用】->【添加引用】，选择【浏览】，将下载文件中的OpenCvSharp.dll文件添加进引用，最后将下载文件中的OpenCvSharpExtern.dll复制到工程文件夹，并将其设置为复制到输出目录。



