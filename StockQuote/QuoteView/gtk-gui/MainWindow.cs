
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.VBox vbox2;
	
	private global::Gtk.Frame frame2;
	
	private global::Gtk.Alignment GtkAlignment;
	
	private global::Gtk.VBox vbox4;
	
	private global::Gtk.Entry entry4;
	
	private global::Gtk.Button button1;
	
	private global::Gtk.Label GtkLabel1;
	
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	
	private global::Gtk.NodeView gridQuotes;
	
	private global::Gtk.Statusbar statusbar4;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox2 = new global::Gtk.VBox ();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		this.vbox2.BorderWidth = ((uint)(10));
		// Container child vbox2.Gtk.Box+BoxChild
		this.frame2 = new global::Gtk.Frame ();
		this.frame2.Name = "frame2";
		this.frame2.ShadowType = ((global::Gtk.ShadowType)(0));
		// Container child frame2.Gtk.Container+ContainerChild
		this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
		this.GtkAlignment.Name = "GtkAlignment";
		this.GtkAlignment.LeftPadding = ((uint)(12));
		// Container child GtkAlignment.Gtk.Container+ContainerChild
		this.vbox4 = new global::Gtk.VBox ();
		this.vbox4.Name = "vbox4";
		this.vbox4.Spacing = 6;
		// Container child vbox4.Gtk.Box+BoxChild
		this.entry4 = new global::Gtk.Entry ();
		this.entry4.CanFocus = true;
		this.entry4.Name = "entry4";
		this.entry4.Text = global::Mono.Unix.Catalog.GetString ("BAC, C, CS, GS, JPM, MS, MSFT, IBM, MMM, ");
		this.entry4.IsEditable = true;
		this.entry4.InvisibleChar = '●';
		this.vbox4.Add (this.entry4);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.entry4]));
		w1.Position = 0;
		w1.Expand = false;
		w1.Fill = false;
		// Container child vbox4.Gtk.Box+BoxChild
		this.button1 = new global::Gtk.Button ();
		this.button1.CanFocus = true;
		this.button1.Name = "button1";
		this.button1.UseUnderline = true;
		this.button1.Label = global::Mono.Unix.Catalog.GetString ("Quote");
		global::Gtk.Image w2 = new global::Gtk.Image ();
		w2.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-refresh", global::Gtk.IconSize.Menu);
		this.button1.Image = w2;
		this.vbox4.Add (this.button1);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.button1]));
		w3.Position = 1;
		w3.Expand = false;
		w3.Fill = false;
		this.GtkAlignment.Add (this.vbox4);
		this.frame2.Add (this.GtkAlignment);
		this.GtkLabel1 = new global::Gtk.Label ();
		this.GtkLabel1.Name = "GtkLabel1";
		this.GtkLabel1.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>GtkFrame</b>");
		this.GtkLabel1.UseMarkup = true;
		this.frame2.LabelWidget = this.GtkLabel1;
		this.vbox2.Add (this.frame2);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.frame2]));
		w6.Position = 0;
		// Container child vbox2.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.gridQuotes = new global::Gtk.NodeView ();
		this.gridQuotes.CanFocus = true;
		this.gridQuotes.Name = "gridQuotes";
		this.GtkScrolledWindow.Add (this.gridQuotes);
		this.vbox2.Add (this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.GtkScrolledWindow]));
		w8.Position = 1;
		// Container child vbox2.Gtk.Box+BoxChild
		this.statusbar4 = new global::Gtk.Statusbar ();
		this.statusbar4.Name = "statusbar4";
		this.statusbar4.Spacing = 6;
		this.vbox2.Add (this.statusbar4);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.statusbar4]));
		w9.Position = 2;
		w9.Expand = false;
		w9.Fill = false;
		this.Add (this.vbox2);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 400;
		this.DefaultHeight = 314;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.button1.Clicked += new global::System.EventHandler (this.QuoteButton_OnClick);
	}
}
