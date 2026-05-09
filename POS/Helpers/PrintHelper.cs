using System;
using System.Drawing;

namespace POS.Helpers
{
    public static class PrintHelper
    {
        private const string CompanyName = "Ink Toonations Printing Services";
        private const string CompanyTIN = "TIN: 323-823-173-00000";
        private const string CompanyAddress = "Blk 33 Lot 15 ph6 Mabuhay City, Mamatid Cabuyao Laguna";
        private const string CompanyContact = "Contact: 09558358947";

        // Draws the narrow receipt-style header (thermal printer).
        // Returns the next yPos after the header.
        public static float DrawReceiptHeader(Graphics g, float yPos, int leftMargin, int rightMargin)
        {
            Font titleFont = new Font("Arial", 9, FontStyle.Bold);
            Font infoFont = new Font("Arial", 7);

            // Logo centered at top
            try
            {
                var logo = Properties.Resources.logo;
                if (logo != null)
                {
                    int logoSize = 48;
                    int logoX = (rightMargin - leftMargin - logoSize) / 2 + leftMargin;
                    g.DrawImage(logo, logoX, yPos, logoSize, logoSize);
                    yPos += logoSize + 4;
                }
            }
            catch { }

            g.DrawString(CompanyName, titleFont, Brushes.Black, leftMargin, yPos); yPos += 15;
            g.DrawString(CompanyTIN, infoFont, Brushes.Black, leftMargin, yPos); yPos += 12;
            // Split long address for narrow width
            g.DrawString("Blk 33 Lot 15 ph6 Mabuhay City,", infoFont, Brushes.Black, leftMargin, yPos); yPos += 12;
            g.DrawString("Mamatid Cabuyao Laguna", infoFont, Brushes.Black, leftMargin, yPos); yPos += 12;
            g.DrawString(CompanyContact, infoFont, Brushes.Black, leftMargin, yPos); yPos += 18;

            return yPos;
        }

        // Draws the wide landscape report header.
        // Returns the next yPos after the header.
        public static float DrawReportHeader(Graphics g, float yPos, int leftMargin, int rightMargin)
        {
            Font titleFont = new Font("Arial", 13, FontStyle.Bold);
            Font infoFont = new Font("Arial", 9);

            int logoSize = 60;
            int textLeft = leftMargin;
            float textY = yPos;
            bool drewLogo = false;

            try
            {
                var logo = Properties.Resources.logo;
                if (logo != null)
                {
                    g.DrawImage(logo, leftMargin, yPos, logoSize, logoSize);
                    textLeft = leftMargin + logoSize + 12;
                    drewLogo = true;
                }
            }
            catch { }

            g.DrawString(CompanyName, titleFont, Brushes.Black, textLeft, textY); textY += 22;
            g.DrawString(CompanyTIN, infoFont, Brushes.Black, textLeft, textY); textY += 15;
            g.DrawString($"Address: {CompanyAddress}", infoFont, Brushes.Black, textLeft, textY); textY += 15;
            g.DrawString(CompanyContact, infoFont, Brushes.Black, textLeft, textY); textY += 12;

            yPos = drewLogo ? Math.Max(yPos + logoSize + 4, textY) : textY + 4;
            return yPos;
        }
    }
}
