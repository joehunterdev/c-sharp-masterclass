public class Product
{
    //fields
    public int productID;
    public string productName;
    public double cost;
    public double iva;
    public int quantityInStock;
    public static int TotalNoProducts;
    public const string CategoryName = "Electronics";
    public readonly string dateOfPurchase;

    //constructor
    public Product()
    {
        dateOfPurchase = System.DateTime.Now.ToShortDateString();
    }

    public void  CalculateIva(in double percentage){

        //create local variable
        double t;
        // percentage =  10.45; // This will get an error as the local variable cannot be changed (read only)

        if (cost <= 2000)
        {
            t = cost * 21 / 1000;

        }
        else
        {
            t = percentage * 10 / 1000;
        }

        //Finally store 
        iva = t;

    }

    public void SetProductID(int value)
    {

        productID = value;

    }
    public int GetProductID()
    {

        return productID;

    }

    public void SetProductName(string value)
    {

        productName=value;

    }
    public string GetProductName(string value)
    {

        return productName;

    }

    public void SetCost(double value)
    {
        cost = value;
    }

    public double GetCost()
    {
        return cost;
    }

    public void SetTax(double value)
    {
        iva = value;
    }

    public double GetTax()
    {
        return iva;
    }


    public void SetQuantityInStock(int value)
    {
        quantityInStock = value;
    }

    public int GetQuantityInStock()
    {
        return quantityInStock;
    }

    public string GetDateOfPurchase()
    {
        return dateOfPurchase;
    }


    public static void SetTotalNumberOfProducts(int value)
    {
        TotalNoProducts = value;
    }

    //static method. Passing object refrences as arguments
    public static int GetTotalQuantity(Product product1,Product product2,Product product3)
    {
        int total;
        total = product1.GetQuantityInStock() + product2.GetQuantityInStock() + product3.GetQuantityInStock();
        return total;

    }


}

