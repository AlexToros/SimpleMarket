using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace GameStore
{
    public enum SessionKey
    {
        CART,
        RETURN_URL
    }

    public static class SessionHelper
    {
        public static void Set(HttpSessionState session, SessionKey key, object value)
        {
            session[Enum.GetName(typeof(SessionKey), key)] = value;
        }

        public static T Get<T>(HttpSessionState session, SessionKey key)
        {
            object data = session[Enum.GetName(typeof(SessionKey), key)];

            if (data != null && data is T)
                return (T)data;
            else
                return default(T);
        }

        public static Cart GetCart(HttpSessionState session)
        {
            Cart cart = Get<Cart>(session, SessionKey.CART);
            if (cart == null)
            {
                cart = new Cart();
                Set(session, SessionKey.CART, cart);
            }
            return cart;
        }
    }
}