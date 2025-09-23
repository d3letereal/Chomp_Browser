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

        public static string Secret()
        {
            string html = @"
<!doctype html>
<html lang=""en"">
<head>
  <meta charset=""utf-8"" />
  <meta name=""viewport"" content=""width=device-width,initial-scale=1"" />
  <title>Secret Found 🎉</title>
  <style>
    html,body{height:100%;margin:0}
    body{display:flex;align-items:center;justify-content:center;background:linear-gradient(180deg,#0f172a,#021124);font-family:Inter, system-ui, -apple-system, 'Segoe UI', Roboto, 'Helvetica Neue', Arial;color:#fff}
    #stage{position:fixed;inset:0;pointer-events:none}
    .card{position:relative;z-index:5;padding:36px 48px;border-radius:16px;background:rgba(255,255,255,0.06);backdrop-filter:blur(6px);box-shadow:0 8px 30px rgba(2,6,23,0.6);text-align:center}
    h1{margin:0;font-size:34px;letter-spacing:0.4px}
    p{margin:8px 0 0;color:rgba(255,255,255,0.8)}
    .controls{margin-top:18px;display:flex;gap:8px;justify-content:center}
    button{appearance:none;border:0;padding:10px 14px;border-radius:10px;font-weight:600;cursor:pointer}
    button#again{background:#10b981;color:#042014}
    button#stop{background:#ef4444;color:#2b0b0b}
  </style>
</head>
<body>
  <canvas id=""stage""></canvas>
  <div class=""card"">
    <h1>You found the secret!</h1>
    <p>Confetti activated. Enjoy 🎉</p>
    <div class=""controls"">
      <button id=""again"">Throw confetti again</button>
      <button id=""stop"">Stop</button>
    </div>
  </div>

  <script>
    // Simple confetti on canvas — no libraries, works offline
    const canvas = document.getElementById('stage');
    const ctx = canvas.getContext('2d');
    let W = canvas.width = innerWidth;
    let H = canvas.height = innerHeight;
    window.addEventListener('resize', ()=>{W = canvas.width = innerWidth; H = canvas.height = innerHeight});

    const colors = ['#FF3CAC','#FF8A00','#F9F871','#3AE8B5','#7F5FFF','#FF6B6B'];

    class Confetti {
      constructor(x,y){
        this.x = x; this.y = y;
        this.size = Math.random()*8 + 6;
        this.angle = Math.random()*Math.PI*2;
        this.rotation = Math.random()*360;
        this.speed = Math.random()*6 + 4;
        this.vx = Math.cos(this.angle)*this.speed;
        this.vy = Math.sin(this.angle)*this.speed - 6; // give an arc
        this.gravity = 0.15 + Math.random()*0.12;
        this.friction = 0.995;
        this.color = colors[Math.floor(Math.random()*colors.length)];
        this.shape = Math.random() < 0.5 ? 'rect' : 'circle';
        this.tilt = Math.random()*0.6 - 0.3;
        this.life = 0;
        this.ttl = 240 + Math.random()*120; // time to live (frames)
      }
      update(){
        this.vy += this.gravity;
        this.vx *= this.friction;
        this.vy *= this.friction;
        this.x += this.vx;
        this.y += this.vy;
        this.rotation += this.tilt * 6;
        this.life++;
      }
      draw(ctx){
        ctx.save();
        ctx.translate(this.x,this.y);
        ctx.rotate(this.rotation * Math.PI/180);
        ctx.globalAlpha = Math.max(0, 1 - this.life/this.ttl);
        if(this.shape === 'rect'){
          ctx.fillStyle = this.color;
          ctx.fillRect(-this.size/2, -this.size/2, this.size, this.size*0.6);
        } else {
          ctx.beginPath(); ctx.fillStyle = this.color; ctx.arc(0,0,this.size*0.5,0,Math.PI*2); ctx.fill();
        }
        ctx.restore();
      }
    }

    let confetti = [];
    let running = true;

    function launchBurst(x, y, count=60){
      for(let i=0;i<count;i++) confetti.push(new Confetti(x + (Math.random()-0.5)*80, y + (Math.random()-0.5)*40));
    }

    // auto-launch from center on load
    window.addEventListener('load', ()=>{
      launchBurst(W/2, H/2, 120);
      // a couple of smaller bursts for variety
      setTimeout(()=>launchBurst(W*0.25, H*0.4, 40), 250);
      setTimeout(()=>launchBurst(W*0.75, H*0.4, 40), 450);
    });

    function loop(){
      if(!running) return;
      ctx.clearRect(0,0,W,H);
      for(let i = confetti.length-1; i>=0; i--){
        const c = confetti[i];
        c.update();
        c.draw(ctx);
        // remove offscreen or dead
        if(c.y > H + 100 || c.life > c.ttl) confetti.splice(i,1);
      }
      requestAnimationFrame(loop);
    }
    loop();

    // controls
    document.getElementById('again').addEventListener('click', ()=>{
      launchBurst(W/2, H/2, 120);
      setTimeout(()=>launchBurst(W*0.25, H*0.4, 40), 200);
      setTimeout(()=>launchBurst(W*0.75, H*0.4, 40), 400);
    });
    document.getElementById('stop').addEventListener('click', ()=>{ running=false; ctx.clearRect(0,0,W,H); confetti=[] });

    // allow click to throw confetti at click position
    window.addEventListener('click', (e)=>{
      launchBurst(e.clientX, e.clientY, 80);
    });

    // accessibility: focus shows message
    document.addEventListener('keydown', (e)=>{
      if(e.key === ' ' || e.key === 'Enter'){
        launchBurst(W/2, H/2, 120);
      }
    });
  </script>
</body>
</html>

";
            return "data:text/html;charset=utf-8," + Uri.EscapeDataString(html);
        }


    }
}
