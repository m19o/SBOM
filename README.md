# Simple Web Browser

A native Windows web browser built with C# and WebView2.

## Features
- Native Windows application
- Modern WebView2 rendering engine (same as Microsoft Edge)
- Navigation controls (Back, Forward, Refresh)
- URL bar with automatic https:// prefix
- High performance and native integration

## Requirements
- Windows 10 or later
- .NET 6.0 or later
- WebView2 Runtime (will be installed automatically if not present)

## Building the Application

1. Install Visual Studio 2022 or later with .NET desktop development workload
2. Open the solution in Visual Studio
3. Build the solution (F6 or Build > Build Solution)
4. Run the application (F5)

## Usage
- Double-click SimpleBrowser.exe to run
- Use the URL bar to enter website addresses
- Use the Back, Forward, and Refresh buttons for navigation
- Press Enter in the URL bar to load a new page

## Distribution
The application can be distributed as a single executable. Users will need:
1. The SimpleBrowser.exe file
2. .NET 6.0 Runtime (if not already installed)
3. WebView2 Runtime (if not already installed)

Note: Both .NET Runtime and WebView2 Runtime are commonly pre-installed on modern Windows systems. 