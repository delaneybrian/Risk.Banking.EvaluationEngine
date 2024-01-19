//This is a Value Object -> Contains logic but two value objects are essentially the same things 

namespace Risk.Banking.EvaluationEngine.Domain
{
    public class IBAN : IEquatable<IBAN>
    {
        public IBAN(int accountNumber, string sortCode, string countryIdentifier)
        {
            AccountNumber = accountNumber;
            SortCode = sortCode;
            CountryIdentifier = countryIdentifier;
        }

        public int AccountNumber { get; private set; }

        public string SortCode { get; private set; }

        public string CountryIdentifier { get; private set; }

        public string Id { get => CountryIdentifier + SortCode + AccountNumber; }

        public bool Equals(IBAN? other)
        {
            return other.Id == Id;
        }
    }
}
