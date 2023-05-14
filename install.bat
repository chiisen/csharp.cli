echo 【請輸入 .\install.bat】

echo 【解除安裝全域套件】
del .\nupkg\*.nupkg

echo 【打包全域套件】
dotnet pack

echo 【解除安裝全域套件】
dotnet tool uninstall -g csharp.cli

echo 【安裝全域套件】
dotnet tool install --global --add-source .\nupkg csharp.cli

echo 【查看全域套件】
dotnet tool list -g