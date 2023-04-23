using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.Utility
{
    public class TemplateGenerator
    {
        public static string GetHTMLString()
        {
            var sb = new StringBuilder();
            sb.Append(@"<html>
            <head>
			</head>
            <body>
			<div class='container'>
			<div class='column-1'>
				<div class='text-frame'>
					<div class='event'></div>
					<div class='date'>26 August, 2021</div>
					<br/>
					<div class='name'>Mohammad Ahmad</div>
					<div class='ticket-id'>#123456</div>
				</div>
			</div>

			<div class='column-2'>
				<div class='qr-holder'>
					
				</div>
			</div>
		</div>
                ");

            return sb.ToString();
        }
    }
}
