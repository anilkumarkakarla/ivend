using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CXS.Mpos.POS.iOS
{
	partial class TextSettingTableViewCell : UITableViewCell
	{
		public TextSettingTableViewCell (IntPtr handle) : base (handle)
		{
		}

		public void SetTitle (string title)
		{
			TitleLabel.Text = title;
		}

		public void SetValue (string value)
		{
			SettingTextField.Text = value;
		}

		public void SetPlaceholder (string placeholder)
		{
			SettingTextField.Placeholder = placeholder;
		}

		public string GetValue ()
		{
			return SettingTextField.Text;
		}
	}
}
