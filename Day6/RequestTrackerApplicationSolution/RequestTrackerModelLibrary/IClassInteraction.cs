using System;

namespace RequestTrackerModelLibrary
{
    /// <summary>
    /// Represents an interface for client interactions.
    /// </summary>
    public interface IClientInteraction
    {
        /// <summary>
        /// Simulates getting an order from the client.
        /// </summary>
        void GetOrder();

        /// <summary>
        /// Simulates getting a payment from the client.
        /// </summary>
        void GetPayment();
    }
}
