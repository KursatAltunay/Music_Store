using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreSites.UI.MVC.Models
{
    public class MyCart
    {
        private Dictionary<int, CartItemDTO> _sepet = new Dictionary<int, CartItemDTO>();

        public List<CartItemDTO> GetAllCartItem
        {
            get
            {
                return _sepet.Values.ToList();
            }
        }

        public void Add(CartItemDTO cartitemDTO)
        {
            if (_sepet.ContainsKey(cartitemDTO.ID))
            {
                _sepet[cartitemDTO.ID].Amount += cartitemDTO.Amount;
                return;
            }
            _sepet.Add(cartitemDTO.ID, cartitemDTO);
        }

        public void Update(int id,short amount)
        {
            if (_sepet.ContainsKey(id))
            {
                _sepet[id].Amount = amount;
            }
        }
        public void Delete(int id)
        {
            if (_sepet.ContainsKey(id))
            {
                _sepet.Remove(id);
            }
        }

        //private int _total;
        //public int TotalAmount
        //{
        //    get
        //    {
              
        //        foreach (KeyValuePair<int,CartItemDTO> item in _sepet)
        //        {
        //            _total += item.Value.Amount;
        //        }
        //        return _total;
        //    }
        //}

        public int TotalAmount
        {
            get
            {
                return _sepet.Values.Sum(x => x.Amount);
            }
        }


    }
}