using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vosplzen.sem1.Model;

namespace vosplzen.sem1.Core
{
    public static class Localizer
    {
                
        public static PageContent GetGdprPageContent(string lanCode)
        {

            var result = new PageContent()
            {
                Language = lanCode     
            };

            if (lanCode.Equals("de"))
            {
                result.Language = lanCode;
                result.Title = "Datenshutz";
                result.Content = "Hier kann man etwas über <a href='/Privacy'>Datenschutzeinstellung</a>  lesen.";
                result.ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/b/ba/Flag_of_Germany.svg/300px-Flag_of_Germany.svg.png";

            }
            else if (lanCode.Equals("en"))
            {
                result.Language = lanCode;
                result.Title = "Privacy";
                result.Content = "Tak a short look at your <a href='/Privacy'>privacy</a> settings.";
                result.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f2/Flag_of_Great_Britain_%281707%E2%80%931800%29.svg/1920px-Flag_of_Great_Britain_%281707%E2%80%931800%29.svg.png";

            }

            return result;

        }

    }
}
