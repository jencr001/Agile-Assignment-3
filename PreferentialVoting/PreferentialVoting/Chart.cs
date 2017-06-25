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
    /// <summary>
    /// Generates the graph and prints the report
    /// </summary>
    public partial class Chart : Form
    {
        protected Result result;        // The result so the graph can be generated
        private int yPosition;          // The position of the top of the page
        private int roundPosition = 0;  // The current round number

        #region Constructor
        /// <summary>
        /// Construcutor
        /// </summary>
        /// <param name="_r">Instance of the result</param>
        public Chart(Result _r)
        {
            InitializeComponent();
            this.result = _r;
        }
        #endregion

        #region Graph
        /// <summary>
        /// Sets up the parameters for the graph to be generated
        /// </summary>
        /// <param name="e">The extra messages</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // The margins are to give some space rather than drawing right on the edge of the component
            int leftMargin = 20;
            int rightMargin = 20;
            int topMargin = 40;
            int bottomMargin = 20;

            // This are the maximum practical height and width, after we allow for some margins to make it neat.
            // Double is used here as 1 * 100 is very different from 1.1 * 100, even if we convert to an integer at the end of the process.
            double maxWidth = this.Width - leftMargin - rightMargin;
            double maxHeight = this.Height - topMargin - bottomMargin - 30;

            g.Clear(Color.WhiteSmoke);

            // Generate the graph
            this.generateGraph(result.Rounds[result.Rounds.Count - 1], g, leftMargin, topMargin, maxHeight, maxWidth);

            // Repaints any additional features
            base.OnPaint(e);
        }

        /// <summary>
        /// Generates a graph for the tally of votes for each candidate
        /// </summary>
        /// <param name="currentRoundResult">The round to generate the results of</param>
        /// <param name="g">The Graphic to construct</param>
        /// <param name="leftMargin">The left side margin</param>
        /// <param name="topMargin">The top margin</param>
        /// <param name="maxHeight">The maximum height the graph can be</param>
        /// <param name="maxWidth">The maximum width the graph can be</param>
        private void generateGraph(Dictionary<string, int> currentRoundResult, Graphics g, int leftMargin, int topMargin, double maxHeight, double maxWidth)
        {
            int range = currentRoundResult.Values.Max();    // The heighest a column can be

            // Maximum width of each individual column - we need room to fit them all. 
            double columnWidth = (maxWidth / currentRoundResult.Count);

            int columnNumber = 0;

            // The different colours for the outline and fill of the rectangle and the text 
            Pen currentPen = new Pen(Color.RoyalBlue);
            Brush currentBrush = new SolidBrush(Color.SkyBlue);
            Brush textBrush = new SolidBrush(Color.Black);
            Font font = new Font("Arial", 10);

            // Loop through the vote tally for each candidate
            foreach (KeyValuePair<string, int> result in currentRoundResult)
            {
                // Calculate the height of a particular column
                int columnHeight = (int)((maxHeight / range) * result.Value);

                // Work out the top left corner of the column
                int y = (int)(topMargin + maxHeight - columnHeight);
                int x = (int)(leftMargin + (columnWidth * columnNumber));

                // Checks if the column height is 0, i.e. there are no votes, so a column can be added stating they had 0 votes
                if (columnHeight == 0)
                {
                    // Builds the rectangle with the correct height representing the number of votes
                    y = (int)(topMargin + maxHeight - 35);
                    RectangleF rect = new RectangleF(x, y, (int)columnWidth, 35);

                    // Draw a filled rectangle for the column giving an outline and some information for the column
                    g.FillRectangle(new SolidBrush(Color.FromArgb(0, Color.Red)), rect);
                    g.DrawRectangle(new Pen(Color.FromArgb(0, Color.Red)), Rectangle.Round(rect));
                    g.DrawString(result.Key + "\n" + result.Value, font, textBrush, rect);
                }
                else
                {
                    // Builds the rectangle with the correct height representing the number of votes
                    RectangleF rect = new RectangleF(x, y, (int)columnWidth, columnHeight);

                    // Draw a filled rectangle for the column giving an outline and some information for the column
                    g.FillRectangle(currentBrush, rect);
                    g.DrawRectangle(currentPen, Rectangle.Round(rect));
                    g.DrawString(result.Key + "\n" + result.Value, font, textBrush, rect);
                }
                columnNumber++;
            }
        }
        #endregion

        #region Print
        /// <summary>
        /// Prints the page
        /// </summary>
        /// <param name="sender">The handle to the button</param>
        /// <param name="e">The extra messages</param>
        private void PrintButton_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument(); // New page

            // Set the event to handle it and print it
            pd.PrintPage += new PrintPageEventHandler(this.PrintPageEvent);
            pd.Print();
        }

        /// <summary>
        /// So each page can be printed
        /// </summary>
        /// <param name="sender">The handle to the page</param>
        /// <param name="ev">The extra messages</param>
        private void PrintPageEvent(object sender, PrintPageEventArgs ev)
        {
            yPosition = 1;
            float pageHeight = ev.MarginBounds.Height;

            // Draw the graphs on the page similar to how the OnPaint method works
            Graphics g = ev.Graphics;

            int marginLeft = ev.PageSettings.Margins.Left;
            int marginRight = ev.PageSettings.Margins.Right;
            int marginTop = ev.PageSettings.Margins.Top;
            int marginBottom = ev.PageSettings.Margins.Bottom;

            double maxHeight = ev.PageSettings.PrintableArea.Height - marginTop - marginBottom;
            double maxWidth = ev.PageSettings.PrintableArea.Width - marginLeft - marginRight;

            // For each round add the results to the page
            while (yPosition + 60 < pageHeight && roundPosition < result.Rounds.Count)
            {
                // Adds the round number to each page
                string title = "Round " + (roundPosition + 1);
                Brush textBrush = new SolidBrush(Color.Black);
                Font font = new Font("Arial", 10);
                g.DrawString(title, font, textBrush, new PointF(0, 0));

                // Generate the graph and recalculate the starting position
                this.generateGraph(result.Rounds[roundPosition], g, marginLeft, yPosition, maxHeight, maxWidth);
                roundPosition++;
                yPosition = yPosition + (int)pageHeight;

                // Checks if there are more pages to print
                if (roundPosition < result.Rounds.Count)
                {
                    ev.HasMorePages = true;
                }
            }
        }
        #endregion
    }
}
