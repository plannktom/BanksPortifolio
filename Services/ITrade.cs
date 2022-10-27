using System;

namespace BanksPortifolio.Services
{
    interface ITrade
    {
        double Amount(double Value); //indicates the transaction amount in dollars
        string Sector(string ClientSector); //indicates the client´s sector which can be "Public" or "Private"
        DateTime PaymentExpected(DateTime NextPaymentDate); //indicates when the next payment from the client to the bank is expected
        bool IsPoliticallyExposed(bool PoliticallyExposed); //indicates the is politically exposed person
    }
}
