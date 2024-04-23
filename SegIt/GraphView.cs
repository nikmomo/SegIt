using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace SensorDataSegmentation
{
    internal class GraphView : MasterPane
    {
        private PaneList _paneList = new PaneList();

        /// <summary>
        /// Draws the graphical component using the specified graphics context.
        /// This method configures rendering settings before drawing elements in a specific order, ensuring visual elements are layered correctly.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> context used for drawing.</param>
        /// <remarks>
        public override void Draw(Graphics g)
        {
            SmoothingMode smoothingMode = g.SmoothingMode;
            TextRenderingHint textRenderingHint = g.TextRenderingHint;
            CompositingQuality compositingQuality = g.CompositingQuality;
            InterpolationMode interpolationMode = g.InterpolationMode;

            base.Draw(g);
            if (_rect.Width <= 1f || _rect.Height <= 1f)
            {
                return;
            }

            float scaleFactor = CalcScaleFactor();
            g.SetClip(_rect);
            _graphObjList.Draw(g, this, scaleFactor, ZOrder.G_BehindChartFill);
            _graphObjList.Draw(g, this, scaleFactor, ZOrder.E_BehindCurves);
            _graphObjList.Draw(g, this, scaleFactor, ZOrder.D_BehindAxis);
            _graphObjList.Draw(g, this, scaleFactor, ZOrder.C_BehindChartBorder);
            g.ResetClip();
            foreach (GraphPane pane in _paneList)
            {
                pane.Draw(g);
            }

            g.SetClip(_rect);
            _graphObjList.Draw(g, this, scaleFactor, ZOrder.B_BehindLegend);
            RectangleF tChartRect = CalcClientRect(g, scaleFactor);
            _legend.CalcRect(g, this, scaleFactor, ref tChartRect);
            _legend.Draw(g, this, scaleFactor);
            _graphObjList.Draw(g, this, scaleFactor, ZOrder.A_InFront);
            g.ResetClip();
            g.SmoothingMode = smoothingMode;
            g.TextRenderingHint = textRenderingHint;
            g.CompositingQuality = compositingQuality;
            g.InterpolationMode = interpolationMode;
        }
    }
}
