using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnOpen (object sender, EventArgs e)
	{
		FileChooserDialog fileChooser = new FileChooserDialog ("Choose an Image to View", this, FileChooserAction.Open, "Cancel", ResponseType.Cancel, "Open", ResponseType.Accept);
		if (fileChooser.Run () == (int)ResponseType.Accept) {

			if(fileChooser.Filename.ToLower().EndsWith(".png") || 
				fileChooser.Filename.ToLower().EndsWith(".gif") ||
				fileChooser.Filename.ToLower().EndsWith(".jpg"))
				{
					//Dispose of Old PixBuf
					if (displayImage != null && displayImage.Pixbuf != null)
						displayImage.Pixbuf.Dispose ();

					displayImage.Pixbuf = new Gdk.Pixbuf (fileChooser.Filename);
				}
		}

		fileChooser.Destroy ();
				
	}

	protected void OnAbout (object sender, EventArgs e)
	{
		var about = new AboutDialog ();
		about.ProgramName = "Blake's Image Viewer";
		about.Version = "1.0.0";
		about.Run ();

		about.Destroy ();
		               
	}
	

	protected void OnExit (object sender, EventArgs e)
	{
		Application.Quit ();
	}
	
}
