using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chroma.NetCore.Api.Chroma;

namespace ChromaFormsApp
{
    public partial class FrmMain : Form
    {
        private ChromaManager chromaManager;

        public FrmMain()
        {
            InitializeComponent();

        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            if(chromaManager != null)
                return;

            chromaManager = new ChromaManager();
            chromaManager.Init();
        }

        private async void SetColorCommand_Click(object sender, EventArgs e)
        {
            var color = Color.HotPink;

            switch (((Button) sender).Text.ToLower())
            {
                case "green":
                    color = Color.Green;
                    break;
                    
                case "red":
                    color = Color.Red;
                    break;
                    
                case "white":
                    color = Color.White;
                    break;
                    
                case "blue":
                    color = Color.Blue;
                    break;

                case "yellow":
                    color = Color.Yellow;
                    break;

                default:
                    color = Color.Black;
                    break;

            }

            var result =  await chromaManager.SetColor(color);
            SetLog(result);
        }

        private async void SetDeviceCommand_Click(object sender, EventArgs e)
        {
            var color = Color.HotPink;
            var device = ((Button) sender).Text.ToLower();

            switch (device)
            {
                case "keyboard":
                    color = Color.Green;
                    break;

                case "mouse":
                    color = Color.Red;
                    break;

                case "mousepad":
                    color = Color.White;
                    break;

                case "headset":
                    color = Color.Blue;
                    break;

                case "keypad":
                    color = Color.Yellow;
                    break;

                default:
                    color = Color.Black;
                    break;

            }

            var result = await chromaManager.SetDevice(device, color);
            SetLog(result);
        }

        private void SetLog(List<RequestResponse> entries)
        {
            foreach (var entry in entries)
            {
                lstLog.Items.Insert(0,$"Device: {entry.Device} => {entry.Response}");
            }
        }

        private async void cmdUnregister_Click(object sender, EventArgs e)
        {
            var result = await chromaManager.Unregister();

        }

        private async void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = await chromaManager.Unregister();
        }
    }
}
