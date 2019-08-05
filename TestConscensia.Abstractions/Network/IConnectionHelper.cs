using System;

namespace TestConscensia.Abstractions.Network
{
    public interface IConnectionHelper
    {
        event EventHandler<bool> ConnectivityChanged;

        bool IsNetworkAvailable();
    }
}