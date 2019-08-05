using NETWORKLIST;
using System;
using TestConscensia.Abstractions.Network;

namespace TestConscensia.Services.Network
{
    /// <summary>
    /// Used to determine the connectivity of the application.
    /// </summary>
    public class ConnectionHelper : IConnectionHelper
    {
        public event EventHandler<bool> ConnectivityChanged;

        private readonly NetworkListManager _nlm = new NetworkListManager();

        public ConnectionHelper()
        {
            _nlm.NetworkConnectivityChanged += _nlm_NetworkConnectivityChanged;
        }

        private void _nlm_NetworkConnectivityChanged(Guid networkId, NLM_CONNECTIVITY newConnectivity)
        {
            ConnectivityChanged?.Invoke(this, IsNetworkAvailable());
        }

        /// <summary>
        /// Indicates whether any network connection is available.
        /// </summary>
        /// <returns>
        /// <c>true</c> if a network connection is available; otherwise, <c>false</c>.
        /// </returns>
        public bool IsNetworkAvailable()
        {
            return _nlm.IsConnectedToInternet;
        }
    }
}