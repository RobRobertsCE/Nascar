using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Nascar.Api
{
    public class ResourceManager : IDisposable
    {
        private const string chevyLogoUrl = @"http://static.nascar.com/content/dam/nascar/articles/sidebar content/Chevy.png";
        private const string dodgeLogoUrl = @"http://static.nascar.com/content/dam/nascar/articles/sidebar content/Chevy.png";
        private const string fordLogoUrl = @"http://static.nascar.com/content/dam/nascar/articles/sidebar content/Chevy.png";
        private const string toyotLogoaUrl = @"http://static.nascar.com/content/dam/nascar/articles/sidebar content/RAM_Badge.png";

        private const string sprintCupLogoUrl = @"http://static.nascar.com/content/dam/nascar/promospots/Series%20logos/SPRINTCUP_LOGO.png";
        private const string nnsLogoUrl = @"http://static.nascar.com/content/dam/nascar/promospots/Series%20logos/NNS_LOGO.png";
        private const string cwtsLogoUrl = @"http://static.nascar.com/content/dam/nascar/promospots/Series%20logos/CWTS_LOGO.png";

        public Image GetManufacturerImage(string manufacturer)
        {
            Image returnImage = null;

            switch (manufacturer)
            {
                case "Chv":
                    {
                        returnImage = Properties.Resources.chevy_logo;
                        break;
                    }
                case "Frd":
                    {
                        returnImage = Properties.Resources.ford_logo;
                        break;
                    }
                case "Tyt":
                    {
                        returnImage = Properties.Resources.toyota_logo;
                        break;
                    }
                case "Dge":
                    {
                        returnImage = Properties.Resources.ram_logo;
                        break;
                    }
                case "RAM":
                    {
                        returnImage = Properties.Resources.ram_logo;
                        break;
                    }
                default:
                    {
                        returnImage = Properties.Resources.nascar_logo;
                        break;
                    }
            }
            return returnImage;
        }

        public Image GetNascarImage()
        {
            return Properties.Resources.nascar_logo;
        }

        public Image GetSeriesImage(int series_id)
        {
            Image returnImage = null;

            switch (series_id)
            {
                case 1:
                    {
                        returnImage = Properties.Resources.cup_logo;
                        break;
                    }
                case 2:
                    {
                        returnImage = Properties.Resources.nns_logo;
                        break;
                    }
                case 3:
                    {
                        returnImage = Properties.Resources.cwts_logo;
                        break;
                    }
                default:
                    {
                        returnImage = Properties.Resources.nascar_logo;
                        break;
                    }
            }
            return returnImage;
        }

        public Image GetVehicleNumberImage(string vehicle_number, int series_id)
        {
            return Properties.Resources.nascar_logo;
        }

        public void Dispose()
        {

        }
    }
}
