# 🦈 Chomp Browser
*A sleek, low-resource custom browser built in C# WinForms with EasyTabs + WebView2.*

## ✨ Features
- 🚀 Lightweight, doesn’t hog CPU or GPU  
- 🖥️ Modern tabbed UI (powered by [EasyTabs](https://github.com/dwmkerr/easytabs))  
- 🌐 Uses DuckDuckGo via [WebView2](https://learn.microsoft.com/en-us/microsoft-edge/webview2/)  
- 🌓 Dark & Light mode toggle (planned)  
- ⚡ Low-power mode toggle (planned)  
- 🔒 Privacy protection options (planned)  

---

## 📚 Inspiration
Chomp was inspired by **[CsharpProgramming on YouTube](https://www.youtube.com/@CsharpProgramming)**, specifically this viodeo:  
➡️ [I made a Web Browser.](https://www.youtube.com/watch?v=YMX7uD2tqE0)  

---

## ⚙️ How It Works
Chomp is made using **C# WinForms** and .NET. The project uses:
- **EasyTabs** → Manages tabs in a WinForms app.  
- **WebView2** → Provides a DuckDuckGo-based rendering engine.  
- **Custom WinForms UI** → Lightweight design with minimal resource usage.  

### Project Structure
ChompBrowser/

├── Program.cs

├── HTML.cs 

├── AppContainer.cs

├── Main.cs 

└── Main.Designer.cs

HTML - Handles all the custom HTML i make
AppContainer - Handles Easy Tabs

## 🛠️ Getting Started

### Requirements
-  .NET Framework 4.8 since prefer classic)  
- [WebView2 Runtime](https://developer.microsoft.com/en-us/microsoft-edge/webview2/)  
- EasyTabs NuGet package  

### Installation
Clone this repo:
```bash
git clone https://github.com/d3letereal/Chomp.git
