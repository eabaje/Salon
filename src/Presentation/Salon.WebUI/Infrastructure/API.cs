using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.WebUI.Infrastructure
{
    public static class API
    {

        public static class Purchase
        {
            public static string AddItemToBasket(string baseUri) => $"{baseUri}/basket/items";
            public static string UpdateBasketItem(string baseUri) => $"{baseUri}/basket/items";

            public static string GetOrderDraft(string baseUri, string basketId) => $"{baseUri}/order/draft/{basketId}";
        }



        public static class Customer
        {
            public static string AddCustomer(string baseUri) => $"{baseUri}/customer/user";
            public static string UpdateCustomer(string baseUri) => $"{baseUri}/customer/user";

            public static string GetCustomer(string baseUri, string CustomerId) => $"{baseUri}/customer/{CustomerId}";

            public static string GetCustomerbyLocation(string baseUri, string Location) => $"{baseUri}/customer/{Location}";
        }


        public static class BeautySalon
        {
            public static string AddCustomer(string baseUri) => $"{baseUri}/customer/user";
            public static string UpdateCustomer(string baseUri) => $"{baseUri}/customer/user";

            public static string GetCustomer(string baseUri, string CustomerId) => $"{baseUri}/customer/{CustomerId}";

            public static string GetCustomerbyLocation(string baseUri, string Location) => $"{baseUri}/customer/{Location}";
        }

        public static class Barber
        {
            public static string AddCustomer(string baseUri) => $"{baseUri}/customer/user";
            public static string UpdateCustomer(string baseUri) => $"{baseUri}/customer/user";

            public static string GetCustomer(string baseUri, string CustomerId) => $"{baseUri}/customer/{CustomerId}";

            public static string GetCustomerbyLocation(string baseUri, string Location) => $"{baseUri}/customer/{Location}";
        }


        public static class Booking
        {
            public static string AddCustomer(string baseUri) => $"{baseUri}/customer/user";
            public static string UpdateCustomer(string baseUri) => $"{baseUri}/customer/user";

            public static string GetCustomer(string baseUri, string CustomerId) => $"{baseUri}/customer/{CustomerId}";

            public static string GetCustomerbyLocation(string baseUri, string Location) => $"{baseUri}/customer/{Location}";
        }

        public static class Favorite
        {
            public static string AddCustomer(string baseUri) => $"{baseUri}/customer/user";
            public static string UpdateCustomer(string baseUri) => $"{baseUri}/customer/user";

            public static string GetCustomer(string baseUri, string CustomerId) => $"{baseUri}/customer/{CustomerId}";

            public static string GetCustomerbyLocation(string baseUri, string Location) => $"{baseUri}/customer/{Location}";
        }


        public static class PriceList
        {
            public static string AddCustomer(string baseUri) => $"{baseUri}/customer/user";
            public static string UpdateCustomer(string baseUri) => $"{baseUri}/customer/user";

            public static string GetCustomer(string baseUri, string CustomerId) => $"{baseUri}/customer/{CustomerId}";

            public static string GetCustomerbyLocation(string baseUri, string Location) => $"{baseUri}/customer/{Location}";
        }

        public static class ServiceType
        {
            public static string AddServiceType(string baseUri) => $"{baseUri}/ServiceType/AddServiceType";
            public static string UpdateServiceType(string baseUri) => $"{baseUri}/ServiceType/EditServiceType";

            public static string GetServiceType(string baseUri, string ServiceTypeId) => $"{baseUri}/ServiceType/{ServiceTypeId}";

            public static string GetServiceTypes(string baseUri) => $"{baseUri}/ServiceType/";
        }

        public static class Calendar
        {
            public static string AddCustomer(string baseUri) => $"{baseUri}/customer/user";
            public static string UpdateCustomer(string baseUri) => $"{baseUri}/customer/user";

            public static string GetCustomer(string baseUri, string CustomerId) => $"{baseUri}/customer/{CustomerId}";

            public static string GetCustomerbyLocation(string baseUri, string Location) => $"{baseUri}/customer/{Location}";
        }


        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId) => $"{baseUri}/{basketId}";
            public static string UpdateBasket(string baseUri) => baseUri;
            public static string CheckoutBasket(string baseUri) => $"{baseUri}/checkout";
            public static string CleanBasket(string baseUri, string basketId) => $"{baseUri}/{basketId}";
        }

        public static class Order
        {
            public static string GetOrder(string baseUri, string orderId)
            {
                return $"{baseUri}/{orderId}";
            }

            public static string GetAllMyOrders(string baseUri)
            {
                return baseUri;
            }

            public static string AddNewOrder(string baseUri)
            {
                return $"{baseUri}/new";
            }

            public static string CancelOrder(string baseUri)
            {
                return $"{baseUri}/cancel";
            }

            public static string ShipOrder(string baseUri)
            {
                return $"{baseUri}/ship";
            }
        }

        public static class Catalog
        {
            public static string GetAllCatalogItems(string baseUri, int page, int take, int? brand, int? type)
            {
                var filterQs = "";

                if (type.HasValue)
                {
                    var brandQs = (brand.HasValue) ? brand.Value.ToString() : string.Empty;
                    filterQs = $"/type/{type.Value}/brand/{brandQs}";

                }
                else if (brand.HasValue)
                {
                    var brandQs = (brand.HasValue) ? brand.Value.ToString() : string.Empty;
                    filterQs = $"/type/all/brand/{brandQs}";
                }
                else
                {
                    filterQs = string.Empty;
                }

                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
            }

            public static string GetAllBrands(string baseUri)
            {
                return $"{baseUri}catalogBrands";
            }

            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}catalogTypes";
            }
        }
    }
}
