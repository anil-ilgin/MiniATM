using System.Text.Json;
using System.Text.Json.Serialization;

namespace ATM.Server.Models.Data
{
    public class CashDTO
    {

        [JsonPropertyName("cashAmount")]
        public int _cashAmount  { get; set; }

        [JsonPropertyName("amount")]
        public int _quantity { get; set; }

        [JsonPropertyName("cashType")]
        public string _cashType { get; set; }


        public CashDTO(int cashAmount, int amount, string cashType)
        {
            _cashAmount = cashAmount;
            _quantity = amount;
            _cashType = cashType;
        }

        public CashDTO (KeyValuePair<int,int> cashType)
        {
            _cashAmount = cashType.Key;
            _quantity = cashType.Value;
        }

        public void addCash(int amount)
        {
            _quantity += amount;
        }

        public void removeCash(int amount)
        {
            if (_quantity - amount < 0)
            {
                throw new Exception("Not enough cash in the box");
            }
            _quantity -= amount;
        }

        public int getCashAmount()
        {
            return _cashAmount;
        }
        
        public int getCashQuantity()
        {
            return _quantity;
        }

        public string getCashType()
        {
            return _cashType;
        }

        public void setCashType(string cashType)
        {
            _cashType = cashType;
        }




    }
}
