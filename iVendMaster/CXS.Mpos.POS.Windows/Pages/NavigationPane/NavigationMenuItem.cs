using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CXS.Mpos.POS.Windows.Pages.NavigationPane
{
	public class NavigationMenuItem
	{

		public string Label
		{
			get; set;
		}
		public Symbol Symbol
		{
			get; set;
		}
		public char SymbolAsChar
		{
			get
			{
				return (char)this.Symbol;
			}
		}

		public Type DestinationPage
		{
			get; set;
		}
		public object Arguments
		{
			get; set;
		}
	}
}
