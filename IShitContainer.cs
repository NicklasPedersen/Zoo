using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    // Container for animals to shit in
    public interface IShitContainer
    {
        void PlaceShit(Shit shit);
        Shit RemoveShit();
    }
}
