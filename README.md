# cs.cli
csharp cli

- 建立專案
```bash=
dotnet new console -lang c#
```
- 在 *.csproj 下新增下面三行
```xml=
<PackAsTool>true</PackAsTool>
<ToolCommandName>csharp.cli</ToolCommandName>
<PackageOutputPath>./nupkg</PackageOutputPath>
```
- 產生 nupkg
```bash=
dotnet pack
```
- 安裝全域套件
```bash=
dotnet tool install --global --add-source .\nupkg csharp.cli
```
- 查看全域套件
```bash=
dotnet tool list -g
```
- 解除安裝全域套件
```bash=
dotnet tool uninstall -g csharp.cli
```