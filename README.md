# 🦈 Chomp Browser

*A sleek, low-resource custom browser built in C# WinForms with EasyTabs + WebView2.*

> ⚠️ **Currently supports Windows only.** macOS & Linux are **not supported**.

---

## 🚀 Features

- Lightweight, doesn’t hog CPU or GPU  
- Modern UI (uses GunaUI and [EasyTabs](https://github.com/dwmkerr/easytabs))  
- Embeds DuckDuckGo via [WebView2](https://learn.microsoft.com/en-us/microsoft-edge/webview2/)  
- Dark/Light mode toggle (planned)  
- Low-power mode toggle (planned)  
- Privacy protection options (planned)  

---

## 📚 Inspiration

Inspired by **[CsharpProgramming on YouTube](https://www.youtube.com/@CsharpProgramming)**, particularly this video:  
➡️ [I made a Web Browser](https://www.youtube.com/watch?v=YMX7uD2tqE0)

---

## Screenshot
![Chomp Browser Screenshot](https://github.com/d3letereal/image/blob/main/Screenshot%202025-09-27%20124214.png?raw=true)

---

## ⚙️ How It Works

Chomp is built using **C# WinForms** & .NET. It uses:

- **EasyTabs** — for tabbed UI in WinForms  
- **WebView2** — to render web content via DuckDuckGo  
- **Guna UI** — for polished UI styling  
- Custom code to manage tabs & HTML parsing

### 📁 Project Structure
ChompBrowser/

├── Program.cs

├── HTML.cs

├── AppContainer.cs

├── Main.cs

└── Main.Designer.cs

- `HTML.cs` handles custom HTML logic  
- `AppContainer.cs` manages tabs (EasyTabs integration)  
- `Main…` files manage the UI and app lifecycle  

---

## 🛠️ Getting Started

### 🔧 Requirements

- .NET Framework 4.8  
- WebView2 Runtime  
- EasyTabs NuGet package  

### 🌀 Installation

```bash
git clone https://github.com/d3letereal/Chomp_Browser.git
cd Chomp_Browser
# Open solution in Visual Studio, build & run

