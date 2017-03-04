using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;
using NavDrawer.Helpers;
using Android.Support.V4.Widget;
using Android.Content.Res;

namespace NavDrawer.Activities
{
    [Activity(Label = "Drawer", MainLauncher = true, LaunchMode = LaunchMode.SingleTop)]
    public class HomeActivity : BaseActivity
    {
        private MyActionBarDrawerToggle drawerToggle;
        private string title="Drawer";
        private string drawerTitle;

        private DrawerLayout drawerLayout;
        private ListView drawerListView;
        private static readonly string[] Sections = new[] {"Jeon", "Jung", "Kook"};

        protected override int LayoutResource {
            get {
                return Resource.Layout.page_home_view;
            }
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.title = this.drawerTitle = this.Title;
            this.drawerLayout = this.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            this.drawerListView = this.FindViewById<ListView>(Resource.Id.left_drawer);
            this.drawerListView.Adapter = new ArrayAdapter<string>(this, Resource.Layout.item_menu, Sections);
            this.drawerListView.ItemClick += (sender, args) => ListItemClicked(args.Position);
            this.drawerToggle = new MyActionBarDrawerToggle(this, this.drawerLayout, this.Toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            this.drawerToggle.DrawerClosed += (o, args) =>
            {
                this.SupportActionBar.Title = this.title;
                this.InvalidateOptionsMenu();
            };

            this.drawerToggle.DrawerOpened += (o, args) =>{
                this.SupportActionBar.Title = this.drawerTitle;
                this.InvalidateOptionsMenu();                    
            };
            this.drawerLayout.SetDrawerListener(this.drawerToggle);

            if (savedInstanceState==null)
            {
                ListItemClicked(0);
            }
        }

        private void ListItemClicked(int position) {
            switch (position) {
                case 0:
                    Toast.MakeText(this, "Jeon is what I want to eat.", ToastLength.Short).Show();
                    break;
                case 1:
                    Toast.MakeText(this, "Jung is my bae's name.", ToastLength.Short).Show();
                    break;
                case 2:
                    Toast.MakeText(this, "Kook is what I want to do right now.", ToastLength.Short).Show();
                    break;
            }
            this.drawerListView.SetItemChecked(position, true);
            SupportActionBar.Title = this.title = Sections[position];
            this.drawerLayout.CloseDrawers();
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            var drawerOpen = this.drawerLayout.IsDrawerOpen((int)GravityFlags.Left);
            for (int i = 0; i < menu.Size(); i++)
                menu.GetItem(i).SetVisible(!drawerOpen);


            return base.OnPrepareOptionsMenu(menu);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            this.drawerToggle.SyncState();
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            this.drawerToggle.OnConfigurationChanged(newConfig);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (this.drawerToggle.OnOptionsItemSelected(item))
                return true;

            return base.OnOptionsItemSelected(item);

        }
    }
}