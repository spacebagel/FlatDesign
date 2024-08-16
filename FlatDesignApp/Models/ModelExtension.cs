namespace FlatDesignApp.Models;

public partial class Address
{
    public string DisplayName => ((City != null && City.Country != null) ? City.Country.Name + " " : "") + (City != null ? City.Name + " " : "") + StreetName + (BuildingNumber != null ? " " + BuildingNumber : "");
}

public partial class BankDetail
{
    public string DisplayName => (Bank != null ? Bank.Name : "") + ": " + Number;
}
