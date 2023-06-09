# cs.cli
# 介紹
C# 製作成的 CLI
- CLI 是命令列介面 (Command-Line Interface)
以指令與電腦互動
- GUI 是圖形化介面 (Graphical User Interface)

---

# CLI 常用指令有哪些？
windows 作業系統為例，常用的指令如下：  
cd	=> 切換目錄  
pwd	=> 取得目前所在位置  
cp	=> 複製檔案  

---

# 建立專案
```bash=
dotnet new console -lang c#
```
- 在 *.csproj 下新增下面三行
```xml=
<PackAsTool>true</PackAsTool>
<ToolCommandName>csharp.cli</ToolCommandName>
<PackageOutputPath>./nupkg</PackageOutputPath>
```

---

# 安裝
- 編譯
```bash=
dotnet build
```
看看有沒有錯誤訊息
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
- 測試是否安裝成功 
```bash=
csharp.cli --help
```
![help](./images/help.png)

---

# 解除安裝
- 解除安裝全域套件
```bash=
dotnet tool uninstall -g csharp.cli
```

---

# 本地安裝套件批次檔案
```bash=
.\install.bat
```
會循序進行清理目錄、打包、移除套件、安裝套件並顯示套件安裝版本  

---

# 編譯警告
搜尋 #pragma warning disable 就能找到

---

# bet-area
查詢 betArea
- c: 查詢翻譯內容
- i: 查詢 AreaId
- a: csv 指定檔案路徑，列出全部的翻譯內容
- g: 指定 bet-area.json 檔案，列出全部的翻譯內容
```bash=
csharp.cli  bet-area Bacc -c 閒
csharp.cli  bet-area Bacc -i 1
csharp.cli  bet-area Bacc -a C:\royal\github\RoyalTemporaryFile\WM\csv\百家樂.csv
csharp.cli  bet-area Bacc -a 1
```
# bet-area-all
讀取 .bet-area 設定檔案，列出 bet-area 的結果
```bash=
csharp.cli bet-area-all
```
# cache
測試 cache
```bash=
csharp.cli cache -r keyName
```
# csv
讀取 csv 的 AreaId 並且比對 betArea.json 的資料
```bash=
csharp.cli csv "C:\royal\github\RoyalTemporaryFile\WM\csv\百家樂.csv" -b Bacc
```
# echo
輸出用戶輸入的文字。
```bash=
csharp.cli echo "Hello World" -r 3
```
# environment
取得環境變數
```bash=
csharp.cli environment
```
# example
範例程式
```bash=
csharp.cli example "words" -r 10
```
# excel
EXCEL 範例程式
```bash=
csharp.cli excel
```
# json
讀取 json 範例程式
測試用只能指定特定 class 的 json 檔案
```bash=
csharp.cli json "C:\royal\github\RoyalTemporaryFile\MG\BetRecordHistory.json"
```
# multi-thread
multi-thread 範例程式
```bash=
csharp.cli multi-thread
```
# polly
重試測試。
```bash=
csharp.cli polly
```
# ps
PowerShell 範例程式
```bash=
csharp.cli ps
```
# pwd
顯示常用路徑
```bash=
csharp.cli pwd
```
# version
查詢版本號
```bash=
csharp.cli version
```
