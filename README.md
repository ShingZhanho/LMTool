# Listeing Material Tool
方便學校建立聆聽考試錄音的工具。

<p align="center">
  <img src="/ListeningMaterialTool/Resources/LMTool-512.png" alt="Icon" width="100px" /></br>
  <strong>聆聽材料實用工具　LMTool</strong>
</p>

<p align="center">
          <a href="https://github.com/ShingZhanho/LMTool/blob/master/LICENSE"><img alt="GitHub license" src="https://img.shields.io/github/license/ShingZhanho/LMTool?color=lighgreen"></a>
          <a href="https://github.com/ShingZhanho/LMTool/releases/latest"><img alt="GitHub release" src="https://img.shields.io/static/v1?label=latest-release&message=v1%2E4%2E1-r&color=blue"></a>
          <img alt="GitHub release" src="https://img.shields.io/static/v1?label=latest-pre-release&message=v2.0.1-b&color=red">
</p>

<p align="center" float="left" >
  <img src="/ReadmeRes/preview-image.png" alt="Preview Image of LMTool" width="800px" />
</p>

## :tada: 專案功能正在測試中
測試版 v2.0.1-b 已支援將音訊清單儲存為 `.lmtproj` 格式的專案，方便關閉程式後再次編輯。

## 特色
* 使用ffmpeg函式庫來合成檔案，增加匯出速度；
* 簡易、明瞭的使用方式，使用者可以輕鬆掌握使用方法；
* 內置不同長度的綠袖子等候音樂及Beep音效，方便因應實際情況調整錄音長度；
* **完全免費！**

## 如何使用
### 下載
前往[發行版本頁面](/releases)來下載最新版（如果你想使用稳定的版本，請不要**下載**帶有「beta」字眼的版本。）

### 安裝
下載.zip檔案後只需要解壓檔案，就可以即時使用，**不需安裝**。

### 合成音訊檔
1. 按一下應用程式左下角「新增音訊到清單中」；
2. 在新的視窗中，按「選取檔案」，然後選取欲加入的檔案；
3. 當你所選的音訊開始播放後，按一下「入點」按鈕來選擇錄音開始的位置（圖案如下）；
<br/><img src="/ReadmeRes/trim-in.png" alt="Trim In Icon" width="30px"/><br/>
4. 按一下「出點」選取錄音結束的位置（圖案如下）；
<br/><img src="/ReadmeRes/trim-out.png" alt="Trim Out Icon" width="30px"/><br/>
5. 重複上述步驟，直至所有錄音都被增加至列表中，按一下功能選單 `檔案` > `匯出檔案`來合成所有錄音；
6. 在隨後的視窗中，選取儲存的位置及檔案名稱，然後按儲存；
7. 程式會開始處理所有檔案，完成後，程式亦會發出提示的聲音，指示作業已完成。

### 更多功能
更多詳細的使用說明，請參閱[Wiki頁面](/wiki)。
