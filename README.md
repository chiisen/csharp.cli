# cs.cli
csharp cli

- �إ߱M��
```bash=
dotnet new console -lang c#
```
- �b *.csproj �U�s�W�U���T��
```xml=
<PackAsTool>true</PackAsTool>
<ToolCommandName>csharp.cli</ToolCommandName>
<PackageOutputPath>./nupkg</PackageOutputPath>
```
- ���� nupkg
```bash=
dotnet pack
```
- �w�˥���M��
```bash=
dotnet tool install --global --add-source .\nupkg csharp.cli
```
- �d�ݥ���M��
```bash=
dotnet tool list -g
```
- �Ѱ��w�˥���M��
```bash=
dotnet tool uninstall -g csharp.cli
```