using BarcodeLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarCode
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            for (int index = 0; index < 2000; index++)
            {
                ProdBarcode($"test{index}", index);
            }

            
        }

        /// <summary>
        /// 根據輸入字串產生Barcode
        /// </summary>
        /// <param name="barcode"></param>
        private void ProdBarcode(String barcode,int index)
        {
            String photoSavePath = Server.MapPath("~/photo") + "\\" + $"barcode{index}.png";
            if (File.Exists(photoSavePath))
            {
                File.Delete(photoSavePath);
            }

            BarcodeLib.Barcode bc = new BarcodeLib.Barcode();

            bc.IncludeLabel = true;
            bc.LabelFont = new Font("Verdana", 8f);//標籤字型與大小
            bc.Width = 300;//標籤寬度
            bc.Height = 150;//標籤高度

            System.Drawing.Image img = bc.Encode(TYPE.CODE128, barcode, bc.Width, bc.Height);
            img.Save(photoSavePath, System.Drawing.Imaging.ImageFormat.Png);

            string path = $"Photo/barcode{index}.png";
            Literal1.Text += $"<img src='{path}'>";

        }
    }
}
