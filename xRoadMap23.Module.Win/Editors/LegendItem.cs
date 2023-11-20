using DevExpress.XtraMap.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Module.Win.Editors
{
    public class LegendItem
    {

        IModelMapLayer model;
        
        public LegendItem(IModelMapLayer model)
        {
            this.model = model;            
        }

        public string Titolo => model.Titolo;

        public string LayerName => model.LayerName;

        public bool Visible
        {
            get => model.Visible;
            set => model.Visible = value;
        }

        private Image image;
        public Image Image
        {
            get
            {
                if (image == null)
                    image = CreateImage();
                return image;
            }
        }
        
        private Image CreateImage()
        {
            Bitmap bitmap = new Bitmap(20,20, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(bitmap);

            if (model.StrokeColor.HasValue)
            {
                var pen = new Pen(model.StrokeColor.Value, model.StrokeWidth.GetValueOrDefault(10));
                graphics.DrawLine(pen, 0, 0, 20, 0);
            }
            else if (model.FillColor.HasValue)
            {
                var brush = new SolidBrush(model.FillColor.Value);
                graphics.FillEllipse(brush, 0, 0, 10, 10);
            }
            return bitmap;
        }
    }
}
