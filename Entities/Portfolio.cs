using System;
using System.Globalization;
using BanksPortifolio.Services;
using BanksPortifolio.Enum;

namespace BanksPortifolio.Entities
{
    class Portfolio : ITrade
    {
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }

        public double Amount(double _amount)
        {
            return _amount;
        }

        public string Sector(string _sector)
        {
            return _sector;
        }

        public DateTime PaymentExpected(DateTime _paymentExpected)
        {
            return _paymentExpected;
        }

        public bool IsPoliticallyExposed(bool _isPoliticallyExposed)
        {
            return _isPoliticallyExposed;
        }

        public Portfolio(double value, string clientSector, DateTime nextPaymentDate)
        {
            Value = Amount(value);
            ClientSector = Sector(clientSector);
            NextPaymentDate = PaymentExpected(nextPaymentDate);
        }

        public string ClassifiesCliente(bool isEsposed, double value, string clientSector, DateTime nextPaymentDate, DateTime referenceDate)       
        {
            //1.EXPIRED: Trades whose next payment date is late by more than 30 days based on a reference date which will be given.
            //2.HIGHRISK: Trades with value greater than 1,000,000 and client from Private Sector.
            //3.MEDIUMRISK: Trades with value greater than 1,000,000 and client from Public Sector

            Enum.ClientCategory.Category category = new ClientCategory.Category();

            if (isEsposed)
            {
                category = Enum.ClientCategory.Category.PEP;
            }
            else if ((int)referenceDate.Subtract(nextPaymentDate).TotalDays > 30)
            {
                category = Enum.ClientCategory.Category.Expired;
            }
            else if ((value >= 1000000) && ((clientSector).ToLower() == "private"))
            {
                category = Enum.ClientCategory.Category.HighRisk;
            }
            else if((value >= 1000000) && ((clientSector).ToLower() == "public"))
            {
                category = Enum.ClientCategory.Category.MediunRisk;
            }

            return category.ToString().ToUpper();
        }

        public override string ToString()
        {
            return Value.ToString("F2", CultureInfo.InvariantCulture) + ' ' +
                   ClientSector + ' ' +
                   NextPaymentDate;
        }
    }
}
