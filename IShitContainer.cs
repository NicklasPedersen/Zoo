using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public interface IShitContainer
    {
        void PlaceShit(Shit shit);
        Shit RemoveShit();
    }
}
