﻿namespace TrackerWPFUI;

public class Bootstrapper : BootstrapperBase
{
    public Bootstrapper()
    {
        Initialize();
    }

    protected override void OnStartup(
            object sender, 
            StartupEventArgs e)
    {
        DisplayRootViewForAsync<ShellViewModel>();
    }
}
