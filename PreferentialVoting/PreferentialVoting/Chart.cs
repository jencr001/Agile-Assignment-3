using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using PreferentialVoting.Classes;

namespace PreferentialVoting
{
    public partial class Chart : Form
    {

        protected Result result;



        public Chart(Result _r)
        {
            InitializeComponent();
            this.result = _r;
        }


        // New OnPaint method
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // The margins are to give some space rather than drawing right on the edge of the component.
            int leftMargin = 20;
            int rightMargin = 20;
            int topMargin = 40;
            int bottomMargin = 20;

            // This are the maximum practical height and width, after we allow for some margins to make it neat.
            // Double is used here as 1 * 100 is very different from 1.1 * 100, even if we convert to an integer at the end of the process.
            double maxWidth = this.Width - leftMargin - rightMargin;
            double maxHeight = this.Height - topMargin - bottomMargin - 30;

            g.Clear(Color.WhiteSmoke);

            // Created this as a method so we can reuse it in the print functions.
            this.generateGraph(result.Rounds[0], g, leftMargin, topMargin, maxHeight, maxWidth);

            // Just to repaint any additional features.
            base.OnPaint(e);

        }

        // Method that does the real work of drawing the graph.
        private void generateGraph(Dictionary<string, int> currentRoundResult, Graphics g, int leftMargin, int topMargin, double maxHeight, double maxWidth)
        {

            int range = currentRoundResult.Values.Max(); // This could normally be gained by looking at the range of values and picking the largest.

            // Maximum width of each individual column - we need room to fit them all. 
            double columnWidth = (maxWidth / currentRoundResult.Count);

            int columnNumber = 0;

            // Loop through the values we need to display
            foreach (KeyValuePair<string, int> result in currentRoundResult)
            {

                // Here we could set different colours for different columns, which is
                // why I'm setting them in the loop.
                Pen currentPen = new Pen(Color.RoyalBlue);
                Brush currentBrush = new SolidBrush(Color.SkyBlue);
                Brush textBrush = new SolidBrush(Color.Black);

                // Calculate teh height of this particular column.
                int columnHeight = (int)((maxHeight / range) * result.Value);

                // Work out the top left corner of the column.
                int y = (int)(topMargin + maxHeight - columnHeight);
                int x = (int)(leftMargin + (columnWidth * columnNumber));

                Font font = new Font("Arial", 10);
                
                if (columnHeight == 0)
                {
                    y = (int)(topMargin + maxHeight - 35);
                    RectangleF rect = new RectangleF(x, y, (int)columnWidth, 35);
                    // Draw a filled rectangle for the column
                    g.FillRectangle(new SolidBrush(Color.FromArgb(0, Color.Red)), rect);
                    // Draw a border around it to make it look pretty
                    g.DrawRectangle(new Pen(Color.FromArgb(0, Color.Red)), Rectangle.Round(rect));
                    g.DrawString(result.Key + "\n" + result.Value, font, textBrush, rect);
                }
                else
                {
                    RectangleF rect = new RectangleF(x, y, (int)columnWidth, columnHeight);
                    // Draw a filled rectangle for the column
                    g.FillRectangle(currentBrush, rect);
                    // Draw a border around it to make it look pretty
                    g.DrawRectangle(currentPen, Rectangle.Round(rect));
                    g.DrawString(result.Key + "\n" + result.Value, font, textBrush, rect);
                }

                columnNumber++;
            }

        }

        private void PrintButton_Click(object sender, EventArgs e)
        {

            // Create a new page
            PrintDocument pd = new PrintDocument();
            // Set the event to handle it.
            pd.PrintPage += new PrintPageEventHandler(this.PrintPageEvent);
            // Print the page.
            pd.Print();
        }
        private int yPosition;
        private int roundPosition = 0;
        // This is where the work of printing each individual page occurs.
        private void PrintPageEvent(object sender, PrintPageEventArgs ev)
        {

            yPosition = 1;
            float pageHeight = ev.MarginBounds.Height;
            // Draw the graphs


            Graphics g = ev.Graphics;


            int marginLeft = ev.PageSettings.Margins.Left;


            int marginRight = ev.PageSettings.Margins.Right;
            int marginTop = ev.PageSettings.Margins.Top;
            int marginBottom = ev.PageSettings.Margins.Bottom;

            double maxHeight = ev.PageSettings.PrintableArea.Height - marginTop - marginBottom;
            double maxWidth = ev.PageSettings.PrintableArea.Width - marginLeft - marginRight;

            while (yPosition + 60 < pageHeight && roundPosition < result.Rounds.Count)
            {
                this.generateGraph(result.Rounds[roundPosition], g, marginLeft, yPosition, maxHeight, maxWidth);
                roundPosition++;
                yPosition = yPosition + (int)pageHeight;
                if (roundPosition < result.Rounds.Count)
                {
                    ev.HasMorePages = true;
                }
            }





        }
    }


}
