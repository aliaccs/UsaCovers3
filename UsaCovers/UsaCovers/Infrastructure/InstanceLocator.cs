using System;
using System.Collections.Generic;
using UsaCovers.ViewModels;

namespace UsaCovers.Infrastructure
{
    public class InstanceLocator
    {
        public MainViewModel  Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();

        }
    }
}
