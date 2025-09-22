using System;

namespace Chomp.HTML
{
    internal static class HTML
    {
        public static string HomePage()
        {
            string html = @"
<!DOCTYPE html>
<html>
<head>
    <title>Chomp Home</title>
    <style>
        html, body { height:100%; margin:0; background-color: rgb(36,36,36); color:white; font-family:Arial,sans-serif; }
        body { display:flex; justify-content:center; align-items:center; flex-direction:column; text-align:center; }
        h1 { margin:0 0 20px 0; font-size:5vw; }
        img { width:20vw; max-width:400px; height:auto; }
    </style>
</head>
<body>
    <h1>Chomp</h1>
    <h2>take a byte out the web</h2>
    <img src='https://raw.githubusercontent.com/d3letereal/image/refs/heads/main/Screenshot_2025-09-22_022548-removebg-preview.png' alt='Home Image'>
</body>
</html>";
            return "data:text/html;charset=utf-8," + Uri.EscapeDataString(html);
        }

        public static string BytePage()
        {
            string html = @"
<!DOCTYPE html>
<html>
<head>
    <title>Chomp Byte</title>
    <style>
        html, body { height:100%; margin:0; background-color: rgb(32,32,32); color:white; font-family:Arial,sans-serif; }
        body { display:flex; justify-content:center; align-items:center; flex-direction:column; text-align:center; }
        h1 { margin:0 0 20px 0; font-size:5vw; }
        img { width:20vw; max-width:400px; height:auto; }
    </style>
</head>
<body>
    <h1>Chomp Byte</h1>
    <img src='https://raw.githubusercontent.com/d3letereal/image/refs/heads/main/Screenshot_2025-09-22_022548-removebg-preview.png' alt='Byte Image'>
</body>
</html>";
            return "data:text/html;charset=utf-8," + Uri.EscapeDataString(html);
        }

        public static string OfflinePage()
        {
            string html = @"
<!DOCTYPE html>
<html>
<head>
    <title>Offline</title>
    <style>
        html, body { height:100%; margin:0; background-color: rgb(32,32,32); color:white; font-family:Arial,sans-serif; }
        body { display:flex; justify-content:center; align-items:center; flex-direction:column; text-align:center; }
        h1 { margin:0 0 20px 0; font-size:5vw; }
        p { font-size:1.5vw; }
    </style>
</head>
<body>
    <h1>Offline</h1>
    <p>No internet connection detected. Please check your network.</p>
</body>
</html>";
            return "data:text/html;charset=utf-8," + Uri.EscapeDataString(html);
        }
    }
}
